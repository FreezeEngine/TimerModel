using CompetitionOrganizer.Objects;
using CompetitionOrganizer.Objects.Reporting;
using System;
using System.IO;
using System.Windows.Forms;
using TimerModel.Objects;

namespace TimerModel
{
    public partial class SetSettings : Form
    {
        bool UpdateControls = true;
        public SetSettings()
        {
            InitializeComponent();
            TimerSettings.Competition.Teams.Setup();
            TopMost = true;

            FlyModelsList.Items.AddRange(TimerSettings.Competition.Teams.TeamClumps?.ToArray());
            StartModelIndex.Items.AddRange(TimerSettings.Competition.Teams.TeamClumps?.ToArray());

            UpdateFlyModelsList();

            LapsCount.Maximum = Rules.MaxLaps;
            LapsCount.Minimum = Rules.MinLaps;

            RoundsCount.Maximum = Rules.MaxRounds;
            RoundsCount.Minimum = Rules.MinRounds;
        }
        private void UpdateFlyModelsList()
        {
            UpdateControls = false;

            if (FlyModelsList.SelectedIndex == -1)
            {
                FlyModelsList.SelectedIndex = 0;
                StartModelIndex.SelectedIndex = 0;
            }

            FlyModelsList.Items[FlyModelsList.SelectedIndex] = TimerSettings.Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex];
            StartModelIndex.Items[StartModelIndex.SelectedIndex] = TimerSettings.Competition.Teams.TeamClumps[StartModelIndex.SelectedIndex];

            LapsCount.Value = TimerSettings.Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].LapsCount;
            RoundsCount.Value = TimerSettings.Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].MaxRoundsCount;

            UpdateControls = true;
        }
        private void Continue_Click(object sender, EventArgs e)
        {
            Hide();
            // MessageBox.Show("1");
            TimerSettings.Container = new CompetitionsContainer();
            TimerSettings.Competition.Teams.Setup(false);
            TimerSettings.Container.LaunchSupervisor = LaunchSupervisor.Text;
            TimerSettings.Container.MainJudge = MainJudge.Text;
            TimerSettings.Container.Scorekeeper = Scorekeeper.Text;
            //MessageBox.Show("2");
            TimerSettings.Competition.Teams.CurrentModel = (CompetingModels)StartModelIndex.SelectedItem;


            TimerSettings.Container.Name = CMName.Text;
            //TimerSettings.Container.PartsOfCompetitions = new List<Competition>();
            TimerSettings.Container.Competition = TimerSettings.Competition;
            //TimerSettings.Container.CurrentState = TimerSettings.Competition;
            //MessageBox.Show("3");
            //Async!

            TimerSettings.MakeEnvironment();
            TimerSettings.CurrentProjectFolder = Path.Combine(TimerSettings.CompetitionProjects, DateTime.Now.ToString("D") + " " + DateTime.Now.ToString("H-mm-ss"));
            Directory.CreateDirectory(Path.Combine(TimerSettings.CurrentProjectFolder));

            //TimerSettings.Container.Name +
            BGSaver.SaveData();
            //MessageBox.Show("4");

            MainForm MF = new MainForm();
            MF.Closed += (s, a) => Close();
            MF.Show();
        }
        private void LapAmount_ValueChanged(object sender, EventArgs e)
        {
            //UpdateFlyModelsList();
            if (UpdateControls)
            {
                TimerSettings.Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].LapsCount = (byte)LapsCount.Value;
                UpdateFlyModelsList();
            }
        }

        private void CMList_SelectedIndexChanged(object sender, EventArgs e)
        {

            //RoundNum.Value = TimerSettings.Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].RoundsForThisClass;
            if (UpdateControls)
                UpdateFlyModelsList();
            //LapsAmount.Value = TimerSettings.Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].LapsCount;
        }

        private void SetSettings_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void StartModelIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UpdateControls)
                UpdateFlyModelsList();
        }

        private void RoundsCount_ValueChanged(object sender, EventArgs e)
        {
            if (UpdateControls)
            {
                TimerSettings.Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].MaxRoundsCount = (byte)RoundsCount.Value;
                UpdateFlyModelsList();
            }
        }
    }
}
