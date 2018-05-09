﻿using System;
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
    //успеваемость
    public partial class FormPerformance : Form
    {
        TeacherController tc = new TeacherController();
        public FormPerformance()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Ученик")
            {

            }
            else if (comboBox1.Text == "Класс")
            {

            }
            else if (comboBox1.Text == "Школа")
            {

            }
        }

        private void FormPerformance_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Ученик");
            comboBox1.Items.Add("Класс");
            comboBox1.Items.Add("Школа");
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBClass.Items.Clear();

            List<string> list = tc.getDiscipline(Program.login);
            for (int i = 0; i < list.Count; i++)
            {
                CBClass.Items.Add(list[i]);
            }


            CBClass.SelectedIndex = 0;
        }

        private void CBClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBLetter.Items.Clear();

            List<string> list = new List<string>();

            list = tc.getListLetters(CBClass.Text);


            for (int i = 0; i < list.Count; i++)
            {
                CBLetter.Items.Add(list[i]);
            }
            CBLetter.SelectedIndex = 0;
        }

        private void CBLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
