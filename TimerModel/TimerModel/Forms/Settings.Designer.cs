
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
            this.ReportingTest = new System.Windows.Forms.Button();
            this.MainControl = new System.Windows.Forms.CheckBox();
            this.MakeBlankReport = new System.Windows.Forms.Button();
            this.RecoverData = new System.Windows.Forms.Button();
            this.FileGeneration = new System.Windows.Forms.CheckBox();
            this.DoubleClickProtection = new System.Windows.Forms.CheckBox();
            this.Print = new System.Windows.Forms.CheckBox();
            this.OpenCompetitionManager = new System.Windows.Forms.Button();
            this.EditTeamSets = new System.Windows.Forms.Button();
            this.EndCompetition = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TemporerelyFinish = new System.Windows.Forms.Button();
            this.SaveData = new System.Windows.Forms.Button();
            this.DevGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestModeCheckBox
            // 
            this.TestModeCheckBox.AutoSize = true;
            this.TestModeCheckBox.Location = new System.Drawing.Point(12, 212);
            this.TestModeCheckBox.Name = "TestModeCheckBox";
            this.TestModeCheckBox.Size = new System.Drawing.Size(114, 19);
            this.TestModeCheckBox.TabIndex = 0;
            this.TestModeCheckBox.Text = "Дополнительно";
            this.TestModeCheckBox.UseVisualStyleBackColor = true;
            this.TestModeCheckBox.CheckedChanged += new System.EventHandler(this.TestModeCheckBox_CheckedChanged);
            // 
            // DevGroupBox
            // 
            this.DevGroupBox.Controls.Add(this.ReportingTest);
            this.DevGroupBox.Controls.Add(this.MainControl);
            this.DevGroupBox.Controls.Add(this.MakeBlankReport);
            this.DevGroupBox.Controls.Add(this.RecoverData);
            this.DevGroupBox.Controls.Add(this.FileGeneration);
            this.DevGroupBox.Controls.Add(this.DoubleClickProtection);
            this.DevGroupBox.Controls.Add(this.Print);
            this.DevGroupBox.Enabled = false;
            this.DevGroupBox.Location = new System.Drawing.Point(12, 236);
            this.DevGroupBox.Name = "DevGroupBox";
            this.DevGroupBox.Size = new System.Drawing.Size(410, 167);
            this.DevGroupBox.TabIndex = 1;
            this.DevGroupBox.TabStop = false;
            this.DevGroupBox.Text = "Работа модулей";
            // 
            // ReportingTest
            // 
            this.ReportingTest.Location = new System.Drawing.Point(208, 50);
            this.ReportingTest.Name = "ReportingTest";
            this.ReportingTest.Size = new System.Drawing.Size(196, 23);
            this.ReportingTest.TabIndex = 8;
            this.ReportingTest.Text = "Заполнить соревнование";
            this.ReportingTest.UseVisualStyleBackColor = true;
            this.ReportingTest.Click += new System.EventHandler(this.ReportingTest_Click);
            // 
            // MainControl
            // 
            this.MainControl.AutoSize = true;
            this.MainControl.Checked = true;
            this.MainControl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MainControl.Location = new System.Drawing.Point(208, 25);
            this.MainControl.Name = "MainControl";
            this.MainControl.Size = new System.Drawing.Size(167, 19);
            this.MainControl.TabIndex = 7;
            this.MainControl.Text = "Система конроля данных";
            this.MainControl.UseVisualStyleBackColor = true;
            // 
            // MakeBlankReport
            // 
            this.MakeBlankReport.Location = new System.Drawing.Point(6, 134);
            this.MakeBlankReport.Name = "MakeBlankReport";
            this.MakeBlankReport.Size = new System.Drawing.Size(398, 26);
            this.MakeBlankReport.TabIndex = 6;
            this.MakeBlankReport.Text = "Создать шаблон соревнований";
            this.MakeBlankReport.UseVisualStyleBackColor = true;
            this.MakeBlankReport.Click += new System.EventHandler(this.button1_Click);
            // 
            // RecoverData
            // 
            this.RecoverData.Location = new System.Drawing.Point(6, 100);
            this.RecoverData.Name = "RecoverData";
            this.RecoverData.Size = new System.Drawing.Size(398, 28);
            this.RecoverData.TabIndex = 5;
            this.RecoverData.Text = "Восстановить данные по полётным листам";
            this.RecoverData.UseVisualStyleBackColor = true;
            this.RecoverData.Click += new System.EventHandler(this.RecoverData_Click);
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
            // OpenCompetitionManager
            // 
            this.OpenCompetitionManager.Location = new System.Drawing.Point(12, 7);
            this.OpenCompetitionManager.Name = "OpenCompetitionManager";
            this.OpenCompetitionManager.Size = new System.Drawing.Size(410, 42);
            this.OpenCompetitionManager.TabIndex = 2;
            this.OpenCompetitionManager.Text = "Менеджер соревнования";
            this.OpenCompetitionManager.UseVisualStyleBackColor = true;
            this.OpenCompetitionManager.Click += new System.EventHandler(this.OpenCompetitionManager_Click);
            // 
            // EditTeamSets
            // 
            this.EditTeamSets.Location = new System.Drawing.Point(12, 52);
            this.EditTeamSets.Name = "EditTeamSets";
            this.EditTeamSets.Size = new System.Drawing.Size(410, 35);
            this.EditTeamSets.TabIndex = 3;
            this.EditTeamSets.Text = "Редактировать тройки";
            this.EditTeamSets.UseVisualStyleBackColor = true;
            this.EditTeamSets.Click += new System.EventHandler(this.EditTeamSets_Click);
            // 
            // EndCompetition
            // 
            this.EndCompetition.Location = new System.Drawing.Point(12, 158);
            this.EndCompetition.Name = "EndCompetition";
            this.EndCompetition.Size = new System.Drawing.Size(410, 32);
            this.EndCompetition.TabIndex = 4;
            this.EndCompetition.Text = "Завершить соревнование";
            this.EndCompetition.UseVisualStyleBackColor = true;
            this.EndCompetition.Click += new System.EventHandler(this.EndCompetition_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(220, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 51);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дизайн";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(120, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(69, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Размер шрифта:";
            // 
            // TemporerelyFinish
            // 
            this.TemporerelyFinish.Location = new System.Drawing.Point(12, 91);
            this.TemporerelyFinish.Name = "TemporerelyFinish";
            this.TemporerelyFinish.Size = new System.Drawing.Size(410, 36);
            this.TemporerelyFinish.TabIndex = 7;
            this.TemporerelyFinish.Text = "Временно завершить соревнование";
            this.TemporerelyFinish.UseVisualStyleBackColor = true;
            this.TemporerelyFinish.Click += new System.EventHandler(this.TemporerelyFinish_Click);
            // 
            // SaveData
            // 
            this.SaveData.Location = new System.Drawing.Point(12, 131);
            this.SaveData.Name = "SaveData";
            this.SaveData.Size = new System.Drawing.Size(410, 23);
            this.SaveData.TabIndex = 8;
            this.SaveData.Text = "Сохранить данные соревнования";
            this.SaveData.UseVisualStyleBackColor = true;
            this.SaveData.Click += new System.EventHandler(this.SaveData_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 410);
            this.Controls.Add(this.SaveData);
            this.Controls.Add(this.TemporerelyFinish);
            this.Controls.Add(this.EndCompetition);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.EditTeamSets);
            this.Controls.Add(this.OpenCompetitionManager);
            this.Controls.Add(this.DevGroupBox);
            this.Controls.Add(this.TestModeCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Органайзер";
            this.DevGroupBox.ResumeLayout(false);
            this.DevGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox TestModeCheckBox;
        private System.Windows.Forms.GroupBox DevGroupBox;
        private System.Windows.Forms.CheckBox DoubleClickProtection;
        private System.Windows.Forms.CheckBox Print;
        private System.Windows.Forms.CheckBox FileGeneration;
        private System.Windows.Forms.Button OpenCompetitionManager;
        private System.Windows.Forms.Button EditTeamSets;
        private System.Windows.Forms.Button EndCompetition;
        private System.Windows.Forms.Button RecoverData;
        private System.Windows.Forms.Button MakeBlankReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TemporerelyFinish;
        private System.Windows.Forms.CheckBox MainControl;
        private System.Windows.Forms.Button ReportingTest;
        private System.Windows.Forms.Button SaveData;
    }
}