using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TimerModel.Objects;

namespace TimerModel
{
    public partial class AddToListForm : Form
    {
        public Team NewTeam { get; private set; }
        public AddToListForm(Team Team = null)
        {
            InitializeComponent();
            ModelsList.Items.AddRange(Competition.Teams.TeamClumps.ToArray());
            MechanicsList.Items.AddRange(Competition.Mechanics.ToArray());

            if (Team != null)
            {
                Text = "Редактировать участника";
                AddItem.Text = "Внести изменения";
                NewTeam = Team;
                Pilot.Text = Team.Pilot;
                Mechanic.Text = Team.Mechanic;
                Model.Text = Team.ModelName;
                TeamName.Text = Team.TeamName;

                ModelsList.Text = Team.ModelName;
                MechanicsList.Text = Team.Mechanic;
            }
            else
            {
                if (ModelsList.Items.Count > 0)
                    ModelsList.SelectedIndex = 0;
                if (MechanicsList.Items.Count > 0)
                    MechanicsList.SelectedIndex = 0;
            }
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            if (!(Pilot.Text == "" | TeamName.Text == "" | Mechanic.Text == "" | Model.Text == ""))
            {
                if (NewTeam != null)
                {
                    NewTeam.Pilot = Pilot.Text;
                    NewTeam.Mechanic = Mechanic.Text;
                    NewTeam.ModelName = Model.Text;
                    NewTeam.TeamName = TeamName.Text;
                    if (NewTeam.CM.CompetingModel != Model.Text)
                    {
                        NewTeam.CM.Teams.Remove(NewTeam);
                        if (NewTeam.CM.Teams.Count == 0)
                        {
                            Competition.Teams.TeamClumps.Remove(NewTeam.CM);
                        }
                        Competition.Teams.Add(NewTeam);
                    }
                }
                else
                {
                    NewTeam = new Team() { Pilot = Pilot.Text, Mechanic = Mechanic.Text, ModelName = Model.Text, TeamName = TeamName.Text };
                }
                Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля, пожалуйста");
            }
        }

        private void ModelsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Text = ModelsList.Text;
        }

        private void MechanicsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mechanic.Text = MechanicsList.Text;
        }
    }
}
