using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class Vector
    {
        public Vector(double x=0, double y=0) {
            X = x;
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public static Vector FromCoordinates(Coordinates begin, Coordinates end)
        {
            Vector vect = new Vector();
            vect.X = end.X - begin.X;
            vect.Y = end.Y - begin.Y;
            return vect;
        }

        public double Length() {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }
    }
}

