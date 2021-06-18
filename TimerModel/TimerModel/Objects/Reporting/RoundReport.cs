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
            if (!TimerSettings.PrintFileGeneration)
            {
                return;
            }
            int MaxLaps = TimerSettings.Competition.Teams.MaxLaps();
            if (MaxLaps > 12)
            {
                AutoClosingMessageBox.Show("Количество кругов превысило 12, шаблоны не предназначены для печати больше 12 кругов", "Ошибка", 5000);
                return;
            }
            string FN = MaxLaps switch
            {
                12 => "Шаблон печати 12 кругов.xlsx",
                11 => "Шаблон печати 11 кругов.xlsx",
                _ => "Шаблон печати.xlsx",
            };
            var ExecutablePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var P = Path.Combine(ExecutablePath, "Шаблоны/" + FN);
            var F = File.OpenRead(P);
            var Package = new ExcelPackage(F);
            var Workbook = Package.Workbook;
            ExcelWorksheet Sheet;

            switch (TimerSettings.PrintMode)
            {
                case PrintModes.Vertical:
                    Workbook.Worksheets.Delete(0);
                    break;
                case PrintModes.Horizontal:
                    Workbook.Worksheets.Delete(1);
                    break;
                default:
                    break;
            }

            for (int p = 0; p < Workbook.Worksheets.Count; p++)
            {
                Sheet = Workbook.Worksheets[p];
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
                                    Team Team = new Team(false);
                                    switch (DS[1])
                                    {
                                        case '1':
                                            if (!TimerSettings.Competition.Teams.First.Enabled)
                                            {
                                                continue;
                                            }
                                            Team = TimerSettings.Competition.Teams.First;
                                            break;
                                        case '2':
                                            if (!TimerSettings.Competition.Teams.Second.Enabled)
                                            {
                                                continue;
                                            }
                                            Team = TimerSettings.Competition.Teams.Second;
                                            break;
                                        case '3':
                                            if (!TimerSettings.Competition.Teams.Third.Enabled)
                                            {
                                                continue;
                                            }
                                            Team = TimerSettings.Competition.Teams.Third;
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

                                        Sheet.Cells[r, c].Value = Team.CurrentRound.Laps[index]?.GetLapTime();
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
                                            Sheet.Cells[r, c].Value = Team.Pilot.ShortenName();
                                            break;
                                        case "M":
                                            Sheet.Cells[r, c].Value = Team.Mechanic.ShortenName();
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
                //Horizontal cycle
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
            }

            var SavingPath = Path.Combine(TimerSettings.CurrentProjectFolder, "Отчеты");

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

            Print(SavingFile);
            /*
            if (TimerSettings.PrintingEnabled)
            {
                var PrintDialog = MessageBox.Show("Печать завершена успешно?", "Проверка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (PrintDialog == DialogResult.Yes)
                {
                    Print(SavingFile);
                    return;
                }
            }*/

        }
        //FIX Excel duplication

        public static void Print(string PathToFile)
        {
            if (!TimerSettings.PrintingEnabled)
                return;
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks wbs = Excel.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook wb = wbs.Open(
                PathToFile,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            if (TimerSettings.PrintMode == PrintModes.Both)
            {
                wb.PrintOutEx(1, 2);
            }
            else
            {
                wb.PrintOutEx(1, 1);
            }

            GC.WaitForPendingFinalizers();
            wb.Close(0);
            Marshal.FinalReleaseComObject(wb);
            wbs.Close();
            Marshal.FinalReleaseComObject(wbs);
            Excel.Quit();
            Marshal.FinalReleaseComObject(Excel);
            GC.Collect();
        }
    }
}
