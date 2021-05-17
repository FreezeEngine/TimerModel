using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TimerModel.Objects;

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
        public event MisedAPoint OnFlyMissChanged;

        public double TotalPoints
        {
            get
            {
                byte Value = TotalFlyMisses();

                if (Value == 1)
                {
                    return Points + (Points * 0.10);
                }
                else
                {
                    if (Value == 0)
                    {
                        return Points;
                    }
                    else
                    {
                        return 200;
                    }
                }
            }
            set { }
        }
        bool BadFinish = false;
        public double Points
        {
            get
            {
                if (Finished&&!BadFinish)
                {
                    double D = Math.Round(Convert.ToDouble(Time.TotalSeconds), 2);
                    /*if (D >= 200)
                    {
                        return 200;
                    }*/
                    return D;
                }
                else
                {
                    return 200;
                }
            }
            set { }
        }

        private List<Lap> _Laps;
        public bool Finished { get; set; }
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

        public string RoundTime()
        {
            return Points.ToString("0.00");
        }
        public string RoundPoints()
        {
            var D = Math.Round(TotalPoints, 2);
            return D.ToString("0.00").Replace(",",".");
        }

        public byte[] _FlyMisses = new byte[3];
        public byte[] FlyMisses { get { return _FlyMisses; } set { _FlyMisses = value; OnFlyMissChanged(); } }
        public byte TotalFlyMisses()
        {
            return (byte)(FlyMisses[0] + FlyMisses[1] + FlyMisses[2]);
        }
        public void MakeLap(CompetingModels CM)
        {
            if (Finished)
            {
                Finished = false;
                BadFinish = false;
                Laps = new List<Lap>(); //if selected old
            }
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
            if (Laps.Count - 1 == CM.LapsCount)
            {
                Finish();
                return;
            }
        }
        public Label GetStopWatchLabel(int Lap = -1)
        {
            if (Lap == -1)
                Lap = Laps.Count - 1;

            Label L;
            L = new Label
            {
                Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right),
                Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point),
                Location = new Point(5, 2),
                Name = "TimeSpanLabel" + Laps.Count.ToString(),
                Size = new Size(273, 35),
                Text = Laps[Lap].ToString(),
                TabIndex = 0,
                TextAlign = ContentAlignment.MiddleCenter
            };
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
        public void Finish(bool GoodFinish = true)
        {
            Time = CurrentTime - RoundStart;
            Finished = true;
            if (GoodFinish)
            {
                onFinish();
            }
            else
            {
                BadFinish = true;
            }
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
