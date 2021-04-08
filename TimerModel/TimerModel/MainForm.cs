using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TimerModel
{
    public partial class MainForm : Form
    {
        private static FlyModel[] FlyModels = new FlyModel[3];
        private int Shift = 0;
        List<Team> Teams;

        private bool Printed = false;
        //private bool First = false;

        private int TourPointer = 1;
        private byte LC = ++TimerSettings.LapCount;
        bool automatic;
        public MainForm(List<Team> Teams, bool automatic)   
        {
            this.automatic = automatic;
            this.Teams = Teams;
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
            if (automatic)
            {
                NewSetOfTeams();
            }
        }
        
        private void NewSetOfTeams()
        {
            void TT()
            {
                FlyModels[0] = new FlyModel() { Team = ((0 + Shift) < Teams.Count) ? (Teams[0 + Shift]) : (null), Enabled = (0 + Shift) < Teams.Count, Finished = !((0 + Shift) < Teams.Count) };
                FlyModels[1] = new FlyModel() { Team = ((1 + Shift) < Teams.Count) ? (Teams[1 + Shift]) : (null), Enabled = (1 + Shift) < Teams.Count, Finished = !((1 + Shift) < Teams.Count) };
                FlyModels[2] = new FlyModel() { Team = ((2 + Shift) < Teams.Count) ? (Teams[2 + Shift]) : (null), Enabled = (2 + Shift) < Teams.Count, Finished = !((2 + Shift) < Teams.Count) };
            }
            TT();
            if (FlyModels[0].Team == null && FlyModels[1].Team == null && FlyModels[2].Team == null)
            {
                TourNum.Text = "Тур: " + TourPointer++;
                Shift = 0;
                TT();
            }
            if (TourPointer == TimerSettings.TourCount + 1)
            {
                MessageBox.Show("Комады закончились!");
                Close();
            }


            TimeSpanTable1.BackColor = ((0 + Shift) < Teams.Count) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);
            TimeSpanTable2.BackColor = ((1 + Shift) < Teams.Count) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);
            TimeSpanTable3.BackColor = ((2 + Shift) < Teams.Count) ? (SystemColors.ButtonHighlight) : (SystemColors.GrayText);

            Model1Pilots.Text = ((0 + Shift) < Teams.Count) ? (FlyModels[0].Team.Pilot + "\r\n" + ((FlyModels[0].Team.Mechanic != null) ? (FlyModels[2].Team.Mechanic) : ("Без механика"))) : ("Без команды");
            Model2Pilots.Text = ((1 + Shift) < Teams.Count) ? (FlyModels[1].Team.Pilot + "\r\n" + ((FlyModels[1].Team.Mechanic != null) ? (FlyModels[2].Team.Mechanic) : ("Без механика"))) : ("Без команды");
            Model3Pilots.Text = ((2 + Shift) < Teams.Count) ? (FlyModels[2].Team.Pilot + "\r\n" + ((FlyModels[2].Team.Mechanic != null)?(FlyModels[2].Team.Mechanic):("Без механика"))):("Без команды");

            Model1Label.Text = ((0 + Shift) < Teams.Count) ? ((FlyModels[0].Team.ModelName != null) ?(FlyModels[0].Team.ModelName+" [1]") :("Модель 1")) : ("Отсутсвует");
            Model2Label.Text = ((1 + Shift) < Teams.Count) ? ((FlyModels[1].Team.ModelName != null) ? (FlyModels[1].Team.ModelName + " [2]") : ("Модель 2")) : ("Отсутсвует");
            Model3Label.Text = ((2 + Shift) < Teams.Count) ? ((FlyModels[2].Team.ModelName != null) ? (FlyModels[2].Team.ModelName + " [3]") : ("Модель 3")) : ("Отсутсвует");
            Shift = Shift + 3;
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
        private void FlyMissUpdate(int ModelNum)
        {
            decimal Value = 0;
            if (!FlyModels[ModelNum].Finished)
            {
                return;
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
                FlyModels[ModelNum].FlyMisses = 1;
                FlyModels[ModelNum].TotalPoints = FlyModels[ModelNum].Points + (FlyModels[ModelNum].Points * 0.10);
                
            }
            else
            {
                if (Value == 0)
                {
                    FlyModels[ModelNum].FlyMisses = 0;
                    FlyModels[ModelNum].TotalPoints = FlyModels[ModelNum].Points;
                }
                else
                {
                    FlyModels[ModelNum].FlyMisses = (byte)Value;
                    FlyModels[ModelNum].TotalPoints = 200;
                }
            }
            UpdatePoints(ModelNum);
        }
        private void UpdatePoints(int ModelNum)
        {
            double Points = FlyModels[ModelNum].TotalPoints;
            string TotalTime = Points.ToString("0.00").Replace(",", ".");
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
        private void KeyPressed(object sender, KeyPressEventArgs e)
        {

            void HandleButton(int ModelNum)
            {
                if (!(FlyModels[ModelNum].Enabled))
                {
                    return;
                }
                if (FlyModels[ModelNum].CurrentPointer < LC)
                {
                    DateTime Time = DateTime.Now;
                    if (FlyModels[ModelNum].CooldownIsUP(Time) == true)
                    {
                        
                        int Pointer = FlyModels[ModelNum].CurrentPointer;
                        Label Label = FlyModels[ModelNum].GetStopWatchLabel(Time, ModelNum);
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
                        FlyModels[ModelNum].CurrentPointer++;
                        if (FlyModels[ModelNum].CurrentPointer == LC)
                        {
                            TimeSpan TTime = FlyModels[ModelNum].GetOverAllTime(Time);
                            double Points = Math.Round(Convert.ToDouble(TTime.TotalSeconds), 3);
                            FlyModels[ModelNum].TotalPoints = Points;
                            FlyModels[ModelNum].Points = Points;
                            FlyModels[ModelNum].Finished = true;
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
                            if (FlyModels[0].Finished && FlyModels[1].Finished && FlyModels[2].Finished)
                                StopTimer();
                        }
                    }
                }
            }
            if (!Stopwatch.Started&&(TourPointer==1|Printed))
            {
                ClearTimer();
                StopTimer();
                NewSetOfTeams();

                Stopwatch.Started = true;
                Start.Enabled = false;
                Stop.Enabled = true;
                Stopwatch.Start();
                Timer.Start();
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
            ClearTimer();
            Stopwatch.Started = true;
            Start.Enabled = false;
            Stop.Enabled = true;
            Stopwatch.Start();
            Timer.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            ClearTimer();
            StopTimer();
        }
        private void StopTimer()
        {
            Stopwatch.Started = false;
            Timer.Stop();
            TimerLabel.Text = "Остановлено";
            Start.Enabled = true;
            Stop.Enabled = false;
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
            if (FlyModels[0].Finished && FlyModels[1].Finished && FlyModels[2].Finished)
            {
                //ADD PRINT ON 123 keys CUZ IT OVERRIDES
                Printed = true;
                MessageBox.Show("PRINTING");

                //NewSetOfTeams();
                //ClearTimer();
                //StopTimer();
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
            Hide();
            CreateListForm LF = new CreateListForm();
            LF.Closed += (s, a) => Close();
            LF.Show();

        }
    }
}
