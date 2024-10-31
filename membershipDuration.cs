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
    public partial class membershipDuration : Form
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
        private string mem;

        private int opt = 0;
        public membershipDuration(string FN, string LN, string mail, string Adr, string gen, string gl, string db, string hght, string weght, string gym_id,string opt)
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
            mem = opt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new membership(FName, LName, Email, Adrs, gender, goal, dob, height, weight, gymid);
            form1.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string dur = "";
            if (radioButton1.Checked)
            {
                dur = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                dur = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                dur = radioButton3.Text;
            }
            else
            {
                MessageBox.Show("Select an option");
                return;
            }
            this.Hide();
            var form1 = new Member3(FName, LName, Email, Adrs, gender, goal, dob, height, weight, gymid,mem,dur);
            form1.Show();
        }
    }
}
