using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TimerModel
{
    public partial class ExcelDataReadMode : Form
    {
        ExcelPackage ExcelFile;

        public ExcelDataReadMode(string FilePath)
        {
            InitializeComponent();
            Thread t = new Thread(new ThreadStart(()=> { ExcelFile = new ExcelPackage(new FileInfo(FilePath)); }));
            t.Start();
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            if (ExcelFile == null)
            {
                MessageBox.Show("Таблица еще загружается, повторите попытку");
                return;
            }
            int i = new int();
            int Shift = 0;
            if (mode1.Checked)
            {
                i = 1;
            } else if (mode2.Checked)
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
            while (true)
            {
                if (ExcelFile.Workbook.Worksheets[0].Cells[i, 1].Value == null)
                {
                    break;
                }
                var P = (Sheet.Cells[i, 1].Value != null) ? (Sheet.Cells[i, 1+ Shift].Value.ToString()) : (null);
                var M = (Sheet.Cells[i, 2].Value != null) ? (Sheet.Cells[i, 2+ Shift].Value.ToString()) : (null);
                var FM = (Sheet.Cells[i, 3].Value!=null)?(Sheet.Cells[i, 3+ Shift].Value.ToString()):(null);
                var TN = (Sheet.Cells[i, 3].Value != null) ? (Sheet.Cells[i, 4 + Shift].Value.ToString()) : (null);
                Teams.Add(new Team() { Pilot = P, Mechanic = M, ModelName = FM, TeamName = TN });
                i++;
            }
            if (Teams.Count != 0)
            {
                Hide();
                SetSettings MF = new SetSettings(Teams);
                MF.Closed += (s, a) => Close();
                MF.Show();
            }
            else
            {
                MessageBox.Show("Команды не найдены!");
            }
        }
    }
}
