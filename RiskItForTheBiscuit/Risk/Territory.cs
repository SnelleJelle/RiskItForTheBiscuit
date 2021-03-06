﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskItForTheBiscuit.Risk.Extension;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using RiskItForTheBiscuitGame.Risk;
using System.Diagnostics;

namespace RiskItForTheBiscuit.Risk
{
    public class Territory
    {        
        public string Name { get; set; }
        public Player Owner { get; set; }
        public uint NrOfSoldiers { get; set; } = 1;
        public Continent ParentContinent { get; set; }
        public List<Territory> Neighbours { get; set; } = new List<Territory>();        
        public List<Point> Border { get; set; }
        public Point LabelCoordinates { get; set; }
        public Rectangle LabelRegion { get; set; }
        public Game Game { get; set; }
        public static Territory Sea { get; } = new Territory("Sea");

        public Territory(string name)
        {
            this.Name = name;
        }      

        public List<Territory> GetAttackableNeighbours(bool requireSoldiers = false)
        {
            if (requireSoldiers && NrOfSoldiers == 1)
            {
                return new List<Territory>();
            }
            return new List<Territory>(Neighbours.Where(t => t.Owner != this.Owner));
        }

        public List<Territory> getOwnedNeighbours()
        {
            return new List<Territory>(Neighbours.Where(t => t.Owner == this.Owner));
        }

        public void AddNeighbours(params Territory[] territories)
        {
            foreach (Territory territory in territories)
            {
                if (territory != this && territory.Name != this.Name)
                {
                    Neighbours.Add(territory);
                }
            }
        }

        public bool CanAttack(Territory attackedTerritory)
        {
            return GetAttackableNeighbours(true).Contains(attackedTerritory);
        }        

        public bool ContainsCoordinates(Point click)
        {
            if (LabelRegion == Rectangle.Empty)
            {
                CalculateLabelSize();
            }

            if (LabelRegion.Contains(click))
            {
                return true;
            }
            else if (IsInPolygon(Border, click))
            {
                return true;
            }
            return false;
        }

        private void CalculateLabelSize()
        {
            Size textSize = TextRenderer.MeasureText(Name, Game.LabelFont);
            this.LabelRegion = new Rectangle(
                LabelCoordinates.X - 6,
                LabelCoordinates.Y - 4,
                (int)textSize.Width + 35,
                (int)textSize.Height + 10);
        }

        private bool IsInPolygon(List<Point> poly, Point click)
        {
            bool isInside = false;
            for (int i = 0; i < poly.Count; i++)
            {
                if (LineIntersectsWidthEdge(poly[i], poly[(i + 1) % poly.Count], click))
                {
                    isInside = !isInside;
                }
            }
            return isInside;
        }

        private bool LineIntersectsWidthEdge(Point edge1, Point edge2, Point click)
        {
            Point point2 = new Point(click.X + 1920, click.Y + 1080);
            float dx12 = (float)(edge2.X - edge1.X);
            float dy12 = (float)(edge2.Y - edge1.Y);
            float dx34 = (float)(point2.X - click.X);
            float dy34 = (float)(point2.Y - click.Y);

            float denominator = (dy12 * dx34 - dx12 * dy34);

            float t1 =
                (float)((edge1.X - click.X) * dy34 + (click.Y - edge1.Y) * dx34)
                    / denominator;
            if (float.IsInfinity(t1))
            {
                return false;
            }

            float t2 =
            (float)((click.X - edge1.X) * dy12 + (edge1.Y - click.Y) * dx12)
                / -denominator;

            return ((t1 >= 0) && (t1 <= 1) &&
            (t2 >= 0) && (t2 <= 1));
        }

        public Attack Attack()
        {
            return new Attack(this);
        }

        public void TakeOwnership(Territory loser)
        {
            loser.Owner = this.Owner;
            loser.NrOfSoldiers = this.NrOfSoldiers - 1;
            this.NrOfSoldiers = 1;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return this.Name == ((Territory)obj).Name;
        }
    }
}
