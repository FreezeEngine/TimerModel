using System;
using System.Text.Json.Serialization;

namespace TimerModel
{
    public class Lap : IEquatable<Lap>
    {
        [JsonIgnore]
        private TimeSpan Time
        {
            get
            {
                return PreviousTime - LapTime;
            }
        }
        public DateTime LapTime { get; set; }
        public DateTime PreviousTime { get; set; }
        public bool First { get; set; }
        //public string Label { get; set; }
        //public string LapTimePoints { get; set; }

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
            /*if (!isFirst)
            {
                Time = fromTime - toTime;
            }*/
            this.First = isFirst;
            this.LapTime = toTime;
            this.PreviousTime = fromTime;
        }
        public Lap()
        {

        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Lap objAsPart = obj as Lap;
            if (objAsPart == null)
            {
                return false;
            }
            else
            {
                return Equals(objAsPart);
            }
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public bool Equals(Lap other)
        {
            if (other == null)
            {
                return false;
            }

            return (Time.Equals(other.Time));
        }
    }
}
