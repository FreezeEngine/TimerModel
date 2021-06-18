using System;

namespace TimerModel.Objects
{
    public class ReportItem : IEquatable<ReportItem>
    {
        public CompetingModels CompetingModel { get; private set; }

        public ReportItem(CompetingModels CM)
        {
            CompetingModel = CM;
            if (CompetingModel.Lines[0] == null | CompetingModel.Lines[0] == "")
                CompetingModel.Lines[0] = "ПРОТОКОЛ";
            if (CompetingModel.Lines[1] == null | CompetingModel.Lines[1] == "")
                CompetingModel.Lines[1] = "соревнований по авиамодельному спорту";
            if (CompetingModel.Lines[2] == null | CompetingModel.Lines[2] == "")
                CompetingModel.Lines[2] = "\"...\"  в классе радиоуправляемых моделей " + CompetingModel.CompetingModel;
            if (CompetingModel.Lines[3] == null | CompetingModel.Lines[3] == "")
                CompetingModel.Lines[3] = "Дата соревнования";
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

            return (CompetingModel == other.CompetingModel);
        }
    }
}
