
namespace TimerModel.Forms.Team_Managers
{
    partial class Refly
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
            this.SubmitRefly = new System.Windows.Forms.Button();
            this.RoundsToRefly = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TeamL = new System.Windows.Forms.Label();
            this.MechanicL = new System.Windows.Forms.Label();
            this.PilotL = new System.Windows.Forms.Label();
            this.ListOfTeams = new System.Windows.Forms.ListBox();
            this.GoBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SubmitRefly
            // 
            this.SubmitRefly.Enabled = false;
            this.SubmitRefly.Location = new System.Drawing.Point(12, 268);
            this.SubmitRefly.Name = "SubmitRefly";
            this.SubmitRefly.Size = new System.Drawing.Size(398, 47);
            this.SubmitRefly.TabIndex = 1;
            this.SubmitRefly.Text = "Провести перелёты";
            this.SubmitRefly.UseVisualStyleBackColor = true;
            this.SubmitRefly.Click += new System.EventHandler(this.SubmitRefly_Click);
            // 
            // RoundsToRefly
            // 
            this.RoundsToRefly.Location = new System.Drawing.Point(416, 135);
            this.RoundsToRefly.Name = "RoundsToRefly";
            this.RoundsToRefly.Size = new System.Drawing.Size(195, 23);
            this.RoundsToRefly.TabIndex = 11;
            this.RoundsToRefly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(416, 166);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(195, 43);
            this.Submit.TabIndex = 10;
            this.Submit.Text = "Применить";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "Назначить перелёт за тур/туры \r\n(Перечилить через запятую)";
            // 
            // TeamL
            // 
            this.TeamL.AutoSize = true;
            this.TeamL.Location = new System.Drawing.Point(416, 70);
            this.TeamL.Name = "TeamL";
            this.TeamL.Size = new System.Drawing.Size(61, 15);
            this.TeamL.TabIndex = 8;
            this.TeamL.Text = "Команда: ";
            // 
            // MechanicL
            // 
            this.MechanicL.AutoSize = true;
            this.MechanicL.Location = new System.Drawing.Point(416, 43);
            this.MechanicL.Name = "MechanicL";
            this.MechanicL.Size = new System.Drawing.Size(62, 15);
            this.MechanicL.TabIndex = 7;
            this.MechanicL.Text = "Механик: ";
            // 
            // PilotL
            // 
            this.PilotL.AutoSize = true;
            this.PilotL.Location = new System.Drawing.Point(416, 15);
            this.PilotL.Name = "PilotL";
            this.PilotL.Size = new System.Drawing.Size(48, 15);
            this.PilotL.TabIndex = 6;
            this.PilotL.Text = "Пилот: ";
            // 
            // ListOfTeams
            // 
            this.ListOfTeams.FormattingEnabled = true;
            this.ListOfTeams.ItemHeight = 15;
            this.ListOfTeams.Location = new System.Drawing.Point(12, 12);
            this.ListOfTeams.Name = "ListOfTeams";
            this.ListOfTeams.Size = new System.Drawing.Size(398, 244);
            this.ListOfTeams.TabIndex = 12;
            this.ListOfTeams.SelectedIndexChanged += new System.EventHandler(this.ListOfTeams_SelectedIndexChanged);
            // 
            // GoBack
            // 
            this.GoBack.Location = new System.Drawing.Point(416, 268);
            this.GoBack.Name = "GoBack";
            this.GoBack.Size = new System.Drawing.Size(195, 47);
            this.GoBack.TabIndex = 13;
            this.GoBack.Text = "Вернуться к отчету";
            this.GoBack.UseVisualStyleBackColor = true;
            this.GoBack.Click += new System.EventHandler(this.GoBack_Click);
            // 
            // Refly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(623, 325);
            this.Controls.Add(this.GoBack);
            this.Controls.Add(this.ListOfTeams);
            this.Controls.Add(this.RoundsToRefly);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TeamL);
            this.Controls.Add(this.MechanicL);
            this.Controls.Add(this.PilotL);
            this.Controls.Add(this.SubmitRefly);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Refly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Назначить перелёт";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SubmitRefly;
        private System.Windows.Forms.TextBox RoundsToRefly;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TeamL;
        private System.Windows.Forms.Label MechanicL;
        private System.Windows.Forms.Label PilotL;
        private System.Windows.Forms.ListBox ListOfTeams;
        private System.Windows.Forms.Button GoBack;
    }
}