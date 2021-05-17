
namespace TimerModel
{
    partial class AddToListForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Pilot = new System.Windows.Forms.TextBox();
            this.Mechanic = new System.Windows.Forms.TextBox();
            this.Model = new System.Windows.Forms.TextBox();
            this.AddItem = new System.Windows.Forms.Button();
            this.TeamName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MechanicsList = new System.Windows.Forms.ComboBox();
            this.ModelsList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пилот:";
            // 
            // Pilot
            // 
            this.Pilot.Location = new System.Drawing.Point(71, 28);
            this.Pilot.Name = "Pilot";
            this.Pilot.Size = new System.Drawing.Size(211, 23);
            this.Pilot.TabIndex = 1;
            // 
            // Mechanic
            // 
            this.Mechanic.Location = new System.Drawing.Point(13, 24);
            this.Mechanic.Name = "Mechanic";
            this.Mechanic.Size = new System.Drawing.Size(257, 23);
            this.Mechanic.TabIndex = 2;
            // 
            // Model
            // 
            this.Model.Location = new System.Drawing.Point(13, 22);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(257, 23);
            this.Model.TabIndex = 3;
            // 
            // AddItem
            // 
            this.AddItem.Location = new System.Drawing.Point(12, 287);
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(282, 38);
            this.AddItem.TabIndex = 4;
            this.AddItem.Text = "Внести";
            this.AddItem.UseVisualStyleBackColor = true;
            this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // TeamName
            // 
            this.TeamName.Location = new System.Drawing.Point(137, 258);
            this.TeamName.Name = "TeamName";
            this.TeamName.Size = new System.Drawing.Size(157, 23);
            this.TeamName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Название команды:";
            // 
            // MechanicsList
            // 
            this.MechanicsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MechanicsList.FormattingEnabled = true;
            this.MechanicsList.Location = new System.Drawing.Point(13, 52);
            this.MechanicsList.Name = "MechanicsList";
            this.MechanicsList.Size = new System.Drawing.Size(257, 23);
            this.MechanicsList.TabIndex = 9;
            this.MechanicsList.SelectedIndexChanged += new System.EventHandler(this.MechanicsList_SelectedIndexChanged);
            // 
            // ModelsList
            // 
            this.ModelsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModelsList.FormattingEnabled = true;
            this.ModelsList.Location = new System.Drawing.Point(13, 50);
            this.ModelsList.Name = "ModelsList";
            this.ModelsList.Size = new System.Drawing.Size(257, 23);
            this.ModelsList.TabIndex = 10;
            this.ModelsList.SelectedIndexChanged += new System.EventHandler(this.ModelsList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ModelsList);
            this.groupBox1.Controls.Add(this.Model);
            this.groupBox1.Location = new System.Drawing.Point(12, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 87);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Модель";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Mechanic);
            this.groupBox2.Controls.Add(this.MechanicsList);
            this.groupBox2.Location = new System.Drawing.Point(12, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 87);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Механик";
            // 
            // AddToListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 337);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TeamName);
            this.Controls.Add(this.AddItem);
            this.Controls.Add(this.Pilot);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "AddToListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить участника";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Pilot;
        private System.Windows.Forms.TextBox Mechanic;
        private System.Windows.Forms.TextBox Model;
        protected System.Windows.Forms.Button AddItem;
        private System.Windows.Forms.TextBox TeamName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox MechanicsList;
        private System.Windows.Forms.ComboBox ModelsList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}