using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimerModel.Forms;

namespace TimerModel
{
    public partial class CreateListForm : Form
    {
        public bool SomethingChanged = false;
        public CreateListForm(bool ChooseMode = false)
        {
            InitializeComponent();

            if (ChooseMode)
            {
                CreateAndUse.Visible = false;
                Choose.Visible = true;
                CreateExcelFile.Visible = false;
                ChooseEmpty.Visible = true;
                JustUse.Visible = false;
                UpdateFlyModelsList();
            }
            else
            {
                new Competition();
                Choose.Visible = false;
                ChooseEmpty.Visible = false;
            }
        }
        private void UpdateFlyModelsList()
        {
            FlyModelsList.Items.Clear();
            FlyModelsList.Text = null;
            FlyModelsList.Items.AddRange(Competition.Teams.TeamClumps?.ToArray());
            FlyModelsList.Items.Add("Все модели");

            if (Competition.Teams.TeamClumps.Count != 0)
            {
                FlyModelsList.SelectedIndex = Competition.Teams.TeamClumps.Count;
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
            AddItemForm.FormClosing += (s, args) => { if (AddItemForm.NewTeam != null) { ListOfTeams.Items.Add(AddItemForm.NewTeam); Competition.Teams.Add(AddItemForm.NewTeam); UpdateFlyModelsList(); }; };
            AddItemForm.Show();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (ListOfTeams.SelectedItem != null)
            {
                SomethingChanged = true;
                Competition.Teams.Remove((Team)ListOfTeams.SelectedItem);

                if ((Team)ListOfTeams.SelectedItem == Competition.Teams.First)
                {
                    Competition.Teams.First = new Team() { Enabled = false };
                }
                if ((Team)ListOfTeams.SelectedItem == Competition.Teams.Second)
                {
                    Competition.Teams.Second = new Team() { Enabled = false };
                }
                if ((Team)ListOfTeams.SelectedItem == Competition.Teams.Third)
                {
                    Competition.Teams.Third = new Team() { Enabled = false };
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
                Team T = AddItemForm.NewTeam;
                AddItemForm.FormClosing += (s, args) => { UpdateFlyModelsList(); };
                //ListOfTeams.Items[ListOfTeams.SelectedIndex] = Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].Teams[ListOfTeams.SelectedIndex];
                AddItemForm.Show();
            }
            else
            {
                MessageBox.Show("Команда не выбрана!");
            }
        }
        private async Task SaveListAsync()
        {
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
            SomethingChanged = true;
            CompetitionManager CM = new CompetitionManager();
            CM.Show();
        }

        private void FlyModelsList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (FlyModelsList.SelectedIndex == Competition.Teams.TeamClumps.Count)
            {
                ListOfTeams.Items.Clear();
                ListOfTeams.Items.AddRange(Competition.Teams.GetTeams().ToArray());
                return;
            }
            ListOfTeams.Items.Clear();
            ListOfTeams.Items.AddRange(Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].Teams.ToArray());

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
    }
}

