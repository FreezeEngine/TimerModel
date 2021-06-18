using System;
using System.Windows.Forms;
using TimerModel.Objects.PrintMode;

namespace TimerModel.Forms.Setup_Forms
{
    public partial class PrintModeSelector : Form
    {
        public PrintModes PrintMode;
        public PrintModeSelector()
        {
            InitializeComponent();
            TopMost = true;
            switch (TimerSettings.PrintMode)
            {
                case PrintModes.Horizontal:
                    HorizontalPrint.Checked = true;
                    break;
                case PrintModes.Vertical:
                    VerticalPrint.Checked = true;
                    break;
                case PrintModes.Both:
                    PrintBoth.Checked = true;
                    break;
            }
        }

        private void RememberMode_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.NoPrePrintAsking = RememberMode.Checked;
        }

        private void PrintModeChanged(object sender, EventArgs e)
        {
            if (HorizontalPrint.Checked)
            {
                TimerSettings.PrintMode = PrintModes.Horizontal;
            }
            if (VerticalPrint.Checked)
            {
                TimerSettings.PrintMode = PrintModes.Vertical;
            }
            if (PrintBoth.Checked)
            {
                TimerSettings.PrintMode = PrintModes.Both;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
        }
    }
}
