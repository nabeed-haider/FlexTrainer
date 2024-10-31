using DB_Project;
using rdlc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var f1 = new Report1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var f1 = new Report2();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            var f1 = new Report3();
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            var f1 = new Report4();
            f1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            var f1 = new Report5();
            f1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            var f1 = new Report6();
            f1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            var f1 = new Report8();
            f1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            var f1 = new Report7();
            f1.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
            var f1 = new Report9();
            f1.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
            var f1 = new Form1();
            f1.Show();
        }
    }
}
