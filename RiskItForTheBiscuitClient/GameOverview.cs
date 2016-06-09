using RiskItForTheBiscuitClient.Properties;
using RiskItForTheBiscuitGame.Risk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskItForTheBiscuit.Risk
{
    public partial class GameOverview : UserControl
    {
        public Game Game { get; set; }
        private Attack attack { get; set; }
        private Territory selectedTerritory { get; set; } = Game.Sea;
        private SoundPlayer diceSound = new SoundPlayer(Resources.Dice);
        private Point defenderDiceLocation = new Point(25, 216);
        private Point attackerDiceLocation = new Point(25, 270);

        public GameOverview()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Graphics g = e.Graphics;

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.FromArgb(25, 35, 50),
                                                                       Color.FromArgb(45, 55, 70),
                                                                       25f))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }
            g.DrawLine(Pens.White, new Point(0, 0), new Point(0, this.ClientSize.Height));

            Pen pen = new Pen(Color.WhiteSmoke) { Width = 1 };
            int height = 75;
            g.DrawLine(pen, 0, height, this.ClientSize.Width, height);
        }

        public void Select(Territory selectedTerritory)
        {
            if (selectedTerritory != this.selectedTerritory)
            {
                this.selectedTerritory = selectedTerritory;
                this.attack = null;                
                RefreshUi();
            }            
        }

        public void DisplayAttack(Attack attack)
        {
            this.attack = attack;
            RefreshUi();
        }

        public void RefreshUi()
        {
            lblCurrentPlayerName.Text = Game.CurrentPlayer.Nickname;            
            IndicatePhase();
            lblCurrentSelectedTerritory.Text = selectedTerritory.Name;
            if (this.attack != null)
            {
                grpBattle.Visible = true;
                lblWinnerName.Text = "Undecided";
                btnResolveOne.Enabled = true;
                btnNextPhase.Enabled = false;             

                lblDefendingTerritoryName.Text = attack.DefendingTerritory.Name;
                lblAttackingTerritoryName.Text = attack.AttackingTerritory.Name;
                lblDefenderTroopsAmount.Text = attack.DefendingTerritory.NrOfSoldiers.ToString();
                lblAttackerTroopsAmount.Text = attack.AttackingTerritory.NrOfSoldiers.ToString();
            }
            else
            {
                grpBattle.Visible = false;
                btnNextPhase.Enabled = true;
                clearDice();
            }
        }

        private void IndicatePhase()
        {
            var phaselabels = Controls.OfType<Label>().Where(l => (string)l.Tag == "Phase");

            foreach (Label phaseLabel in phaselabels)
            {
                phaseLabel.Font = new Font(phaseLabel.Font, FontStyle.Bold);
            }
            Label lblCurrentPhase = this.Controls["lbl" + Game.CurrentPhase.ToString()] as Label;
            lblCurrentPhase.Font = new Font(lblCurrentPhase.Font, lblCurrentPhase.Font.Style | FontStyle.Underline);
        }

        private void clearDice()
        {
            foreach (PictureBox pic in grpBattle.Controls.OfType<PictureBox>())
            {
                pic.Image = null;
            }
        }

        private void btnNextPhase_Click(object sender, EventArgs e)
        {            
            this.attack = null;
            Game.NextPhase();
            RefreshUi();
        }

        private void btnResolveOne_Click(object sender, EventArgs e)
        {
            clearDice();
            diceSound.Play();            
            TurnResult result = attack.ResolveOneTurn();
            RefreshUi();
            DisplayDiceAsImage(result);

            if (result.AttackerWon)
            {
                btnResolveOne.Enabled = false;
                attack.AttackingTerritory.TakeOwnership(attack.DefendingTerritory);
                lblWinnerName.Text = attack.AttackingTerritory.Name;
                btnNextPhase.Enabled = true;
            }
            else if (result.DefenderWon)
            {
                btnResolveOne.Enabled = false;
                lblWinnerName.Text = attack.DefendingTerritory.Name;
                btnNextPhase.Enabled = true;
            }

            this.Parent.Refresh();
        }

        private void DisplayDiceAsImage(TurnResult result)
        {
            int diceIndex = 1;
            foreach(uint eyes in result.DefenderThrows)
            {
                PictureBox dice = grpBattle.Controls["picDefenderDice" + diceIndex] as PictureBox;
                dice.Image = getDiceImage(eyes);     
                diceIndex++;
            }

            diceIndex = 1;
            foreach (uint eyes in result.AttackerThrows)
            {
                PictureBox dice = grpBattle.Controls["picAttackerDice" + diceIndex] as PictureBox;
                dice.Image = getDiceImage(eyes);
                diceIndex++;
            }
        }

        private Image getDiceImage(uint nrOfEyes)
        {
            return Image.FromFile(string.Format(@"../../Resources/Dice{0}.png", nrOfEyes));
        }
    }
}
