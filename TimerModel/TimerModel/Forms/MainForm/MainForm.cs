using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TimerModel.Forms.Setup_Forms;
using TimerModel.Objects.Reporting;

namespace TimerModel
{
    public partial class MainForm : Form
    {
        private bool Printed = false;
        private bool AutoStart = true;

        bool Automatic;
        public MainForm(bool automatic)
        {
            this.Automatic = automatic;
            InitializeComponent();
            Competition.Teams.onTeamChanged += UpdateTeamsData;
            Competition.Teams.onCompetitionFinished += () =>
            {
                FinalReport();
            };
            Competition.Teams.onTeamNewCycle += () =>
            {
                UpdateRoundCounters = false;

                if (RoundNum.Value + 1 > RoundNum.Maximum)
                {
                    RoundNum.Value = Competition.Teams.First.CurrentRoundNum + 1;
                }
                else
                {
                    RoundNum.Value++;
                }
                UpdateRoundCounters = true;
            };

            if (Automatic)
            {
                NewSetOfTeams();
            }
            else
            {
                Start.Enabled = false;
                TimeSpanTable1.BackColor = SystemColors.GrayText;
                TimeSpanTable3.BackColor = SystemColors.GrayText;
                TimeSpanTable2.BackColor = SystemColors.GrayText;
            }
        }
        private void UpdateRounds()
        {
            Competition.Teams.First.SelectRound((byte)M1Round.Value);
            Competition.Teams.Second.SelectRound((byte)M2Round.Value);
            Competition.Teams.Third.SelectRound((byte)M3Round.Value);
        }
        private void UpdateTabels()
        {
            TimeSpanTable1.Controls.Clear();
            TimeSpanTable2.Controls.Clear();
            TimeSpanTable3.Controls.Clear();
            LapTable.Controls.Clear();

            List<int> MaxRounds = new List<int>();
            foreach (var CM in Competition.Teams.TeamClumps)
            {
                MaxRounds.Add(CM.RoundsForThisClass);
            }
            RoundNum.Maximum = MaxRounds.ToArray().Max();

            int M1c = (Competition.Teams.First.CM != null) ? (Competition.Teams.First.CM.LapsCount) : (Rules.MinLaps);
            int M2c = (Competition.Teams.Second.CM != null) ? (Competition.Teams.Second.CM.LapsCount) : (Rules.MinLaps);
            int M3c = (Competition.Teams.Third.CM != null) ? (Competition.Teams.Third.CM.LapsCount) : (Rules.MinLaps);

            TimeSpanTable1.RowCount = M1c + 1;
            TimeSpanTable2.RowCount = M2c + 1;
            TimeSpanTable3.RowCount = M3c + 1;

            LapTable.RowCount = Competition.Teams.MaxLaps() + 1;

            for (int i = 0; i < TimeSpanTable1.RowCount; i++)
            {
                TimeSpanTable1.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / TimeSpanTable1.RowCount));
            }
            for (int i = 0; i < TimeSpanTable2.RowCount; i++)
            {
                TimeSpanTable2.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / TimeSpanTable2.RowCount));
            }
            for (int i = 0; i < TimeSpanTable3.RowCount; i++)
            {
                TimeSpanTable3.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / TimeSpanTable3.RowCount));
            }
            for (int i = 0; i < LapTable.RowCount; i++)
            {
                LapTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / LapTable.RowCount));
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
        void FinalReport()
        {
            PreFinishAsk PFA = new PreFinishAsk();
            PFA.FormClosing += (s, a) => { if (PFA.CloseForm) { Close(); } NewSetOfTeams(true); Show(); };
            Hide();
            PFA.Show();
        }
        private void NewSetOfTeams(bool Force = false)
        {
            if (Automatic | Force)
            {
                Competition.Teams.NextSetOfTeams();
            }
        }

        private void UpdateTeamsData()
        {
            M1Round.Enabled = Competition.Teams.First.Enabled;
            M2Round.Enabled = Competition.Teams.Second.Enabled;
            M3Round.Enabled = Competition.Teams.Third.Enabled;

            M1Round.Visible = Competition.Teams.First.Enabled;
            M2Round.Visible = Competition.Teams.Second.Enabled;
            M3Round.Visible = Competition.Teams.Third.Enabled;

            M1L1.Visible = Competition.Teams.First.Enabled;
            M2L1.Visible = Competition.Teams.Second.Enabled;
            M3L1.Visible = Competition.Teams.Third.Enabled;

            UpdateRoundCounters = false;
            if (M1Round.Enabled)
            {
                M1Round.Maximum = Competition.Teams.First.CM.RoundsForThisClass;
                M1Round.Value = Competition.Teams.First.CurrentRoundNum + 1;
            }

            if (M2Round.Enabled)
            {
                M2Round.Maximum = Competition.Teams.Second.CM.RoundsForThisClass;
                M2Round.Value = Competition.Teams.Second.CurrentRoundNum + 1;
            }

            if (M3Round.Enabled)
            {
                M3Round.Maximum = Competition.Teams.Third.CM.RoundsForThisClass;
                M3Round.Value = Competition.Teams.Third.CurrentRoundNum + 1;
            }
            UpdateRoundCounters = true;

            RoundNum.Maximum = Competition.Teams.MaxRounds();

            TimeSpanTable1.BackColor = (Competition.Teams.First.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);
            TimeSpanTable2.BackColor = (Competition.Teams.Second.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);
            TimeSpanTable3.BackColor = (Competition.Teams.Third.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);

            Model1Pilots.Text = (Competition.Teams.First.Enabled) ? (Competition.Teams.First.GetShortPilotName() + "\r\n" + Competition.Teams.First.GetShortMechanicName()) : ("Без команды");
            Model2Pilots.Text = (Competition.Teams.Second.Enabled) ? (Competition.Teams.Second.GetShortPilotName() + "\r\n" + Competition.Teams.Second.GetShortMechanicName()) : ("Без команды");
            Model3Pilots.Text = (Competition.Teams.Third.Enabled) ? (Competition.Teams.Third.GetShortPilotName() + "\r\n" + Competition.Teams.Third.GetShortMechanicName()) : ("Без команды");

            Model1Label.Text = (Competition.Teams.First.Enabled) ? ((Competition.Teams.First.ModelName != null) ? (Competition.Teams.First.ModelName + " [1]") : ("Модель 1")) : ("Отсутсвует");
            Model2Label.Text = (Competition.Teams.Second.Enabled) ? ((Competition.Teams.Second.ModelName != null) ? (Competition.Teams.Second.ModelName + " [2]") : ("Модель 2")) : ("Отсутсвует");
            Model3Label.Text = (Competition.Teams.Third.Enabled) ? ((Competition.Teams.Third.ModelName != null) ? (Competition.Teams.Third.ModelName + " [3]") : ("Модель 3")) : ("Отсутсвует");

            FM1FlyMiss1Point.Enabled = Competition.Teams.First.Enabled;
            FM1FlyMiss2Point.Enabled = Competition.Teams.First.Enabled;
            FM1FlyMiss3Point.Enabled = Competition.Teams.First.Enabled;

            FM2FlyMiss1Point.Enabled = Competition.Teams.Second.Enabled;
            FM2FlyMiss2Point.Enabled = Competition.Teams.Second.Enabled;
            FM2FlyMiss3Point.Enabled = Competition.Teams.Second.Enabled;

            FM3FlyMiss1Point.Enabled = Competition.Teams.Third.Enabled;
            FM3FlyMiss2Point.Enabled = Competition.Teams.Third.Enabled;
            FM3FlyMiss3Point.Enabled = Competition.Teams.Third.Enabled;

            ClearTimer();

            UpdateTabels();
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
                    if (!Competition.Teams.First.CurrentRound.Finished)
                    {
                        return;
                    }
                    Team = Competition.Teams.First;
                    Round = Team.CurrentRound;
                    Round.FlyMisses[0] = (byte)FM1FlyMiss1Point.Value;
                    Round.FlyMisses[1] = (byte)FM1FlyMiss2Point.Value;
                    Round.FlyMisses[2] = (byte)FM1FlyMiss3Point.Value;
                    break;
                case 1:
                    if (!Competition.Teams.Second.CurrentRound.Finished)
                    {
                        return;
                    }
                    Team = Competition.Teams.Second;
                    Round = Team.CurrentRound;
                    Round.FlyMisses[0] = (byte)FM2FlyMiss1Point.Value;
                    Round.FlyMisses[1] = (byte)FM2FlyMiss2Point.Value;
                    Round.FlyMisses[2] = (byte)FM2FlyMiss3Point.Value;
                    break;
                case 2:
                    if (!Competition.Teams.Third.CurrentRound.Finished)
                    {
                        return;
                    }
                    Team = Competition.Teams.Third;
                    Round = Team.CurrentRound;
                    Round.FlyMisses[0] = (byte)FM3FlyMiss1Point.Value;
                    Round.FlyMisses[1] = (byte)FM3FlyMiss2Point.Value;
                    Round.FlyMisses[2] = (byte)FM3FlyMiss3Point.Value;
                    break;
            }
            UpdatePoints(Round, ModelNum);
        }
        private void UpdatePoints(Round Round, int ModelNum)
        {
            if (Round.TotalPoints == 0.00)
            {
                return;
            }
            string TotalPoints = Round.TotalPoints.ToString("0.00").Replace(",", ".");

            switch (ModelNum)
            {
                case 0:
                    Result.Text = TotalPoints;
                    break;
                case 1:
                    Result2.Text = TotalPoints;
                    break;
                case 2:
                    Result3.Text = TotalPoints;
                    break;
            }
        }
        //private int ovPointer = 0;
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
        byte LapPointer = 1;
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
                if (Team.CurrentRound.Finished)
                {
                    return;
                }
                if (Automatic)
                {
                    if (RoundNum.Value > Team.Rounds.Count) //Never happening
                    {
                        return;
                    }
                }
                void R()
                {
                    string Points = Team.CurrentRound.RoundPoints();
                    string TotalTime = Team.CurrentRound.Time.ToString(@"m\:ss\:ff");
                    switch (ModelNum)
                    {
                        case 0:
                            Result.Text = Points;
                            FinishTime.Text = TotalTime;
                            break;
                        case 1:
                            Result2.Text = Points;
                            FinishTime2.Text = TotalTime;
                            break;
                        case 2:
                            Result3.Text = Points;
                            FinishTime3.Text = TotalTime;
                            break;
                    }

                    if ((T1.CurrentRound.Finished | !T1.Enabled) && (T2.CurrentRound.Finished | !T2.Enabled) && (T3.CurrentRound.Finished | !T3.Enabled) && !AllowRerun)
                    {
                        StopTimer();
                    }
                }
                if (Team.CurrentRound.Laps.Count == 0)
                {
                    Team.CurrentRound.onFinish += R; //REWORK
                }
                if (Team.CurrentRound.CooldownIsUP() == true)
                {

                    int RLC = Team.CurrentRound.Laps.Count;

                    if (RLC <= Team.CM.LapsCount + 1)
                    {
                        Competition.Lap(ModelNum);

                        if (Competition.Teams.First.CurrentRound.Laps.Count == LapPointer + 1 |
                           Competition.Teams.Second.CurrentRound.Laps.Count == LapPointer + 1 |
                           Competition.Teams.Third.CurrentRound.Laps.Count == LapPointer + 1)
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
                                Name = "DD" + RLC,
                                Text = RLC.ToString()
                            }, 0, RLC);
                            LapPointer++;
                        }

                        Label Label = Team.CurrentRound.GetStopWatchLabel();


                        switch (ModelNum)
                        {
                            case 0:
                                TimeSpanTable1.Controls.Add(Label, 0, RLC);
                                break;
                            case 1:
                                TimeSpanTable2.Controls.Add(Label, 0, RLC);
                                break;
                            case 2:
                                TimeSpanTable3.Controls.Add(Label, 0, RLC);
                                break;
                        }
                    }
                }
            }
            if ((!Stopwatch.Started && Printed | AutoStart | AllowRerun) && !(!T1.Enabled && !T2.Enabled && !T3.Enabled) && (e.KeyChar == '1' | e.KeyChar == '2' | e.KeyChar == '3'))
            {
                AutoStart = true;
                AllowRerun = false;

                ClearTimer();
                StopTimer();

                StartTimer();
            }
            else
            {
                AutoStart = false;
            }
            if (Stopwatch.Started)
            {
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
        }

        private void CloseProtection(Object sender, FormClosingEventArgs e)
        {
            var Close = MessageBox.Show("Вы уверены что хотите закрыть приложение?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Close == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            Environment.Exit(0);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerLabel.Text = Stopwatch.GetTime().ToString();
        }
        private void ChoosePilots(bool Enabled = false)
        {
            M1Round.Enabled = Enabled;
            M2Round.Enabled = Enabled;
            M3Round.Enabled = Enabled;
            RoundNum.Enabled = Enabled;
            ChoosePilotsM1.Enabled = Enabled;
            ChoosePilotsM3.Enabled = Enabled;
            ChoosePilotsM2.Enabled = Enabled;
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
            ResetTeamProgress();
            ClearTimer();
            StopTimer();
            AutoStart = true;
            Start.Enabled = true;
            Stop.Enabled = false;
            Reset.Enabled = false;
            ChoosePilots(true);
        }
        public void ResetTeamProgress()
        {
            Competition.Teams.Reset();
            //Reset finished round
        }
        private void StopTimer()
        {
            //if (!Automatic)
            //{
            //ChoosePilots();
            //}
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
            LapPointer = 1;
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
            if ((T1.CurrentRound.Finished | T2.CurrentRound.Finished | T3.CurrentRound.Finished) && !Stopwatch.Started)
            {
                //ADD PRINT ON 1,2,3 keys CUZ IT OVERRIDES
                Print.Enabled = false;
                //MessageBox desision
                if (!TimerSettings.NoPrePrintAsking)
                {
                    var PM = new PrintMode();
                    PM.Show();
                    PM.FormClosing += (s, a) => { PrintReport(); };
                }
                else
                {
                    PrintReport();
                }
                void PrintReport()
                {
                    RoundReport.MakeReport(TimerSettings.VerticalPrint);
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
                //RoundReport.Print

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
            CreateListForm LF = new CreateListForm(true);
            LF.Closing += (s, a) =>
            {
                if (LF.Choosen_Team != null)
                {
                    Start.Enabled = true;
                    switch (ModelNum)
                    {
                        case 0:
                            Competition.Teams.First = LF.Choosen_Team;
                            M1Round.Value = Competition.Teams.First.CurrentRoundNum + 1;
                            break;
                        case 1:
                            Competition.Teams.Second = LF.Choosen_Team;
                            M2Round.Value = Competition.Teams.Second.CurrentRoundNum + 1;
                            break;
                        case 2:
                            Competition.Teams.Third = LF.Choosen_Team;
                            M3Round.Value = Competition.Teams.Third.CurrentRoundNum + 1;
                            break;
                    }
                }
                if (LF.SomethingChanged)
                {
                    UpdateTeamsData();
                }
            };
            LF.Show();
        }

        private void Stop_Click_1(object sender, EventArgs e)
        {
            var T1 = GetTeam(0);
            var T2 = GetTeam(1);
            var T3 = GetTeam(2);

            T1.CurrentRound.Finish(!(T1.CurrentRound.Laps.Count - 1 < T1.CM.LapsCount && T1.Enabled));
            T2.CurrentRound.Finish(!(T2.CurrentRound.Laps.Count - 1 < T2.CM.LapsCount && T2.Enabled));
            T3.CurrentRound.Finish(!(T3.CurrentRound.Laps.Count - 1 < T3.CM.LapsCount && T3.Enabled));

            Stop.Enabled = false;
            StopTimer();
            Start.Enabled = false;

            if (T1.CurrentRound.Laps.Count - 1 < T1.CM.LapsCount && T1.Enabled)
            {
                T1.CurrentRound.TotalPoints = 200;
                Result.Text = "200.00";
                FinishTime.Text = "База не пройдена!";
            }
            if (T2.CurrentRound.Laps.Count - 1 < T2.CM.LapsCount && T2.Enabled)
            {
                T2.CurrentRound.TotalPoints = 200;
                Result2.Text = "200.00";
                FinishTime2.Text = "База не пройдена!";
            }
            if (T3.CurrentRound.Laps.Count - 1 < T3.CM.LapsCount && T3.Enabled)
            {
                T3.CurrentRound.TotalPoints = 200;
                Result3.Text = "200.00";
                FinishTime3.Text = "База не пройдена!";
            }
        }

        private void ForcedExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private bool UpdateRoundCounters = true;
        private void RoundNum_ValueChanged(object sender, EventArgs e)
        {
            if (UpdateRoundCounters)
            {
                if (RoundNum.Value <= M1Round.Maximum)
                {
                    M1Round.Value = RoundNum.Value;
                }
                if (RoundNum.Value <= M2Round.Maximum)
                {
                    M2Round.Value = RoundNum.Value;
                }
                if (RoundNum.Value <= M3Round.Maximum)
                {
                    M3Round.Value = RoundNum.Value;
                }
            }

            StopTimer();
            ClearTimer();
        }
        private bool AllowRerun = false;
        private void M1Round_ValueChanged(object sender, EventArgs e)
        {
            if (UpdateRoundCounters && M1Round.Enabled)
            {
                AllowRerun = true;
                Competition.Teams.First.SelectRound((byte)M1Round.Value);
            }
        }

        private void M2Round_ValueChanged(object sender, EventArgs e)
        {
            if (UpdateRoundCounters && M2Round.Enabled)
            {
                AllowRerun = true;
                Competition.Teams.Second.SelectRound((byte)M2Round.Value);
            }
        }

        private void M3Round_ValueChanged(object sender, EventArgs e)
        {
            if (UpdateRoundCounters && M3Round.Enabled)
            {
                AllowRerun = true;
                Competition.Teams.Third.SelectRound((byte)M3Round.Value);
            }
        }
    }
}
