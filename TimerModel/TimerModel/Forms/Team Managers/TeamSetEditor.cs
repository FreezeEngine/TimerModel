using System.Windows.Forms;
using TimerModel;

namespace CompetitionOrganizer.Forms.Team_Managers
{
    public partial class TeamSetEditor : Form
    {
        public TeamSetEditor()
        {
            InitializeComponent();
            UpdateLists();
            TopMost = true;
        }
        void UpdateLists()
        {
            Model.Items.Clear();
            Model.Items.AddRange(TimerSettings.Competition.Teams.TeamClumps.ToArray());

            if (Model.Items.Count > 0)
            {
                Model.SelectedIndex = 0;
            }
            else
            {
                //Model.Items.Add()
                //IMPOSSIBLE!!!
            }
            TimerSettings.Competition.Teams.ReloadTeamSet();
            UpdateTeamsetsTree();
        }
        void UpdateTeamsetsTree()
        {
            TeamSetsTree.Nodes.Clear();
            TeamSetsTree.Nodes.Add("Соревнование");
            byte c = 0;
            foreach (var TC in TimerSettings.Competition.Teams?.TeamClumps)
            {
                TeamSetsTree.CheckBoxes = false;
                TeamSetsTree.Nodes[0].Nodes.Add("Между моделями: " + TC.CompetingModel + " | Количество троек: " + TC.TeamSets.Count);
                var TS = TC.TeamSets;
                foreach (var T in TS)
                {
                    TeamSetsTree.Nodes[0].Nodes[c].Nodes.Add(T.ToString());
                }
                c++;
            }
            TeamSetsTree.Nodes[0].Expand();
        }

        private void Submit_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        //CHECK FOR NULL!!!!
        private void Model_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (Model.SelectedIndex != -1)
            {
                TS1.Items.Clear();
                TS1.Items.AddRange(TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets.ToArray());
                TS1.Enabled = true;
                TS1.SelectedIndex = 0;
            }
        }

        private void TS1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            TeamSet1.Items.Clear();
            TeamSet1.Items.AddRange(TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].GetAsList().ToArray());
        }

        private void MoveUp1_Click(object sender, System.EventArgs e)
        {
            if (TeamSet1.SelectedItem != null)
            {
                TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].UpdateSets();
                Team T1;
                if (TeamSet1.SelectedIndex == 0)
                {
                    T1 = (Team)TeamSet1.Items[2];
                    TeamSet1.Items[2] = TeamSet1.SelectedItem;
                    TeamSet1.Items[0] = T1;
                    //TeamSet1.SelectedItem = TeamSet1.Items[2];
                }
                else if (TeamSet1.SelectedIndex == 1)
                {
                    T1 = (Team)TeamSet1.Items[TeamSet1.SelectedIndex - 1];
                    TeamSet1.Items[0] = TeamSet1.SelectedItem;
                    TeamSet1.Items[1] = T1;
                }
                else if (TeamSet1.SelectedIndex == 2)
                {
                    T1 = (Team)TeamSet1.Items[TeamSet1.SelectedIndex - 1];
                    TeamSet1.Items[1] = TeamSet1.SelectedItem;
                    TeamSet1.Items[2] = T1;
                }
                TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].UpdateAsList(new Team[3] { (Team)TeamSet1.Items[0], (Team)TeamSet1.Items[1], (Team)TeamSet1.Items[2] });
                TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].UpdateSets();
                //.Competition.Teams.TeamClumps[Model2.SelectedIndex].TeamSets[TS2.SelectedIndex].UpdateAsList(new Team[3] { (Team)TeamSet2.Items[0], (Team)TeamSet2.Items[1], (Team)TeamSet2.Items[2] });
                UpdateLists();
            }
        }

        private void MoveDown1_Click(object sender, System.EventArgs e)
        {
            if (TeamSet1.SelectedItem != null)
            {
                TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].UpdateSets();
                Team T1;
                if (TeamSet1.SelectedIndex == 0)
                {
                    T1 = (Team)TeamSet1.Items[TeamSet1.SelectedIndex + 1];
                    TeamSet1.Items[1] = TeamSet1.SelectedItem;
                    TeamSet1.Items[0] = T1;
                    //TeamSet1.SelectedItem = TeamSet1.Items[2];
                }
                else if (TeamSet1.SelectedIndex == 1)
                {
                    T1 = (Team)TeamSet1.Items[TeamSet1.SelectedIndex + 1];
                    TeamSet1.Items[2] = TeamSet1.SelectedItem;
                    TeamSet1.Items[1] = T1;
                }
                else if (TeamSet1.SelectedIndex == 2)
                {
                    T1 = (Team)TeamSet1.Items[0];
                    TeamSet1.Items[0] = TeamSet1.SelectedItem;
                    TeamSet1.Items[2] = T1;
                }
                TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].UpdateAsList(new Team[3] { (Team)TeamSet1.Items[0], (Team)TeamSet1.Items[1], (Team)TeamSet1.Items[2] });
                TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].UpdateSets();
                //.Competition.Teams.TeamClumps[Model2.SelectedIndex].TeamSets[TS2.SelectedIndex].UpdateAsList(new Team[3] { (Team)TeamSet2.Items[0], (Team)TeamSet2.Items[1], (Team)TeamSet2.Items[2] });
                UpdateLists();
            }
        }


        private void AddTeamSet_Click(object sender, System.EventArgs e)
        {
            //TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets.Add
            TeamSetCreator TSC = new TeamSetCreator();
            TSC.Closing += (s, a) =>
            {
                TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets.Add(TSC.teamSet);
                UpdateLists();
            };
            TSC.Show();
        }
        private void DeleteTeamSet_Click(object sender, System.EventArgs e)
        {

            //MessageBox.Show(V.ToString());
            TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets.RemoveAt(TS1.SelectedIndex);
            //MessageBox.Show(T.ToString());
            UpdateLists();
        }

        private void EditTeamSet_Click(object sender, System.EventArgs e)
        {
            TeamSetCreator TSC = new TeamSetCreator(TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex]);
            TSC.Closing += (s, a) =>
            {
                //TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets.Add(TSC.teamSet);
                UpdateLists();
            };
            TSC.Show();
        }
    }
}
