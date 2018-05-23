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
        TeacherController tc = new TeacherController();
        DataTable dt = new DataTable();
        public FormAttendance()
        {
            InitializeComponent();
           // dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        }

        private void FormAttendance_Load(object sender, EventArgs e)
        {

            comboBox2.Items.Add("Дисциплина");
            comboBox2.Items.Add("Класс");
            comboBox2.SelectedIndex = 0;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            if(comboBox2.Text == "Дисциплина")
            {
                
                dt = tc.getAttendanceOnDisc(dateTimePicker1.Value, dateTimePicker2.Value, comboBox1.SelectedItem.ToString());
            } else
            {
                dt = tc.getAttendanceOnClass(dateTimePicker1.Value, dateTimePicker2.Value, 
                    CBClass.SelectedItem.ToString(), CBLetter.SelectedItem.ToString());
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

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
            }

            if (e.ColumnIndex > 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.Width = 20;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text == "Дисциплина")
            {
                comboBox1.Items.Clear();
                List<string> list = tc.getListDisc();
                for (int i = 0; i < list.Count; i++)
                {
                    comboBox1.Items.Add(list[i]);
                }


                comboBox1.SelectedIndex = 0;

                label1.Visible = false;
                label2.Visible = false;
                CBClass.Visible = false;
                CBLetter.Visible = false;
                label5.Visible = true;
                comboBox1.Visible = true;
            } else
            {


                CBClass.Items.Clear();

                List<string> list = tc.getListNumClass();
                for (int i = 0; i < list.Count; i++)
                {
                    CBClass.Items.Add(list[i]);
                }
                CBClass.SelectedIndex = 0;


                label1.Visible = true;
                label2.Visible = true;
                CBClass.Visible = true;
                CBLetter.Visible = true;
                label5.Visible = false;
                comboBox1.Visible = false;

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

        Reports report = new Reports();
        private void сформироватьОтчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //report.createReportPupil(dt, cbFamil.SelectedItem.ToString(), dTPickerFrom.Value, dTPickerBy.Value);
            //MessageBox.Show("Отчёт сформирован", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);


            if (comboBox2.Text == "Дисциплина")
            {
                report.createJournal(dt, comboBox1.Text, dateTimePicker1.Value, dateTimePicker2.Value, "Дисциплина");
                MessageBox.Show("Отчёт сформирован", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                report.createJournal(dt, CBClass.Text+CBLetter.Text, dateTimePicker1.Value, dateTimePicker2.Value, "Класс");
                MessageBox.Show("Отчёт сформирован", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
