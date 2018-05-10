using Npgsql;
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
    public partial class FormTeacher : Form
    {
        DataTable dt = new DataTable();
        TeacherController tc = new TeacherController();
       
        //string login = "";

        
        public FormTeacher()
        {
            InitializeComponent();
            //login = _login;
            Text += " - "+ Program.login;
            //mBD.init();
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            //запрос к бд и заполнение ComboBox

            List<string> list = tc.getDiscipline(Program.login);
            for(int i=0;i<list.Count;i++)
            {
                CBClass.Items.Add(list[i]);
            }
            

            CBClass.SelectedIndex = 0;

        }

        private void успеваемостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPerformance fp = new FormPerformance();
            fp.ShowDialog();
        }

        private void посещаемостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAttendance fa = new FormAttendance();
            fa.ShowDialog();
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



        private void ButGet_Click(object sender, EventArgs e)
        {

            dt = tc.getList(CBClass.Text, CBLetter.Text);



            dataGridView1.DataSource = dt;
            TBMark.Text = dt.Rows[dataGridView1.CurrentRow.Index][3].ToString();
        }

        private void CBLetter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TBMark.Text = dt.Rows[dataGridView1.CurrentRow.Index][3].ToString();

        }

        private void ButPost_Click(object sender, EventArgs e)
        {
            Program.date = dateTimePicker1.Value;
            if (TBMark.Text.Contains('(') || TBMark.Text.Contains(')') || TBMark.Text.Contains(';') || TBMark.Text.Length > 1)
            {
                return;
            }
            try
            {
                tc.postMark(TBMark.Text, dataGridView1.CurrentRow.Index);
                MessageBox.Show("Оценка выставлена", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

            dt = tc.getList(CBClass.Text,CBLetter.Text);

            dataGridView1.DataSource = dt;
            TBMark.Text = dt.Rows[dataGridView1.CurrentRow.Index][3].ToString();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Program.date = dateTimePicker1.Value;
            dt = tc.getList(CBClass.Text, CBLetter.Text);

            dataGridView1.DataSource = dt;
            TBMark.Text = dt.Rows[dataGridView1.CurrentRow.Index][3].ToString();
        }
    }
}
