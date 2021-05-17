
namespace TimerModel
{
    partial class ExcelDataReadMode
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
            this.mode1 = new System.Windows.Forms.RadioButton();
            this.mode2 = new System.Windows.Forms.RadioButton();
            this.mode3 = new System.Windows.Forms.RadioButton();
            this.Continue = new System.Windows.Forms.Button();
            this.UsingStandartTemplate = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // mode1
            // 
            this.mode1.AutoSize = true;
            this.mode1.Location = new System.Drawing.Point(12, 37);
            this.mode1.Name = "mode1";
            this.mode1.Size = new System.Drawing.Size(268, 19);
            this.mode1.TabIndex = 0;
            this.mode1.Text = "Список без нумерации и подписей колонок";
            this.mode1.UseVisualStyleBackColor = true;
            this.mode1.CheckedChanged += new System.EventHandler(this.UsingStandartTemplate_CheckedChanged);
            // 
            // mode2
            // 
            this.mode2.AutoSize = true;
            this.mode2.Location = new System.Drawing.Point(12, 62);
            this.mode2.Name = "mode2";
            this.mode2.Size = new System.Drawing.Size(276, 19);
            this.mode2.TabIndex = 1;
            this.mode2.Text = "Список с подписями колонок без нумерации";
            this.mode2.UseVisualStyleBackColor = true;
            this.mode2.CheckedChanged += new System.EventHandler(this.UsingStandartTemplate_CheckedChanged);
            // 
            // mode3
            // 
            this.mode3.AutoSize = true;
            this.mode3.Location = new System.Drawing.Point(12, 87);
            this.mode3.Name = "mode3";
            this.mode3.Size = new System.Drawing.Size(273, 19);
            this.mode3.TabIndex = 2;
            this.mode3.Text = "Список с нумерацией без подписей колонок";
            this.mode3.UseVisualStyleBackColor = true;
            this.mode3.CheckedChanged += new System.EventHandler(this.UsingStandartTemplate_CheckedChanged);
            // 
            // Continue
            // 
            this.Continue.Location = new System.Drawing.Point(12, 116);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(276, 30);
            this.Continue.TabIndex = 3;
            this.Continue.Text = "Загрузить таблицу";
            this.Continue.UseVisualStyleBackColor = true;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // UsingStandartTemplate
            // 
            this.UsingStandartTemplate.AutoSize = true;
            this.UsingStandartTemplate.Checked = true;
            this.UsingStandartTemplate.Location = new System.Drawing.Point(12, 13);
            this.UsingStandartTemplate.Name = "UsingStandartTemplate";
            this.UsingStandartTemplate.Size = new System.Drawing.Size(140, 19);
            this.UsingStandartTemplate.TabIndex = 4;
            this.UsingStandartTemplate.TabStop = true;
            this.UsingStandartTemplate.Text = "Стандартный список";
            this.UsingStandartTemplate.UseVisualStyleBackColor = true;
            this.UsingStandartTemplate.CheckedChanged += new System.EventHandler(this.UsingStandartTemplate_CheckedChanged);
            // 
            // ExcelDataReadMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 158);
            this.Controls.Add(this.UsingStandartTemplate);
            this.Controls.Add(this.Continue);
            this.Controls.Add(this.mode3);
            this.Controls.Add(this.mode2);
            this.Controls.Add(this.mode1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ExcelDataReadMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор формата таблицы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton mode1;
        private System.Windows.Forms.RadioButton mode2;
        private System.Windows.Forms.RadioButton mode3;
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.RadioButton UsingStandartTemplate;
    }
}