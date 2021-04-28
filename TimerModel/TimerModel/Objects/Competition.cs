using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TimerModel
{
    //class Team
    /*


     * */
    public class TeamSet
    {
        private List<Team> Teams { get; set; }

        public delegate void RoundHandler();
        public event RoundHandler onTeamNewCycle;
        public event RoundHandler onTeamChanged;
        public int Count { get { return Teams.Count; } private set { } }

        private Team _First = new Team() { Enabled = false };
        private Team _Second = new Team() { Enabled = false };
        private Team _Third = new Team() { Enabled = false };

        public Team First
        {
            get { return _First; }
            set { _First = value; onTeamChanged(); }
        }
        public Team Second
        {
            get { return _Second; }
            set { _Second = value; onTeamChanged(); }
        }
        public Team Third
        {
            get { return _Third; }
            set { _Third = value; onTeamChanged(); }
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
        public void Reset()
        {
            First.Reset();
            Second.Reset();
            Third.Reset();
        }
        public void UpdateTeams(List<Team> Teams)
        {
            this.Teams = Teams;
        }
        public void NextRound()
        {
            foreach (Team T in Teams)
            {
                T.NextRound();
                T.Finished = false;
            }
            Shift = 0;
            onTeamNewCycle();
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
                NextRound();
            }
            else
            {
                Shift = Shift + 3;
            }
        }
    }
    public class Competition
    {
        public int Round { get; set; }
        public string MainJudge { get; set; }
        public string LaunchSupervisor { get; set; }
        public string Scorekeeper { get; set; }

        public string[] Lines = new string[4];

        public static TeamSet Teams { get; set; }
        public Competition(List<Team> LTeams)
        {
            Teams = new TeamSet(LTeams);
            Teams.onTeamNewCycle += () =>
            {
                Round = Round + 1;
            };
            //Teams.First.Rounds[Round].onFinish += () => { Teams.First.Finished };
        }
        public void Lap(int ModelNum)
        {
            switch (ModelNum)
            {
                case 0:
                    if (Teams.First.Enabled)
                    {
                        Teams.First.Rounds[Round].MakeLap();
                    }
                    break;
                case 1:
                    if (Teams.Second.Enabled)
                    {
                        Teams.Second.Rounds[Round].MakeLap();
                    }
                    break;
                case 2:
                    if (Teams.Third.Enabled)
                    {
                        Teams.Third.Rounds[Round].MakeLap();
                    }
                    break;
            }
        }
    }
}
