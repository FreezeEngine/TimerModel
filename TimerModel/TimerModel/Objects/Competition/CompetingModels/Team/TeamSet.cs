using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TimerModel.Objects
{
    public class TeamSet : IEquatable<TeamSet>
    {
        private Team _First = new Team() { Enabled = false };
        private Team _Second = new Team() { Enabled = false };
        private Team _Third = new Team() { Enabled = false };
        private void ResetTeams()
        {
            _First = new Team() { Enabled = false };
            _Second = new Team() { Enabled = false };
            _Third = new Team() { Enabled = false };
        }

        //List<List<Team>> TeamSets { get; set; }
        //Team[][] TeamSets;

        //public TeamSet(List<Team> Teams)
        //{

        //}
        //public void LoadTeams(List<Team> Teams)
        //{
        //    TeamSets = new Team[Teams.Count/3][];
        //}
        //public void 
        private void SameTeamMessage()
        {
            MessageBox.Show("Один и тот же участник не может быть выбран дважды");
        }
        public Team First
        {
            get { return _First; }
            set { if (value == _Second | value == _Third) { SameTeamMessage(); return; } else { _First = value; } }
        }
        public Team Second
        {
            get { return _Second; }
            set { if (value == _First | value == _Third) { SameTeamMessage(); return; } else { _Second = value; } }
        }
        public Team Third
        {
            get { return _Third; }
            set { if (value == _First | value == _Second) { SameTeamMessage(); return; } else { _Third = value; } }
        }
        public override string ToString()
        {
            return First.GetShortPilotName() + " " + Second.GetShortPilotName() + " " + Third.GetShortPilotName();
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
