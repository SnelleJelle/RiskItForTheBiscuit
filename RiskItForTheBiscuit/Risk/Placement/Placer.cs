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
            return game.GetTerritoryFromContinent(currentTerritoryName, game.Continents).LabelCoordinates;
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

            game.GetTerritoryFromContinent(currentTerritoryName, game.Continents).LabelCoordinates = point;
            game.pbDrawingField.Refresh();
        }
    }
}
