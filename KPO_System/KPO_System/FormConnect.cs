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
                    tbServer.Text = param[0];
                    tbPort.Text = param[1];
                    tbUserId.Text = param[2];
                    tbPassword.Text = param[3];
                    tbDataBase.Text = param[4];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //проверить текстбоксы на sql инъекции
            if(!validate(tbServer.Text, tbPort.Text, tbUserId.Text, tbPassword.Text, tbDataBase.Text))
            {
                MessageBox.Show("Валидация не пройдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try{
                ManagerBD mdb = new ManagerBD();
                mdb.init(tbServer.Text, tbPort.Text, tbUserId.Text, tbPassword.Text, tbDataBase.Text);
                if (mdb.isConnect())
                {
                    string text = tbServer.Text + "\r\n" +
                    tbPort.Text + "\r\n" +
                    tbUserId.Text + "\r\n" +
                    tbPassword.Text + "\r\n" +
                    tbDataBase.Text;

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
