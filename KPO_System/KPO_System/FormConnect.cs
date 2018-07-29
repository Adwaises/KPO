using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPO_System
{
    public partial class FormConnect : Form
    {
        FileManager fm = new FileManager();
        public FormConnect(bool empty)
        {
            InitializeComponent();

            if(!empty)
            {
                    string[] param = fm.getParam();
                    textBox1.Text = param[0];
                    textBox2.Text = param[1];
                    textBox3.Text = param[2];
                    textBox4.Text = param[3];
                    textBox5.Text = param[4];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //проверить текстбоксы на sql инъекции
            if(!validate(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text))
            {
                MessageBox.Show("Валидация не пройдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try{
                ManagerBD mdb = new ManagerBD();
                mdb.init(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                if (mdb.isConnect())
                {
                    string text = textBox1.Text + "\r\n" +
                    textBox2.Text + "\r\n" +
                    textBox3.Text + "\r\n" +
                    textBox4.Text + "\r\n" +
                    textBox5.Text;

                    fm.setParam(text);
                    MessageBox.Show("Подключение стабильно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Не удалось подключиться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           
        }

        private bool validate(string s1, string s2, string s3, string s4,string s5)
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

            if (s5.Contains('(') || s5.Contains(')') || s5.Contains(';')
            || s5.Length > 20 || s5.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void FormConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void FormConnect_Load(object sender, EventArgs e)
        {

        }
    }
}
