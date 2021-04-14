using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TimerModel
{
    public partial class MainForm : Form
    {
        //private FlyModel[] FlyModels = new FlyModel[3];
        private Competition Competition;
        //private int Shift = 0;
        List<Team> Teams;

        private bool Printed = false;
        private bool AutoStart = true;
        //private bool First = false;

        private int RoundPointer = 1;
        private byte LC = ++TimerSettings.LapCount;
        bool Automatic;
        public MainForm(List<Team> Teams, bool automatic)   
        {
            this.Automatic = automatic;
            this.Teams = Teams;
            Competition = new Competition(Teams);
            InitializeComponent();

            TimeSpanTable1.RowCount = LC;
            TimeSpanTable2.RowCount = LC;
            TimeSpanTable3.RowCount = LC;
            LapTable.RowCount = LC;

            for (int i = 0; i < LC; i++)
            {
                TimeSpanTable1.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / LC));
                TimeSpanTable2.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / LC));
                TimeSpanTable3.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / LC));
                LapTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / LC));
            }
            if (Automatic)
            {
                NewSetOfTeams();
            }
        }
        
        private void NewSetOfTeams()
        {
            void TT()
            {
                Competition.Teams.NextSetOfTeams();           
            }
            TT();
            if (!Competition.Teams.First.Enabled && !Competition.Teams.Second.Enabled && !Competition.Teams.Third.Enabled)
            {
                RoundNum.Text = "Тур: " + RoundPointer++;
                Competition.Teams.Shift = 0;
                TT();
            }

            if (RoundPointer == TimerSettings.RoundCount + 1)
            {
                MessageBox.Show("Комады закончились!");
                //Print final result
                Hide();
                CompetitionReport ReportForm = new CompetitionReport();
                ReportForm.Show();
                ReportForm.FormClosed += (s,a) => Show();
                Close();
            }
            //MessageBox.Show(Competition.Teams.First.Enabled.ToString());
            TimeSpanTable1.BackColor = (Competition.Teams.First.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);
            TimeSpanTable2.BackColor = (Competition.Teams.Second.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);
            TimeSpanTable3.BackColor = (Competition.Teams.Third.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);

            Model1Pilots.Text = (Competition.Teams.First.Enabled) ? (Competition.Teams.First.Pilot + "\r\n" + ((Competition.Teams.First.Mechanic != null) ? (Competition.Teams.First.Mechanic) : ("Без механика"))) : ("Без команды");
            Model2Pilots.Text = (Competition.Teams.Second.Enabled) ? (Competition.Teams.Second.Pilot + "\r\n" + ((Competition.Teams.Second.Mechanic != null) ? (Competition.Teams.Second.Mechanic) : ("Без механика"))) : ("Без команды");
            Model3Pilots.Text = (Competition.Teams.Third.Enabled) ? (Competition.Teams.Third.Pilot + "\r\n" + ((Competition.Teams.Third.Mechanic != null)?(Competition.Teams.Third.Mechanic):("Без механика"))):("Без команды");

            Model1Label.Text = (Competition.Teams.First.Enabled) ? ((Competition.Teams.First.ModelName != null) ?(Competition.Teams.First.ModelName +" [1]") :("Модель 1")) : ("Отсутсвует");
            Model2Label.Text = (Competition.Teams.Second.Enabled) ? ((Competition.Teams.Second.ModelName != null) ? (Competition.Teams.Second.ModelName + " [2]") : ("Модель 2")) : ("Отсутсвует");
            Model3Label.Text = (Competition.Teams.Third.Enabled) ? ((Competition.Teams.Third.ModelName != null) ? (Competition.Teams.Third.ModelName + " [3]") : ("Модель 3")) : ("Отсутсвует");
        }
        private void FlyMiss1(object sender, EventArgs e)
        {
            FlyMissUpdate(0);
        }
        private void FlyMiss2(object sender, EventArgs e)
        {
            FlyMissUpdate(1);
        }
        private void FlyMiss3(object sender, EventArgs e)
        {
            FlyMissUpdate(2);
        }
        private Team GetTeam(int ModelNum)
        {
            Team Team = new Team();
            switch (ModelNum)
            {
                case 0:
                    Team = Competition.Teams.First;
                    break;
                case 1:

                    Team = Competition.Teams.Second;
                    break;
                case 2:

                    Team = Competition.Teams.Third;
                    break;
            }
            return Team;
        }
        private void FlyMissUpdate(int ModelNum)
        {
            decimal Value = 0;
            Team Team = new Team();
            switch (ModelNum)
            {
                case 0:
                    if (!Competition.Teams.First.Finished)
                    {
                        return;
                    }
                    Team = Competition.Teams.First;
                    break;
                case 1:
                    if (!Competition.Teams.Second.Finished)
                    {
                        return;
                    }
                    Team = Competition.Teams.Second;
                    break;
                case 2:
                    if (!Competition.Teams.Third.Finished)
                    {
                        return;
                    }
                    Team = Competition.Teams.Third;
                    break;
            }
            
            switch (ModelNum)
            {
                case 0:
                    Value = numericUpDown1.Value;
                    break;
                case 1:
                    Value = numericUpDown2.Value;
                    break;
                case 2:
                    Value = numericUpDown7.Value;
                    break;
            }
            if (Value == 1)
            {
                Team.FlyMisses = 1;
                Team.TotalPoints = Team.Points + (Team.Points * 0.10);
                
            }
            else
            {
                if (Value == 0)
                {
                    Team.FlyMisses = 0;
                    Team.TotalPoints = Team.Points;
                }
                else
                {
                    Team.FlyMisses = (byte)Value;
                    Team.TotalPoints = 200;
                }
            }
            UpdatePoints(Team, ModelNum);
        }
        private void UpdatePoints(Team Team, int ModelNum)
        {
            double Points = Team.TotalPoints;
            string TotalTime = Points.ToString("0.00").Replace(",", ".");
            switch (ModelNum)
            {
                case 0:
                    Competition.Teams.First.TotalPoints = Team.TotalPoints;
                    Result.Text = TotalTime;
                    break;
                case 1:
                    Competition.Teams.Second.TotalPoints = Team.TotalPoints;
                    Result2.Text = TotalTime;
                    break;
                case 2:
                    Competition.Teams.Third.TotalPoints = Team.TotalPoints;
                    Result3.Text = TotalTime;
                    break;
            }
        }
        private int ovPointer = 0;
        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            var T1 = GetTeam(0);
            var T2 = GetTeam(1);
            var T3 = GetTeam(2);
            void HandleButton(int ModelNum)
            {
                Team Team = GetTeam(ModelNum);
                if (!Team.Enabled)
                {
                    return;
                }
                if (Team.CurrentPointer < LC)
                {
                    if (Team.Finished)
                    {
                        return;
                    }
                    DateTime Time = DateTime.Now;
                    if (Team.CooldownIsUP(Time) == true)
                    {
                        int Pointer = Team.CurrentPointer;
                        
                        Label Label = Team.GetStopWatchLabel(Time, ModelNum);
                        if ((Pointer > ovPointer)&&ovPointer < LC)
                        {
                            LapTable.Controls.Add(new Label()
                            {
                                Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right))),
                                Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point),
                                Location = new Point(3, 78),
                                TextAlign = ContentAlignment.MiddleCenter,
                                Size = new Size(90, 373),
                                Name = "DD" + (ovPointer + 1),
                                Text = (ovPointer + 1).ToString()
                            }, 0, ovPointer+1);
                            ovPointer++;
                        }
                        switch (ModelNum)
                        {
                            case 0:
                                TimeSpanTable1.Controls.Add(Label, 0, Pointer);
                                break;
                            case 1:
                                TimeSpanTable2.Controls.Add(Label, 0, Pointer);
                                break;
                            case 2:
                                TimeSpanTable3.Controls.Add(Label, 0, Pointer);
                                break;
                        }
                        Team.CurrentPointer++;
                        if (Team.CurrentPointer == LC)
                        {
                            TimeSpan TTime = Team.GetOverAllTime(Time);
                            double Points = Math.Round(Convert.ToDouble(TTime.TotalSeconds), 3);
                            Team.TotalPoints = Points;
                            Team.Points = Points;
                            Team.Finished = true;
                            string TotalTime = Points.ToString("0.00").Replace(",",".");
                            switch (ModelNum)
                            {
                                case 0:
                                    Result.Text = TotalTime;
                                    FinishTime.Text = TTime.ToString();
                                    break;
                                case 1:
                                    Result2.Text = TotalTime;
                                    FinishTime2.Text = TTime.ToString();
                                    break;
                                case 2:
                                    Result3.Text = TotalTime;
                                    FinishTime3.Text = TTime.ToString();
                                    break;
                            }
                            
                            if ((T1.Finished | !T1.Enabled) && (T2.Finished | !T2.Enabled) && (T3.Finished | !T3.Enabled))
                                StopTimer();
                        }
                    }
                }
            }
            if (!Stopwatch.Started && Printed | AutoStart)
            {
                Printed = false;
                AutoStart = true;
                ClearTimer();
                StopTimer();
                //NewSetOfTeams();
                Stop.Enabled = true;
                Stopwatch.Started = true;
                Start.Enabled = false;
                Reset.Enabled = true;
                Stopwatch.Start();
                Timer.Start();
            }
            else
            {
                AutoStart = false;
            }
            if(Stopwatch.Started)
            switch (e.KeyChar)
            {
                case '1':
                        HandleButton(0);
                        break;
                case '2':
                        HandleButton(1);
                        break;
                case '3':
                        HandleButton(2);
                        break;
                default:
                    return;
            }
        }

        private void CloseProtection(Object sender, FormClosingEventArgs e)
        {
            var Close = MessageBox.Show("Вы уверены что хотите закрыть приложение?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Close == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerLabel.Text = Stopwatch.GetTime().ToString();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Stop.Enabled = true;
            AutoStart = false;
            ClearTimer();
            Stopwatch.Started = true;
            Start.Enabled = false;
            Reset.Enabled = true;
            Stopwatch.Start();
            Timer.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            ClearTimer();
            StopTimer();
            ResetTeamProgress();
        
        }
        public void ResetTeamProgress()
        {
            ovPointer = 0;
            Competition.Teams.First.Reset();
            Competition.Teams.Second.Reset();
            Competition.Teams.Third.Reset();
        }
        private void StopTimer()
        {
            Stop.Enabled = false;
            Stopwatch.Started = false;
            Timer.Stop();
            TimerLabel.Text = "Остановлено";
            Start.Enabled = true;
            Reset.Enabled = false;
        }
        private void ClearTimer()
        {
            ovPointer = 0;
            Result.Text = Result2.Text = Result3.Text = "";
            FinishTime.Text = FinishTime2.Text = FinishTime3.Text = "";
            TimeSpanTable1.Controls.Clear();
            TimeSpanTable2.Controls.Clear();
            TimeSpanTable3.Controls.Clear();
            LapTable.Controls.Clear();

            Printed = false;
        }

        private void Print_Click(object sender, EventArgs e)
        {
            var T1 = GetTeam(0);
            var T2 = GetTeam(1);
            var T3 = GetTeam(2);
            if ((T1.Enabled | T2.Enabled | T3.Enabled)&&!Stopwatch.Started&& (T1.Finished | T2.Finished | T3.Finished))
            {
                //ADD PRINT ON 1,2,3 keys CUZ IT OVERRIDES
                MessageBox.Show("PRINTING");
                Printed = true;
                AutoStart = true;
                NewSetOfTeams();
                ClearTimer();
                StopTimer();
            }
            else
            {
                MessageBox.Show("Не хватает данных для вывода на печать!");
            }
        }

        private void ChoosePilotsM1_Click(object sender, EventArgs e)
        {
            ChangePilot(0);
        }

        private void ChoosePilotsM2_Click(object sender, EventArgs e)
        {
            ChangePilot(1);
        }

        private void ChoosePilotsM3_Click(object sender, EventArgs e)
        {
            ChangePilot(2);
        }
        private void ChangePilot(int ModelNum)
        {
            //Hide();
            CreateListForm LF = new CreateListForm(true, Teams);
            //LF.Closed += (s, a) => { if() };
            LF.Show();
        }

        private void Stop_Click_1(object sender, EventArgs e)
        {
            var T1 = GetTeam(0);
            var T2 = GetTeam(1);
            var T3 = GetTeam(2);

            //ClearTimer();
            T1.Finished = true;
            T2.Finished = true;
            T3.Finished = true;

            Stop.Enabled = false;
            StopTimer();

            if (!T1.Finished && T1.Enabled)
            {
                Competition.Teams.First.TotalPoints = 200;
                Result.Text = "200.00";
                FinishTime.Text = "Недолёт";
            }
            if (!T2.Finished && T2.Enabled)
            {
                Competition.Teams.Second.TotalPoints = 200;
                Result2.Text = "200.00";
                FinishTime2.Text = "Недолёт";
            }
            if (!T3.Finished&&T3.Enabled)
            {
                Competition.Teams.Third.TotalPoints = 200;
                Result3.Text = "200.00";
                FinishTime3.Text = "Недолёт";
            }
        }
    }
}
