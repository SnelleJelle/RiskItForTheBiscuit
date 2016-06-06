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
        public TerritoryGraphics()
        {
           
        }

        public void DrawTerritory(Graphics g, Territory territory)
        {
            DrawLabel(g, territory);
        }

        public void DrawLabel(Graphics g, Territory territory)
        {
            g.DrawLabel(
                territory.LabelCoordinates,
                territory.Name,
                territory.NrOfSoldiers,
                territory.Owner.PlayerColor,
                true);
        }

        public void DrawAttackable(Graphics g, Territory territory)
        {
            g.DrawAttackable(territory.Name, territory.LabelCoordinates);
        }

        //public void CalclateLabelSize()
        //{
        //    Size labelSize = TextRenderer.MeasureText(territory.Name, GraphicsExtension.labelFont);
        //    LabelRegion = new Rectangle(LabelCoordinates.X - 10,
        //        LabelCoordinates.Y - 20,
        //        labelSize.Width + 50,
        //        labelSize.Height + 40);
        //}
    }
}
