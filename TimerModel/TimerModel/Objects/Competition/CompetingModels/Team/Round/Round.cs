using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using TimerModel.Objects;

namespace TimerModel
{
    public class Round : IEquatable<Round>
    {
        public DateTime RoundStart { get; set; }
        public DateTime CurrentTime { get; set; }
        public DateTime PreviousTime { get; set; }

        public double PointsD { get; set; }
        public int TimeD { get; set; }

        [JsonIgnore]
        public TimeSpan Time
        {
            get
            {
                var t = CurrentTime - RoundStart;
                if (t.TotalSeconds > 200|t.TotalSeconds<0)
                {
                    //return new TimeSpan();
                    return new TimeSpan(0,0,200);
                }
                return t;
            }
        }

        public delegate void Finishd();
        public event Finishd onFinish;
        public delegate void MisedAPoint();
        public event MisedAPoint OnFlyMissChanged;

        [JsonIgnore]
        public double TotalPoints
        {
            get
            {
                if (PointsD != 0)
                {
                    if (PointsD < 0)
                    {
                        PointsD = 200;
                        return PointsD;
                    }
                    return PointsD;
                }
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
        }
        public bool BadFinish = false;

        [JsonIgnore]
        public double Points
        {
            get
            {
                if (TimeD != 0)
                {
                    if (TimeD < 0)
                    {
                        TimeD = 200;
                        return TimeD;
                    }
                    return TimeD;
                }
                if (Finished && !BadFinish)
                {
                    var time = Convert.ToDouble(Time.TotalSeconds);
                    if (time < 0)
                    {
                        return 200;
                    }
                    else
                    {
                        double D = Math.Round(time, 2);
                        if (D >= 200)
                        {
                            return 200;
                        }
                        return D;
                    }
                }
                else
                {
                    return 200;
                }
            }
        }

        public bool Finished { get; set; }

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
            set
            {
                _Laps = value;
            }
        }
        //public string Label { get; set; }
        //public string TimeLabel { get; set; }
        //public string TimeFLabel { get; set; }
        //public string PointsLabel { get; set; }
        public string RoundTime()
        {
            //if (Label == null)
            //{
            //    Label = Points.ToString("0.00");
            //}
            return Points.ToString("0.00");
        }
        public void RandomRound()
        {
            TimeD = new Random().Next(10, 200);
            PointsD = TimeD;
        }
        public string RoundTTime()
        {
            //if (TimeLabel == null)
            //{
            //    TimeLabel = Time.ToString(@"m\:ss\:ff");
            //}
            return Time.ToString(@"m\:ss\:ff");
        }
        public string RoundFTime()
        {
            //if (TimeFLabel == null)
            //{
            //    TimeFLabel = Time.ToString(@"mm\,ss\,ff");
            //}
            if (TimeD != 0)
            {
                return new TimeSpan(0,0,TimeD).ToString(@"mm\,ss\,ff");
            }
            return Time.ToString(@"mm\,ss\,ff");
        }
        public string RoundPoints()
        {
            //if (PointsLabel == null)
            //{
            // var D = Math.Round(TotalPoints, 2);
            // PointsLabel = Math.Round(TotalPoints, 2).ToString("0.00").Replace(",", ".");
            //// if (Label == null)
            //     RoundTime();

            // if (TimeFLabel == null)
            //     RoundFTime();

            return Math.Round(TotalPoints, 2).ToString("0.00").Replace(",", ".");
        }

        public byte[] _FlyMisses = new byte[3];
        public byte[] FlyMisses { get { return _FlyMisses; } set { _FlyMisses = value; if (OnFlyMissChanged != null) { OnFlyMissChanged(); } } }
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
            {
                Lap = Laps.Count - 1;
            }

            Label L;
            L = new Label
            {
                Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right),
                Font = new Font("Segoe UI", TimerSettings.LabelsSize, FontStyle.Regular, GraphicsUnit.Point),
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
            if (!TimerSettings.DoubleClickProtectionEnabled)
                return true;//DELETE
            if (Laps.Count == 0)
            {
                return true;
            }
            TimeSpan Time = TimeSpan.Parse("00:00:01.00");
            if (DateTime.Now - PreviousTime < Time)
            {
                return false;
            }

            return true;
        }
        public void Finish(bool GoodFinish = true)
        {
            //Time = CurrentTime - RoundStart;
            Finished = true;
            if (GoodFinish)
            {
                if (onFinish != null)
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
            if (obj == null)
            {
                return false;
            }

            Round objAsPart = obj as Round;
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
        public bool Equals(Round other)
        {
            if (other == null)
            {
                return false;
            }

            return (Laps.Equals(other.Laps) && RoundTime().Equals(other.RoundTime()));
        }
    }
}
