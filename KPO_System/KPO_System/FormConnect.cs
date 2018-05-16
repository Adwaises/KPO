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
            } else
            {
                MessageBox.Show("Не удалось подключиться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void FormConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
