namespace KPO_System
{
    partial class FormPerformance
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.dTPickerBy = new System.Windows.Forms.DateTimePicker();
            this.dTPickerFrom = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CBLetter = new System.Windows.Forms.ComboBox();
            this.CBClass = new System.Windows.Forms.ComboBox();
            this.cbFamil = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(481, 217);
            this.dataGridView1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(556, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Получить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dTPickerBy
            // 
            this.dTPickerBy.Location = new System.Drawing.Point(160, 46);
            this.dTPickerBy.Name = "dTPickerBy";
            this.dTPickerBy.Size = new System.Drawing.Size(142, 20);
            this.dTPickerBy.TabIndex = 3;
            // 
            // dTPickerFrom
            // 
            this.dTPickerFrom.Location = new System.Drawing.Point(12, 46);
            this.dTPickerFrom.Name = "dTPickerFrom";
            this.dTPickerFrom.Size = new System.Drawing.Size(142, 20);
            this.dTPickerFrom.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(308, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Буква";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Класс";
            // 
            // CBLetter
            // 
            this.CBLetter.FormattingEnabled = true;
            this.CBLetter.Location = new System.Drawing.Point(186, 359);
            this.CBLetter.Name = "CBLetter";
            this.CBLetter.Size = new System.Drawing.Size(82, 21);
            this.CBLetter.TabIndex = 9;
            this.CBLetter.SelectedIndexChanged += new System.EventHandler(this.CBLetter_SelectedIndexChanged);
            // 
            // CBClass
            // 
            this.CBClass.FormattingEnabled = true;
            this.CBClass.Location = new System.Drawing.Point(186, 328);
            this.CBClass.Name = "CBClass";
            this.CBClass.Size = new System.Drawing.Size(82, 21);
            this.CBClass.TabIndex = 8;
            this.CBClass.SelectedIndexChanged += new System.EventHandler(this.CBClass_SelectedIndexChanged);
            // 
            // cbFamil
            // 
            this.cbFamil.FormattingEnabled = true;
            this.cbFamil.Location = new System.Drawing.Point(186, 386);
            this.cbFamil.Name = "cbFamil";
            this.cbFamil.Size = new System.Drawing.Size(116, 21);
            this.cbFamil.TabIndex = 9;
            // 
            // FormPerformance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 512);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFamil);
            this.Controls.Add(this.CBLetter);
            this.Controls.Add(this.CBClass);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dTPickerBy);
            this.Controls.Add(this.dTPickerFrom);
            this.Name = "FormPerformance";
            this.Text = "Успеваемость";
            this.Load += new System.EventHandler(this.FormPerformance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dTPickerBy;
        private System.Windows.Forms.DateTimePicker dTPickerFrom;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBLetter;
        private System.Windows.Forms.ComboBox CBClass;
        private System.Windows.Forms.ComboBox cbFamil;
    }
}