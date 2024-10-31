using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Project
{
    public partial class Form12 : Form
    {
        public static string str= "";
        public static int GymID;
        public Form12(string value,int val)
        {
            InitializeComponent();
            str = value;
            GymID=val;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11(str,GymID);
            this.Hide();
            f11.ShowDialog();

        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form18 f18 = new Form18(str,GymID);
            this.Hide();
            f18.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form19 f19 = new Form19(str,GymID);
            this.Hide();
            f19.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form20 f20 = new Form20(str,GymID);
            this.Hide();
            f20.ShowDialog();
        }
    }
}
