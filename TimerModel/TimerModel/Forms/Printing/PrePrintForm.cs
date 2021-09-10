using System.Windows.Forms;
using TimerModel;

namespace CompetitionOrganizer.Forms.Printing
{
    public partial class PrePrintForm : Form
    {
        public PrePrintForm()
        {
            InitializeComponent();
            var T1 = TimerSettings.Competition.Teams.First;
            var T2 = TimerSettings.Competition.Teams.Second;
            var T3 = TimerSettings.Competition.Teams.Third;

            var T1E = TimerSettings.Competition.Teams.First.Enabled;
            var T2E = TimerSettings.Competition.Teams.First.Enabled;
            var T3E = TimerSettings.Competition.Teams.First.Enabled;

            var T1R = T1.CurrentRound;
            var T2R = T2.CurrentRound;
            var T3R = T3.CurrentRound;

            M1L1.Enabled = T1E;
            M1L2.Enabled = T1E;
            M1L3.Enabled = T1E;
            M1L4.Enabled = T1E;
            M1L5.Enabled = T1E;
            M1L6.Enabled = T1E;
            M1L7.Enabled = T1E;
            M1L8.Enabled = T1E;
            M1L9.Enabled = T1E;
            M1L10.Enabled = T1E;
            M1L11.Enabled = T1E;
            M1L12.Enabled = T1E;

            M2L1.Enabled = T2E;
            M2L2.Enabled = T2E;
            M2L3.Enabled = T2E;
            M2L4.Enabled = T2E;
            M2L5.Enabled = T2E;
            M2L6.Enabled = T2E;
            M2L7.Enabled = T2E;
            M2L8.Enabled = T2E;
            M2L9.Enabled = T2E;
            M2L10.Enabled = T2E;
            M2L11.Enabled = T2E;
            M2L12.Enabled = T2E;

            M3L1.Enabled = T3E;
            M3L2.Enabled = T3E;
            M3L3.Enabled = T3E;
            M3L4.Enabled = T3E;
            M3L5.Enabled = T3E;
            M3L6.Enabled = T3E;
            M3L7.Enabled = T3E;
            M3L8.Enabled = T3E;
            M3L9.Enabled = T3E;
            M3L10.Enabled = T3E;
            M3L11.Enabled = T3E;
            M3L12.Enabled = T3E;

            M1L1.Text = T1R.Laps[0].GetLapTime();
            M1L2.Text = T1R.Laps[1].GetLapTime();
            M1L3.Text = T1R.Laps[2].GetLapTime();
            M1L4.Text = T1R.Laps[3].GetLapTime();
            M1L5.Text = T1R.Laps[4].GetLapTime();
            M1L6.Text = T1R.Laps[5].GetLapTime();
            M1L7.Text = T1R.Laps.Count >= 7 ? T1R.Laps[6].GetLapTime() : "";
            M1L8.Text = T1R.Laps.Count >= 8 ? T1R.Laps[7].GetLapTime() : "";
            M1L9.Text = T1R.Laps.Count >= 9 ? T1R.Laps[8].GetLapTime() : "";
            M1L10.Text = T1R.Laps.Count >= 10 ? T1R.Laps[9].GetLapTime() : "";
            M1L11.Text = T1R.Laps.Count >= 11 ? T1R.Laps[10].GetLapTime() : "";
            M1L12.Text = T1R.Laps.Count == 12 ? T1R.Laps[11].GetLapTime() : "";

            M2L1.Text = T2R.Laps[0].GetLapTime();
            M2L2.Text = T2R.Laps[1].GetLapTime();
            M2L3.Text = T2R.Laps[2].GetLapTime();
            M2L4.Text = T2R.Laps[3].GetLapTime();
            M2L5.Text = T2R.Laps[4].GetLapTime();
            M2L6.Text = T2R.Laps[5].GetLapTime();
            M2L7.Text = T2R.Laps.Count >= 7 ? T2R.Laps[6].GetLapTime() : "";
            M2L8.Text = T2R.Laps.Count >= 8 ? T2R.Laps[7].GetLapTime() : "";
            M2L9.Text = T2R.Laps.Count >= 9 ? T2R.Laps[8].GetLapTime() : "";
            M2L10.Text = T2R.Laps.Count >= 10 ? T2R.Laps[9].GetLapTime() : "";
            M2L11.Text = T2R.Laps.Count >= 11 ? T2R.Laps[10].GetLapTime() : "";
            M2L12.Text = T2R.Laps.Count == 12 ? T2R.Laps[11].GetLapTime() : "";

            M3L1.Text = T3R.Laps[0].GetLapTime();
            M3L2.Text = T3R.Laps[1].GetLapTime();
            M3L3.Text = T3R.Laps[2].GetLapTime();
            M3L4.Text = T3R.Laps[3].GetLapTime();
            M3L5.Text = T3R.Laps[4].GetLapTime();
            M3L6.Text = T3R.Laps[5].GetLapTime();
            M3L7.Text = T3R.Laps.Count >= 7 ? T3R.Laps[6].GetLapTime() : "";
            M3L8.Text = T3R.Laps.Count >= 8 ? T3R.Laps[7].GetLapTime() : "";
            M3L9.Text = T3R.Laps.Count >= 9 ? T3R.Laps[8].GetLapTime() : "";
            M3L10.Text = T3R.Laps.Count >= 10 ? T3R.Laps[9].GetLapTime() : "";
            M3L11.Text = T3R.Laps.Count >= 11 ? T3R.Laps[10].GetLapTime() : "";
            M3L12.Text = T3R.Laps.Count == 12 ? T3R.Laps[11].GetLapTime() : "";

            UpdateData();

        }

