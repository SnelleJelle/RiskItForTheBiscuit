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
    }
}
