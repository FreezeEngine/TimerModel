using System;
using System.Windows.Forms;

namespace TimerModel.Forms.Setup_Forms
{
    public partial class PrintMode : Form
    {
        public bool Vertical = false;
        public PrintMode()
        {
            InitializeComponent();
        }

        private void RememberMode_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.NoPrePrintAsking = RememberMode.Checked;
        }

        private void VerticalPrint_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.VerticalPrint = VerticalPrint.Checked;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
