using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TimerModel.Forms
{
    public partial class CompetitionManager : Form
    {
        public CompetitionManager()
        {
            InitializeComponent();
            UpdateFlyModelsList();
            RedrawTree();
            RoundNum.Maximum = Rules.MaxRounds;
            LapsAmount.Maximum = Rules.MaxLaps;

            RoundNum.Minimum = Rules.MinRounds;
            LapsAmount.Minimum = Rules.MinLaps;
            //Competition.Teams.onTeamRemoved += RedrawTree;
            //Competition.Teams.onTeamAdded += RedrawTree;
        }
        void RedrawTree()
        {
            MainTree.Nodes.Clear();
            MainTree.Nodes.Add("Соревнование");
            int c = 0;

            foreach (var TC in Competition.Teams?.TeamClumps)
            {
                MainTree.CheckBoxes = false;
                MainTree.Nodes[0].Nodes.Add("Между моделями: " + TC.CompetingModel + " | Количество команд: " + TC.Teams.Count);
                MainTree.Nodes[0].Nodes[c].Nodes.Add("Туров в соревновании: " + TC.RoundsForThisClass.ToString());
                int d = 0;
                MainTree.Nodes[0].Nodes[c].Nodes.Add("Команды:");
                foreach (var T in TC.Teams)
                {
                    MainTree.Nodes[0].Nodes[c].Nodes[1].Nodes.Add(T.ToString());
                    MainTree.Nodes[0].Nodes[c].Nodes[1].Nodes[d].Nodes.Add("Текущий тур: " + (T.CurrentRoundNum + 1).ToString());
                    MainTree.Nodes[0].Nodes[c].Nodes[1].Nodes[d].Nodes.Add("Туры: ");
                    int b = 0;
                    bool first = true;
                    foreach (var TD in T?.Rounds)
                    {
                        MainTree.Nodes[0].Nodes[c].Nodes[1].Nodes[d].Nodes[1].Nodes.Add("Тур - " + (b + 1).ToString());
                        if (TD.Laps.Count == 0)
                        {
                            MainTree.Nodes[0].Nodes[c].Nodes[1].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("В очереди");
                            b++;
                            continue;
                        }
                        MainTree.Nodes[0].Nodes[c].Nodes[1].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("Круги:");
                        int e = 0;
                        foreach (var TL in TD?.Laps)
                        {
                            MainTree.Nodes[0].Nodes[c].Nodes[1].Nodes[d].Nodes[1].Nodes[b].Nodes[0].Nodes.Add(TL.ToString());
                            e++;
                        }
                        MainTree.Nodes[0].Nodes[c].Nodes[1].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("Время: " + TD.Time);
                        MainTree.Nodes[0].Nodes[c].Nodes[1].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("Всего очков: " + TD.TotalPoints);
                        b++;
                    }
                    if (!T.CurrentRound.Finished)
                    {
                        MainTree.Nodes[0].Nodes[c].Nodes[1].Nodes[d].Nodes[1].Nodes[T.CurrentRoundNum].Nodes.Clear();
                        MainTree.Nodes[0].Nodes[c].Nodes[1].Nodes[d].Nodes[1].Nodes[T.CurrentRoundNum].Nodes.Add("В ожидании");
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
            FlyModelsList.Items.AddRange(Competition.Teams.TeamClumps?.ToArray());
            if (Competition.Teams.TeamClumps.Count != 0)
            {
                FlyModelsList.SelectedIndex = 0;
            }
            else
            {
                FlyModelsList.SelectedIndex = -1;
                FlyModelsList.Text = "Нет моделей";
            }
        }
        private void RoundCounter_ValueChanged(object sender, EventArgs e)
        {
            Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].SetRoundsCount((int)RoundNum.Value);
            RedrawTree();
        }

        private void LapsCounter_ValueChanged(object sender, EventArgs e)
        {
            Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].LapsCount = (int)LapsAmount.Value;
            RedrawTree();
        }

        private void ChooseModelClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            RoundNum.Value = Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].RoundsForThisClass;
            LapsAmount.Value = Competition.Teams.TeamClumps[FlyModelsList.SelectedIndex].LapsCount;
        }
    }
}
