using OfficeOpenXml;
using System.Collections.Generic;

namespace TimerModel
{
    public class ListOfTeams
    {
        public byte[] Generate(List<Team> List)
        {
            using (var Package = new ExcelPackage())
            {
                var Sheet = Package.Workbook.Worksheets.Add("Команды");
                int i = 1;

                foreach (Team team in List)
                {
                    Sheet.Cells[i, 1].Value = team.Pilot;
                    Sheet.Cells[i, 2].Value = team.Mechanic;
                    Sheet.Cells[i, 3].Value = team.ModelName;
                    i++;
                }

                return Package.GetAsByteArray();
            }
        }
    }
}
