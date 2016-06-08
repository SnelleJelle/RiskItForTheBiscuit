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
        public string GameName { get; set; }
        public GamePhase CurrentPhase = GamePhase.PlaceTroops;
        public List<Continent> Continents { get; set; } = new List<Continent>();
        public List<Player> Players { get; set; } = new List<Player>();
        public Player CurrentPlayer { get; set; }
        private int currentPlayerIndex = 0; 
        public Size GameSize { get; set; }
        public Font LabelFont { get; set; }

        public static Territory Sea { get; } = Territory.Sea;
        public enum GamePhase
        {
            PlaceTroops,
            Attack,
            MoveTroops
        }

        public Game(string gameName)
        {
            this.GameName = gameName;
        }

        //for testing
        public void RandomizeOwnership()
        {
            var players = Players.Shuffle();
            int index = 0;
            Random random = new Random();
            foreach (Territory territory in GetAllTerritories().Shuffle())
            {
                territory.Owner = players[index];
                territory.NrOfSoldiers = (uint)(random.Next(1, 6));
                index = (index + 1) % players.Count;
            }
        }

        public List<Territory> GetAllTerritories()
        {
            List<Territory> allTerritories = new List<Territory>();
            Continents.ForEach(c => c.ForEach(t => allTerritories.Add(t)));
            return allTerritories;
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
            return Game.Sea;
        }

        public Territory TerritoryOnCoordinates(Point coordinates)
        {
            foreach (Continent continent in this.Continents)
            {
                foreach (Territory territory in continent)
                {
                    if (territory.ContainsCoordinates(coordinates))
                    {
                        return territory;
                    }
                }
            }
            return Game.Sea;
        }

        public void Start()
        {
            CurrentPlayer = Players[currentPlayerIndex];
            CurrentPhase = GamePhase.PlaceTroops;
        }

        public void NextTurn()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % Players.Count;
            CurrentPlayer = Players[currentPlayerIndex];
        }
    }
}