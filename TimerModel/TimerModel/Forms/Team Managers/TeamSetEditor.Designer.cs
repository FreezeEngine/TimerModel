
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
            this.MoveUp2 = new System.Windows.Forms.Button();
            this.MoveDown2 = new System.Windows.Forms.Button();
            this.MoveDown1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DeleteTeamSet2 = new System.Windows.Forms.Button();
            this.DeleteTeamSet1 = new System.Windows.Forms.Button();
            this.AddTeamSet2 = new System.Windows.Forms.Button();
            this.AddTeamSet1 = new System.Windows.Forms.Button();
            this.Exchange = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Model2 = new System.Windows.Forms.ComboBox();
            this.TeamSet2 = new System.Windows.Forms.ListBox();
            this.TeamSet1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TS2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Submit = new System.Windows.Forms.Button();
            this.Shuffle1 = new System.Windows.Forms.Button();
            this.Shuffle2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TS1
            // 
            this.TS1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TS1.Enabled = false;
            this.TS1.FormattingEnabled = true;
            this.TS1.Location = new System.Drawing.Point(10, 97);
            this.TS1.Name = "TS1";
            this.TS1.Size = new System.Drawing.Size(353, 23);
            this.TS1.TabIndex = 0;
            this.TS1.SelectedIndexChanged += new System.EventHandler(this.TS1_SelectedIndexChanged);
            // 
            // Model
            // 
            this.Model.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Model.FormattingEnabled = true;
            this.Model.Location = new System.Drawing.Point(10, 44);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(190, 23);
            this.Model.TabIndex = 1;
            this.Model.SelectedIndexChanged += new System.EventHandler(this.Model_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TeamSetsTree);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 296);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Просмотр";
            // 
            // TeamSetsTree
            // 
            this.TeamSetsTree.Location = new System.Drawing.Point(7, 22);
            this.TeamSetsTree.Name = "TeamSetsTree";
            this.TeamSetsTree.Size = new System.Drawing.Size(422, 266);
            this.TeamSetsTree.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Shuffle2);
            this.groupBox2.Controls.Add(this.Shuffle1);
            this.groupBox2.Controls.Add(this.MoveUp1);
            this.groupBox2.Controls.Add(this.MoveUp2);
            this.groupBox2.Controls.Add(this.MoveDown2);
            this.groupBox2.Controls.Add(this.MoveDown1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.DeleteTeamSet2);
            this.groupBox2.Controls.Add(this.DeleteTeamSet1);
            this.groupBox2.Controls.Add(this.AddTeamSet2);
            this.groupBox2.Controls.Add(this.AddTeamSet1);
            this.groupBox2.Controls.Add(this.Exchange);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Model2);
            this.groupBox2.Controls.Add(this.TeamSet2);
            this.groupBox2.Controls.Add(this.TeamSet1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TS2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Model);
            this.groupBox2.Controls.Add(this.TS1);
            this.groupBox2.Location = new System.Drawing.Point(457, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(733, 252);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры";
            // 
            // MoveUp1
            // 
            this.MoveUp1.Location = new System.Drawing.Point(10, 126);
            this.MoveUp1.Name = "MoveUp1";
            this.MoveUp1.Size = new System.Drawing.Size(40, 35);
            this.MoveUp1.TabIndex = 22;
            this.MoveUp1.Text = " ↑";
            this.MoveUp1.UseVisualStyleBackColor = true;
            this.MoveUp1.Click += new System.EventHandler(this.MoveUp1_Click);
            // 
            // MoveUp2
            // 
            this.MoveUp2.Location = new System.Drawing.Point(682, 126);
            this.MoveUp2.Name = "MoveUp2";
            this.MoveUp2.Size = new System.Drawing.Size(40, 35);
            this.MoveUp2.TabIndex = 21;
            this.MoveUp2.Text = " ↑";
            this.MoveUp2.UseVisualStyleBackColor = true;
            this.MoveUp2.Click += new System.EventHandler(this.MoveUp2_Click);
            // 
            // MoveDown2
            // 
            this.MoveDown2.Location = new System.Drawing.Point(682, 170);
            this.MoveDown2.Name = "MoveDown2";
            this.MoveDown2.Size = new System.Drawing.Size(40, 35);
            this.MoveDown2.TabIndex = 20;
            this.MoveDown2.Text = "↓";
            this.MoveDown2.UseVisualStyleBackColor = true;
            this.MoveDown2.Click += new System.EventHandler(this.MoveDown2_Click);
            // 
            // MoveDown1
            // 
            this.MoveDown1.Location = new System.Drawing.Point(10, 170);
            this.MoveDown1.Name = "MoveDown1";
            this.MoveDown1.Size = new System.Drawing.Size(40, 35);
            this.MoveDown1.TabIndex = 19;
            this.MoveDown1.Text = "↓";
            this.MoveDown1.UseVisualStyleBackColor = true;
            this.MoveDown1.Click += new System.EventHandler(this.MoveDown1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(565, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Добавить команду";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(206, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Добавить команду";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DeleteTeamSet2
            // 
            this.DeleteTeamSet2.Location = new System.Drawing.Point(369, 211);
            this.DeleteTeamSet2.Name = "DeleteTeamSet2";
            this.DeleteTeamSet2.Size = new System.Drawing.Size(160, 34);
            this.DeleteTeamSet2.TabIndex = 16;
            this.DeleteTeamSet2.Text = "Удалить тройку";
            this.DeleteTeamSet2.UseVisualStyleBackColor = true;
            this.DeleteTeamSet2.Click += new System.EventHandler(this.DeleteTeamSet2_Click);
            // 
            // DeleteTeamSet1
            // 
            this.DeleteTeamSet1.Location = new System.Drawing.Point(203, 211);
            this.DeleteTeamSet1.Name = "DeleteTeamSet1";
            this.DeleteTeamSet1.Size = new System.Drawing.Size(160, 34);
            this.DeleteTeamSet1.TabIndex = 15;
            this.DeleteTeamSet1.Text = "Удалить тройку";
            this.DeleteTeamSet1.UseVisualStyleBackColor = true;
            this.DeleteTeamSet1.Click += new System.EventHandler(this.DeleteTeamSet1_Click);
            // 
            // AddTeamSet2
            // 
            this.AddTeamSet2.Location = new System.Drawing.Point(532, 211);
            this.AddTeamSet2.Name = "AddTeamSet2";
            this.AddTeamSet2.Size = new System.Drawing.Size(190, 34);
            this.AddTeamSet2.TabIndex = 14;
            this.AddTeamSet2.Text = "Добавить тройку";
            this.AddTeamSet2.UseVisualStyleBackColor = true;
            this.AddTeamSet2.Click += new System.EventHandler(this.AddTeamSet2_Click);
            // 
            // AddTeamSet1
            // 
            this.AddTeamSet1.Location = new System.Drawing.Point(10, 211);
            this.AddTeamSet1.Name = "AddTeamSet1";
            this.AddTeamSet1.Size = new System.Drawing.Size(190, 34);
            this.AddTeamSet1.TabIndex = 13;
            this.AddTeamSet1.Text = "Добавить тройку";
            this.AddTeamSet1.UseVisualStyleBackColor = true;
            this.AddTeamSet1.Click += new System.EventHandler(this.AddTeamSet1_Click);
            // 
            // Exchange
            // 
            this.Exchange.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Exchange.Location = new System.Drawing.Point(203, 155);
            this.Exchange.Margin = new System.Windows.Forms.Padding(0);
            this.Exchange.Name = "Exchange";
            this.Exchange.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Exchange.Size = new System.Drawing.Size(326, 25);
            this.Exchange.TabIndex = 12;
            this.Exchange.Text = "<->";
            this.Exchange.UseVisualStyleBackColor = true;
            this.Exchange.Click += new System.EventHandler(this.Exchange_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Модель #2";
            // 
            // Model2
            // 
            this.Model2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Model2.FormattingEnabled = true;
            this.Model2.Location = new System.Drawing.Point(369, 44);
            this.Model2.Name = "Model2";
            this.Model2.Size = new System.Drawing.Size(190, 23);
            this.Model2.TabIndex = 9;
            this.Model2.SelectedIndexChanged += new System.EventHandler(this.Model2_SelectedIndexChanged);
            // 
            // TeamSet2
            // 
            this.TeamSet2.FormattingEnabled = true;
            this.TeamSet2.ItemHeight = 15;
            this.TeamSet2.Location = new System.Drawing.Point(532, 126);
            this.TeamSet2.Name = "TeamSet2";
            this.TeamSet2.Size = new System.Drawing.Size(145, 79);
            this.TeamSet2.TabIndex = 6;
            // 
            // TeamSet1
            // 
            this.TeamSet1.FormattingEnabled = true;
            this.TeamSet1.ItemHeight = 15;
            this.TeamSet1.Location = new System.Drawing.Point(56, 126);
            this.TeamSet1.Name = "TeamSet1";
            this.TeamSet1.Size = new System.Drawing.Size(144, 79);
            this.TeamSet1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Тройка #2";
            // 
            // TS2
            // 
            this.TS2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TS2.Enabled = false;
            this.TS2.FormattingEnabled = true;
            this.TS2.Location = new System.Drawing.Point(369, 97);
            this.TS2.Name = "TS2";
            this.TS2.Size = new System.Drawing.Size(353, 23);
            this.TS2.TabIndex = 4;
            this.TS2.SelectedIndexChanged += new System.EventHandler(this.TS2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тройка #1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Модель #1";
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(457, 270);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(733, 38);
            this.Submit.TabIndex = 4;
            this.Submit.Text = "Применить";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // Shuffle1
            // 
            this.Shuffle1.Location = new System.Drawing.Point(206, 15);
            this.Shuffle1.Name = "Shuffle1";
            this.Shuffle1.Size = new System.Drawing.Size(157, 23);
            this.Shuffle1.TabIndex = 23;
            this.Shuffle1.Text = "Перемешать";
            this.Shuffle1.UseVisualStyleBackColor = true;
            this.Shuffle1.Click += new System.EventHandler(this.Shuffle1_Click);
            // 
            // Shuffle2
            // 
            this.Shuffle2.Location = new System.Drawing.Point(565, 15);
            this.Shuffle2.Name = "Shuffle2";
            this.Shuffle2.Size = new System.Drawing.Size(157, 23);
            this.Shuffle2.TabIndex = 24;
            this.Shuffle2.Text = "Перемешать";
            this.Shuffle2.UseVisualStyleBackColor = true;
            this.Shuffle2.Click += new System.EventHandler(this.Shuffle2_Click);
            // 
            // TeamSetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1196, 316);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
        private System.Windows.Forms.ListBox TeamSet2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TS2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView TeamSetsTree;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Model2;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Button Exchange;
        private System.Windows.Forms.Button DeleteTeamSet2;
        private System.Windows.Forms.Button DeleteTeamSet1;
        private System.Windows.Forms.Button AddTeamSet2;
        private System.Windows.Forms.Button AddTeamSet1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button MoveUp1;
        private System.Windows.Forms.Button MoveUp2;
        private System.Windows.Forms.Button MoveDown2;
        private System.Windows.Forms.Button MoveDown1;
        private System.Windows.Forms.Button Shuffle2;
        private System.Windows.Forms.Button Shuffle1;
    }
}