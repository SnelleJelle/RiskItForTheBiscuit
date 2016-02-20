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
        public List<Territory> Neighbours { get; set; } = new List<Territory>();
        public string Name { get; set; }
        public Player Owner { get; set; }
        public Rectangle ClickRegion { get; private set; }
        public uint NrOfSoldiers { get; set; } = 1;        
        public bool IsSelectedNeighbour { get; set; } = false;

        #region Drawing
        public Point LabelCoordinates { get; set; }
        public Point[] Border { get; set; }
        #endregion

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                Neighbours.ForEach(n => n.IsSelectedNeighbour = value);
            }
        }

        public Territory(string name)
        {
            this.Name = name;
            IsSelected = false;
        }

        public void CalculateClickRegions()
        {
            Size labelSize = TextRenderer.MeasureText(Name, GraphicsExtension.labelFont);
            ClickRegion = new Rectangle(LabelCoordinates.X - 10,
                LabelCoordinates.Y - 20,
                labelSize.Width + 50,
                labelSize.Height + 40);
        }

        public void AddNeighbours(params Territory[] territories)
        {
            foreach(Territory territory in territories)
            {
                if (territory != this && territory.Name != this.Name)
                {
                    Neighbours.Add(territory);
                }                
            }            
        }

        public void DrawLabel(Graphics g)
        {
            g.DrawLabel(LabelCoordinates, Name, NrOfSoldiers, Color.LightBlue, IsSelected);            
        }              

        public void DrawNeighbourBorder(Graphics g)
        {
            g.DrawNeighbourBorder(Name, LabelCoordinates);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
