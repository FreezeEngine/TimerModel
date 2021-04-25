
namespace TimerModel
{
    partial class CompetitionReport
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
            this.SaveReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MainJudge = new System.Windows.Forms.TextBox();
            this.Scorekeeper = new System.Windows.Forms.TextBox();
            this.LaunchSupervisor = new System.Windows.Forms.TextBox();
            this.l1 = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.TextBox();
            this.l3 = new System.Windows.Forms.TextBox();
            this.l4 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveReport
            // 
            this.SaveReport.Location = new System.Drawing.Point(6, 110);
            this.SaveReport.Name = "SaveReport";
            this.SaveReport.Size = new System.Drawing.Size(328, 32);
            this.SaveReport.TabIndex = 0;
            this.SaveReport.Text = "Сохранить отчёт";
            this.SaveReport.UseVisualStyleBackColor = true;
            this.SaveReport.Click += new System.EventHandler(this.SaveReport_Click);
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
            // 
            // Scorekeeper
            // 
            this.Scorekeeper.Location = new System.Drawing.Point(127, 84);
            this.Scorekeeper.Name = "Scorekeeper";
            this.Scorekeeper.Size = new System.Drawing.Size(207, 23);
            this.Scorekeeper.TabIndex = 5;
            // 
            // LaunchSupervisor
            // 
            this.LaunchSupervisor.Location = new System.Drawing.Point(127, 55);
            this.LaunchSupervisor.Name = "LaunchSupervisor";
            this.LaunchSupervisor.Size = new System.Drawing.Size(207, 23);
            this.LaunchSupervisor.TabIndex = 6;
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(12, 24);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(364, 23);
            this.l1.TabIndex = 8;
            this.l1.Text = "ПРОТОКОЛ";
            this.l1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l2
            // 
            this.l2.Location = new System.Drawing.Point(12, 53);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(364, 23);
            this.l2.TabIndex = 9;
            this.l2.Text = "соревнований по авиамодельному спорту";
            this.l2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l3
            // 
            this.l3.Location = new System.Drawing.Point(12, 82);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(364, 23);
            this.l3.TabIndex = 10;
            this.l3.Text = "\"...\"  в классе радиоуправляемых моделей ...";
            this.l3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l4
            // 
            this.l4.Location = new System.Drawing.Point(12, 111);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(364, 23);
            this.l4.TabIndex = 11;
            this.l4.Text = "Дата соревнования";
            this.l4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.l1);
            this.groupBox1.Controls.Add(this.l4);
            this.groupBox1.Controls.Add(this.l2);
            this.groupBox1.Controls.Add(this.l3);
            this.groupBox1.Location = new System.Drawing.Point(358, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 147);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поля отчёта";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LaunchSupervisor);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.SaveReport);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Scorekeeper);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.MainJudge);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 147);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация о соревновании";
            // 
            // CompetitionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 169);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CompetitionReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование отчёта";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MainJudge;
        private System.Windows.Forms.TextBox Scorekeeper;
        private System.Windows.Forms.TextBox LaunchSupervisor;
        private System.Windows.Forms.TextBox l1;
        private System.Windows.Forms.TextBox l2;
        private System.Windows.Forms.TextBox l3;
        private System.Windows.Forms.TextBox l4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}