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

        //public TeamSet 

        //private Team _First;
        //private Team _Second;
        //private Team _Third;

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

        [JsonIgnore]
        public Team First
        {
            get
            {
                if(CurrentModel == null)
                {
                    return _Disabled;
                }
                var _First = CurrentModel.CurrentTeamset.First;
                /*if (AllTeams.Find(delegate (Team T) { return T.Equals(_First) && T != _First; }) != null)
                {
                    byte i = (byte)AllTeams.FindIndex(delegate (Team T) { return T.Equals(_First) && T != _First; });
                    AllTeams.RemoveAt(i);
                    AllTeams.Insert(i, _First);
                }*/
                return _First;
            }
            set { if (CurrentModel == null) { return; } CurrentModel.CurrentTeamset.First = value; }
            //set { if (value == null | CurrentModel == null) { return; } if ((value == Second | value == Third) && value.Enabled == true && !Updater) { SameTeamMessage(); return; } else { CurrentModel.CurrentTeamset.First = value; } }

        }
        [JsonIgnore]
        public Team Second
        {
            get
            {
                if (CurrentModel == null)
                {
                    return _Disabled;
                }
                var _Second = CurrentModel.CurrentTeamset.Second;
                /*if (AllTeams.Find(delegate (Team T) { return T.Equals(_Second) && T != _Second; }) != null)
                {
                    byte i = (byte)AllTeams.FindIndex(delegate (Team T) { return T.Equals(_Second) && T != _Second; });
                    AllTeams.RemoveAt(i);
                    AllTeams.Insert(i, _Second);
                }*/
                return _Second;
            }
            set { if (CurrentModel == null) { return; } CurrentModel.CurrentTeamset.Second = value; }
        }
        [JsonIgnore]
        public Team Third
        {
            get
            {
                if (CurrentModel == null)
                {
                    return _Disabled;
                }
                var _Third = CurrentModel.CurrentTeamset.Third;
                /*if (AllTeams.Find(delegate (Team T) { return T.Equals(_Third) && T != _Third; }) != null)
                {
                    byte i = (byte)AllTeams.FindIndex(delegate (Team T) { return T.Equals(_Third) && T != _Third; });
                    AllTeams.RemoveAt(i);
                    AllTeams.Insert(i, _Third);
                }*/
                return _Third;
            }
            set { if (CurrentModel == null) { return; } CurrentModel.CurrentTeamset.Third = value; }
        }
        public byte GlobalRound { get; set; }
        [JsonIgnore]
        public byte TeamOffset {

            get
            {
                double TDr = GlobalRound / 3d;
                if (TDr == 0)
                    return 0;
                if (TDr.ToString("0.00").Split(',')[1].Contains('0'))
                {
                    return 0;
                }
                if (TDr.ToString("0.00").Split(',')[1].Contains('3'))
                {
                    return 1;
                }
                if (TDr.ToString("0.00").Split(',')[1].Contains('6'))
                {
                    return 2;
                }
                return 0;
            }
            set { }
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
        public bool Updater = false;
        public void ReloadTeamSet()
        {
            //Resolve?
            Updater = true;
            //First = CurrentModel.CurrentTeamset.First;
            //Second = CurrentModel.CurrentTeamset.Second;
            //Third = CurrentModel.CurrentTeamset.Third;
            Updater = false;
            //onTeamChanged();
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
            //First = CurrentModel.CurrentTeamset.First;
            //Second = CurrentModel.CurrentTeamset.Second;
            //Third = CurrentModel.CurrentTeamset.Third;
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
        public void Remove(Team teamToDelete)
        {
            //return; //TEAM INDEXES UPDATE AFTER DELETION!!!!!
            sbyte teamIndex = (sbyte)AllTeams.FindIndex(delegate (Team t) { return t == teamToDelete; });
            AllTeams.Remove(teamToDelete);
            //TeamClumps.FindAll(delegate (CompetingModels CM) { return CM.Teams().Count == 0; }).ForEach(delegate (CompetingModels CM) { TeamClumps.Remove(CM); });
            //GenerateTeamSets();


            
            TeamClumps.ForEach(delegate (CompetingModels CM)
            {
                while (CM.TeamSets.Find(delegate (TeamSet TS) { return TS.Set.ToList().Contains(teamIndex); }) != null)
                {
                    CM.TeamSets.Remove(CM.TeamSets.Find(delegate (TeamSet TS) { return !TS.First.Enabled && !TS.Second.Enabled && !TS.Third.Enabled; }));
                    //return;
                }
                //delete all empty clumps
                while (CM.TeamSets.Find(delegate (TeamSet TS) { return !TS.First.Enabled && !TS.Second.Enabled && !TS.Third.Enabled; }) != null)
                {
                    CM.TeamSets.Remove(CM.TeamSets.Find(delegate (TeamSet TS) { return !TS.First.Enabled && !TS.Second.Enabled && !TS.Third.Enabled; }));
                    //return;
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
            //MessageBox.Show("TT");
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
