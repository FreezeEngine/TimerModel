using CompetitionOrganizer.Forms.Team_Managers;
using System;
using System.Windows.Forms;

namespace TimerModel.Forms
{
    public partial class Settings : Form
    {
        public bool SomethingGotUpdated = false;
        public Settings()
        {
            InitializeComponent();
            TopMost = true;

            Print.Checked = TimerSettings.PrintingEnabled;
            DoubleClickProtection.Checked = TimerSettings.DoubleClickProtectionEnabled;
            FileGeneration.Checked = TimerSettings.PrintFileGeneration;
        }

        private void TestModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DevGroupBox.Enabled = TestModeCheckBox.Checked;
        }

        private void Print_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.PrintingEnabled = Print.Checked;
        }

        private void DoubleClickProtection_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.DoubleClickProtectionEnabled = DoubleClickProtection.Checked;
        }

        private void FileGeneration_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.PrintFileGeneration = FileGeneration.Checked;
        }

        private void OpenCompetitionManager_Click(object sender, EventArgs e)
        {
            Hide();
            CompetitionManager CM = new CompetitionManager();
            CM.Show();
            CM.FormClosing += (a, s) => { Show(); };
            SomethingGotUpdated = true;
        }

        private void EditTeamSets_Click(object sender, EventArgs e)
        {
            Hide();
            TeamSetEditor TSE = new TeamSetEditor();
            TSE.Show();
            TSE.FormClosing += (a, s) => { Show(); };
            SomethingGotUpdated = true;
        }

        private void EndCompetition_Click(object sender, EventArgs e)
        {
            var EndDialog = MessageBox.Show("Завершить соревнование?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (EndDialog == DialogResult.Yes)
            {
                Hide();
                TimerSettings.Competition.Finish();
                Close();
            }
            
        }
    }
}
