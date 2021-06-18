
namespace TimerModel
{
    partial class StartForm
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
            this.OpenFile = new System.Windows.Forms.Button();
            this.CreateList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ContinueCompetition = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(157, 40);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(135, 40);
            this.OpenFile.TabIndex = 0;
            this.OpenFile.Text = "Открыть из файла";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // CreateList
            // 
            this.CreateList.Location = new System.Drawing.Point(12, 40);
            this.CreateList.Name = "CreateList";
            this.CreateList.Size = new System.Drawing.Size(137, 40);
            this.CreateList.TabIndex = 1;
            this.CreateList.Text = "Создать новый список вручную";
            this.CreateList.UseVisualStyleBackColor = true;
            this.CreateList.Click += new System.EventHandler(this.CreateList_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберете или создайте список участников";
            // 
            // ContinueCompetition
            // 
            this.ContinueCompetition.Location = new System.Drawing.Point(13, 87);
            this.ContinueCompetition.Name = "ContinueCompetition";
            this.ContinueCompetition.Size = new System.Drawing.Size(279, 40);
            this.ContinueCompetition.TabIndex = 3;
            this.ContinueCompetition.Text = "Продолжить соревнование";
            this.ContinueCompetition.UseVisualStyleBackColor = true;
            this.ContinueCompetition.Click += new System.EventHandler(this.ContinueCompetition_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 134);
            this.Controls.Add(this.ContinueCompetition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateList);
            this.Controls.Add(this.OpenFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button CreateList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ContinueCompetition;
    }
}