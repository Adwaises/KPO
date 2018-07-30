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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonGet = new System.Windows.Forms.Button();
            this.dTPickerBy = new System.Windows.Forms.DateTimePicker();
            this.dTPickerFrom = new System.Windows.Forms.DateTimePicker();
            this.cbVariant = new System.Windows.Forms.ComboBox();
            this.labelLetter = new System.Windows.Forms.Label();
            this.labelClass = new System.Windows.Forms.Label();
            this.CBLetter = new System.Windows.Forms.ComboBox();
            this.CBClass = new System.Windows.Forms.ComboBox();
            this.cbFamil = new System.Windows.Forms.ComboBox();
            this.labelBy = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.labelPupil = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьОтчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыДляВсегоКлассаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowDrop = true;
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Location = new System.Drawing.Point(12, 166);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 20;
            this.dataGridView.Size = new System.Drawing.Size(494, 205);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // buttonGet
            // 
            this.buttonGet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGet.Location = new System.Drawing.Point(107, 125);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(92, 25);
            this.buttonGet.TabIndex = 5;
            this.buttonGet.Text = "Получить";
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.button1_Click);
            // 
            // dTPickerBy
            // 
            this.dTPickerBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dTPickerBy.Location = new System.Drawing.Point(57, 72);
            this.dTPickerBy.Name = "dTPickerBy";
            this.dTPickerBy.Size = new System.Drawing.Size(142, 22);
            this.dTPickerBy.TabIndex = 3;
            this.dTPickerBy.ValueChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // dTPickerFrom
            // 
            this.dTPickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dTPickerFrom.Location = new System.Drawing.Point(57, 46);
            this.dTPickerFrom.Name = "dTPickerFrom";
            this.dTPickerFrom.Size = new System.Drawing.Size(142, 22);
            this.dTPickerFrom.TabIndex = 4;
            this.dTPickerFrom.ValueChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // cbVariant
            // 
            this.cbVariant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbVariant.FormattingEnabled = true;
            this.cbVariant.Location = new System.Drawing.Point(57, 98);
            this.cbVariant.Name = "cbVariant";
            this.cbVariant.Size = new System.Drawing.Size(142, 24);
            this.cbVariant.TabIndex = 7;
            this.cbVariant.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelLetter
            // 
            this.labelLetter.AutoSize = true;
            this.labelLetter.Location = new System.Drawing.Point(142, 28);
            this.labelLetter.Name = "labelLetter";
            this.labelLetter.Size = new System.Drawing.Size(48, 16);
            this.labelLetter.TabIndex = 10;
            this.labelLetter.Text = "Буква";
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Location = new System.Drawing.Point(23, 28);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(46, 16);
            this.labelClass.TabIndex = 11;
            this.labelClass.Text = "Класс";
            // 
            // CBLetter
            // 
            this.CBLetter.FormattingEnabled = true;
            this.CBLetter.Location = new System.Drawing.Point(196, 25);
            this.CBLetter.Name = "CBLetter";
            this.CBLetter.Size = new System.Drawing.Size(55, 24);
            this.CBLetter.TabIndex = 9;
            this.CBLetter.SelectedIndexChanged += new System.EventHandler(this.CBLetter_SelectedIndexChanged);
            // 
            // CBClass
            // 
            this.CBClass.FormattingEnabled = true;
            this.CBClass.Location = new System.Drawing.Point(75, 25);
            this.CBClass.Name = "CBClass";
            this.CBClass.Size = new System.Drawing.Size(55, 24);
            this.CBClass.TabIndex = 8;
            this.CBClass.SelectedIndexChanged += new System.EventHandler(this.CBClass_SelectedIndexChanged);
            // 
            // cbFamil
            // 
            this.cbFamil.FormattingEnabled = true;
            this.cbFamil.Location = new System.Drawing.Point(75, 52);
            this.cbFamil.Name = "cbFamil";
            this.cbFamil.Size = new System.Drawing.Size(176, 24);
            this.cbFamil.TabIndex = 9;
            this.cbFamil.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // labelBy
            // 
            this.labelBy.AutoSize = true;
            this.labelBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBy.Location = new System.Drawing.Point(28, 78);
            this.labelBy.Name = "labelBy";
            this.labelBy.Size = new System.Drawing.Size(26, 16);
            this.labelBy.TabIndex = 11;
            this.labelBy.Text = "По";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFrom.Location = new System.Drawing.Point(28, 52);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(17, 16);
            this.labelFrom.TabIndex = 11;
            this.labelFrom.Text = "С";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.CBClass);
            this.groupBox.Controls.Add(this.labelPupil);
            this.groupBox.Controls.Add(this.labelLetter);
            this.groupBox.Controls.Add(this.labelClass);
            this.groupBox.Controls.Add(this.cbFamil);
            this.groupBox.Controls.Add(this.CBLetter);
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox.Location = new System.Drawing.Point(234, 46);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(257, 88);
            this.groupBox.TabIndex = 12;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Выбирете класс";
            // 
            // labelPupil
            // 
            this.labelPupil.AutoSize = true;
            this.labelPupil.Location = new System.Drawing.Point(13, 55);
            this.labelPupil.Name = "labelPupil";
            this.labelPupil.Size = new System.Drawing.Size(56, 16);
            this.labelPupil.TabIndex = 10;
            this.labelPupil.Text = "Ученик";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(519, 25);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сформироватьОтчётToolStripMenuItem,
            this.отчётыДляВсегоКлассаToolStripMenuItem});
            this.отчетыToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(63, 21);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // сформироватьОтчётToolStripMenuItem
            // 
            this.сформироватьОтчётToolStripMenuItem.Name = "сформироватьОтчётToolStripMenuItem";
            this.сформироватьОтчётToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.сформироватьОтчётToolStripMenuItem.Text = "Сформировать отчёт";
            this.сформироватьОтчётToolStripMenuItem.Click += new System.EventHandler(this.сформироватьОтчётToolStripMenuItem_Click);
            // 
            // отчётыДляВсегоКлассаToolStripMenuItem
            // 
            this.отчётыДляВсегоКлассаToolStripMenuItem.Name = "отчётыДляВсегоКлассаToolStripMenuItem";
            this.отчётыДляВсегоКлассаToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.отчётыДляВсегоКлассаToolStripMenuItem.Text = "Отчёты для всего класса";
            this.отчётыДляВсегоКлассаToolStripMenuItem.Click += new System.EventHandler(this.отчётыДляВсегоКлассаToolStripMenuItem_Click);
            // 
            // FormPerformance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 403);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.labelBy);
            this.Controls.Add(this.cbVariant);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonGet);
            this.Controls.Add(this.dTPickerBy);
            this.Controls.Add(this.dTPickerFrom);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(535, 430);
            this.Name = "FormPerformance";
            this.Text = "Успеваемость";
            this.Load += new System.EventHandler(this.FormPerformance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonGet;
        private System.Windows.Forms.DateTimePicker dTPickerBy;
        private System.Windows.Forms.DateTimePicker dTPickerFrom;
        private System.Windows.Forms.ComboBox cbVariant;
        private System.Windows.Forms.Label labelLetter;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.ComboBox CBLetter;
        private System.Windows.Forms.ComboBox CBClass;
        private System.Windows.Forms.ComboBox cbFamil;
        private System.Windows.Forms.Label labelBy;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label labelPupil;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьОтчётToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыДляВсегоКлассаToolStripMenuItem;
    }
}