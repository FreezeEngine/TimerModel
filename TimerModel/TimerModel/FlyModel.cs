using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TimerModel
{
    class FlyModel
    {
        public int CurrentPointer = 0;

        public DateTime LocalStart;

        private DateTime PrewTime;

        public Team Team;

        public bool Finished = false;
        public bool Enabled;

        public string[] LapTimes = new string[11];

        private Label[] TimeSpanLabels = new Label[11];
        public double TotalPoints { get; set; }
        public double Points { get; set; }
        public byte FlyMisses { get; set; }

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
            PrewTime = DateTime.Now;
            return TimeStr;
        }

        public TimeSpan GetOverAllTime(DateTime Time)
        {
            return Time - LocalStart;
        }
        public Label GetStopWatchLabel(DateTime Time, int Model)
        {
            if(CurrentPointer == 0)
            {
                LocalStart = Time;
            }
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
