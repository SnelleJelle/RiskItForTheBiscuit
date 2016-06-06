using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RiskItForTheBiscuit.Risk.Placement
{
    //very polluted class
    public class Placer
    {
        public string currentTerritoryName;
        private IEnumerator<Territory> territoryEnumerator;
        private Game game;
        private Point point;

        public Placer(Game game)
        {
            this.game = game;

            territoryEnumerator = game.GetAllTerritories().GetEnumerator();
            territoryEnumerator.MoveNext();
            currentTerritoryName = territoryEnumerator.Current.Name;

            point = getPoint();
        }

        private Point getPoint()
        {
            return new Point(0, 0); // game.GetTerritoryFromContinent(currentTerritoryName, game.Continents).LabelCoordinates;
        }

        private void persistLabelLocationPoint()
        {
            string xmlFileDir = @"../../Resources/world_map_risk.xml";
            XDocument xml = XDocument.Load(xmlFileDir);

            string continentName = territoryEnumerator.Current.ParentContinent.Name;

            var xmlContinent = xml.Element("map").Element("continents").Elements().First(c => c.Attribute("name").Value == continentName);
            var xmlTerritory = xmlContinent.Elements().First(t => t.Element("territory.name").Value == currentTerritoryName);
            var xmlPoint = xmlTerritory.Element("territory.labelpoint");
            xmlPoint.Value = "(" + point.X + ", " + point.Y + ")";
            xml.Save(xmlFileDir);
        }

        public void PersistBorderPointsToXml(List<Point> points, string territoryName)
        {
            string xmlFileDir = @"../../Resources/world_map_risk.xml";
            XDocument xml = XDocument.Load(xmlFileDir);

            string continentName = territoryEnumerator.Current.ParentContinent.Name;


            var xmlContinent = xml.Element("map").Element("continents").Elements().First(c => c.Attribute("name").Value == continentName);
            var xmlTerritory = xmlContinent.Elements().First(t => t.Element("territory.name").Value == currentTerritoryName);
            var xmlPoint = xmlTerritory.Element("territory.labelpoint");

            string pointsAsString = "";
            foreach(Point p in points)
            {
                pointsAsString += string.Format("({0}, {1})", p.X, p.Y);
            }

            if(pointsAsString == "")
            {
                return;
            }

            xmlPoint.AddAfterSelf(new XElement("territory.border") { Value = pointsAsString});

            xml.Save(xmlFileDir);
            Debug.WriteLine(pointsAsString);
        }

        public void Placer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    point = new Point(point.X, point.Y - 2);
                    break;
                case Keys.Down:
                    point = new Point(point.X, point.Y + 2);
                    break;
                case Keys.Left:
                    point = new Point(point.X - 2, point.Y);
                    break;
                case Keys.Right:
                    point = new Point(point.X + 2, point.Y);
                    break;
                case Keys.Enter:
                    persistLabelLocationPoint();
                    territoryEnumerator.MoveNext();
                    currentTerritoryName = territoryEnumerator.Current.Name;
                    point = getPoint();
                    break;                
            }

            //game.GetTerritoryFromContinent(currentTerritoryName, game.Continents).LabelCoordinates = point;
            //game.pbDrawingField.Refresh();
        }

        private void saveMapDataToXml()
        {
            string directory = @"../../resources";
            string imagesDirectory = directory + @"/images";
            string xmlString = "\n<continents>\n";
            foreach (Continent continent in game.Continents)
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
            foreach (Continent continent in game.Continents)
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
    }
}
