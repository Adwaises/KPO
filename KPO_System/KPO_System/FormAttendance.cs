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
        public FormAttendance()
        {
            InitializeComponent();
        }

        private void FormAttendance_Load(object sender, EventArgs e)
        {
            List<string> list = tc.getListDisc();
            for (int i = 0; i < list.Count; i++)
            {
                comboBox1.Items.Add(list[i]);
            }


            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tc.getAttendance(dateTimePicker1.Value,dateTimePicker2.Value, comboBox1.SelectedItem.ToString());
            noSort();
        }

        private void noSort()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

    }
}
