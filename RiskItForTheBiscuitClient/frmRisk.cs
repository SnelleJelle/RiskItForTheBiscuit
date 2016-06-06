using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RiskItForTheBiscuit.Risk;
using System.Media;
using System.Drawing.Drawing2D;
using RiskItForTheBiscuitClient.Drawing;
using RiskItForTheBiscuitGame.Risk;
using System.Collections.Generic;

namespace RiskItForTheBiscuitClient
{
    public partial class frmRisk : Form
    {
        public Game Game { get; set; }
        private Territory selectedTerritory;

        private SoundPlayer attackSound = new SoundPlayer(@"../../Resources/Attack.wav");
        private SoundPlayer selectSound = new SoundPlayer(@"../../Resources/Select.wav");
        private Image backGround = Image.FromFile(@"../../Resources/risk_world_map1264x839.jpg");

        public frmRisk(Game game)
        {
            InitializeComponent();

            this.Game = game;

            GameOverview overview = new GameOverview(game);
            overview.Location = new Point(this.Game.GameSize);
            this.Controls.Add(overview);

            this.pbRiskMap.Image = backGround;
        }

        private void frmRisk_Load(object sender, EventArgs e)
        {

        }

        private void pbRiskMap_Paint(object sender, PaintEventArgs e)
        {
            drawGame(e.Graphics);
        }       

        private void pbRiskMap_MouseClick(object sender, MouseEventArgs e)
        {
            clickOnGame(e);
        }

        private void drawGame(Graphics g)
        {
            //settings 
            g.SmoothingMode = SmoothingMode.HighQuality;

            //bg
            g.DrawFullImg(backGround);

            // territories
            if (selectedTerritory != Game.Sea)
            {
                g.DrawLabel(selectedTerritory.LabelCoordinates, selectedTerritory.Name, selectedTerritory.NrOfSoldiers, selectedTerritory.Owner.PlayerColor, true);
            }
            foreach (Territory t in Game.GetAllTerritories().Except(new List<Territory>{selectedTerritory}))
            {
                g.DrawLabel(t.LabelCoordinates, t.Name, t.NrOfSoldiers, t.Owner.PlayerColor);
            }
        }

        private void select(Territory newlySelectedTerritory)
        {
            if (selectedTerritory != newlySelectedTerritory && newlySelectedTerritory != Game.Sea)
            {
                selectSound.Play();
            }
            selectedTerritory = newlySelectedTerritory;

        }

        private void attack(Territory attackedTerritory)
        {
            if (attackedTerritory != Game.Sea && selectedTerritory.CanAttack(attackedTerritory))
            {
                attackSound.Play();
            }
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
            pbRiskMap.Refresh();
        }
    }
}
