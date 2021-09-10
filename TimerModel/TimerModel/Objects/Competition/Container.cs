using TimerModel;

namespace CompetitionOrganizer.Objects
{
    public class CompetitionsContainer
    {
        public string Name { get; set; }
        public string MainJudge { get; set; }
        public string LaunchSupervisor { get; set; }
        public string Scorekeeper { get; set; }

        public Competition Competition { get; set; }

        //private List<Competition> _PartsOfCompetitions;
        /*public List<Competition> PartsOfCompetitions
        {
            get
            {
                if (_PartsOfCompetitions == null)
                {
                    _PartsOfCompetitions = new List<Competition>();
                }
                return _PartsOfCompetitions;
            }
            set
            {
                _PartsOfCompetitions = value;
            }
        }*/

        //public Competition CurrentState { get; set; }
        public CompetitionsContainer()
        {

        }
        /*public Competition GetCombined()
        {
            //REWORK!!!
            Competition Combined = new Competition();
            foreach (var C in PartsOfCompetitions)
            {
                var TS = C.Teams.GetTeams();
                foreach (var T in TS)
                {
                    Combined.Teams.Add(T);
                }
            }
            return Combined;
        }*/
    }
}
