using System;

namespace TimerModel.Objects
{
    public class ReportItem : IEquatable<ReportItem>
    {
        public string MainJudge { get; set; }
        public string LaunchSupervisor { get; set; }
        public string Scorekeeper { get; set; }

        public string[] Lines = new string[4];

        public CompetingModels CompetingModel { get; private set; }

        public ReportItem(CompetingModels CM)
        {
            CompetingModel = CM;
            Lines[0] = "ПРОТОКОЛ";
            Lines[1] = "соревнований по авиамодельному спорту";
            Lines[2] = "\"...\"  в классе радиоуправляемых моделей " + CompetingModel.CompetingModel;
            Lines[3] = "Дата соревнования";
        }
        public override string ToString()
        {
            return "Соревнование между моделями " + CompetingModel.CompetingModel;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            FinalReport objAsPart = obj as FinalReport;
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
        public bool Equals(ReportItem other)
        {
            if (other == null)
            {
                return false;
            }

            return (MainJudge == other.MainJudge);
        }
    }
}
