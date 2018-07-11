using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPO_System
{
    //успеваемость
    public partial class FormPerformance : Form
    {
        TeacherController tc = new TeacherController();
        DataTable dt = new DataTable();
        public FormPerformance()
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            if (comboBox1.Text == "Ученик")
            {
                //dataGridView1.DataSource = tc.getPerformancePupil(cbFamil.SelectedIndex,
                //    dTPickerFrom.Value,dTPickerBy.Value);

                dt = tc.getPerformancePupil(cbFamil.SelectedIndex, dTPickerFrom.Value, dTPickerBy.Value);
            }
            else if (comboBox1.Text == "Класс")
            {
                //dataGridView1.DataSource = tc.getPerformanceClass(CBClass.Text, CBLetter.Text,
                //    dTPickerFrom.Value.ToString("yyyy-MM-dd"), dTPickerBy.Value.ToString("yyyy-MM-dd"));

                dt = tc.getPerformanceClass(CBClass.Text, CBLetter.Text,
                    dTPickerFrom.Value.ToString("yyyy-MM-dd"), dTPickerBy.Value.ToString("yyyy-MM-dd"));
            }
            else if (comboBox1.Text == "Школа")
            {
                //dataGridView1.DataSource = tc.getPerformanceSchool(dTPickerFrom.Value.ToString("yyyy-MM-dd"), dTPickerBy.Value.ToString("yyyy-MM-dd"));
                dt = tc.getPerformanceSchool(dTPickerFrom.Value.ToString("yyyy-MM-dd"), dTPickerBy.Value.ToString("yyyy-MM-dd"));
            }
            dataGridView1.DataSource = dt;
            noSort();
        }

        private void noSort()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            
        }

        private void FormPerformance_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Ученик");
            comboBox1.Items.Add("Класс");
            comboBox1.Items.Add("Школа");
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Ученик")
            {
                отчётыДляВсегоКлассаToolStripMenuItem.Visible = false;
                groupBox1.Visible = true;
                label5.Visible = true;
                cbFamil.Visible = true;
                groupBox1.Height = 90;

                CBClass.Items.Clear();

                List<string> list = tc.getListNumClass();
                for (int i = 0; i < list.Count; i++)
                {
                    CBClass.Items.Add(list[i]);
                }
                CBClass.SelectedIndex = 0;
            } else if(comboBox1.Text == "Класс")
            {
                groupBox1.Visible = true;

                label5.Visible = false;
                cbFamil.Visible = false;
                groupBox1.Height = 60;
                отчётыДляВсегоКлассаToolStripMenuItem.Visible = true;

            }
            else if (comboBox1.Text == "Школа")
            {
                groupBox1.Visible = false;
                отчётыДляВсегоКлассаToolStripMenuItem.Visible = false;
            }




        }

        private void CBClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBLetter.Items.Clear();

            List<string> list = new List<string>();

            list = tc.getListLetters(CBClass.Text);


            for (int i = 0; i < list.Count; i++)
            {
                CBLetter.Items.Add(list[i]);
            }
            CBLetter.SelectedIndex = 0;
        }

        private void CBLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFamil.Items.Clear();
            List<string> list = new List<string>();
            list = tc.getFamilPupils(CBClass.Text,CBLetter.Text);
            for (int i = 0; i < list.Count; i++)
            {
                cbFamil.Items.Add(list[i]);
            }
            cbFamil.SelectedIndex = 0;
            
           
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (comboBox1.Text == "Ученик")
            {
                if (e.RowIndex == -1 && e.ColumnIndex < dataGridView1.Columns.Count && e.ColumnIndex > 0)
                {
                    e.PaintBackground(e.CellBounds, true);
                    e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                    e.Graphics.RotateTransform(270);
                    e.Graphics.DrawString(e.FormattedValue?.ToString(), e.CellStyle.Font, Brushes.Black, 5, 5);
                    e.Graphics.ResetTransform();
                    e.Handled = true;
                    dataGridView1.ColumnHeadersHeight = 70;
                    //dataGridView1.RowHeadersWidth = 20;
                    if (e.ColumnIndex > 0)
                    {
                        DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.Width = 20;
                    }


                }
            } else if(comboBox1.Text == "Класс")
            {
                if (e.RowIndex == -1 && e.ColumnIndex < dataGridView1.Columns.Count && e.ColumnIndex > 2)
                {
                    e.PaintBackground(e.CellBounds, true);
                    e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                    e.Graphics.RotateTransform(270);
                    e.Graphics.DrawString(e.FormattedValue?.ToString(), e.CellStyle.Font, Brushes.Black, 5, 5);
                    e.Graphics.ResetTransform();
                    e.Handled = true;
                    dataGridView1.ColumnHeadersHeight = 100;
                    
                    if (e.ColumnIndex > 2)
                    {
                        DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                        column.Width = 30;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                }
            } else
            {
                if (e.RowIndex == -1 && e.ColumnIndex < dataGridView1.Columns.Count && e.ColumnIndex > 0)
                {
                    e.PaintBackground(e.CellBounds, true);
                    e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                    e.Graphics.RotateTransform(270);
                    e.Graphics.DrawString(e.FormattedValue?.ToString(), e.CellStyle.Font, Brushes.Black, 5, 5);
                    e.Graphics.ResetTransform();
                    e.Handled = true;
                    dataGridView1.ColumnHeadersHeight = 100;
                    
                    if (e.ColumnIndex > 0)
                    {
                        DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.Width = 30;
                    }

                }
                //else if (e.RowIndex == -1 && e.ColumnIndex < dataGridView1.Columns.Count && e.ColumnIndex == 0)
                //{
                //    DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                //    column.Width = 50;
                //}
            }

        }

        Reports report = new Reports();
        private void сформироватьОтчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.DataSource == null)
            {
                MessageBox.Show("Получите данные для отчёта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (comboBox1.Text == "Ученик")
            {
                //dataGridView1.DataSource = tc.getPerformancePupil(cbFamil.SelectedIndex,
                //    dTPickerFrom.Value, dTPickerBy.Value);

                //dt = tc.getPerformancePupil(cbFamil.SelectedIndex, dTPickerFrom.Value, dTPickerBy.Value);

                report.createReportPupil(dt, cbFamil.SelectedItem.ToString(), dTPickerFrom.Value, dTPickerBy.Value);
                MessageBox.Show("Отчёт сформирован", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "Класс")
            {
                //dataGridView1.DataSource = tc.getPerformanceClass(CBClass.Text, CBLetter.Text,
                //    dTPickerFrom.Value.ToString("yyyy-MM-dd"), dTPickerBy.Value.ToString("yyyy-MM-dd"));

                //dt = tc.getPerformanceClass(CBClass.Text, CBLetter.Text,
                //    dTPickerFrom.Value.ToString("yyyy-MM-dd"), dTPickerBy.Value.ToString("yyyy-MM-dd"));

                report.createReportClass(dt, CBClass.Text+ CBLetter.Text, dTPickerFrom.Value, dTPickerBy.Value);
                MessageBox.Show("Отчёт сформирован", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "Школа")
            {
                //dataGridView1.DataSource = tc.getPerformanceSchool(dTPickerFrom.Value.ToString("yyyy-MM-dd"), dTPickerBy.Value.ToString("yyyy-MM-dd"));
                //dt = tc.getPerformanceSchool(dTPickerFrom.Value.ToString("yyyy-MM-dd"), dTPickerBy.Value.ToString("yyyy-MM-dd"));

                report.createReportSchool(dt, dTPickerFrom.Value, dTPickerBy.Value);
                MessageBox.Show("Отчёт сформирован", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void отчётыДляВсегоКлассаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Получите данные для отчёта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //report.createReportSchool(dt, dTPickerFrom.Value, dTPickerBy.Value);

            //dt = tc.getPerformancePupil(cbFamil.SelectedIndex, dTPickerFrom.Value, dTPickerBy.Value);

            List<string> list = tc.getFamilPupils(CBClass.Text, CBLetter.Text);
            for (int i=0; i< list.Count;i++)
            {
                dt = tc.getPerformancePupil(i, dTPickerFrom.Value, dTPickerBy.Value);
                report.createReportPupil(dt, list[i], dTPickerFrom.Value, dTPickerBy.Value);
            }

            dt = tc.getPerformanceClass(CBClass.Text, CBLetter.Text,
                   dTPickerFrom.Value.ToString("yyyy-MM-dd"), dTPickerBy.Value.ToString("yyyy-MM-dd"));

            MessageBox.Show("Отчёты сформированы", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
