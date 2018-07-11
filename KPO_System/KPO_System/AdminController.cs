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

        public int getIdDisc(int index)
        {
            return listID[index];
        }

        public int getIdClass(int index)
        {
            return listID[index];
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

        //добавление
        public void insertTeacher(string f, string n, string o)
        {
            mdb.controlQuery( String.Format( "INSERT INTO Teacher(famil, name, otchestvo) VALUES('{0}', '{1}', '{2}');",f,n,o));
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
            //mBD.controlquery("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES(1, 'Андреев', 'Вячеслав', 'Сергеевич');");
            mdb.controlQuery(String.Format("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES({0}, '{1}', '{2}', '{3}');", getIdClass(number,letter), f, n, o));
        }


        //удаление
        public void delete(int index, string table)
        {
            if (table == "Учителя")
            {
                mdb.controlQuery(String.Format( "delete from teacher where id_teacher = {0}",listID[index]));
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

        public void updateTeacher(string famil, string name, string otchestvo, int index)
        {
            mdb.controlQuery(String.Format("update Teacher set famil = '{0}' where id_teacher = {1}",famil, listID[index]));
            mdb.controlQuery(String.Format("update Teacher set name = '{0}' where id_teacher = {1}", name, listID[index]));
            mdb.controlQuery(String.Format("update Teacher set otchestvo = '{0}' where id_teacher = {1}", otchestvo, listID[index]));
        }

        public void updatePupil(string famil, string name, string otchestvo, int index)
        {
            mdb.controlQuery(String.Format("update pupil set famil = '{0}' where id_pupil = {1}", famil, listID[index]));
            mdb.controlQuery(String.Format("update pupil set name = '{0}' where id_pupil = {1}", name, listID[index]));
            mdb.controlQuery(String.Format("update pupil set otchestvo = '{0}' where id_pupil = {1}", otchestvo, listID[index]));
        }

        public void updateDiscipline(string name, int indexTeacher, int idDisc)
        {
            mdb.controlQuery(String.Format("update discipline set name = '{0}' where id_discipline= {1}", name, idDisc));
            mdb.controlQuery(String.Format("update discipline set id_teacher = {0} where id_discipline = {1}", listID[indexTeacher], idDisc));
        }

        public void updateClass(string number, string letter, int indexTeacher, int idDClass)
        {
            mdb.controlQuery(String.Format("update class set number = {0} where id_class= {1}", number, idDClass));
            mdb.controlQuery(String.Format("update class set letter = '{0}' where id_class= {1}", letter, idDClass));
            mdb.controlQuery(String.Format("update class set id_teacher = {0} where id_class = {1}", listID[indexTeacher], idDClass));
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
