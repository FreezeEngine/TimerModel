using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TimerModel.Objects
{
    public class TeamContainer
    {
        //public static 
        //private List<Team> Teams { get; set; }
        //public List<Team> Teams = new List<Team>();

        public delegate void RoundHandler();
        public event RoundHandler onTeamNewCycle;
        public delegate void TeamHandler();
        public event TeamHandler onTeamChanged;
        public delegate void CompetitionHandler();
        public event CompetitionHandler onCompetitionFinished;
        //public delegate void TeamContainerHandler();
        //public event TeamContainerHandler onTeamRemoved;

        public int Count { get { int C = 0; foreach (var CM in TeamClumps) { C = C + CM.Teams.Count; } return C; } private set { } }


        private Team _Disabled = new Team(false);

        private Team _First;
        private Team _Second;
        private Team _Third;

        public CompetingModels CurrentModel;
        private void ResetTeams()
        {
            _First = _Disabled;
            _Second = _Disabled;
            _Third = _Disabled;
        }
        public List<TeamSet> TeamSets { get; set; }
        public List<CompetingModels> TeamClumps { get; set; }
        private void SameTeamMessage()
        {
            MessageBox.Show("Один и тот же участник не может быть выбран дважды");
        }
        private void NoTeamsMessage()
        {
            MessageBox.Show("Невозможно отключить все команды");
        }
        public Team First
        {
            get { return _First; }
            set { /*if (!_First.Enabled && !_Second.Enabled && _Third.Enabled) { NoTeamsMessage(); return; }*/ if ((value == _Second | value == _Third) && value.Enabled == true) { SameTeamMessage(); return; } else { _First = value; } }
        }
        public Team Second
        {
            get { return _Second; }
            set { /*if (!_First.Enabled && !_Second.Enabled && _Third.Enabled) { NoTeamsMessage(); return; }*/ if ((value == _First | value == _Third) && value.Enabled == true) { SameTeamMessage(); return; } else { _Second = value; } }
        }
        public Team Third
        {
            get { return _Third; }
            set { /*if (!_First.Enabled && !_Second.Enabled && _Third.Enabled) { NoTeamsMessage(); return; }*/  if ((value == _First | value == _Second) && value.Enabled == true) { SameTeamMessage(); return; } else { _Third = value; } }
        }
        public List<Team> GetTeamContainer()
        {
            return new List<Team>() { First, Second, Third };
        }
        public int MaxLaps()
        {
            int M1c = (First.CM != null) ? (First.CM.LapsCount) : (Rules.MinLaps);
            int M2c = (Second.CM != null) ? (Second.CM.LapsCount) : (Rules.MinLaps);
            int M3c = (Third.CM != null) ? (Third.CM.LapsCount) : (Rules.MinLaps);

            int[] MaxLaps = new int[3] { M1c, M2c, M3c };

            return MaxLaps.Max();
        }
        public int MaxRounds()
        {
            return Rules.MaxRounds;
        }
        public void Add(Team Team)
        {
            bool Added = false;
            foreach (var TC in TeamClumps)
            {
                if (TC.CompetingModel == Team.ModelName)
                {
                    TC.Add(Team);
                    TC.Teams[^1].CM = TC;
                    Added = true;
                }
            }
            if (!Added)
            {
                TeamClumps.Add(new CompetingModels(new List<Team>() { Team }) { CompetingModel = Team.ModelName });
            }
        }
        public void Remove(Team Team)
        {
            foreach (var TC in TeamClumps)
            {
                foreach (var T in TC.Teams)
                {
                    if (T.Equals(Team))
                    {
                        TC.Teams.Remove(T);
                        if (TC.Teams.Count == 0)
                        {
                            TeamClumps.Remove(TC);
                        }
                        return;
                    }
                }
            }
        }
        public TeamContainer()
        {
        }
        public TeamContainer(List<Team> Teams)
        {
            TeamClumps = new List<CompetingModels>();
            if (Teams.Count == 0)
            {
                return;
            }

            foreach (var T in Teams)
            {
                Add(T);
            }
        }
        public void Setup(bool Enabled = true)
        {
            foreach (var CM in TeamClumps)
            {
                CM.AtSetup = Enabled;
            }
        }
        public void GenerateTeamSets()
        {
            ResetTeams();

            var Teams = GetTeams();

            byte CountOfTeamSets = Convert.ToByte(Teams.Count / 3);

            TeamSets = new List<TeamSet>();
            TeamSets.Add(new TeamSet());
            int TC = 0;
            foreach (var T in Teams)
            {
                if (TC == 3)
                {
                    TC = 0;
                    TeamSets.Add(new TeamSet());
                }
                TC++;

            }
        }
        public List<Team> GetTeams()
        {
            //return this.Teams;
            var Teams = new List<Team>();
            foreach (var TC in TeamClumps)
            {
                foreach (var T in TC.Teams)
                {
                    Teams.Add(T);
                }
            }
            return Teams;
        }
        private void Shuffle()
        {
            foreach (var CM in TeamClumps)
            {
                CM.Teams.Shuffle();
            }
        }
        public void Reset()
        {
            First.Reset();
            Second.Reset();
            Third.Reset();
        }
        public void NextRound()
        {
            var Teams = GetTeams();
            int c = 0;

            foreach (Team T in Teams)
            {
                /*if (T.CurrentRoundNum + 1 == T.CM.RoundsForThisClass)
                {
                    continue;
                }*/

                T.NextRound();
                c++;
            }
            if (c == 0)
            {
                foreach (Team T in Teams)
                {
                    byte RC = 0;
                    foreach (Round R in T.Rounds)
                    {
                        if (R.Finished)
                        {
                            continue;
                        }

                        T.SelectRound(++RC);
                    }
                    /*if (T.CurrentRoundNum + 1 == T.CM.RoundsForThisClass && T.CurrentRound.Finished)
                    {
                        continue;
                    }*/

                    c++;
                }
                if (c == 0)
                {
                    onCompetitionFinished();
                    return;
                }
            }
            onTeamNewCycle();
            NextSetOfTeams();
        }
        public void NextSetOfTeams()
        {
            byte TS = 1;
            ResetTeams();

            var Teams = GetTeams();

            foreach (var T in Teams)
            {
                bool F = true;
                foreach (var R in T.Rounds)
                {
                    if (R.Finished)
                    {
                        continue;
                    }

                    F = false;
                }
                if (F)
                {
                    continue;
                }
                if (T.CurrentRound.Finished)
                {
                    continue;
                }
                switch (TS)
                {
                    case 1:
                        _First = T;
                        TS++;
                        break;
                    case 2:
                        _Second = T;
                        TS++;
                        break;
                    case 3:
                        _Third = T;
                        TS++;
                        onTeamChanged();
                        return;
                    default:
                        break;
                }
            }

            if (TS == 1)
            {
                foreach (var TC in TeamClumps)
                {
                    TC.Teams.Shuffle();
                }
                NextRound();
                return;
            }
            onTeamChanged();
        }
    }
}
