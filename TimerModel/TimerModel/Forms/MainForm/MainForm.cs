using CompetitionOrganizer.Objects.Reporting;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TimerModel.Forms;
using TimerModel.Forms.Setup_Forms;
using TimerModel.Objects;
using TimerModel.Objects.Reporting;

namespace TimerModel
{
    public partial class MainForm : Form
    {
        //private bool Printed = false;
        private bool AutoStart = false;

        public MainForm()
        {
            //TimerSettings.Competition.Teams.GenerateTeamSets();
            InitializeComponent();

            //FIX
            //CMSwitcher.Text = TimerSettings.Competition.Teams.CurrentModel.ToString();
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //TopMost = true;
            TimerSettings.Competition.Teams.NextTeamSet(true);

            TimerSettings.Competition.Teams.onTeamChanged += UpdateTeamsData;
            TimerSettings.Competition.onCompetitionFinished += () =>
            {
                FinalReport();
            };
            TimerSettings.Competition.Teams.onTeamNewCycle += () =>
            {
                UpdateRoundCounters = false;

                if (RoundNum.Value + 1 > RoundNum.Maximum)
                {
                    RoundNum.Value = TimerSettings.Competition.Teams.First.CurrentRoundNum + 1; //????
                }
                else
                {
                    RoundNum.Value++;
                }
                UpdateRoundCounters = true;
            };

            //Start.Enabled = false;
            TimeSpanTable1.BackColor = SystemColors.GrayText;
            TimeSpanTable2.BackColor = SystemColors.GrayText;
            TimeSpanTable3.BackColor = SystemColors.GrayText;

            UpdateTeamsData();
        }

