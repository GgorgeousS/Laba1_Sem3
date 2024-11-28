namespace WinForms
{
    partial class UpdateStudentForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textNameUp = new System.Windows.Forms.TextBox();
            this.textSpecialityUp = new System.Windows.Forms.TextBox();
            this.textGroupUp = new System.Windows.Forms.TextBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Изменить данные студента на:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Специальность";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Группа";
            // 
            // textNameUp
            // 
            this.textNameUp.Location = new System.Drawing.Point(92, 127);
            this.textNameUp.Name = "textNameUp";
            this.textNameUp.Size = new System.Drawing.Size(222, 26);
            this.textNameUp.TabIndex = 7;
            // 
            // textSpecialityUp
            // 
            this.textSpecialityUp.Location = new System.Drawing.Point(92, 213);
            this.textSpecialityUp.Name = "textSpecialityUp";
            this.textSpecialityUp.Size = new System.Drawing.Size(222, 26);
            this.textSpecialityUp.TabIndex = 8;
            // 
            // textGroupUp
            // 
            this.textGroupUp.Location = new System.Drawing.Point(92, 305);
            this.textGroupUp.Name = "textGroupUp";
            this.textGroupUp.Size = new System.Drawing.Size(222, 26);
            this.textGroupUp.TabIndex = 9;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(129, 366);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(130, 30);
            this.buttonUpdate.TabIndex = 10;
            this.buttonUpdate.Text = "Изменить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            this.buttonUpdate.MouseEnter += new System.EventHandler(this.buttonUpdate_MouseEnter);
            this.buttonUpdate.MouseLeave += new System.EventHandler(this.buttonUpdate_MouseLeave);
            // 
            // UpdateStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(439, 450);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.textGroupUp);
            this.Controls.Add(this.textSpecialityUp);
            this.Controls.Add(this.textNameUp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "UpdateStudentForm";
            this.Text = "ИЗМЕНЕНИЕ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textNameUp;
        private System.Windows.Forms.TextBox textSpecialityUp;
        private System.Windows.Forms.TextBox textGroupUp;
        private System.Windows.Forms.Button buttonUpdate;
    }
}