using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace TimerModel.Objects
{
    public class CompetingModels : IEquatable<CompetingModels>
    {
        public byte Round { get; set; }
        public byte ActiveTeamSet { get; set; }
        public byte CurrentTeamSetIndex { get; set; }

        public string[] Lines = new string[4];
        public bool AtSetup { get; set; }

        private byte _LapsCount = Rules.MinLaps;
        public byte LapsCount { get { return _LapsCount; } set { if (value <= Rules.MaxLaps && Rules.MinLaps <= value) { _LapsCount = value; } } }

        private byte _MaxRoundsCount = Rules.MinLaps;
        public byte MaxRoundsCount
        {
            get { return _MaxRoundsCount; }
            set
            {
                if (value <= Rules.MaxRounds && Rules.MinRounds <= value)
                {
                    SetRoundsCount(value);
                    _MaxRoundsCount = value;
                }
            }
        }

        public string CompetingModel { get; set; }

        private List<TeamSet> _TeamSets;
        public List<TeamSet> TeamSets
        {
            get { if (_TeamSets == null) { _TeamSets = new List<TeamSet>(); } if (_TeamSets.Count == 0 && Teams().Count > 0) { GenerateTeamSets(); } return _TeamSets; }
            set
            {
                _TeamSets = value;
            }
        }
        [JsonIgnore]
        public TeamSet CurrentTeamset { get { return TeamSets[CurrentTeamSetIndex]; } }
        //private List<Team> _Teams;
        //[JsonIgnore]
        public List<Team> Teams(Competition competition = null)
        {
            if (TimerSettings.Competition == null && competition == null)
            {
                return new List<Team>();
            }
            List<Team> Ts = competition == null ? TimerSettings.Competition?.Teams.AllTeams : competition?.Teams.AllTeams;

            var T = Ts.FindAll(delegate (Team T) { return T.ModelName == CompetingModel; });

            if (T == null | T.Count == 0)
            {
                return new List<Team>();
            }
            return T;
        }

        public void GenerateTeamSets()
        {

            var TSS = new List<TeamSet>();

            var Ts = Teams();
            if (Ts.Count == 0)
                return;
            byte TSCount = (byte)(Ts.Count / 3);
            if ((Ts.Count - TSCount * 3) != 0)
            {
                TSCount++;
            }

            if (TSCount == 0)
                TSCount = 1;

            bool added = false;
            foreach (var T in Ts)
            {
                if (TSS.Count == 0)
                {
                    TSS.Add(new TeamSet());
                    TSS[^1].First = T;
                }
                else
                {
                    added = false;
                    foreach (var TS in TSS)
                    {
                        if (TS.isFull() | TS.ShareSamePerson(T) | added)
                            continue;
                        byte i = (byte)TS.GetAsList().FindIndex(delegate (Team Tf) { return !Tf.Enabled; });

                        switch (i)
                        {
                            case 0:
                                TS.First = T;
                                break;
                            case 1:
                                TS.Second = T;
                                break;
                            case 2:
                                TS.Third = T;
                                break;
                        }
                        added = true;
                        break;
                        //TeamSets = TSS;
                        //break;
                        //TS.UpdateAsList(new Team[3] { });
                    }
                    if (!added)
                    {
                        TSS.Add(new TeamSet());
                        TSS[^1].First = T;
                    }
                }
                TeamSets = TSS;
            }
        }
        public void ReorderTeamsets()
        {
            for (byte i = 0; i < TeamSets.Count; i++)
            {
                var P = TeamSets[i].First.Pilot;
                if (P == TeamSets[i].Second.Pilot | P == TeamSets[i].Third.Pilot | P == TeamSets[i].Second.Mechanic | P == TeamSets[i].Third.Mechanic)
                {
                    if (i == TeamSets.Count - 1 | i == TeamSets.Count - 2)
                    {
                        var A = TeamSets[i].First;

                        //First = 
                    }
                    else
                    {
                        //i -
                    }
                }
                //byte SafeIndex()
                //{

                //}
            }
        }
        public CompetingModels()
        {
            //SetRoundsCount(MaxRoundsCount);
            //GenerateTeamSets();
        }
        public void SetRoundsCount(byte count)
        {
            foreach (var T in Teams(TimerSettings.Competition != null ? TimerSettings.Competition : null))
            {
                T.SetRoundsCount(count);
            }
        }
        public byte GetMaxRoundsCountForThisClass()
        {
            List<byte> values = new List<byte>();
            var Ts = Teams();
            foreach (Team T in Ts)
            {
                values.Add((byte)T.Rounds.Count);
            }
            return values.ToArray().Max();
        }
        public bool NextTeamSet()
        {
            if (CurrentTeamSetIndex + 1 < TeamSets.Count)
            {
                //if (CurrentTeamSetIndex + 1 < TeamSets.Count)
                CurrentTeamSetIndex++;
                return true;
            }
            else
            {
                CurrentTeamSetIndex = 0;
                return false;
            }

        }
        public void SetLapsCount(byte LapsCount)
        {
            //AutoClosingMessageBox.Show("LapsSet", "LapsSet", 4000);
            if (LapsCount < this.LapsCount)
            {
                DialogResult dialogResult = MessageBox.Show("Изменение количества кругов в меньшую сторону приведёт к удалению сохранённых данных в удалённом круге, что так же приведёт к пересчету очков", "Предупреждение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.LapsCount = LapsCount;
                    var Ts = Teams();
                    foreach (var T in Ts)
                    {
                        T.SetLapsCount(LapsCount);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }

        public override string ToString()
        {
            if (TimerSettings.Competition?.Teams.CurrentModel == null)
            {
                string T = (AtSetup) ? (" | " + MaxRoundsCount + "/" + LapsCount) : ("");
                return CompetingModel + T;
            }
            return CompetingModel;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            CompetingModels objAsPart = obj as CompetingModels;
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
        public bool Equals(CompetingModels other)
        {
            if (other == null)
            {
                return false;
            }

            return (CompetingModel.Equals(other.CompetingModel));
        }
    }
}