        private void UpdateRounds()
        {
            TimerSettings.Competition.Teams.First.SelectRound((byte)M1Round.Value);
            TimerSettings.Competition.Teams.Second.SelectRound((byte)M2Round.Value);
            TimerSettings.Competition.Teams.Third.SelectRound((byte)M3Round.Value);
        }
        private void UpdateTabels()
        {
            TimeSpanTable1.Controls.Clear();
            TimeSpanTable2.Controls.Clear();
            TimeSpanTable3.Controls.Clear();
            LapTable.Controls.Clear();

            RoundNum.Maximum = Rules.MaxRounds;

            int M1c = (TimerSettings.Competition.Teams.First.CM != null) ? (TimerSettings.Competition.Teams.First.CM.LapsCount) : (Rules.MinLaps);
            int M2c = (TimerSettings.Competition.Teams.Second.CM != null) ? (TimerSettings.Competition.Teams.Second.CM.LapsCount) : (Rules.MinLaps);
            int M3c = (TimerSettings.Competition.Teams.Third.CM != null) ? (TimerSettings.Competition.Teams.Third.CM.LapsCount) : (Rules.MinLaps);

            TimeSpanTable1.RowCount = M1c + 1;
            TimeSpanTable2.RowCount = M2c + 1;
            TimeSpanTable3.RowCount = M3c + 1;

            LapTable.RowCount = TimerSettings.Competition.Teams.MaxLaps() + 1;

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
                    TimerSettings.LabelsSize = 20F;
                    UpdateFontSize(4);
                    //GUIThreadSafe.SetAllControlsFontSize(this.Controls, 20);
                    break;
                case false:
                    TopMost = false;
                    //GUIThreadSafe.SetAllControlsFontSize(this.TimeSpanTable1, 12, false);
                    TimerSettings.LabelsSize = 12F;

                    UpdateFontSize(0);

                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    break;
            }
            void FontsSetup(Single MainFontSize = 9F, Single Mini = 8.25F, Single Middle = 12F, Single Big = 15F, Single SmallerBig = 14.25F, Single FlyMissPointers = 9F)
            {
                Font Nine = GetFont(MainFontSize);
                Model1Pilots.Font = Nine;
                Model2Pilots.Font = Nine;
                Model3Pilots.Font = Nine;

                Start.Font = Nine;
                Stop.Font = Nine;
                Start.Font = Nine;
                NextSetOfTeamsBTN.Font = Nine;
                Reset.Font = Nine;
                Print.Font = Nine;

                CMSwitcher.Font = Nine;

                Font Fifteen = GetFont(Big);
                Model1Label.Font = Fifteen;
                Model2Label.Font = Fifteen;
                Model3Label.Font = Fifteen;

                Font Eight = GetFont(Mini);
                M1L1.Font = Eight;
                M2L1.Font = Eight;
                M3L1.Font = Eight;

                M1Round.Font = Nine;
                M2Round.Font = Nine;
                M3Round.Font = Nine;
                RoundNum.Font = Nine;

                Font FMP = GetFont(FlyMissPointers);
                FM1FlyMiss1Point.Font = FMP;
                FM1FlyMiss2Point.Font = FMP;
                FM1FlyMiss3Point.Font = FMP;

                FM2FlyMiss1Point.Font = FMP;
                FM2FlyMiss2Point.Font = FMP;
                FM2FlyMiss3Point.Font = FMP;

                FM3FlyMiss1Point.Font = FMP;
                FM3FlyMiss2Point.Font = FMP;
                FM3FlyMiss3Point.Font = FMP;

                FinishTime.Font = Nine;
                FinishTime2.Font = Nine;
                FinishTime3.Font = Nine;

                Result.Font = Nine;
                Result2.Font = Nine;
                Result3.Font = Nine;

                MissFlyLabel.Font = Nine;

                //NextInOrder.Font = Nine;
                //SecondInOrder.Font = Nine;

                Font Forteen = GetFont(SmallerBig);

                TimerNameLabel.Font = Forteen;
                TimerLabel.Font = Forteen;

                TimerSettings.LabelsSize = Middle;
                Font Dynamic = GetFont(TimerSettings.LabelsSize);

                FinishTime.Font = Dynamic;
                FinishTime2.Font = Dynamic;
                FinishTime3.Font = Dynamic;

                Result.Font = Dynamic;
                Result2.Font = Dynamic;
                Result3.Font = Dynamic;

                RoundLabel.Font = Dynamic;
                TimeLabel.Font = Dynamic;
            }
            Font GetFont(Single Size)
            {
                return new Font("Segoe UI", Size, FontStyle.Regular, GraphicsUnit.Point);
            }
            void UpdateFontSize(byte Mode)
            {

                switch (Mode)
                {
                    case 0:
                        FontsSetup();
                        break;
                    case 1:
                        FontsSetup(10F, 9F, 14F, 15F, 15F, 14F);
                        break;
                    case 2:
                        FontsSetup(11F, 10F, 16F, 16F, 15.3F, 15F);
                        break;
                    case 3:
                        FontsSetup(14F, 11F, 18F, 16F, 15.6F, 17F);
                        break;
                    case 4:
                        FontsSetup(16F, 12F, 20F, 16F, 16F, 20F);
                        break;
                }

                var NewSize = GetFont(TimerSettings.LabelsSize);

                void UpdateSize(Control C)
                {
                    C.Font = NewSize;
                }

                foreach (Control C in TimeSpanTable1.Controls)
                {
                    UpdateSize(C);
                }
                foreach (Control C in TimeSpanTable3.Controls)
                {
                    UpdateSize(C);
                }
                foreach (Control C in TimeSpanTable2.Controls)
                {
                    UpdateSize(C);
                }
                foreach (Control C in LapTable.Controls)
                {
                    UpdateSize(C);
                }

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
            //CHANGE
            //SAVE NAMES
            PFA.FormClosing += (s, a) => { if (PFA.CloseForm) { Close(); } /*RoundNum.Visible = false; RoundLabel.Visible = false; /*NewSetOfTeams();*/ Show(); };
            Hide();
            PFA.Show();
        }
        private void NewSetOfTeams()
        {
            ChoosePilots(true);
            TimerSettings.Competition.Teams.NextTeamSet();
            //UpdateTeamsData();
        }

