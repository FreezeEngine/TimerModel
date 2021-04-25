
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TeamName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пилот:";
            // 
            // Pilot
            // 
            this.Pilot.Location = new System.Drawing.Point(83, 12);
            this.Pilot.Name = "Pilot";
            this.Pilot.Size = new System.Drawing.Size(211, 23);
            this.Pilot.TabIndex = 1;
            // 
            // Mechanic
            // 
            this.Mechanic.Location = new System.Drawing.Point(83, 41);
            this.Mechanic.Name = "Mechanic";
            this.Mechanic.Size = new System.Drawing.Size(211, 23);
            this.Mechanic.TabIndex = 2;
            // 
            // Model
            // 
            this.Model.Location = new System.Drawing.Point(83, 70);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(211, 23);
            this.Model.TabIndex = 3;
            // 
            // AddItem
            // 
            this.AddItem.Location = new System.Drawing.Point(16, 128);
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(282, 38);
            this.AddItem.TabIndex = 4;
            this.AddItem.Text = "Внести";
            this.AddItem.UseVisualStyleBackColor = true;
            this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Механик:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Модель:";
            // 
            // TeamName
            // 
            this.TeamName.Location = new System.Drawing.Point(137, 99);
            this.TeamName.Name = "TeamName";
            this.TeamName.Size = new System.Drawing.Size(157, 23);
            this.TeamName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Название команды:";
            // 
            // AddToListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 179);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TeamName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddItem);
            this.Controls.Add(this.Model);
            this.Controls.Add(this.Mechanic);
            this.Controls.Add(this.Pilot);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(330, 218);
            this.MinimumSize = new System.Drawing.Size(330, 218);
            this.Name = "AddToListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить участника";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Pilot;
        private System.Windows.Forms.TextBox Mechanic;
        private System.Windows.Forms.TextBox Model;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Button AddItem;
        private System.Windows.Forms.TextBox TeamName;
        private System.Windows.Forms.Label label4;
    }
}