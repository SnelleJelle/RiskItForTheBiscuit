using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskItForTheBiscuit.Risk.Extension
{
    public static class GraphicsExtension
    {
        public static Image shield = Properties.Resources.Shield35x35;
        private static Font shieldFont = new Font("Arial", 11);
        public static Font labelFont = new Font("Tahoma", 8);

        public static void DrawFullImg(this Graphics g, Image i, int x = 0, int y = 0)
        {
            g.DrawImageUnscaledAndClipped(i, new Rectangle(x, y, i.Width, i.Height));
        }

        public static void DrawShield(this Graphics g, Point p, Color color, uint n)
        {
            DrawShield(g, p.X, p.Y, color, n);
        }

        public static void DrawShield(this Graphics g,  int x, int y, Color color, uint n)
        {
            //img            
            Rectangle shieldDimensions = new Rectangle(x, y, shield.Width, shield.Height);
            g.DrawImageUnscaledAndClipped(shield, shieldDimensions);

            //circle
            Rectangle circleDimensions = new Rectangle(shieldDimensions.X + 6, shieldDimensions.Y + 6, shieldDimensions.Width - 14, shieldDimensions.Height - 14);            
            g.FillEllipse(new SolidBrush(color), circleDimensions);
            g.DrawEllipse(new Pen(Color.Black, 1.5f), circleDimensions);

            //count
            Point p = new Point(circleDimensions.X + 5, shieldDimensions.Y + 9);
            g.DrawString(n.ToString(), shieldFont, new SolidBrush(Color.Black), p);
        }

        public static void DrawLabel(this Graphics g, Point p, string name, uint soldiers, Color playerColor, bool selected = false)
        {
            Size textSize = TextRenderer.MeasureText(name, labelFont);
            Rectangle border = new Rectangle(p.X, p.Y, (int)textSize.Width, (int)textSize.Height);
            Color backgroundColor = Color.FromArgb(150, playerColor.R, playerColor.G, playerColor.B);

            //background
            Rectangle backgroundBounds = new Rectangle(border.X - 5, border.Y - 3, border.Width + 20, border.Height + 5);
            g.FillRectangle(new SolidBrush(backgroundColor), backgroundBounds);

            //border
            Color borderColor = selected ? Color.LimeGreen : Color.Gold;
            g.DrawRectangle(new Pen(borderColor, 3f), backgroundBounds);

            //name
            g.DrawString(name, labelFont, Brushes.Black, p);

            //shield
            g.DrawShield(new Point(border.X + border.Width, border.Y - 10), playerColor, soldiers);
        }

        public static void DrawNeighbourBorder(this Graphics g, string name, Point p)
        {
            Size s = TextRenderer.MeasureText(name, labelFont);
            Rectangle border = new Rectangle(p.X - 5, p.Y - 3, (int)s.Width + 20, (int)s.Height + 5);
            Point[] borderPoints = new Point[4];
            borderPoints[0] = new Point(border.X + border.Width - 14, border.Y);
            borderPoints[1] = new Point(border.X, border.Y);
            borderPoints[2] = new Point(border.X, border.Y + border.Height);
            borderPoints[3] = new Point(border.X + border.Width - 10, border.Y + border.Height);
            g.DrawLines(new Pen(Color.Red, 2f), borderPoints);
        }
    }
}
