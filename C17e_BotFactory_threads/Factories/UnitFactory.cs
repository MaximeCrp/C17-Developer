using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Interfaces;
using BotFactory.Common.Tools;
using BotFactory.Models;
using System.Threading;

namespace BotFactory.Factories
{
    public class UnitFactory : IUnitFactory
    {

        public Queue<IFactoryQueueElement> Queue { get; set; }
        private int _queueCapacity;
        private int _storageCapacity;
        public TimeSpan QueueTime { get; set; }
        Thread SupplyChainThread;
        object SupplyChainMutex = new object();
        public int QueueCapacity {
            get
            {
                return _queueCapacity;
            }
        }
        public int StorageCapacity {
            get
            {
                return _storageCapacity;
            }
        }
        public int QueueFreeSlots {
            get {
                return QueueCapacity - Queue.Count;
            }
        }
        public int StorageFreeSlots {
            get {
                return StorageCapacity - Storage.Count;
            }
        }
        
        public List<ITestingUnit> Storage { get; set; }
        public UnitFactory(int qcapa, int storcapa)
        {
            _queueCapacity = qcapa;
            _storageCapacity = storcapa;
            Queue = new Queue<IFactoryQueueElement>();
            Storage = new List<ITestingUnit>();
        }
        public bool AddWorkableUnitToQueue(Type model, string name, Coordinates workingPos, Coordinates parkingPos) {
            if (IsAddingPossible()) {
                IFactoryQueueElement unity_in = new FactoryQueueElement(model, name, workingPos, parkingPos);
                WorkingUnit EnqueuedUnit = Activator.CreateInstance((unity_in.Model), new object[] { unity_in.Name }) as WorkingUnit;
                TimeSpan TimeToCreate = TimeSpan.FromSeconds(EnqueuedUnit.BuildTime);
                Queue.Enqueue(unity_in);
                QueueTime += TimeToCreate;
                FactoryProgressEventArgs args_unity_in = new FactoryProgressEventArgs();
                args_unity_in.returnUnit = unity_in;
                FactoryProgress(this, args_unity_in);
                startFactory();
                if (Monitor.TryEnter(SupplyChainMutex))
                {
                    Monitor.Pulse(SupplyChainMutex);
                    Monitor.Exit(SupplyChainMutex);
                }
                return true;
            }
            return false;
        }
        public void AddStorage(ITestingUnit BuiltUnity)
        {
            Storage.Add(BuiltUnity);
        }
        private bool IsAddingPossible() {
            if (Queue.Count < QueueCapacity && Storage.Count + Queue.Count<StorageCapacity) {
                return true;
            }
            return false;
        }
        private bool IsFactoryBuildingFlag = false;
        public void BuildWorkableUnit()
        {
            IFactoryQueueElement unity_out = Queue.Peek();
            WorkingUnit BuildingUnit = Activator.CreateInstance((unity_out.Model), new object[] { unity_out.Name }) as WorkingUnit;
            TimeSpan TimeToCreate = TimeSpan.FromSeconds(BuildingUnit.BuildTime);
            Thread.Sleep(TimeToCreate);
            Queue.Dequeue();
            QueueTime -= TimeToCreate;
            AddStorage(BuildingUnit);
            FactoryProgressEventArgs args_unity_out = new FactoryProgressEventArgs();
            args_unity_out.returnUnit = unity_out;
            FactoryProgress(this, args_unity_out);
        }
        public event FactoryProgressDelegate FactoryProgress;
        private void startFactory()
        {
            if (IsFactoryBuildingFlag || (StorageFreeSlots <= 0) || (QueueFreeSlots <= 0) || (Queue.Count == 0))
            {
                Monitor.Wait(SupplyChainMutex);
                return;
            }
            else
            {
                startBuilding();
            }

        }
        private void startBuilding()
        {
            IsFactoryBuildingFlag = true;
            SupplyChainThread = new Thread(new ThreadStart(BuildWorkableUnit));
            SupplyChainThread.Start();
            IsFactoryBuildingFlag = false;
        }

    }
}
