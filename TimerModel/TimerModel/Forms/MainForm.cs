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

            Competition.Teams.onTeamNewCycle += () =>
            {
                if (Competition.Round == TimerSettings.RoundCount)
                {
                    PrintFinalReport();
                }
                else
                {
                    RoundNum.Text = "Тур: " + (Competition.Round + 1).ToString();
                    NewSetOfTeams();
                }
            };
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
                ChoosePilotsM1.Enabled = false;
                ChoosePilotsM2.Enabled = false;
                ChoosePilotsM3.Enabled = false;
                NewSetOfTeams();
            }
            else
            {
                Competition.Teams.onTeamChanged += NewSetOfTeams;
            }
        }
        void PrintFinalReport()
        {
            //Add report settings
            Stream Stream;
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Title = "Сохранить список команд";
            SaveFile.InitialDirectory = @"C:\";
            SaveFile.Filter = "Таблица Excel (*.xlsx)|*.xlsx";
            SaveFile.FilterIndex = 0;
            SaveFile.RestoreDirectory = true;

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((Stream = SaveFile.OpenFile()) != null)
                    {
                        {
                            Stream.Write(new RoundReport().Generate(Competition));
                            Stream.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Невозможно получть доступ к файлу, возможно он занят другим приложением. Ошибка: " + e.Message + " Стек вызовов: " + e.StackTrace);
                }

            }
            Close();
        }
        private void NewSetOfTeams()
        {
            if (Automatic)
            {
                Competition.Teams.NextSetOfTeams();
            }

            TimeSpanTable1.BackColor = (Competition.Teams.First != null) ? ((Competition.Teams.First.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText)) : (SystemColors.GrayText);
            TimeSpanTable2.BackColor = (Competition.Teams.Second != null) ? ((Competition.Teams.Second.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText)) : (SystemColors.GrayText);
            TimeSpanTable3.BackColor = (Competition.Teams.Third != null) ? ((Competition.Teams.Third.Enabled) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText)) : (SystemColors.GrayText);

            Model1Pilots.Text = (Competition.Teams.First != null) ? ((Competition.Teams.First.Enabled) ? (Competition.Teams.First.Pilot + "\r\n" + ((Competition.Teams.First.Mechanic != null) ? (Competition.Teams.First.Mechanic) : ("Без механика"))) : ("Без команды")) : ("");
            Model2Pilots.Text = (Competition.Teams.Second != null) ? ((Competition.Teams.Second.Enabled) ? (Competition.Teams.Second.Pilot + "\r\n" + ((Competition.Teams.Second.Mechanic != null) ? (Competition.Teams.Second.Mechanic) : ("Без механика"))) : ("Без команды")) : ("");
            Model3Pilots.Text = (Competition.Teams.Third != null) ? ((Competition.Teams.Third.Enabled) ? (Competition.Teams.Third.Pilot + "\r\n" + ((Competition.Teams.Third.Mechanic != null) ? (Competition.Teams.Third.Mechanic) : ("Без механика"))) : ("Без команды")) : ("");

            Model1Label.Text = (Competition.Teams.First != null) ? ((Competition.Teams.First.Enabled) ? ((Competition.Teams.First.ModelName != null) ? (Competition.Teams.First.ModelName + " [1]") : ("Модель 1")) : ("Отсутсвует")) : ("");
            Model2Label.Text = (Competition.Teams.First != null) ? ((Competition.Teams.First.Enabled) ? ((Competition.Teams.Second.ModelName != null) ? (Competition.Teams.First.ModelName + " [2]") : ("Модель 2")) : ("Отсутсвует")) : ("");
            Model3Label.Text = (Competition.Teams.First != null) ? ((Competition.Teams.Third.Enabled) ? ((Competition.Teams.Third.ModelName != null) ? (Competition.Teams.Third.ModelName + " [3]") : ("Модель 3")) : ("Отсутсвует")) : ("");
        }
        private void FlyMiss1(object sender, EventArgs e)
        {
            FlyMissUpdate(0, 1);
        }
        private void FlyMiss2(object sender, EventArgs e)
        {
            FlyMissUpdate(1, 1);
        }
        private void FlyMiss3(object sender, EventArgs e)
        {
            FlyMissUpdate(2, 1);
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
        private void FlyMissUpdate(int ModelNum, byte Point)
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
            //int 
            if (Value == 1)
            {
                Team.Rounds[Competition.Round].FlyMisses[Point] = (byte)Value;
                Team.Rounds[Competition.Round].TotalPoints = Team.Rounds[Competition.Round].Points + (Team.Rounds[Competition.Round].Points * 0.10);

            }
            else
            {
                if (Value == 0)
                {
                    Team.Rounds[Competition.Round].FlyMisses[Point] = 0;
                    Team.Rounds[Competition.Round].TotalPoints = Team.Rounds[Competition.Round].Points;
                }
                else
                {
                    Team.Rounds[Competition.Round].FlyMisses[Point] = (byte)Value;
                    Team.Rounds[Competition.Round].TotalPoints = 200;
                }
            }
            UpdatePoints(Team, ModelNum);
        }
        private void UpdatePoints(Team Team, int ModelNum)
        {
            double Points = Team.Rounds[Competition.Round].TotalPoints;
            string TotalTime = Points.ToString("0.00").Replace(",", ".");
            switch (ModelNum)
            {
                case 0:
                    Competition.Teams.First.Rounds[Competition.Round].TotalPoints = Team.Rounds[Competition.Round].TotalPoints;
                    Result.Text = TotalTime;
                    break;
                case 1:
                    Competition.Teams.Second.Rounds[Competition.Round].TotalPoints = Team.Rounds[Competition.Round].TotalPoints;
                    Result2.Text = TotalTime;
                    break;
                case 2:
                    Competition.Teams.Third.Rounds[Competition.Round].TotalPoints = Team.Rounds[Competition.Round].TotalPoints;
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
                if (Team.Finished)
                {
                    return;
                }
                //Sometimes crushes out of bounds 1 round instead of 2
                if (Competition.Round == Team.Rounds.Count | Competition.Round > Team.Rounds.Count)
                {
                    return;
                }
                if (Team.Rounds[Competition.Round].CooldownIsUP() == true)
                {
                    int RLC = Team.Rounds[Competition.Round].Laps.Count;
                    if (RLC <= TimerSettings.LapCount)
                    {
                        Competition.Lap(ModelNum + 1);
                        Team = GetTeam(ModelNum);
                    }

                    if (!Team.Enabled)
                    {
                        return;
                    }
                    if (RLC < LC)
                    {
                        Team.Rounds[Competition.Round].onFinish += R;
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
            CreateListForm LF = new CreateListForm(true, Competition.Teams.GetTeams());
            LF.Closing += (s, a) => { if (LF.Choosen_Team != null) { Competition.Teams.First = LF.Choosen_Team; } };
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
                Competition.Teams.First.Rounds[Competition.Round].TotalPoints = 200;
                Result.Text = "200.00";
                FinishTime.Text = "База не пройдена!";
            }
            if (!T2.Finished && T2.Enabled)
            {
                Competition.Teams.Second.Rounds[Competition.Round].TotalPoints = 200;
                Result2.Text = "200.00";
                FinishTime2.Text = "База не пройдена!";
            }
            if (!T3.Finished && T3.Enabled)
            {
                Competition.Teams.Third.Rounds[Competition.Round].TotalPoints = 200;
                Result3.Text = "200.00";
                FinishTime3.Text = "База не пройдена!";
            }
        }
    }
}
