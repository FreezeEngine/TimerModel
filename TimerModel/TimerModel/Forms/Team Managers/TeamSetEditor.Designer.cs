
namespace CompetitionOrganizer.Forms.Team_Managers
{
    partial class TeamSetEditor
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
            this.TS1 = new System.Windows.Forms.ComboBox();
            this.Model = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TeamSetsTree = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MoveUp1 = new System.Windows.Forms.Button();
            this.MoveDown1 = new System.Windows.Forms.Button();
            this.TeamSet1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteTeamSet = new System.Windows.Forms.Button();
            this.AddTeamSet = new System.Windows.Forms.Button();
            this.Submit = new System.Windows.Forms.Button();
            this.EditTeamSet = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TS1
            // 
            this.TS1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TS1.Enabled = false;
            this.TS1.FormattingEnabled = true;
            this.TS1.Location = new System.Drawing.Point(10, 70);
            this.TS1.Name = "TS1";
            this.TS1.Size = new System.Drawing.Size(386, 23);
            this.TS1.TabIndex = 0;
            this.TS1.SelectedIndexChanged += new System.EventHandler(this.TS1_SelectedIndexChanged);
            // 
            // Model
            // 
            this.Model.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Model.FormattingEnabled = true;
            this.Model.Location = new System.Drawing.Point(66, 22);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(183, 23);
            this.Model.TabIndex = 1;
            this.Model.SelectedIndexChanged += new System.EventHandler(this.Model_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TeamSetsTree);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 252);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Просмотр";
            // 
            // TeamSetsTree
            // 
            this.TeamSetsTree.Location = new System.Drawing.Point(7, 22);
            this.TeamSetsTree.Name = "TeamSetsTree";
            this.TeamSetsTree.Size = new System.Drawing.Size(422, 224);
            this.TeamSetsTree.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MoveUp1);
            this.groupBox2.Controls.Add(this.MoveDown1);
            this.groupBox2.Controls.Add(this.TeamSet1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Model);
            this.groupBox2.Controls.Add(this.TS1);
            this.groupBox2.Location = new System.Drawing.Point(457, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 171);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры";
            // 
            // MoveUp1
            // 
            this.MoveUp1.Location = new System.Drawing.Point(10, 99);
            this.MoveUp1.Name = "MoveUp1";
            this.MoveUp1.Size = new System.Drawing.Size(40, 26);
            this.MoveUp1.TabIndex = 22;
            this.MoveUp1.Text = " ↑";
            this.MoveUp1.UseVisualStyleBackColor = true;
            this.MoveUp1.Click += new System.EventHandler(this.MoveUp1_Click);
            // 
            // MoveDown1
            // 
            this.MoveDown1.Location = new System.Drawing.Point(10, 137);
            this.MoveDown1.Name = "MoveDown1";
            this.MoveDown1.Size = new System.Drawing.Size(40, 25);
            this.MoveDown1.TabIndex = 19;
            this.MoveDown1.Text = "↓";
            this.MoveDown1.UseVisualStyleBackColor = true;
            this.MoveDown1.Click += new System.EventHandler(this.MoveDown1_Click);
            // 
            // TeamSet1
            // 
            this.TeamSet1.FormattingEnabled = true;
            this.TeamSet1.ItemHeight = 15;
            this.TeamSet1.Location = new System.Drawing.Point(56, 99);
            this.TeamSet1.Name = "TeamSet1";
            this.TeamSet1.Size = new System.Drawing.Size(340, 64);
            this.TeamSet1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тройка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Модель";
            // 
            // DeleteTeamSet
            // 
            this.DeleteTeamSet.Location = new System.Drawing.Point(722, 188);
            this.DeleteTeamSet.Name = "DeleteTeamSet";
            this.DeleteTeamSet.Size = new System.Drawing.Size(137, 34);
            this.DeleteTeamSet.TabIndex = 15;
            this.DeleteTeamSet.Text = "Удалить тройку";
            this.DeleteTeamSet.UseVisualStyleBackColor = true;
            this.DeleteTeamSet.Click += new System.EventHandler(this.DeleteTeamSet_Click);
            // 
            // AddTeamSet
            // 
            this.AddTeamSet.Location = new System.Drawing.Point(457, 188);
            this.AddTeamSet.Name = "AddTeamSet";
            this.AddTeamSet.Size = new System.Drawing.Size(137, 34);
            this.AddTeamSet.TabIndex = 13;
            this.AddTeamSet.Text = "Создать тройку";
            this.AddTeamSet.UseVisualStyleBackColor = true;
            this.AddTeamSet.Click += new System.EventHandler(this.AddTeamSet_Click);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(457, 228);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(402, 36);
            this.Submit.TabIndex = 4;
            this.Submit.Text = "Применить";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // EditTeamSet
            // 
            this.EditTeamSet.Location = new System.Drawing.Point(600, 188);
            this.EditTeamSet.Name = "EditTeamSet";
            this.EditTeamSet.Size = new System.Drawing.Size(116, 34);
            this.EditTeamSet.TabIndex = 16;
            this.EditTeamSet.Text = "Изменить тройку";
            this.EditTeamSet.UseVisualStyleBackColor = true;
            this.EditTeamSet.Click += new System.EventHandler(this.EditTeamSet_Click);
            // 
            // TeamSetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(871, 270);
            this.Controls.Add(this.EditTeamSet);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.AddTeamSet);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DeleteTeamSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TeamSetEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор троек";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox TS1;
        private System.Windows.Forms.ComboBox Model;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox TeamSet1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView TeamSetsTree;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Button DeleteTeamSet;
        private System.Windows.Forms.Button AddTeamSet;
        private System.Windows.Forms.Button MoveUp1;
        private System.Windows.Forms.Button MoveDown1;
        private System.Windows.Forms.Button EditTeamSet;
    }
}