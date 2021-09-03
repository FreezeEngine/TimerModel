
namespace TimerModel.Forms
{
    partial class ReportManager
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
            this.ListOfReports = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LaunchSupervisor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Scorekeeper = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MainJudge = new System.Windows.Forms.TextBox();
            this.SaveReport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.l1 = new System.Windows.Forms.TextBox();
            this.l4 = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.TextBox();
            this.l3 = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListOfReports
            // 
            this.ListOfReports.FormattingEnabled = true;
            this.ListOfReports.ItemHeight = 15;
            this.ListOfReports.Location = new System.Drawing.Point(358, 12);
            this.ListOfReports.Name = "ListOfReports";
            this.ListOfReports.Size = new System.Drawing.Size(291, 274);
            this.ListOfReports.TabIndex = 0;
            this.ListOfReports.SelectedIndexChanged += new System.EventHandler(this.ListOfReports_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LaunchSupervisor);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Scorekeeper);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.MainJudge);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 122);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация о соревновании";
            // 
            // LaunchSupervisor
            // 
            this.LaunchSupervisor.Location = new System.Drawing.Point(127, 55);
            this.LaunchSupervisor.Name = "LaunchSupervisor";
            this.LaunchSupervisor.Size = new System.Drawing.Size(207, 23);
            this.LaunchSupervisor.TabIndex = 6;
            this.LaunchSupervisor.TextChanged += new System.EventHandler(this.LaunchSupervisor_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Главный Судья:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Начальник Старта:";
            // 
            // Scorekeeper
            // 
            this.Scorekeeper.Location = new System.Drawing.Point(127, 84);
            this.Scorekeeper.Name = "Scorekeeper";
            this.Scorekeeper.Size = new System.Drawing.Size(207, 23);
            this.Scorekeeper.TabIndex = 5;
            this.Scorekeeper.TextChanged += new System.EventHandler(this.Scorekeeper_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Секретарь:";
            // 
            // MainJudge
            // 
            this.MainJudge.Location = new System.Drawing.Point(127, 26);
            this.MainJudge.Name = "MainJudge";
            this.MainJudge.Size = new System.Drawing.Size(207, 23);
            this.MainJudge.TabIndex = 4;
            this.MainJudge.TextChanged += new System.EventHandler(this.MainJudge_TextChanged);
            // 
            // SaveReport
            // 
            this.SaveReport.Location = new System.Drawing.Point(12, 293);
            this.SaveReport.Name = "SaveReport";
            this.SaveReport.Size = new System.Drawing.Size(637, 32);
            this.SaveReport.TabIndex = 0;
            this.SaveReport.Text = "Сохранить отчёт";
            this.SaveReport.UseVisualStyleBackColor = true;
            this.SaveReport.Click += new System.EventHandler(this.SaveReport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.l1);
            this.groupBox1.Controls.Add(this.l4);
            this.groupBox1.Controls.Add(this.l2);
            this.groupBox1.Controls.Add(this.l3);
            this.groupBox1.Location = new System.Drawing.Point(12, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 147);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поля отчёта";
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(12, 24);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(322, 23);
            this.l1.TabIndex = 8;
            this.l1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.l1.TextChanged += new System.EventHandler(this.Lines_TextChanged);
            // 
            // l4
            // 
            this.l4.Location = new System.Drawing.Point(12, 111);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(322, 23);
            this.l4.TabIndex = 11;
            this.l4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.l4.TextChanged += new System.EventHandler(this.Lines_TextChanged);
            // 
            // l2
            // 
            this.l2.Location = new System.Drawing.Point(12, 53);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(322, 23);
            this.l2.TabIndex = 9;
            this.l2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.l2.TextChanged += new System.EventHandler(this.Lines_TextChanged);
            // 
            // l3
            // 
            this.l3.Location = new System.Drawing.Point(12, 82);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(322, 23);
            this.l3.TabIndex = 10;
            this.l3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.l3.TextChanged += new System.EventHandler(this.Lines_TextChanged);
            // 
            // ReportManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 332);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SaveReport);
            this.Controls.Add(this.ListOfReports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReportManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер отчетов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportManager_FormClosing);
            this.Load += new System.EventHandler(this.ReportManager_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListOfReports;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox LaunchSupervisor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Scorekeeper;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MainJudge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox l1;
        private System.Windows.Forms.TextBox l4;
        private System.Windows.Forms.TextBox l2;
        private System.Windows.Forms.TextBox l3;
    }
}