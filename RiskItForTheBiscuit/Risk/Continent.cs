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
            return this.Where(t => !player.OwnedRegions.Contains(t)).Count() > 0;
        }

        public void AddTerritories(params Territory[] territories)
        {
            foreach (Territory territory in territories)
            {
                this.Add(territory);
                territory.ParentContinent = this;
                territory.CalclateLabelSize();
            }
        }

        public Territory GetTerritory(string name)
        {
            return this.First(s => s.Name == name);
        }

        public void Draw(Graphics g)
        {
            this.ForEach(t => t.DrawLabel(g));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
