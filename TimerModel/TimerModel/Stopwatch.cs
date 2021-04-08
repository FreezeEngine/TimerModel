using System;
using System.Collections.Generic;
using System.Text;

namespace TimerModel
{
    class Stopwatch
    {
        public static DateTime StartTime { get; private set; }
        public static bool Started = false;
        public static void Start()
        {
            StartTime = DateTime.Now;
        }
        public static TimeSpan GetTime()
        {
            return DateTime.Now - StartTime;
        }
       
    }
}
