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
        TeacherController tc;
        DataTable dt = new DataTable();
        bool isNotChange = false;
        Reports report = new Reports();

        string paint = "";

        public FormPerformance(TeacherController _tc)
        {
            tc = _tc;
            InitializeComponent();
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.DataSource = null;
                if (cbVariant.Text == "Ученик")
                {
                    dt = tc.getPerformancePupil(cbFamil.SelectedIndex, dTPickerFrom.Value, dTPickerBy.Value);
                }
                else if (cbVariant.Text == "Класс")
                {
                    dt = tc.getPerformanceClass(CBClass.Text, CBLetter.Text,
                        dTPickerFrom.Value.ToString("yyyy-MM-dd"), dTPickerBy.Value.ToString("yyyy-MM-dd"));
                }
                else if (cbVariant.Text == "Школа")
                {
                    dt = tc.getPerformanceSchool(dTPickerFrom.Value.ToString("yyyy-MM-dd"), dTPickerBy.Value.ToString("yyyy-MM-dd"));
                }

                paint = cbVariant.Text;

                dataGridView.DataSource = dt;
                noSort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isNotChange = true;
        }

        private void noSort()
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            
        }

        private void FormPerformance_Load(object sender, EventArgs e)
        {
            cbVariant.Items.Add("Ученик");
            cbVariant.Items.Add("Класс");
            cbVariant.Items.Add("Школа");
            cbVariant.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbVariant.Text == "Ученик")
            {
                отчётыДляВсегоКлассаToolStripMenuItem.Visible = false;
                groupBox.Visible = true;
                labelPupil.Visible = true;
                cbFamil.Visible = true;
                groupBox.Height = 90;

                CBClass.Items.Clear();

                List<string> list = tc.getListNumClass();
                for (int i = 0; i < list.Count; i++)
                {
                    CBClass.Items.Add(list[i]);
                }
                CBClass.SelectedIndex = 0;
            } else if(cbVariant.Text == "Класс")
            {
                groupBox.Visible = true;

                labelPupil.Visible = false;
                cbFamil.Visible = false;
                groupBox.Height = 60;
                отчётыДляВсегоКлассаToolStripMenuItem.Visible = true;

            }
            else if (cbVariant.Text == "Школа")
            {
                groupBox.Visible = false;
                отчётыДляВсегоКлассаToolStripMenuItem.Visible = false;
            }

            isNotChange = false;


        }

        private void CBClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            isNotChange = false;
            CBLetter.Items.Clear();
            try {


                List<string> list = new List<string>();

                list = tc.getListLetters(CBClass.Text);


                for (int i = 0; i < list.Count; i++)
                {
                    CBLetter.Items.Add(list[i]);
                }
                CBLetter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось получить список\r\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CBLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            isNotChange = false;
            cbFamil.Items.Clear();
            try { 
            List<string> list = new List<string>();
            list = tc.getFamilPupils(CBClass.Text,CBLetter.Text);
            for (int i = 0; i < list.Count; i++)
            {
                cbFamil.Items.Add(list[i]);
            }
            cbFamil.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось получить список\r\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
         //   if (isNotChange)
          //  {
                if (paint == "Ученик")
                {
                    if (e.RowIndex == -1 && e.ColumnIndex < dataGridView.Columns.Count - 1 && e.ColumnIndex > 0)
                    {
                        e.PaintBackground(e.CellBounds, true);
                        e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                        e.Graphics.RotateTransform(270);
                        e.Graphics.DrawString(e.FormattedValue?.ToString(), e.CellStyle.Font, Brushes.Black, 5, 5);
                        e.Graphics.ResetTransform();
                        e.Handled = true;
                        dataGridView.ColumnHeadersHeight = 80;
                        //dataGridView1.RowHeadersWidth = 20;
                        if (e.ColumnIndex > 0)
                        {
                            DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.Width = 22;
                        }

                    }
                    else if (e.RowIndex == -1 && e.ColumnIndex < dataGridView.Columns.Count - 1 && e.ColumnIndex == 0)
                    {
                        DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }

                    else if (e.RowIndex == -1 && e.ColumnIndex > dataGridView.Columns.Count - 2 && e.ColumnIndex > 0)
                    {
                        e.PaintBackground(e.CellBounds, true);
                        e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                        e.Graphics.RotateTransform(270);
                        e.Graphics.DrawString(e.FormattedValue?.ToString(), e.CellStyle.Font, Brushes.Black, 5, 10);
                        e.Graphics.ResetTransform();
                        e.Handled = true;
                        dataGridView.ColumnHeadersHeight = 80;

                        DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.Width = 40;
                    }

                }
                else if (paint == "Класс")
                {
                    if (e.RowIndex == -1 && e.ColumnIndex < dataGridView.Columns.Count && e.ColumnIndex > 2)
                    {
                        e.PaintBackground(e.CellBounds, true);
                        e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                        e.Graphics.RotateTransform(270);
                        e.Graphics.DrawString(e.FormattedValue?.ToString(), e.CellStyle.Font, Brushes.Black, 5, 7);
                        e.Graphics.ResetTransform();
                        e.Handled = true;
                        dataGridView.ColumnHeadersHeight = 100;

                        if (e.ColumnIndex > 2)
                        {
                            DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];
                            column.Width = 35;
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }

                    }
                    else if (e.RowIndex == -1 && e.ColumnIndex < dataGridView.Columns.Count && e.ColumnIndex <= 2)
                    {
                        DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                        DataGridViewCellStyle style = dataGridView.ColumnHeadersDefaultCellStyle;
                        style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                }
                else
                {
                    if (e.RowIndex == -1 && e.ColumnIndex < dataGridView.Columns.Count && e.ColumnIndex > 0)
                    {
                        e.PaintBackground(e.CellBounds, true);
                        e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                        e.Graphics.RotateTransform(270);
                        e.Graphics.DrawString(e.FormattedValue?.ToString(), e.CellStyle.Font, Brushes.Black, 5, 7);
                        e.Graphics.ResetTransform();
                        e.Handled = true;
                        dataGridView.ColumnHeadersHeight = 100;

                        if (e.ColumnIndex > 0)
                        {
                            DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.Width = 35;
                        }
                    }
                    else if (e.RowIndex == -1 && e.ColumnIndex < dataGridView.Columns.Count && e.ColumnIndex == 0)
                    {
                        DataGridViewCellStyle style = dataGridView.ColumnHeadersDefaultCellStyle;
                        style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
       //     }
        }

        private void сформироватьОтчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.DataSource == null)
            {
                MessageBox.Show("Получите данные для отчёта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           // butGet();

            if(!isNotChange)
            {
                MessageBox.Show("Получите актуальные данные для отчёта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                if (cbVariant.Text == "Ученик")
                {
                    report.createReportPupil(dt, cbFamil.SelectedItem.ToString(), dTPickerFrom.Value, dTPickerBy.Value);
                    MessageBox.Show("Отчёт сформирован и помещен в \"Документы\"", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cbVariant.Text == "Класс")
                {
                    report.createReportClass(dt, CBClass.Text + CBLetter.Text, dTPickerFrom.Value, dTPickerBy.Value);
                    MessageBox.Show("Отчёт сформирован и помещен в \"Документы\"", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cbVariant.Text == "Школа")
                {
                    report.createReportSchool(dt, dTPickerFrom.Value, dTPickerBy.Value);
                    MessageBox.Show("Отчёт сформирован и помещен в \"Документы\"", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void отчётыДляВсегоКлассаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView.DataSource == null)
            {
                MessageBox.Show("Получите данные для отчёта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                List<string> list = tc.getFamilPupils(CBClass.Text, CBLetter.Text);
                for (int i = 0; i < list.Count; i++)
                {
                    dt = tc.getPerformancePupil(i, dTPickerFrom.Value, dTPickerBy.Value);
                    report.createReportPupil(dt, list[i], dTPickerFrom.Value, dTPickerBy.Value);
                }

                dt = tc.getPerformanceClass(CBClass.Text, CBLetter.Text,
                       dTPickerFrom.Value.ToString("yyyy-MM-dd"), dTPickerBy.Value.ToString("yyyy-MM-dd"));

                MessageBox.Show("Отчёты сформированы и помещены в \"Документы\"", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            isNotChange = false;
        }

    }
}