        private void UpdateData()
        {
            var T1 = TimerSettings.Competition.Teams.First;
            var T2 = TimerSettings.Competition.Teams.Second;
            var T3 = TimerSettings.Competition.Teams.Third;

            var T1R = T1.CurrentRound;
            var T2R = T2.CurrentRound;
            var T3R = T3.CurrentRound;

            M1T.Text = T1.Enabled ? T1R.RoundFTime() : "Отключено";
            M2T.Text = T2.Enabled ? T2R.RoundFTime() : "Отключено";
            M3T.Text = T3.Enabled ? T3R.RoundFTime() : "Отключено";
        }
        private void Save_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void T_TextChanged(object sender, System.EventArgs e)
        {
            return;
            var T1 = TimerSettings.Competition.Teams.First;
            var T2 = TimerSettings.Competition.Teams.Second;
            var T3 = TimerSettings.Competition.Teams.Third;

            var T1E = TimerSettings.Competition.Teams.First.Enabled;
            var T2E = TimerSettings.Competition.Teams.First.Enabled;
            var T3E = TimerSettings.Competition.Teams.First.Enabled;

            var T1R = T1.CurrentRound;
            var T2R = T2.CurrentRound;
            var T3R = T3.CurrentRound;

            T1R.Laps[0].PreviousTime = new System.DateTime();
            M1L2.Text = T1R.Laps[1].GetLapTime();
            M1L3.Text = T1R.Laps[2].GetLapTime();
            M1L4.Text = T1R.Laps[3].GetLapTime();
            M1L5.Text = T1R.Laps[4].GetLapTime();
            M1L6.Text = T1R.Laps[5].GetLapTime();
            M1L7.Text = T1R.Laps.Count >= 7 ? T1R.Laps[6].GetLapTime() : "";
            M1L8.Text = T1R.Laps.Count >= 8 ? T1R.Laps[7].GetLapTime() : "";
            M1L9.Text = T1R.Laps.Count >= 9 ? T1R.Laps[8].GetLapTime() : "";
            M1L10.Text = T1R.Laps.Count >= 10 ? T1R.Laps[9].GetLapTime() : "";
            M1L11.Text = T1R.Laps.Count >= 11 ? T1R.Laps[10].GetLapTime() : "";
            M1L12.Text = T1R.Laps.Count == 12 ? T1R.Laps[11].GetLapTime() : "";

            M2L1.Text = T2R.Laps[0].GetLapTime();
            M2L2.Text = T2R.Laps[1].GetLapTime();
            M2L3.Text = T2R.Laps[2].GetLapTime();
            M2L4.Text = T2R.Laps[3].GetLapTime();
            M2L5.Text = T2R.Laps[4].GetLapTime();
            M2L6.Text = T2R.Laps[5].GetLapTime();
            M2L7.Text = T2R.Laps.Count >= 7 ? T2R.Laps[6].GetLapTime() : "";
            M2L8.Text = T2R.Laps.Count >= 8 ? T2R.Laps[7].GetLapTime() : "";
            M2L9.Text = T2R.Laps.Count >= 9 ? T2R.Laps[8].GetLapTime() : "";
            M2L10.Text = T2R.Laps.Count >= 10 ? T2R.Laps[9].GetLapTime() : "";
            M2L11.Text = T2R.Laps.Count >= 11 ? T2R.Laps[10].GetLapTime() : "";
            M2L12.Text = T2R.Laps.Count == 12 ? T2R.Laps[11].GetLapTime() : "";

            M3L1.Text = T3R.Laps[0].GetLapTime();
            M3L2.Text = T3R.Laps[1].GetLapTime();
            M3L3.Text = T3R.Laps[2].GetLapTime();
            M3L4.Text = T3R.Laps[3].GetLapTime();
            M3L5.Text = T3R.Laps[4].GetLapTime();
            M3L6.Text = T3R.Laps[5].GetLapTime();
            M3L7.Text = T3R.Laps.Count >= 7 ? T3R.Laps[6].GetLapTime() : "";
            M3L8.Text = T3R.Laps.Count >= 8 ? T3R.Laps[7].GetLapTime() : "";
            M3L9.Text = T3R.Laps.Count >= 9 ? T3R.Laps[8].GetLapTime() : "";
            M3L10.Text = T3R.Laps.Count >= 10 ? T3R.Laps[9].GetLapTime() : "";
            M3L11.Text = T3R.Laps.Count >= 11 ? T3R.Laps[10].GetLapTime() : "";
            M3L12.Text = T3R.Laps.Count == 12 ? T3R.Laps[11].GetLapTime() : "";
            UpdateData();
        }
    }
}
