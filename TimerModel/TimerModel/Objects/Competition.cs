using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TimerModel
{
    //class Team
    class TeamSet
    {
        private List<Team> Teams { get; set; }

        public delegate void RoundHandler();
        public event RoundHandler onTeamNewCycle;
        public int Count { get { return Teams.Count; } private set {  } }

        private Team _First;
        private Team _Second;
        private Team _Third;

        public Team First
        {
            get { return _First; }
            private set { _First = value; }
        }
        public Team Second
        {
            get { return _Second; }
            private set { _Second = value; }
        }
        public Team Third
        {
            get { return _Third; }
            private set { _Third = value; }
        }
        private int _Shift { get; set; }
        public int Shift
        {
            get { return _Shift; } //Shift < MaxRounds
            set { _Shift = value; }
        }
        public TeamSet(List<Team> Teams)
        {
            this.Teams = Teams;
        }
        public List<Team> GetTeams()
        {
            return Teams;
        }
        public void UpdateTeams(List<Team> Teams)
        {
            this.Teams = Teams;
        }
        public void NextSetOfTeams()
        {
            if (Shift != 0) //Save results
            {
                if (Teams.Count > Shift - 3)
                {
                    Teams[Shift - 3] = First;
                }
                if (Teams.Count > Shift - 2)
                {
                    Teams[Shift - 2] = Second;
                }
                if (Teams.Count > Shift - 1)
                {
                    Teams[Shift - 1] = Third;
                }
            }
            if (Teams.Count > Shift)
            {
                First = Teams[Shift];
            }
            else
            {
                First = new Team() { Enabled = false };
            }
            if (Teams.Count > (Shift + 1))
            {
                Second = Teams[Shift + 1];
            }
            else
            {
                Second = new Team() { Enabled = false };
            }
            if (Teams.Count > (Shift + 2))
            {
                Third = Teams[Shift + 2];
            }
            else
            {
                Third = new Team() { Enabled = false };
            }
            if (!(Teams.Count > Shift) && !(Teams.Count > (Shift + 1)) && !(Teams.Count > (Shift + 2)))
            {
                //MessageBox.Show("S1");
                foreach(Team T in Teams)
                {
                    T.NextRound();
                    T.Finished = false;
                }
                Shift = 0;
                onTeamNewCycle();
            }
            else
            {
                Shift = Shift + 3;
            }
        }
    }
    class Competition
    {
        public int Round { get; private set; }

        public static TeamSet Teams { get; set; }
        public Competition(List<Team> LTeams)
        {
            Teams = new TeamSet(LTeams);
            Teams.onTeamNewCycle += () => {
                Round = Round + 1; 
            };
            //Teams.First.Rounds[Round].onFinish += () => { Teams.First.Finished };
        }
        public void Lap(int ModelNum)
        {
            switch (ModelNum)
            {
                case 1:
                    Teams.First.Rounds[Round].MakeLap();
                    break;
                case 2:
                    Teams.Second.Rounds[Round].MakeLap();
                    break;
                case 3:
                    Teams.Third.Rounds[Round].MakeLap();
                    break;
            }
        }
    }
}
