﻿using Npgsql;
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
        FileManager fm = new FileManager();
        TeacherController tc;
        ManagerBD mdb;
        bool isNotChange = false;

        //string login = "";


        public FormTeacher(ManagerBD mbd)
        {
            mdb = mbd;
            tc = new TeacherController(mbd);
            InitializeComponent();
            //login = _login;
            Text += " - "+ Program.login;
            //mBD.init();
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            
            //запрос к бд и заполнение ComboBox

            List<string> list = tc.getListNumClass();
            for(int i=0;i<list.Count;i++)
            {
                CBClass.Items.Add(list[i]);
            }
            

            CBClass.SelectedIndex = 0;
        }

        private void успеваемостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPerformance fp = new FormPerformance(tc);
            fp.ShowDialog();
        }

        private void посещаемостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAttendance fa = new FormAttendance(tc);
            fa.ShowDialog();
        }

        private void CBClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            isNotChange = false;
            CBLetter.Items.Clear();

            List<string> list = new List<string>();

            try
            {
                list = tc.getListLetters(CBClass.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            for (int i = 0; i < list.Count; i++)
            {
                CBLetter.Items.Add(list[i]);
            }
            CBLetter.SelectedIndex = 0;
        }

        private void ButGet_Click(object sender, EventArgs e)
        {
            try
            {
                dt = tc.getList(CBClass.Text, CBLetter.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataGridView1.DataSource = dt;
            TBMark.Text = dt.Rows[dataGridView1.CurrentRow.Index][3].ToString();
            noSort();
            isNotChange = true;
        }


        private void CBLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            isNotChange = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TBMark.Text = dt.Rows[dataGridView1.CurrentRow.Index][3].ToString();

        }

        private void ButPost_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Список не получен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!isNotChange)
            {
                MessageBox.Show("Получите актуальные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.date = dateTimePicker1.Value;
            if (TBMark.Text.Contains('(') || TBMark.Text.Contains(')') || TBMark.Text.Contains(';') || TBMark.Text.Length > 1)
            {
                MessageBox.Show("SQL", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(dt.Rows[dataGridView1.CurrentRow.Index][3].ToString() == "" && TBMark.Text == "")
            {
                MessageBox.Show("Введите оценку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            try
            {
                dt = tc.getList(CBClass.Text, CBLetter.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не получен список\r\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            dataGridView1.DataSource = dt;
            TBMark.Text = dt.Rows[dataGridView1.CurrentRow.Index][3].ToString();

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Program.date = dateTimePicker1.Value;

            isNotChange = false;
            //try
            //{
            //    dt = tc.getList(CBClass.Text, CBLetter.Text);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}



            //dataGridView1.DataSource = dt;
            //TBMark.Text = dt.Rows[dataGridView1.CurrentRow.Index][3].ToString();
            //noSort();
        }


        private void noSort()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void подключениеКБДToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //tc.connect();

            try
            {
                tc.connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




    }
}
