using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TimerModel
{
    public partial class ChangeTeamSeparationMode : Form
    {
        List<Team> Teams;
        public ChangeTeamSeparationMode(List<Team> Teams)
        {
            InitializeComponent();
            this.Teams = Teams;
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            //byte mode = 
            Hide();
            MainForm MF = new MainForm(Teams, AutomaticMode.Checked);
            MF.Closed += (s, a) => Close();
            MF.Show();
        }
    }
}
