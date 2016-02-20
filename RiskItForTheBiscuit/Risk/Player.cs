using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskItForTheBiscuit.Risk
{
    public class Player
    {
        public Player(string nickName)
        {
            this.Nickname = nickName;
        }

        public string Nickname { get; set; }

        public Color PlayerColor { get; set; }

        public List<Territory> OwnedRegions { get; set; }

        public override string ToString()
        {
            return Nickname;
        }
    }
}
