using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RiskItForTheBiscuit.Risk.Placement
{
    public class Placer
    {
        public string territory;
        private IEnumerator<Territory> territoryEnumerator;
        private Game game;
        private Point point;

        public Placer(Game game)
        {
            this.game = game;

            territoryEnumerator = game.GetAllTerritories().GetEnumerator();
            territoryEnumerator.MoveNext();
            territory = territoryEnumerator.Current.Name;

            point = getPoint();
        }

        private Point getPoint()
        {
            return game.GetTerritoryFromContinent(territory, game.Continents).LabelCoordinates;
        }

        private void persistPoint()
        {
            string xmlFileDir = @"../../Resources/world_map_risk.xml";
            XDocument xml = XDocument.Load(xmlFileDir);

            string continentName = game.GetContinentFromTerritory(territoryEnumerator.Current).Name;

            var xmlContinent = xml.Element("map").Element("continents").Elements().First(c => c.Attribute("name").Value == continentName);
            var xmlTerritory = xmlContinent.Elements().First(t => t.Element("territory.name").Value == territory);
            var xmlPoint = xmlTerritory.Element("territory.labelpoint");
            xmlPoint.Value = "(" + point.X + ", " + point.Y + ")";
            xml.Save(xmlFileDir);
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
                    persistPoint();
                    territoryEnumerator.MoveNext();
                    territory = territoryEnumerator.Current.Name;
                    point = getPoint();
                    break;
            }

            game.GetTerritoryFromContinent(territory, game.Continents).LabelCoordinates = point;
            game.pbDrawingField.Refresh();
        }
    }
}
