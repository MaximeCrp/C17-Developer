using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;

namespace BotFactory.Interfaces
{
    public interface IWorkingUnit : IBaseUnit, IBuildableUnit, IReportingUnit
    {
        Coordinates ParkingPos { get; set; }
        Coordinates WorkingPos { get; set; }
        bool IsWorking { get; set; }
        Task<bool> WorkBegins();
        Task<bool> WorkEnds();

    }
}
