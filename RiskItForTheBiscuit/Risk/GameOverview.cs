using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskItForTheBiscuit.Risk
{
    public partial class GameOverview : UserControl
    {
        private Game game;

        public GameOverview(Game game)
        {
            InitializeComponent();

            this.game = game;
        }

        private void GameOverview_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawArc(Pens.AliceBlue, new Rectangle(5, 5, 50, 50), 5f, 10f);
        }
    }
}
