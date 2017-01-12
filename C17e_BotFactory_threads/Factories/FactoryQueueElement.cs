using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using BotFactory.Interfaces;

namespace BotFactory.Factories
{
    public class FactoryQueueElement : IFactoryQueueElement
    {
        public FactoryQueueElement(Type model,string name, Coordinates parkingPos, Coordinates workingPos)
        {
            Name = name;
            Model = model;
            ParkingPos = parkingPos;
            WorkingPos = workingPos;
        }
        public string Name { get; set; }
        public Type Model { get; set; }
        public Coordinates ParkingPos { get; set; }
        public Coordinates WorkingPos { get; set; }
    }
}
