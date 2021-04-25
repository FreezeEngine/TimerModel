using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TimerModel
{
    public partial class CompetitionReport : Form
    {
        private Competition Competition;
        public CompetitionReport(Competition Competition)
        {
            this.Competition = Competition;
            InitializeComponent();
            
        }

        private void SaveReport_Click(object sender, EventArgs e)
        {
            Competition.MainJudge = MainJudge.Text;
            Competition.LaunchSupervisor = LaunchSupervisor.Text;
            Competition.Scorekeeper = Scorekeeper.Text;

            Competition.Lines[0] = l1.Text;
            Competition.Lines[1] = l2.Text;
            Competition.Lines[2] = l3.Text;
            Competition.Lines[3] = l4.Text;

            Stream Stream;
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Title = "Сохранить отчет";
            SaveFile.InitialDirectory = @"C:\";
            SaveFile.Filter = "Таблица Excel (*.xlsx)|*.xlsx";
            SaveFile.FilterIndex = 0;
            SaveFile.RestoreDirectory = true;

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((Stream = SaveFile.OpenFile()) != null)
                    {
                        {
                            byte[] b = new RoundReport().Generate(Competition);
                            Stream.Write(b);
                            Stream.Close();
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
    }
}
