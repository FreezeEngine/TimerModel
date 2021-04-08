using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TimerModel
{
    public partial class CreateListForm : Form
    {
        bool ChoseMode;
        public CreateListForm(bool ChoseMode = false)
        {
            this.ChoseMode = ChoseMode;
            InitializeComponent();

            if (ChoseMode)
            {
                CreateAndUse.Enabled = false;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddToListForm AddItemForm = new AddToListForm();
            AddItemForm.FormClosing += (s, args) => { if (AddItemForm.NewTeam != null) { ListOfTeams.Items.Add(AddItemForm.NewTeam); }; };
            AddItemForm.Show();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (ListOfTeams.SelectedItem != null)
            {
                ListOfTeams.Items.RemoveAt(ListOfTeams.SelectedIndex);
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
                AddToListForm AddItemForm = new AddToListForm((Team)ListOfTeams.SelectedItem);
                AddItemForm.FormClosing += (s, args) => ListOfTeams.Items[ListOfTeams.SelectedIndex] = AddItemForm.NewTeam;
                AddItemForm.Show();
            }
            else
            {
                MessageBox.Show("Команда не выбрана!");
            }

        }
        private List<Team> SaveList()
        {
            if (ListOfTeams.Items.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения");
                return null;
            }
            Stream Stream;
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Title = "Сохранить список команд";
            SaveFile.InitialDirectory = @"C:\";
            SaveFile.Filter = "Таблица Excel (*.xlsx)|*.xlsx";
            SaveFile.FilterIndex = 0;
            SaveFile.RestoreDirectory = true;

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
                    Stream.Write(TeamsR.Generate(TeamsList));
                    Stream.Close();
                    return TeamsList;
                }
            }
            return null;
        }
        private void SaveList1()
        {
            //if (ListOfTeams.Items.Count == 0)
            //{
                //MessageBox.Show("Нет данных для сохранения");
            //    return;
            //}
            Stream Stream;
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Title = "Сохранить список команд";
            SaveFile.InitialDirectory = @"C:\";
            SaveFile.Filter = "Таблица Excel (*.xlsx)|*.xlsx";
            SaveFile.FilterIndex = 0;
            SaveFile.RestoreDirectory = true;

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                if ((Stream = SaveFile.OpenFile()) != null)
                {
                    //List<Team> TeamsList = new List<Team>();
                    //foreach (Team t in ListOfTeams.Items)
                    {
                        //    TeamsList.Add(t);
                        //}
                        //ListOfTeams TeamsR = new ListOfTeams();
                        Stream.Write(new TourReport().Generate());
                        Stream.Close();
                        return;
                    }
                }
                return;
            }
        }
            private void CreateExcelFile_Click(object sender, EventArgs e)
            {
                SaveList();
            }

            private void CreateAndUse_Click(object sender, EventArgs e)
            {
                //SaveList();
                var Teams = SaveList();
                if (Teams != null) {
                    Hide();
                    ChangeTeamSeparationMode ChoseMode = new ChangeTeamSeparationMode(Teams);
                ChoseMode.Closed += (s, a) => Close();
                ChoseMode.Show();
                //MainForm Timer = new MainForm(Teams);
                //Timer.Closed += (s, a) => Close();
                //Timer.Show();
            }
            }

            private void button1_Click(object sender, EventArgs e)
            {
                SaveList1();
            }
        }
    }

