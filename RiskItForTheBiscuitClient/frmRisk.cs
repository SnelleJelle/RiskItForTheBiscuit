using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskItForTheBiscuit.Risk;
using System.Diagnostics;
using System.Xml.Linq;
using RiskItForTheBiscuit.Risk.Extension;
using System.Media;
using System.Drawing.Drawing2D;
using RiskItForTheBiscuitClient.Drawing;

namespace RiskItForTheBiscuitClient
{
    public partial class frmRisk : Form
    {
        public Game Game { get; set; }
        
        private SoundPlayer attackSound = new SoundPlayer(@"../../Resources/Attack.wav");
        private SoundPlayer selectSound = new SoundPlayer(@"../../Resources/Select.wav");
        private Image backGround = Properties.Resources.risk_world_map1264x839;

        private Territory selectedTerritory;

        public frmRisk(Game game)
        {
            InitializeComponent();

            this.Game = game;

            GameOverview overview = new GameOverview(game);
            overview.Location = new Point(Game.GameSize);
            this.Controls.Add(overview);

            this.pbMap.Image = backGround;
        }

        private void frmRisk_Load(object sender, EventArgs e)
        {

        }

        private void pbMap_Paint(object sender, PaintEventArgs e)
        {
            drawGame(e.Graphics);
        }       

        private void pbMap_MouseClick(object sender, MouseEventArgs e)
        {
            clickOnGame(e);
        }

        private void drawGame(Graphics g)
        {
            //settings 
            g.SmoothingMode = SmoothingMode.HighQuality;

            //bg
            g.DrawFullImg(backGround);

            //continents
            foreach (Continent continent in Continents.Where(c => !c.Contains(SelectedTerritory)))
            {
                continent.Draw(g);
            }

            if (SelectedTerritory != null)
            {
                foreach (Territory territory in Continents.First(c => c.Contains(SelectedTerritory)))
                {
                    territory.DrawLabel(g);
                }
                SelectedTerritory.GetAttackableNeighbours().ForEach(n => n.DrawAttackable(g));
            }
        }

        private void select(Territory newlySelectedTerritory)
        {
            if (newlySelectedTerritory != null)
            {
                selectSound.Play();
                if (selectedTerritory != null)
                {
                    selectedTerritory.IsSelected = false;
                    newlySelectedTerritory.IsSelected = true;
                    selectedTerritory = newlySelectedTerritory;
                }
                else // selectedTerritory == null
                {
                    newlySelectedTerritory.IsSelected = true;
                    selectedTerritory = newlySelectedTerritory;
                }
            }
            else // newlySelectedTerritory == null
            {
                if (selectedTerritory != null)
                {
                    selectedTerritory.IsSelected = false;
                }
                selectedTerritory = null;
            }
            pbMap.Refresh();
        }

        private void attack(Territory newlySelectedTerritory)
        {
            if (newlySelectedTerritory != null && selectedTerritory.GetAttackableNeighbours().Contains(newlySelectedTerritory))
            {
                attackSound.Play();
            }
            pbMap.Refresh();
        }

        public void clickOnGame(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Territory clicked = getTerritoryFromClick(e.Location);
                select(clicked);
            }
            else // e.Button == MouseButtons.Left
            {
                Territory clicked = getTerritoryFromClick(e.Location);
                attack(clicked);
            }
        }
    }
}
