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

namespace RiskItForTheBiscuit.Risk
{
    public partial class GameOverview : UserControl
    {
        private Game game;
        public Attack Attack { get; set; }

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

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.FromArgb(25, 35, 50),
                                                                       Color.FromArgb(35, 45, 60),
                                                                       0f))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.WhiteSmoke) { Width = 1};
            g.DrawLine(pen, 0, 30, this.ClientSize.Width, 30);

        }
    }
}
