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
            foreach (var CM in Competition.Teams.TeamClumps)
            {
                Reports.Add(new ReportItem(CM));
            }
            if (Reports.Count == 0)
            {
                MessageBox.Show("Нет данных для отчета");
                Close();
            }
            ListOfReports.Items.AddRange(Reports.ToArray());
            ListOfReports.SelectedIndex = 0;
        }

        public object MesageBox { get; private set; }

        private void ListOfReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            Update = false;
            var Report = (ReportItem)ListOfReports.SelectedItem;
            l1.Text = Report.Lines[0];
            l2.Text = Report.Lines[1];
            l3.Text = Report.Lines[2];
            l4.Text = Report.Lines[3];

            MainJudge.Text = Report.MainJudge;
            LaunchSupervisor.Text = Report.LaunchSupervisor;
            Scorekeeper.Text = Report.Scorekeeper;
            Update = true;
        }

        private void SaveReport_Click(object sender, EventArgs e)
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
        bool Update = true;
        private void MainJudge_TextChanged(object sender, EventArgs e)
        {
            if (Update)
            {
                Reports[ListOfReports.SelectedIndex].MainJudge = MainJudge.Text;
            }
        }

        private void LaunchSupervisor_TextChanged(object sender, EventArgs e)
        {
            if (Update)
            {
                Reports[ListOfReports.SelectedIndex].LaunchSupervisor = LaunchSupervisor.Text;
            }
        }

        private void Scorekeeper_TextChanged(object sender, EventArgs e)
        {
            if (Update)
            {
                Reports[ListOfReports.SelectedIndex].Scorekeeper = Scorekeeper.Text;
            }
        }
        private void Lines_TextChanged(object sender, EventArgs e)
        {
            if (Update)
            {
                Reports[ListOfReports.SelectedIndex].Lines[0] = l1.Text;
                Reports[ListOfReports.SelectedIndex].Lines[1] = l2.Text;
                Reports[ListOfReports.SelectedIndex].Lines[2] = l3.Text;
                Reports[ListOfReports.SelectedIndex].Lines[3] = l4.Text;
            }
        }

        private void ReportManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
