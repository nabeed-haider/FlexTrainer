﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM_MANAGEMENT
{
    public partial class workout_Report : Form
    {
        private int member_id;
        private int gym_id;
        public workout_Report(int m_id, int g_id)
        {
            InitializeComponent();
            member_id = m_id;
            gym_id = g_id;
        }

        private void workout_Report_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
