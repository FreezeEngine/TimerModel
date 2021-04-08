
namespace TimerModel
{
    partial class ChangeTeamSeparationMode
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
            this.HandMode = new System.Windows.Forms.RadioButton();
            this.AutomaticMode = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Continue
            // 
            this.Continue.Location = new System.Drawing.Point(12, 91);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(265, 36);
            this.Continue.TabIndex = 0;
            this.Continue.Text = "Продолжить";
            this.Continue.UseVisualStyleBackColor = true;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // HandMode
            // 
            this.HandMode.AutoSize = true;
            this.HandMode.Location = new System.Drawing.Point(32, 35);
            this.HandMode.Name = "HandMode";
            this.HandMode.Size = new System.Drawing.Size(75, 19);
            this.HandMode.TabIndex = 1;
            this.HandMode.TabStop = true;
            this.HandMode.Text = "Вручную";
            this.HandMode.UseVisualStyleBackColor = true;
            // 
            // AutomaticMode
            // 
            this.AutomaticMode.AutoSize = true;
            this.AutomaticMode.Location = new System.Drawing.Point(32, 60);
            this.AutomaticMode.Name = "AutomaticMode";
            this.AutomaticMode.Size = new System.Drawing.Size(110, 19);
            this.AutomaticMode.TabIndex = 2;
            this.AutomaticMode.TabStop = true;
            this.AutomaticMode.Text = "Автоматически";
            this.AutomaticMode.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Разбиение по командам";
            // 
            // ChangeTeamSeparationMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 134);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AutomaticMode);
            this.Controls.Add(this.HandMode);
            this.Controls.Add(this.Continue);
            this.MaximumSize = new System.Drawing.Size(305, 173);
            this.MinimumSize = new System.Drawing.Size(305, 173);
            this.Name = "ChangeTeamSeparationMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Режим разбиения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.RadioButton HandMode;
        private System.Windows.Forms.RadioButton AutomaticMode;
        private System.Windows.Forms.Label label1;
    }
}