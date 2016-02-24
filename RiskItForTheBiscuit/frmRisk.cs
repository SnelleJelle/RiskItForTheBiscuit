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
using RiskItForTheBiscuit.Risk.Placement;

namespace RiskItForTheBiscuit
{
    public partial class frmRisk : Form
    {
        public Game game { get; set; }
        private Placer placer;

        public frmRisk(string gameName, List<Player> players)
        {
            InitializeComponent();
            game = new Game(pbMap, players);
            GameOverview overview = new GameOverview(game);
            overview.Location = new Point(1264, 839);
            this.Controls.Add(overview);

            placer = new Placer(game);
            pictureBox1.Visible = false;
        }

        private void frmRisk_Load(object sender, EventArgs e)
        {

        }

        private void pbMap_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);

            e.Graphics.DrawString(placer.currentTerritoryName, GraphicsExtension.labelFont, Brushes.LimeGreen, 0, 0);
        }

        //placement
        private void frmRisk_KeyDown(object sender, KeyEventArgs e)
        {
            placer.Placer_KeyDown(sender, e);
        }

        private void pbMap_MouseClick(object sender, MouseEventArgs e)
        {
            game.Click(e);
        }
    }
}
