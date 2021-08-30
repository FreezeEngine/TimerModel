
namespace TimerModel
{
    partial class CreateListForm
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
            this.ListOfTeams = new System.Windows.Forms.ListBox();
            this.Add = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.CreateExcelFile = new System.Windows.Forms.Button();
            this.CreateAndUse = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Choose = new System.Windows.Forms.Button();
            this.OpenCompetitionManager = new System.Windows.Forms.Button();
            this.FlyModelsList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.JustUse = new System.Windows.Forms.Button();
            this.ChooseEmpty = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListOfTeams
            // 
            this.ListOfTeams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListOfTeams.FormattingEnabled = true;
            this.ListOfTeams.ItemHeight = 15;
            this.ListOfTeams.Location = new System.Drawing.Point(3, 3);
            this.ListOfTeams.Name = "ListOfTeams";
            this.ListOfTeams.Size = new System.Drawing.Size(477, 529);
            this.ListOfTeams.TabIndex = 0;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(15, 112);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(133, 37);
            this.Add.TabIndex = 1;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(14, 211);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(134, 37);
            this.Remove.TabIndex = 2;
            this.Remove.Text = "Удалить";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // CreateExcelFile
            // 
            this.CreateExcelFile.Location = new System.Drawing.Point(14, 434);
            this.CreateExcelFile.Name = "CreateExcelFile";
            this.CreateExcelFile.Size = new System.Drawing.Size(132, 37);
            this.CreateExcelFile.TabIndex = 3;
            this.CreateExcelFile.Text = "Сохранить";
            this.CreateExcelFile.UseVisualStyleBackColor = true;
            this.CreateExcelFile.Click += new System.EventHandler(this.CreateExcelFile_ClickAsync);
            // 
            // CreateAndUse
            // 
            this.CreateAndUse.Location = new System.Drawing.Point(14, 477);
            this.CreateAndUse.Name = "CreateAndUse";
            this.CreateAndUse.Size = new System.Drawing.Size(133, 51);
            this.CreateAndUse.TabIndex = 4;
            this.CreateAndUse.Text = "Сохранить и использовать";
            this.CreateAndUse.UseVisualStyleBackColor = true;
            this.CreateAndUse.Click += new System.EventHandler(this.CreateAndUse_ClickAsync);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(15, 155);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(133, 37);
            this.Edit.TabIndex = 5;
            this.Edit.Text = "Редактровать";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Choose
            // 
            this.Choose.Location = new System.Drawing.Point(14, 483);
            this.Choose.Name = "Choose";
            this.Choose.Size = new System.Drawing.Size(133, 45);
            this.Choose.TabIndex = 7;
            this.Choose.Text = "Выбрать";
            this.Choose.UseVisualStyleBackColor = true;
            this.Choose.Visible = false;
            this.Choose.Click += new System.EventHandler(this.Choose_Click);
            // 
            // OpenCompetitionManager
            // 
            this.OpenCompetitionManager.Location = new System.Drawing.Point(15, 254);
            this.OpenCompetitionManager.Name = "OpenCompetitionManager";
            this.OpenCompetitionManager.Size = new System.Drawing.Size(133, 57);
            this.OpenCompetitionManager.TabIndex = 8;
            this.OpenCompetitionManager.Text = "Открыть менеджер соревнования";
            this.OpenCompetitionManager.UseVisualStyleBackColor = true;
            this.OpenCompetitionManager.Click += new System.EventHandler(this.OpenCompetitionManager_Click);
            // 
            // FlyModelsList
            // 
            this.FlyModelsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlyModelsList.FormattingEnabled = true;
            this.FlyModelsList.Location = new System.Drawing.Point(15, 73);
            this.FlyModelsList.Name = "FlyModelsList";
            this.FlyModelsList.Size = new System.Drawing.Size(132, 23);
            this.FlyModelsList.TabIndex = 9;
            this.FlyModelsList.SelectedIndexChanged += new System.EventHandler(this.FlyModelsList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Модель:";
            // 
            // JustUse
            // 
            this.JustUse.Location = new System.Drawing.Point(14, 389);
            this.JustUse.Name = "JustUse";
            this.JustUse.Size = new System.Drawing.Size(133, 33);
            this.JustUse.TabIndex = 11;
            this.JustUse.Text = "Использовать";
            this.JustUse.UseVisualStyleBackColor = true;
            this.JustUse.Click += new System.EventHandler(this.JustUse_Click);
            // 
            // ChooseEmpty
            // 
            this.ChooseEmpty.Location = new System.Drawing.Point(14, 428);
            this.ChooseEmpty.Name = "ChooseEmpty";
            this.ChooseEmpty.Size = new System.Drawing.Size(133, 43);
            this.ChooseEmpty.TabIndex = 12;
            this.ChooseEmpty.Text = "Отключить команду";
            this.ChooseEmpty.UseVisualStyleBackColor = true;
            this.ChooseEmpty.Visible = false;
            this.ChooseEmpty.Click += new System.EventHandler(this.ChooseEmpty_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.searchBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ChooseEmpty);
            this.panel1.Controls.Add(this.CreateAndUse);
            this.panel1.Controls.Add(this.Add);
            this.panel1.Controls.Add(this.CreateExcelFile);
            this.panel1.Controls.Add(this.JustUse);
            this.panel1.Controls.Add(this.Remove);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Edit);
            this.panel1.Controls.Add(this.FlyModelsList);
            this.panel1.Controls.Add(this.Choose);
            this.panel1.Controls.Add(this.OpenCompetitionManager);
            this.panel1.Location = new System.Drawing.Point(486, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 537);
            this.panel1.TabIndex = 13;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(15, 27);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(133, 23);
            this.searchBox.TabIndex = 14;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Поиск:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ListOfTeams, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(652, 543);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // CreateListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(652, 543);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(653, 582);
            this.Name = "CreateListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактировать список";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListOfTeams;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Button CreateExcelFile;
        private System.Windows.Forms.Button CreateAndUse;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Choose;
        private System.Windows.Forms.Button OpenCompetitionManager;
        private System.Windows.Forms.ComboBox FlyModelsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button JustUse;
        private System.Windows.Forms.Button ChooseEmpty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label2;
    }
}