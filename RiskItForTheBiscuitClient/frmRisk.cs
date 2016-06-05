using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RiskItForTheBiscuit.Risk;
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
            foreach (Continent continent in Game.Continents.Where(c => !c.Contains(selectedTerritory)))
            {
                //continent.Draw(g);
            }

            if (selectedTerritory != null)
            {
                foreach (Territory territory in Game.Continents.First(c => c.Contains(selectedTerritory)))
                {
                    //territory.DrawLabel(g);
                }
                //selectedTerritory.GetAttackableNeighbours().ForEach(n => n.DrawAttackable(g));
            }
        }

        private void select(Territory newlySelectedTerritory)
        {
            if (selectedTerritory != newlySelectedTerritory && newlySelectedTerritory != null)
            {
                selectSound.Play();
            }
            selectedTerritory = newlySelectedTerritory;
            pbMap.Refresh();

        }

        private void attack(Territory attackedTerritory)
        {
            if (attackedTerritory != null && selectedTerritory.CanAttack(attackedTerritory))
            {
                attackSound.Play();
            }
            pbMap.Refresh();
        }

        public void clickOnGame(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Territory clicked = Game.TerritoryOnCoordinates(e.Location);
                select(clicked);
            }
            else  if (e.Button == MouseButtons.Right)
            {
                Territory clicked = Game.TerritoryOnCoordinates(e.Location);
                attack(clicked);
            }
        }
    }
}
