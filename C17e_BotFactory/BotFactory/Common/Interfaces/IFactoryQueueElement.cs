using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;

namespace BotFactory.Interfaces
{
    public interface IFactoryQueueElement
    {
        string Name { get; set; }
        Type Model { get; set; }
        Coordinates ParkingPos { get; set; }
        Coordinates WorkingPos { get; set; }
    }
}
