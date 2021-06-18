using CompetitionOrganizer.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using TimerModel.Forms.Setup_Forms;

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

        //public delegate void TeamContainerHandler();
        //public event TeamContainerHandler onTeamRemoved;

        [JsonIgnore]
        public int Count { get { return AllTeams.Count; } private set { } }


        public Team _Disabled = new Team(false);

        private Team _First;
        private Team _Second;
        private Team _Third;

        private List<Team> _AllTeams { get; set; }
        public List<Team> AllTeams { get { if (_AllTeams == null) { _AllTeams = new List<Team>(); } return _AllTeams; } set { if (_AllTeams == null) { _AllTeams = new List<Team>(); } _AllTeams = value; } }

        private List<CompetingModels> _TeamClumps;
        public List<CompetingModels> TeamClumps
        {
            get
            {
                if (_TeamClumps == null)
                {
                    _TeamClumps = new List<CompetingModels>();
                }
                return _TeamClumps;
            }
            set
            {
                _TeamClumps = value;
            }
        }
        private CompetingModels _CurrentModel;
        public CompetingModels CurrentModel
        {
            get
            {
                if (TeamClumps.Find(delegate (CompetingModels CM) { return CM.Equals(_CurrentModel) && CM != _CurrentModel; }) != null)
                {
                    byte i = (byte)TeamClumps.FindIndex(delegate (CompetingModels CM) { return CM.Equals(_CurrentModel) && CM != _CurrentModel; });
                    TeamClumps.RemoveAt(i);
                    TeamClumps.Insert(i, _CurrentModel);
                }
                return _CurrentModel;
            }
            set { if (value == null) { return; } _CurrentModel = value; }
        }

        public List<CompetingModels> GetTeamClumps()
        {
            if (_TeamClumps == null)
            {
                _TeamClumps = new List<CompetingModels>();
            }
            return _TeamClumps;
        }
        public List<Participant> Participants()
        {
            List<Participant> P = new List<Participant>();
            foreach (var T in AllTeams)
            {
                if (T.Pilot.Name != null)
                    P.Add(T.Pilot);
                if (T.Mechanic.Name != null)
                    P.Add(T.Mechanic);
            }
            return P;
        }
        private void SameTeamMessage()
        {
            MessageBox.Show("Один и тот же участник не может быть выбран дважды!");
        }
        private void NoTeamsMessage()
        {
            MessageBox.Show("Невозможно отключить все команды");
        }
        public Team First
        {
            get
            {
                if (AllTeams.Find(delegate (Team T) { return T.Equals(_First) && T != _First; }) != null)
                {
                    byte i = (byte)AllTeams.FindIndex(delegate (Team T) { return T.Equals(_First) && T != _First; });
                    AllTeams.RemoveAt(i);
                    AllTeams.Insert(i, _First);
                }
                return _First;
            }
            set { if (value == null) { return; } if ((value == _Second | value == _Third) && value.Enabled == true && !Updater) { SameTeamMessage(); return; } else { _First = value; } }
        }
        public Team Second
        {
            get
            {
                if (AllTeams.Find(delegate (Team T) { return T.Equals(_Second) && T != _Second; }) != null)
                {
                    byte i = (byte)AllTeams.FindIndex(delegate (Team T) { return T.Equals(_Second) && T != _Second; });
                    AllTeams.RemoveAt(i);
                    AllTeams.Insert(i, _Second);
                }
                return _Second;
            }
            set { if (value == null) { return; } if ((value == _First | value == _Third) && value.Enabled == true && !Updater) { SameTeamMessage(); return; } else { _Second = value; } }
        }
        public Team Third
        {
            get
            {
                if (AllTeams.Find(delegate (Team T) { return T.Equals(_Third) && T != _Third; }) != null)
                {
                    byte i = (byte)AllTeams.FindIndex(delegate (Team T) { return T.Equals(_Third) && T != _Third; });
                    AllTeams.RemoveAt(i);
                    AllTeams.Insert(i, _Third);
                }
                return _Third;
            }
            set { if (value == null) { return; } if ((value == _First | value == _Second) && value.Enabled == true && !Updater) { SameTeamMessage(); return; } else { _Third = value; } }
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
        bool Updater = false;
        public void ReloadTeamSet()
        {
            Updater = true;
            First = CurrentModel.CurrentTeamset.First;
            Second = CurrentModel.CurrentTeamset.Second;
            Third = CurrentModel.CurrentTeamset.Third;
            Updater = false;
            onTeamChanged();
        }

        public void NextTeamSet(bool FirstStart = false)
        {
            //GenerateTeamSets();
            if (!FirstStart)
            {
                bool NeedNewTeams = CurrentModel.NextTeamSet();
                if (!NeedNewTeams)
                {

                    ChooseNextModelSet CNMS = new ChooseNextModelSet();
                    CNMS.Show();
                    CNMS.FormClosing += (s, a) =>
                    {
                        CurrentModel = TeamClumps[CNMS.SelectedIndex];
                        NextTeamSet(true);
                        /*byte FTCC = 0;
                        foreach (var TC in TeamClumps)
                        {
                            byte FT = 0;
                            TC.Teams().ForEach(delegate (Team T) { if (T.CurrentRound.Finished) { FT++; } });
                            if (FT == TC.Teams().Count)//SIMPLER
                            {
                                FTCC++;
                            }
                            if (FTCC == TeamClumps.Count)
                            {
                                //CurrentModel.Nex
                                foreach (var Tm in CurrentModel.Teams())
                                {
                                    Tm.NextRound();
                                }
                            }
                        }*/
                    };

                    return;
                }
            }
            First = CurrentModel.CurrentTeamset.First;
            Second = CurrentModel.CurrentTeamset.Second;
            Third = CurrentModel.CurrentTeamset.Third;
            if (onTeamChanged != null)
                onTeamChanged();
        }
        public int MaxRounds()
        {
            return Rules.MaxRounds;
        }
        public void Add(Team Team)
        {
            AllTeams.Add(Team);
            var TC = TeamClumps.Find(delegate (CompetingModels CM) { return CM.CompetingModel == Team.ModelName; });

            if (TC == null)
            {
                TeamClumps.Add(new CompetingModels() { CompetingModel = Team.ModelName });
            }
            //FO IT SMALLER
            bool Added = false;

            if (Team.CM == null)
            {
                return;
            }
            foreach (var TS in Team.CM.TeamSets)
            {
                if (TS.First.Enabled && TS.Second.Enabled && TS.Third.Enabled)
                    continue;
                //bool HasSameP = false;
                foreach (var T in TS.GetAsList())
                {
                    if (!T.Enabled)
                        continue;
                    if (!T.HasSameParticipant(Team))
                    {
                        TS.Add(T);
                        Added = true;
                        //HasSameP = true;
                    }
                }
                if (!Added)
                {
                    Team.CM.TeamSets.Add(new TeamSet() { First = Team });
                }

            }
            //GenerateTeamSets();
        }
        public void Remove(Team Team)
        {
            return; //TEAM INDEXES UPDATE AFTER DELETION!!!!!
            AllTeams.Remove(Team);
            //TeamClumps.FindAll(delegate (CompetingModels CM) { return CM.Teams().Count == 0; }).ForEach(delegate (CompetingModels CM) { TeamClumps.Remove(CM); });
            //GenerateTeamSets();
            TeamClumps.ForEach(delegate (CompetingModels CM)
            {
                while (CM.TeamSets.Find(delegate (TeamSet TS) { return !TS.First.Enabled && !TS.Second.Enabled && !TS.Third.Enabled; }) != null)
                {
                    CM.TeamSets.Remove(CM.TeamSets.Find(delegate (TeamSet TS) { return !TS.First.Enabled && !TS.Second.Enabled && !TS.Third.Enabled; }));
                }
            });

        }
        public TeamContainer()
        {
            //AutoClosingMessageBox.Show("Test2", "Test2", 4000);
            GenerateTeamSets();

            First = Second = Third = _Disabled;
        }
        public TeamContainer(List<Team> Teams)
        {
            First = Second = Third = _Disabled;
            //TeamClumps = new List<CompetingModels>();//??!!!!!!!!!!!!!
            if (Teams.Count == 0)
            {
                return;
            }

            foreach (var T in Teams)
            {
                Add(T);
            }


            GenerateTeamSets(); //Fix reordering!!!
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
            foreach (var TC in TeamClumps)
            {
                TC.GenerateTeamSets(); //Fix reordering!!!
            }
        }
        public List<Team> GetTeams()
        {
            return AllTeams;
        }
        public void Reset()
        {
            First.Reset();
            Second.Reset();
            Third.Reset();
        }

    }
}
