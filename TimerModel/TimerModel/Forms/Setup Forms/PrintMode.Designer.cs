
namespace TimerModel.Forms.Setup_Forms
{
    partial class PrintMode
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
            this.VerticalPrint = new System.Windows.Forms.RadioButton();
            this.HorizontalPrint = new System.Windows.Forms.RadioButton();
            this.RememberMode = new System.Windows.Forms.CheckBox();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VerticalPrint
            // 
            this.VerticalPrint.AutoSize = true;
            this.VerticalPrint.Location = new System.Drawing.Point(28, 42);
            this.VerticalPrint.Name = "VerticalPrint";
            this.VerticalPrint.Size = new System.Drawing.Size(96, 19);
            this.VerticalPrint.TabIndex = 0;
            this.VerticalPrint.Text = "Вертикально";
            this.VerticalPrint.UseVisualStyleBackColor = true;
            this.VerticalPrint.CheckedChanged += new System.EventHandler(this.VerticalPrint_CheckedChanged);
            // 
            // HorizontalPrint
            // 
            this.HorizontalPrint.AutoSize = true;
            this.HorizontalPrint.Checked = true;
            this.HorizontalPrint.Location = new System.Drawing.Point(28, 14);
            this.HorizontalPrint.Name = "HorizontalPrint";
            this.HorizontalPrint.Size = new System.Drawing.Size(109, 19);
            this.HorizontalPrint.TabIndex = 1;
            this.HorizontalPrint.TabStop = true;
            this.HorizontalPrint.Text = "Горизонтально";
            this.HorizontalPrint.UseVisualStyleBackColor = true;
            this.HorizontalPrint.CheckedChanged += new System.EventHandler(this.VerticalPrint_CheckedChanged);
            // 
            // RememberMode
            // 
            this.RememberMode.AutoSize = true;
            this.RememberMode.Location = new System.Drawing.Point(13, 76);
            this.RememberMode.Name = "RememberMode";
            this.RememberMode.Size = new System.Drawing.Size(126, 19);
            this.RememberMode.TabIndex = 2;
            this.RememberMode.Text = "Запомнить выбор";
            this.RememberMode.UseVisualStyleBackColor = true;
            this.RememberMode.CheckedChanged += new System.EventHandler(this.RememberMode_CheckedChanged);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(12, 101);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(136, 23);
            this.OK.TabIndex = 3;
            this.OK.Text = "Печать";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // PrintMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(160, 133);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.RememberMode);
            this.Controls.Add(this.HorizontalPrint);
            this.Controls.Add(this.VerticalPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PrintMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Режим печати";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton VerticalPrint;
        private System.Windows.Forms.RadioButton HorizontalPrint;
        private System.Windows.Forms.CheckBox RememberMode;
        private System.Windows.Forms.Button OK;
    }
}