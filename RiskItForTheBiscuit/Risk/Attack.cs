using RiskItForTheBiscuit.Risk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskItForTheBiscuitGame.Risk
{
    public class Attack
    {
        public Territory attackingTerritory { get; set; }
        public Territory defendingTerritory { get; set; }

        public Attack(Territory defendingTerritory)
        {
            this.defendingTerritory = defendingTerritory;
        }

        public Attack From(Territory attackingTerritory)
        {
            this.attackingTerritory = attackingTerritory;
            return this;
        }
    }
}
