using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GYM_MANAGEMENT
{
    public partial class Member2 : Form
    {
        public Member2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Member1();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            conn.Open();
           // MessageBox.Show("connection open");
            string FName = textBox1.Text;
           // Console.WriteLine("Fname :\n");
            //Console.WriteLine(FName);
            string LName = textBox2.Text;
           
            string Email = textBox3.Text;
           
            string Adrs = textBox4.Text;
            string Adrs2 = textBox5.Text;
            string Adrs3 = textBox6.Text;
            Adrs += Adrs2;
            Adrs += Adrs3;
           
            string Phone = textBox7.Text;
         
            string gender="";
            if (radioButton1.Checked)
            {
                gender = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                gender = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                gender = radioButton3.Text;
            }

            string goal= textBox8.Text;
           
            //string dob = dateTimePicker1.Text;
            
            string height= textBox9.Text;
            string weight= textBox10.Text;
            string gym_id= textBox11.Text;
            string dob = textBox12.Text;

            //=========================checking gym exist or not================
            string query = "Select * from gym where gymid = '" + gym_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("GYM FOUND SUCCESSFULY");
                this.Hide();
                var form3 = new membership(FName, LName, Email, Adrs, gender, goal, dob, height, weight, gym_id);
                form3.Show();
            }
            else
            {
                MessageBox.Show("GYM NOT FOUND");
            }
            dr.Close();
            cmd.Dispose();
            conn.Close();

            //================================================================
            //this.Hide();
            //var form3 = new Form3(FName, LName, Email, Adrs, gender, goal, dob, height, weight, gym_id);
            //form3.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
