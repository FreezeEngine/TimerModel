using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TimerModel
{
    public partial class SetSettings : Form
    {
        private List<Team> Team;
        public SetSettings(List<Team> Team)
        {
            InitializeComponent();

            RoundNum.Maximum = Rules.MaxRounds;
            LapAmount.Maximum = Rules.MaxLaps;

            RoundNum.Minimum = Rules.MinRounds;
            LapAmount.Minimum = Rules.MinLaps;

            RoundNum.Value = TimerSettings.RoundCount;
            LapAmount.Value = TimerSettings.LapCount;
            this.Team = Team;
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            Hide();
            ChangeTeamSeparationMode ChoseMode = new ChangeTeamSeparationMode(Team);
            ChoseMode.Closed += (s, a) => Close();
            ChoseMode.Show();
            //MainForm MF = new MainForm(Team);
            //MF.Closed += (s, a) => Close();
            //MF.Show();
        }

        private void RoundNum_ValueChanged(object sender, EventArgs e)
        {
            TimerSettings.RoundCount = (byte)RoundNum.Value;
        }

        private void LapAmount_ValueChanged(object sender, EventArgs e)
        {
            TimerSettings.LapCount = (byte)LapAmount.Value;
        }
    }
}
