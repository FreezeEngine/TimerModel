
namespace TimerModel.Forms
{
    partial class TestForm
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
            this.LapCounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LapCounter
            // 
            this.LapCounter.AutoSize = true;
            this.LapCounter.Location = new System.Drawing.Point(80, 75);
            this.LapCounter.Name = "LapCounter";
            this.LapCounter.Size = new System.Drawing.Size(38, 15);
            this.LapCounter.TabIndex = 0;
            this.LapCounter.Text = "label1";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 582);
            this.Controls.Add(this.LapCounter);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LapCounter;
    }
}