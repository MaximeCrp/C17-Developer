using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using BotFactory.Factories;
using BotFactory.Models;

namespace BotFactory.Interfaces
{
    public interface IUnitFactory
    {
        TimeSpan QueueTime { get; set; }
        int QueueCapacity { get; }
        int StorageCapacity { get; }
        int QueueFreeSlots { get; }
        int StorageFreeSlots { get; }

        List<ITestingUnit> Storage { get; set; }
        bool AddWorkableUnitToQueue(Type model, string name, Coordinates workingPos, Coordinates parkingPos);
        void AddStorage(ITestingUnit BuiltUnity);
        void BuildWorkableUnit();
        event FactoryProgressDelegate FactoryProgress;
        Queue<IFactoryQueueElement> Queue { get; set; }
    }
}
