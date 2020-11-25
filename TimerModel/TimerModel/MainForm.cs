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
            TimerLabel.Text = Stopwatch.GetSubTime();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Stopwatch.Start();
            Timer.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Timer.Stop();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Timer.Stop();
            TimerLabel.Text = "Остановлено";
        }
    }
}
