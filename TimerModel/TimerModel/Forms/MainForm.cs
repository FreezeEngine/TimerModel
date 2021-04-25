using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TimerModel
{
    public partial class MainForm : Form
    {
        private Competition Competition;

        private bool Printed = false;
        private bool AutoStart = true;

        private byte LC = (byte)(TimerSettings.LapCount + 1);
        bool Automatic;
        public MainForm(List<Team> Teams, bool automatic)
        {

            this.Automatic = automatic;
            Competition = new Competition(Teams);
            //onNewRound
            Competition.Teams.onTeamChanged += UpdateTeamsData;

            InitializeComponent();
            Competition.Teams.onTeamNewCycle += () =>
            {
                if (Automatic)
                {
                    if (Competition.Round == TimerSettings.RoundCount)
                    {
                        ClearTimer();
                        if (Automatic)
                        {
                            PrintFinalReport();
                        }
                    }
                    else
                    {
                        RoundNum.Value = Competition.Round + 1;
                        NewSetOfTeams();
                    }
                }
            };

            RoundNum.Maximum = TimerSettings.RoundCount;

            TimeSpanTable1.RowCount = LC;
            TimeSpanTable3.RowCount = LC;
            TimeSpanTable2.RowCount = LC;
            LapTable.RowCount = LC;

            for (int i = 0; i < LC; i++)
            {
                TimeSpanTable1.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / LC));
                TimeSpanTable3.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / LC));
                TimeSpanTable2.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / LC));
                LapTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / LC));
            }
            if (Automatic)
            {
                ChoosePilots();
                NewSetOfTeams();
            }
            else
            {
                Competition.Round = (int)RoundNum.Value - 1;
                Start.Enabled = false;
                RoundNum.Enabled = true;
                TimeSpanTable1.BackColor = SystemColors.GrayText;
                TimeSpanTable3.BackColor = SystemColors.GrayText;
                TimeSpanTable2.BackColor = SystemColors.GrayText;
            }
        }
        private bool FullScreen = false;
        private void GoFullScreen(bool ScreenMode)
        {
            switch (ScreenMode)
            {
                case true:
                    TopMost = true;
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    break;
                case false:
                    TopMost = false;
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    break;
            }
        }
        void ResetFlyMissCounters()
        {
            FM1FlyMiss1Point.Value = 0;
            FM1FlyMiss2Point.Value = 0;
            FM1FlyMiss3Point.Value = 0;

            FM2FlyMiss1Point.Value = 0;
            FM2FlyMiss2Point.Value = 0;
            FM2FlyMiss3Point.Value = 0;

            FM3FlyMiss1Point.Value = 0;
            FM3FlyMiss2Point.Value = 0;
            FM3FlyMiss3Point.Value = 0;
        }
        void PrintFinalReport()
        {
            Hide();
            CompetitionReport CMPR = new CompetitionReport(Competition);
            CMPR.FormClosed += (s, a) => { Close(); };
            CMPR.Show();
        }
        private void NewSetOfTeams()
        {
            if (Automatic)
            {
                Competition.Teams.NextSetOfTeams();
            }
            UpdateTeamsData();
        }
        private void UpdateTeamsData()
        {

            TimeSpanTable1.BackColor = (Competition.Teams.First.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);
            TimeSpanTable3.BackColor = (Competition.Teams.Second.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);
            TimeSpanTable2.BackColor = (Competition.Teams.Third.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);

            Model1Pilots.Text = (Competition.Teams.First.Enabled) ? (Competition.Teams.First.Pilot + "\r\n" + ((Competition.Teams.First.Mechanic != null) ? (Competition.Teams.First.Mechanic) : ("Без механика"))) : ("Без команды");
            Model2Pilots.Text = (Competition.Teams.Second.Enabled) ? (Competition.Teams.Second.Pilot + "\r\n" + ((Competition.Teams.Second.Mechanic != null) ? (Competition.Teams.Second.Mechanic) : ("Без механика"))) : ("Без команды");
            Model3Pilots.Text = (Competition.Teams.Third.Enabled) ? (Competition.Teams.Third.Pilot + "\r\n" + ((Competition.Teams.Third.Mechanic != null) ? (Competition.Teams.Third.Mechanic) : ("Без механика"))) : ("Без команды");

            Model1Label.Text = (Competition.Teams.First.Enabled) ? ((Competition.Teams.First.ModelName != null) ? (Competition.Teams.First.ModelName + " [1]") : ("Модель 1")) : ("Отсутсвует");
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
            Team Team;
            Round Round = new Round();
            switch (ModelNum)
            {
                case 0:
                    if (!Competition.Teams.First.Finished)
                    {
                        return;
                    }
                    Team = Competition.Teams.First;
                    Round = Team.Rounds[Competition.Round];
                    Round.FlyMisses[0] = (byte)FM1FlyMiss1Point.Value;
                    Round.FlyMisses[1] = (byte)FM1FlyMiss2Point.Value;
                    Round.FlyMisses[2] = (byte)FM1FlyMiss3Point.Value;
                    break;
                case 1:
                    if (!Competition.Teams.Second.Finished)
                    {
                        return;
                    }
                    Team = Competition.Teams.Second;
                    Round = Team.Rounds[Competition.Round];
                    Round.FlyMisses[0] = (byte)FM2FlyMiss1Point.Value;
                    Round.FlyMisses[1] = (byte)FM2FlyMiss2Point.Value;
                    Round.FlyMisses[2] = (byte)FM2FlyMiss3Point.Value;
                    break;
                case 2:
                    if (!Competition.Teams.Third.Finished)
                    {
                        return;
                    }
                    Team = Competition.Teams.Third;
                    Round = Team.Rounds[Competition.Round];
                    Round.FlyMisses[0] = (byte)FM3FlyMiss1Point.Value;
                    Round.FlyMisses[1] = (byte)FM3FlyMiss2Point.Value;
                    Round.FlyMisses[2] = (byte)FM3FlyMiss3Point.Value;
                    break;
            }

            byte Value = Round.TotalFlyMisses();

            if (Value == 1)
            {
                Round.TotalPoints = Round.Points + (Round.Points * 0.10);
            }
            else
            {
                if (Value == 0)
                {
                    Round.TotalPoints = Round.Points;
                }
                else
                {
                    Round.TotalPoints = 200;
                }
            }
            UpdatePoints(Round, ModelNum);
        }
        private void UpdatePoints(Round Round, int ModelNum)
        {
            if (Round.TotalPoints == 0.00)
            {
                return;
            }
            string TotalTime = Round.TotalPoints.ToString("0.00").Replace(",", ".");

            switch (ModelNum)
            {
                case 0:
                    Result.Text = TotalTime;
                    break;
                case 1:
                    Result2.Text = TotalTime;
                    break;
                case 2:
                    Result3.Text = TotalTime;
                    break;
            }
        }
        private int ovPointer = 0;
        private void KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    GoFullScreen(false);
                    break;
                case Keys.F11:
                    FullScreen = !FullScreen;
                    GoFullScreen(FullScreen);
                    break;
            }
        }
        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            var T1 = GetTeam(0);
            var T2 = GetTeam(1);
            var T3 = GetTeam(2);

            void HandleButton(int ModelNum)
            {
                Team Team = GetTeam(ModelNum);
                if (Team.Finished)
                {
                    return;
                }
                if (Automatic)
                {
                    if (Competition.Round >= Team.Rounds.Count)
                    {
                        return;
                    }
                }
                if (Team.Rounds[Competition.Round].CooldownIsUP() == true)
                {
                    int RLC = Team.Rounds[Competition.Round].Laps.Count;
                    if (RLC <= TimerSettings.LapCount)
                    {
                        Competition.Lap(ModelNum);
                        Team = GetTeam(ModelNum);
                    }

                    if (!Team.Enabled)
                    {
                        return;
                    }
                    if (RLC < LC)
                    {
                        Team.Rounds[Competition.Round].onFinish += R; //REWORK
                        DateTime Time = DateTime.Now;
                        int Pointer = RLC;

                        Label Label = Team.Rounds[Competition.Round].GetStopWatchLabel();

                        if ((Pointer > ovPointer) && ovPointer < LC)
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
                            }, 0, ovPointer + 1);
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
                        //REWORK

                        void R()
                        {
                            TimeSpan TTime = Team.Rounds[Competition.Round].Time;
                            double Points = Math.Round(Convert.ToDouble(TTime.TotalSeconds), 3);
                            Team.Rounds[Competition.Round].TotalPoints = Points;
                            Team.Rounds[Competition.Round].Points = Points;
                            Team.Finished = true;
                            string TotalTime = Points.ToString("0.00").Replace(",", ".");
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
            if ((!Stopwatch.Started && Printed | AutoStart) && !(!T1.Enabled && !T2.Enabled && !T3.Enabled) && (e.KeyChar == '1' | e.KeyChar == '2' | e.KeyChar == '3'))
            {
                AutoStart = true;

                ClearTimer();
                StopTimer();

                StartTimer();
            }
            else
            {
                AutoStart = false;
            }
            if (Stopwatch.Started)
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
        private void ChoosePilots(bool Enabled = false)
        {
            ChoosePilotsM1.Enabled = Enabled;
            ChoosePilotsM2.Enabled = Enabled;
            ChoosePilotsM3.Enabled = Enabled;
        }
        private void Start_Click(object sender, EventArgs e)
        {
            StartTimer();
        }
        private void StartTimer()
        {
            Printed = false;
            AutoStart = false;
            ChoosePilots();
            Start.Enabled = false;
            Reset.Enabled = true;
            Print.Enabled = false;
            Stop.Enabled = true;

            ClearTimer();

            Stopwatch.Start();
            Stopwatch.Started = true;
            Timer.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            ClearTimer();
            StopTimer();
            AutoStart = true;
            Start.Enabled = true;
            Stop.Enabled = false;
            Reset.Enabled = false;
            ResetTeamProgress();

        }
        public void ResetTeamProgress()
        {
            ovPointer = 0;
            Competition.Teams.Reset();
        }
        private void StopTimer()
        {

            if (!Automatic)
            {
                ChoosePilots(true);
            }
            Stop.Enabled = false;
            Start.Enabled = false;
            Stopwatch.Started = false;
            Timer.Stop();
            TimerLabel.Text = "Остановлено";
            //Start.Enabled = true;
            //Reset.Enabled = false;
            Print.Enabled = true;

        }
        private void ClearTimer()
        {
            Printed = false;
            ovPointer = 0;
            if (!Automatic)
            {
                Competition.Teams.Reset();
            }
            Result.Text = Result2.Text = Result3.Text = "";
            FinishTime.Text = FinishTime2.Text = FinishTime3.Text = "";
            TimeSpanTable1.Controls.Clear();
            TimeSpanTable3.Controls.Clear();
            TimeSpanTable2.Controls.Clear();
            LapTable.Controls.Clear();
            ResetFlyMissCounters();
        }

        private async void Print_Click(object sender, EventArgs e)
        {
            var T1 = GetTeam(0);
            var T2 = GetTeam(1);
            var T3 = GetTeam(2);
            if ((T1.Enabled | T2.Enabled | T3.Enabled) && !Stopwatch.Started && (T1.Finished | T2.Finished | T3.Finished))
            {
                //ADD PRINT ON 1,2,3 keys CUZ IT OVERRIDES
                MessageBox.Show("PRINTING");
                Printed = true;
                AutoStart = true;
                ChoosePilots(true);
                if (Automatic)
                {
                    NewSetOfTeams();
                }
                StopTimer();
                ClearTimer();
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
            //Competition.Te

            CreateListForm LF = new CreateListForm(true, Competition.Teams.GetTeams());
            LF.Closing += (s, a) =>
            {
                if (LF.Choosen_Team != null)
                {
                    Start.Enabled = true;
                    switch (ModelNum)
                    {
                        case 0:
                            Competition.Teams.First = LF.Choosen_Team;
                            break;
                        case 1:
                            Competition.Teams.Second = LF.Choosen_Team;
                            break;
                        case 2:
                            Competition.Teams.Third = LF.Choosen_Team;
                            break;
                    }
                }
            };
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
            Start.Enabled = false;

            if (T1.Rounds[Competition.Round].Laps.Count - 1 < TimerSettings.LapCount && T1.Enabled)
            {
                Competition.Teams.First.Rounds[Competition.Round].TotalPoints = 200;
                Result.Text = "200.00";
                FinishTime.Text = "База не пройдена!";
            }
            if (T2.Rounds[Competition.Round].Laps.Count - 1 < TimerSettings.LapCount && T2.Enabled)
            {
                Competition.Teams.Second.Rounds[Competition.Round].TotalPoints = 200;
                Result2.Text = "200.00";
                FinishTime2.Text = "База не пройдена!";
            }
            if (T3.Rounds[Competition.Round].Laps.Count - 1 < TimerSettings.LapCount && T3.Enabled)
            {
                Competition.Teams.Third.Rounds[Competition.Round].TotalPoints = 200;
                Result3.Text = "200.00";
                FinishTime3.Text = "База не пройдена!";
            }
        }

        private void ForcedExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void RoundNum_ValueChanged(object sender, EventArgs e)
        {
            /*if (!Automatic) {
                Competition.Round = (int)RoundNum.Value - 1;
                if(Competition.Round != (int)RoundNum.Value)
                {
                    if(Competition.Round < (int)RoundNum.Value)
                    {

                    }
                    while(Competition.Round != (int)RoundNum.Value)
                    {
                        Competition.Teams.NextRound();
                    }
                    StopTimer();
                    Competition.Teams.Reset();
                }
            }*/
        }
    }
}
