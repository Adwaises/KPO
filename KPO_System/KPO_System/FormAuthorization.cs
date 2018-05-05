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
        string sql = "select id_teacher from teacher where famil = ";

        bool authorization = false;

        public FormAuthorization()
        {
            InitializeComponent();
            TBlogin.Text = "Parshina";
           
        }

        private void ButLogIn_Click(object sender, EventArgs e)
        {
            //валидация
            // если есть () или ; или пустые

            if (TBlogin.Text.Contains('(') || TBlogin.Text.Contains(')') || TBlogin.Text.Contains(';') || TBlogin.Text.Length > 20)
            {
                return;
            }

            if (TBPassword.Text.Contains('(') || TBPassword.Text.Contains(')') || TBPassword.Text.Contains(';') || TBPassword.Text.Length > 20)
            {
                return;
            }

            //запрос к БД

            string sqlOne = sql +String.Format( "'{0}';",TBlogin.Text);

            ManagerBD mBD = new ManagerBD();
            mBD.init();
            

            DataTable dt = new DataTable();

            dt = mBD.selectionquery(sqlOne);

            if (dt.Rows.Count != 0)
            {
                login = TBlogin.Text;
                if(dt.Rows[0][0].ToString() == TBPassword.Text)
                {
                    authorization = true;
                }
            }

            //TBPassword.Text = result;
            //открытие формы
            if(login.ToLower() == "admin" && TBPassword.Text.ToLower() == "admin")
            {
                FormAdmin fa = new FormAdmin();
                fa.ShowDialog();
            } else if(login == "")
            {
                MessageBox.Show("Не найден логин", "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
            } else if(authorization) 
            {
                authorization = false;
                FormTeacher ft = new FormTeacher(login);
                ft.ShowDialog();
            } else
            {
                MessageBox.Show( "Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
