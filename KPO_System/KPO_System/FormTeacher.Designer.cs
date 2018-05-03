namespace KPO_System
{
    partial class FormTeacher
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
            this.CBClass = new System.Windows.Forms.ComboBox();
            this.CBLetter = new System.Windows.Forms.ComboBox();
            this.ButGet = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.успеваемостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.посещаемостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подключениеКБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBMark = new System.Windows.Forms.TextBox();
            this.ButPost = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(535, 255);
            this.dataGridView1.TabIndex = 0;
            // 
            // CBClass
            // 
            this.CBClass.FormattingEnabled = true;
            this.CBClass.Location = new System.Drawing.Point(87, 37);
            this.CBClass.Name = "CBClass";
            this.CBClass.Size = new System.Drawing.Size(82, 21);
            this.CBClass.TabIndex = 1;
            // 
            // CBLetter
            // 
            this.CBLetter.FormattingEnabled = true;
            this.CBLetter.Location = new System.Drawing.Point(273, 37);
            this.CBLetter.Name = "CBLetter";
            this.CBLetter.Size = new System.Drawing.Size(121, 21);
            this.CBLetter.TabIndex = 2;
            // 
            // ButGet
            // 
            this.ButGet.Location = new System.Drawing.Point(446, 35);
            this.ButGet.Name = "ButGet";
            this.ButGet.Size = new System.Drawing.Size(75, 23);
            this.ButGet.TabIndex = 3;
            this.ButGet.Text = "Получить";
            this.ButGet.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(560, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.успеваемостьToolStripMenuItem,
            this.посещаемостьToolStripMenuItem,
            this.подключениеКБДToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // успеваемостьToolStripMenuItem
            // 
            this.успеваемостьToolStripMenuItem.Name = "успеваемостьToolStripMenuItem";
            this.успеваемостьToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.успеваемостьToolStripMenuItem.Text = "Успеваемость";
            this.успеваемостьToolStripMenuItem.Click += new System.EventHandler(this.успеваемостьToolStripMenuItem_Click);
            // 
            // посещаемостьToolStripMenuItem
            // 
            this.посещаемостьToolStripMenuItem.Name = "посещаемостьToolStripMenuItem";
            this.посещаемостьToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.посещаемостьToolStripMenuItem.Text = "Посещаемость";
            this.посещаемостьToolStripMenuItem.Click += new System.EventHandler(this.посещаемостьToolStripMenuItem_Click);
            // 
            // подключениеКБДToolStripMenuItem
            // 
            this.подключениеКБДToolStripMenuItem.Name = "подключениеКБДToolStripMenuItem";
            this.подключениеКБДToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.подключениеКБДToolStripMenuItem.Text = "Подключение к БД";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Класс";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Буква";
            // 
            // TBMark
            // 
            this.TBMark.Location = new System.Drawing.Point(294, 356);
            this.TBMark.Name = "TBMark";
            this.TBMark.Size = new System.Drawing.Size(100, 20);
            this.TBMark.TabIndex = 6;
            // 
            // ButPost
            // 
            this.ButPost.Location = new System.Drawing.Point(446, 354);
            this.ButPost.Name = "ButPost";
            this.ButPost.Size = new System.Drawing.Size(75, 23);
            this.ButPost.TabIndex = 7;
            this.ButPost.Text = "Поставить";
            this.ButPost.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Оценка";
            // 
            // FormTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 400);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ButPost);
            this.Controls.Add(this.TBMark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButGet);
            this.Controls.Add(this.CBLetter);
            this.Controls.Add(this.CBClass);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormTeacher";
            this.Text = "FormTeacher";
            this.Load += new System.EventHandler(this.FormTeacher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox CBClass;
        private System.Windows.Forms.ComboBox CBLetter;
        private System.Windows.Forms.Button ButGet;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem успеваемостьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem посещаемостьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подключениеКБДToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBMark;
        private System.Windows.Forms.Button ButPost;
        private System.Windows.Forms.Label label3;
    }
}