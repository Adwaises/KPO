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
        ManagerBD mdb;
        FileManager fm = new FileManager();
        DataTable dt = new DataTable();
        DataTable dtMarks = new DataTable();
        List<int> listID = new List<int>();
        List<int> listIdPupilPerf = new List<int>();
        //DateTime date = DateTime.Now;


        string discipline = "";
        int idDiscipline = 0;


        public TeacherController(ManagerBD mbd)
        {
            mdb = mbd;
            getDiscipline(Program.login);
        }

        //лист на форму учителя за день
        public DataTable getList(string nClass, string letter)
        {
            listID.Clear();
            //получили список класса
            string sql = String.Format(" select id_pupil, famil as Фамилия, pupil.name as Имя, otchestvo as Отчество from pupil " +
"join class on class.id_class = pupil.id_class " +
"where number = {0} and letter = '{1}'; ", Convert.ToInt32(nClass), letter);

            dt = mdb.selectionQuery(sql);
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

       
        public List<string> getListNumClass()
        {
            //запрос номеров классов
            List<string> list = new List<string>();
            string sql = " select number from class group by number order by number;";

            dt = mdb.selectionQuery(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i][0].ToString());
            }

            return list;
        }


        public void getDiscipline (string login)
        {
            //запрос дисциплины по учителю
            string sql = String.Format("select discipline.name,discipline.id_discipline from discipline " +
"join teacher on discipline.id_teacher = teacher.id_teacher " +
"where teacher.famil = '{0}'; ", login);

            dt = mdb.selectionQuery(sql);

            discipline = dt.Rows[0][0].ToString();
            idDiscipline = Convert.ToInt32(dt.Rows[0][1]);
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
            if (mark == "н")
                mark = mark.ToUpper();

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
            } else
            {
                throw new Exception("Неверная оценка");
            }

            mdb.controlQuery(sql);
        }

        //успеваемость

        public DataTable getPerformancePupil(int id_pupil, DateTime date1, DateTime date2)
        {
            DateTime date1Start = date1;

            DataTable dtFinal = new DataTable();

            dtFinal.Columns.Add("Дисциплина");
            string sql = "select discipline.name from discipline order by discipline.name;";
            dt = mdb.selectionQuery(sql);

            Dictionary<string, int> dictDisc = new Dictionary<string, int>();
            Dictionary<string, int> dictDate = new Dictionary<string, int>();

            //заполняем дисц
            int d = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dictDisc.Add(dt.Rows[i][0].ToString(), d);
                d++;
                dtFinal.Rows.Add(dt.Rows[i][0].ToString());
            }

            //заполняем дату
            d = 0;
            while (date1.Date <= date2.Date)
            {
                dictDate.Add(date1.ToString("dd.MM.yyyy"), d);
                dtFinal.Columns.Add(date1.ToString("dd.MM.yyyy"));
                date1 = date1.AddDays(1);
                d++;
            }


            sql = String.Format("select discipline.name, date_letter, mark from pupil "+
            "join class on class.id_class = pupil.id_class "+
            "join performance on pupil.id_pupil = Performance.id_pupil "+
            "join discipline on  discipline.id_discipline = Performance.id_discipline "+
            "where Date_letter between '{0}' and '{1}' "+
            "and Performance.id_pupil = {2};", date1Start.ToString("yyyy-MM-dd"), date2.ToString("yyyy-MM-dd"), listIdPupilPerf[id_pupil]);

            dt = mdb.selectionQuery(sql);

            //расставляем

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string keyDisc = dt.Rows[i][0].ToString();
                DateTime date = Convert.ToDateTime(dt.Rows[i][1]);
                string keyDate = date.ToString("dd.MM.yyyy");

                dtFinal.Rows[dictDisc[keyDisc]][dictDate[keyDate] + 1] = dt.Rows[i][2];
            }


            dt = mdb.selectionQuery(sql);

            return dtFinal;
        }

        public DataTable getPerformanceClass(string number, string letter, string date1, string date2)
        {
            DataTable dtFinal = new DataTable();

            dtFinal.Columns.Add("Фамилия");
            dtFinal.Columns.Add("Имя");
            dtFinal.Columns.Add("Отчество");
            string sql = "select discipline.name from discipline;";
            dt = mdb.selectionQuery(sql);

            Dictionary<string, int> dictDisc = new Dictionary<string, int>();
            Dictionary<string, int> dictFIO = new Dictionary<string, int>();

            List<string> listDisc = getListDisc();
            //на сколько делить
            List<int> mnozh = new List<int>();


            //заполняем дисц
            int d = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dictDisc.Add(dt.Rows[i][0].ToString(), d);
                d++;
                dtFinal.Columns.Add(dt.Rows[i][0].ToString());
            }

            //заполняем фио

            sql = String.Format( "select famil, name, otchestvo from pupil "+
                    "join class on class.id_class = pupil.id_class "+
                    "where class.number = '{0}' and class.letter = '{1}' order by famil, name, otchestvo;", number, letter);
            dt = mdb.selectionQuery(sql);

            int fio = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dictFIO.Add(dt.Rows[i][0].ToString() + dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString(), fio);
                mnozh.Add(0);
                fio++;
                dtFinal.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString());
            }


            for(int j=0; j<dictDisc.Count;j++)
            {
                //очистка множителей
                for (int i = 0; i < mnozh.Count; i++)
                {
                    mnozh[i] = 0;
                }
                    //запрос

                    sql = String.Format("select pupil.famil, pupil.name, pupil.otchestvo, mark from pupil "+
"join class on class.id_class = pupil.id_class "+
"join performance on pupil.id_pupil = Performance.id_pupil "+
"join discipline on  discipline.id_discipline = Performance.id_discipline "+
"where class.number = '{0}' and class.letter = '{1}'  and discipline.name = '{2}' "+
"and mark NOT LIKE 'Н' and Date_letter between '{3}' and '{4}' ;", number, letter, listDisc[j], date1, date2);
                dt = mdb.selectionQuery(sql);

                // заполнение
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string keyFIO = dt.Rows[i][0].ToString() + dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString();
                    //DateTime date = Convert.ToDateTime(dt.Rows[i][3]);
                    string keyDisc = listDisc[j];

                    if (dtFinal.Rows[dictFIO[keyFIO]][dictDisc[keyDisc] + 3].ToString() == "")
                    {
                        dtFinal.Rows[dictFIO[keyFIO]][dictDisc[keyDisc] + 3] = dt.Rows[i][3];
                        mnozh[dictFIO[keyFIO]]++;
                    }
                    else
                    {
                        dtFinal.Rows[dictFIO[keyFIO]][dictDisc[keyDisc] + 3] =
                          Convert.ToInt32((dtFinal.Rows[dictFIO[keyFIO]][dictDisc[keyDisc] + 3])) + Convert.ToInt32( dt.Rows[i][3]);
                        mnozh[dictFIO[keyFIO]]++;
                    }

                }

                //деление
                for (int i = 0; i < dtFinal.Rows.Count; i++)
                {
                    if (mnozh[i] != 0)
                    {
                        string keyDisc = listDisc[j];
                        string keyFIO = dtFinal.Rows[i][0].ToString() + dtFinal.Rows[i][1].ToString() + dtFinal.Rows[i][2].ToString();

                        string s = String.Format("{0:f2}", Convert.ToDouble(dtFinal.Rows[dictFIO[keyFIO]][dictDisc[keyDisc] + 3]) / mnozh[i]);
                        if(s[2] == '0' && s[3] == '0')
                        {
                            dtFinal.Rows[dictFIO[keyFIO]][dictDisc[keyDisc] + 3] = Convert.ToInt32(Convert.ToDouble(s));
                        } else
                        {
                            dtFinal.Rows[dictFIO[keyFIO]][dictDisc[keyDisc] + 3] = s;
                        }
                    }
                }
            }
            return dtFinal;
        }


        public DataTable getPerformanceSchool(string date1, string date2)
        {
            DataTable dtFinal = new DataTable();

            dtFinal.Columns.Add("Класс");
            string sql = "select discipline.name from discipline;";
            dt = mdb.selectionQuery(sql);

            Dictionary<string, int> dictDisc = new Dictionary<string, int>();
            Dictionary<string, int> dictCl = new Dictionary<string, int>();

            List<string> listDisc = getListDisc();
            //на сколько делить
            List<int> mnozh = new List<int>();


            //заполняем дисц
            int d = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dictDisc.Add(dt.Rows[i][0].ToString(), d);
                d++;
                dtFinal.Columns.Add(dt.Rows[i][0].ToString());
            }

            //заполняем классы

            sql = String.Format("select number, letter from class order by number,letter;");
            dt = mdb.selectionQuery(sql);

            int cl = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dictCl.Add(dt.Rows[i][0].ToString() + dt.Rows[i][1].ToString() , cl);
                mnozh.Add(0);
                cl++;
                dtFinal.Rows.Add(dt.Rows[i][0].ToString() + dt.Rows[i][1].ToString());
            }


            for (int j = 0; j < dictDisc.Count; j++)
            {
                //очистка множителей
                for (int i = 0; i < mnozh.Count; i++)
                {
                    mnozh[i] = 0;
                }


                //запрос

                sql = String.Format("select class.number, class.letter , mark from class " +
"join pupil on class.id_class = pupil.id_class " +
"join performance on pupil.id_pupil = Performance.id_pupil " +
"join discipline on  discipline.id_discipline = Performance.id_discipline " +
"where mark NOT LIKE 'Н' and discipline.name = '{0}' " +
"and Date_letter between '{1}' and '{2}';", listDisc[j], date1, date2);
                dt = mdb.selectionQuery(sql);

                // заполнение
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string keyFIO = dt.Rows[i][0].ToString() + dt.Rows[i][1].ToString();
                    //DateTime date = Convert.ToDateTime(dt.Rows[i][3]);
                    string keyDisc = listDisc[j];

                    if (dtFinal.Rows[dictCl[keyFIO]][dictDisc[keyDisc] + 1].ToString() == "")
                    {
                        dtFinal.Rows[dictCl[keyFIO]][dictDisc[keyDisc] + 1] = dt.Rows[i][2];
                        mnozh[dictCl[keyFIO]]++;
                    }
                    else
                    {
                        dtFinal.Rows[dictCl[keyFIO]][dictDisc[keyDisc] + 1] =
                          Convert.ToInt32((dtFinal.Rows[dictCl[keyFIO]][dictDisc[keyDisc] + 1])) + Convert.ToInt32(dt.Rows[i][2]);
                        mnozh[dictCl[keyFIO]]++;
                    }

                }

                //деление
                for (int i = 0; i < dtFinal.Rows.Count; i++)
                {
                    if (mnozh[i] != 0)
                    {
                        string keyDisc = listDisc[j];
                        //string keyFIO = dt.Rows[i][0].ToString() + dt.Rows[i][1].ToString();
                        string keyFIO = dtFinal.Rows[i][0].ToString();

                        string s = String.Format("{0:f2}", Convert.ToDouble(dtFinal.Rows[dictCl[keyFIO]][dictDisc[keyDisc] + 1]) / mnozh[i]);
                        if (s[2] == '0' && s[3] == '0')
                        {
                            dtFinal.Rows[dictCl[keyFIO]][dictDisc[keyDisc] + 1] = Convert.ToInt32(Convert.ToDouble(s));
                        }
                        else
                        {
                            dtFinal.Rows[dictCl[keyFIO]][dictDisc[keyDisc] + 1] = s;
                        }
                    }
                }
            }
            return dtFinal;
        }


        public List<string> getFamilPupils(string nClass, string letter)
        {
            List<string> list = new List<string>();
            string sql = String.Format("select id_pupil,famil, pupil.name from pupil join class on " +
                "class.id_class = pupil.id_class where number = {0} and letter = '{1}' order by famil, pupil.name;", nClass, letter);
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


        //посещаемость

        public List<string> getListDisc()
        {
            List<string> list = new List<string>();
            string sql = " select name from discipline order by name;";

            dt = mdb.selectionQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i][0].ToString());
            }
            return list;
        }
        public DataTable getAttendanceOnDisc(DateTime date1, DateTime date2, string disc)
        {
            DataTable dtFinal = new DataTable();
            dtFinal.Columns.Add("Класс");
            string sql = "select number, letter from class order by number,letter;";

            dt = mdb.selectionQuery(sql);

            Dictionary<string, int> dictCl = new Dictionary<string, int>();
            Dictionary<string, int> dictDate = new Dictionary<string, int>();


            //заполняем классы
            int d = 0;

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                dictCl.Add(dt.Rows[i][0].ToString() + dt.Rows[i][1].ToString(),d);
                d++;
                dtFinal.Rows.Add(dt.Rows[i][0].ToString() + dt.Rows[i][1].ToString());
            }


            sql = String.Format("select class.number,class.letter, date_letter from pupil " +
"join class on class.id_class = pupil.id_class " +
"join performance on pupil.id_pupil = Performance.id_pupil " +
"join discipline on  discipline.id_discipline = Performance.id_discipline " +
"where discipline.name = '{2}' and Date_letter between '{0}' and '{1}' " +
"and mark LIKE 'Н' ;", date1.ToString("yyyy-MM-dd"), date2.ToString("yyyy-MM-dd"), disc);

            dt = mdb.selectionQuery(sql);


            //заполняем дату
            d = 0;
            while (date1.Date <= date2.Date)
            {
                dictDate.Add(date1.ToString("dd.MM.yyyy"), d);
                dtFinal.Columns.Add(date1.ToString("dd.MM.yyyy"));
                date1 = date1.AddDays(1);
                d++;
            }

            //расставляем

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string keyCl = dt.Rows[i][0].ToString() + dt.Rows[i][1].ToString();
                DateTime date = Convert.ToDateTime( dt.Rows[i][2]);
                string keyDate = date.ToString("dd.MM.yyyy");

                if (dtFinal.Rows[dictCl[keyCl]][dictDate[keyDate] + 1].ToString() == "")
                {
                    dtFinal.Rows[dictCl[keyCl]][dictDate[keyDate] + 1] = 1;
                }
                else
                {
                    dtFinal.Rows[dictCl[keyCl]][dictDate[keyDate] + 1] =
                      Convert.ToInt32((dtFinal.Rows[dictCl[keyCl]][dictDate[keyDate] + 1])) + 1;
                }
            }

            return dtFinal;
        }



        public DataTable getAttendanceOnClass(DateTime date1, DateTime date2, string number, string letter)
        {
            DataTable dtFinal = new DataTable();
            dtFinal.Columns.Add("Дисциплина");
            string sql = "select discipline.name from discipline order by discipline.name;";
            dt = mdb.selectionQuery(sql);

            Dictionary<string, int> dictDisc = new Dictionary<string, int>();
            Dictionary<string, int> dictDate = new Dictionary<string, int>();

            //заполняем дисц
            int d = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dictDisc.Add(dt.Rows[i][0].ToString(), d);
                d++;
                dtFinal.Rows.Add(dt.Rows[i][0].ToString() );
            }


            sql = String.Format("select discipline.name, date_letter from pupil " +
            "join class on class.id_class = pupil.id_class " +
            "join performance on pupil.id_pupil = Performance.id_pupil " +
            "join discipline on  discipline.id_discipline = Performance.id_discipline " +
            "where class.number = '{2}' and class.letter = '{3}' " +
            "and Date_letter between '{0}' and '{1}' " +
            "and mark LIKE 'Н' ;", date1.ToString("yyyy-MM-dd"), date2.ToString("yyyy-MM-dd"), number, letter);


            dt = mdb.selectionQuery(sql);


            //заполняем дату
            d = 0;
            while (date1.Date <= date2.Date)
            {
                dictDate.Add(date1.ToString("dd.MM.yyyy"), d);
                dtFinal.Columns.Add(date1.ToString("dd.MM.yyyy"));
                date1 = date1.AddDays(1);
                d++;
            }

            //расставляем


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string keyDisc = dt.Rows[i][0].ToString();
                DateTime date = Convert.ToDateTime(dt.Rows[i][1]);
                string keyDate = date.ToString("dd.MM.yyyy");

                if (dtFinal.Rows[dictDisc[keyDisc]][dictDate[keyDate] + 1].ToString() == "")
                {
                    dtFinal.Rows[dictDisc[keyDisc]][dictDate[keyDate] + 1] = 1;
                }
                else
                {
                    dtFinal.Rows[dictDisc[keyDisc]][dictDate[keyDate] + 1] =
                      Convert.ToInt32((dtFinal.Rows[dictDisc[keyDisc]][dictDate[keyDate] + 1])) + 1;
                }
            }


            return dtFinal;
        }

        public void connect()
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
            string[] param = fm.getParam();
            mdb.init(param[0], param[1], param[2], param[3], param[4]);
        }


    }
}
