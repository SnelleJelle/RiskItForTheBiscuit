using RiskItForTheBiscuit.Risk;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskItForTheBiscuit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Player playerYellow = new Player("Jona");
            playerYellow.PlayerColor = Color.Yellow;
            Player playerBlue = new Player("Vince");
            playerBlue.PlayerColor = Color.BlueViolet;
            Player playerGreen = new Player("Jelle");
            playerGreen.PlayerColor = Color.ForestGreen;

            List<Player> players = new List<Player>();
            players.Add(playerYellow);
            players.Add(playerBlue);
            players.Add(playerGreen);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmRisk("Test Game", players));
        }
    }
}
