using System;
using System.Windows.Forms;

namespace TimerModel
{
    public partial class SetSettings : Form
    {
        public SetSettings()
        {
            InitializeComponent();

            UpdateFlyModelsList();

            RoundNum.Maximum = Rules.MaxRounds;
            LapsAmount.Maximum = Rules.MaxLaps;

            RoundNum.Minimum = Rules.MinRounds;
            LapsAmount.Minimum = Rules.MinLaps;

            //RoundNum.Value = TimerSettings.RoundCount;
            //LapsAmount.Value = TimerSettings.LapCount;
        }
        private void UpdateFlyModelsList()
        {
            FlyModelsList.Items.Clear();
            FlyModelsList.Text = null;
            FlyModelsList.Items.AddRange(Competition.Teams.TeamClumps?.ToArray());
            if (Competition.Teams.TeamClumps.Count != 0)
            {
                FlyModelsList.SelectedIndex = 0;
            }
            else
            {
                FlyModelsList.SelectedIndex = -1;
                FlyModelsList.Text = "Нет моделей";
            }
        }
        private void Continue_Click(object sender, EventArgs e)
        {
            Hide();
            ChangeTeamSeparationMode ChoseMode = new ChangeTeamSeparationMode();
            ChoseMode.Closed += (s, a) => Close();
            ChoseMode.Show();
        }

        private void RoundNum_ValueChanged(object sender, EventArgs e)
        {
            //TimerSettings.RoundCount = (byte)RoundNum.Value;
            Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].SetRoundsCount((int)RoundNum.Value);
        }

        private void LapAmount_ValueChanged(object sender, EventArgs e)
        {
            //TimerSettings.LapCount = (byte)LapsAmount.Value;
            Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].LapsCount = (int)LapsAmount.Value;
        }

        private void CMList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RoundNum.Value = Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].RoundsForThisClass;
            LapsAmount.Value = Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].LapsCount;
        }
    }
}
