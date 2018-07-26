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
        AdminController ac;
        bool isNotChange = false;

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
                label1.Visible = false;
                label2.Visible = false;
                CBClass.Visible = false;
                CBLetter.Visible = false;
                groupBox1.Visible = false;
            }
            else if (comboBoxVariants.Text == "Предметы")
            {
                label1.Visible = false;
                label2.Visible = false;
                CBClass.Visible = false;
                CBLetter.Visible = false;
                groupBox1.Visible = false;
            }
            else if (comboBoxVariants.Text == "Классы")
            {
                label1.Visible = false;
                label2.Visible = false;
                CBClass.Visible = false;
                CBLetter.Visible = false;
                groupBox1.Visible = false;
            }
            else if (comboBoxVariants.Text == "Класс")
            {
                label1.Visible = true;
                label2.Visible = true;
                CBClass.Visible = true;
                CBLetter.Visible = true;
                groupBox1.Visible = true;

                updateCBClass();

            }
            isNotChange = false;
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
            isNotChange = false;

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
        }

        private void ButGet_Click(object sender, EventArgs e)
        {
              getList();
            isNotChange = true;

        }

        private void getList()
        {
            dt = null;
            dataGridView1.DataSource = null;


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
                dataGridView1.DataSource = dt;
                noSort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (comboBoxVariants.Text == "Учителя")
            {
                FormAdd fa = new FormAdd(comboBoxVariants.Text);
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
            else if (comboBoxVariants.Text == "Предметы")
            {

                FormAdd fa = new FormAdd(comboBoxVariants.Text, ac.getListTeachers());
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
            else if (comboBoxVariants.Text == "Классы")
            {

                FormAdd fa = new FormAdd(comboBoxVariants.Text, ac.getListTeachers());
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
            else if (comboBoxVariants.Text == "Класс")
            {
                
                FormAdd fa = new FormAdd(comboBoxVariants.Text);
                fa.buttonOK.Click += (senderSlave, eSlave) =>
                {
                    //валидация

                    if(!validate(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text))
                    {
                        MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }

            if (!isNotChange)
            {
                MessageBox.Show("Получите актуальные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись? \r\nБудут удалены все связные записи, \r\nв том числе оценки!"
                , "Удалить", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    ac.delete(dataGridView1.CurrentRow.Index, comboBoxVariants.Text);
                    MessageBox.Show("Удалено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                getList();
            }


        }

        private void button2_Click(object sender, EventArgs e)
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


            if (comboBoxVariants.Text == "Учителя")
            {
                FormAdd fa = new FormAdd(comboBoxVariants.Text, dt.Rows[dataGridView1.CurrentRow.Index][0].ToString(),
                    dt.Rows[dataGridView1.CurrentRow.Index][1].ToString(), dt.Rows[dataGridView1.CurrentRow.Index][2].ToString(), dt.Rows[dataGridView1.CurrentRow.Index][3].ToString());
                fa.buttonOK.Click += (senderSlave, eSlave) =>
                {

                    if (!validate(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text, fa.textBox4.Text))
                    {
                        MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try { 
                    ac.updateTeacher(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text, fa.textBox4.Text, dataGridView1.CurrentRow.Index);
                    MessageBox.Show("Обновлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                int idDisc = ac.getIdDisc(dataGridView1.CurrentRow.Index);

                FormAdd fa = new FormAdd(comboBoxVariants.Text, ac.getListTeachers(),
                    dt.Rows[dataGridView1.CurrentRow.Index][0].ToString(), dt.Rows[dataGridView1.CurrentRow.Index][1].ToString()) ;


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
            else if (comboBoxVariants.Text == "Класс")
            {
                FormAdd fa = new FormAdd(comboBoxVariants.Text, dt.Rows[dataGridView1.CurrentRow.Index][0].ToString(),
    dt.Rows[dataGridView1.CurrentRow.Index][1].ToString(), dt.Rows[dataGridView1.CurrentRow.Index][2].ToString());
                fa.buttonOK.Click += (senderSlave, eSlave) =>
                {
                    if (!validate(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text))
                    {
                        MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    try { 
                    ac.updatePupil(fa.textBox1.Text, fa.textBox2.Text, fa.textBox3.Text, dataGridView1.CurrentRow.Index);
                }
                    catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Обновлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                fa.ShowDialog();

            }
            getList();


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
            isNotChange = false;
        }

        private void задатьПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdd fa = new FormAdd("Пароль");
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
                    FileManager fm = new FileManager();
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
