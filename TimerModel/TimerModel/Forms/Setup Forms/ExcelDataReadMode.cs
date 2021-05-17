using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TimerModel.Objects;

namespace TimerModel
{
    public partial class ExcelDataReadMode : Form
    {
        ExcelPackage ExcelFile;
        Thread Loader;
        List<Team> Teams = new List<Team>();
        private delegate void CompetitionHandler();
        private event CompetitionHandler onTeamsLoaded;
        private event CompetitionHandler onTeamsFailed;


        public ExcelDataReadMode(string FilePath)
        {
            InitializeComponent();
            Loader = new Thread(new ThreadStart(() => { var F = File.OpenRead(FilePath); ExcelFile = new ExcelPackage(F); }));
            Loader.IsBackground = true;
            Loader.Start();

            onTeamsLoaded += () =>
            {
                Continue.SetPropertyThreadSafe(() => this.Text, "Загружено " + Teams.Count + " команд");
                Continue.SetPropertyThreadSafe(() => Continue.Enabled, true);
                Continue.SetPropertyThreadSafe(() => Continue.Text, "Продолжить");
                //MessageBox.Show("Таблица обработана, нажмите \"Продолжить\"");
            };
            {

            };
            onTeamsFailed += () =>
            {
                Continue.SetPropertyThreadSafe(() => Continue.Enabled, true);
                MessageBox.Show("Команд не найдено!");
            };
        }
        private void Continue_Click(object sender, EventArgs e)
        {
            Continue.Enabled = false;
            UpdateTeams();
            if (Teams.Count != 0)
            {
                Hide();
                new Competition(Teams);
                SetSettings MF = new SetSettings();
                MF.Closed += (s, a) => Close();
                MF.Show();
            }

        }

        private void UsingStandartTemplate_CheckedChanged(object sender, EventArgs e)
        {
            //Update();
        }
        bool Updated = false;
        private void UpdateTeams()
        {
            Thread t = new Thread(new ThreadStart(() =>
            {
                if (Updated == true)
                {
                    return;
                }
                Updated = true;
                //AutoClosingMessageBox.Show("Загрузка таблиц", "Информация", 10000);
                while (ExcelFile == null)
                {
                    Thread.Sleep(100);
                }
                int i = new int();
                int Shift = new int();
                if (UsingStandartTemplate.Checked)
                {
                    i = 4;
                }
                else if (mode1.Checked)
                {
                    i = 1;
                }
                else if (mode2.Checked)
                {
                    i = 2;
                }
                else if (mode3.Checked)
                {
                    i = 2;
                    Shift = 1;
                }

                List<Team> Teams = new List<Team>();
                var Sheet = ExcelFile.Workbook.Worksheets[0];
                try
                {
                    while (true)
                    {
                        if (ExcelFile.Workbook.Worksheets[0].Cells[i, 1].Value == null | ExcelFile.Workbook.Worksheets[0].Cells[i, 2].Value == null)
                        {
                            break;
                        }
                        string P = null;
                        string M = null;
                        string FM = null;
                        string TN = null;
                        if (UsingStandartTemplate.Checked && Sheet.Cells[i, 1].Value.ToString() == "")
                        {
                            break;
                        }
                        switch (UsingStandartTemplate.Checked)
                        {
                            case true:
                                FM = Sheet.Cells[i, 2]?.Value?.ToString();
                                P = Sheet.Cells[i, 3].Value?.ToString() + " " + Sheet.Cells[i, 4].Value?.ToString() + " " + Sheet.Cells[i, 5].Value?.ToString();
                                M = Sheet.Cells[i, 6].Value?.ToString() + " " + Sheet.Cells[i, 7].Value?.ToString() + " " + Sheet.Cells[i, 8].Value?.ToString();
                                TN = Sheet.Cells[i, 9].Value?.ToString();
                                break;
                            case false:
                                P = Sheet.Cells[i, 1 + Shift].Value?.ToString();
                                M = Sheet.Cells[i, 2 + Shift].Value?.ToString();
                                FM = Sheet.Cells[i, 3 + Shift].Value?.ToString();
                                TN = Sheet.Cells[i, 4 + Shift].Value?.ToString();
                                break;
                        }
                        if (i == 50)
                        {
                            break;
                        }
                        Teams.Add(new Team() { Pilot = P, Mechanic = M, ModelName = FM, TeamName = TN });
                        i++;
                    }
                }
                catch
                {
                    onTeamsFailed();
                }
                if (Teams.Count != 0)
                {
                    ExcelFile.Dispose();
                    GC.Collect();
                    this.Teams = Teams;
                    onTeamsLoaded();
                }
                else
                {
                    onTeamsFailed();
                }
            }));
            t.IsBackground = true;
            t.Start();
        }
    }
}
