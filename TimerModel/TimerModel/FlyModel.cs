using System;
using System.Collections.Generic;
using System.Text;

namespace TimerModel
{
    class FlyModel
    {
        public string Name { get; set; }
        public string Pilots { get; set; }
        public TimeSpan[] LapTime { get; set; } //lap 1 - flymiss?
        public TimeSpan TotalTime { get; set; }
        public double TotalPoints { get; set; }
        public byte FlyMisses { get; set; }
        //on change handler
    }
}
