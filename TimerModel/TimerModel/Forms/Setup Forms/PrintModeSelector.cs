using CompetitionOrganizer.Forms.Printing;
using System;
using System.Windows.Forms;
using TimerModel.Objects.PrintMode;

namespace TimerModel.Forms.Setup_Forms
{
    public partial class PrintModeSelector : Form
    {
        public PrintModes PrintMode;
        public PrintModeSelector()
        {
            InitializeComponent();
            TopMost = true;
            switch (TimerSettings.PrintMode)
            {
                case PrintModes.Horizontal:
                    HorizontalPrint.Checked = true;
                    break;
                case PrintModes.Vertical:
                    VerticalPrint.Checked = true;
                    break;
                case PrintModes.Both:
                    PrintBoth.Checked = true;
                    break;
            }
        }

        private void RememberMode_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.NoPrePrintAsking = RememberMode.Checked;
        }

        private void PrintModeChanged(object sender, EventArgs e)
        {
            if (HorizontalPrint.Checked)
            {
                TimerSettings.PrintMode = PrintModes.Horizontal;
            }
            if (VerticalPrint.Checked)
            {
                TimerSettings.PrintMode = PrintModes.Vertical;
            }
            if (PrintBoth.Checked)
            {
                TimerSettings.PrintMode = PrintModes.Both;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
        }

        private void ReflyM1_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.Competition.Teams.CurrentModel.CurrentTeamset.First.CurrentRound.BadFinish = ReflyM1.Checked;
        }

        private void ReflyM2_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.Competition.Teams.CurrentModel.CurrentTeamset.Second.CurrentRound.BadFinish = ReflyM2.Checked;
        }

        private void ReflyM3_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.Competition.Teams.CurrentModel.CurrentTeamset.Third.CurrentRound.BadFinish = ReflyM3.Checked;
        }

        private void EditPrintData_Click(object sender, EventArgs e)
        {
            var PrePrintFrom1 = new PrePrintForm();
            PrePrintFrom1.Show();
            Hide();
            PrePrintFrom1.FormClosing += (a,s)=> { Show(); };
        }
    }
}
