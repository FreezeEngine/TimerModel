
namespace TimerModel.Forms
{
    partial class CompetitionManager
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
            this.RoundNum = new System.Windows.Forms.NumericUpDown();
            this.FlyModelsList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MainTree = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LapsAmount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.CompetitionArrangement = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.RoundNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LapsAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // RoundNum
            // 
            this.RoundNum.Location = new System.Drawing.Point(137, 67);
            this.RoundNum.Name = "RoundNum";
            this.RoundNum.ReadOnly = true;
            this.RoundNum.Size = new System.Drawing.Size(63, 23);
            this.RoundNum.TabIndex = 0;
            this.RoundNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RoundNum.ValueChanged += new System.EventHandler(this.RoundCounter_ValueChanged);
            // 
            // FlyModelsList
            // 
            this.FlyModelsList.BackColor = System.Drawing.SystemColors.Window;
            this.FlyModelsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlyModelsList.FormattingEnabled = true;
            this.FlyModelsList.Location = new System.Drawing.Point(115, 28);
            this.FlyModelsList.Name = "FlyModelsList";
            this.FlyModelsList.Size = new System.Drawing.Size(195, 23);
            this.FlyModelsList.TabIndex = 1;
            this.FlyModelsList.SelectedIndexChanged += new System.EventHandler(this.ChooseModelClass_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Класс моделей:";
            // 
            // MainTree
            // 
            this.MainTree.Location = new System.Drawing.Point(343, 22);
            this.MainTree.Name = "MainTree";
            this.MainTree.Size = new System.Drawing.Size(531, 569);
            this.MainTree.TabIndex = 3;
            this.MainTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MainTree_AfterSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Количество туров:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LapsAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.FlyModelsList);
            this.groupBox1.Controls.Add(this.RoundNum);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 149);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки соревнования";
            // 
            // LapsAmount
            // 
            this.LapsAmount.Location = new System.Drawing.Point(137, 108);
            this.LapsAmount.Name = "LapsAmount";
            this.LapsAmount.ReadOnly = true;
            this.LapsAmount.Size = new System.Drawing.Size(63, 23);
            this.LapsAmount.TabIndex = 8;
            this.LapsAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LapsAmount.ValueChanged += new System.EventHandler(this.LapsCounter_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Количество кругов:";
            // 
            // CompetitionArrangement
            // 
            this.CompetitionArrangement.Location = new System.Drawing.Point(12, 167);
            this.CompetitionArrangement.Name = "CompetitionArrangement";
            this.CompetitionArrangement.Size = new System.Drawing.Size(325, 424);
            this.CompetitionArrangement.TabIndex = 8;
            // 
            // CompetitionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(886, 603);
            this.Controls.Add(this.CompetitionArrangement);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MainTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CompetitionManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер соревнования";
            ((System.ComponentModel.ISupportInitialize)(this.RoundNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LapsAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown RoundNum;
        private System.Windows.Forms.ComboBox FlyModelsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView MainTree;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown LapsAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView CompetitionArrangement;
    }
}