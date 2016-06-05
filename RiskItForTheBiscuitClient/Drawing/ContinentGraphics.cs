using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskItForTheBiscuitClient.Drawing
{
    class ContinentGraphics
    {
        public void Draw(Graphics g)
        {
            this.ForEach(t => t.DrawLabel(g));
        }
    }
}
