using RiskItForTheBiscuit.Risk.Extension;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
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
        private SoundPlayer attackSound = new SoundPlayer(@"../../Resources/Attack.wav");
        private SoundPlayer selectSound = new SoundPlayer(@"../../Resources/Select.wav");


        public List<Continent> Continents { get; set; }
        public PictureBox pbDrawingField { get; set; }
        public Territory SelectedTerritory { get; set; }
        //bg
        private Image backGround = Properties.Resources.risk_world_map1264x839;

        public List<Player> Players { get; set; } = new List<Player>();
        public string MapName { get; set; }

        public Game(PictureBox pb, List<Player> players)
        {
            //Continents = RegionBuilder.Build();
            Continents = loadMapDataFromXml();
            this.pbDrawingField = pb;
            this.Players = players;
            randomizeOwnership();
            //saveMapDataToXml();//
        }

        private void randomizeOwnership()
        {
            var players = Players.Shuffle();
            int index = 0;
            foreach (Territory territory in GetAllTerritories().Shuffle())
            {
                territory.Owner = players[index];
                index = (index + 1) % 3;
            }
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

                foreach (XElement xmlTerritory in xmlContinent.Elements())
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
            foreach (XElement xmlNeighbours in allNeighbours.Elements())
            {
                Territory[] territories = new Territory[2];
                uint index = 0;
                foreach (XElement xmlNeighbour in xmlNeighbours.Elements())
                {
                    string neighbourName = xmlNeighbour.Attribute("name").Value;
                    Territory t = this.GetTerritoryFromContinent(neighbourName, continents);
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
            foreach (Continent continent in Continents)
            {
                string imgDirectory = imagesDirectory + @"/" + continent.Name;
                xmlString += "\t<continent name=\"" + continent.Name + "\">\n";
                foreach (Territory territory in continent)
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

        public List<Territory> GetAllTerritories()
        {
            List<Territory> allTerritories = new List<Territory>();
            Continents.ForEach(c => c.ForEach(t => allTerritories.Add(t)));
            return allTerritories;
        }

        public Continent GetContinent(string name)
        {
            return Continents.First(s => s.Name == name);
        }

        public Continent GetContinentFromTerritory(Territory territory)
        {
            foreach (Continent continent in Continents)
            {
                if (continent.Contains(territory))
                {
                    return continent;
                }
            }
            return null;
        }

        public Territory GetTerritoryFromContinent(string name, List<Continent> continents)
        {
            foreach (Continent continent in continents)
            {
                foreach (Territory territory in continent)
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
            g.DrawFullImg(backGround);

            //continents
            foreach (Continent continent in Continents.Where(c => !c.Contains(SelectedTerritory)))
            {
                continent.Draw(g);
            }

            if (SelectedTerritory != null)
            {
                foreach (Territory territory in Continents.First(c => c.Contains(SelectedTerritory)))
                {
                    territory.DrawLabel(g);
                }
                SelectedTerritory.GetAttackableNeighbours().ForEach(n => n.DrawAttackable(g));
            }
        }

        private Territory getTerritoryFromClick(Point click)
        {
            foreach (Continent continent in this.Continents)
            {
                foreach (Territory territory in continent)
                {
                    if (territory.ClickRegion.Contains(click))
                    {
                        return territory;
                    }
                }
            }
            return null;
        }

        private void select(Territory newlySelectedTerritory)
        {
            if (newlySelectedTerritory != null)
            {
                selectSound.Play();
                if (SelectedTerritory != null)
                {
                    SelectedTerritory.IsSelected = false;
                    newlySelectedTerritory.IsSelected = true;
                    SelectedTerritory = newlySelectedTerritory;
                }
                else // selectedTerritory == null
                {
                    newlySelectedTerritory.IsSelected = true;
                    SelectedTerritory = newlySelectedTerritory;
                }
            }
            else // newlySelectedTerritory == null
            {
                if (SelectedTerritory != null)
                {
                    SelectedTerritory.IsSelected = false;
                }
                SelectedTerritory = null;
            }
            pbDrawingField.Refresh();
        }

        private void attack(Territory newlySelectedTerritory)
        {
            if (newlySelectedTerritory != null && SelectedTerritory.GetAttackableNeighbours().Contains(newlySelectedTerritory))
            {
                attackSound.Play();
            }
            pbDrawingField.Refresh();
        }

        public void Click(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Territory clicked = getTerritoryFromClick(e.Location);
                select(clicked);
            }
            else // e.Button == MouseButtons.Left
            {
                Territory clicked = getTerritoryFromClick(e.Location);
                attack(clicked);
            }
        }
    }
}