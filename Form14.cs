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
    public partial class Form14 : Form
    {
        public static string str="";
        public static int gymID;
        public Form14(string value,int val)
        {
            InitializeComponent();
            str = value;
            gymID = val;
        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11(str, gymID);
            this.Hide();
            f11.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
