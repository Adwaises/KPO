namespace KPO_System
{
    partial class FormAttendance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBy = new System.Windows.Forms.DateTimePicker();
            this.buttonGet = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbDisc = new System.Windows.Forms.ComboBox();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelBy = new System.Windows.Forms.Label();
            this.cbVariants = new System.Windows.Forms.ComboBox();
            this.CBClass = new System.Windows.Forms.ComboBox();
            this.labelLetter = new System.Windows.Forms.Label();
            this.labelClass = new System.Windows.Forms.Label();
            this.CBLetter = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьОтчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelDisc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerFrom.Location = new System.Drawing.Point(63, 33);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(142, 22);
            this.dateTimePickerFrom.TabIndex = 0;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // dateTimePickerBy
            // 
            this.dateTimePickerBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerBy.Location = new System.Drawing.Point(63, 59);
            this.dateTimePickerBy.Name = "dateTimePickerBy";
            this.dateTimePickerBy.Size = new System.Drawing.Size(142, 22);
            this.dateTimePickerBy.TabIndex = 0;
            this.dateTimePickerBy.ValueChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // buttonGet
            // 
            this.buttonGet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGet.Location = new System.Drawing.Point(401, 62);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(91, 25);
            this.buttonGet.TabIndex = 1;
            this.buttonGet.Text = "Получить";
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 127);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.Size = new System.Drawing.Size(480, 196);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView_CellPainting);
            // 
            // cbDisc
            // 
            this.cbDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDisc.FormattingEnabled = true;
            this.cbDisc.Location = new System.Drawing.Point(346, 31);
            this.cbDisc.Name = "cbDisc";
            this.cbDisc.Size = new System.Drawing.Size(146, 24);
            this.cbDisc.TabIndex = 3;
            this.cbDisc.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFrom.Location = new System.Drawing.Point(29, 35);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(17, 16);
            this.labelFrom.TabIndex = 12;
            this.labelFrom.Text = "С";
            // 
            // labelBy
            // 
            this.labelBy.AutoSize = true;
            this.labelBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBy.Location = new System.Drawing.Point(20, 61);
            this.labelBy.Name = "labelBy";
            this.labelBy.Size = new System.Drawing.Size(26, 16);
            this.labelBy.TabIndex = 13;
            this.labelBy.Text = "По";
            // 
            // cbVariants
            // 
            this.cbVariants.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbVariants.FormattingEnabled = true;
            this.cbVariants.Location = new System.Drawing.Point(63, 85);
            this.cbVariants.Name = "cbVariants";
            this.cbVariants.Size = new System.Drawing.Size(142, 24);
            this.cbVariants.TabIndex = 3;
            this.cbVariants.SelectedIndexChanged += new System.EventHandler(this.comboBoxVariants_SelectedIndexChanged);
            // 
            // CBClass
            // 
            this.CBClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBClass.FormattingEnabled = true;
            this.CBClass.Location = new System.Drawing.Point(303, 31);
            this.CBClass.Name = "CBClass";
            this.CBClass.Size = new System.Drawing.Size(55, 24);
            this.CBClass.TabIndex = 14;
            this.CBClass.SelectedIndexChanged += new System.EventHandler(this.CBClass_SelectedIndexChanged);
            // 
            // labelLetter
            // 
            this.labelLetter.AutoSize = true;
            this.labelLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLetter.Location = new System.Drawing.Point(371, 35);
            this.labelLetter.Name = "labelLetter";
            this.labelLetter.Size = new System.Drawing.Size(48, 16);
            this.labelLetter.TabIndex = 16;
            this.labelLetter.Text = "Буква";
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClass.Location = new System.Drawing.Point(251, 34);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(46, 16);
            this.labelClass.TabIndex = 17;
            this.labelClass.Text = "Класс";
            // 
            // CBLetter
            // 
            this.CBLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBLetter.FormattingEnabled = true;
            this.CBLetter.Location = new System.Drawing.Point(425, 31);
            this.CBLetter.Name = "CBLetter";
            this.CBLetter.Size = new System.Drawing.Size(67, 24);
            this.CBLetter.TabIndex = 15;
            this.CBLetter.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(504, 25);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сформироватьОтчётToolStripMenuItem});
            this.отчетыToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(63, 21);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // сформироватьОтчётToolStripMenuItem
            // 
            this.сформироватьОтчётToolStripMenuItem.Name = "сформироватьОтчётToolStripMenuItem";
            this.сформироватьОтчётToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.сформироватьОтчётToolStripMenuItem.Text = "Сформировать отчёт";
            this.сформироватьОтчётToolStripMenuItem.Click += new System.EventHandler(this.сформироватьОтчётToolStripMenuItem_Click);
            // 
            // labelDisc
            // 
            this.labelDisc.AutoSize = true;
            this.labelDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDisc.Location = new System.Drawing.Point(252, 35);
            this.labelDisc.Name = "labelDisc";
            this.labelDisc.Size = new System.Drawing.Size(88, 16);
            this.labelDisc.TabIndex = 16;
            this.labelDisc.Text = "Дисциплина";
            // 
            // FormAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 351);
            this.Controls.Add(this.cbDisc);
            this.Controls.Add(this.CBClass);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.CBLetter);
            this.Controls.Add(this.labelDisc);
            this.Controls.Add(this.labelLetter);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.labelClass);
            this.Controls.Add(this.labelBy);
            this.Controls.Add(this.cbVariants);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonGet);
            this.Controls.Add(this.dateTimePickerBy);
            this.Controls.Add(this.dateTimePickerFrom);
            this.MinimumSize = new System.Drawing.Size(520, 390);
            this.Name = "FormAttendance";
            this.Text = "Посещаемость";
            this.Load += new System.EventHandler(this.FormAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerBy;
        private System.Windows.Forms.Button buttonGet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbDisc;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelBy;
        private System.Windows.Forms.ComboBox cbVariants;
        private System.Windows.Forms.ComboBox CBClass;
        private System.Windows.Forms.Label labelLetter;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.ComboBox CBLetter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьОтчётToolStripMenuItem;
        private System.Windows.Forms.Label labelDisc;
    }
}