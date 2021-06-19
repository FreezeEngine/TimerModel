using CompetitionOrganizer.Objects;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TimerModel.Objects;

namespace TimerModel
{
    public class Team : IEquatable<Team>
    {
        private string _TeamName;
        public string TeamName { get { if (_TeamName == null) { return "Без названия"; } else { return _TeamName; } } set { _TeamName = value; } }
        public Participant Pilot { get; set; }
        public Participant Mechanic { get; set; }
        //public string Mechanic { get { if (_Mechanic == null) { return "Без механика"; } else { return _Mechanic.ToString(); } } set { if (value?.Length < 3 | value == "") { _Mechanic = null; return; } _Mechanic = value; } }
        public string ModelName { get; set; }

        [JsonIgnore]
        public CompetingModels CM
        {
            get
            {
                if (TimerSettings.Competition == null)
                {
                    return null;
                }
                var CM = TimerSettings.Competition.Teams.TeamClumps.Find(delegate (CompetingModels CM) { return CM.CompetingModel == ModelName; });
                if (CM == null)
                {
                    if (Enabled)
                        TimerSettings.Competition.Teams.TeamClumps.Add(new CompetingModels() { CompetingModel = ModelName });
                }
                return TimerSettings.Competition.Teams.TeamClumps.Find(delegate (CompetingModels CM) { return CM.CompetingModel == ModelName; });
            }
        }

        //MAKE IT SMARTER
        //public string CMName { get { return CM.CompetingModel; } set { } }

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
            set
            {
                _Rounds = value;
            }
        }
        public byte CurrentRoundNum { get; set; }

        [JsonIgnore]
        public Round CurrentRound
        {
            get
            {
                if (Enabled)
                {
                    if(Rounds.Count >= CurrentRoundNum)
                    {
                        return Rounds[Rounds.Count - 1];
                    }
                    return Rounds[CurrentRoundNum];
                }
                else
                {
                    return new Round();
                }
            }
            set
            {
                if (Enabled)
                    Rounds[CurrentRoundNum] = value;
            }
        }
        public bool Enabled { get; set; }

        public Team(bool Enabled)
        {
            Rounds.Add(new Round());
            this.Enabled = Enabled;
        }
        public Team()
        {

        }

        public void SelectRound(byte Round)
        {
            /*if (!(CM.RoundsForThisClass <= Round))
            {
                CM.SetRoundsCount(Round);
                return;
            }*/
            CurrentRoundNum = (byte)(Round - 1);
            //AutoClosingMessageBox.Show(Round.ToString(),"d",8000);
            if (Round > Rounds.Count)
            {
                SetRoundsCount(Round);
                //CurrentRoundNum = (byte)(Round - 1);
            }
            /*if (Rounds.Count >= Round)
            {
                //Normal
            }*/
            /*if (Round > CM.RoundsForThisClass)
             {
                 return;
                 DialogResult dialogResult = MessageBox.Show("Вы пытаетесь превысить количество туров для соревнования моделей " + CM.CompetingModel + ". Увеличить количество туров для совревнования?", "Предупреждение", MessageBoxButtons.YesNo);
                 if (dialogResult == DialogResult.Yes)
                 {
                     CM.SetRoundsCount(Round);
                 }
             }*/
        }
        public void SetRoundsCount(int RoundC)
        {
            if (RoundC == Rounds.Count)
            {
                return;
            }

            /*if (RoundC < Rules.MinRounds)
            {
                return;
            }*/
            if (Rounds.Count > RoundC)
            {
                int c = 1;
                while (!(Rounds.Count == RoundC))
                {
                    Rounds.Remove(Rounds[^c++]);
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
        public bool HasSameParticipant(Team other)
        {
            if (other == null)
            {
                return false;
            }
            //bool HSP = false;
            //bool HSM = false;

            if (Pilot != null && Pilot?.Name != null)
            {
                if (other.Pilot != null && other.Pilot?.Name != null)
                {
                    if (Pilot.Equals(other.Pilot))
                    {
                        return true;
                    }
                }
            }
            if (Mechanic != null && Mechanic?.Name != null)
            {
                if (other.Mechanic != null && other.Mechanic?.Name != null)
                {
                    if (Mechanic.Equals(other.Mechanic))
                    {
                        return true;
                    }
                }
            }
            return false;
            //return ((Pilot.Equals(other.Pilot) && other.Pilot?.Name != null) | (Mechanic.Equals(other.Mechanic) && other.Mechanic?.Name != null));
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
            //var R = new Round();
            CurrentRound = new Round();
        }
        public override string ToString()
        {
            if (!Enabled)
            {
                return "Отсутсвует";
            }
            return "П: " + Pilot.ShortenName() + " | М: " + Mechanic.ShortenName() + " | FM: " + ModelName + " | T: " + TeamName;
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
