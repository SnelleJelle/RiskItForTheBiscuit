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
        public List< Continent> Continents { get; set; } = new List<Continent>();
        public List<Player> Players { get; set; } = new List<Player>();
        public Size GameSize;        
        public string GameName { get; set; }

        public Game(string gameName)
        {
            this.GameName = gameName;
        }

        //for testing
        public void randomizeOwnership()
        {
            var players = Players.Shuffle();
            int index = 0;
            foreach (Territory territory in GetAllTerritories().Shuffle())
            {
                territory.Owner = players[index];
                index = (index + 1) % players.Count;
            }
        }        

        public List<Territory> GetAllTerritories()
        {
            List<Territory> allTerritories = new List<Territory>();
            Continents.ForEach(c => c.ForEach(t => allTerritories.Add(t)));
            return allTerritories;
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

        public Territory getTerritory(string name)
        {
            foreach (Continent continent in this.Continents)
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

        public Territory TerritoryOnCoordinates(Point coordinates)
        {
            foreach (Continent continent in this.Continents)
            {
                foreach(Territory territory in continent)
                {
                    if (territory.ContainsCoordinates(coordinates))
                    {
                        return territory;
                    }
                }
            }
            return null;
        }
    }
}