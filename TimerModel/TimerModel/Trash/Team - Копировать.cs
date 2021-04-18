using System;
using System.Drawing;
using System.Windows.Forms;
namespace TimerModel
{
    public class Team1 : IEquatable<Team1>
    {
        
        private byte _CurrentPointer;
        public byte CurrentPointer
        {
            get { return _CurrentPointer; }
            set { if (_CurrentPointer >= 0 && _CurrentPointer < Rules.MaxLaps + 1) { _CurrentPointer = value; } }
        }
        private byte _RoundCounter;
        public byte RoundCounter
        {
            get { if (_RoundCounter >= Rules.MinRounds && _RoundCounter < Rules.MaxRounds) { _RoundCounter = Rules.MinRounds; return _RoundCounter; } else { return _RoundCounter; }  }
            set { if (_RoundCounter >= Rules.MinRounds && _RoundCounter < Rules.MaxRounds) { _RoundCounter = value; } }
        }
        public string Pilot { get; set; }
        public string Mechanic { get; set; }
        public string ModelName { get; set; }

        public Team1()
        {
            RoundCounter = TimerSettings.RoundCount;
            Enabled = true;
        }
        //public bool Used { get; set; }
        //public bool Chosen { get; set; }
        //public void Choose()
        //{
        //    Chosen = true;
        //}
        public override string ToString()
        {
            /*string UsedTXT = "";
            string ChosenTXT = "";
            if (Used == true)
            {
                UsedTXT = " - ИСП";
            }
            if (Chosen == true)
            {
                ChosenTXT = " - ВЫБР";
            }*/
            return "П: " + Pilot + " М: " + Mechanic + " FM: "+ModelName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Team1 objAsPart = obj as Team1;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public bool Equals(Team1 other)
        {
            if (other == null) return false;
            return (this.Pilot.Equals(other.Pilot));
        }

        private DateTime LocalStart { get; set; }
        private DateTime PrewTime { get; set; }
        public bool Finished { get; set; }
        public bool Enabled { get; set; }//ERR
        public string[] LapTimes { get; set; }
        private Label[] TimeSpanLabels { get; set; }
        public double TotalPoints { get; set; }
        public double Points { get; set; }
        public byte FlyMisses { get; set; }

        public void Reset()
        {
            _CurrentPointer = 0;
            Finished = false;
            TotalPoints = 0;
            LapTimes = new string[11];
            TimeSpanLabels = new Label[11];
            //Enabled 
        }
        public bool CooldownIsUP(DateTime Now)
        {
            if (CurrentPointer == 0)
            {
                return true;
            }
            TimeSpan Time = TimeSpan.Parse("00:00:01.00");
            if (Now - PrewTime < Time)
                return false;
            return true;
        }
        public string GetSubTime(DateTime Now)
        {
            TimeSpan Time = Now - PrewTime;
            string TimeStr;
            if (CurrentPointer == 0)
            {
                PrewTime = Now;
                TimeStr = PrewTime.ToString("HH:mm:ss:FFF") + " - Старт";
            }
            else
            {
                TimeStr = PrewTime.ToString("HH:mm:ss:FFF") + " - " + Time.ToString().Remove(12);
            }
            PrewTime = Now;
            return TimeStr;
        }
        public TimeSpan GetOverAllTime(DateTime Time)
        {
            return Time - LocalStart;
        }
        public Label GetStopWatchLabel(DateTime Time, int Model)
        {
            if (TimeSpanLabels == null && LapTimes == null)
            {
                TimeSpanLabels = new Label[11];
                LapTimes = new string[11];
            }

            if (CurrentPointer == 0)
            {
                LocalStart = Time;
            }
            //Rework 
            LapTimes[CurrentPointer] = GetSubTime(Time);
            TimeSpanLabels[CurrentPointer] = new Label();
            TimeSpanLabels[CurrentPointer].Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);
            TimeSpanLabels[CurrentPointer].Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TimeSpanLabels[CurrentPointer].Location = new Point(5, 2);
            TimeSpanLabels[CurrentPointer].Name = "TimeSpanLabel" + CurrentPointer.ToString();
            TimeSpanLabels[CurrentPointer].Size = new Size(273, 35);
            TimeSpanLabels[CurrentPointer].Text = LapTimes[CurrentPointer];
            TimeSpanLabels[CurrentPointer].TabIndex = 0;
            TimeSpanLabels[CurrentPointer].TextAlign = ContentAlignment.MiddleCenter;
            return TimeSpanLabels[CurrentPointer];
        }

    }
}
