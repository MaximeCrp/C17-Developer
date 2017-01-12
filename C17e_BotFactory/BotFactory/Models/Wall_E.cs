using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class WALL_E : WorkingUnit
    {                         
        public WALL_E(string name)       
            : base(4.0, name, 2.0)
        {
            WorkingPos = new Common.Tools.Coordinates(8, 8);
            ParkingPos = new Common.Tools.Coordinates(1, 1);
            Model = "WALL-E";
        }
    }
}