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
        private DataTable dt;
        string conn_param = "Server=127.0.0.1;Port=5432;User Id=postgres; Password=123456;Database=school1; ";
        string sql = "select id_teacher from teacher where famil = ";
        NpgsqlDataAdapter da;
        NpgsqlConnection conn;
        string login = "";


        public FormAuthorization()
        {
            InitializeComponent();
            TBlogin.Text = "Parshina";
            conn = new NpgsqlConnection(conn_param);
           
        }

        private void ButLogIn_Click(object sender, EventArgs e)
        {
            //валидация
            // если есть () или ; или пустые


            //запрос к БД

            string sqlOne = sql +String.Format( "'{0}';",TBlogin.Text);
            
            
            conn.Open(); //Открываем соединение.

            //string sql = "set names 'windows-1251'; SELECT * FROM teacher";

            da = new NpgsqlDataAdapter(sqlOne, conn);
            dt = new DataTable();
            da.Fill(dt);

            //dataGridView1.DataSource = dt;
            
            conn.Close(); //Закрываем соединение.

            if(dt.Rows.Count != 0)
            {
                login = TBlogin.Text;
            }

            //TBPassword.Text = result;
            //открытие формы
            if(login == "admin")
            {

            } else if(login == "")
            {
                MessageBox.Show("Ошибка","Не найден логин", MessageBoxButtons.OK,MessageBoxIcon.Error);
            } else
            {
                FormTeacher ft = new FormTeacher(conn,login);
                ft.ShowDialog();
            }


        }
    }
}
