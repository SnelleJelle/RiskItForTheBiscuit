using RiskItForTheBiscuit.Risk;
using RiskItForTheBiscuitClient.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskItForTheBiscuitClient
{
    public partial class TerritoryLabel : Control
    {
        public Territory Territory { get; set; } = new Territory("sample")
        {
            NrOfSoldiers = 1,
            Owner = new Player("")
            {
                PlayerColor = Color.AliceBlue
            }
        };

        public TerritoryLabel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;

            Rectangle r = new Rectangle(0, 0, 30, 12);
            g.DrawRectangle(SystemPens.ActiveBorder, r);
            g.DrawLabel(Territory);
        }
    }
}
