using System;
using System.Collections.Generic;
using System.Text;

namespace TimerModel
{
    class FlyModel
    {
        public double[] LapTimes { get; set; } //lap 1 - flymiss?
        public double TotalTime { get; set; }
        public double TotalPoints { get; set; }
        public byte FlyMisses { get; set; }
        public string Pilots { get; set; }
        public string Name { get; set; }
        //on change handler
    }
}
