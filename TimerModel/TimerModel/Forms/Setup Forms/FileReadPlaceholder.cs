using CompetitionOrganizer.Objects;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TimerModel.Objects;

namespace TimerModel
{
    public partial class FileReadPlaceholder : Form
    {
        ExcelPackage ExcelFile;
        Thread Loader;
        List<Team> Teams = new List<Team>();
        private delegate void CompetitionHandler();
        private event CompetitionHandler onTeamsLoaded;
        private event CompetitionHandler onTeamsFailed;


        public FileReadPlaceholder(string FilePath)
        {
            InitializeComponent();
            TopMost = true;
            Loader = new Thread(new ThreadStart(() => { var F = File.OpenRead(FilePath); ExcelFile = new ExcelPackage(F); UpdateTeams(); }));
            Loader.IsBackground = true;
            Loader.Start();

            onTeamsLoaded += () =>
            {
                if (Teams.Count != 0)
                {
                    //TimerSettings.ResetCompetition();
                    TimerSettings.Competition = new Competition(Teams);
                    ShowHideForm(this, false);
                    Invoke((MethodInvoker)delegate ()
                    {
                        SetSettings MF = new SetSettings();
                        MF.Closed += (s, a) => Close();
                        MF.Show();
                    });
                }
            };
            {

            };
            onTeamsFailed += () =>
            {
                LoadingStatusLabel.SetPropertyThreadSafe(() => LoadingStatusLabel.Text, "Ошибка загрузки!");
                MessageBox.Show("Команд не найдено!");
                Invoke((MethodInvoker)delegate ()
                {
                    Close();
                });
            };
        }
        static void ShowHideForm(Form form, bool show /* otherwise hide */)
        {
            if (form.InvokeRequired)
            {
                form.Invoke(new Action<Form, bool>((formInstance, isShow) =>
                {
                    if (isShow)
                        formInstance.Show();
                    else
                        formInstance.Hide();
                }), form, show);
            }
            else
            {
                if (show)
                    form.Show();
                else
                    form.Hide();
            } //if
        } //ShowHideForm

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
                byte i = 4;

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
                        if (Sheet.Cells[i, 1].Value.ToString() == "")
                        {
                            break;
                        }

                        FM = Sheet.Cells[i, 2]?.Value?.ToString();
                        P = Sheet.Cells[i, 3].Value?.ToString() + " " + Sheet.Cells[i, 4].Value?.ToString() + " " + Sheet.Cells[i, 5].Value?.ToString();
                        M = Sheet.Cells[i, 6].Value?.ToString() + " " + Sheet.Cells[i, 7].Value?.ToString() + " " + Sheet.Cells[i, 8].Value?.ToString();
                        TN = Sheet.Cells[i, 9].Value?.ToString();

                        if (i == 104) //Max competitors + team containless lines
                        {
                            break;
                        }
                        if (P?.Length < 3)
                        {
                            P = null;
                        }
                        if (M?.Length < 3)
                        {
                            M = null;
                        }
                        Teams.Add(new Team(true) { Pilot = new Participant(P), Mechanic = new Participant(M), ModelName = FM, TeamName = TN });
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
