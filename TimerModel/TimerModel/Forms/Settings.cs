using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TimerModel.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            Print.Checked = TimerSettings.PrintingEnabled;
            DoubleClickProtection.Checked = TimerSettings.DoubleClickProtectionEnabled;
            FileGeneration.Checked = TimerSettings.PrintFileGeneration;
        }

        private void TestModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DevGroupBox.Enabled = TestModeCheckBox.Checked;
        }

        private void Print_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.PrintingEnabled = Print.Checked;
        }

        private void DoubleClickProtection_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.DoubleClickProtectionEnabled = DoubleClickProtection.Checked;
        }

        private void FileGeneration_CheckedChanged(object sender, EventArgs e)
        {
            TimerSettings.PrintFileGeneration = FileGeneration.Checked;
        }
    }
}
