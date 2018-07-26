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
    public partial class FormAdd : Form
    {
        string variant = "";
        public FormAdd(string inVariant)
        {
            InitializeComponent();
            variant = inVariant;
        }

        public FormAdd(string inVariant, DataTable dt)
        {
            InitializeComponent();
            variant = inVariant;

            for(int i=0; i< dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            comboBox1.SelectedIndex = 0;
        }


        public FormAdd(string inVariant, string famil, string name, string otchestvo,string password)
        {
            InitializeComponent();
            variant = inVariant;

            textBox1.Text = famil;
            textBox2.Text = name;
            textBox3.Text = otchestvo;
            textBox4.Text = password;

            buttonOK.Text = "Обновить";
        }

        public FormAdd(string inVariant, string famil, string name, string otchestvo)
        {
            InitializeComponent();
            variant = inVariant;

            textBox1.Text = famil;
            textBox2.Text = name;
            textBox3.Text = otchestvo;

            buttonOK.Text = "Обновить";
        }

        public FormAdd(string inVariant, string passw)
        {
            InitializeComponent();
            variant = inVariant;
            textBox1.Text = passw;

        }

        public FormAdd(string inVariant, DataTable dt, string disc, string clRuk)
        {
            InitializeComponent();
            variant = inVariant;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            comboBox1.SelectedIndex = 0;

            buttonOK.Text = "Обновить";
            textBox1.Text = disc;
            comboBox1.SelectedItem = clRuk;
        }

        public FormAdd(string inVariant, DataTable dt, string number, string letter, string clRuk)
        {
            InitializeComponent();
            variant = inVariant;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            comboBox1.SelectedIndex = 0;

            buttonOK.Text = "Обновить";
            textBox1.Text = number;
            textBox2.Text = letter;
            comboBox1.SelectedItem = clRuk;
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {

            if (variant == "Учителя")
            {
                //3
                label1.Text = "Фамилия";
                label2.Text = "Имя";
                label3.Text = "Отчество";
                label4.Text = "Пароль";
                comboBox1.Visible = false;
            }
            else if (variant == "Предметы")
            {
                //2
                label1.Text = "Дисциплина";
                label2.Text = "Руководитель";

                textBox2.Visible = false;
                label3.Visible = false;
                textBox3.Visible = false;
                label4.Visible = false;
                textBox4.Visible = false;

            }
            else if (variant == "Классы")
            {
                //3
                label1.Text = "Намер";
                label2.Text = "Буква";
                label3.Text = "Руководитель";

                textBox3.Visible = false;
                comboBox1.Location = new Point( 119,64);

                label4.Visible = false;
                textBox4.Visible = false;
            }
            else if (variant == "Класс")
            {
                //3
                label1.Text = "Фамилия";
                label2.Text = "Имя";
                label3.Text = "Отчество";
                comboBox1.Visible = false;

                label4.Visible = false;
                textBox4.Visible = false;
            } else if(variant == "Пароль")
            {
                label1.Text = "Пароль";

                comboBox1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                buttonOK.Text = "Изменить";


                label4.Visible = false;
                textBox4.Visible = false;

                MinimumSize = new Size(300,130);
                Size = new Size(300, 130);
            }
            else if (variant == "Логин")
            {
                label1.Text = "Дисциплина";

                
                label2.Visible = false;
                label3.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                label4.Visible = false;
                textBox4.Visible = false;
                buttonOK.Text = "Выбрать";

                label4.Visible = false;
                textBox4.Visible = false;

                comboBox1.Location = new Point(119, 11);
                MinimumSize = new Size(300, 130);
                Size = new Size(300, 130);
            }


        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
