﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimerModel.Forms;
using TimerModel.Objects;

namespace TimerModel
{
    public partial class TeamsListForm : Form
    {
        public bool SomethingChanged = false;
        public TeamsListForm(bool ShowUnusedFirst = false)
        {
            InitializeComponent();
            TopMost = true;

            //if (ChooseMode)
            //{
            //CreateAndUse.Visible = false;
            //Choose.Visible = true;
            //CreateExcelFile.Visible = false;
            //ChooseEmpty.Visible = true;
            //JustUse.Visible = false;
            UpdateFlyModelsList();
            if (ShowUnusedFirst)
            {
                FlyModelsList.SelectedIndex = FlyModelsList.Items.Count - 1;
            }
            //}
            //else
            //{
            //   new Competition();
            //   Choose.Visible = false;
            //   ChooseEmpty.Visible = false;
            //}
        }
        private void UpdateFlyModelsList()
        {
            FlyModelsList.Items.Clear();
            FlyModelsList.Text = null;
            FlyModelsList.Items.AddRange(TimerSettings.Competition.Teams.TeamClumps?.ToArray());
            FlyModelsList.Items.Add("Все модели");
            FlyModelsList.Items.Add("Не используемые");

            if (TimerSettings.Competition.Teams.TeamClumps.Count != 0)
            {
                FlyModelsList.SelectedIndex = TimerSettings.Competition.Teams.TeamClumps.Count;
            }
            else
            {
                FlyModelsList.SelectedIndex = -1;
                FlyModelsList.Text = "Нет моделей";
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddToListForm AddItemForm = new AddToListForm();
            AddItemForm.FormClosing += (s, args) => { if (AddItemForm.NewTeam != null) { UpdateFlyModelsList(); }; };
            AddItemForm.Show();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (ListOfTeams.SelectedItem != null)
            {
                SomethingChanged = true;
                TimerSettings.Competition.Teams.Remove((Team)ListOfTeams.SelectedItem);

                if ((Team)ListOfTeams.SelectedItem == TimerSettings.Competition.Teams.First)
                {
                    TimerSettings.Competition.Teams.First = TimerSettings.Competition.Teams._Disabled;
                }
                if ((Team)ListOfTeams.SelectedItem == TimerSettings.Competition.Teams.Second)
                {
                    TimerSettings.Competition.Teams.Second = TimerSettings.Competition.Teams._Disabled;
                }
                if ((Team)ListOfTeams.SelectedItem == TimerSettings.Competition.Teams.Third)
                {
                    TimerSettings.Competition.Teams.Third = TimerSettings.Competition.Teams._Disabled;
                }
                ListOfTeams.Items.RemoveAt(ListOfTeams.SelectedIndex);
                UpdateFlyModelsList();
            }
            else
            {
                MessageBox.Show("Команда не выбрана!");
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (ListOfTeams.SelectedItem != null)
            {
                SomethingChanged = true;
                AddToListForm AddItemForm = new AddToListForm((Team)ListOfTeams.SelectedItem);
                //Team T = AddItemForm.NewTeam;
                AddItemForm.FormClosing += (s, args) => { UpdateFlyModelsList(); };
                //ListOfTeams.Items[ListOfTeams.SelectedIndex] = TimerSettings.Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].Teams[ListOfTeams.SelectedIndex];
                AddItemForm.Show();
            }
            else
            {
                MessageBox.Show("Команда не выбрана!");
            }
        }
        private async Task SaveListAsync()
        {
            //REWRITE
            if (ListOfTeams.Items.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения");
                return;
            }
            Stream Stream;
            SaveFileDialog SaveFile = new SaveFileDialog
            {
                Title = "Сохранить список команд",
                InitialDirectory = @"C:\",
                Filter = "Таблица Excel (*.xlsx)|*.xlsx",
                FilterIndex = 0,
                RestoreDirectory = true
            };

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                if ((Stream = SaveFile.OpenFile()) != null)
                {
                    List<Team> TeamsList = new List<Team>();
                    foreach (Team t in ListOfTeams.Items)
                    {
                        TeamsList.Add(t);
                    }
                    ListOfTeams TeamsR = new ListOfTeams();
                    byte[] b = TeamsR.Generate(TeamsList);
                    await Stream.WriteAsync(b);
                    Stream.Close();
                    if (TeamsR != null)
                    {
                        Hide();
                        new Competition(TeamsList);
                        SetSettings Settings = new SetSettings();
                        Settings.Closed += (s, a) => Close();
                        Settings.Show();
                    }
                    return;
                }
            }
            return;
        }

        private async void CreateExcelFile_ClickAsync(object sender, EventArgs e)
        {
            Hide();
            await SaveListAsync();
        }

        private async void CreateAndUse_ClickAsync(object sender, EventArgs e)
        {
            Hide();
            await SaveListAsync();
        }

        public Team Choosen_Team { get; private set; }
        private void Choose_Click(object sender, EventArgs e)
        {
            if (ListOfTeams.SelectedItem != null)
            {
                SomethingChanged = true;
                List<Team> Team = new List<Team>();
                foreach (Team T in ListOfTeams.Items)
                {
                    Team.Add(T);
                }
                Choosen_Team = (Team)ListOfTeams.SelectedItem;
                Close();
            }
            else
            {
                MessageBox.Show("Команда не выбрана!");
            }
        }

        private void OpenCompetitionManager_Click(object sender, EventArgs e)
        {
            Hide();
            SomethingChanged = true;
            OpenCompetitionManager.Enabled = false;
            CompetitionManager CM = new CompetitionManager();
            CM.FormClosing += (s, a) => { OpenCompetitionManager.Enabled = true; Show(); };
            CM.Show();
        }

        private void FlyModelsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateList();
        }
        private void UpdateList()
        {
            ListOfTeams.Items.Clear();
            List<Team> Ts;
            if (FlyModelsList.SelectedIndex == TimerSettings.Competition.Teams.TeamClumps.Count)
            {
                Ts = TimerSettings.Competition.Teams.GetTeams();
            }
            else if (FlyModelsList.SelectedIndex < TimerSettings.Competition.Teams.TeamClumps.Count)
            {
                Ts = TimerSettings.Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].Teams();
            }
            else
            {
                Ts = TimerSettings.Competition.Teams.AllTeams.FindAll(delegate (Team T) { return T.CM.TeamSets.Find(delegate (TeamSet tset) { return tset.ShareSamePerson(T); }) == null; });
            }
            List<Team> TsFiltered;
            if (searchBox.Text != "")
            {
                TsFiltered = Ts.FindAll(delegate (Team T) { return T.Pilot.Name.Contains(searchBox.Text) | T.Mechanic.Name.Contains(searchBox.Text); });
            }
            else
            {
                TsFiltered = Ts;
            }
            ListOfTeams.Items.AddRange(TsFiltered.ToArray());
        }
        private void JustUse_Click(object sender, EventArgs e)
        {
            List<Team> TeamsList = new List<Team>();
            foreach (Team t in ListOfTeams.Items)
            {
                TeamsList.Add(t);
            }
            if (TeamsList.Count == 0)
            {
                MessageBox.Show("Лист команд пустой!");
            }
            Hide();
            new Competition(TeamsList);
            SetSettings Settings = new SetSettings();
            Settings.Closed += (s, a) => Close();
            Settings.Show();
        }

        private void ChooseEmpty_Click(object sender, EventArgs e)
        {
            Choosen_Team = new Team() { Enabled = false };
            SomethingChanged = true;
            Close();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}

