using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskItForTheBiscuitGame.Risk;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Media;

namespace RiskItForTheBiscuit.Risk
{
    public partial class GameOverview : UserControl
    {
        private Game game;
        private Attack attack { get; set; }
        private Territory selectedTerritory { get; set; } = Game.Sea;
        private SoundPlayer diceSound = new SoundPlayer(@"../../Resources/Dice.mp3");

        public GameOverview(Game game)
        {
            InitializeComponent();

            this.game = game;
            RefreshUi();

        }

        private void GameOverview_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawArc(Pens.AliceBlue, new Rectangle(5, 5, 50, 50), 5f, 10f);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.FromArgb(25, 35, 50),
                                                                       Color.FromArgb(40, 50, 65),
                                                                       0f))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // base.OnPaint(e); // Draws glitchy white pixels

            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.WhiteSmoke) { Width = 1};
            int height = 47;
            g.DrawLine(pen, 0, height, this.ClientSize.Width, height);
        }

        public void Select(Territory selectedTerritory)
        {
            this.selectedTerritory = selectedTerritory;
            this.attack = null;
            RefreshUi();
        }

        public void Attack(Attack attack)
        {
            this.attack = attack;
            RefreshUi();
        }

        public void RefreshUi()
        {
            lblCurrentPlayerName.Text = game.CurrentPlayer.Nickname;
            lblCurrentSelectedTerritory.Text = selectedTerritory.Name;
            if (this.attack != null)
            {
                grpBattle.Visible = true;
                btnEndTurn.Enabled = false;             

                lblDefendingTerritoryName.Text = attack.DefendingTerritory.Name;
                lblAttackingTerritoryName.Text = attack.AttackingTerritory.Name;
                lblDefenderTroopsAmount.Text = attack.DefendingTerritory.NrOfSoldiers.ToString();
                lblAttackerTroopsAmount.Text = attack.AttackingTerritory.NrOfSoldiers.ToString();
            }
            else
            {
                grpBattle.Visible = false;
                btnEndTurn.Enabled = true;
            }
        }

        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            game.NextTurn();
            RefreshUi();
        }

        private void btnResolveOne_Click(object sender, EventArgs e)
        {
            diceSound.Play();
            attack.ResolveOneTurn();
            RefreshUi();
        }
    }
}
