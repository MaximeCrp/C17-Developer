using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class R2D2 : WorkingUnit
    {
        public R2D2(string name)
            :base(5.5, name, 1.5)
        {
            WorkingPos = new Common.Tools.Coordinates(6, 6);
            ParkingPos = new Common.Tools.Coordinates(3, 3);
            Model = "R2D2";
        }
    }
}
