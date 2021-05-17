using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TimerModel.Objects;

namespace TimerModel
{
    public class Team : IEquatable<Team>
    {
        private string _TeamName;
        public string TeamName { get { if (_TeamName == null) { return "Без названия"; } else { return _TeamName; } } set { _TeamName = value; } }

        private string _Pilot;
        public string Pilot { get { if (_Pilot == null) { return "Без пилота"; } else { return _Pilot; } } set { _Pilot = value; } }

        private string _Mechanic;
        public string Mechanic { get { if (_Mechanic == null) { return "Без механика"; } else { return _Mechanic; } } set { if (value?.Length < 3 | value == "") { _Mechanic = null; return; } _Mechanic = value; } }
        public string ModelName { get; set; }

        public CompetingModels CM;

        public List<Round> _Rounds;
        public List<Round> Rounds
        {
            get
            {
                if (_Rounds == null)
                {
                    _Rounds = new List<Round>();
                }
                return _Rounds;
            }
            private set
            {
                _Rounds = value;
            }
        }
        public byte CurrentRoundNum { get; set; }
        public Round CurrentRound
        {
            get
            {
                return Rounds[CurrentRoundNum];
            }
            private set
            {
                Rounds[CurrentRoundNum] = value;
            }
        }
        public bool Enabled { get; set; }

        public Team()
        {
            Rounds.Add(new Round());
            Enabled = true;
        }

        public string GetShortPilotName()
        {
            return GetShortenName(Pilot);
        }
        public string GetShortMechanicName()
        {
            return GetShortenName(Mechanic);
        }
        private string GetShortenName(string Name)
        {
            if (Name.Contains("Без "))
            {
                return Name;
            }

            string ShortenName = Name;
            var ExplodedName = Name.Split(" ");
            if (ExplodedName.Length > 1)
            {
                ShortenName = ExplodedName[0] + " ";
                for (int i = 1; i < ExplodedName.Length; i++)
                {
                    if (ExplodedName[i] == "")
                    {
                        continue;
                    }
                    ShortenName += ExplodedName[i][0] + ".";
                }
            }
            return ShortenName;
        }
        public void SelectRound(byte Round)
        {
            /*if (!(CM.RoundsForThisClass <= Round))
            {
                CM.SetRoundsCount(Round);
                return;
            }*/
            if (Round <= Rounds.Count)
            {
                CurrentRoundNum = (byte)(Round - 1);
                //Rounds[CurrentRound] = ;
                return;
            }
            /*if (Rounds.Count >= Round)
            {
                //Normal
            }*/
            if (Round > CM.RoundsForThisClass)
            {
                return;
                DialogResult dialogResult = MessageBox.Show("Вы пытаетесь превысить количество туров для соревнования моделей " + CM.CompetingModel + ". Увеличить количество туров для совревнования?", "Предупреждение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    CM.SetRoundsCount(Round);
                }
            }
        }
        public void SetRoundsCount(int RoundC)
        {
            if (RoundC == Rounds.Count)
            {
                return;
            }

            if (RoundC < Rules.MinRounds)
            {
                return;
            }
            if (Rounds.Count > RoundC)
            {
                int c = 1;
                while (!(Rounds.Count == RoundC))
                {
                    Rounds.Remove(Rounds[^c]);
                    c++;
                }
                return;
            }
            if (Rounds.Count < RoundC)
            {
                while (!(Rounds.Count == RoundC))
                {
                    Rounds.Add(new Round());
                }
            }
        }
        public void SetLapsCount(int LapsC)
        {
            foreach (var R in Rounds)
            {
                if (R.Laps.Count <= LapsC)
                {
                    return;
                }

                if (R.Laps.Count > LapsC)
                {
                    int c = 1;
                    while (!(R.Laps.Count == LapsC))
                    {
                        R.Laps.Remove(R.Laps[^c]);
                        c++;
                    }
                    return;
                }
            }
        }
        public void NextRound()
        {
            if (CurrentRoundNum + 1 < Rounds.Count)
            {
                CurrentRoundNum++;
            }
            //else
            //{
            //    CurrentRoundNum = 0;
            //}
        }
        public bool isFinished(int Round)
        {
            if (Round <= Rounds.Count)
            {
                return Rounds[Round - 1].Finished;
            }
            return false;
        }
        public void Reset()
        {
            CurrentRound = new Round();
        }
        public override string ToString()
        {
            return "П: " + GetShortPilotName() + " | М: " + GetShortMechanicName() + " | FM: " + ModelName + " | T: " + TeamName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Team objAsPart))
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
        public bool Equals(Team other)
        {
            if (other == null)
            {
                return false;
            }

            return (Pilot == other.Pilot && ModelName == other.ModelName && Mechanic == other.Mechanic);
        }
    }
}
