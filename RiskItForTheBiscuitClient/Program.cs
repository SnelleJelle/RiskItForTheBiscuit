using RiskItForTheBiscuit.Risk;
using RiskItForTheBiscuitGame.Risk;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskItForTheBiscuitClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Player playerYellow = new Player("JonaJonaJonaJonaJonaJona");
            playerYellow.PlayerColor = Color.Yellow;
            Player playerBlue = new Player("Vince");
            playerBlue.PlayerColor = Color.BlueViolet;
            Player playerGreen = new Player("Jelle");
            playerGreen.PlayerColor = Color.ForestGreen;

            List<Player> players = new List<Player>();
            players.Add(playerYellow);
            players.Add(playerBlue);
            players.Add(playerGreen);

            string mapPath = @"../../Resources/world_map_risk.xml";
            GameLoader loader = new GameLoader();
            Game game = loader.LoadFromXmlFile(mapPath);
            game.Players = players;
            //for testing
            game.RandomizeOwnership();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmRisk(game));
        }
    }
}
