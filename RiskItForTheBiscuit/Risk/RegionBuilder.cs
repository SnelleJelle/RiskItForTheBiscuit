using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RiskItForTheBiscuit.Risk
{
    public static class RegionBuilder
    {
        public static List<Continent> Build()
        {
            //not used
            var continents = new List<Continent>();

            #region South America
            Continent southAmerica = new Continent("South America");

            Territory venezuela = new Territory("Venezuela");
            Territory peru = new Territory("Peru");
            Territory brazil = new Territory("Brazil");
            Territory argentina = new Territory("Argentina"); 

            venezuela.AddNeighbours(peru, brazil);
            peru.AddNeighbours(venezuela, brazil, argentina);
            brazil.AddNeighbours(venezuela, peru, argentina);
            argentina.AddNeighbours(peru, brazil);

            venezuela.LabelCoordinates = new Point(294, 434);
            peru.LabelCoordinates = new Point(288, 572);
            brazil.LabelCoordinates = new Point(384, 536);
            argentina.LabelCoordinates = new Point(296, 674);

            southAmerica.AddTerritories(venezuela, peru, brazil, argentina);
            continents.Add(southAmerica);
            #endregion

            #region North America
            Continent northAmerica = new Continent("North America");

            Territory alaska = new Territory("Alaska");
            Territory alberta = new Territory("Alberta");
            Territory centralAmerica = new Territory("Central America");
            Territory easternUsa = new Territory("Eastern USA");
            Territory greenland = new Territory("Greenland");
            Territory northWest = new Territory("NorthWest USA");
            Territory ontario = new Territory("Ontario");
            Territory quebec = new Territory("Quebec");
            Territory westernUsa = new Territory("Western USA");

            alaska.AddNeighbours(northWest, alberta);
            alberta.AddNeighbours(alaska, northWest, ontario, westernUsa);
            centralAmerica.AddNeighbours(westernUsa, easternUsa);
            easternUsa.AddNeighbours(centralAmerica, westernUsa, ontario, quebec);
            greenland.AddNeighbours(northWest, ontario, quebec);
            northWest.AddNeighbours(alaska, alberta, ontario, greenland);
            ontario.AddNeighbours(greenland, northWest, alberta, westernUsa, easternUsa, quebec);
            quebec.AddNeighbours(greenland, ontario, easternUsa);
            westernUsa.AddNeighbours(alberta, ontario, easternUsa, centralAmerica);    

            alaska.LabelCoordinates = new Point(56, 90);
            alberta.LabelCoordinates = new Point(150, 150);
            centralAmerica.LabelCoordinates = new Point(154, 366);
            easternUsa.LabelCoordinates = new Point(196, 274);
            greenland.LabelCoordinates = new Point(484, 38);
            northWest.LabelCoordinates = new Point(160, 100);
            ontario.LabelCoordinates = new Point(244, 164);
            quebec.LabelCoordinates = new Point(338, 158);
            westernUsa.LabelCoordinates = new Point(112, 228);

            northAmerica.AddTerritories(alaska, alberta, centralAmerica, easternUsa, greenland, northWest, ontario, quebec, westernUsa);
            continents.Add(northAmerica);
            #endregion

            #region Afrika
            Continent afrika = new Continent("Afrika");

            Territory congo = new Territory("Congo");
            Territory eastAfrika = new Territory("East Afrika");
            Territory egypt = new Territory("Egypt");
            Territory madagascar = new Territory("Madagascar");
            Territory northAfrika = new Territory("North Afrika");
            Territory southAfrika = new Territory("South Afrika");

            congo.AddNeighbours(northAfrika, eastAfrika, southAfrika);
            eastAfrika.AddNeighbours(egypt, northAfrika, congo, southAfrika, madagascar);
            egypt.AddNeighbours(northAfrika, eastAfrika);
            madagascar.AddNeighbours(eastAfrika, southAfrika);
            northAfrika.AddNeighbours(egypt, eastAfrika, congo);
            southAfrika.AddNeighbours(congo, eastAfrika, madagascar);

            congo.LabelCoordinates = new Point(720, 484);
            eastAfrika.LabelCoordinates = new Point(790, 436);
            egypt.LabelCoordinates = new Point(724, 316);
            madagascar.LabelCoordinates = new Point(842, 594);
            northAfrika.LabelCoordinates = new Point(618, 382);
            southAfrika.LabelCoordinates = new Point(718, 612);

            afrika.AddTerritories(congo, eastAfrika, egypt, madagascar, northAfrika, southAfrika);
            continents.Add(afrika);
            #endregion

            #region Europe
            Continent europe = new Continent("Europe");

            Territory greatBritain = new Territory("G. Britain");
            Territory iceland = new Territory("Iceland");
            Territory northernEurope = new Territory("N. Europe");
            Territory scandinavia = new Territory("Scandinavia");
            Territory southernEurope = new Territory("S. Europe");
            Territory ukraine = new Territory("Ukraine");
            Territory westernEurope = new Territory("W. Europe");

            iceland.AddNeighbours(greatBritain, scandinavia);
            greatBritain.AddNeighbours(iceland, westernEurope, scandinavia);
            scandinavia.AddNeighbours(greatBritain, northernEurope, ukraine);
            westernEurope.AddNeighbours(greatBritain, northernEurope, southernEurope);
            southernEurope.AddNeighbours(westernEurope, northernEurope, ukraine);
            northernEurope.AddNeighbours(westernEurope, scandinavia, ukraine, southernEurope);
            ukraine.AddNeighbours(southernEurope, northernEurope, scandinavia);

            greatBritain.LabelCoordinates = new Point(578, 152);
            iceland.LabelCoordinates = new Point(586, 92);
            northernEurope.LabelCoordinates = new Point(670, 168);
            scandinavia.LabelCoordinates = new Point(666, 64);
            southernEurope.LabelCoordinates = new Point(692, 222);
            ukraine.LabelCoordinates = new Point(802, 146);
            westernEurope.LabelCoordinates = new Point(558, 236);

            europe.AddTerritories(greatBritain, iceland, northernEurope, scandinavia, southernEurope, ukraine, westernEurope);
            continents.Add(europe);
            #endregion

            #region CrossContinental neighbours
            venezuela.AddNeighbours(centralAmerica);
            centralAmerica.AddNeighbours(venezuela);

            brazil.AddNeighbours(northAfrika);
            northAfrika.AddNeighbours(brazil);

            greenland.AddNeighbours(iceland);
            iceland.AddNeighbours(greenland);

            egypt.AddNeighbours(southernEurope);
            southernEurope.AddNeighbours(egypt);
            #endregion

            return continents;
        }
    }
}
