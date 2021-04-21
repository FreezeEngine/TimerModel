
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
            this.button1 = new System.Windows.Forms.Button();
            this.Choose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListOfTeams
            // 
            this.ListOfTeams.FormattingEnabled = true;
            this.ListOfTeams.ItemHeight = 15;
            this.ListOfTeams.Location = new System.Drawing.Point(12, 12);
            this.ListOfTeams.Name = "ListOfTeams";
            this.ListOfTeams.Size = new System.Drawing.Size(447, 454);
            this.ListOfTeams.TabIndex = 0;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(465, 12);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(121, 37);
            this.Add.TabIndex = 1;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(464, 131);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(121, 37);
            this.Remove.TabIndex = 2;
            this.Remove.Text = "Удалить";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // CreateExcelFile
            // 
            this.CreateExcelFile.Location = new System.Drawing.Point(465, 372);
            this.CreateExcelFile.Name = "CreateExcelFile";
            this.CreateExcelFile.Size = new System.Drawing.Size(121, 37);
            this.CreateExcelFile.TabIndex = 3;
            this.CreateExcelFile.Text = "Сохранить";
            this.CreateExcelFile.UseVisualStyleBackColor = true;
            this.CreateExcelFile.Click += new System.EventHandler(this.CreateExcelFile_ClickAsync);
            // 
            // CreateAndUse
            // 
            this.CreateAndUse.Location = new System.Drawing.Point(465, 415);
            this.CreateAndUse.Name = "CreateAndUse";
            this.CreateAndUse.Size = new System.Drawing.Size(121, 51);
            this.CreateAndUse.TabIndex = 4;
            this.CreateAndUse.Text = "Сохранить и использовать";
            this.CreateAndUse.UseVisualStyleBackColor = true;
            this.CreateAndUse.Click += new System.EventHandler(this.CreateAndUse_ClickAsync);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(465, 55);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(121, 37);
            this.Edit.TabIndex = 5;
            this.Edit.Text = "Редактровать";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "Тест шаблона";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Choose
            // 
            this.Choose.Location = new System.Drawing.Point(465, 415);
            this.Choose.Name = "Choose";
            this.Choose.Size = new System.Drawing.Size(121, 51);
            this.Choose.TabIndex = 7;
            this.Choose.Text = "Выбрать";
            this.Choose.UseVisualStyleBackColor = true;
            this.Choose.Visible = false;
            this.Choose.Click += new System.EventHandler(this.Choose_Click);
            // 
            // CreateListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 478);
            this.Controls.Add(this.Choose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.CreateAndUse);
            this.Controls.Add(this.CreateExcelFile);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.ListOfTeams);
            this.Name = "CreateListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактировать список";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListOfTeams;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Button CreateExcelFile;
        private System.Windows.Forms.Button CreateAndUse;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Choose;
    }
}