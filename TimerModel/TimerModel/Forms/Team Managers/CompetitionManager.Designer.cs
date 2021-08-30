
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
            this.FlyModelsList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MainTree = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LapsAmount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EditTeamSets = new System.Windows.Forms.Button();
            this.TeamSetsTree = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LapsAmount)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LapsAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FlyModelsList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 98);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки соревнования";
            // 
            // LapsAmount
            // 
            this.LapsAmount.Location = new System.Drawing.Point(137, 63);
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
            this.label3.Location = new System.Drawing.Point(16, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Количество кругов:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EditTeamSets);
            this.groupBox2.Controls.Add(this.TeamSetsTree);
            this.groupBox2.Location = new System.Drawing.Point(12, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 475);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тройки";
            // 
            // EditTeamSets
            // 
            this.EditTeamSets.Location = new System.Drawing.Point(16, 22);
            this.EditTeamSets.Name = "EditTeamSets";
            this.EditTeamSets.Size = new System.Drawing.Size(294, 23);
            this.EditTeamSets.TabIndex = 1;
            this.EditTeamSets.Text = "Редактировать";
            this.EditTeamSets.UseVisualStyleBackColor = true;
            this.EditTeamSets.Click += new System.EventHandler(this.EditTeamSets_Click);
            // 
            // TeamSetsTree
            // 
            this.TeamSetsTree.Location = new System.Drawing.Point(16, 51);
            this.TeamSetsTree.Name = "TeamSetsTree";
            this.TeamSetsTree.Size = new System.Drawing.Size(294, 408);
            this.TeamSetsTree.TabIndex = 0;
            // 
            // CompetitionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(886, 603);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MainTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CompetitionManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер соревнования";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LapsAmount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox FlyModelsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView MainTree;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown LapsAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button EditTeamSets;
        private System.Windows.Forms.TreeView TeamSetsTree;
    }
}