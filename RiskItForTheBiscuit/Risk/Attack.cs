using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskItForTheBiscuit.Risk.Extension;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using RiskItForTheBiscuitGame.Risk;

namespace RiskItForTheBiscuit.Risk
{
    public class Attack
    {
        public Territory DefendingTerritory { get; set; }
        public Territory AttackingTerritory { get; set; }

        public Attack(Territory defendingTerritory)
        {
            this.DefendingTerritory = defendingTerritory;
        }

        public Attack From(Territory attackingTerritory)
        {
            this.AttackingTerritory = attackingTerritory;
            return this;
        }

        public void ResolveOneTurn()
        {
            

        }

        public void ResolveUntilFinished()
        {

        }

        private uint getDiceThrow()
        {
            return (uint)(new Random().Next(1, 6));
        }
    }
}