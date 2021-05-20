using OfficeOpenXml;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using TimerModel.Objects.PrintMode;

namespace TimerModel.Objects.Reporting
{
    class RoundReport
    {

        public static void MakeReport()
        {
            int MaxLaps = Competition.Teams.MaxLaps();
            if (MaxLaps > 12)
            {
                AutoClosingMessageBox.Show("Количество кругов превысило 12, шаблоны не предназначены для печати больше 12 кругов", "Ошибка", 5000);
                return;
            }
            string FN = "";
            switch (MaxLaps)
            {
                case 12:
                    FN = "Шаблон печати 12 кругов.xlsx";
                    break;
                case 11:
                    FN = "Шаблон печати 11 кругов.xlsx";
                    break;
                default:
                    FN = "Шаблон печати.xlsx";
                    break;
            }
            var ExecutablePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var P = Path.Combine(ExecutablePath, "Templates/" + FN);
            var F = File.OpenRead(P);
            var Package = new ExcelPackage(F);
            //F.Close();
            var Workbook = Package.Workbook;
            ExcelWorksheet Sheet;

            switch (TimerSettings.PrintMode)
            {
                case PrintModes.Vertical:
                    Sheet = Workbook.Worksheets[1];
                    Workbook.Worksheets.Delete(0);
                    break;
                case PrintModes.Horizontal:
                    Sheet = Workbook.Worksheets[0];
                    Workbook.Worksheets.Delete(1);
                    break;
                default:
                    Sheet = Workbook.Worksheets[0];
                    break;
            }

            for (int p = 0; p < Workbook.Worksheets.Count; p++)
            {

                //Horizontal cycle
                for (int c = 1; c <= 26; c++)
                {
                    //Vertical cycle
                    for (int r = 1; r <= 50; r++)
                    {
                        var D = Sheet.Cells[r, c]?.Value;
                        if (D != null)
                        {
                            string DS = D.ToString();
                            if (DS.Length >= 3 && DS.Length <= 5)
                            {
                                if (DS[0] == 'M')
                                {
                                    Team Team = new Team();
                                    switch (DS[1])
                                    {
                                        case '1':
                                            if (!Competition.Teams.First.Enabled)
                                            {
                                                continue;
                                            }
                                            Team = Competition.Teams.First;
                                            break;
                                        case '2':
                                            if (!Competition.Teams.Second.Enabled)
                                            {
                                                continue;
                                            }
                                            Team = Competition.Teams.Second;
                                            break;
                                        case '3':
                                            if (!Competition.Teams.Third.Enabled)
                                            {
                                                continue;
                                            }
                                            Team = Competition.Teams.Third;
                                            break;
                                    }
                                    if (DS.Contains("FM"))
                                    {
                                        byte index = Convert.ToByte(DS[4].ToString());
                                        Sheet.Cells[r, c].Value = Team.CurrentRound.FlyMisses[index - 1].ToString();
                                        continue;
                                    }
                                    if (DS.Contains("L"))
                                    {
                                        byte index = Convert.ToByte(DS.Remove(0, 3));
                                        if (index >= Team.CurrentRound.Laps.Count)
                                        {
                                            continue;
                                        }

                                        Sheet.Cells[r, c].Value = Team.CurrentRound.Laps[index]?.ReportString();
                                        continue;
                                    }
                                    switch (DS.Remove(0, 2))
                                    {
                                        case "TN":
                                            Sheet.Cells[r, c].Value = Team.CurrentRoundNum + 1;
                                            break;
                                        case "MC":
                                            Sheet.Cells[r, c].Value = Team.CM.CompetingModel;
                                            break;
                                        case "P":
                                            Sheet.Cells[r, c].Value = Team.GetShortPilotName();
                                            break;
                                        case "M":
                                            Sheet.Cells[r, c].Value = Team.GetShortMechanicName();
                                            break;
                                        case "PTs":
                                            Sheet.Cells[r, c].Value = Team.CurrentRound.RoundPoints();
                                            break;
                                        case "T":
                                            Sheet.Cells[r, c].Value = Team.CurrentRound.RoundTime();
                                            break;
                                    }
                                    continue;
                                }
                            }
                        }
                    }
                }

                //Clearing
                for (int c = 1; c <= 26; c++)
                {
                    //Vertical cycle
                    for (int r = 1; r <= 50; r++)
                    {
                        var D = Sheet.Cells[r, c]?.Value;
                        if (D != null)
                        {
                            if (D.ToString().Length != 0)
                            {
                                if (D.ToString()[0] == 'M')
                                {
                                    Sheet.Cells[r, c].Value = "";
                                }
                            }
                        }
                    }
                }

                //if (Mode == PrintModes.Both)
                //{
                //    break;
                //}
            }


            //, DateTime.Now.ToString("dd.MM.yyyy")+"/"
            var SavingPath = Path.Combine(ExecutablePath, "RoundReports");

            if (!Directory.Exists(SavingPath))
            {
                Directory.CreateDirectory(SavingPath);
            }

            var SavingDir = Path.Combine(SavingPath, DateTime.Now.ToString("D") + "/");

            if (!Directory.Exists(SavingDir))
            {
                Directory.CreateDirectory(SavingDir);
            }

            var SavingFile = Path.Combine(SavingDir, DateTime.Now.ToString("H-mm-ss") + ".xlsx");

            var FileBytes = Package.GetAsByteArray();

            File.WriteAllBytes(SavingFile, FileBytes); //Enable

            F.Close();
            Package.Dispose();

            Print(SavingFile); //Enable

        }
        public static void Print(string PathToFile)
        {
            //FIX Excel duplication

            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            // Open the Workbook:
            // TimerSettings.Excel.Workbooks;
            Microsoft.Office.Interop.Excel.Workbooks wbs = Excel.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook wb = wbs.Open(
                PathToFile,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            wb.PrintOutEx();
            // Get the first worksheet.
            // (Excel uses base 1 indexing, not base 0.)
            /*
            for (byte c = 1; c <= wb.Worksheets.Count; c++)
            {
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[c];

                //wb.Worksheets.PrintOu

                // Print out 1 copy to the default printer:
                ws.PrintOut(
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //Marshal.FinalReleaseComObject(ws);
            }*/


            // Cleanup:

            GC.WaitForPendingFinalizers();

            wb.Close(0);
            wbs.Close();
           
            Marshal.FinalReleaseComObject(wb);
            Marshal.FinalReleaseComObject(wbs);
            Excel.Quit();
            //excelApp.Quit();
            //Marshal.FinalReleaseComObject(excelApp);
            GC.Collect();
        }


    }
}
