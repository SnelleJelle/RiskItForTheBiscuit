using RiskItForTheBiscuit.Risk;
using RiskItForTheBiscuitClient.Drawing;
using RiskItForTheBiscuitClient.Properties;
using RiskItForTheBiscuitGame.Risk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace RiskItForTheBiscuitClient
{
    public partial class frmRisk : Form
    {
        public Game Game { get; set; }
        private Territory selectedTerritory = Game.Sea;

        private SoundPlayer attackSound = new SoundPlayer(Resources.Attack);
        private SoundPlayer selectSound = new SoundPlayer(Resources.Select);
        private Image backGround = Resources.risk_world_map1264x839;
        private GameOverview overviewPanel;

        public frmRisk(Game game)
        {
            InitializeComponent();

            this.Game = game;
            game.LabelFont = GraphicsExtension.labelFont;
            game.Start();

            overviewPanel = new GameOverview();
            overviewPanel.Game = game;
            int heightDifference = 24;
            overviewPanel.Location = new Point(this.Game.GameSize.Width, heightDifference);
            overviewPanel.Size = new Size(this.ClientSize.Width - backGround.Width, this.ClientSize.Height - heightDifference);
            overviewPanel.BringToFront();
            overviewPanel.RefreshUi();
            this.Controls.Add(overviewPanel);
            
            this.pbRiskMap.Image = backGround;
            this.pbRiskMap.Size = backGround.Size;

            game.GetAllTerritories().First(t => t.Name == "Venezuela").NrOfSoldiers = 100;
            game.GetAllTerritories().First(t => t.Name == "Brazil").NrOfSoldiers = 100;
        }

        private void frmRisk_Load(object sender, EventArgs e)
        {

        }

        private void pbRiskMap_Paint(object sender, PaintEventArgs e)
        {
            drawItemsOnMap(e.Graphics);
        }       

        private void pbRiskMap_MouseClick(object sender, MouseEventArgs e)
        {
            clickOnGame(e);
        }

        private void drawItemsOnMap(Graphics g)
        {
            // settings 
            g.SmoothingMode = SmoothingMode.HighQuality;

            // bg
            // g.DrawFullImg(backGround);

            // territories
            List<Territory> alreadyDrawn = new List<Territory>();
            if (selectedTerritory != Game.Sea)
            {
                g.DrawLabel(selectedTerritory, true);
                alreadyDrawn.Add(selectedTerritory);
                foreach(Territory territory in selectedTerritory.GetAttackableNeighbours(true))
                {
                    g.DrawAttackableLabel(territory);
                    alreadyDrawn.Add(territory);
                }
            }
            foreach (Territory territory in Game.GetAllTerritories().Except(new List<Territory>(alreadyDrawn)))
            {
                g.DrawLabel(territory);        
            }
        }

        private void select(Territory newlySelectedTerritory)
        {
            if (selectedTerritory != newlySelectedTerritory && newlySelectedTerritory != Game.Sea)
            {
                selectSound.Play();
            }
            selectedTerritory = newlySelectedTerritory;
            overviewPanel.Select(newlySelectedTerritory);
        }

        private void attack(Territory attackedTerritory)
        {
            if (attackedTerritory != Game.Sea && selectedTerritory.CanAttack(attackedTerritory))
            {
                attackSound.Play();
                Attack attack = attackedTerritory.Attack().From(selectedTerritory);
                overviewPanel.DisplayAttack(attack);
            }
        }

        public void clickOnGame(MouseEventArgs e)
        {
            Territory clicked = Game.TerritoryOnCoordinates(e.Location);
            if (e.Button == MouseButtons.Left)
            {
                select(clicked);
            }
            else  if (e.Button == MouseButtons.Right)
            {
                attack(clicked);
            }
            pbRiskMap.Refresh();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Graphics g = e.Graphics;

            using (Brush brush = new SolidBrush(Color.FromArgb(25, 35, 50)))
            {
                Rectangle menuBackground = this.ClientRectangle;
                menuBackground.Height = 30;
                g.FillRectangle(brush, menuBackground);
            }
        }
    }
}
