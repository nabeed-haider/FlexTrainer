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
    public partial class Form13 : Form
    {
        public static int gymID;
        public static string str = "";
        public Form13(string value,int val)
        {
            InitializeComponent();
            str = value;
            gymID = val;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11(str,gymID);
            this.Hide();
            f11.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }
    }
}
