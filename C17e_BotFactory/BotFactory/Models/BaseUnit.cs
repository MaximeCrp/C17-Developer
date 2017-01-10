using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Models;
using BotFactory.Common.Tools;
using BotFactory.Interfaces;
using System.Threading;

namespace BotFactory.Models
{
    public abstract class BaseUnit : ReportingUnit, IBaseUnit
    {
        public BaseUnit(double bt, string name = "No Name", double speed = 1) :base(bt) {
            Name = name;
            Speed = speed;
        }
        public string Name { get; set; }
        public double Speed { get; set; }
        private Coordinates _currentPos = new Coordinates(0.0, 0.0);
        public Coordinates CurrentPos {
            get
            {
                return _currentPos;
            }
            set
            {
                _currentPos = value;
            }
        }
        public virtual async Task<bool> Move(Coordinates destination) {
            StatusChangedEventArgs argsStatus = new StatusChangedEventArgs();
            Vector vect = Vector.FromCoordinates(CurrentPos, destination);
            if (!Equals(CurrentPos, destination)) {
                double moveTime = vect.Length() / Speed;
                argsStatus.NewStatus = "Moving";
                OnStatusChanged(argsStatus);
                await Task.Delay(Convert.ToInt32(moveTime) * 1000);
                CurrentPos = destination;
                return true;
            }
            return false;
        }
    }
}
