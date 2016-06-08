using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskItForTheBiscuitGame.Risk
{
    public class TurnResult
    {
        public List<uint> DefenderThrows { get; set; } = new List<uint>();
        public List<uint> AttackerThrows { get; set; } = new List<uint>();

        public override string ToString()
        {
            return string.Format("Defender throws: {0}\nAttacker throws: {1}", 
                string.Join(", ", DefenderThrows), string.Join(", ", AttackerThrows));
        }
    }
}