        private void loadRoundData()
        {
            var CTS = new Team[3] { GetTeam(0), GetTeam(1), GetTeam(2) };
            byte i = 0;
            foreach (var T in CTS)
            {
                byte b = 0;
                if (!T.Enabled)
                {
                    i++;
                    continue;
                }

                //byte Round = 0;
                var R = T.CurrentRound;
                if (!R.Finished)
                {
                    i++;
                    continue;
                }



                switch (i)
                {
                    case 0:
                        FM1FlyMiss1Point.Value = R.FlyMisses[0];
                        FM1FlyMiss2Point.Value = R.FlyMisses[1];
                        FM1FlyMiss3Point.Value = R.FlyMisses[2];
                        FinishTime.Text = R.RoundTTime();
                        Result.Text = R.RoundPoints();
                        //Round = (byte)(M1Round.Value - 1);
                        break;
                    case 1:
                        FM2FlyMiss1Point.Value = R.FlyMisses[0];
                        FM2FlyMiss2Point.Value = R.FlyMisses[1];
                        FM2FlyMiss3Point.Value = R.FlyMisses[2];
                        FinishTime2.Text = R.RoundTTime();
                        Result2.Text = R.RoundPoints();
                        //Round = (byte)(M1Round.Value - 1);
                        break;
                    case 2:
                        FM3FlyMiss1Point.Value = R.FlyMisses[0];
                        FM3FlyMiss2Point.Value = R.FlyMisses[1];
                        FM3FlyMiss3Point.Value = R.FlyMisses[2];
                        FinishTime3.Text = R.RoundTTime();
                        Result3.Text = R.RoundPoints();
                        //Round = (byte)(M1Round.Value - 1);
                        break;
                }

                foreach (var L in R.Laps)
                {
                    Label Label = R.GetStopWatchLabel(b);
                    switch (i)
                    {
                        case 0:
                            TimeSpanTable1.Controls.Add(Label, 0, b);
                            break;
                        case 1:
                            TimeSpanTable2.Controls.Add(Label, 0, b);
                            break;
                        case 2:
                            TimeSpanTable3.Controls.Add(Label, 0, b);
                            break;
                    }
                    b++;
                }
                i++;
            }

        }
        private void UpdateTeamsData()
        {
            NT1.Text = "";
            NT2.Text = "";
            NT3.Text = "";
            NT4.Text = "";
            NT5.Text = "";
            NT6.Text = "";
            var Teams = TimerSettings.Competition.Teams;

            M1Round.Enabled = Teams.First.Enabled;
            M2Round.Enabled = Teams.Second.Enabled;
            M3Round.Enabled = Teams.Third.Enabled;

            M1Round.Visible = Teams.First.Enabled;
            M2Round.Visible = Teams.Second.Enabled;
            M3Round.Visible = Teams.Third.Enabled;

            M1L1.Visible = Teams.First.Enabled;
            M2L1.Visible = Teams.Second.Enabled;
            M3L1.Visible = Teams.Third.Enabled;

            Start.Enabled = true;

            UpdateRoundCounters = false;

            CMSwitcher.Items.Clear();
            CMSwitcher.Items.AddRange(Teams.TeamClumps?.ToArray());
            CMSwitcher.SelectedItem = Teams.CurrentModel;

            //Teams.First.CurrentRoundNum = (byte)(RoundNum.Value - 1);
            //Teams.Second.CurrentRoundNum = (byte)(RoundNum.Value - 1);
            //Teams.Third.CurrentRoundNum = (byte)(RoundNum.Value - 1);

            if (M1Round.Enabled)
            {
                M1Round.Maximum = Teams.MaxRounds();
                M1Round.Value = Teams.First.CurrentRoundNum + 1;
            }

            if (M2Round.Enabled)
            {
                M2Round.Maximum = Teams.MaxRounds();
                M2Round.Value = Teams.Second.CurrentRoundNum + 1;
            }

            if (M3Round.Enabled)
            {
                M3Round.Maximum = Teams.MaxRounds();
                M3Round.Value = Teams.Third.CurrentRoundNum + 1;
            }
            UpdateRoundCounters = true;

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

            RoundNum.Maximum = Teams.MaxRounds();

            TimeSpanTable1.BackColor = (Teams.First.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);
            TimeSpanTable2.BackColor = (Teams.Second.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);
            TimeSpanTable3.BackColor = (Teams.Third.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);

            Model1Pilots.Text = (Teams.First.Enabled) ? (Teams.First.Pilot.ShortenName() + "\r\n" + Teams.First.Mechanic.ShortenName()) : ("Без команды");
            Model2Pilots.Text = (Teams.Second.Enabled) ? (Teams.Second.Pilot.ShortenName() + "\r\n" + Teams.Second.Mechanic.ShortenName()) : ("Без команды");
            Model3Pilots.Text = (Teams.Third.Enabled) ? (Teams.Third.Pilot.ShortenName() + "\r\n" + Teams.Third.Mechanic.ShortenName()) : ("Без команды");

            var CM = Teams.CurrentModel;
            //var TD = Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex];
            if (CM.TeamSets.Count - 1 != CM.CurrentTeamSetIndex)
            {
                NT1.Text = (Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 1].First.Enabled ? Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 1].First.Pilot.ShortenName() + " | " + Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 1].First.Mechanic.ShortenName() : "Без команды");
                NT2.Text = (Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 1].Second.Enabled ? Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 1].Second.Pilot.ShortenName() + " | " + Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 1].Second.Mechanic.ShortenName() : "Без команды");
                NT3.Text = (Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 1].Third.Enabled ? Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 1].Third.Pilot.ShortenName() + " | " + Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 1].Third.Mechanic.ShortenName() : "Без команды");

                if (CM.TeamSets.Count - 2 != CM.CurrentTeamSetIndex)
                {
                    NT4.Text = (Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 2].First.Enabled ? Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 2].First.Pilot.ShortenName() + " | " + Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 2].First.Mechanic.ShortenName() : "Без команды");
                    NT5.Text = (Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 2].Second.Enabled ? Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 2].Second.Pilot.ShortenName() + " | " + Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 2].Second.Mechanic.ShortenName() : "Без команды");
                    NT6.Text = (Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 2].Third.Enabled ? Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 2].Third.Pilot.ShortenName() + " | " + Teams.CurrentModel.TeamSets[Teams.CurrentModel.CurrentTeamSetIndex + 2].Third.Mechanic.ShortenName() : "Без команды");
                }
            }

            Model1Label.Text = (Teams.First.Enabled) ? ((Teams.First.ModelName != null) ? (Teams.First.ModelName + " [1]") : ("Модель 1")) : ("Отсутсвует");
            Model2Label.Text = (Teams.Second.Enabled) ? ((Teams.Second.ModelName != null) ? (Teams.Second.ModelName + " [2]") : ("Модель 2")) : ("Отсутсвует");
            Model3Label.Text = (Teams.Third.Enabled) ? ((Teams.Third.ModelName != null) ? (Teams.Third.ModelName + " [3]") : ("Модель 3")) : ("Отсутсвует");

            FM1FlyMiss1Point.Enabled = Teams.First.Enabled;
            FM1FlyMiss2Point.Enabled = Teams.First.Enabled;
            FM1FlyMiss3Point.Enabled = Teams.First.Enabled;

            FM2FlyMiss1Point.Enabled = Teams.Second.Enabled;
            FM2FlyMiss2Point.Enabled = Teams.Second.Enabled;
            FM2FlyMiss3Point.Enabled = Teams.Second.Enabled;

            FM3FlyMiss1Point.Enabled = Teams.Third.Enabled;
            FM3FlyMiss2Point.Enabled = Teams.Third.Enabled;
            FM3FlyMiss3Point.Enabled = Teams.Third.Enabled;

            ClearTimer();

            UpdateTabels();
            loadRoundData();
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
            Team Team = new Team(true);
            switch (ModelNum)
            {
                case 0:
                    Team = TimerSettings.Competition.Teams.First;
                    break;
                case 1:

                    Team = TimerSettings.Competition.Teams.Second;
                    break;
                case 2:
                    Team = TimerSettings.Competition.Teams.Third;
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
                    if (!TimerSettings.Competition.Teams.First.CurrentRound.Finished)
                    {
                        return;
                    }
                    Team = TimerSettings.Competition.Teams.First;
                    Round = Team.CurrentRound;
                    Round.FlyMisses[0] = (byte)FM1FlyMiss1Point.Value;
                    Round.FlyMisses[1] = (byte)FM1FlyMiss2Point.Value;
                    Round.FlyMisses[2] = (byte)FM1FlyMiss3Point.Value;
                    break;
                case 1:
                    if (!TimerSettings.Competition.Teams.Second.CurrentRound.Finished)
                    {
                        return;
                    }
                    Team = TimerSettings.Competition.Teams.Second;
                    Round = Team.CurrentRound;
                    Round.FlyMisses[0] = (byte)FM2FlyMiss1Point.Value;
                    Round.FlyMisses[1] = (byte)FM2FlyMiss2Point.Value;
                    Round.FlyMisses[2] = (byte)FM2FlyMiss3Point.Value;
                    break;
                case 2:
                    if (!TimerSettings.Competition.Teams.Third.CurrentRound.Finished)
                    {
                        return;
                    }
                    Team = TimerSettings.Competition.Teams.Third;
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
        private void F11KeyDown(object sender, KeyEventArgs e)
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

                void R()
                {
                    string Points = Team.CurrentRound.RoundPoints();
                    string TotalTime = Team.CurrentRound.RoundTTime();
                    //Team.CurrentRound.RoundTime(); //To save data
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

                    if (((T1.CurrentRound.Finished && T1.Enabled) | !T1.Enabled) && ((T2.CurrentRound.Finished && T2.Enabled) | !T2.Enabled) && ((T3.CurrentRound.Finished && T3.Enabled) | !T3.Enabled)) //&& !AllowRerun
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
                        TimerSettings.Competition.Lap(ModelNum);

                        if (TimerSettings.Competition.Teams.First.CurrentRound?.Laps.Count == LapPointer + 1 |
                           TimerSettings.Competition.Teams.Second.CurrentRound?.Laps.Count == LapPointer + 1 |
                           TimerSettings.Competition.Teams.Third.CurrentRound?.Laps.Count == LapPointer + 1)
                        {
                            LapTable.Controls.Add(new Label()
                            {
                                Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right))),
                                Font = new Font("Segoe UI", TimerSettings.LabelsSize, FontStyle.Regular, GraphicsUnit.Point),

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
            if ((!Stopwatch.Started && AutoStart) && !(!T1.Enabled && !T2.Enabled && !T3.Enabled) && (e.KeyChar == '1' | e.KeyChar == '2' | e.KeyChar == '3'))
            {
                //AutoStart = false;
                //AllowRerun = false;

                ClearTimer();
                StopTimer();

                StartTimer();
            }
            //else
            //{
            //    AutoStart = false;
            //}
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
            ChoosePilotsM2.Enabled = Enabled;
            ChoosePilotsM3.Enabled = Enabled;
        }
        private void Start_Click(object sender, EventArgs e)
        {
            StartTimer();
        }
        private void StartTimer()
        {
            //Printed = false;
            NextSetOfTeamsBTN.Enabled = false;
            AutoStart = true;
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

        private void Reset_Click(object sender, EventArgs e)
        {
            var ResetDialog = MessageBox.Show("Вы уверены что хотите сбросить данные о текущм туре?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResetDialog == DialogResult.Yes)
            {
                ResetTeamProgress();
                ClearTimer();
                StopTimer();
                //AutoStart = false;
                Start.Enabled = true;
                Stop.Enabled = false;
                Reset.Enabled = false;
                ChoosePilots(true);
                return;
            }
        }
        public void ResetTeamProgress()
        {
            TimerSettings.Competition.Teams.Reset();
            //Reset finished round
        }
        private void StopTimer()
        {
            //if (!Automatic)
            //{
            ChoosePilots();
            //}
            AutoStart = false;
            Stop.Enabled = false;
            //Start.Enabled = false;
            Stopwatch.Started = false;
            Timer.Stop();
            TimerLabel.Text = "Остановлен";
            Start.Enabled = true;
            //Reset.Enabled = false;
            Print.Enabled = true;
            NextSetOfTeamsBTN.Enabled = true;

        }
        private void ClearTimer()
        {
            //Printed = false;
            //NextSetOfTeamsBTN.Enabled = false;
            LapPointer = 1;
            Result.Text = Result2.Text = Result3.Text = "";
            FinishTime.Text = FinishTime2.Text = FinishTime3.Text = "";
            TimeSpanTable1.Controls.Clear();
            TimeSpanTable2.Controls.Clear();
            TimeSpanTable3.Controls.Clear();
            LapTable.Controls.Clear();
            ResetFlyMissCounters();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            var T1 = GetTeam(0);
            var T2 = GetTeam(1);
            var T3 = GetTeam(2);
            if ((T1.CurrentRound.Finished | T2.CurrentRound.Finished | T3.CurrentRound.Finished) && !Stopwatch.Started)
            {
                Print.Enabled = false;
                ChoosePilots(true);
                void PrintReport()
                {
                    var Print = new Thread(new ThreadStart(() =>
                    {
                        RoundReport.MakeReport();
                    }));
                    Print.IsBackground = true;
                    Print.Start();

                    //NewSetOfTeams();
                    StopTimer();
                    //ClearTimer();
                }
                void PrintFunc()
                {
                    if (!TimerSettings.NoPrePrintAsking)
                    {
                        var PM = new PrintModeSelector();
                        PM.Show();
                        PM.FormClosing += (s, a) => { PrintReport(); };
                    }
                    else
                    {
                        PrintReport();
                    }
                    //Might be deleted. Just allow any num of prints

                }
                PrintFunc();
                BGSaver.SaveData();
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
            ChoosePilots();
            LF.Closing += (s, a) =>
            {
                if (LF.Choosen_Team != null)
                {
                    Start.Enabled = true;
                    switch (ModelNum)
                    {
                        case 0:
                            TimerSettings.Competition.Teams.First = LF.Choosen_Team;
                            M1Round.Value = TimerSettings.Competition.Teams.First.CurrentRoundNum + 1;
                            break;
                        case 1:
                            TimerSettings.Competition.Teams.Second = LF.Choosen_Team;
                            M2Round.Value = TimerSettings.Competition.Teams.Second.CurrentRoundNum + 1;
                            break;
                        case 2:
                            TimerSettings.Competition.Teams.Third = LF.Choosen_Team;
                            M3Round.Value = TimerSettings.Competition.Teams.Third.CurrentRoundNum + 1;
                            break;
                    }
                }
                ChoosePilots(true);
                if (LF.SomethingChanged)
                {

                    UpdateTeamsData();
                }
                BGSaver.SaveData();
            };
            LF.Show();
        }

        private void Stop_Click_1(object sender, EventArgs e)
        {
            var T1 = GetTeam(0);
            var T2 = GetTeam(1);
            var T3 = GetTeam(2);
            if (T1.Enabled)
                T1.CurrentRound.Finish(!(T1.CurrentRound.Laps.Count - 1 < T1.CM.LapsCount && T1.Enabled));
            if (T2.Enabled)
                T2.CurrentRound.Finish(!(T2.CurrentRound.Laps.Count - 1 < T2.CM.LapsCount && T2.Enabled));
            if (T3.Enabled)
                T3.CurrentRound.Finish(!(T3.CurrentRound.Laps.Count - 1 < T3.CM.LapsCount && T3.Enabled));

            Stop.Enabled = false;
            StopTimer();
            //Start.Enabled = false;
            if (T1.Enabled)
                if (T1.CurrentRound.Laps.Count - 1 < T1.CM.LapsCount && T1.Enabled)
                {
                    T1.CurrentRound.BadFinish = true;
                    Result.Text = "200.00";
                    FinishTime.Text = "База не пройдена!";
                }
            if (T2.Enabled)
                if (T2.CurrentRound.Laps.Count - 1 < T2.CM.LapsCount && T2.Enabled)
                {
                    T2.CurrentRound.BadFinish = true;
                    Result2.Text = "200.00";
                    FinishTime2.Text = "База не пройдена!";
                }
            if (T3.Enabled)
                if (T3.CurrentRound.Laps.Count - 1 < T3.CM.LapsCount && T3.Enabled)
                {
                    T3.CurrentRound.BadFinish = true;
                    Result3.Text = "200.00";
                    FinishTime3.Text = "База не пройдена!";
                }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Settings.Enabled = false;
            Settings ST = new Settings();
            ST.FormClosing += (s, a) => { Settings.Enabled = true; };
            ST.Show();
        }

        private bool UpdateRoundCounters = true;
        private void RoundNum_ValueChanged(object sender, EventArgs e)
        {
            var RoundSwitchingDialog = MessageBox.Show("Вы уверены что хотите сменить тур?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (RoundSwitchingDialog == DialogResult.Yes)
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
                    //TimerSettings.Competition.Teams.CurrentModel.CurrentTeamset.First.CurrentRoundNum = 
                }
                StopTimer();
                ChoosePilots(true);
                //ClearTimer();
                UpdateTeamsData();
                return;
            }
        }
        //private bool AllowRerun = false;
        private void M1Round_ValueChanged(object sender, EventArgs e)
        {
            if (UpdateRoundCounters && M1Round.Enabled)
            {
                //AllowRerun = true;
                TimerSettings.Competition.Teams.First.SelectRound((byte)M1Round.Value);
                UpdateTeamsData();
            }
        }

        private void M2Round_ValueChanged(object sender, EventArgs e)
        {
            if (UpdateRoundCounters && M2Round.Enabled)
            {
                //AllowRerun = true;
                TimerSettings.Competition.Teams.Second.SelectRound((byte)M2Round.Value);
                UpdateTeamsData();
            }
        }

        private void M3Round_ValueChanged(object sender, EventArgs e)
        {
            if (UpdateRoundCounters && M3Round.Enabled)
            {
                //AllowRerun = true;
                TimerSettings.Competition.Teams.Third.SelectRound((byte)M3Round.Value);
                UpdateTeamsData();
            }
        }

        private void NextSetOfTeamsBTN_Click(object sender, EventArgs e)
        {
            var ResetDialog = MessageBox.Show("Перейти к следующей тройке?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResetDialog == DialogResult.Yes)
            {
                NewSetOfTeams();
                //TimerSettings.Competition.Teams.NextRound();
            }
        }

        private void CMSwitcher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UpdateRoundCounters)
            {
                var ResetDialog = MessageBox.Show("Перейти к другим моделям?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ResetDialog == DialogResult.Yes)
                {
                    TimerSettings.Competition.Teams.CurrentModel = (CompetingModels)CMSwitcher.SelectedItem;
                    TimerSettings.Competition.Teams.NextTeamSet(true);
                }
                else
                {
                    CMSwitcher.SelectedItem = TimerSettings.Competition.Teams.CurrentModel;
                }
            }
        }
    }
}
