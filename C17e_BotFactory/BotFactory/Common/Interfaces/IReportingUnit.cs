using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;

namespace BotFactory.Interfaces
{
    public interface IReportingUnit : IBuildableUnit
    {
        string CurrentStatus { get; set; }
        event UnitStatusChangedDelegate UnitStatusChanged;
        void OnStatusChanged(StatusChangedEventArgs args);
    }
}
