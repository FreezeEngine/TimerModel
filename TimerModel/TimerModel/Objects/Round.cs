using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TimerModel
{
    public class Round : IEquatable<Round>
    {
        private DateTime RoundStart { get; set; }
        private DateTime CurrentTime { get; set; }
        private DateTime PreviousTime { get; set; }
        public TimeSpan Time { get; private set; }

        public delegate void Finishd();
        public event Finishd onFinish;
        public delegate void MisedAPoint();
        public event MisedAPoint onFlyMissChanged;

        private double _TotalPoints;
        public double TotalPoints { get { return _TotalPoints; } set { if (value >= 200) { _TotalPoints = 200; } else { _TotalPoints = value; } } }

        private double _Points;
        public double Points { get { return _Points; } set { if (value > 200) { _Points = 200; } else { _Points = value; } } }

        private List<Lap> _Laps;
        public List<Lap> Laps
        {
            get
            {
                if (_Laps == null)
                {
                    _Laps = new List<Lap>();
                }
                return _Laps;
            }
            private set
            {
                _Laps = value;
            }
        }
        public byte[] _FlyMisses = new byte[3];
        public byte[] FlyMisses { get { return _FlyMisses; } set { _FlyMisses = value; onFlyMissChanged(); } }
        public byte TotalFlyMisses()
        {
            return (byte)(FlyMisses[0] + FlyMisses[1] + FlyMisses[2]);
        }
        public void MakeLap()
        {
            DateTime Now = DateTime.Now;
            if (Laps.Count == 0)
            {
                RoundStart = Now;
                PreviousTime = Now;
                Laps.Add(new Lap(Now, Now, true));
            }
            else
            {
                CurrentTime = Now;
                Laps.Add(new Lap(Now, PreviousTime, false));
                PreviousTime = Now;
            }
            if (Laps.Count == TimerSettings.LapCount + 1)
            {
                Finish();
                return;
            }
        }
        public Label GetStopWatchLabel()
        {
            Label L;
            L = new Label();
            L.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);
            L.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            L.Location = new Point(5, 2);
            L.Name = "TimeSpanLabel" + Laps.Count.ToString();
            L.Size = new Size(273, 35);
            L.Text = Laps[Laps.Count - 1].ToString();
            L.TabIndex = 0;
            L.TextAlign = ContentAlignment.MiddleCenter;
            return L;
        }
        public bool CooldownIsUP()
        {
            return true;//DELETE
            if (Laps.Count == 0)
            {
                return true;
            }
            TimeSpan Time = TimeSpan.Parse("00:00:01.00");
            if (DateTime.Now - PreviousTime < Time)
                return false;
            return true;
        }
        public void Finish()
        {
            Time = CurrentTime - RoundStart;
            onFinish();
        }
        public override string ToString()
        {
            return "Round Data";
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Round objAsPart = obj as Round;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public bool Equals(Round other)
        {
            if (other == null) return false;
            return (this.Laps.Equals(other.Laps));
        }
    }
}
