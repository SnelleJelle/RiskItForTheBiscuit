using RiskItForTheBiscuit.Risk;
using RiskItForTheBiscuitClient.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskItForTheBiscuitClient
{
    public partial class TerritoryLabel : Control
    {
        private Point drawingOffset = new Point(6, 10);

        public Territory Territory { get; set; } = new Territory("samplesamplesamplesample")
        {
            NrOfSoldiers = 1,
            Owner = new Player("")
            {
                PlayerColor = Color.OrangeRed
            }
        };

        public TerritoryLabel()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;

            // settings 
            g.SmoothingMode = SmoothingMode.HighQuality;            

            Rectangle bounds = new Rectangle(Point.Empty, new Size(this.Width - 1, this.Height - 1));
            g.DrawRectangle(Pens.Red, bounds);

            this.Size = g.DrawLabel(Territory, drawingOffset);
        }

        public void CorrectLocation()
        {
            this.Location = Location + (Size)drawingOffset;
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            CorrectLocation();
        }
    }
}
