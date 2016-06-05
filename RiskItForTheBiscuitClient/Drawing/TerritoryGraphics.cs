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
                territory.IsSelected);
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

        public bool IsClicked(Point click)
        {
            if (LabelRegion.Contains(click)){
                return true;
            }
            else if(IsInPolygon(Border.ToArray(), click))
            {
                return true;
            }
            return false;
        }



        private bool IsInPolygon(Point[] poly, Point click)
        {
            bool isInside = false;
            for (int i = 0; i < poly.Length; i++)
            {
                if (LineIntersectsWidthEdge(poly[i], poly[(i + 1) % poly.Length], click))
                {
                    isInside = !isInside;
                }
            }
            return isInside;
        }

        private bool LineIntersectsWidthEdge(Point edge1, Point edge2, Point click)
        {
            Point point2 = new Point(click.X + 1920, click.Y + 1080);
            float dx12 = (float)(edge2.X - edge1.X);
            float dy12 = (float)(edge2.Y - edge1.Y);
            float dx34 = (float)(point2.X - click.X);
            float dy34 = (float)(point2.Y - click.Y);

            float denominator = (dy12 * dx34 - dx12 * dy34);

            float t1 =
                (float)((edge1.X - click.X) * dy34 + (click.Y - edge1.Y) * dx34)
                    / denominator;
            if (float.IsInfinity(t1))
            {
                return false;
            }

            float t2 =
            (float)((click.X - edge1.X) * dy12 + (edge1.Y - click.Y) * dx12)
                / -denominator;

            return ((t1 >= 0) && (t1 <= 1) &&
            (t2 >= 0) && (t2 <= 1));
        }
    }
}
