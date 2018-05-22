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
    public partial class FormAdmin : Form
    {

        DataTable dt = new DataTable();
        AdminController ac = new AdminController();
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void подключениеКБДToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            TeacherController tc = new TeacherController();

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
                label1.Visible = false;
                label2.Visible = false;
                CBClass.Visible = false;
                CBLetter.Visible = false;
            }
            else if (comboBoxVariants.Text == "Предметы")
            {
                label1.Visible = false;
                label2.Visible = false;
                CBClass.Visible = false;
                CBLetter.Visible = false;
            }
            else if (comboBoxVariants.Text == "Классы")
            {
                label1.Visible = false;
                label2.Visible = false;
                CBClass.Visible = false;
                CBLetter.Visible = false;
            }
            else if (comboBoxVariants.Text == "Класс")
            {
                label1.Visible = true;
                label2.Visible = true;
                CBClass.Visible = true;
                CBLetter.Visible = true;

                updateCBClass();

            }
        }


        private void updateCBClass()
        {
            CBClass.Items.Clear();
            List<string> list = ac.getNumbersClass();
            for (int i = 0; i < list.Count; i++)
            {
                CBClass.Items.Add(list[i]);
            }

            CBClass.SelectedIndex = 0;
        }

        private void CBClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBLetter.Items.Clear();

            List<string> list = new List<string>();

            list = ac.getListLetters(CBClass.Text);


            for (int i = 0; i < list.Count; i++)
            {
                CBLetter.Items.Add(list[i]);
            }
            CBLetter.SelectedIndex = 0;
        }

        private void ButGet_Click(object sender, EventArgs e)
        {

            getList();

        }

        private void getList()
        {
            dt = null;
            dataGridView1.DataSource = null;

            if (comboBoxVariants.Text == "Учителя")
            {
                dt = ac.getListTeachers();
                dataGridView1.DataSource = dt;
                noSort();
            }
            else if (comboBoxVariants.Text == "Предметы")
            {
                dt = ac.getListDiscipline();
                dataGridView1.DataSource = dt;
                noSort();
            }
            else if (comboBoxVariants.Text == "Классы")
            {
                dt = ac.getListClasses();
                dataGridView1.DataSource = dt;
                noSort();
            }
            else if (comboBoxVariants.Text == "Класс")
            {
                dt = ac.getList(CBClass.Text, CBLetter.Text);

                dataGridView1.DataSource = dt;
                //TBMark.Text = dt.Rows[dataGridView1.CurrentRow.Index][3].ToString();
                noSort();

            }
        }

        private void noSort()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getList();

            //FormAdd fa = new FormAdd(comboBoxVariants.Text);
            //fa.buttonOK.Click += (senderSlave, eSlave) =>
            //{
            //};
            //fa.ShowDialog();


            //this.label1.Text = fa.textBox1.Text;

            if (comboBoxVariants.Text == "Учителя")
            {
                FormAdd fa = new FormAdd(comboBoxVariants.Text);
                fa.buttonOK.Click += (senderSlave, eSlave) =>
                {

                    //валидация

                    if (fa.textBox1.Text.Contains('(') || fa.textBox1.Text.Contains(')') || fa.textBox1.Text.Contains(';') || fa.textBox1.Text.Length > 20)
                    {
                        return;
                    }

                    if (fa.textBox2.Text.Contains('(') || fa.textBox2.Text.Contains(')') || fa.textBox2.Text.Contains(';') || fa.textBox2.Text.Length > 20)
                    {
                        return;
                    }

                    if (fa.textBox3.Text.Contains('(') || fa.textBox3.Text.Contains(')') || fa.textBox3.Text.Contains(';') || fa.textBox3.Text.Length > 20)
                    {
                        return;
                    }

                    //Console.WriteLine(fa.textBox1.Text);
                    //Console.WriteLine(fa.textBox2.Text);
                    //Console.WriteLine(fa.textBox3.Text);

                    //insert

                    //mBD.controlquery("INSERT INTO Teacher(famil, name, otchestvo) VALUES('Паршина', 'Людмила', 'Николаевна');");
                    try
                    {
                        ac.insertTeacher(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text);
                        MessageBox.Show("Добавлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                };
                fa.ShowDialog();
            }
            else if (comboBoxVariants.Text == "Предметы")
            {
                //mBD.controlquery("INSERT INTO Discipline(name, id_teacher) VALUES('Русский язык', 1);");

                FormAdd fa = new FormAdd(comboBoxVariants.Text, ac.getListTeachers());
                fa.buttonOK.Click += (senderSlave, eSlave) =>
                {
                    //валидация

                    if (fa.textBox1.Text.Contains('(') || fa.textBox1.Text.Contains(')') || fa.textBox1.Text.Contains(';') || fa.textBox1.Text.Length > 20)
                    {
                        return;
                    }


                    try
                    {
                        //ac.insertTeacher(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text);
                        ac.insertDiscipline(fa.textBox1.Text, fa.comboBox1.SelectedIndex);
                        MessageBox.Show("Добавлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                };
                fa.ShowDialog();


            }
            else if (comboBoxVariants.Text == "Классы")
            {
                //mBD.controlquery("INSERT INTO Class(number, letter, id_teacher) VALUES(5, 'А', 1);");

                FormAdd fa = new FormAdd(comboBoxVariants.Text, ac.getListTeachers());
                fa.buttonOK.Click += (senderSlave, eSlave) =>
                {
                    //валидация

                    if (fa.textBox1.Text.Contains('(') || fa.textBox1.Text.Contains(')') || fa.textBox1.Text.Contains(';') || fa.textBox1.Text.Length > 20)
                    {
                        return;
                    }

                    if (fa.textBox2.Text.Contains('(') || fa.textBox2.Text.Contains(')') || fa.textBox2.Text.Contains(';') || fa.textBox2.Text.Length > 20)
                    {
                        return;
                    }

                    try
                    {
                        //ac.insertTeacher(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text);
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
            else if (comboBoxVariants.Text == "Класс")
            {
                //mBD.controlquery("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES(1, 'Андреев', 'Вячеслав', 'Сергеевич');");

                FormAdd fa = new FormAdd(comboBoxVariants.Text);
                fa.buttonOK.Click += (senderSlave, eSlave) =>
                {
                    //валидация

                    if (fa.textBox1.Text.Contains('(') || fa.textBox1.Text.Contains(')') || fa.textBox1.Text.Contains(';') || fa.textBox1.Text.Length > 20)
                    {
                        return;
                    }

                    if (fa.textBox2.Text.Contains('(') || fa.textBox2.Text.Contains(')') || fa.textBox2.Text.Contains(';') || fa.textBox2.Text.Length > 20)
                    {
                        return;
                    }

                    if (fa.textBox3.Text.Contains('(') || fa.textBox3.Text.Contains(')') || fa.textBox3.Text.Contains(';') || fa.textBox3.Text.Length > 20)
                    {
                        return;
                    }

                    try
                    {
                        ac.insertPupil(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text, CBClass.Text,CBLetter.Text);
                        MessageBox.Show("Добавлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                };
                fa.ShowDialog();

            }
            getList();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.DataSource == null)
            {
                MessageBox.Show("Список не получен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                //getList();
            }
            


            //dataGridView1.CurrentRow.Index

            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись? \r\nБудут удалены все связные записи, \r\nв том числе оценки!"
                , "Удалить", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                //do something
                ac.delete(dataGridView1.CurrentRow.Index, comboBoxVariants.Text);
                MessageBox.Show("Удалено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getList();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Список не получен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                //getList();
            }


            if (comboBoxVariants.Text == "Учителя")
            {
                FormAdd fa = new FormAdd(comboBoxVariants.Text, dt.Rows[dataGridView1.CurrentRow.Index][0].ToString(),
                    dt.Rows[dataGridView1.CurrentRow.Index][1].ToString(), dt.Rows[dataGridView1.CurrentRow.Index][2].ToString());
                fa.buttonOK.Click += (senderSlave, eSlave) =>
                {
                    ac.updateTeacher(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text,dataGridView1.CurrentRow.Index);
                    MessageBox.Show("Обновлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                fa.ShowDialog();
            }
            else if (comboBoxVariants.Text == "Предметы")
            {

                //FormAdd fa = new FormAdd(comboBoxVariants.Text, ac.getListTeachers());
                //fa.buttonOK.Click += (senderSlave, eSlave) =>
                //{
                //    //валидация

                //    if (fa.textBox1.Text.Contains('(') || fa.textBox1.Text.Contains(')') || fa.textBox1.Text.Contains(';') || fa.textBox1.Text.Length > 20)
                //    {
                //        return;
                //    }


                //    try
                //    {
                //        //ac.insertTeacher(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text);
                //        ac.insertDiscipline(fa.textBox1.Text, fa.comboBox1.SelectedIndex);
                //        MessageBox.Show("Добавлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }

                //};
                //fa.ShowDialog();

                int idDisc = ac.getIdDisc(dataGridView1.CurrentRow.Index);

                FormAdd fa = new FormAdd(comboBoxVariants.Text, ac.getListTeachers(),
                    dt.Rows[dataGridView1.CurrentRow.Index][0].ToString(), dt.Rows[dataGridView1.CurrentRow.Index][1].ToString()) ;


                fa.buttonOK.Click += (senderSlave, eSlave) =>
                {
                    //валидация

                    try
                    {
                        //ac.insertDiscipline(fa.textBox1.Text, fa.comboBox1.SelectedIndex);
                        ac.updateDiscipline(fa.textBox1.Text, fa.comboBox1.SelectedIndex,idDisc);
                        MessageBox.Show("Обновлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                };
                fa.ShowDialog();

            }
            else if (comboBoxVariants.Text == "Классы")
            {

                int idClass = ac.getIdClass(dataGridView1.CurrentRow.Index);

                FormAdd fa = new FormAdd(comboBoxVariants.Text, ac.getListTeachers(),
                    dt.Rows[dataGridView1.CurrentRow.Index][0].ToString(), dt.Rows[dataGridView1.CurrentRow.Index][1].ToString(), 
                    dt.Rows[dataGridView1.CurrentRow.Index][2].ToString());


                fa.buttonOK.Click += (senderSlave, eSlave) =>
                {
                    //валидация

                    try
                    {
                        //ac.updateDiscipline(fa.textBox1.Text, fa.comboBox1.SelectedIndex, idClass);
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
            else if (comboBoxVariants.Text == "Класс")
            {
                FormAdd fa = new FormAdd(comboBoxVariants.Text, dt.Rows[dataGridView1.CurrentRow.Index][0].ToString(),
    dt.Rows[dataGridView1.CurrentRow.Index][1].ToString(), dt.Rows[dataGridView1.CurrentRow.Index][2].ToString());
                fa.buttonOK.Click += (senderSlave, eSlave) =>
                {
                    ac.updatePupil(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text, dataGridView1.CurrentRow.Index);

                    MessageBox.Show("Обновлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                fa.ShowDialog();

            }
            getList();

            //FormAdd fa = new FormAdd(comboBoxVariants.Text);
            //fa.buttonOK.Click += (senderSlave, eSlave) =>
            //{
            //};
            //fa.ShowDialog();

        }
    }
}
