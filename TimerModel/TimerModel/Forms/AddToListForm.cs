using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TimerModel
{
    public partial class AddToListForm : Form
    {
        public Team NewTeam { get; private set; }
        public AddToListForm(Team Team = null)
        {
            InitializeComponent();
            if(Team != null)
            {
                NewTeam = Team;
                Pilot.Text = Team.Pilot;
                Mechanic.Text = Team.Mechanic;
                Model.Text = Team.ModelName;
            }
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            NewTeam = new Team() { Pilot = Pilot.Text, Mechanic = Mechanic.Text, ModelName = Model.Text };
            Close();
        }
    }
}
