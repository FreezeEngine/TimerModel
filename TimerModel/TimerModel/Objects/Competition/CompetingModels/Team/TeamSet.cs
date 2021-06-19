using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace TimerModel.Objects
{
    public class TeamSet : IEquatable<TeamSet>
    {
        [JsonIgnore]
        public Team First
        {
            get
            {
                if (Set[0] == -1)
                {
                    return new Team(false);
                }
                return TimerSettings.Competition.Teams.AllTeams[Set[0]];
            }
            set
            {
                //if (Set[0] == -1) {  }
                if (value == null | !value.Enabled) { Set[0] = -1; return; }
                if (value == Second | value == Third && value.Enabled == true && !Updater) { SameTeamMessage(); return; } else { Set[0] = (sbyte)TimerSettings.Competition.Teams.AllTeams.FindIndex(delegate (Team fT) { return fT.Equals(value); }); }
            }
        }
        [JsonIgnore]
        public Team Second
        {
            get
            {
                if (Set[1] == -1)
                {
                    return new Team(false);
                }
                return TimerSettings.Competition.Teams.AllTeams[Set[1]];
            }
            set
            {
                //if (Set[0] == -1) {  }
                if (value == null | !value.Enabled) { Set[1] = -1; return; }
                if (value == Second | value == Third && value.Enabled == true && !Updater) { SameTeamMessage(); return; } else { Set[1] = (sbyte)TimerSettings.Competition.Teams.AllTeams.FindIndex(delegate (Team fT) { return fT.Equals(value); }); }
            }
        }
        //TimerSettings.Competition.Teams.AllTeams[Set[2]]
        [JsonIgnore]
        public Team Third
        {
            get
            {
                if (Set[2] == -1)
                {
                    return new Team(false);
                }
                return TimerSettings.Competition.Teams.AllTeams[Set[2]];
            }
            set
            {
                //if (Set[0] == -1) {  }
                if (value == null | !value.Enabled) { Set[2] = -1; return; }
                if (value == Second | value == Third && value.Enabled == true && !Updater) { SameTeamMessage(); return; } else { Set[2] = (sbyte)TimerSettings.Competition.Teams.AllTeams.FindIndex(delegate (Team fT) { return fT.Equals(value); }); }
            }
        }
        public bool isFull()
        {
            //REPLACE WITH THIS METHOD
            return First.Enabled && Second.Enabled && Third.Enabled;
        }
        public bool ShareSamePerson(Team T)
        {
            //REPLACE ALL WITH THIS TEAM SET EDITOR
            foreach(var Tm in GetAsList())
            {
                if (!Tm.Enabled)
                    continue;
                if (Tm.HasSameParticipant(T))
                {
                    return true;
                }
            }
            return false;
        }
        //Fix null //= new Team(false);
        public sbyte[] Set { get; set; }
        public List<Team> GetAsList()
        {
            return new List<Team>() { First, Second, Third };
        }

        public void UpdateAsList(Team[] TST)
        {
            UpdateSets();
            if (TST.Length == 3)
            {
                First = TST[0];
                Second = TST[1];
                Third = TST[2];
            }
            UpdateSets();
        }
        private bool Updater = false;
        public void UpdateSets()
        {
            TimerSettings.Competition.Teams.Updater = !TimerSettings.Competition.Teams.Updater;
            Updater = !Updater;
        }
        public TeamSet()
        {
            Set = new sbyte[3] { -1, -1, -1 };
        }
        public TeamSet(List<Team> Teams, byte SetNum = 0)
        {
            Set = new sbyte[3] { -1, -1, -1 };

            byte SetIndex = (byte)(SetNum * 3);
            Set[0] = (sbyte)SetIndex;
            if (Teams.Count > SetIndex + 1)
                Set[1] = (sbyte)(SetIndex + 1);
            if (Teams.Count > SetIndex + 2)
                Set[2] = (sbyte)(SetIndex + 2);
        }
        public void Add(Team T)
        {
            if (First.Enabled && Second.Enabled && Third.Enabled)
                return;
            bool SameP = false;
            foreach (var Ti in Set)
            {
                if (Ti == -1)
                    continue;
                var Te = TimerSettings.Competition.Teams.AllTeams[Ti];
                if (Te.Enabled)
                {
                    if (Te.HasSameParticipant(T))
                    {
                        SameP = true;
                    }
                }
            }
            if (!SameP)
            {
                var Ts = GetAsList();
                for (byte i = 0; i < Set.Length; i++)
                {
                    if (!Ts[i].Enabled)
                    {
                        Set[i] = (sbyte)TimerSettings.Competition.Teams.AllTeams.FindIndex(delegate (Team fT) { return fT.Equals(T); });
                    }
                }
            }

            //Err
        }
        public void Shuffle()
        {
            Set.ShuffleTeamSet();
        }
        public override string ToString()
        {
            string f = First.Enabled ? " 1: " + First.Pilot.ShortenName() : " 1: Отсутствует";
            string s = Second.Enabled ? " 2: " + Second.Pilot.ShortenName() : " 2: Отсутствует";
            string t = Third.Enabled ? " 3: " + Third.Pilot.ShortenName() : " 3: Отсутствует";
            return f + s + t;
        }
        private void SameTeamMessage()
        {
            MessageBox.Show("Один и тот же участник не может быть выбран дважды");
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is TeamSet objAsPart))
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
        public bool Equals(TeamSet other)
        {
            if (other == null)
            {
                return false;
            }

            return (First == other.First && Second == other.Second && Third == other.Third);
        }
    }
}
