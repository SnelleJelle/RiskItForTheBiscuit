using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskItForTheBiscuit.Risk.Extension;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RiskItForTheBiscuit.Risk
{
    public class Territory
    {        
        public string Name { get; set; }
        public Player Owner { get; set; }
        public Continent ParentContinent { get; set; }
        public List<Territory> Neighbours { get; set; } = new List<Territory>();
        public uint NrOfSoldiers { get; set; } = 1;
        public bool IsSelectedNeighbour { get; set; } = false;
        public List<Point> Border { get; set; }
        public Point LabelCoordinates { get; set; }
        public Rectangle LabelRegion { get; set; }

        public Territory(string name)
        {
            this.Name = name;
        }      

        public List<Territory> GetAttackableNeighbours()
        {
            return new List<Territory>(Neighbours.Where(t => t.Owner != this.Owner));
        }

        public List<Territory> getOwnedNeighbours()
        {
            return new List<Territory>(Neighbours.Where(t => t.Owner == this.Owner));
        }

        public void AddNeighbours(params Territory[] territories)
        {
            foreach (Territory territory in territories)
            {
                if (territory != this && territory.Name != this.Name)
                {
                    Neighbours.Add(territory);
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
