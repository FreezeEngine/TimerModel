using CompetitionOrganizer.Objects;
using System;
using System.Windows.Forms;

namespace TimerModel
{
    public partial class AddToListForm : Form
    {
        public Team NewTeam { get; private set; }
        public AddToListForm(Team Team = null)
        {
            InitializeComponent();
            TopMost = true;
            ModelsList.Items.AddRange(TimerSettings.Competition.Teams.TeamClumps.ToArray());
            MechanicsList.Items.AddRange(TimerSettings.Competition.Mechanics.ToArray());

            if (Team != null)
            {
                Text = "Редактировать участника";
                AddItem.Text = "Внести изменения";
                NewTeam = Team;
                Pilot.Text = Team.Pilot.ToString();
                Mechanic.Text = Team.ToString();
                Model.Text = Team.ModelName;
                TeamName.Text = Team.TeamName;

                ModelsList.Text = Team.ModelName;
                MechanicsList.Text = Team.Mechanic.ToString();
            }
            else
            {
                if (ModelsList.Items.Count > 0)
                {
                    ModelsList.SelectedIndex = 0;
                }

                if (MechanicsList.Items.Count > 0)
                {
                    MechanicsList.SelectedIndex = 0;
                }
            }
        }
        private void MakeTeam()
        {
            Participant FindP(string Name)
            {
                return TimerSettings.Competition.Teams.Participants().Find(delegate (Participant P) { return P.Name == Name; });
            }

            var Pr = FindP(Pilot.Text);
            if (Pr != null)
            {
                NewTeam.Pilot = Pr;
            }
            else
            {
                NewTeam.Pilot = new Participant(Pilot.Text);
            }

            if (Mechanic.Text == MechanicsList.Text)
            {
                NewTeam.Mechanic = (Participant)MechanicsList.SelectedItem;
            }
            else
            {
                var Mr = FindP(Mechanic.Text);
                if (Mr != null)
                {
                    NewTeam.Mechanic = Pr;
                }
                else
                {
                    NewTeam.Mechanic = new Participant(Mechanic.Text);
                }
            }

            NewTeam.ModelName = Model.Text;
            NewTeam.TeamName = TeamName.Text;
        }
        private void AddItem_Click(object sender, EventArgs e)
        {
            if (!(Pilot.Text == "" | TeamName.Text == "" | Mechanic.Text == "" | Model.Text == ""))
            {
                if (NewTeam != null)
                {
                    MakeTeam();

                }
                else
                {
                    NewTeam = new Team(true);
                    MakeTeam();
                    TimerSettings.Competition.Teams.Add(NewTeam);
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
