
namespace TimerModel.Forms
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TestModeCheckBox = new System.Windows.Forms.CheckBox();
            this.DevGroupBox = new System.Windows.Forms.GroupBox();
            this.Print = new System.Windows.Forms.CheckBox();
            this.DoubleClickProtection = new System.Windows.Forms.CheckBox();
            this.FileGeneration = new System.Windows.Forms.CheckBox();
            this.DevGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestModeCheckBox
            // 
            this.TestModeCheckBox.AutoSize = true;
            this.TestModeCheckBox.Location = new System.Drawing.Point(586, 12);
            this.TestModeCheckBox.Name = "TestModeCheckBox";
            this.TestModeCheckBox.Size = new System.Drawing.Size(130, 19);
            this.TestModeCheckBox.TabIndex = 0;
            this.TestModeCheckBox.Text = "Режим разработки";
            this.TestModeCheckBox.UseVisualStyleBackColor = true;
            this.TestModeCheckBox.CheckedChanged += new System.EventHandler(this.TestModeCheckBox_CheckedChanged);
            // 
            // DevGroupBox
            // 
            this.DevGroupBox.Controls.Add(this.FileGeneration);
            this.DevGroupBox.Controls.Add(this.DoubleClickProtection);
            this.DevGroupBox.Controls.Add(this.Print);
            this.DevGroupBox.Enabled = false;
            this.DevGroupBox.Location = new System.Drawing.Point(586, 37);
            this.DevGroupBox.Name = "DevGroupBox";
            this.DevGroupBox.Size = new System.Drawing.Size(202, 100);
            this.DevGroupBox.TabIndex = 1;
            this.DevGroupBox.TabStop = false;
            this.DevGroupBox.Text = "Работа модулей";
            // 
            // Print
            // 
            this.Print.AutoSize = true;
            this.Print.Checked = true;
            this.Print.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Print.Location = new System.Drawing.Point(15, 25);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(65, 19);
            this.Print.TabIndex = 0;
            this.Print.Text = "Печать";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.CheckedChanged += new System.EventHandler(this.Print_CheckedChanged);
            // 
            // DoubleClickProtection
            // 
            this.DoubleClickProtection.AutoSize = true;
            this.DoubleClickProtection.Checked = true;
            this.DoubleClickProtection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DoubleClickProtection.Location = new System.Drawing.Point(15, 75);
            this.DoubleClickProtection.Name = "DoubleClickProtection";
            this.DoubleClickProtection.Size = new System.Drawing.Size(181, 19);
            this.DoubleClickProtection.TabIndex = 1;
            this.DoubleClickProtection.Text = "Защита от ложных нажатий";
            this.DoubleClickProtection.UseVisualStyleBackColor = true;
            this.DoubleClickProtection.CheckedChanged += new System.EventHandler(this.DoubleClickProtection_CheckedChanged);
            // 
            // FileGeneration
            // 
            this.FileGeneration.AutoSize = true;
            this.FileGeneration.Checked = true;
            this.FileGeneration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FileGeneration.Location = new System.Drawing.Point(15, 50);
            this.FileGeneration.Name = "FileGeneration";
            this.FileGeneration.Size = new System.Drawing.Size(173, 19);
            this.FileGeneration.TabIndex = 2;
            this.FileGeneration.Text = "Создание файлов к печати";
            this.FileGeneration.UseVisualStyleBackColor = true;
            this.FileGeneration.CheckedChanged += new System.EventHandler(this.FileGeneration_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DevGroupBox);
            this.Controls.Add(this.TestModeCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.DevGroupBox.ResumeLayout(false);
            this.DevGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox TestModeCheckBox;
        private System.Windows.Forms.GroupBox DevGroupBox;
        private System.Windows.Forms.CheckBox DoubleClickProtection;
        private System.Windows.Forms.CheckBox Print;
        private System.Windows.Forms.CheckBox FileGeneration;
    }
}