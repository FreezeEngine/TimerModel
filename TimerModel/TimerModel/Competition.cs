using System;
using System.Collections.Generic;
using System.Text;

namespace TimerModel
{
    //class Team
    class TeamSet
    {
        

        private List<Team> Teams { get; set; }

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
                Shift = 0;
            }
            else
            {
                Shift = Shift + 3;
            }
        }
    }
    class Competition
    {
        private int _Round;
        public int Round
        {
            get { return _Round; }
            private set { _Round = value; }
        }
        public static TeamSet Teams { get; set; }
        public Competition(List<Team> LTeams)
        {
            Teams = new TeamSet(LTeams);
        }
        public void NextRound()
        {

        }
    }
}
