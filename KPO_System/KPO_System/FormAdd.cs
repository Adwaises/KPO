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

        private void FormAdd_Load(object sender, EventArgs e)
        {

            if (variant == "Учителя")
            {
                //3
                label1.Text = "Фамилия";
                label2.Text = "Имя";
                label3.Text = "Отчество";
            }
            else if (variant == "Предметы")
            {
                //2
                label1.Text = "Дисциплина";
                label2.Text = "Руководитель";
                label3.Visible = false;
            }
            else if (variant == "Классы")
            {
                //3
                label1.Text = "Намер";
                label2.Text = "Буква";
                label3.Text = "Руководитель";
            }
            else if (variant == "Класс")
            {
                //3
                label1.Text = "Фамилия";
                label2.Text = "Имя";
                label3.Text = "Отчество";
            }


        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
