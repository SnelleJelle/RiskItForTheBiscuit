using RiskItForTheBiscuit.Risk;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RiskItForTheBiscuitGame.Risk
{
    public class GameLoader
    {
        public Game LoadFromXmlFile(string xmlPath)
        {                        
            XDocument xml = XDocument.Load(xmlPath);

            XElement map = xml.Element("map");
            string gameName = map.Attribute("name").Value;
            Game game = new Game(gameName);

            string backgroundImagePath = map.Attribute("background").Value;
            //game.backgroundImage = Image.FromFile(backgroundImagePath);

            int width = int.Parse(map.Attribute("width").Value);
            int height = int.Parse(map.Attribute("height").Value);
            game.GameSize = new Size(width, height);

            var xmlContinents = map.Element("continents").Elements();
            foreach (XElement xmlContinent in xmlContinents)
            {
                Continent continent = new Continent(xmlContinent.Attribute("name").Value);

                foreach (XElement xmlTerritory in xmlContinent.Elements())
                {
                    string name = xmlTerritory.Element("territory.name").Value;
                    string labelPointValue = xmlTerritory.Element("territory.labelpoint").Value;

                    string borderPointsValue = xmlTerritory.Element("territory.border").Value;
                    Territory territory = new Territory(name)
                    {
                        LabelCoordinates = toPoint(labelPointValue),
                        Border = toPointList(borderPointsValue)
                    };

                    continent.AddTerritories(territory);
                }
                game.Continents.Add(continent.Name, continent);
            }

            XElement allNeighbours = map.Element("allneighbours");
            foreach (XElement xmlNeighbours in allNeighbours.Elements())
            {
                Territory[] territories = new Territory[2];
                uint index = 0;
                foreach (XElement xmlNeighbour in xmlNeighbours.Elements())
                {
                    string neighbourName = xmlNeighbour.Attribute("name").Value;
                    territories[index] = game.getTerritory(neighbourName);
                    index++;
                }
                territories[0].AddNeighbours(territories[1]);
                territories[1].AddNeighbours(territories[0]);
            }

            return game;
        }

        private Point toPoint(string s)
        {
            s = s.Substring(1, s.Length - 2).Replace(" ", "");
            string[] coords = s.Split(',');
            int x = Int32.Parse(coords[0]);
            int y = Int32.Parse(coords[1]);
            return new Point(x, y);
        }

        private List<Point> toPointList(string s)
        {
            List<Point> points = new List<Point>();
            string[] splits = s.Split(new char[2] { ')', '(' });
            foreach (string split in splits)
            {
                if (split != "")
                {
                    string[] coords = split.Replace(" ", "").Split(',');
                    int x = Int32.Parse(coords[0]);
                    int y = Int32.Parse(coords[1]);
                    points.Add(new Point(x, y));
                }
            }

            return points;
        }

    }
}
