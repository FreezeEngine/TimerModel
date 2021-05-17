
namespace TimerModel.Forms.Setup_Forms
{
    partial class PreFinishAsk
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
            this.ReflyModels = new System.Windows.Forms.Button();
            this.Report = new System.Windows.Forms.Button();
            this.OpenCompetitionManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReflyModels
            // 
            this.ReflyModels.Location = new System.Drawing.Point(12, 116);
            this.ReflyModels.Name = "ReflyModels";
            this.ReflyModels.Size = new System.Drawing.Size(348, 46);
            this.ReflyModels.TabIndex = 0;
            this.ReflyModels.Text = "Назначить прелёты";
            this.ReflyModels.UseVisualStyleBackColor = true;
            this.ReflyModels.Click += new System.EventHandler(this.ReflyModels_Click);
            // 
            // Report
            // 
            this.Report.Location = new System.Drawing.Point(12, 12);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(348, 46);
            this.Report.TabIndex = 1;
            this.Report.Text = "Перейти к работе с отчётами";
            this.Report.UseVisualStyleBackColor = true;
            this.Report.Click += new System.EventHandler(this.Report_Click);
            // 
            // OpenCompetitionManager
            // 
            this.OpenCompetitionManager.Location = new System.Drawing.Point(12, 64);
            this.OpenCompetitionManager.Name = "OpenCompetitionManager";
            this.OpenCompetitionManager.Size = new System.Drawing.Size(348, 46);
            this.OpenCompetitionManager.TabIndex = 2;
            this.OpenCompetitionManager.Text = "Открыть менеджер соревнования";
            this.OpenCompetitionManager.UseVisualStyleBackColor = true;
            this.OpenCompetitionManager.Click += new System.EventHandler(this.OpenCompetitionManager_Click);
            // 
            // PreFinishAsk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 171);
            this.Controls.Add(this.OpenCompetitionManager);
            this.Controls.Add(this.Report);
            this.Controls.Add(this.ReflyModels);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PreFinishAsk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Завершение соревнования";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReflyModels;
        private System.Windows.Forms.Button Report;
        private System.Windows.Forms.Button OpenCompetitionManager;
    }
}