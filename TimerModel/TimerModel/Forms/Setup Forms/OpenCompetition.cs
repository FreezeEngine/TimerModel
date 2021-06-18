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
                ProjectsList.Items.Add("Название: " + CC.Name);
            }
            if (Projects.Length == 0)
            {
                ProjectsList.Items.Add("Проектов нет");
                ProjectsList.SelectedIndex = 0;
                Continue.Visible = false;
                DeleteCompetition.Visible = false;
                ModelStartBox.Visible = false;
                InfoBox.Visible = false;
                SelectCompetition.Visible = false;
                SelectCompetition.Items.Clear();
            }
            else
            {
                ProjectsList.SelectedIndex = ProjectsList.Items.Count - 1;
                SelectCompetition.SelectedIndex = SelectCompetition.Items.Count - 1;
            }
        }
        void UpdateData()
        {

            MainTree.Nodes.Clear();
            if (SelectCompetition.SelectedIndex == SelectCompetition.Items.Count - 1)
            {
                InfoBox.Visible = false;

            }

            if (Projects.Length == 0)
            {
                return;
            }
            StartModelIndex.Items.Clear();
            if (ProjectsList.SelectedIndex != -1)
            {
                if (SelectCompetition.SelectedIndex == SelectCompetition.Items.Count - 1)
                {
                    StartModelIndex.Items.AddRange(Projects[ProjectsList.SelectedIndex].PartsOfCompetitions[^1].Teams.TeamClumps.ToArray());
                    StartModelIndex.SelectedIndex = 0;
                    return;
                }
                else
                {
                    StartModelIndex.Items.AddRange(Projects[ProjectsList.SelectedIndex].PartsOfCompetitions[SelectCompetition.SelectedIndex].Teams.TeamClumps.ToArray());
                }
                StartModelIndex.SelectedIndex = 0;
            }
            var CC = Projects[ProjectsList.SelectedIndex];
            var C = CC.PartsOfCompetitions[SelectCompetition.SelectedIndex];

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


            MainTree.Nodes.Add("Соревнование");
            int c = 0;
            //if
            //MessageBox.Show(Projects[ProjectsList.SelectedIndex].PartsOfCompetitions[SelectCompetition.SelectedIndex].Teams?.TeamClumps.Count.ToString());
            if (!(SelectCompetition.SelectedIndex == Projects[ProjectsList.SelectedIndex].PartsOfCompetitions.Count))
            {
                TimerSettings.Competition = Projects[ProjectsList.SelectedIndex].PartsOfCompetitions[SelectCompetition.SelectedIndex];
            }
            var TCs = Projects[ProjectsList.SelectedIndex].PartsOfCompetitions[SelectCompetition.SelectedIndex].Teams?.GetTeamClumps();
            foreach (var TC in TCs)
            {
                //MessageBox.Show(c.ToString());
                MainTree.CheckBoxes = false;
                MainTree.Nodes[0].Nodes.Add("Между моделями: " + TC.CompetingModel + " | Количество команд: " + TC.Teams().Count);
                //MainTree.Nodes[0].Nodes[c].Nodes.Add("Туров в соревновании: " + TC.RoundsForThisClass.ToString());
                int d = 0;
                MainTree.Nodes[0].Nodes[c].Nodes.Add("Команды:");

                var Ts = TC.Teams();

                foreach (var T in Ts)
                {
                    //MessageBox.Show(d.ToString());
                    MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes.Add(T.ToString());
                    MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes.Add("Текущий тур: " + (T.CurrentRoundNum + 1).ToString());
                    MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes.Add("Туры: ");
                    int b = 0;
                    foreach (var TD in T?.Rounds)
                    {
                        MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes.Add("Тур - " + (b + 1).ToString());
                        if (TD.Laps.Count == 0)
                        {
                            MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("В очереди");
                            b++;
                            continue;
                        }
                        MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("Круги:");
                        int e = 0;
                        foreach (var TL in TD?.Laps)
                        {
                            MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes[0].Nodes.Add(TL.ToString());
                            e++;
                        }
                        MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("Время: " + TD.RoundTTime());
                        MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("Всего очков: " + TD.RoundPoints());
                        b++;
                        if (T.CurrentRound == TD)
                        {
                            if (!T.CurrentRound.Finished)
                            {
                                MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[T.CurrentRoundNum].Nodes.Clear();
                                MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[T.CurrentRoundNum].Nodes.Add("В ожидании");
                            }
                        }
                    }
                    d++;
                }
                c++;
            }
            MainTree.Nodes[0].Expand();
        }
        private void Continue_Click(object sender, EventArgs e)
        {


            Hide();
            TimerSettings.Container = Projects[ProjectsList.SelectedIndex];
            if (SelectCompetition.SelectedIndex == Projects[ProjectsList.SelectedIndex].PartsOfCompetitions.Count)
            {
                //NEW SYSTEM
                //REGEN TEAMS
                //var CTeams = TimerSettings.Container.PartsOfCompetitions[0].Teams.AllTeams
                TimerSettings.Container.PartsOfCompetitions.Add(new Competition(TimerSettings.Container.PartsOfCompetitions[0].Teams.AllTeams));
                TimerSettings.Competition = TimerSettings.Container.PartsOfCompetitions[^1];

            }
            else
            {
                TimerSettings.Competition = Projects[ProjectsList.SelectedIndex].PartsOfCompetitions[SelectCompetition.SelectedIndex];
            }
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
            SelectCompetition.Items.Clear();
            SelectCompetition.Items.AddRange(Projects[ProjectsList.SelectedIndex].PartsOfCompetitions.ToArray());
            SelectCompetition.Items.Add("Новый этап");
            if (ProjectsList.SelectedIndex != -1)
            {
                SelectCompetition.Enabled = true;
                SelectCompetition.SelectedIndex = SelectCompetition.Items.Count - 1;
            }
            UpdateData();
        }

        private void SelectCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (SelectCompetition.SelectedIndex == Projects[ProjectsList.SelectedIndex].PartsOfCompetitions.Count)
            {
                InfoBox.Visible = true;
            }
            else
            {
                InfoBox.Visible = true;

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
