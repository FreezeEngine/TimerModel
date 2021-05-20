using System;
using System.Windows.Forms;
using TimerModel.Objects.PrintModes;

namespace TimerModel.Forms.Setup_Forms
{
    public partial class PrintModeSelector : Form
    {
        public PrintModes PrintMode;
        public PrintModeSelector()
        {
            InitializeComponent();
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
