using System;
using System.Windows.Forms;

namespace TimerModel
{
    public partial class MainForm : Form
    {
        private static FlyModel[] FlyModels = new FlyModel[3];
        public MainForm()
        {
            InitializeComponent();
            FlyModels[0] = new FlyModel();
            FlyModels[1] = new FlyModel();
            FlyModels[2] = new FlyModel();
        }
        //private void Set
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
        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            void HandleButton(int ModelNum)
            {
                if (FlyModels[ModelNum].CurrentPointer < 10)
                {
                    DateTime Time = DateTime.Now;
                    if (FlyModels[ModelNum].CooldownIsUP(Time) == true)
                    {
                        int Pointer = FlyModels[ModelNum].CurrentPointer;
                        Label Label = FlyModels[ModelNum].GetStopWatchLabel(Time, ModelNum);
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
                        if (FlyModels[ModelNum].CurrentPointer == 10)
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
            Result.Text = Result2.Text = Result3.Text = "";
            FinishTime.Text = FinishTime2.Text = FinishTime3.Text = "";
            FlyModels[0] = new FlyModel();
            FlyModels[1] = new FlyModel();
            FlyModels[2] = new FlyModel();
            TimeSpanTable1.Controls.Clear();
            TimeSpanTable2.Controls.Clear();
            TimeSpanTable3.Controls.Clear();
        }
    }
}
