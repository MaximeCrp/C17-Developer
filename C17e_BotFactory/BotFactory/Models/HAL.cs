using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class HAL : WorkingUnit
    {
        public HAL(string name)
            : base(7.0, name, 0.5)
        {
            WorkingPos = new Common.Tools.Coordinates(5, 5);
            ParkingPos = new Common.Tools.Coordinates(2, 2);
            Model = "HAL";
        }
    }
}