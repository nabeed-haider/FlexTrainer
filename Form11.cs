using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace DB_Project
{
    public partial class Form11 : Form
    {
        public static int GymId;
        public Form11(string value,int gymid)
        {
            InitializeComponent();
            label2.Text = value;
            GymId= gymid;
        }
        public string Value { get; set; }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12(label2.Text,GymId);
            
            this.Hide();
            f12.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Form13 f13 = new Form13(label2.Text,GymId);
            
            this.Hide();
            f13.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14(label2.Text,GymId);

            this.Hide();
            f14.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16(label2.Text,GymId);
            this.Hide(); 
            f16.ShowDialog();  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15(label2.Text,GymId);
            this.Hide();
            f15.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17(label2.Text,GymId);
            this.Hide();
            f17.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            var form1 = new MainPage();
            form1.Show();
        }
    }
}
