using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TimerModel.Objects;

namespace TimerModel.Forms
{
    public partial class ReportManager : Form
    {
        List<ReportItem> Reports = new List<ReportItem>();
        public ReportManager()
        {
            InitializeComponent();
            TopMost = true;

            MainJudge.Text = TimerSettings.Container.MainJudge;
            LaunchSupervisor.Text = TimerSettings.Container.LaunchSupervisor;
            Scorekeeper.Text = TimerSettings.Container.Scorekeeper;

            LoadReports();
        }

        private void LoadReports()
        {
            Reports.Clear();
            foreach (var CM in TimerSettings.Competition.Teams.TeamClumps)
            {
                Reports.Add(new ReportItem(CM));
            }
            if (Reports.Count == 0)
            {
                MessageBox.Show("Нет данных для отчета");
                Close();
            }
            ListOfReports.Items.Clear();
            ListOfReports.Items.AddRange(Reports.ToArray());
            ListOfReports.SelectedIndex = 0;
        }

        public object MesageBox { get; private set; }

        private void ListOfReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateData = false;
            var Report = (ReportItem)ListOfReports.SelectedItem;

            l1.Text = Report.CompetingModel.Lines[0];
            l2.Text = Report.CompetingModel.Lines[1];
            l3.Text = Report.CompetingModel.Lines[2];
            l4.Text = Report.CompetingModel.Lines[3];

            UpdateData = true;
        }
        private void SaveFile(bool Combined = false)
        {
            Stream stream;
            SaveFileDialog SaveFile = new SaveFileDialog
            {
                Title = "Сохранить отчет",
                InitialDirectory = @"C:\",
                Filter = "Таблица Excel (*.xlsx)|*.xlsx",
                FilterIndex = 0,
                RestoreDirectory = true
            };

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = SaveFile.OpenFile()) != null)
                    {
                        {
                            if (Combined)
                            {
                                TimerSettings.Competition = TimerSettings.Container.GetCombined();
                                LoadReports();
                            }
                            byte[] b = FinalReport.Generate(Reports);
                            stream.Write(b);
                            stream.Close();
                        }
                    }
                }
                catch (Exception ED)
                {
                    MessageBox.Show("Невозможно получть доступ к файлу, возможно он занят другим приложением. Ошибка: " + ED.Message + " Стек вызовов: " + ED.StackTrace);
                }

            }
            Close();
        }
        private void SaveReport_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
        bool UpdateData = true;
        private void MainJudge_TextChanged(object sender, EventArgs e)
        {
            if (UpdateData)
            {
                TimerSettings.Container.MainJudge = MainJudge.Text;
            }
        }

        private void LaunchSupervisor_TextChanged(object sender, EventArgs e)
        {
            if (UpdateData)
            {
                TimerSettings.Container.MainJudge = LaunchSupervisor.Text;
            }
        }

        private void Scorekeeper_TextChanged(object sender, EventArgs e)
        {
            if (UpdateData)
            {
                TimerSettings.Container.MainJudge = Scorekeeper.Text;
            }
        }
        private void Lines_TextChanged(object sender, EventArgs e)
        {
            if (UpdateData)
            {
                Reports[ListOfReports.SelectedIndex].CompetingModel.Lines[0] = l1.Text;
                Reports[ListOfReports.SelectedIndex].CompetingModel.Lines[1] = l2.Text;
                Reports[ListOfReports.SelectedIndex].CompetingModel.Lines[2] = l3.Text;
                Reports[ListOfReports.SelectedIndex].CompetingModel.Lines[3] = l4.Text;
            }
        }

        private void ReportManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void SaveCompiledReport_Click(object sender, EventArgs e)
        {
            SaveFile(true);
        }

        private void ReportManager_Load(object sender, EventArgs e)
        {

        }
    }
}
