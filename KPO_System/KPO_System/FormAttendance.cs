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
    public partial class FormAttendance : Form
    {
        TeacherController tc;
        DataTable dt = new DataTable();
        Reports report = new Reports();
        bool isNotChange = false;
        string paint = "";

        public FormAttendance(TeacherController _tc)
        {
            tc = _tc;
            InitializeComponent();
            // dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        }

        private void FormAttendance_Load(object sender, EventArgs e)
        {

            cbVariants.Items.Add("Дисциплина");
            cbVariants.Items.Add("Класс");
            cbVariants.SelectedIndex = 0;


        }

        private void butGet()
        {
            try
            {
                dataGridView1.DataSource = null;
                if (cbVariants.Text == "Дисциплина")
                {

                    dt = tc.getAttendanceOnDisc(dateTimePickerFrom.Value, dateTimePickerBy.Value, cbDisc.SelectedItem.ToString());
                }
                else
                {
                    dt = tc.getAttendanceOnClass(dateTimePickerFrom.Value, dateTimePickerBy.Value,
                        CBClass.SelectedItem.ToString(), CBLetter.SelectedItem.ToString());
                }
                paint = cbVariants.Text;
                dataGridView1.DataSource = dt;

                noSort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            butGet();
            isNotChange = true;
        }

        private void noSort()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
         //   if (isNotChange)
          //  {


                if (paint == "Дисциплина")
                {
                    if (e.RowIndex == -1 && e.ColumnIndex < dataGridView1.Columns.Count && e.ColumnIndex > 0)
                    {
                        e.PaintBackground(e.CellBounds, true);
                        e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                        e.Graphics.RotateTransform(270);
                        e.Graphics.DrawString(e.FormattedValue?.ToString(), e.CellStyle.Font, Brushes.Black, 5, 5);
                        e.Graphics.ResetTransform();
                        e.Handled = true;
                        dataGridView1.ColumnHeadersHeight = 80;


                    }

                    if (e.ColumnIndex > 0)
                    {
                        DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                        //column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.Width = 20;
                    }
                }
                else
                {
                    if (e.RowIndex == -1 && e.ColumnIndex < dataGridView1.Columns.Count && e.ColumnIndex > 0)
                    {
                        e.PaintBackground(e.CellBounds, true);
                        e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                        e.Graphics.RotateTransform(270);
                        e.Graphics.DrawString(e.FormattedValue?.ToString(), e.CellStyle.Font, Brushes.Black, 5, 5);
                        e.Graphics.ResetTransform();
                        e.Handled = true;
                        dataGridView1.ColumnHeadersHeight = 80;
                    }

                    if (e.ColumnIndex > 0)
                    {
                        DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                        //column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.Width = 20;
                    }
                    else
                    {
                        DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                }
           // }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            isNotChange = false;
            if (cbVariants.Text == "Дисциплина")
            {
                try
                {
                    cbDisc.Items.Clear();
                    List<string> list = tc.getListDisc();
                    for (int i = 0; i < list.Count; i++)
                    {
                        cbDisc.Items.Add(list[i]);
                    }


                    cbDisc.SelectedIndex = 0;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось получить список\r\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                labelClass.Visible = false;
                labelLetter.Visible = false;
                CBClass.Visible = false;
                CBLetter.Visible = false;
                labelDisc.Visible = true;
                cbDisc.Visible = true;
            }
            else
            {

                try
                {
                    CBClass.Items.Clear();

                    List<string> list = tc.getListNumClass();
                    for (int i = 0; i < list.Count; i++)
                    {
                        CBClass.Items.Add(list[i]);
                    }
                    CBClass.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось получить список\r\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                labelClass.Visible = true;
                labelLetter.Visible = true;
                CBClass.Visible = true;
                CBLetter.Visible = true;
                labelDisc.Visible = false;
                cbDisc.Visible = false;
            }
        }

        private void CBClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            isNotChange = false;
            CBLetter.Items.Clear();
            try
            {
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

        private void сформироватьОтчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!isNotChange)
            {
                MessageBox.Show("Получите актуальные данные для отчёта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //butGet();

            try
            {

                if (cbVariants.Text == "Дисциплина")
                {
                    report.createJournal(dt, cbDisc.Text, dateTimePickerFrom.Value, dateTimePickerBy.Value, "Дисциплина");
                    MessageBox.Show("Отчёт сформирован и помещен в \"Документы\"", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    report.createJournal(dt, CBClass.Text + CBLetter.Text, dateTimePickerFrom.Value, dateTimePickerBy.Value, "Класс");
                    MessageBox.Show("Отчёт сформирован и помещен в \"Документы\"", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
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
