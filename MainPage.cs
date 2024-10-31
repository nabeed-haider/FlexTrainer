using DB_Project;
using GYM_MANAGEMENT;
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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f1 = new Member1();
            f1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f1 = new AdminSignIn();
            f1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f1 = new OwnerSignIn();
            f1.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var f1 = new Form7();
            f1.Show();
        }
    }
}
