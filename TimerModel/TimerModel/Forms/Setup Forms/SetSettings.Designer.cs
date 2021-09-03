
namespace TimerModel
{
    partial class SetSettings
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
            this.Continue = new System.Windows.Forms.Button();
            this.LapsCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.FlyModelsList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CMName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LaunchSupervisor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Scorekeeper = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MainJudge = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.StartModelIndex = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RoundsCount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.LapsCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoundsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // Continue
            // 
            this.Continue.Location = new System.Drawing.Point(12, 309);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(365, 35);
            this.Continue.TabIndex = 1;
            this.Continue.Text = "Продолжить";
            this.Continue.UseVisualStyleBackColor = true;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // LapsCount
            // 
            this.LapsCount.Location = new System.Drawing.Point(131, 55);
            this.LapsCount.Name = "LapsCount";
            this.LapsCount.ReadOnly = true;
            this.LapsCount.Size = new System.Drawing.Size(58, 23);
            this.LapsCount.TabIndex = 4;
            this.LapsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LapsCount.ValueChanged += new System.EventHandler(this.LapAmount_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Количество кругов";
            // 
            // FlyModelsList
            // 
            this.FlyModelsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlyModelsList.FormattingEnabled = true;
            this.FlyModelsList.Location = new System.Drawing.Point(13, 23);
            this.FlyModelsList.Name = "FlyModelsList";
            this.FlyModelsList.Size = new System.Drawing.Size(176, 23);
            this.FlyModelsList.TabIndex = 5;
            this.FlyModelsList.SelectedIndexChanged += new System.EventHandler(this.CMList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Название проекта соревнования (Не влияет на отчет)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RoundsCount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.LapsCount);
            this.groupBox1.Controls.Add(this.FlyModelsList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 114);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // CMName
            // 
            this.CMName.Location = new System.Drawing.Point(12, 32);
            this.CMName.Name = "CMName";
            this.CMName.Size = new System.Drawing.Size(365, 23);
            this.CMName.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LaunchSupervisor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Scorekeeper);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.MainJudge);
            this.groupBox2.Location = new System.Drawing.Point(12, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 122);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация о соревновании";
            // 
            // LaunchSupervisor
            // 
            this.LaunchSupervisor.Location = new System.Drawing.Point(126, 55);
            this.LaunchSupervisor.Name = "LaunchSupervisor";
            this.LaunchSupervisor.Size = new System.Drawing.Size(233, 23);
            this.LaunchSupervisor.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Главный Судья:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Начальник Старта:";
            // 
            // Scorekeeper
            // 
            this.Scorekeeper.Location = new System.Drawing.Point(126, 84);
            this.Scorekeeper.Name = "Scorekeeper";
            this.Scorekeeper.Size = new System.Drawing.Size(233, 23);
            this.Scorekeeper.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Секретарь:";
            // 
            // MainJudge
            // 
            this.MainJudge.Location = new System.Drawing.Point(126, 26);
            this.MainJudge.Name = "MainJudge";
            this.MainJudge.Size = new System.Drawing.Size(233, 23);
            this.MainJudge.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.StartModelIndex);
            this.groupBox3.Location = new System.Drawing.Point(222, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(155, 89);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Старт";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(29, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 26);
            this.label6.TabIndex = 7;
            this.label6.Text = "С каких моделей \r\nначинать?";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartModelIndex
            // 
            this.StartModelIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StartModelIndex.FormattingEnabled = true;
            this.StartModelIndex.Location = new System.Drawing.Point(6, 23);
            this.StartModelIndex.Name = "StartModelIndex";
            this.StartModelIndex.Size = new System.Drawing.Size(143, 23);
            this.StartModelIndex.TabIndex = 6;
            this.StartModelIndex.SelectedIndexChanged += new System.EventHandler(this.StartModelIndex_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Количество туров";
            // 
            // RoundsCount
            // 
            this.RoundsCount.Location = new System.Drawing.Point(131, 83);
            this.RoundsCount.Name = "RoundsCount";
            this.RoundsCount.ReadOnly = true;
            this.RoundsCount.Size = new System.Drawing.Size(58, 23);
            this.RoundsCount.TabIndex = 7;
            this.RoundsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RoundsCount.ValueChanged += new System.EventHandler(this.RoundsCount_ValueChanged);
            // 
            // SetSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 356);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CMName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Continue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "SetSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetSettings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.LapsCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoundsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.NumericUpDown LapsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FlyModelsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CMName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox LaunchSupervisor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Scorekeeper;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MainJudge;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox StartModelIndex;
        private System.Windows.Forms.NumericUpDown RoundsCount;
        private System.Windows.Forms.Label label7;
    }
}