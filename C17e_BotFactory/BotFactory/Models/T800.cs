using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class T800 : WorkingUnit
    {
        public T800(string name)
            : base(10.0, name, 3)
        {
            WorkingPos = new Common.Tools.Coordinates(7, 7);
            ParkingPos = new Common.Tools.Coordinates(4, 4);
            Model = "T800";
        }
    }
}