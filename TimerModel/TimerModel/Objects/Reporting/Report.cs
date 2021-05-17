using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using TimerModel.Objects;

namespace TimerModel
{
    class Report
    {

    }

    /*class Lap: IEquatable<Lap>
    {
        public string Pilot { get; set; }
        public string Mechanic { get; set; }
        public string ModelName { get; set; }
        public override string ToString()
        {
            return "П: " + Pilot + " М: " + Mechanic + " FM: " + ModelName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Team objAsPart = obj as Team;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return 0;
        }
        public bool Equals(Lap other)
        {
            if (other == null) return false;
            return (this.Pilot.Equals(other.Pilot));
        }
    }*/

    public class ListOfTeams
    {
        public byte[] Generate(List<Team> List)
        {
            var Package = new ExcelPackage();
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
