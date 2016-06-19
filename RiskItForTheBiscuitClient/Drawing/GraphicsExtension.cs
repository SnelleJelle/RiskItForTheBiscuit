using RiskItForTheBiscuit.Risk;
using RiskItForTheBiscuitClient.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskItForTheBiscuitClient.Drawing
{

    //TODO: calculate certain Classes at compile-Time for performance gain;
    public static class GraphicsExtension
    {
        public static void DrawFullImg(this Graphics g, Image i, int x = 0, int y = 0)
        {
            g.DrawImageUnscaledAndClipped(i, new Rectangle(x, y, i.Width, i.Height));
        }

        private static void DrawShield(this Graphics g, Point p, Color color, uint n)
        {
            DrawShield(g, p.X, p.Y, color, n);
        }

        private static void DrawShield(this Graphics g, int x, int y, Color color, uint n)
        {
            //img            
            Rectangle shieldDimensions = new Rectangle(x, y, DrawingOptions.ShieldImage.Width, DrawingOptions.ShieldImage.Height);
            g.DrawImageUnscaledAndClipped(DrawingOptions.ShieldImage, shieldDimensions);

            //circle
            Rectangle circleDimensions = new Rectangle(shieldDimensions.X + 6, shieldDimensions.Y + 6, shieldDimensions.Width - 14, shieldDimensions.Height - 14);
            g.FillEllipse(new SolidBrush(color), circleDimensions);
            g.DrawEllipse(new Pen(Color.Black, 1.5f), circleDimensions);

            //count
            Point p = new Point(circleDimensions.X + 5, shieldDimensions.Y + 9);
            g.DrawString(n.ToString(), DrawingOptions.ShieldFont, new SolidBrush(Color.Black), p);
        }

        public static Size DrawLabel(this Graphics g, Territory territory, Point offset, bool selected = false)
        {
            Size textSize = TextRenderer.MeasureText(territory.Name, DrawingOptions.LabelFont);
            Point location = territory.LabelCoordinates + (Size)offset;
            Rectangle border = new Rectangle(location.X, location.Y, (int)textSize.Width, (int)textSize.Height);
            Color playerColor = territory.Owner.PlayerColor;
            Color backgroundColor = Color.FromArgb(150, playerColor.R, playerColor.G, playerColor.B);

            //background
            Rectangle backgroundBounds = new Rectangle(border.X - 5, border.Y - 3, border.Width + 20, border.Height + 5);
            g.FillRectangle(new SolidBrush(backgroundColor), backgroundBounds);

            //border
            Color borderColor = selected ? Color.LimeGreen : Color.Black;
            g.DrawRectangle(new Pen(borderColor, 2f), backgroundBounds);

            //name
            g.DrawString(territory.Name, DrawingOptions.LabelFont, Brushes.Black, location);

            //shield
            g.DrawShield(new Point(border.X + border.Width, border.Y - 10), playerColor, territory.NrOfSoldiers);
            return new Size(backgroundBounds.Width + DrawingOptions.ShieldImage.Width / 2 + 3, DrawingOptions.ShieldImage.Height);
        }

        public static Size DrawLabel(this Graphics g, Territory territory, bool selected = false)
        {
            return g.DrawLabel(territory, new Point(0, 0), selected); ;
        }

        public static Territory DrawAttackableLabel(this Graphics g, Territory territory)
        {
            Size s = TextRenderer.MeasureText(territory.Name, DrawingOptions.LabelFont);
            Point p = territory.LabelCoordinates;
            Rectangle border = new Rectangle(p.X - 5, p.Y - 3, (int)s.Width + 20, (int)s.Height + 5);            

            // swords
            g.DrawImage(Properties.Resources.Swords50x50, new Point(p.X + 3, p.Y - 15));

            // normal label
            g.DrawLabel(territory);

            // red border
            Point[] borderPoints = new Point[4];
            borderPoints[0] = new Point(border.X + border.Width - 14, border.Y);
            borderPoints[1] = new Point(border.X, border.Y);
            borderPoints[2] = new Point(border.X, border.Y + border.Height);
            borderPoints[3] = new Point(border.X + border.Width - 10, border.Y + border.Height);

            Pen dashedPen = new Pen(Color.Red, 2f);
            dashedPen.DashStyle = DashStyle.Dash;
            g.DrawLines(dashedPen, borderPoints);

            return territory;
        }
    }
}
