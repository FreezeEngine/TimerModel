
namespace TimerModel.Forms.Setup_Forms
{
    partial class PrintModeSelector
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
            this.PrintBoth = new System.Windows.Forms.RadioButton();
            this.ReflyM1 = new System.Windows.Forms.CheckBox();
            this.ReflyM2 = new System.Windows.Forms.CheckBox();
            this.ReflyM3 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EditPrintData = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VerticalPrint
            // 
            this.VerticalPrint.AutoSize = true;
            this.VerticalPrint.Location = new System.Drawing.Point(12, 39);
            this.VerticalPrint.Name = "VerticalPrint";
            this.VerticalPrint.Size = new System.Drawing.Size(96, 19);
            this.VerticalPrint.TabIndex = 0;
            this.VerticalPrint.Text = "Вертикально";
            this.VerticalPrint.UseVisualStyleBackColor = true;
            this.VerticalPrint.CheckedChanged += new System.EventHandler(this.PrintModeChanged);
            // 
            // HorizontalPrint
            // 
            this.HorizontalPrint.AutoSize = true;
            this.HorizontalPrint.Checked = true;
            this.HorizontalPrint.Location = new System.Drawing.Point(12, 12);
            this.HorizontalPrint.Name = "HorizontalPrint";
            this.HorizontalPrint.Size = new System.Drawing.Size(109, 19);
            this.HorizontalPrint.TabIndex = 1;
            this.HorizontalPrint.TabStop = true;
            this.HorizontalPrint.Text = "Горизонтально";
            this.HorizontalPrint.UseVisualStyleBackColor = true;
            this.HorizontalPrint.CheckedChanged += new System.EventHandler(this.PrintModeChanged);
            // 
            // RememberMode
            // 
            this.RememberMode.AutoSize = true;
            this.RememberMode.Location = new System.Drawing.Point(12, 102);
            this.RememberMode.Name = "RememberMode";
            this.RememberMode.Size = new System.Drawing.Size(126, 19);
            this.RememberMode.TabIndex = 2;
            this.RememberMode.Text = "Запомнить выбор";
            this.RememberMode.UseVisualStyleBackColor = true;
            this.RememberMode.CheckedChanged += new System.EventHandler(this.RememberMode_CheckedChanged);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(12, 127);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(219, 23);
            this.OK.TabIndex = 3;
            this.OK.Text = "Печать";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // PrintBoth
            // 
            this.PrintBoth.AutoSize = true;
            this.PrintBoth.Location = new System.Drawing.Point(12, 67);
            this.PrintBoth.Name = "PrintBoth";
            this.PrintBoth.Size = new System.Drawing.Size(100, 19);
            this.PrintBoth.TabIndex = 4;
            this.PrintBoth.Text = "Оба варианта";
            this.PrintBoth.UseVisualStyleBackColor = true;
            this.PrintBoth.CheckedChanged += new System.EventHandler(this.PrintModeChanged);
            // 
            // ReflyM1
            // 
            this.ReflyM1.AutoSize = true;
            this.ReflyM1.Location = new System.Drawing.Point(7, 22);
            this.ReflyM1.Name = "ReflyM1";
            this.ReflyM1.Size = new System.Drawing.Size(92, 19);
            this.ReflyM1.TabIndex = 5;
            this.ReflyM1.Text = "Перелёт М1";
            this.ReflyM1.UseVisualStyleBackColor = true;
            this.ReflyM1.CheckedChanged += new System.EventHandler(this.ReflyM1_CheckedChanged);
            // 
            // ReflyM2
            // 
            this.ReflyM2.AutoSize = true;
            this.ReflyM2.Location = new System.Drawing.Point(7, 47);
            this.ReflyM2.Name = "ReflyM2";
            this.ReflyM2.Size = new System.Drawing.Size(92, 19);
            this.ReflyM2.TabIndex = 6;
            this.ReflyM2.Text = "Перелёт М2";
            this.ReflyM2.UseVisualStyleBackColor = true;
            this.ReflyM2.CheckedChanged += new System.EventHandler(this.ReflyM2_CheckedChanged);
            // 
            // ReflyM3
            // 
            this.ReflyM3.AutoSize = true;
            this.ReflyM3.Location = new System.Drawing.Point(7, 72);
            this.ReflyM3.Name = "ReflyM3";
            this.ReflyM3.Size = new System.Drawing.Size(92, 19);
            this.ReflyM3.TabIndex = 7;
            this.ReflyM3.Text = "Перелёт М3";
            this.ReflyM3.UseVisualStyleBackColor = true;
            this.ReflyM3.CheckedChanged += new System.EventHandler(this.ReflyM3_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReflyM1);
            this.groupBox1.Controls.Add(this.ReflyM3);
            this.groupBox1.Controls.Add(this.ReflyM2);
            this.groupBox1.Location = new System.Drawing.Point(127, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 93);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Перелёты";
            // 
            // EditPrintData
            // 
            this.EditPrintData.Location = new System.Drawing.Point(177, 100);
            this.EditPrintData.Name = "EditPrintData";
            this.EditPrintData.Size = new System.Drawing.Size(54, 23);
            this.EditPrintData.TabIndex = 9;
            this.EditPrintData.Text = "Ред.";
            this.EditPrintData.UseVisualStyleBackColor = true;
            this.EditPrintData.Click += new System.EventHandler(this.EditPrintData_Click);
            // 
            // PrintModeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 162);
            this.Controls.Add(this.EditPrintData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PrintBoth);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.RememberMode);
            this.Controls.Add(this.HorizontalPrint);
            this.Controls.Add(this.VerticalPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PrintModeSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Режим печати";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton VerticalPrint;
        private System.Windows.Forms.RadioButton HorizontalPrint;
        private System.Windows.Forms.CheckBox RememberMode;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.RadioButton PrintBoth;
        private System.Windows.Forms.CheckBox ReflyM1;
        private System.Windows.Forms.CheckBox ReflyM2;
        private System.Windows.Forms.CheckBox ReflyM3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button EditPrintData;
    }
}