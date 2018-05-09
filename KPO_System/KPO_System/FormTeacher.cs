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
        string discipline = "";
        int idDiscipline = 0;
        private DataTable dt;
        private DataTable dtMarks;
        ManagerBD mBD = new ManagerBD();

        List<int> listID = new List<int>();
        string login = "";

        DateTime date = DateTime.Now;
        public FormTeacher(string _login)
        {
            InitializeComponent();
            login = _login;
            Text += " - "+ login;
            mBD.init();
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            //запрос к бд и заполнение ComboBox



            string sql = " select number from class group by number order by number;";

            dt = mBD.selectionquery(sql);

            for (int i=0; i<dt.Rows.Count;i++)
            {
                CBClass.Items.Add(dt.Rows[i][0].ToString());
            }

            //запрос дисциплины по учителю
            sql =  String.Format("select discipline.name,discipline.id_discipline from discipline " +
"join teacher on discipline.id_teacher = teacher.id_teacher "+
"where teacher.famil = '{0}'; ", login);

            dt = mBD.selectionquery(sql);

            discipline = dt.Rows[0][0].ToString();
            idDiscipline = Convert.ToInt32( dt.Rows[0][1]);
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
          

            string sql =String.Format( " select letter from class where number = {0} group by letter order by letter;",
                Convert.ToInt32(CBClass.Text));

            dt = mBD.selectionquery(sql);



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CBLetter.Items.Add(dt.Rows[i][0].ToString());
            }
        }


        private void getList()
        {
            //получили список класса

            string sql = String.Format(" select id_pupil, famil, pupil.name, otchestvo from pupil " +
"join class on class.id_class = pupil.id_class " +
"where number = {0} and letter = '{1}'; ", Convert.ToInt32(CBClass.Text), CBLetter.Text);



            dt = mBD.selectionquery(sql);

            //dataGridView1.DataSource = dt;


            dt.Columns.Add("Оценка");

            //получили список оценок за дату

            sql = String.Format("select id_pupil, mark from performance " +
"join discipline on discipline.id_discipline = Performance.id_discipline " +
"where discipline.name = '{0}' and date_letter = '{1}';", discipline, date.ToString("yyyy-MM-dd"));

            dtMarks = new DataTable();
            dtMarks = mBD.selectionquery(sql);

            //находим соотвествия
            for (int i = 0; i < dtMarks.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if ((dt.Rows[j][0]).ToString() == dtMarks.Rows[i][0].ToString())
                    {
                        dt.Rows[j][4] = dtMarks.Rows[i][1];
                    }
                }
            }
            //сохраняем порядок id и удаляем столбец
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listID.Add(Convert.ToInt32(dt.Rows[i][0]));
            }

            dt.Columns.RemoveAt(0);
        }

        private void ButGet_Click(object sender, EventArgs e)
        {


            listID.Clear();
            getList();

            dataGridView1.DataSource = dt;
            TBMark.Text = dt.Rows[dataGridView1.CurrentRow.Index][3].ToString();
        }

        private void CBLetter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TBMark.Text = dt.Rows[dataGridView1.CurrentRow.Index][3].ToString();

        }

        private void ButPost_Click(object sender, EventArgs e)
        {
            if (TBMark.Text.Contains('(') || TBMark.Text.Contains(')') || TBMark.Text.Contains(';') || TBMark.Text.Length > 1)
            {
                return;
            }

            
            string sql="";

            if (TBMark.Text.Length == 1 && dt.Rows[dataGridView1.CurrentRow.Index][3].ToString() == "")
            {
                sql = String.Format("insert into Performance (Date_letter,id_pupil, id_discipline,mark) values ('{0}', {1}, {2},'{3}');",
                 date.ToString("yyyy-MM-dd"), listID[dataGridView1.CurrentRow.Index], idDiscipline, TBMark.Text);

            } else if(TBMark.Text.Length == 1 && dt.Rows[dataGridView1.CurrentRow.Index][3].ToString() != "")
            {
                sql = String.Format("update performance set mark = '{0}' where id_pupil = {1} and id_discipline = {2};",
                    TBMark.Text, listID[dataGridView1.CurrentRow.Index], idDiscipline);

            } else if(TBMark.Text.Length == 0)
            {
                sql = String.Format("delete from performance where id_pupil = {0} and id_discipline = {1};",
                    listID[dataGridView1.CurrentRow.Index], idDiscipline);
            }





            mBD.controlquery(sql);

            MessageBox.Show("Оценка выставлена", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

            getList();

            dataGridView1.DataSource = dt;
            TBMark.Text = dt.Rows[dataGridView1.CurrentRow.Index][3].ToString();

        }
    }
}
