
namespace TimerModel.Forms.Setup_Forms
{
    partial class ChooseNextModelSet
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
            this.label1 = new System.Windows.Forms.Label();
            this.NextModels = new System.Windows.Forms.Button();
            this.ListOfModels = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выбор следующего класса\r\n";
            // 
            // NextModels
            // 
            this.NextModels.Location = new System.Drawing.Point(12, 88);
            this.NextModels.Name = "NextModels";
            this.NextModels.Size = new System.Drawing.Size(169, 39);
            this.NextModels.TabIndex = 1;
            this.NextModels.Text = "Продолжить";
            this.NextModels.UseVisualStyleBackColor = true;
            this.NextModels.Click += new System.EventHandler(this.NextModels_Click);
            // 
            // ListOfModels
            // 
            this.ListOfModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListOfModels.FormattingEnabled = true;
            this.ListOfModels.Location = new System.Drawing.Point(12, 40);
            this.ListOfModels.Name = "ListOfModels";
            this.ListOfModels.Size = new System.Drawing.Size(169, 23);
            this.ListOfModels.TabIndex = 2;
            // 
            // ChooseNextModelSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 137);
            this.Controls.Add(this.ListOfModels);
            this.Controls.Add(this.NextModels);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChooseNextModelSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Следующие модели";
            this.Load += new System.EventHandler(this.ChooseNextModelSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button NextModels;
        private System.Windows.Forms.ComboBox ListOfModels;
    }
}