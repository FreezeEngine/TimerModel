using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;

namespace TimerModel.Objects
{
    public class FinalReport
    {
        public static byte[] Generate(List<ReportItem> Reports)
        {
            var Package = new ExcelPackage();
            foreach (var Report in Reports)
            {
                var Sheet = Package.Workbook.Worksheets.Add(Report.CompetingModel.CompetingModel);

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
                Sheet.Column(tableShift + 1).Width = 22;
                Sheet.Column(tableShift + 2).Width = 20;

                Sheet.Row(1).Height = 27.75;
                Sheet.Row(2).Height = 42;
                Sheet.Row(3).Height = 26.25;
                Sheet.Row(4).Height = 18.75;
                Sheet.Row(5).Height = 18.75;
                Sheet.Row(6).Height = 18.75;
                Sheet.Row(7).Height = 18.75;
                Sheet.Row(8).Height = 18.75;
                Sheet.Row(9).Height = 15.75;

                int s = tableShift + 3;
                int teamsCount = Report.CompetingModel.Teams.Count;
                int i = 0;
                int b = 0;
                int TableStartPoint = 8;
                int TableBorder;
                int t = 10;

                for (; i < Report.CompetingModel.RoundsForThisClass; i++)
                {
                    TableBorder = s + i; //up to sum
                    Sheet.Column(s + i).Width = 8;
                    Sheet.Column(s + 1 + i).Width = 4;
                    Sheet.Cells[TableStartPoint + 1, TableBorder, TableStartPoint + 1, s + 1 + i].Merge = true;
                    Sheet.Cells[TableStartPoint + 1, TableBorder].Style.Font.Bold = true;
                    Sheet.Cells[TableStartPoint + 1, TableBorder].Style.Font.Size = 12;

                    for (int c = 0; c < teamsCount; c++)
                    {
                        Sheet.Cells[9 + c + c + 2, TableBorder, 9 + c + c + 2, s + 1 + i].Merge = true;
                        Sheet.Cells[9 + c + c + 2, TableBorder].Value = Math.Round(Report.CompetingModel.Teams[c].Rounds[i].TotalPoints, 2);

                        Sheet.Cells[9 + c + c + 1, TableBorder].Value = (Report.CompetingModel.Teams[c].Rounds[i].TotalPoints != 200) ? (Report.CompetingModel.Teams[c].Rounds[i].Time.ToString(@"mm\,ss\,ff")) : ("0");
                        byte T = Report.CompetingModel.Teams[c].Rounds[i].TotalFlyMisses();
                        string B;
                        if (T == 0)
                        {
                            B = "";
                        }
                        else
                        {
                            B = T.ToString();
                        }
                        Sheet.Cells[9 + c + c + 1, TableBorder + 1].Value = B;
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
                    Sheet.Cells[TeamRowStart, tableShift + 1].Value = Report.CompetingModel.Teams[b].GetShortPilotName();
                    Sheet.Cells[TeamRowStart + 1, tableShift + 1].Value = Report.CompetingModel.Teams[b].GetShortPilotName();
                    Sheet.Cells[TeamRowStart, tableShift + 2].Value = Report.CompetingModel.Teams[b].TeamName;
                    //Sheet.Cells[TeamRowStart, tableShift + 2].AutoFitColumns();

                    Sheet.Cells[TeamRowStart, s + i, TeamRowStart + 1, s + i].Merge = true;
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

                Sheet.Cells[1, tableShift].Value = "Главный судья: " + Report.MainJudge;
                Sheet.Cells[1, tableShift].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                Sheet.Cells[1, tableShift].Style.Font.Size = 14;
                Sheet.Cells[1, tableShift].Style.Font.Bold = true;

                Sheet.Column(TeamsEndRow + 1).Width = 27;
                Sheet.Column(TeamsEndRow + 2).Width = 40;
                Sheet.Cells[TeamsEndRow + 3, 1, TeamsEndRow + 3, TableBorder].Merge = true;

                Sheet.Cells[TeamsEndRow + 3, 1].Value = "Начальник старта: " + Report.LaunchSupervisor + "                                             Секретарь старта: " + Report.Scorekeeper;
                Sheet.Cells[TeamsEndRow + 3, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                Sheet.Cells[TeamsEndRow + 3, 1].Style.Font.Size = 14;
                Sheet.Cells[TeamsEndRow + 3, 1].Style.Font.Bold = true;
                //1Sheet.Cells[TeamsEndRow + 3, 1, TeamsEndRow + 3, TableBorder + 1].Merge = true;


                Sheet.Cells[3, tableShift, 3, TableBorder].Merge = true; //ПРОТОКОЛ...
                Sheet.Cells[3, tableShift, 6, TableBorder].Style.Font.Size = 20;

                Sheet.Cells[3, tableShift].Value = Report.Lines[0];
                Sheet.Cells[4, tableShift].Value = Report.Lines[1];
                Sheet.Cells[5, tableShift].Value = Report.Lines[2];
                Sheet.Cells[6, tableShift].Value = Report.Lines[3];

                Sheet.Cells[TableStartPoint, tableShift + 3].Value = "Туры";
                Sheet.Cells[TableStartPoint, tableShift + 3].Style.Font.Bold = true;
                Sheet.Cells[TableStartPoint, tableShift + 3].Style.Font.Size = 14;

                Sheet.Cells[TableStartPoint, tableShift].Value = "№";
                Sheet.Cells[TableStartPoint, tableShift].Style.Font.Bold = true;
                Sheet.Cells[TableStartPoint, tableShift].Style.Font.Size = 14;

                Sheet.Cells[TableStartPoint, tableShift + 1].Value = "Экипаж";
                Sheet.Cells[TableStartPoint, tableShift + 1].Style.Font.Bold = true;
                Sheet.Cells[TableStartPoint, tableShift + 1].Style.Font.Size = 14;

                Sheet.Cells[TableStartPoint, tableShift + 2].Value = "Команда";
                Sheet.Cells[TableStartPoint, tableShift + 2].Style.Font.Bold = true;
                Sheet.Cells[TableStartPoint, tableShift + 2].Style.Font.Size = 14;

                Sheet.Cells[TableStartPoint, TableBorder - 1].Value = "Сумма";
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

                Sheet.Cells[TableStartPoint, tableShift + 3, TableStartPoint, TableBorder - 2].Merge = true;

                Sheet.Cells[TableStartPoint, TableBorder - 1, 9, TableBorder - 1].Merge = true;
                Sheet.Cells[TableStartPoint, TableBorder, 9, TableBorder].Merge = true;


                Sheet.Cells[TableStartPoint, tableShift, 9, tableShift].Merge = true;
                Sheet.Cells[TableStartPoint, tableShift + 1, 9, tableShift + 1].Merge = true;
                Sheet.Cells[TableStartPoint, tableShift + 2, 9, tableShift + 2].Merge = true;
            }
            var data = Package.GetAsByteArray();
            Package.Dispose();
            return data;
        }
        public void Save()
        {

        }
    }
}
