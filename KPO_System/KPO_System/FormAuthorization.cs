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
            TBlogin.Text = "Паршина";
            TBPassword.Text = "Паршина1";
        }

        private void ButLogIn_Click(object sender, EventArgs e)
        {
            //валидация
            // если есть () или ; или пустые

            login = TBlogin.Text;

            if (TBlogin.Text.Contains('(') || TBlogin.Text.Contains(')') || TBlogin.Text.Contains(';') || TBlogin.Text.Length > 20)
            {
                return;
            }

            if (TBPassword.Text.Contains('(') || TBPassword.Text.Contains(')') || TBPassword.Text.Contains(';') || TBPassword.Text.Length > 20)
            {
                return;
            }

            try
            {
                if(!fm.exists("ConnectParam.txt"))
                {
                    MessageBox.Show("Файл параметров не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fm.createFileParam();
                    FormConnect fc = new FormConnect(true);
                    fc.ShowDialog();
                    return;
                }
                else if(fm.getLengthFile() == 0 || fm.getLinesFile() != 5)
                {
                    MessageBox.Show("Файл параметров повреждён", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fm.createFileParam();
                    FormConnect fc = new FormConnect(true);
                    fc.ShowDialog();
                    return;
                }
                string[] param = fm.getParam();
                mBD.init(param[0], param[1], param[2], param[3], param[4]);

                if (!mBD.isConnect())
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

                string pAdm = fm.getPasswd();

                //открытие формы
                if (login.ToLower() == "admin" && TBPassword.Text.ToLower() == pAdm)
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

        private void FormAuthorization_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fm.getLengthFile() == 0 || fm.getLinesFile() != 5)
            {
                fm.createFileParam();
                FormConnect fc = new FormConnect(true);
                fc.ShowDialog();
            }
            else
            {
                FormConnect fc = new FormConnect(false);
                fc.ShowDialog();
            }
        }
    }
}
