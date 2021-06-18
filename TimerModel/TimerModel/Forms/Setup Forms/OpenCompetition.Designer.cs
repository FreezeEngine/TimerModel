
namespace CompetitionOrganizer.Forms.Setup_Forms
{
    partial class OpenCompetition
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
            this.Continue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ProjectsList = new System.Windows.Forms.ComboBox();
            this.MainTree = new System.Windows.Forms.TreeView();
            this.InfoBox = new System.Windows.Forms.GroupBox();
            this.Scorekeeper = new System.Windows.Forms.Label();
            this.HeadOfAStart = new System.Windows.Forms.Label();
            this.MainJudge = new System.Windows.Forms.Label();
            this.RoundsCount = new System.Windows.Forms.Label();
            this.ModelsCount = new System.Windows.Forms.Label();
            this.PeopleCount = new System.Windows.Forms.Label();
            this.TeamsCount = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SelectCompetition = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DeleteCompetition = new System.Windows.Forms.Button();
            this.ModelStartBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.StartModelIndex = new System.Windows.Forms.ComboBox();
            this.InfoBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ModelStartBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Continue
            // 
            this.Continue.Location = new System.Drawing.Point(174, 397);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(215, 37);
            this.Continue.TabIndex = 0;
            this.Continue.Text = "Продолжить соревнование";
            this.Continue.UseVisualStyleBackColor = true;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберете проект соревнования:";
            // 
            // ProjectsList
            // 
            this.ProjectsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProjectsList.FormattingEnabled = true;
            this.ProjectsList.Location = new System.Drawing.Point(13, 48);
            this.ProjectsList.Name = "ProjectsList";
            this.ProjectsList.Size = new System.Drawing.Size(376, 23);
            this.ProjectsList.TabIndex = 2;
            this.ProjectsList.SelectedIndexChanged += new System.EventHandler(this.ProjectsList_SelectedIndexChanged);
            // 
            // MainTree
            // 
            this.MainTree.Location = new System.Drawing.Point(6, 22);
            this.MainTree.Name = "MainTree";
            this.MainTree.Size = new System.Drawing.Size(429, 398);
            this.MainTree.TabIndex = 3;
            // 
            // InfoBox
            // 
            this.InfoBox.Controls.Add(this.Scorekeeper);
            this.InfoBox.Controls.Add(this.HeadOfAStart);
            this.InfoBox.Controls.Add(this.MainJudge);
            this.InfoBox.Controls.Add(this.RoundsCount);
            this.InfoBox.Controls.Add(this.ModelsCount);
            this.InfoBox.Controls.Add(this.PeopleCount);
            this.InfoBox.Controls.Add(this.TeamsCount);
            this.InfoBox.Location = new System.Drawing.Point(13, 135);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(376, 202);
            this.InfoBox.TabIndex = 4;
            this.InfoBox.TabStop = false;
            this.InfoBox.Text = "Информация";
            this.InfoBox.Visible = false;
            // 
            // Scorekeeper
            // 
            this.Scorekeeper.AutoSize = true;
            this.Scorekeeper.Location = new System.Drawing.Point(16, 173);
            this.Scorekeeper.Name = "Scorekeeper";
            this.Scorekeeper.Size = new System.Drawing.Size(67, 15);
            this.Scorekeeper.TabIndex = 6;
            this.Scorekeeper.Text = "Секретарь:";
            // 
            // HeadOfAStart
            // 
            this.HeadOfAStart.AutoSize = true;
            this.HeadOfAStart.Location = new System.Drawing.Point(16, 149);
            this.HeadOfAStart.Name = "HeadOfAStart";
            this.HeadOfAStart.Size = new System.Drawing.Size(109, 15);
            this.HeadOfAStart.TabIndex = 5;
            this.HeadOfAStart.Text = "Начальник старта:";
            // 
            // MainJudge
            // 
            this.MainJudge.AutoSize = true;
            this.MainJudge.Location = new System.Drawing.Point(16, 125);
            this.MainJudge.Name = "MainJudge";
            this.MainJudge.Size = new System.Drawing.Size(91, 15);
            this.MainJudge.TabIndex = 4;
            this.MainJudge.Text = "Главный судья:";
            // 
            // RoundsCount
            // 
            this.RoundsCount.AutoSize = true;
            this.RoundsCount.Location = new System.Drawing.Point(16, 94);
            this.RoundsCount.Name = "RoundsCount";
            this.RoundsCount.Size = new System.Drawing.Size(186, 15);
            this.RoundsCount.TabIndex = 3;
            this.RoundsCount.Text = "Количество проведённых туров:";
            // 
            // ModelsCount
            // 
            this.ModelsCount.AutoSize = true;
            this.ModelsCount.Location = new System.Drawing.Point(16, 73);
            this.ModelsCount.Name = "ModelsCount";
            this.ModelsCount.Size = new System.Drawing.Size(220, 15);
            this.ModelsCount.TabIndex = 2;
            this.ModelsCount.Text = "Количество моделей в соревновании: ";
            // 
            // PeopleCount
            // 
            this.PeopleCount.AutoSize = true;
            this.PeopleCount.Location = new System.Drawing.Point(16, 51);
            this.PeopleCount.Name = "PeopleCount";
            this.PeopleCount.Size = new System.Drawing.Size(144, 15);
            this.PeopleCount.TabIndex = 1;
            this.PeopleCount.Text = "Количество участников: ";
            // 
            // TeamsCount
            // 
            this.TeamsCount.AutoSize = true;
            this.TeamsCount.Location = new System.Drawing.Point(16, 30);
            this.TeamsCount.Name = "TeamsCount";
            this.TeamsCount.Size = new System.Drawing.Size(122, 15);
            this.TeamsCount.TabIndex = 0;
            this.TeamsCount.Text = "Количество команд: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MainTree);
            this.groupBox2.Location = new System.Drawing.Point(395, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(441, 426);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Просмотр структуры";
            // 
            // SelectCompetition
            // 
            this.SelectCompetition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectCompetition.Enabled = false;
            this.SelectCompetition.FormattingEnabled = true;
            this.SelectCompetition.Location = new System.Drawing.Point(13, 96);
            this.SelectCompetition.Name = "SelectCompetition";
            this.SelectCompetition.Size = new System.Drawing.Size(376, 23);
            this.SelectCompetition.TabIndex = 6;
            this.SelectCompetition.SelectedIndexChanged += new System.EventHandler(this.SelectCompetition_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Выберете этап соревнования:";
            // 
            // DeleteCompetition
            // 
            this.DeleteCompetition.Location = new System.Drawing.Point(174, 352);
            this.DeleteCompetition.Name = "DeleteCompetition";
            this.DeleteCompetition.Size = new System.Drawing.Size(215, 37);
            this.DeleteCompetition.TabIndex = 8;
            this.DeleteCompetition.Text = "Удалить";
            this.DeleteCompetition.UseVisualStyleBackColor = true;
            this.DeleteCompetition.Click += new System.EventHandler(this.DeleteCompetition_Click);
            // 
            // ModelStartBox
            // 
            this.ModelStartBox.Controls.Add(this.label6);
            this.ModelStartBox.Controls.Add(this.StartModelIndex);
            this.ModelStartBox.Location = new System.Drawing.Point(13, 343);
            this.ModelStartBox.Name = "ModelStartBox";
            this.ModelStartBox.Size = new System.Drawing.Size(155, 89);
            this.ModelStartBox.TabIndex = 18;
            this.ModelStartBox.TabStop = false;
            this.ModelStartBox.Text = "Старт";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(29, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 26);
            this.label6.TabIndex = 7;
            this.label6.Text = "С каких моделей \r\nначинать?";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartModelIndex
            // 
            this.StartModelIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StartModelIndex.FormattingEnabled = true;
            this.StartModelIndex.Location = new System.Drawing.Point(6, 23);
            this.StartModelIndex.Name = "StartModelIndex";
            this.StartModelIndex.Size = new System.Drawing.Size(143, 23);
            this.StartModelIndex.TabIndex = 6;
            this.StartModelIndex.SelectedIndexChanged += new System.EventHandler(this.StartModelIndex_SelectedIndexChanged);
            // 
            // OpenCompetition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(848, 444);
            this.Controls.Add(this.ModelStartBox);
            this.Controls.Add(this.DeleteCompetition);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SelectCompetition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProjectsList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.InfoBox);
            this.Controls.Add(this.Continue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OpenCompetition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Открыть проект соревнования";
            this.InfoBox.ResumeLayout(false);
            this.InfoBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ModelStartBox.ResumeLayout(false);
            this.ModelStartBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ProjectsList;
        private System.Windows.Forms.TreeView MainTree;
        private System.Windows.Forms.GroupBox InfoBox;
        private System.Windows.Forms.Label RoundsCount;
        private System.Windows.Forms.Label ModelsCount;
        private System.Windows.Forms.Label PeopleCount;
        private System.Windows.Forms.Label TeamsCount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox SelectCompetition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Scorekeeper;
        private System.Windows.Forms.Label HeadOfAStart;
        private System.Windows.Forms.Label MainJudge;
        private System.Windows.Forms.Button DeleteCompetition;
        private System.Windows.Forms.GroupBox ModelStartBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox StartModelIndex;
    }
}