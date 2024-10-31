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

    public partial class membership : Form
    {
        private string FName;
        private string LName;
        private string Email;
        private string Adrs;
        private string gender;
        private string goal;
        private string dob;
        private string height;
        private string weight;
        private string gymid;
        public membership(string FN, string LN, string mail, string Adr, string gen, string gl, string db, string hght, string weght, string gym_id)
        {
            InitializeComponent();
            FName = FN;
            LName = LN;
            Email = mail;
            Adrs = Adr;
            gender = gen;
            goal = gl;
            dob = db;
            height = hght;
            weight = weght;
            gymid = gym_id;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2=new Member2();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string opt = "";
            if (radioButton1.Checked)
            {
                opt = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                opt = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                opt = radioButton3.Text;
            }
            this.Hide();
            var form1 = new membershipDuration(FName, LName, Email, Adrs, gender, goal, dob, height, weight, gymid, opt);
            form1.Show();
        }
    }
}
