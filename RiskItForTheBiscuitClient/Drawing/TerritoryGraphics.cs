using RiskItForTheBiscuit.Risk;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskItForTheBiscuitClient.Drawing;
using System.Windows.Forms;

namespace RiskItForTheBiscuitClient.Drawing
{
    class TerritoryGraphics
    {        
        public List<Point> Border { get; set; }
        public Point LabelCoordinates { get; set; }
        public Rectangle LabelRegion { get; set; }

        public Territory territory { get; set; }

        public TerritoryGraphics(Territory territory)
        {
            this.territory = territory;
        }

        public void DrawLabel(Graphics g)
        {
            g.DrawLabel(
                LabelCoordinates,
                territory.Name,
                territory.NrOfSoldiers,
                territory.Owner.PlayerColor,
                true);
        }

        public void DrawAttackable(Graphics g)
        {
            g.DrawAttackable(territory.Name, LabelCoordinates);
        }

        public void CalclateLabelSize()
        {
            Size labelSize = TextRenderer.MeasureText(territory.Name, GraphicsExtension.labelFont);
            LabelRegion = new Rectangle(LabelCoordinates.X - 10,
                LabelCoordinates.Y - 20,
                labelSize.Width + 50,
                labelSize.Height + 40);
        }
    }
}
