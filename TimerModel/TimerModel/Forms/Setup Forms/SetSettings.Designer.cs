
namespace TimerModel
{
    partial class SetSettings
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
            this.Continue = new System.Windows.Forms.Button();
            this.RoundNum = new System.Windows.Forms.NumericUpDown();
            this.LapsAmount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.FlyModelsList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.RoundNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LapsAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество туров";
            // 
            // Continue
            // 
            this.Continue.Location = new System.Drawing.Point(12, 115);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(183, 35);
            this.Continue.TabIndex = 1;
            this.Continue.Text = "Продолжить";
            this.Continue.UseVisualStyleBackColor = true;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // RoundNum
            // 
            this.RoundNum.Location = new System.Drawing.Point(137, 50);
            this.RoundNum.Name = "RoundNum";
            this.RoundNum.ReadOnly = true;
            this.RoundNum.Size = new System.Drawing.Size(58, 23);
            this.RoundNum.TabIndex = 2;
            this.RoundNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RoundNum.ValueChanged += new System.EventHandler(this.RoundNum_ValueChanged);
            // 
            // LapsAmount
            // 
            this.LapsAmount.Location = new System.Drawing.Point(137, 82);
            this.LapsAmount.Name = "LapsAmount";
            this.LapsAmount.ReadOnly = true;
            this.LapsAmount.Size = new System.Drawing.Size(58, 23);
            this.LapsAmount.TabIndex = 4;
            this.LapsAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LapsAmount.ValueChanged += new System.EventHandler(this.LapAmount_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Количество кругов";
            // 
            // FlyModelsList
            // 
            this.FlyModelsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlyModelsList.FormattingEnabled = true;
            this.FlyModelsList.Location = new System.Drawing.Point(12, 12);
            this.FlyModelsList.Name = "FlyModelsList";
            this.FlyModelsList.Size = new System.Drawing.Size(183, 23);
            this.FlyModelsList.TabIndex = 5;
            this.FlyModelsList.SelectedIndexChanged += new System.EventHandler(this.CMList_SelectedIndexChanged);
            // 
            // SetSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 159);
            this.Controls.Add(this.FlyModelsList);
            this.Controls.Add(this.LapsAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RoundNum);
            this.Controls.Add(this.Continue);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "SetSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка";
            ((System.ComponentModel.ISupportInitialize)(this.RoundNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LapsAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.NumericUpDown RoundNum;
        private System.Windows.Forms.NumericUpDown LapsAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FlyModelsList;
    }
}