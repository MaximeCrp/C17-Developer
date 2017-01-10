﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Interfaces
{
    public interface IBuildableUnit
    {
        double BuildTime { get; set; }
        string Model { get; set; }
    }
}
