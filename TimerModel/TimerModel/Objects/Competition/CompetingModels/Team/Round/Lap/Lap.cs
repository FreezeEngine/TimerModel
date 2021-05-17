using System;
using System.Collections.Generic;
using System.Text;

namespace TimerModel
{
    public class Lap : IEquatable<Lap>
    {
        public TimeSpan Time { get; private set; }
        private DateTime PreviousTime { get; set; }
        private bool First { get; set; }
        public string ReportString()
        {
            if (First)
            {
                return PreviousTime.ToString("HH:mm:ss:FFF");
            }
            else
            {
                return GetLapTime();
            }
        }
        public override string ToString()
        {
            if (First)
            {
                return PreviousTime.ToString("HH:mm:ss:FFF") + " - Старт";
            }
            else
            {
                return PreviousTime.ToString("HH:mm:ss:FFF") + " - " + GetLapTime();
            }
        }
        public string GetLapTime()
        {
            return Math.Round(Time.TotalSeconds, 2).ToString("0.00");
        }
        public Lap(DateTime fromTime, DateTime toTime, bool isFirst = false)
        {
            if (!isFirst)
            {
                Time = fromTime - toTime;
            }
            this.First = isFirst;
            this.PreviousTime = fromTime;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Lap objAsPart = obj as Lap;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public bool Equals(Lap other)
        {
            if (other == null) return false;
            return (Time.Equals(other.Time));
        }
    }
}
