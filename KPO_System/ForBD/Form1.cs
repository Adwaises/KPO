using Npgsql;
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

namespace ForBD
{
    public partial class Form1 : Form
    {

        private DataTable dt;
        string conn_param = "Server=127.0.0.1;Port=5432;User Id=postgres; Password=123456;Database=school;";
        // string sql = "select * from teacher;";
        //string sql = "";
        NpgsqlDataAdapter da;
        NpgsqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            conn = new NpgsqlConnection(conn_param);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.Open(); //Открываем соединение.

            //string sql = "set names 'windows-1251'; SET client_encoding = UTF8; SELECT * FROM teacher";
            string sql = "SET client_encoding = 'windows-1251'; SELECT * FROM teacher";

            da = new NpgsqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);

            byte[] UTF8encodes = UTF8Encoding.UTF8.GetBytes(dt.Rows[1][1].ToString());
            string plainText = UTF8Encoding.UTF8.GetString(UTF8encodes);
            dt.Rows[1][1] = plainText;

            dataGridView1.DataSource = dt;

            conn.Close(); //Закрываем соединение.

        }
    }
}
