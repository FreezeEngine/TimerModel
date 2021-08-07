using CompetitionOrganizer.Forms.Team_Managers;
using CompetitionOrganizer.Objects;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TimerModel.Forms
{
    public partial class Settings : Form
    {
        public bool SomethingGotUpdated = false;
        public Settings()
        {
            InitializeComponent();
            TopMost = true;

            Print.Checked = TimerSettings.PrintingEnabled;
            DoubleClickProtection.Checked = TimerSettings.DoubleClickProtectionEnabled;
            FileGeneration.Checked = TimerSettings.PrintFileGeneration;
        }

        private void TestModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DevGroupBox.Enabled = TestModeCheckBox.Checked;
        }

        private void Print_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.PrintingEnabled = Print.Checked;
        }

        private void DoubleClickProtection_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.DoubleClickProtectionEnabled = DoubleClickProtection.Checked;
        }

        private void FileGeneration_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.PrintFileGeneration = FileGeneration.Checked;
        }

        private void OpenCompetitionManager_Click(object sender, EventArgs e)
        {
            Hide();
            CompetitionManager CM = new CompetitionManager();
            CM.Show();
            CM.FormClosing += (a, s) => { Show(); };
            SomethingGotUpdated = true;
        }

        private void EditTeamSets_Click(object sender, EventArgs e)
        {
            Hide();
            TeamSetEditor TSE = new TeamSetEditor();
            TSE.Show();
            TSE.FormClosing += (a, s) => { Show(); };
            SomethingGotUpdated = true;
        }

        private void EndCompetition_Click(object sender, EventArgs e)
        {
            var EndDialog = MessageBox.Show("Завершить соревнование?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (EndDialog == DialogResult.Yes)
            {
                Hide();
                TimerSettings.Competition.Finish();
                Close();
            }

        }

        private void RecoverData_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    List<Team> Teams = new List<Team>();
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    string pathd = TimerSettings.CurrentProjectFolder;
                    var BC = new Random().Next().ToString();
                    var TTP = Path.Combine(pathd, BC);

                    var dc = File.Create(TTP);
                    dc.Close();
                    foreach (var path in files)
                    {
                        //

                        var F = File.OpenRead(path);
                        var Package = new ExcelPackage(F);
                        F.Close();
                        var Workbook = Package.Workbook;
                        //if (Workbook.Worksheets.Count == 2|)
                        //{

                        byte mnum = 0;
                        byte shift = 0;
                        var Sheet = Workbook.Worksheets[Workbook.Worksheets.Count - 1];
                        if (Sheet.Cells[1, 1].Value != null)
                        {
                            for (; mnum < 3; mnum++)
                            {
                                shift = (byte)(mnum * 9);
                                if (Sheet.Cells[1, shift + 4].Value == null | Sheet.Cells[1, shift + 4].Value?.ToString() == "")
                                {
                                    continue;
                                }
                                byte round_num = (byte)(Convert.ToByte(Sheet.Cells[1, shift + 4].Value) - 1);

                                byte overallfm = (byte)(Convert.ToByte(Sheet.Cells[4, shift + 5].Value) + Convert.ToByte(Sheet.Cells[4, shift + 6].Value) + Convert.ToByte(Sheet.Cells[4, shift + 7].Value));
                                string model = Convert.ToString(Sheet.Cells[2, shift + 2].Value).Replace(".", " ");
                                string pilot = Convert.ToString(Sheet.Cells[3, shift + 2].Value).Replace(".", " ");
                                string mechanic = Convert.ToString(Sheet.Cells[4, shift + 2].Value).Replace(".", " ");
                                double timev = Convert.ToDouble(Sheet.Cells[15, shift + 2].Value);
                                double points = Convert.ToDouble(Sheet.Cells[15, shift + 6].Value.ToString().Replace(".", ","));
                                //MessageBox.Show(model + " " + pilot + " " + mechanic + " R-" + round_num + " FM-" + overallfm+" P-"+points.ToString());
                                var T = Teams.Find(delegate (Team T1) { return T1.Pilot.Name == pilot && T1.Mechanic.Name == mechanic && T1.ModelName == model; });
                                //var vb = new TimeSpan(0,0,0);
                                //vb.
                                //Rstart.
                                //TimeSpan s =;
                                var Round = new Round() { Finished = true, TimeD = timev, PointsD = points, FlyMisses = new byte[3] { overallfm, 0, 0 } };
                                void Fuckedup()
                                {
                                    string f = "\r\n" + path + " |||||" + model + " " + pilot + " " + mechanic + " R-" + round_num + " FM-" + overallfm + " P - " + points.ToString() + " -> P- " + Round.Points + " T - " + Round.TimeD + " FM - " + Round.TotalFlyMisses();
                                    File.AppendAllText(TTP, f);

                                }
                                if (T != null)
                                {
                                    if (T.Rounds.Count == round_num)
                                    {
                                        T.Rounds.Add(Round);
                                    }
                                    else if (T.Rounds.Count == round_num + 1)
                                    {
                                        if (T.Rounds[round_num].Finished)
                                        {
                                            Fuckedup();
                                        }
                                        T.Rounds[round_num] = Round;
                                    }
                                    else if (T.Rounds.Count < round_num + 1)
                                    {
                                        T.SetRoundsCount(round_num + 1);
                                        T.Rounds[round_num] = Round;
                                    }
                                }
                                else
                                {
                                    Teams.Add(new Team() { Pilot = new Participant() { Name = pilot }, Mechanic = new Participant() { Name = mechanic }, ModelName = model });
                                    T = Teams[^1];
                                    if (T.Rounds.Count == round_num)
                                    {
                                        T.Rounds.Add(Round);
                                    }
                                    else if (T.Rounds.Count == round_num + 1)
                                    {
                                        if (T.Rounds[round_num].Finished)
                                        {
                                            Fuckedup();
                                        }
                                        T.Rounds[round_num] = Round;
                                    }
                                    else if (T.Rounds.Count < round_num + 1)
                                    {
                                        T.SetRoundsCount(round_num + 1);
                                        T.Rounds[round_num] = Round;
                                    }

                                }
                            }
                            //if (Teams.Find())

                        }
                        else
                        {
                            MessageBox.Show("Файл потребуется внести вручную - " + path);
                            //continue;
                        }
                        //}
                    }
                    TimerSettings.Competition.Teams.AllTeams = Teams;
                    TimerSettings.Competition.Finish(true);

                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var T in TimerSettings.Competition.Teams.AllTeams)
            {
                T.SetRoundsCount(12);
                foreach (var R in T.Rounds)
                {
                    R.Finished = true;
                }
            }
            TimerSettings.Competition.Finish(true);
        }
    }
}
