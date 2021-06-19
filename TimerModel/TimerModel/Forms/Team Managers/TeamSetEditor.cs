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
            Model2.Items.Clear();
            Model.Items.AddRange(TimerSettings.Competition.Teams.TeamClumps.ToArray());
            Model2.Items.AddRange(TimerSettings.Competition.Teams.TeamClumps.ToArray());

            if (Model.Items.Count > 0)
            {
                Model.SelectedIndex = 0;
            }
            else
            {
                //Model.Items.Add()
                //IMPOSSIBLE!!!
            }
            if (Model2.Items.Count > 0)
            {
                Model2.SelectedIndex = 0;
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

        private void Model2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (Model2.SelectedIndex != -1)
            {
                TS2.Items.Clear();
                TS2.Items.AddRange(TimerSettings.Competition.Teams.TeamClumps[Model2.SelectedIndex].TeamSets.ToArray());
                TS2.Enabled = true;
                TS2.SelectedIndex = 0;
            }
        }

        private void TS1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            TeamSet1.Items.Clear();
            TeamSet1.Items.AddRange(TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].GetAsList().ToArray());
        }

        private void TS2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            TeamSet2.Items.Clear();
            TeamSet2.Items.AddRange(TimerSettings.Competition.Teams.TeamClumps[Model2.SelectedIndex].TeamSets[TS2.SelectedIndex].GetAsList().ToArray());
        }
        /*private void UpdateSets(bool Left = true)
        {
            if (Left)
            {
                List<Team> Ts = new List<Team>();
                foreach (Team T in TeamSet1.Items)
                {
                    Ts.Add(T);
                }
                if (Ts.Count < 3)
                {
                    while (Ts.Count != 3)
                        Ts.Add(TimerSettings.Competition.Teams._Disabled);
                }
                TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].Set = Ts.ToArray();
                UpdateLists();
            }
            else
            {
                List<Team> Ts = new List<Team>();
                foreach (Team T in TeamSet2.Items)
                {
                    Ts.Add(T);
                }
                if (Ts.Count < 3)
                {
                    while (Ts.Count != 3)
                        Ts.Add(TimerSettings.Competition.Teams._Disabled);
                }
                TimerSettings.Competition.Teams.TeamClumps[Model2.SelectedIndex].TeamSets[TS2.SelectedIndex].Set = Ts.ToArray();
                UpdateLists();
            };
        }*/

        private void MoveRight_Click(object sender, System.EventArgs e)
        {
            //suspended
            if (TeamSet2.Items.Count < 3)
            {
                if (TeamSet1.SelectedIndex >= 0)
                {
                    if (!TeamSet2.Items.Contains(TeamSet1.SelectedItem))
                    {
                        bool SameParticipant = false;
                        foreach (Team T in TeamSet2.Items)
                        {
                            Team T2 = (Team)TeamSet1.SelectedItem;
                            if (T.HasSameParticipant(T2))
                            {
                                SameParticipant = true;
                            }
                        }
                        if (SameParticipant)
                        {
                            MessageBox.Show("Перемещаемая команда делит одного участника в тройке назвачения, операция отменена");
                            return;
                        }
                        //TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].Set
                        TeamSet2.Items.Add(TeamSet1.SelectedItem);
                        TeamSet1.Items.Remove(TeamSet1.SelectedItem);
                        //UpdateSets(false);
                    }
                    else
                    {
                        MessageBox.Show("Одна и та же команда в тройке недопустима!");
                        return;
                    }
                }

            }
            else
            {
                MessageBox.Show("Для перемещения не хватает места!");
                return;
            }
        }

        private void MoveLeft_Click(object sender, System.EventArgs e)
        {
            //suspended
            if (TeamSet1.Items.Count < 3)
            {
                if (TeamSet2.SelectedIndex >= 0)
                {
                    if (!TeamSet1.Items.Contains(TeamSet2.SelectedItem))
                    {
                        bool SameParticipant = false;
                        foreach (Team T in TeamSet1.Items)
                        {
                            Team T2 = (Team)TeamSet2.SelectedItem;
                            if (T.HasSameParticipant(T2))
                            {
                                SameParticipant = true;
                            }
                        }
                        if (SameParticipant)
                        {
                            MessageBox.Show("Перемещаемая команда делит одного участника в тройке назвачения, операция отменена");
                            return;
                        }
                        //TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].Set
                        TeamSet1.Items.Add(TeamSet2.SelectedItem);
                        TeamSet2.Items.Remove(TeamSet2.SelectedItem);
                        //UpdateSets();
                    }
                    else
                    {
                        MessageBox.Show("Одна и та же команда в тройке недопустима!");
                        return;
                    }
                }

            }
            else
            {
                MessageBox.Show("Для перемещения не хватает места!");
                return;
            }
        }

        private void Exchange_Click(object sender, System.EventArgs e)
        {
            if (TeamSet1.SelectedIndex >= 0 && TeamSet2.SelectedIndex >= 0)
            {
                bool SameParticipant = false;
                foreach (Team T1 in TeamSet1.Items)
                {
                    if (T1.Enabled)
                        continue;
                    Team T2 = (Team)TeamSet2.SelectedItem;
                    if (T1.HasSameParticipant(T2))
                    {
                        SameParticipant = true;
                    }
                }
                foreach (Team T1 in TeamSet2.Items)
                {
                    if (T1.Enabled)
                        continue;
                    Team T2 = (Team)TeamSet1.SelectedItem;
                    if (T1.HasSameParticipant(T2))
                    {
                        SameParticipant = true;
                    }
                }
                if(TeamSet2.SelectedItem == TeamSet1.SelectedItem)
                {
                    SameParticipant = true;
                }
                if (SameParticipant)
                {
                    MessageBox.Show("Перемещаемая команда делит одного участника в тройке назвачения, операция отменена");
                    return;
                }
                Team T = (Team)TeamSet1.SelectedItem;
                TeamSet1.Items[TeamSet1.SelectedIndex] = (Team)TeamSet2.SelectedItem;
                TeamSet2.Items[TeamSet2.SelectedIndex] = T;
                //UpdateSets();
                TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].UpdateAsList(new Team[3] { (Team)TeamSet1.Items[0], (Team)TeamSet1.Items[1], (Team)TeamSet1.Items[2] });
                TimerSettings.Competition.Teams.TeamClumps[Model2.SelectedIndex].TeamSets[TS2.SelectedIndex].UpdateAsList(new Team[3] { (Team)TeamSet2.Items[0], (Team)TeamSet2.Items[1], (Team)TeamSet2.Items[2] });
                //UpdateSets(false);
                UpdateLists();
            }
            else
            {
                MessageBox.Show("Требуется выбрать двоих людей для взаимного замещения!");
            }
        }

        private void MoveUp1_Click(object sender, System.EventArgs e)
        {
            if(TeamSet1.SelectedItem != null)
            {
                TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].UpdateSets();
                Team T1;
                if(TeamSet1.SelectedIndex == 0)
                {
                    T1 = (Team)TeamSet1.Items[2];
                    TeamSet1.Items[2] = TeamSet1.SelectedItem;
                    TeamSet1.Items[0] = T1;
                    //TeamSet1.SelectedItem = TeamSet1.Items[2];
                }
                else if(TeamSet1.SelectedIndex == 1)
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

        private void MoveUp2_Click(object sender, System.EventArgs e)
        {
            TimerSettings.Competition.Teams.TeamClumps[Model2.SelectedIndex].TeamSets[TS2.SelectedIndex].UpdateSets();
            Team T1;
            if (TeamSet2.SelectedIndex == 0)
            {
                T1 = (Team)TeamSet2.Items[2];
                TeamSet2.Items[2] = TeamSet2.SelectedItem;
                TeamSet2.Items[0] = T1;
                //TeamSet1.SelectedItem = TeamSet1.Items[2];
            }
            else if (TeamSet2.SelectedIndex == 1)
            {
                T1 = (Team)TeamSet2.Items[TeamSet2.SelectedIndex - 1];
                TeamSet2.Items[0] = TeamSet2.SelectedItem;
                TeamSet2.Items[1] = T1;
            }
            else if (TeamSet2.SelectedIndex == 2)
            {
                T1 = (Team)TeamSet2.Items[TeamSet2.SelectedIndex - 1];
                TeamSet2.Items[1] = TeamSet2.SelectedItem;
                TeamSet2.Items[2] = T1;
            }
            //TimerSettings.Competition.Teams.First
            TimerSettings.Competition.Teams.TeamClumps[Model2.SelectedIndex].TeamSets[TS2.SelectedIndex].UpdateAsList(new Team[3] { (Team)TeamSet2.Items[0], (Team)TeamSet2.Items[1], (Team)TeamSet2.Items[2] });
            TimerSettings.Competition.Teams.TeamClumps[Model2.SelectedIndex].TeamSets[TS2.SelectedIndex].UpdateSets();
            //.Competition.Teams.TeamClumps[Model2.SelectedIndex].TeamSets[TS2.SelectedIndex].UpdateAsList(new Team[3] { (Team)TeamSet2.Items[0], (Team)TeamSet2.Items[1], (Team)TeamSet2.Items[2] });
            UpdateLists();
        }

        private void MoveDown2_Click(object sender, System.EventArgs e)
        {
            if (TeamSet2.SelectedItem != null)
            {
                Team T1;
                if (TeamSet2.SelectedIndex == 0)
                {
                    T1 = (Team)TeamSet2.Items[TeamSet2.SelectedIndex + 1];
                    TeamSet2.Items[1] = TeamSet2.SelectedItem;
                    TeamSet2.Items[0] = T1;
                    //TeamSet1.SelectedItem = TeamSet1.Items[2];
                }
                else if (TeamSet1.SelectedIndex == 1)
                {
                    T1 = (Team)TeamSet2.Items[TeamSet2.SelectedIndex + 1];
                    TeamSet2.Items[2] = TeamSet2.SelectedItem;
                    TeamSet2.Items[1] = T1;
                }
                else if (TeamSet1.SelectedIndex == 2)
                {
                    T1 = (Team)TeamSet2.Items[0];
                    TeamSet2.Items[0] = TeamSet2.SelectedItem;
                    TeamSet2.Items[2] = T1;
                }
                TimerSettings.Competition.Teams.TeamClumps[Model2.SelectedIndex].TeamSets[TS1.SelectedIndex].UpdateSets();
                //TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].UpdateAsList(new Team[3] { (Team)TeamSet1.Items[0], (Team)TeamSet1.Items[1], (Team)TeamSet1.Items[2] });
                TimerSettings.Competition.Teams.TeamClumps[Model2.SelectedIndex].TeamSets[TS2.SelectedIndex].UpdateAsList(new Team[3] { (Team)TeamSet2.Items[0], (Team)TeamSet2.Items[1], (Team)TeamSet2.Items[2] });
                TimerSettings.Competition.Teams.TeamClumps[Model2.SelectedIndex].TeamSets[TS2.SelectedIndex].UpdateSets();
                UpdateLists();
            }
        }

        private void AddTeamSet1_Click(object sender, System.EventArgs e)
        {

        }

        private void AddTeamSet2_Click(object sender, System.EventArgs e)
        {

        }

        private void DeleteTeamSet1_Click(object sender, System.EventArgs e)
        {

        }

        private void DeleteTeamSet2_Click(object sender, System.EventArgs e)
        {

        }

        private void Shuffle1_Click(object sender, System.EventArgs e)
        {
            TimerSettings.Competition.Teams.TeamClumps[Model.SelectedIndex].TeamSets[TS1.SelectedIndex].Shuffle();
            UpdateLists();
        }

        private void Shuffle2_Click(object sender, System.EventArgs e)
        {
            TimerSettings.Competition.Teams.TeamClumps[Model2.SelectedIndex].TeamSets[TS2.SelectedIndex].Shuffle();
            UpdateLists();
        }
    }
}
