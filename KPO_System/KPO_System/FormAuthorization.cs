using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.IO;

namespace KPO_System
{
    public partial class FormAuthorization : Form
    {
        string login = "";
        string sql = "select id_teacher from teacher where famil = ";

        bool authorization = false;
        public ManagerBD mBD = new ManagerBD();
        FileManager fm = new FileManager();
        public FormAuthorization()
        {
            InitializeComponent();
            TBlogin.Text = "Паршина";
            TBPassword.Text = "1";



        }

        private void ButLogIn_Click(object sender, EventArgs e)
        {
            //валидация
            // если есть () или ; или пустые

            login = TBlogin.Text;

            if (TBlogin.Text.Contains('(') || TBlogin.Text.Contains(')') || TBlogin.Text.Contains(';') || TBlogin.Text.Length > 20)
            {
                return;
            }

            if (TBPassword.Text.Contains('(') || TBPassword.Text.Contains(')') || TBPassword.Text.Contains(';') || TBPassword.Text.Length > 20)
            {
                return;
            }

            try
            {
                if(fm.getLengthFile() == 0 || fm.getLinesFile() != 5)
                {
                    MessageBox.Show("Файл параметров повреждён", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fm.createFileParam();
                    FormConnect fc = new FormConnect(true);
                    fc.ShowDialog();
                    return;
                }
                string[] param = fm.getParam();
                mBD.init(param[0], param[1], param[2], param[3], param[4]);

                if (!mBD.isConnect())
                {
                    MessageBox.Show("Не удалось подключиться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FormConnect fc = new FormConnect(false);
                    fc.ShowDialog();
                    //Close();
                }

                param = fm.getParam();
                mBD.init(param[0], param[1], param[2], param[3], param[4]);


                //запрос к БД

                string sqlOne = sql + String.Format("'{0}';", TBlogin.Text);


                #region insert
                //mBD.controlquery("INSERT INTO Teacher(famil, name, otchestvo) VALUES('Паршина', 'Людмила', 'Николаевна');");
                //mBD.controlquery("INSERT INTO Teacher(famil, name, otchestvo) VALUES('Коробцова', 'Светлана', 'Александровна');");
                //mBD.controlquery("INSERT INTO Teacher(famil, name, otchestvo) VALUES('Рябов', 'Андрей', 'Вячеславович');");
                //mBD.controlquery("INSERT INTO Teacher(famil, name, otchestvo) VALUES('Еремина', 'Ольга', 'Александровна');");

                //mBD.controlquery("INSERT INTO Class(number, letter, id_teacher) VALUES(5, 'А', 1);");
                //mBD.controlquery("INSERT INTO Class(number, letter, id_teacher) VALUES(5, 'Б', 2);");
                //mBD.controlquery("INSERT INTO Class(number, letter, id_teacher) VALUES(6, 'А', 4);");
                //mBD.controlquery("INSERT INTO Class(number, letter, id_teacher) VALUES(6, 'Б', 3);");

                //mBD.controlquery("INSERT INTO Discipline(name, id_teacher) VALUES('Русский язык', 1);");
                //mBD.controlquery("INSERT INTO Discipline(name, id_teacher) VALUES('Математика', 2);");
                //mBD.controlquery("INSERT INTO Discipline(name, id_teacher) VALUES('История', 3);");
                //mBD.controlquery("INSERT INTO Discipline(name, id_teacher) VALUES('Литература', 4);");


                //mBD.controlquery("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES(1, 'Андреев', 'Вячеслав', 'Сергеевич');");
                //mBD.controlquery("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES(1, 'Баженов', 'Александр', 'Григорьевич');");
                //mBD.controlquery("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES(1, 'Пронин', 'Владимир', 'Алексеевич');");

                //mBD.controlquery("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES(2, 'Васин', 'Петр', 'Алексеевич');");
                //mBD.controlquery("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES(2, 'Горбунов', 'Владимир', 'Александрович');");
                //mBD.controlquery("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES(2, 'Сабитов', 'Эдуард', 'Витальевич');");
                //mBD.controlquery("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES(2, 'Яшин', 'Михаил', 'Петрович');");

                //mBD.controlquery("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES(3, 'Григорьев', 'Антон', 'Витальевич');");
                //mBD.controlquery("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES(3, 'Котова', 'Анастасия', 'Александровна');");

                //mBD.controlquery("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES(4, 'Демина', 'Дарья', 'Андреевна');");
                //mBD.controlquery("INSERT INTO Pupil(id_class, Famil, name, otchestvo) VALUES(4, 'Филатова', 'Анастасия', 'Дмитриевна');");



                //mBD.controlquery("INSERT INTO Performance(Date_letter, id_pupil, id_discipline, mark) VALUES('2018-05-04', 1, 1, '5'); ");
                //mBD.controlquery("INSERT INTO Performance(Date_letter, id_pupil, id_discipline, mark) VALUES('2018-05-04', 4, 2, '4'); ");
                //mBD.controlquery("INSERT INTO Performance(Date_letter, id_pupil, id_discipline, mark) VALUES('2018-05-03', 8, 3, '4'); ");
                //mBD.controlquery("INSERT INTO Performance(Date_letter, id_pupil, id_discipline, mark) VALUES('2018-05-04', 10, 4, 'Н'); ");
                #endregion

                DataTable dt = new DataTable();

                dt = mBD.selectionQuery(sqlOne);

                if (dt.Rows.Count != 0)
                {
                    login = TBlogin.Text;
                    if (dt.Rows[0][0].ToString() == TBPassword.Text)
                    {
                        authorization = true;
                    }
                }

                //dt = mBD.selectionquery("select * from teacher;");
                //dataGridView1.DataSource = dt;

                //TBPassword.Text = result;
                //открытие формы
                if (login.ToLower() == "admin" && TBPassword.Text.ToLower() == "admin")
                {
                    FormAdmin fa = new FormAdmin(mBD);
                    fa.ShowDialog();
                }
                else if (login == "")
                {
                    MessageBox.Show("Не найден логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (authorization)
                {
                    authorization = false;
                    Program.login = login;
                    FormTeacher ft = new FormTeacher(mBD);
                    ft.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка\r\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormAuthorization_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
        }
    }
}
