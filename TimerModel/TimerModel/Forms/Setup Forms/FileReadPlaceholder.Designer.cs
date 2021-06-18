
namespace TimerModel
{
    partial class FileReadPlaceholder
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
            this.LoadingStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoadingStatusLabel
            // 
            this.LoadingStatusLabel.AutoSize = true;
            this.LoadingStatusLabel.Location = new System.Drawing.Point(12, 22);
            this.LoadingStatusLabel.Name = "LoadingStatusLabel";
            this.LoadingStatusLabel.Size = new System.Drawing.Size(64, 15);
            this.LoadingStatusLabel.TabIndex = 4;
            this.LoadingStatusLabel.Text = "Загрузка...";
            // 
            // FileReadPlaceholder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 63);
            this.Controls.Add(this.LoadingStatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FileReadPlaceholder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Загрузка таблицы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LoadingStatusLabel;
    }
}