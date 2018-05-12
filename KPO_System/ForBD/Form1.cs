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

using MySql.Data.MySqlClient;



//          uid = "monty";
//            password = "some_pass";

namespace ForBD
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        string connStr = "";

        private DataTable dt;

        public Form1()
        {
            InitializeComponent();

            server = "localhost";
            database = "school1";
            uid = "monty";
            password = "some_pass";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";SslMode=none;charset=utf8";

            connection = new MySqlConnection(connectionString);
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {


            //string sql = "set names 'windows-1251'; SET client_encoding = UTF8; SELECT * FROM teacher";
            //string sql = "SET client_encoding = 'windows-1251'; SELECT * FROM teacher";

            string sqlProp = 
            "SET NAMES `utf8`;"+
             "SET CHARACTER SET 'utf8';"+
              "SET SESSION collation_connection = 'utf8_general_ci';";

            connection.Open();



            string sql = "SELECT famil as Фамилия,name as Имя,otchestvo as Отчество FROM teacher"; // Строка запроса
            dt = new DataTable();

            //sql = "INSERT INTO Teacher (famil,name,otchestvo) VALUES ('Паршина','Людмила', 'Николаевна');";


            MySqlCommand sqlCom = new MySqlCommand(sql, connection);

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCom);
            dataAdapter.Fill(dt);

            

            connection.Close();



          

            dataGridView1.DataSource = dt;

         


        }
    }
}
