using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

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

    class RoundReport
    {
        public string MainReferee  { get; set; }
        public string HeadOfAStart { get; set; }
        public string Secretary { get; set; }

        public byte[] Generate(Competition Competition)
        {
            //List<FlyModel> List

            var Package = new ExcelPackage();
            var Sheet = Package.Workbook.Worksheets.Add("Отчёт");

            Sheet.PrinterSettings.Orientation = eOrientation.Landscape;

            Sheet.PrinterSettings.LeftMargin = 0.39370078740157483M;
            Sheet.PrinterSettings.RightMargin = 0.39370078740157483M;

            Sheet.PrinterSettings.TopMargin = 0.98425196850393704M;
            Sheet.PrinterSettings.BottomMargin = 0.98425196850393704M;
            Sheet.PrinterSettings.HeaderMargin = 0.51181102362204722M;
            Sheet.PrinterSettings.FooterMargin = 0.51181102362204722M;

            Sheet.PrinterSettings.FitToHeight = 1;
            Sheet.PrinterSettings.FitToWidth = 1;

            Sheet.PrinterSettings.FitToPage = true;

            Sheet.PrinterSettings.PaperSize = ePaperSize.A4;

            Sheet.PrinterSettings.HorizontalCentered = true;
            Sheet.PrinterSettings.VerticalCentered = true;

            int tableShift = 1;

            Sheet.Column(tableShift).Width = 5;
            Sheet.Column(tableShift+1).Width = 22;
            Sheet.Column(tableShift+2).Width = 20;

            Sheet.Row(1).Height = 27.75;
            Sheet.Row(2).Height = 42;
            Sheet.Row(3).Height = 26.25;
            Sheet.Row(4).Height = 18.75;
            Sheet.Row(5).Height = 18.75;
            Sheet.Row(6).Height = 18.75;
            Sheet.Row(7).Height = 18.75;
            Sheet.Row(8).Height = 18.75;
            Sheet.Row(9).Height = 15.75;
            
            int s = tableShift+3;
            int teamsCount = Competition.Teams.Count;
            int i = 0;
            int b = 0;
            int TableStartPoint = 8;
            int TableBorder;
            int t = 10;

            for (; i < TimerSettings.RoundCount; i++)
            {
                TableBorder = s + i; //up to sum
                Sheet.Column(s+i).Width = 8;
                Sheet.Column(s+1+i).Width = 4;
                Sheet.Cells[TableStartPoint + 1, TableBorder, TableStartPoint + 1, s + 1 + i].Merge = true;
                Sheet.Cells[TableStartPoint + 1, TableBorder].Style.Font.Bold = true;
                Sheet.Cells[TableStartPoint + 1, TableBorder].Style.Font.Size = 12;

                for (int c = 0; c < teamsCount; c++)
                {
                    Sheet.Cells[9 + c + c + 2, TableBorder, 9 + c + c + 2, s + 1 + i].Merge = true;
                    Sheet.Cells[9 + c + c + 2, TableBorder].Value = Math.Round(Competition.Teams.GetTeams()[c].Rounds[i].TotalPoints, 2);

                    Sheet.Cells[9 + c + c + 1, TableBorder].Value = (Competition.Teams.GetTeams()[c].Rounds[i].TotalPoints != 200)?(Competition.Teams.GetTeams()[c].Rounds[i].Time.ToString(@"mm\,ss\,ff")):("0");
                    Sheet.Cells[9 + c + c + 1, TableBorder+1].Value = Competition.Teams.GetTeams()[c].Rounds[i].TotalFlyMisses();
                }
                Sheet.Cells[9, TableBorder].Value = i + 1;

                Sheet.Cells[9, TableBorder].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells[9, TableBorder].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                s++;
            }

            int SUMCol = s + i;

            TableBorder = SUMCol + 1; //up to place

            int TeamsEndRow = t + ((teamsCount * 2) - 1);

            for (; b < teamsCount; b++)
            {
                int TeamRowStart = t + b * 2;

                Sheet.Cells[TeamRowStart, tableShift, TeamRowStart + 1, tableShift].Merge = true;

                Sheet.Cells[TeamRowStart, tableShift + 2, TeamRowStart + 1, tableShift + 2].Merge = true;

                Sheet.Cells[TeamRowStart, tableShift + 2, TeamRowStart + 1, tableShift + 2].Merge = true;

                Sheet.Cells[TeamRowStart, tableShift, TeamRowStart + 1, tableShift].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                Sheet.Cells[TeamRowStart, tableShift, TeamRowStart + 1, tableShift].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                Sheet.Cells[TeamRowStart, tableShift].Value = b + 1;
                Sheet.Cells[TeamRowStart, tableShift + 1].Value = Competition.Teams.GetTeams()[b].Pilot;
                Sheet.Cells[TeamRowStart+1, tableShift + 1].Value = Competition.Teams.GetTeams()[b].Mechanic;
                Sheet.Cells[TeamRowStart, tableShift + 2].Value = Competition.Teams.GetTeams()[b].TeamName;
                //Sheet.Cells[TeamRowStart, tableShift + 2].AutoFitColumns();

                Sheet.Cells[TeamRowStart, s+i, TeamRowStart + 1, s+i].Merge = true;
                var FROM = Sheet.Cells[TeamRowStart + 1, tableShift + 3].Address;
                var TO = Sheet.Cells[TeamRowStart + 1, TableBorder - 2].Address;
                Sheet.Cells[TeamRowStart, SUMCol].Formula = "SUM(" + FROM + ":" + TO + ")-LARGE(" + FROM + ":" + TO + ",1)";
                Sheet.Cells[TeamRowStart, SUMCol].Style.Font.Size = 10;
                Sheet.Cells[TeamRowStart, SUMCol].Style.Font.Bold = true;

                var CurrentPlace = Sheet.Cells[TeamRowStart, SUMCol].Address;
                FROM = Sheet.Cells[t, SUMCol].Address;
                TO = Sheet.Cells[TeamsEndRow, SUMCol].Address;
                Sheet.Cells[TeamRowStart, TableBorder].Formula = "RANK(" + CurrentPlace + "," + FROM + ":" + TO + ",1)";
                Sheet.Cells[TeamRowStart, TableBorder].Style.Font.Bold = true;
                Sheet.Cells[TeamRowStart, TableBorder].Style.Font.Size = 14;

                Sheet.Cells[TeamRowStart, TableBorder, TeamRowStart + 1, TableBorder].Merge = true;
            }
            var Table = Sheet.Cells[TableStartPoint, tableShift, TeamsEndRow, TableBorder];
            Table.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            Table.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            Table.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            Table.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            Sheet.Cells[TableStartPoint, tableShift + 2, TeamsEndRow, TableBorder].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            Sheet.Cells[TableStartPoint, tableShift + 2, TeamsEndRow, TableBorder].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            Sheet.Column(SUMCol).Width = 15.57;
            Sheet.Column(TableBorder).Width = 24.14;
            Sheet.Cells[1, tableShift, 1, 8].Merge = true;

            Sheet.Cells[1, tableShift].Value = "Главный судья: ";

            Sheet.Cells[3, tableShift, 3, TableBorder].Merge = true; //ПРОТОКОЛ...
            Sheet.Cells[3, tableShift, 6, TableBorder].Style.Font.Size = 20;

            Sheet.Cells[3, tableShift].Value = "ПРОТОКОЛ";
            Sheet.Cells[4, tableShift].Value = "соревнований по авиамодельному спорту";

            Sheet.Cells[TableStartPoint, tableShift+3].Value = "Туры";
            Sheet.Cells[TableStartPoint, tableShift + 3].Style.Font.Bold = true;
            Sheet.Cells[TableStartPoint, tableShift + 3].Style.Font.Size = 14;

            Sheet.Cells[TableStartPoint, tableShift].Value = "№";
            Sheet.Cells[TableStartPoint, tableShift].Style.Font.Bold = true;
            Sheet.Cells[TableStartPoint, tableShift].Style.Font.Size = 14;

            Sheet.Cells[TableStartPoint, tableShift+1].Value = "Экипаж";
            Sheet.Cells[TableStartPoint, tableShift + 1].Style.Font.Bold = true;
            Sheet.Cells[TableStartPoint, tableShift + 1].Style.Font.Size = 14;

            Sheet.Cells[TableStartPoint, tableShift+2].Value = "Команда";
            Sheet.Cells[TableStartPoint, tableShift + 2].Style.Font.Bold = true;
            Sheet.Cells[TableStartPoint, tableShift + 2].Style.Font.Size = 14;

            Sheet.Cells[TableStartPoint, TableBorder-1].Value = "Сумма";
            Sheet.Cells[TableStartPoint, TableBorder - 1].Style.Font.Bold = true;
            Sheet.Cells[TableStartPoint, TableBorder - 1].Style.Font.Size = 14;

            Sheet.Cells[TableStartPoint, TableBorder].Value = "Место";
            Sheet.Cells[TableStartPoint, TableBorder].Style.Font.Bold = true;
            Sheet.Cells[TableStartPoint, TableBorder].Style.Font.Size = 14;

            Sheet.Cells[4, tableShift, 4, TableBorder].Merge = true;
            Sheet.Cells[5, tableShift, 5, TableBorder].Merge = true;
            Sheet.Cells[6, tableShift, 6, TableBorder].Merge = true;

            Sheet.Cells[4, tableShift, 6, TableBorder].Style.Font.Size = 14;

            Sheet.Cells[3, tableShift, 9, TableBorder].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            Sheet.Cells[3, tableShift, 9, TableBorder].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            Sheet.Cells[TableStartPoint, tableShift+3, TableStartPoint, TableBorder - 2].Merge = true;

            Sheet.Cells[TableStartPoint, TableBorder-1, 9, TableBorder-1].Merge = true;
            Sheet.Cells[TableStartPoint, TableBorder, 9, TableBorder].Merge = true;


            Sheet.Cells[TableStartPoint, tableShift, 9, tableShift].Merge = true;
            Sheet.Cells[TableStartPoint, tableShift+1, 9, tableShift+1].Merge = true;
            Sheet.Cells[TableStartPoint, tableShift+2, 9, tableShift+2].Merge = true;
            //foreach (FlyModel Model in List)
            //{
            //Sheet.Cells[i, 1].Value = Model.Pilot;
            //Sheet.Cells[i, tableShift].Value = Model.Mechanic;
            //Sheet.Cells[i, 3].Value = Model.ModelName;
            //i++;
            //}
            return Package.GetAsByteArray();
        }
    }

    public class ListOfTeams
    {
        public byte[] Generate(List<Team> List)
        {
            var Package = new ExcelPackage();
            var Sheet = Package.Workbook.Worksheets.Add("Команды");
            int i = 1;

            foreach(Team team in List)
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
