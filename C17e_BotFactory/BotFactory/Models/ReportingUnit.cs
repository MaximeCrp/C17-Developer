using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Interfaces;
using BotFactory.Common.Tools;

namespace BotFactory.Models
{
    public abstract class ReportingUnit : BuildableUnit, IReportingUnit
    {
        public ReportingUnit(double bt)
            :base(bt)
        {

        }
        public string CurrentStatus { get; set; }
        public event UnitStatusChangedDelegate UnitStatusChanged;
        public virtual void OnStatusChanged(StatusChangedEventArgs args) {
            if (CurrentStatus != args.NewStatus)
            {
                CurrentStatus = args.NewStatus;
            }
            else
            {
                args.NewStatus = "Already " + CurrentStatus;
            }
            UnitStatusChanged(this, args);
        }
    }
}
  