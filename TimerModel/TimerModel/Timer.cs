using System;
using System.Collections.Generic;
using System.Text;

namespace TimerModel
{
    class TimerData
    {
        public static DateTime StartTime { get; set; }
        public static double Time { get; set; }

        public static void Clear()
        {
            Time = 0;
        }
        public static void SetStart()
        {
            StartTime = DateTime.Now;
        }
        public static void GetTime()
        {
            StartTime = DateTime.Now;
        }

    }
}
