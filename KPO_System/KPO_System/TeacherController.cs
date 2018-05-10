using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO_System
{
    public class TeacherController
    {
        ManagerBD mdb = new ManagerBD();
        DataTable dt = new DataTable();
        DataTable dtMarks = new DataTable();
        List<int> listID = new List<int>();
        List<int> listIdPupilPerf = new List<int>();
        //DateTime date = DateTime.Now;


        string discipline = "";
        int idDiscipline = 0;


        public TeacherController()
        {
            mdb.init();
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


            dt.Columns.Add("Оценка");

            //получили список оценок за дату

            sql = String.Format("select id_pupil, mark from performance " +
"join discipline on discipline.id_discipline = Performance.id_discipline " +
"where discipline.name = '{0}' and date_letter = '{1}';", discipline, Program.date.ToString("yyyy-MM-dd"));

            dtMarks = new DataTable();
            dtMarks = mdb.selectionQuery(sql);

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

            return dt;
        }

        public List<string> getDiscipline(string login)
        {
            List<string> list = new List<string>();
            string sql = " select number from class group by number order by number;";

            dt = mdb.selectionQuery(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i][0].ToString());
            }
           

            //запрос дисциплины по учителю
            sql = String.Format("select discipline.name,discipline.id_discipline from discipline " +
"join teacher on discipline.id_teacher = teacher.id_teacher " +
"where teacher.famil = '{0}'; ", login);

            dt = mdb.selectionQuery(sql);

            discipline = dt.Rows[0][0].ToString();
            idDiscipline = Convert.ToInt32(dt.Rows[0][1]);

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


        public void postMark(string mark, int index)
        {
            string sql = "";

            if (mark.Length == 1 && dt.Rows[index][3].ToString() == "")
            {
                sql = String.Format("insert into Performance (Date_letter,id_pupil, id_discipline,mark) values ('{0}', {1}, {2},'{3}');",
                 Program.date.ToString("yyyy-MM-dd"), listID[index], idDiscipline, mark);

            }
            else if (mark.Length == 1 && dt.Rows[index][3].ToString() != "")
            {
                sql = String.Format("update performance set mark = '{0}' where id_pupil = {1} and id_discipline = {2} and Date_letter = '{3}';",
                    mark, listID[index], idDiscipline, Program.date.ToString("yyyy-MM-dd"));

            }
            else if (mark.Length == 0)
            {
                sql = String.Format("delete from performance where id_pupil = {0} and id_discipline = {1};",
                    listID[index], idDiscipline);
            }

            mdb.controlQuery(sql);
        }

        //успеваемость

        //ToString("yyyy-MM-dd")

        public DataTable getPerformancePupil(int id_pupil,DateTime date1, DateTime date2)
        {
            DataTable dtFinal = new DataTable();
            int i = 0;

            while(date1.Date <= date2.Date)
            {
                DataTable tmp = getMarkPupilDay(id_pupil, date1);
                date1 = date1.AddDays(1);


                if (i == 0)
                {
                    dtFinal = tmp;
                    i++;
                }
                else
                {
                    dtFinal.Columns.Add(date1.ToString());
                    for (int j = 0; j < dtFinal.Rows.Count; j++)
                    {
                        dtFinal.Rows[j][dtFinal.Columns.Count - 1] = tmp.Rows[j][1];
                    }
                    i++;
                }
            }



            return dtFinal;

        }


        private DataTable getMarkPupilDay(int id_pupil, DateTime date)
        {
            string sql = String.Format("select id_discipline,name from discipline;");
            dt = mdb.selectionQuery(sql);
            DataTable dtPupil = new DataTable();

            Dictionary<string, string> dict = new Dictionary<string, string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql = String.Format("select mark from performance where id_pupil = {0} and id_discipline = {1}" +
                    " and Date_letter = '{2}';",
                    listIdPupilPerf[id_pupil], dt.Rows[i][0].ToString(), date.ToString("yyyy-MM-dd"));

                string key = dt.Rows[i][1].ToString();
                dtPupil = mdb.selectionQuery(sql);

                if (dtPupil.Rows.Count != 0)
                {
                    
                    //dict.Add(key, 0);

                        dict[key]= dtPupil.Rows[0][0].ToString();
                        
               

                }
                else
                {
                    dict.Add(key, "0");
                    //0
                }
            }

            //создаём таблицу
            dt = new DataTable();
            dt.Columns.Add("Предмет");
            dt.Columns.Add(date.ToString("yyyy-MM-dd"));
            foreach (var d in dict)
            {
                dt.Rows.Add(d.Key, String.Format("{0:0.#}", d.Value));
            }

            return dt;
        }

        public DataTable getPerformanceClass(string number,string letter, string date1, string date2)
        {
            DataTable dtFinal = new DataTable();
            string sql = String.Format("select id_discipline, name from discipline;");
            DataTable dtDisc = mdb.selectionQuery(sql);



            for (int i = 0; i < dtDisc.Rows.Count; i++)
            {
                DataTable tmp = getAvgDisc(number, letter, date1, date2, dtDisc.Rows[i][0].ToString(), dtDisc.Rows[i][1].ToString());
                
                if(i==0)
                {
                    dtFinal = tmp;
                } else
                {
                    dtFinal.Columns.Add(dtDisc.Rows[i][1].ToString());
                    for(int j=0; j< dtFinal.Rows.Count;j++)
                    {
                        dtFinal.Rows[j][dtFinal.Columns.Count - 1] = tmp.Rows[j][3];
                    }
                }

            }



            return dtFinal;
        }

        private DataTable getAvgDisc(string number, string letter, string date1, string date2, string idDisc, string nameDisc)
        {
            string sql = String.Format("select id_pupil, famil, name, otchestvo from pupil " +
"join class on class.id_class = pupil.id_class " +
"where number = {0} and letter = '{1}';", number, letter);
            dt = mdb.selectionQuery(sql);


            DataTable dtClass = new DataTable();
            Dictionary<string, double> dict = new Dictionary<string, double>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql = String.Format("select mark from performance where id_pupil = {0}" +
                    " and id_discipline = {3} and mark NOT LIKE 'Н' and Date_letter between '{1}' and '{2}';",
                    dt.Rows[i][0].ToString(), date1, date2,idDisc);


                string key = dt.Rows[i][1].ToString() + " " + dt.Rows[i][2].ToString() + " " + dt.Rows[i][3].ToString();
                dtClass = mdb.selectionQuery(sql);

                if (dtClass.Rows.Count != 0)
                {
                    int count = 0;
                    dict.Add(key, 0);

                    //крутим в цикле
                    for (int j = 0; j < dtClass.Rows.Count; j++)
                    {
                        dict[key] += Convert.ToInt32(dtClass.Rows[j][0]);
                        count++;
                    }
                    dict[key] /= count;

                }
                else
                {
                    dict.Add(key, 0);
                    //0
                }
            }


            dt = new DataTable();
            dt.Columns.Add("Фамилия");
            dt.Columns.Add("Имя");
            dt.Columns.Add("Отчество");
            dt.Columns.Add(nameDisc);



            foreach (var d in dict)
            {
                string[] s = d.Key.Split(' ');
                dt.Rows.Add(s[0], s[1], s[2], String.Format("{0:0.#}", d.Value));
            }

            return dt;
        }

        public DataTable getPerformanceSchool(string date1, string date2) {

            DataTable dtFinal = new DataTable();
            string sql = String.Format("select id_discipline, name from discipline;");
            DataTable dtDisc = mdb.selectionQuery(sql);



            for (int i = 0; i < dtDisc.Rows.Count; i++)
            {
                DataTable tmp = getAvgSchool(date1, date2, dtDisc.Rows[i][0].ToString(), dtDisc.Rows[i][1].ToString());

                if (i == 0)
                {
                    dtFinal = tmp;
                }
                else
                {
                    dtFinal.Columns.Add(dtDisc.Rows[i][1].ToString());
                    for (int j = 0; j < dtFinal.Rows.Count; j++)
                    {
                        dtFinal.Rows[j][dtFinal.Columns.Count - 1] = tmp.Rows[j][1];
                    }
                }

            }



            return dtFinal;

        }

        public DataTable getAvgSchool(string date1, string date2, string idDisc, string nameDisc)
        {
            string sql = String.Format("select id_class,number,letter from class;");
            dt = mdb.selectionQuery(sql);
            DataTable dtSchool = new DataTable();

            Dictionary<string, double> dict = new Dictionary<string, double>();

            for (int i =0; i<dt.Rows.Count;i++)
            {
                sql = String.Format("select  mark from pupil "+
                "join class on class.id_class = pupil.id_class " +
                "join performance on pupil.id_pupil = Performance.id_pupil " +
                "where class.id_class={0} and id_discipline = {3} and mark NOT LIKE 'Н' " +
                    " and Date_letter between '{1}' and '{2}';",
                    dt.Rows[i][0].ToString(), date1, date2,idDisc);

                string key = dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString();
                dtSchool = mdb.selectionQuery(sql);

                if(dtSchool.Rows.Count != 0)
                {
                    int count = 0;
                    dict.Add(key, 0);

                    //крутим в цикле
                    for (int j = 0; j < dtSchool.Rows.Count; j++)
                    {
                        dict[key] += Convert.ToInt32(dtSchool.Rows[j][0]);
                        count++;
                    }
                    dict[key] /= count;

                } else
                {
                    dict.Add(key, 0);
                    //0
                }
            }

            //создаём таблицу
            dt = new DataTable();
            dt.Columns.Add("Класс");
            dt.Columns.Add(nameDisc);
            foreach (var d in dict)
            {
                dt.Rows.Add(d.Key, String.Format("{0:0.#}", d.Value));
            }

            return dt;
        }


        public List<string> getFamilPupils(string nClass, string letter)
        {
            List<string> list = new List<string>();
            string sql = String.Format("select id_pupil,famil, pupil.name from pupil join class on " +
                "class.id_class = pupil.id_class where number = {0} and letter = '{1}';", nClass, letter);
            dt = mdb.selectionQuery(sql);



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i][1].ToString()+" "+ dt.Rows[i][2].ToString());
            }

            //сохраняем порядок id и удаляем столбец
            listIdPupilPerf.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listIdPupilPerf.Add(Convert.ToInt32(dt.Rows[i][0]));
            }


            return list;
        }

    }
}
