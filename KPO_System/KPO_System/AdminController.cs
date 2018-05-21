using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO_System
{
    class AdminController
    {
        ManagerBD mdb = new ManagerBD();
        FileManager fm = new FileManager();
        DataTable dt = new DataTable();

        List<int> listID = new List<int>();


        public AdminController()
        {


            string[] param = fm.getParam();
            mdb.init(param[0], param[1], param[2], param[3], param[4]);

        }

        //кажется это 2 разные функции, разобраться
        public List<string> getNumbersClass()
        {
            //запрос номеров классов
            List<string> list = new List<string>();
            string sql = " select number from class group by number order by number;";

            dt = mdb.selectionQuery(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i][0].ToString());
            }


//            //запрос дисциплины по учителю
//            sql = String.Format("select discipline.name,discipline.id_discipline from discipline " +
//"join teacher on discipline.id_teacher = teacher.id_teacher " +
//"where teacher.famil = '{0}'; ", login);

//            dt = mdb.selectionQuery(sql);

//            discipline = dt.Rows[0][0].ToString();
//            idDiscipline = Convert.ToInt32(dt.Rows[0][1]);

            return list;
        }


        public List<string> getListLetters(string nClass)
        {
            List<string> list = new List<string>();
            string sql = String.Format(" select letter from class where number = {0} group by letter order by letter;",
               Convert.ToInt32(nClass));

            dt = mdb.selectionQuery(sql);



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i][0].ToString());
            }
            return list;
        }


        public DataTable getList(string nClass, string letter)
        {
            listID.Clear();
            //получили список класса

            string sql = String.Format(" select id_pupil, famil as Фамилия, pupil.name as Имя, otchestvo as Отчество from pupil " +
"join class on class.id_class = pupil.id_class " +
"where number = {0} and letter = '{1}'; ", Convert.ToInt32(nClass), letter);



            dt = mdb.selectionQuery(sql);

            //dataGridView1.DataSource = dt;


//            dt.Columns.Add("Оценка");

//            //получили список оценок за дату

//            sql = String.Format("select id_pupil, mark from performance " +
//"join discipline on discipline.id_discipline = Performance.id_discipline " +
//"where discipline.name = '{0}' and date_letter = '{1}';", discipline, Program.date.ToString("yyyy-MM-dd"));

//            dtMarks = new DataTable();
//            dtMarks = mdb.selectionQuery(sql);

//            //находим соотвествия
//            for (int i = 0; i < dtMarks.Rows.Count; i++)
//            {
//                for (int j = 0; j < dt.Rows.Count; j++)
//                {
//                    if ((dt.Rows[j][0]).ToString() == dtMarks.Rows[i][0].ToString())
//                    {
//                        dt.Rows[j][4] = dtMarks.Rows[i][1];
//                    }
//                }
//            }
            //сохраняем порядок id и удаляем столбец
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listID.Add(Convert.ToInt32(dt.Rows[i][0]));
            }

            dt.Columns.RemoveAt(0);

            return dt;
        }


        public DataTable getListTeachers()
        {
            listID.Clear();
            //получили список класса

            string sql = String.Format(" select id_teacher, famil as Фамилия, name as Имя, otchestvo as Отчество from teacher;");



            dt = mdb.selectionQuery(sql);

            //сохраняем порядок id и удаляем столбец
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listID.Add(Convert.ToInt32(dt.Rows[i][0]));
            }

            dt.Columns.RemoveAt(0);

            return dt;
        }

        public DataTable getListClasses()
        {
            listID.Clear();
            //получили список класса

            string sql = String.Format(" select id_class, number as Номер, letter as Буква, famil as Руководитель from class "+
                            "join teacher on class.id_teacher = teacher.id_teacher ;");



            dt = mdb.selectionQuery(sql);

            //сохраняем порядок id и удаляем столбец
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listID.Add(Convert.ToInt32(dt.Rows[i][0]));
            }

            dt.Columns.RemoveAt(0);

            return dt;
        }


        public DataTable getListDiscipline()
        {
            listID.Clear();
            //получили список класса

            string sql = String.Format(" select id_discipline, discipline.name as Дисциплина, famil as Руководитель from discipline "+
                                            "join teacher on discipline.id_teacher = teacher.id_teacher ; ");



            dt = mdb.selectionQuery(sql);

            //сохраняем порядок id и удаляем столбец
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listID.Add(Convert.ToInt32(dt.Rows[i][0]));
            }

            dt.Columns.RemoveAt(0);

            return dt;
        }

    }
}
