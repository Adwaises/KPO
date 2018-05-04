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
        string discipline = "Russkiy Yazyk";
        private DataTable dt;
        private DataTable dtMarks;
        NpgsqlDataAdapter da;
        NpgsqlConnection conn;

        List<int> listID = new List<int>();

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

            //запрос дисциплины по учителю

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

            //получили список класса

            string sql = String.Format(" select id_pupil, famil, pupil.name, otchestvo from pupil "+
"join class on class.id_class = pupil.id_class "+
"where number = {0} and letter = '{1}'; ", Convert.ToInt32(CBClass.Text), CBLetter.Text);

            da = new NpgsqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);

            //dataGridView1.DataSource = dt;

            conn.Close(); //Закрываем соединение.

            dt.Columns.Add("Оценка");

            // получили оценки по предмету

            conn.Open(); //Открываем соединение.

            //получили список оценок

            sql = String.Format("select id_pupil, mark from performance "+
"join discipline on discipline.id_discipline = Performance.id_discipline "+
"where discipline.name = '{0}';",discipline);

            da = new NpgsqlDataAdapter(sql, conn);
            dtMarks = new DataTable();
            da.Fill(dtMarks);
            conn.Close(); //Закрываем соединение.

            //находим соотвествия
            for(int i=0; i< dtMarks.Rows.Count; i++)
            {
                for(int j=0;j<dt.Rows.Count; j++)
                {
                    if((dt.Rows[j][0]).ToString() == dtMarks.Rows[i][0].ToString())
                    {
                        dt.Rows[j][4] = dtMarks.Rows[i][1];
                    }
                }
            }
            //сохраняем порядок id и удаляем столбец
            for(int i=0;i<dt.Rows.Count;i++)
            {
                listID.Add(Convert.ToInt32( dt.Rows[i][0]));
            }

            dt.Columns.RemoveAt(0);

            dataGridView1.DataSource = dt;
        }
    }
}
