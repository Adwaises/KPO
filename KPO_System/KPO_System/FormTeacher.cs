using Npgsql;
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
    public partial class FormTeacher : Form
    {
        private DataTable dt;
        NpgsqlDataAdapter da;
        NpgsqlConnection conn;
        public FormTeacher(NpgsqlConnection connect, string login)
        {
            InitializeComponent();
            conn = connect;
            Text += " - "+login;
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            //запрос к бд и заполнение ComboBox

            conn.Open(); //Открываем соединение.

            //string sql = "set names 'windows-1251'; SELECT * FROM teacher";

            string sql = " select number from class group by number order by number;";

            da = new NpgsqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);

            //dataGridView1.DataSource = dt;

            conn.Close(); //Закрываем соединение.

            for(int i=0; i<dt.Rows.Count;i++)
            {
                CBClass.Items.Add(dt.Rows[i][0].ToString());
            }

        }

        private void успеваемостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPerformance fp = new FormPerformance();
            fp.ShowDialog();
        }

        private void посещаемостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAttendance fa = new FormAttendance();
            fa.ShowDialog();
        }

        private void CBClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBLetter.Items.Clear();
            conn.Open(); //Открываем соединение.

            //string sql = "set names 'windows-1251'; SELECT * FROM teacher";

            string sql =String.Format( " select letter from class where number = {0} group by letter order by letter;",
                Convert.ToInt32(CBClass.Text));

            da = new NpgsqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);

            //dataGridView1.DataSource = dt;

            conn.Close(); //Закрываем соединение.

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CBLetter.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void ButGet_Click(object sender, EventArgs e)
        {
            CBLetter.Items.Clear();
            conn.Open(); //Открываем соединение.

            //string sql = "set names 'windows-1251'; SELECT * FROM teacher";

            string sql = String.Format(" select ", Convert.ToInt32(CBClass.Text));

            da = new NpgsqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);

            //dataGridView1.DataSource = dt;

            conn.Close(); //Закрываем соединение.

            dataGridView1.DataSource = dt;
        }
    }
}
