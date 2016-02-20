using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskItForTheBiscuit.Risk
{
    public class Continent : List<Territory>
    {
        public string Name { get; set; }

        public Continent(string name) : base()
        {
            this.Name = name;
        }
        
        public bool IsCompletelyOwnedBy(Player player)
        {
            foreach(Territory region in this)
            {
                if (!player.OwnedRegions.Contains(region))
                {
                    return false;
                }
            }
            return true;
        }

        public void AddTerritories(params Territory[] territories)
        {
            foreach(Territory territory in territories)
            {
                this.Add(territory);
                territory.CalculateClickRegions();
            }
        }

        public Territory GetTerritory(string name)
        {
            return this.First(s => s.Name == name);
        }

        public void Draw(Graphics g)
        {
            Territory selected = null;
            foreach(Territory territory in this)
            {               
                if (territory.IsSelected)
                {
                    selected = territory;
                }
                territory.DrawLabel(g);
            }

            if (selected != null)
            {
                selected.Neighbours.ForEach(t => t.DrawNeighbourBorder(g));
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
