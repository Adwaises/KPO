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
    public partial class FormAdmin : Form
    {

        DataTable dt = new DataTable();
        AdminController ac = new AdminController();
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void подключениеКБДToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            TeacherController tc = new TeacherController();

            comboBoxVariants.Items.Add("Учителя");
            comboBoxVariants.Items.Add("Предметы");
            comboBoxVariants.Items.Add("Классы");
            comboBoxVariants.Items.Add("Класс");
            comboBoxVariants.SelectedIndex = 0;
        }

        private void comboBoxVariants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVariants.Text == "Учителя")
            {
                label1.Visible = false;
                label2.Visible = false;
                CBClass.Visible = false;
                CBLetter.Visible = false;
            } else if (comboBoxVariants.Text == "Предметы")
            {
                label1.Visible = false;
                label2.Visible = false;
                CBClass.Visible = false;
                CBLetter.Visible = false;
            } else if (comboBoxVariants.Text == "Классы")
            {
                label1.Visible = false;
                label2.Visible = false;
                CBClass.Visible = false;
                CBLetter.Visible = false;
            }
            else if (comboBoxVariants.Text == "Класс")
            {
                label1.Visible = true;
                label2.Visible = true;
                CBClass.Visible = true;
                CBLetter.Visible = true;

                List<string> list = ac.getNumbersClass();
                for (int i = 0; i < list.Count; i++)
                {
                    CBClass.Items.Add(list[i]);
                }


                CBClass.SelectedIndex = 0;

            }
        }

        private void CBClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBLetter.Items.Clear();

            List<string> list = new List<string>();

            list = ac.getListLetters(CBClass.Text);


            for (int i = 0; i < list.Count; i++)
            {
                CBLetter.Items.Add(list[i]);
            }
            CBLetter.SelectedIndex = 0;
        }

        private void ButGet_Click(object sender, EventArgs e)
        {
            dt = null;
            dataGridView1.DataSource = null;

            if (comboBoxVariants.Text == "Учителя")
            {
                dt = ac.getListTeachers();
                dataGridView1.DataSource = dt;
                noSort();
            }
            else if (comboBoxVariants.Text == "Предметы")
            {
                dt = ac.getListDiscipline();
                dataGridView1.DataSource = dt;
                noSort();
            }
            else if (comboBoxVariants.Text == "Классы")
            {
                dt = ac.getListClasses();
                dataGridView1.DataSource = dt;
                noSort();
            }
            else if (comboBoxVariants.Text == "Класс")
            {
                dt = ac.getList(CBClass.Text, CBLetter.Text);

                dataGridView1.DataSource = dt;
                //TBMark.Text = dt.Rows[dataGridView1.CurrentRow.Index][3].ToString();
                noSort();

            }



        }

        private void noSort()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //тест
            FormAdd fa = new FormAdd(comboBoxVariants.Text);
            fa.buttonOK.Click += (senderSlave, eSlave) =>
            {
                this.label1.Text = fa.textBox1.Text;
            };
            fa.ShowDialog();
        }
    }
}
