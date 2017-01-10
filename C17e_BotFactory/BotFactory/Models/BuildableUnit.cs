using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Interfaces;

namespace BotFactory.Models {
    public abstract class BuildableUnit : IBuildableUnit
    {
        public BuildableUnit(double bt = 5.0)
        {
            BuildTime = bt;
        }
        public double BuildTime {
            get
            {
                return _builtTime;
            }
            set
            {
                _builtTime = value;
            }
                
        }
        public string Model { get; set; }
        private double _builtTime=5.0;
    }
}
