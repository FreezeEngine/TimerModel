using System;
using System.Windows.Forms;

namespace TimerModel.Forms.Setup_Forms
{
    public partial class ChooseNextModelSet : Form
    {
        public byte SelectedIndex;
        public ChooseNextModelSet()
        {
            InitializeComponent();
            TopMost = true;
            ListOfModels.Items.AddRange(TimerSettings.Competition.Teams.TeamClumps?.ToArray());
            if (TimerSettings.Competition.Teams.TeamClumps.Count != 0)
            {
                ListOfModels.SelectedItem = TimerSettings.Competition.Teams.CurrentModel;
            }
            else
            {
                ListOfModels.SelectedIndex = -1;
                ListOfModels.Text = "Нет моделей";
            }
        }

        private void NextModels_Click(object sender, EventArgs e)
        {
            SelectedIndex = (byte)ListOfModels.SelectedIndex;
            Hide();
            Close();
        }

        private void ChooseNextModelSet_Load(object sender, EventArgs e)
        {

        }
    }
}
