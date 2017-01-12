using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class Coordinates
    {
        public Coordinates(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public override bool Equals(object objCoordinates)
        {
            if (objCoordinates == null || !(objCoordinates is Coordinates))
            {
                return false;
            }
            return X == (objCoordinates as Coordinates).X && Y == (objCoordinates as Coordinates).Y;
        }

        public override int GetHashCode()
        {
            return (int)(X + Y);
        }
    }

}
