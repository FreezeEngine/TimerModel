using System;
using System.Windows.Forms;
using TimerModel.Forms.Team_Managers;

namespace TimerModel.Forms.Setup_Forms
{
    public partial class PreFinishAsk : Form
    {
        public PreFinishAsk()
        {
            InitializeComponent();
        }

        private void ReflyModels_Click(object sender, EventArgs e)
        {
            Refly RF = new Refly();
            RF.FormClosing += (s, a) => { if (RF.CloseForm) { Close(); } Show(); };
            Hide();
            RF.Show();
        }

        private void Report_Click(object sender, EventArgs e)
        {
            ReportManager RM = new ReportManager();
            Hide();
            RM.Show();
        }
    }
}
