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
using System.Security.Cryptography;
using System.Diagnostics;

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

        public TurnResult ResolveOneTurn()
        {
            TurnResult result = new TurnResult();
            uint defenderDice = Math.Min(DefendingTerritory.NrOfSoldiers, 3);
            uint attackerDice = Math.Min(AttackingTerritory.NrOfSoldiers, 2);

            for (int i = 0; i < defenderDice; i++)
            {
                result.DefenderThrows.Add(getDiceThrow());
            }
            result.DefenderThrows.Sort();
            result.DefenderThrows.Reverse();

            for (int i = 0; i < attackerDice; i++)
            {
                result.AttackerThrows.Add(getDiceThrow());
            }
            result.AttackerThrows.Sort();
            result.AttackerThrows.Reverse();



            Debug.WriteLine(result);
            return result;
        }

        public void ResolveUntilFinished()
        {

        }

        private uint getDiceThrow(uint min = 1, uint max = 6)
        {
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] data = new byte[8];
            ulong value;
            do
            {
                rng.GetBytes(data);
                value = BitConverter.ToUInt64(data, 0);
            } while (value == 0);
            return (uint)(value % max + min);
        }
    }
}