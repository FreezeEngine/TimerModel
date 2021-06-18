using CompetitionOrganizer.Forms.Team_Managers;
using System;
using System.Windows.Forms;

namespace TimerModel.Forms
{
    public partial class CompetitionManager : Form
    {
        public CompetitionManager()
        {
            InitializeComponent();
            TopMost = true;
            UpdateFlyModelsList();
            RedrawTree();
            UpdateTeamsetsTree();

            LapsAmount.Maximum = Rules.MaxLaps;
            LapsAmount.Minimum = Rules.MinLaps;
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
        void RedrawTree()
        {
            MainTree.Nodes.Clear();
            MainTree.Nodes.Add("Соревнование");
            int c = 0;

            foreach (var TC in TimerSettings.Competition.Teams.TeamClumps)
            {
                MainTree.CheckBoxes = false;
                MainTree.Nodes[0].Nodes.Add("Между моделями: " + TC.CompetingModel + " | Количество команд: " + TC.Teams().Count);
                //MainTree.Nodes[0].Nodes[c].Nodes.Add("Туров в соревновании: " + TC.RoundsForThisClass.ToString());
                int d = 0;
                MainTree.Nodes[0].Nodes[c].Nodes.Add("Команды:");
                var Ts = TC.Teams();
                foreach (var T in Ts)
                {
                    MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes.Add(T.ToString());
                    MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes.Add("Текущий тур: " + (T.CurrentRoundNum + 1).ToString());
                    MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes.Add("Туры: ");
                    int b = 0;
                    //MessageBox.Show(T.Rounds.Count.ToString());
                    foreach (var TD in T.Rounds)
                    {
                        MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes.Add("Тур - " + (b + 1).ToString());
                        if (TD.Laps.Count == 0)
                        {
                            MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("В очереди");
                            b++;
                            continue;
                        }
                        MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("Круги:");
                        int e = 0;
                        foreach (var TL in TD.Laps)
                        {
                            MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes[0].Nodes.Add(TL.ToString());
                            e++;
                        }
                        MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("Время: " + TD.RoundTTime());
                        MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("Всего очков: " + TD.RoundPoints());

                        if (T.CurrentRound == TD)
                        {
                            if (!T.CurrentRound.Finished)
                            {
                                MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[T.CurrentRoundNum].Nodes.Clear();
                                MainTree.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[T.CurrentRoundNum].Nodes.Add("В ожидании");
                            }
                        }
                        b++;
                    }
                    d++;
                }
                c++;
            }
            MainTree.Nodes[0].Expand();

        }
        private void MainTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private void UpdateFlyModelsList()
        {
            FlyModelsList.Items.Clear();
            FlyModelsList.Text = null;
            FlyModelsList.Items.AddRange(TimerSettings.Competition.Teams.TeamClumps?.ToArray());
            if (TimerSettings.Competition.Teams.TeamClumps.Count != 0)
            {
                FlyModelsList.SelectedIndex = 0;
            }
            else
            {
                FlyModelsList.SelectedIndex = -1;
                FlyModelsList.Text = "Нет моделей";
            }
        }

        private void LapsCounter_ValueChanged(object sender, EventArgs e)
        {
            TimerSettings.Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].LapsCount = (byte)LapsAmount.Value;
            RedrawTree();
        }

        private void ChooseModelClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LapsAmount.Value = TimerSettings.Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].LapsCount;
        }

        private void EditTeamSets_Click(object sender, EventArgs e)
        {
            Hide();
            TeamSetEditor TSE = new TeamSetEditor();
            TSE.Show();
            TSE.FormClosing += (a, s) => { Show(); };
        }
    }
}
