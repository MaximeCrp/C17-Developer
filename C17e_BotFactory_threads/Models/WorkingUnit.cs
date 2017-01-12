using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Interfaces;
using BotFactory.Common.Tools;

namespace BotFactory.Models
{
    public abstract class WorkingUnit : BaseUnit, IWorkingUnit, ITestingUnit
    {
        public WorkingUnit(double bt, string name, double speed)
            :base(bt, name, speed)
        {

        }
        public Coordinates ParkingPos { get; set; }
        public Coordinates WorkingPos { get; set; }
        public bool IsWorking { get; set; }
        public virtual async Task<bool> WorkBegins() {
            await Move(WorkingPos);
            StatusChangedEventArgs argsStatus = new StatusChangedEventArgs();
            argsStatus.NewStatus = "Working";
            OnStatusChanged(argsStatus);
            return true;
        }
        public virtual async Task<bool> WorkEnds()
        {
            await Move(ParkingPos);
            StatusChangedEventArgs argsStatus = new StatusChangedEventArgs();
            argsStatus.NewStatus = "Parking";
            OnStatusChanged(argsStatus);
            return true;
        }
    }
}
