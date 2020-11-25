using System;
using System.Collections.Generic;
using System.Text;

namespace TimerModel
{
    class Stopwatch
    {
        public static DateTime StartTime { get; set; }

        public static void Start()
        {
            StartTime = DateTime.Now;
        }
        public static string GetSubTime()
        {
            TimeSpan SubstractedTime = DateTime.Now - StartTime;
            
            return SubstractedTime.ToString();
        }

    }
}
