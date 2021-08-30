using CompetitionOrganizer.Forms.Team_Managers;
using CompetitionOrganizer.Objects;
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
            TreeDrawer.DrawCompetitionStructure(MainTree);
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
