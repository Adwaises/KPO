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
        ManagerBD mdb;
        FileManager fm = new FileManager();
        DataTable dt = new DataTable();

        List<int> listID = new List<int>();


        public AdminController(ManagerBD mbd)
        {
            mdb = mbd;

            //string[] param = fm.getParam();
            //mdb.init(param[0], param[1], param[2], param[3], param[4]);
            selectClass();
        }

        DataTable classes;

        //запрос классов
        private void selectClass()
        {
            string sql = " select number,letter from class;";

            classes = mdb.selectionQuery(sql);
        }

        public int getIdDisc(int index)
        {
            return listID[index];
        }

        public int getIdClass(int index)
        {
            return listID[index];
        }

        public List<string> getNumbersClass()
        {
            //запрос номеров классов
            List<string> list = new List<string>();
            //string sql = " select number from class group by number order by number;";

            //dt = mdb.selectionQuery(sql);

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    list.Add(dt.Rows[i][0].ToString());
            //}

            var results = from myRow in classes.AsEnumerable()
                          group myRow by myRow.Field<int>("number") into g
                          select new
                          {
                              ChargeTag = g.Key
                          };

            foreach (var anonymous in results)
            {
                string value = anonymous.ChargeTag.ToString();

                list.Add(value);
            }

            return list;
        }


        public List<string> getListLetters(string nClass)
        {
            List<string> list = new List<string>();
            //string sql = String.Format(" select letter from class where number = {0} group by letter order by letter;",
            //   Convert.ToInt32(nClass));

            //dt = mdb.selectionQuery(sql);



            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    list.Add(dt.Rows[i][0].ToString());
            //}

            var results = from myRow in classes.AsEnumerable()
                          where myRow.Field<int>("number") == Convert.ToInt32(nClass)
                          group myRow by myRow.Field<string>("letter")
              into g
                          select new
                          {
                              ChargeTag = g.Key
                          };

            foreach (var anonymous in results)
            {
                string value = anonymous.ChargeTag.ToString();

                list.Add(value);
            }

            return list;
        }


        public DataTable getList(string nClass, string letter)
        {
            listID.Clear();
            //получили список класса

            string sql = String.Format(" select id_pupil, famil as Фамилия, pupil.name as Имя, otchestvo as Отчество from pupil " +
"join class on class.id_class = pupil.id_class " +
"where number = {0} and letter = '{1}' order by famil,name,otchestvo; ", Convert.ToInt32(nClass), letter);



            dt = mdb.selectionQuery(sql);

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

            string sql = String.Format(" select id_teacher, famil as Фамилия, name as Имя, otchestvo as Отчество, password as Пароль from teacher order by famil,name,otchestvo;");

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
                            "join teacher on class.id_teacher = teacher.id_teacher order by number,letter;");


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
                                            "join teacher on discipline.id_teacher = teacher.id_teacher order by discipline.name; ");

            dt = mdb.selectionQuery(sql);

            //сохраняем порядок id и удаляем столбец
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listID.Add(Convert.ToInt32(dt.Rows[i][0]));
            }
            dt.Columns.RemoveAt(0);

            return dt;
        }

        //добавление
        public void insertTeacher(string f, string n, string o, string p)
        {
            mdb.controlQuery( String.Format("INSERT INTO Teacher(famil, name, otchestvo,password) VALUES('{0}', '{1}', '{2}', '{3}');", f,n,o,p));
        }

        public void insertDiscipline(string name, int index)
        {
            mdb.controlQuery(String.Format("INSERT INTO Discipline(name, id_teacher) VALUES('{0}', {1});",name, listID[index]));
        }

        public void insertClass(string number, string letter, int index)
        {
            mdb.controlQuery(String.Format("INSERT INTO Class(number, letter, id_teacher) VALUES({0}, '{1}', {2});", number,letter, listID[index]));
        }

        private int getIdClass(string number, string letter)
        {
            string sql = String.Format(" select id_class from class where number = {0} and letter = '{1}' ; ",number,letter);
            dt = mdb.selectionQuery(sql);
            return Convert.ToInt32( dt.Rows[0][0]);
        }

        public void insertPupil(string f, string n, string o,string number, string letter)
        {
            mdb.controlQuery(String.Format("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES({0}, '{1}', '{2}', '{3}');", getIdClass(number,letter), f, n, o));
        }


        //удаление
        public void delete(int index, string table)
        {
            if (table == "Учителя")
            {
                try
                {
                    mdb.controlQuery(String.Format("delete from teacher where id_teacher = {0}", listID[index]));
                } catch(Exception ex)
                {
                    throw new Exception("Сначала удалите связные записи \"Класс\" и \"Предмет\"");
                }
            }
            else if (table == "Предметы")
            {
                mdb.controlQuery(String.Format("delete from discipline where id_discipline = {0}", listID[index]));
            }
            else if (table == "Классы")
            {
                mdb.controlQuery(String.Format("delete from class where id_class = {0}", listID[index]));
            }
            else if (table == "Класс")
            {
                mdb.controlQuery(String.Format("delete from pupil where id_pupil = {0}", listID[index]));

            }
        }

        public void updateTeacher(string famil, string name, string otchestvo,string pswd, int index)
        {
            mdb.controlQuery(String.Format("update Teacher set famil = '{0}', name = '{1}',otchestvo = '{2}',password = '{3}' where id_teacher = {4}",
                famil, name, otchestvo, pswd, listID[index]));
        }

        public void updatePupil(string famil, string name, string otchestvo, int index)
        {
            mdb.controlQuery(String.Format("update pupil set famil = '{0}',name = '{1}', otchestvo = '{2}' where id_pupil = {3}", famil, name, otchestvo, listID[index]));
        }

        public void updateDiscipline(string name, int indexTeacher, int idDisc)
        {
            mdb.controlQuery(String.Format("update discipline set name = '{0}',id_teacher = {1}  where id_discipline= {2}", name, listID[indexTeacher], idDisc));
        }

        public void updateClass(string number, string letter, int indexTeacher, int idDClass)
        {
            mdb.controlQuery(String.Format("update class set number = {0},letter = '{1}',id_teacher = {2}  where id_class= {3}", number, letter, listID[indexTeacher], idDClass));
        }


        public void connect()
        {
            if (!fm.exists("ConnectParam.txt"))
            {
                fm.createFile("ConnectParam.txt");
                FormConnect fc = new FormConnect(true);
                fc.ShowDialog();
            }
            else if(fm.getLengthFile() == 0 || fm.getLinesFile("ConnectParam.txt") != 5)
            {
                fm.createFile("ConnectParam.txt");
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
