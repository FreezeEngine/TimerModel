using CompetitionOrganizer.Objects;
//using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using TimerModel;
using TimerModel.Objects;

namespace CompetitionOrganizer.Forms.Setup_Forms
{
    public partial class OpenCompetition : Form
    {
        public OpenCompetition()
        {
            InitializeComponent();
            LoadItems();
            UpdateData();
        }
        private CompetitionsContainer[] Projects { get; set; }
        private string[] ProjectsDirs { get; set; }
        private void LoadItems()
        {
            ProjectsList.Items.Clear();
            ProjectsList.Text = "Загрузка...";

            TimerSettings.MakeEnvironment();

            ProjectsDirs = Directory.GetDirectories(TimerSettings.CompetitionProjects);
            Projects = new CompetitionsContainer[ProjectsDirs.Length];

            for (int i = 0; i < ProjectsDirs.Length; i++)
            {
                try
                {
                    Projects[i] = JsonSerializer.Deserialize<CompetitionsContainer>(File.ReadAllText(Directory.GetFiles(ProjectsDirs[i])[0]));
                    //Projects[i] = JsonConvert.DeserializeObject<CompetitionsContainer>(File.ReadAllText(Directory.GetFiles(ProjectsDirs[i])[0]));
                }
                catch
                {
                    Directory.Delete(ProjectsDirs[i], true);
                    LoadItems();
                }
            }
            ProjectsList.Items.Clear();
            foreach (CompetitionsContainer CC in Projects)
            {
                ProjectsList.Items.Add("Название: " + CC.Name + (CC.Competition.Finished ? " (Завершено)" : ""));
            }
            if (Projects.Length == 0)
            {
                ProjectsList.Items.Add("Проектов нет");
                ProjectsList.SelectedIndex = 0;
                Continue.Visible = false;
                DeleteCompetition.Visible = false;
                ModelStartBox.Visible = false;
                InfoBox.Visible = false;
                CompetitionLabel.Visible = false;
            }
            else
            {
                ProjectsList.SelectedIndex = ProjectsList.Items.Count - 1;
                CompetitionLabel.Text = Projects[ProjectsList.SelectedIndex].Competition.ToString();
                InfoBox.Visible = true;
                UpdateData();
            }
        }
        void UpdateData()
        {
            MainTree.Nodes.Clear();

            if (Projects.Length == 0)
            {
                return;
            }

            StartModelIndex.Items.Clear();
            if (ProjectsList.SelectedIndex != -1)
            {
                StartModelIndex.Items.AddRange(Projects[ProjectsList.SelectedIndex].Competition.Teams.TeamClumps.ToArray());
                StartModelIndex.SelectedIndex = 0;
                //return;
            }

            var CC = Projects[ProjectsList.SelectedIndex];
            var C = CC.Competition;

            TeamsCount.Text = "Количество команд: " + C.Teams.Count.ToString();
            PeopleCount.Text = "Количество участников: " + C.Teams.Participants().Count.ToString();
            ModelsCount.Text = "Количество моделей в соревновании: " + C.Teams.TeamClumps.Count.ToString();
            RoundsCount.Text = "Количество проведённых туров: ~" + C.Teams.GetTeams()[0].Rounds.Count;

            string MJ = (CC.MainJudge.Length < 5) ? ((CC.MainJudge == "" | CC.MainJudge.Length < 2) ? ("Не задан") : ("[!] " + CC.MainJudge)) : (CC.MainJudge);
            string SK = (CC.Scorekeeper.Length < 5) ? ((CC.Scorekeeper == "" | CC.Scorekeeper.Length < 2) ? ("Не задан") : ("[!] " + CC.Scorekeeper)) : (CC.Scorekeeper);
            string LS = (CC.LaunchSupervisor.Length < 5) ? ((CC.LaunchSupervisor == "" | CC.LaunchSupervisor.Length < 2) ? ("Не задан") : ("[!] " + CC.LaunchSupervisor)) : (CC.LaunchSupervisor);

            MainJudge.Text = "Главный судья: " + MJ;
            Scorekeeper.Text = "Секретарь: " + SK;
            HeadOfAStart.Text = "Начальник старта: " + LS;


            var TCs = C.Teams?.TeamClumps;

            TreeDrawer.DrawCompetitionStructure(MainTree, TCs, C);
        }
        private void Continue_Click(object sender, EventArgs e)
        {


            Hide();
            TimerSettings.Container = Projects[ProjectsList.SelectedIndex];

            TimerSettings.Competition = Projects[ProjectsList.SelectedIndex].Competition;

            TimerSettings.Competition.Teams.Setup(false);


            TimerSettings.Competition.Teams.CurrentModel = (CompetingModels)StartModelIndex.SelectedItem;

            //TimerSettings.Container.CurrentState = TimerSettings.Competition;

            TimerSettings.CurrentProjectFolder = ProjectsDirs[ProjectsList.SelectedIndex];


            MainForm MF = new MainForm();
            MF.Closed += (s, a) => Close();
            MF.Show();
        }

        private void ProjectsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Projects.Length == 0)
            {
                return;
            }
            if (ProjectsList.SelectedIndex != -1)
            {
                
                CompetitionLabel.Enabled = true;
            }
            UpdateData();
        }

        private void StartModelIndex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DeleteCompetition_Click(object sender, EventArgs e)
        {
            if (ProjectsList.SelectedIndex != -1)
            {
                var DeleteDialog = MessageBox.Show("Удалить данные соревновния?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DeleteDialog == DialogResult.Yes)
                {
                    Directory.Delete(ProjectsDirs[ProjectsList.SelectedIndex], true);
                    LoadItems();
                    UpdateData();
                }
            }
        }
    }
}
