using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskItForTheBiscuit.Risk;
using System.Diagnostics;
using System.Xml.Linq;

namespace RiskItForTheBiscuit
{
    public partial class frmRisk : Form
    {
        public Game game { get; set; }

        private Point clickpoint;

        private string continent = "Asia";
        private string territory = "Siam";

        public frmRisk()
        {
            InitializeComponent();
            game = new Game(pbMap);

            point = getPoint();
            pictureBox1.Visible = false;
        }

        //for setup
        private Point getPoint()
        {
            return game.GetContinent(continent).GetTerritory(territory).LabelCoordinates;
        }

        private void frmRisk_Load(object sender, EventArgs e)
        {
            Debug.WriteLine(pbMap.Size);
            Debug.WriteLine(pbMap.ClientSize);   
        }

        private void pbMap_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }

        //placement
        Point point;
        private void frmRisk_KeyDown(object sender, KeyEventArgs e)
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
                    break;
            }

            game.GetContinent(continent).GetTerritory(territory).LabelCoordinates = point;
            Refresh();
            string coords = "Point(" + point.X + ", " + point.Y + ");";
            Debug.WriteLine(point + "=>" + coords);
            Clipboard.SetText(coords);
        }

        private void persistPoint()
        {
            string xmlFileDir = @"../../Resources/world_map_risk.xml";
            XDocument xml = XDocument.Load(xmlFileDir);

            var xmlContinent = xml.Element("map").Element("continents").Elements().First(c => c.Attribute("name").Value == continent);
            var xmlTerritory = xmlContinent.Elements().First(t => t.Element("territory.name").Value == territory);
            var xmlPoint = xmlTerritory.Element("territory.labelpoint");
            xmlPoint.Value = "(" + point.X + ", " + point.Y + ")";
            xml.Save(xmlFileDir);
        }

        private void pbMap_MouseClick(object sender, MouseEventArgs e)
        {
            game.Click(e);
            clickpoint = e.Location;
        }
    }
}
