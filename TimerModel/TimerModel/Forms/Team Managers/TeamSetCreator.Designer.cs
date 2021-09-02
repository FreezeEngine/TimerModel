
namespace CompetitionOrganizer.Forms.Team_Managers
{
    partial class TeamSetCreator
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
            this.N1 = new System.Windows.Forms.Label();
            this.N1B = new System.Windows.Forms.Button();
            this.N2B = new System.Windows.Forms.Button();
            this.N3B = new System.Windows.Forms.Button();
            this.N2 = new System.Windows.Forms.Label();
            this.N3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // N1
            // 
            this.N1.AutoSize = true;
            this.N1.Location = new System.Drawing.Point(12, 17);
            this.N1.Name = "N1";
            this.N1.Size = new System.Drawing.Size(67, 15);
            this.N1.TabIndex = 0;
            this.N1.Text = "Отсутсвует";
            // 
            // N1B
            // 
            this.N1B.Location = new System.Drawing.Point(371, 12);
            this.N1B.Name = "N1B";
            this.N1B.Size = new System.Drawing.Size(75, 23);
            this.N1B.TabIndex = 1;
            this.N1B.Text = "Выбрать";
            this.N1B.UseVisualStyleBackColor = true;
            this.N1B.Click += new System.EventHandler(this.N1B_Click);
            // 
            // N2B
            // 
            this.N2B.Location = new System.Drawing.Point(371, 41);
            this.N2B.Name = "N2B";
            this.N2B.Size = new System.Drawing.Size(75, 23);
            this.N2B.TabIndex = 2;
            this.N2B.Text = "Выбрать";
            this.N2B.UseVisualStyleBackColor = true;
            this.N2B.Click += new System.EventHandler(this.N2B_Click);
            // 
            // N3B
            // 
            this.N3B.Location = new System.Drawing.Point(371, 70);
            this.N3B.Name = "N3B";
            this.N3B.Size = new System.Drawing.Size(75, 23);
            this.N3B.TabIndex = 3;
            this.N3B.Text = "Выбрать";
            this.N3B.UseVisualStyleBackColor = true;
            this.N3B.Click += new System.EventHandler(this.N3B_Click);
            // 
            // N2
            // 
            this.N2.AutoSize = true;
            this.N2.Location = new System.Drawing.Point(13, 46);
            this.N2.Name = "N2";
            this.N2.Size = new System.Drawing.Size(67, 15);
            this.N2.TabIndex = 4;
            this.N2.Text = "Отсутсвует";
            // 
            // N3
            // 
            this.N3.AutoSize = true;
            this.N3.Location = new System.Drawing.Point(13, 75);
            this.N3.Name = "N3";
            this.N3.Size = new System.Drawing.Size(67, 15);
            this.N3.TabIndex = 5;
            this.N3.Text = "Отсутсвует";
            // 
            // TeamSetCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 105);
            this.Controls.Add(this.N3);
            this.Controls.Add(this.N2);
            this.Controls.Add(this.N3B);
            this.Controls.Add(this.N2B);
            this.Controls.Add(this.N1B);
            this.Controls.Add(this.N1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TeamSetCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор тройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label N1;
        private System.Windows.Forms.Button N1B;
        private System.Windows.Forms.Button N2B;
        private System.Windows.Forms.Button N3B;
        private System.Windows.Forms.Label N2;
        private System.Windows.Forms.Label N3;
    }
}