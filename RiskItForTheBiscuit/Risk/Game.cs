using RiskItForTheBiscuit.Risk.Extension;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RiskItForTheBiscuit.Risk
{
    public class Game
    {
        public static Size GameSize = new Size(1431, 839);
        private const string xmlFileDir = @"../../Resources/world_map_risk.xml";

        public List<Continent> Continents { get; set; }
        private PictureBox pbDrawingField;
        private Territory selectedTerritory;
        private Image backGround = Properties.Resources.risk_map1431x839;


        public List<Player> Players { get; set; } = new List<Player>();
        public string MapName { get; set; }

        public Game(PictureBox pb)
        {
            //Continents = RegionBuilder.Build();
            Continents = loadMapDataFromXml();
            this.pbDrawingField = pb;
            //saveMapDataToXml();
        }

        private List<Continent> loadMapDataFromXml()
        {
            List<Continent> continents = new List<Continent>();
            XDocument xml = XDocument.Load(xmlFileDir);

            XElement map = xml.Element("map");
            MapName = map.Attribute("name").Value;
            var xmlContinents = map.Element("continents").Elements();
            foreach (XElement xmlContinent in xmlContinents)
            {
                Continent continent = new Continent(xmlContinent.Attribute("name").Value);
                
                foreach(XElement xmlTerritory in xmlContinent.Elements())
                {
                    string name = xmlTerritory.Element("territory.name").Value;
                    string labelPointValue = xmlTerritory.Element("territory.labelpoint").Value;
                    Territory territory = new Territory(name)
                        { LabelCoordinates = toPoint(labelPointValue) };

                    continent.AddTerritories(territory);
                }
                continents.Add(continent);
            }

            XElement allNeighbours = map.Element("allneighbours");
            foreach(XElement xmlNeighbours in allNeighbours.Elements())
            {               
                Territory[] territories = new Territory[2];
                uint index = 0;
                foreach (XElement xmlNeighbour in xmlNeighbours.Elements())
                {
                    string neighbourName = xmlNeighbour.Attribute("name").Value;
                    Territory t = this.GetTerritoryFrom(neighbourName, continents);
                    territories[index] = t;
                    index++;
                }
                territories[0].AddNeighbours(territories[1]);
                territories[1].AddNeighbours(territories[0]);
            }

            return continents;
        }        

        private Point toPoint(string s)
        {
            s = s.Substring(1, s.Length - 2).Replace(" ", "");
            string[] coords = s.Split(',');
            int x = Int32.Parse(coords[0]);
            int y = Int32.Parse(coords[1]);
            return new Point(x, y);
        }

        //not used
        private void saveMapDataToXml()
        {
            string directory = @"../../resources";
            string imagesDirectory = directory + @"/images";
            string xmlString = "\n<continents>\n";
            foreach(Continent continent in Continents)
            {
                string imgDirectory = imagesDirectory + @"/" + continent.Name;
                xmlString += "\t<continent name=\"" + continent.Name + "\">\n";
                foreach(Territory territory in continent)
                {
                    xmlString += "\t\t<territory>\n" +
                    "\t\t\t<territory.name>" + territory.Name + "</territory.name>\n" +                    
                    "\t\t\t<territory.labelpoint>" + String.Format("({0}, {1})", territory.LabelCoordinates.X, territory.LabelCoordinates.Y) + "</territory.labelpoint>\n" +
                    "\t\t</territory>\n";
                }
                xmlString += "\t</continent>\n";
            }
            xmlString += "</continents>\n";

            List<Tuple<Territory, Territory>> alreadyNeighboured = new List<Tuple<Territory, Territory>>();

            xmlString += "<allneighbours>\n";
            foreach (Continent continent in Continents)
            {               
                foreach (Territory territory in continent)
                {                    
                    foreach (Territory neighbour in territory.Neighbours)
                    {
                        Tuple<Territory, Territory> neighbours = new Tuple<Territory, Territory>(territory, neighbour);
                        Tuple<Territory, Territory> reverse = new Tuple<Territory, Territory>(neighbour, territory);
                        if (!alreadyNeighboured.Contains(neighbours) && !alreadyNeighboured.Contains(reverse))
                        {
                            xmlString += "\t<neighbours>\n";
                            xmlString += "\t\t<neighbour name=\"" + territory.Name + "\"/>\n";
                            xmlString += "\t\t<neighbour name=\"" + neighbour.Name + "\"/>\n";
                            xmlString += "\t</neighbours>\n";
                            alreadyNeighboured.Add(neighbours);
                        }
                    }
                }
            }
            xmlString += "</allneighbours>\n";
            //File.AppendAllText(directory + @"/world_map_risk.xml", xmlString);
        }

        public Continent GetContinent(string name)
        {
            return Continents.First(s => s.Name == name);
        }

        public Territory GetTerritoryFrom(string name, List<Continent> continents)
        {
            foreach(Continent continent in continents)
            {
                foreach(Territory territory in continent)
                {
                    if (territory.Name == name)
                    {
                        return territory;
                    }
                }
            }
            return null;
        }

        public void Draw(Graphics g)
        {
            //settings 
            g.SmoothingMode = SmoothingMode.HighQuality;

            //bg
            g.DrawFullImg(Properties.Resources.risk_map1431x839);

            //continents
            foreach (Continent continent in Continents.Where(c => !c.Contains(selectedTerritory)))
            {
                continent.Draw(g);
            }

            if (selectedTerritory != null)
            {  
                foreach (Territory territory in Continents.First(c => c.Contains(selectedTerritory)))
                {
                    territory.DrawLabel(g);
                }
                selectedTerritory.Neighbours.ForEach(n => n.DrawNeighbourBorder(g));
            }            
        }

        private void select(Territory newlySelectedTerritory)
        {
            if (newlySelectedTerritory != null)
            {
                if (selectedTerritory != null)
                {
                    selectedTerritory.IsSelected = false;
                    newlySelectedTerritory.IsSelected = true;
                    selectedTerritory = newlySelectedTerritory;
                }
                else // selectedTerritory == null
                {
                    newlySelectedTerritory.IsSelected = true;
                    selectedTerritory = newlySelectedTerritory;
                }                
            }
            else // newlySelectedTerritory == null
            {
                if (selectedTerritory != null)
                {
                    selectedTerritory.IsSelected = false;
                }
                selectedTerritory = null;
            }
            pbDrawingField.Refresh();
        }

        public void Click(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point clickLocation = e.Location;
                foreach (Continent continent in this.Continents)
                {
                    foreach (Territory territory in continent)
                    {
                        if (territory.ClickRegion.Contains(clickLocation))
                        {
                            select(territory);
                            return;
                        }                        
                    }
                }
                select(null);
            }
            else // e.Button == MouseButtons.Left
            {

            }
        }
    }
}
