﻿using System;
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
    public partial class FormAdmin : Form
    {
        DataTable dt = new DataTable();
        AdminController ac;
        //bool isNotChange = false;

        int indexRow = 0;
        public FormAdmin(ManagerBD mbd)
        {
            ac = new AdminController(mbd);
            InitializeComponent();
        }

        private void подключениеКБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ac.connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormAdmin_Load(object sender, EventArgs e)
        {
            comboBoxVariants.Items.Add("Учителя");
            comboBoxVariants.Items.Add("Предметы");
            comboBoxVariants.Items.Add("Классы");
            comboBoxVariants.Items.Add("Класс");
            comboBoxVariants.SelectedIndex = 0;
        }

        private void comboBoxVariants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVariants.Text == "Учителя")
            {
                labelClass.Visible = false;
                labelLetter.Visible = false;
                CBClass.Visible = false;
                CBLetter.Visible = false;
                groupBox.Visible = false;
            }
            else if (comboBoxVariants.Text == "Предметы")
            {
                labelClass.Visible = false;
                labelLetter.Visible = false;
                CBClass.Visible = false;
                CBLetter.Visible = false;
                groupBox.Visible = false;
            }
            else if (comboBoxVariants.Text == "Классы")
            {
                labelClass.Visible = false;
                labelLetter.Visible = false;
                CBClass.Visible = false;
                CBLetter.Visible = false;
                groupBox.Visible = false;
            }
            else if (comboBoxVariants.Text == "Класс")
            {
                labelClass.Visible = true;
                labelLetter.Visible = true;
                CBClass.Visible = true;
                CBLetter.Visible = true;
                groupBox.Visible = true;

                updateCBClass();

            }
            //isNotChange = false;
            getLists();
        }


        private void updateCBClass()
        {
            CBClass.Items.Clear();

            try
            {
                List<string> list = ac.getNumbersClass();
                for (int i = 0; i < list.Count; i++)
                {
                    CBClass.Items.Add(list[i]);
                }

                CBClass.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CBClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //isNotChange = false;

            CBLetter.Items.Clear();

            try { 
            List<string> list = new List<string>();

            list = ac.getListLetters(CBClass.Text);


            for (int i = 0; i < list.Count; i++)
            {
                CBLetter.Items.Add(list[i]);
            }
            CBLetter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            getLists();
        }

        private void ButGet_Click(object sender, EventArgs e)
        {

        }

        private void getLists()
        {
            indexRow = 0;
            getList();
            //isNotChange = true;
        }

        private void getList()
        {
            dt = null;
            dataGridView.DataSource = null;


            try
            {
                if (comboBoxVariants.Text == "Учителя")
                {
                    dt = ac.getListTeachers();  
                }
                else if (comboBoxVariants.Text == "Предметы")
                {
                    dt = ac.getListDiscipline();
                }
                else if (comboBoxVariants.Text == "Классы")
                {
                    dt = ac.getListClasses();
                }
                else if (comboBoxVariants.Text == "Класс")
                {
                    dt = ac.getList(CBClass.Text, CBLetter.Text);
                }
                dataGridView.DataSource = dt;

                if(dt.Rows.Count >0)
                {
                    dataGridView.Rows[indexRow].Selected = true;
                    dataGridView.CurrentCell = dataGridView[0, indexRow];
                }


                noSort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void noSort()
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView.DataSource == null)
            {
                MessageBox.Show("Список не получен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //if (!isNotChange)
            //{
            //    MessageBox.Show("Получите актуальные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (comboBoxVariants.Text == "Учителя")
            {
                insTeachers();
            }
            else if (comboBoxVariants.Text == "Предметы")
            {
                insDisc();
            }
            else if (comboBoxVariants.Text == "Классы")
            {

                insClass();

            }
            else if (comboBoxVariants.Text == "Класс")
            {

                insPupil();

            }
            getList();
        }

        private void insTeachers()
        {
            FormAdd fa = new FormAdd(comboBoxVariants.Text);
            fa.Text = "Добавить";
            fa.buttonOK.Click += (senderSlave, eSlave) =>
            {

                //валидация
                if (!validate(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text, fa.textBox4.Text))
                {
                    MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //insert
                try
                {
                    ac.insertTeacher(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text, fa.textBox4.Text);
                    MessageBox.Show("Добавлено\r\nНе забудьте довабить дисциплину", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            };
            fa.ShowDialog();
        }

        private void insDisc()
        {
            FormAdd fa = new FormAdd(comboBoxVariants.Text, ac.getListTeachers());
            fa.Text = "Добавить";
            fa.buttonOK.Click += (senderSlave, eSlave) =>
            {
                //валидация

                if (!validate(fa.textBox1.Text))
                {
                    MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    ac.insertDiscipline(fa.textBox1.Text, fa.comboBox1.SelectedIndex);
                    MessageBox.Show("Добавлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("У одного учителя может быть только одна дисциплина\r\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            };
            fa.ShowDialog();
        }

        private void insClass()
        {
            FormAdd fa = new FormAdd(comboBoxVariants.Text, ac.getListTeachers());
            fa.Text = "Добавить";
            fa.buttonOK.Click += (senderSlave, eSlave) =>
            {
                //валидация
                if (!validate(fa.textBox1.Text, fa.textBox2.Text))
                {
                    MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    ac.insertClass(fa.textBox1.Text, fa.textBox2.Text, fa.comboBox1.SelectedIndex);
                    MessageBox.Show("Добавлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            };
            fa.ShowDialog();
        }

        private void insPupil()
        {
            FormAdd fa = new FormAdd(comboBoxVariants.Text);
            fa.Text = "Добавить";
            fa.buttonOK.Click += (senderSlave, eSlave) =>
            {
                //валидация

                if (!validate(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text))
                {
                    MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    ac.insertPupil(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text, CBClass.Text, CBLetter.Text);
                    MessageBox.Show("Добавлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            };
            fa.ShowDialog();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if(dataGridView.DataSource == null)
            {
                MessageBox.Show("Список не получен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //if (!isNotChange)
            //{
            //    MessageBox.Show("Получите актуальные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись? \r\nБудут удалены все связные записи, \r\nв том числе оценки!"
                , "Удалить", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    ac.delete(dataGridView.CurrentRow.Index, comboBoxVariants.Text);
                    MessageBox.Show("Удалено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                getList();
            }


        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.DataSource == null)
            {
                MessageBox.Show("Список не получен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //if (!isNotChange)
            //{
            //    MessageBox.Show("Получите актуальные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            indexRow = dataGridView.CurrentRow.Index;

            if (comboBoxVariants.Text == "Учителя")
            {
                updTeacher();
            }
            else if (comboBoxVariants.Text == "Предметы")
            {

                updDisc();

            }
            else if (comboBoxVariants.Text == "Классы")
            {

                updClass();

            }
            else if (comboBoxVariants.Text == "Класс")
            {
                updPupil();

            }
            getList();


        }

        private void updTeacher()
        {
            FormAdd fa = new FormAdd(comboBoxVariants.Text, dt.Rows[dataGridView.CurrentRow.Index][0].ToString(),
    dt.Rows[dataGridView.CurrentRow.Index][1].ToString(), dt.Rows[dataGridView.CurrentRow.Index][2].ToString(), dt.Rows[dataGridView.CurrentRow.Index][3].ToString());
            fa.Text = "Изменить";
            fa.buttonOK.Click += (senderSlave, eSlave) =>
            {

                if (!validate(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text, fa.textBox4.Text))
                {
                    MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    ac.updateTeacher(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text, fa.textBox4.Text, dataGridView.CurrentRow.Index);
                    MessageBox.Show("Обновлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            fa.ShowDialog();
        }

        private void updClass()
        {
            int idClass = ac.getIdClass(dataGridView.CurrentRow.Index);

            FormAdd fa = new FormAdd(comboBoxVariants.Text, ac.getListTeachers(),
                dt.Rows[dataGridView.CurrentRow.Index][0].ToString(), dt.Rows[dataGridView.CurrentRow.Index][1].ToString(),
                dt.Rows[dataGridView.CurrentRow.Index][2].ToString());
            fa.Text = "Изменить";

            fa.buttonOK.Click += (senderSlave, eSlave) =>
            {
                //валидация
                if (!validate(fa.textBox1.Text, fa.textBox2.Text))
                {
                    MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                try
                {
                    ac.updateClass(fa.textBox1.Text, fa.textBox2.Text, fa.comboBox1.SelectedIndex, idClass);
                    MessageBox.Show("Обновлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            };
            fa.ShowDialog();

        }
        private void updPupil()
        {
            FormAdd fa = new FormAdd(comboBoxVariants.Text, dt.Rows[dataGridView.CurrentRow.Index][0].ToString(),
dt.Rows[dataGridView.CurrentRow.Index][1].ToString(), dt.Rows[dataGridView.CurrentRow.Index][2].ToString());
            fa.Text = "Изменить";
            fa.buttonOK.Click += (senderSlave, eSlave) =>
            {
                if (!validate(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text))
                {
                    MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    ac.updatePupil(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text, dataGridView.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Обновлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            fa.ShowDialog();
        }

        private void updDisc()
        {
            int idDisc = ac.getIdDisc(dataGridView.CurrentRow.Index);

            FormAdd fa = new FormAdd(comboBoxVariants.Text, ac.getListTeachers(),
                dt.Rows[dataGridView.CurrentRow.Index][0].ToString(), dt.Rows[dataGridView.CurrentRow.Index][1].ToString());
            fa.Text = "Изменить";

            fa.buttonOK.Click += (senderSlave, eSlave) =>
            {
                //валидация

                if (!validate(fa.textBox1.Text))
                {
                    MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    ac.updateDiscipline(fa.textBox1.Text, fa.comboBox1.SelectedIndex, idDisc);
                    MessageBox.Show("Обновлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            };
            fa.ShowDialog();
        }

        private bool validate(string s1, string s2, string s3, string s4)
        {
            if (s1.Contains('(') || s1.Contains(')') || s1.Contains(';')
|| s1.Length > 20 || s1.Length == 0)
            {
                return false;
            }

            if (s2.Contains('(') || s2.Contains(')') || s2.Contains(';')
            || s2.Length > 20 || s2.Length == 0)
            {
                return false;
            }

            if (s3.Contains('(') || s3.Contains(')') || s3.Contains(';')
            || s3.Length > 20 || s3.Length == 0)
            {
                return false;
            }

            if (s4.Contains('(') || s4.Contains(')') || s4.Contains(';')
|| s4.Length > 20 || s4.Length == 0)
            {
                return false;
            }
            return true;
        }
        private bool validate(string s1,string s2, string s3)
        {
            if (s1.Contains('(') || s1.Contains(')') || s1.Contains(';')
|| s1.Length > 20 || s1.Length == 0)
            {
                return false;
            }

            if (s2.Contains('(') || s2.Contains(')') || s2.Contains(';')
            || s2.Length > 20 || s2.Length == 0)
            {
                return false;
            }

            if (s3.Contains('(') || s3.Contains(')') || s3.Contains(';')
            || s3.Length > 20 || s3.Length == 0)
            {
                return false;
            }
            return true;
        }

        private bool validate(string s1, string s2)
        {
            if (s1.Contains('(') || s1.Contains(')') || s1.Contains(';')
|| s1.Length > 20 || s1.Length == 0)
            {
                return false;
            }

            if (s2.Contains('(') || s2.Contains(')') || s2.Contains(';')
            || s2.Length > 20 || s2.Length == 0)
            {
                return false;
            }

            return true;
        }

        private bool validate(string s1)
        {
            if (s1.Contains('(') || s1.Contains(')') || s1.Contains(';')
|| s1.Length > 20 || s1.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void CBLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //isNotChange = false;
            getLists();
        }

        private void задатьПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager fm = new FileManager();
            FormAdd fa = new FormAdd("Пароль", fm.getPasswd());
            fa.Text = "Изменить пароль";
            fa.buttonOK.Click += (senderSlave, eSlave) =>
            {

                //валидация
                if (!validate(fa.textBox1.Text))
                {
                    MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    
                    fm.setPasswd(fa.textBox1.Text);
                    MessageBox.Show("Пароль изменён", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            fa.ShowDialog();
        }
    }
}
