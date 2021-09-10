using System;
using System.Windows.Forms;
using TimerModel;
using TimerModel.Objects;

namespace CompetitionOrganizer.Forms.Team_Managers
{
    public partial class TeamSetCreator : Form
    {
        public TeamSet teamSet;
        public TeamSetCreator(TeamSet teamSet)
        {
            TopMost = true;
            this.teamSet = teamSet;
            InitializeComponent();
            reloadTeamSetInfo();
        }
        public TeamSetCreator()
        {
            TopMost = true;
            InitializeComponent();
            teamSet = new TeamSet();
            reloadTeamSetInfo();
        }
        private void reloadTeamSetInfo()
        {
            var tripoint = "...";
            var trim = 63;
            var t1 = teamSet.First.ToString();
            if (t1.Length > trim)
            {
                t1 = t1.Remove(trim) + tripoint;
            }
            N1.Text = t1;
            var t2 = teamSet.Second.ToString();
            if (t2.Length > trim)
            {
                t2 = t2.Remove(trim) + tripoint;
            }
            N2.Text = t2;
            var t3 = teamSet.Third.ToString();
            if (t3.Length > trim)
            {
                t3 = t3.Remove(trim) + tripoint;
            }
            N3.Text = t3;
        }

        private void N1B_Click(object sender, EventArgs e)
        {
            ChangePilot(0);
        }

        private void N2B_Click(object sender, EventArgs e)
        {
            ChangePilot(1);
        }

        private void N3B_Click(object sender, EventArgs e)
        {
            ChangePilot(2);
        }

        private void ChangePilot(int ModelNum)
        {
            TeamsListForm LF = new TeamsListForm(true);
            LF.Closing += (s, a) =>
            {
                if (LF.Choosen_Team != null)
                {
                    switch (ModelNum)
                    {
                        case 0:
                            teamSet.First = LF.Choosen_Team;
                            break;
                        case 1:
                            teamSet.Second = LF.Choosen_Team;
                            break;
                        case 2:
                            teamSet.Third = LF.Choosen_Team;
                            break;
                    }
                }
                if (LF.SomethingChanged)
                {
                    reloadTeamSetInfo();
                }
            };
            LF.Show();
        }
    }
}
