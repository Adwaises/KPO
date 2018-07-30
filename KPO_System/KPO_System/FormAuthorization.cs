using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace KPO_System
{
    public partial class FormAuthorization : Form
    {
        string login = "";
        string sql = "select password from teacher where famil = ";

        bool authorization = false;
        public ManagerBD mBD = new ManagerBD();
        FileManager fm = new FileManager();
        public FormAuthorization()
        {
            InitializeComponent();

            if(fm.exists("last.txt"))
            {
                TBlogin.Text = fm.getLast();
            }

           // TBlogin.Text = "Паршина";
           // TBPassword.Text = "Паршина1";
        }

        private void ButLogIn_Click(object sender, EventArgs e)
        {
            //валидация
            // если есть () или ; или пустые

            login = TBlogin.Text;

            if (TBlogin.Text.Contains('(') || TBlogin.Text.Contains(')') || TBlogin.Text.Contains(';') || TBlogin.Text.Length > 20)
            {
                MessageBox.Show("Возврат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBPassword.Text.Contains('(') || TBPassword.Text.Contains(')') || TBPassword.Text.Contains(';') || TBPassword.Text.Length > 20)
            {
                MessageBox.Show("Возврат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if(!fm.exists("ConnectParam.txt"))
                {
                    MessageBox.Show("Файл параметров не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fm.createFile("ConnectParam.txt");
                    FormConnect fc = new FormConnect(true);
                    fc.ShowDialog();
                    return;
                }
                else if(fm.getLengthFile() == 0 || fm.getLinesFile("ConnectParam.txt") != 5)
                {
                    MessageBox.Show("Файл параметров повреждён", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fm.createFile("ConnectParam.txt");
                    FormConnect fc = new FormConnect(true);
                    fc.ShowDialog();
                    return;
                }
                string[] param = fm.getParam();

                mBD.init(param[0], param[1], param[2], param[3], param[4]);

                if (!mBD.isConnect() || param[4] == "")
                {
                    MessageBox.Show("Не удалось подключиться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FormConnect fc = new FormConnect(false);
                    fc.ShowDialog();
                    return;
                    //Close();
                }

                //param = fm.getParam();
                //mBD.init(param[0], param[1], param[2], param[3], param[4]);


                //запрос к БД

                string sqlOne = sql + String.Format("'{0}';", TBlogin.Text);

                DataTable dt = new DataTable();

                dt = mBD.selectionQuery(sqlOne);

                if (dt.Rows.Count != 0)
                {
                    login = TBlogin.Text;
                    if (dt.Rows[0][0].ToString() == TBPassword.Text)
                    {
                        authorization = true;
                    }
                }


                string pAdm = "";
                if (login == "admin") {
                   
                    if (!fm.exists("confp"))
                    {
                        MessageBox.Show("Пароль не найден\r\nПароль сброшен до стандартного", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fm.createFile("confp");
                        fm.setPasswd("admschp");
                        //setP();
                        return;
                    } else if (fm.getLinesFile("confp") != 1)
                    {

                        MessageBox.Show("Пароль повреждён\r\nПароль сброшен до стандартного", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fm.createFile("confp");
                        fm.setPasswd("admschp");
                        //setP();
                        return;
                    } else {
                        pAdm = fm.getPasswd();
                    }
                }

                fm.createFile("last.txt");
                fm.setLast(TBlogin.Text);

                //открытие формы
                if (login == "admin" && TBPassword.Text == pAdm)
                {
                    FormAdmin fa = new FormAdmin(mBD);
                    fa.ShowDialog();
                }
                else if (login == "")
                {
                    MessageBox.Show("Не найден логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (authorization)
                {
                    authorization = false;
                    Program.login = login;
                    FormTeacher ft = new FormTeacher(mBD);
                    ft.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка\r\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //private void setP()
        //{
        //    FormAdd fa = new FormAdd("Пароль", fm.getPasswd());
        //    fa.buttonOK.Click += (senderSlave, eSlave) =>
        //    {

        //        //валидация
        //        if (!validate(fa.textBox1.Text))
        //        {
        //            MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        try
        //        {

        //            fm.setPasswd(fa.textBox1.Text);
        //            MessageBox.Show("Пароль изменён", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    };
        //    fa.ShowDialog();
        //}

        private bool validate(string s1)
        {
            if (s1.Contains('(') || s1.Contains(')') || s1.Contains(';')
|| s1.Length > 20 || s1.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void FormAuthorization_Load(object sender, EventArgs e)
        {

        }

        private void buttonParam_Click(object sender, EventArgs e)
        {
            if (!fm.exists("ConnectParam.txt"))
            {
                fm.createFile("ConnectParam.txt");
                FormConnect fc = new FormConnect(true);
                fc.ShowDialog();
            }
            else if (fm.getLengthFile() == 0 || fm.getLinesFile("ConnectParam.txt") != 5)
            {
                fm.createFile("ConnectParam.txt");
                FormConnect fc = new FormConnect(true);
                fc.ShowDialog();
            }
            else
            {
                FormConnect fc = new FormConnect(false);
                fc.ShowDialog();
            }
        }

        private void TBPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButLogIn.PerformClick();
            }
        }
    }
}
