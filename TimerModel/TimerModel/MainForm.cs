using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerModel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan Time = DateTime.Now - TimerData.StartTime;
            TimerLabel.Text = Time.ToString();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            //Start.Text = "Пауза";
            TimerData.SetStart();
            Timer.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Timer.Stop();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Timer.Stop();
            TimerData.Clear();
            TimerLabel.Text = "Остановлено";
        }
    }
}
