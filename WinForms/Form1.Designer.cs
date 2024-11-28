namespace WinForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewStudents = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.Addbutton = new System.Windows.Forms.Button();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.buttonDis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewStudents
            // 
            this.listViewStudents.HideSelection = false;
            this.listViewStudents.Location = new System.Drawing.Point(40, 72);
            this.listViewStudents.Name = "listViewStudents";
            this.listViewStudents.Size = new System.Drawing.Size(994, 401);
            this.listViewStudents.TabIndex = 0;
            this.listViewStudents.UseCompatibleStateImageBehavior = false;
            this.listViewStudents.SelectedIndexChanged += new System.EventHandler(this.listViewStudents_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(478, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "СТУДЕНТЫ";
            // 
            // Addbutton
            // 
            this.Addbutton.Location = new System.Drawing.Point(110, 540);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(236, 37);
            this.Addbutton.TabIndex = 2;
            this.Addbutton.Text = "Добавить студента";
            this.Addbutton.UseVisualStyleBackColor = true;
            this.Addbutton.Click += new System.EventHandler(this.Addbutton_Click);
            this.Addbutton.MouseEnter += new System.EventHandler(this.Addbutton_MouseEnter);
            this.Addbutton.MouseLeave += new System.EventHandler(this.Addbutton_MouseLeave);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Location = new System.Drawing.Point(417, 540);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(236, 37);
            this.ButtonUpdate.TabIndex = 3;
            this.ButtonUpdate.Text = "Изменить студента";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.button2_Click);
            this.ButtonUpdate.MouseEnter += new System.EventHandler(this.ButtonUpdate_MouseEnter);
            this.ButtonUpdate.MouseLeave += new System.EventHandler(this.ButtonUpdate_MouseLeave);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(722, 540);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(236, 37);
            this.RemoveButton.TabIndex = 4;
            this.RemoveButton.Text = "Удалить студента";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.button3_Click);
            this.RemoveButton.MouseEnter += new System.EventHandler(this.RemoveButton_MouseEnter);
            this.RemoveButton.MouseLeave += new System.EventHandler(this.RemoveButton_MouseLeave);
            // 
            // buttonDis
            // 
            this.buttonDis.Location = new System.Drawing.Point(344, 597);
            this.buttonDis.Name = "buttonDis";
            this.buttonDis.Size = new System.Drawing.Size(380, 42);
            this.buttonDis.TabIndex = 5;
            this.buttonDis.Text = "Гистаграмма";
            this.buttonDis.UseVisualStyleBackColor = true;
            this.buttonDis.Click += new System.EventHandler(this.button4_Click);
            this.buttonDis.MouseEnter += new System.EventHandler(this.button4_MouseEnter);
            this.buttonDis.MouseLeave += new System.EventHandler(this.buttonDis_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1083, 663);
            this.Controls.Add(this.buttonDis);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.ButtonUpdate);
            this.Controls.Add(this.Addbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewStudents);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Text = "СТУДЕНТЫ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewStudents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button buttonDis;
    }
}

