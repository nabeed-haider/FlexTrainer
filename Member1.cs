using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WindowsFormsApp1;


namespace GYM_MANAGEMENT
{
    public partial class Member1 : Form
    {
        private int member_id;
        private int gym_id;
        public Member1(int m_id=0,int g_id=0)
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var form2 = new Member2();
            form2.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {


            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            conn.Open();
            string UserName = textBox1.Text;
            string Password = textBox2.Text;
    
            string query = "Select * from Member1 where member_username = '" + UserName + "' and member_password = '" + Password + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            

            if (dr.Read())
            {
                MessageBox.Show("Login Successfully");

                member_id = dr.GetInt32(0);
                gym_id = dr.GetInt32(12);

                dr.Close();
                cmd.Dispose();
                conn.Close();

                this.Hide();
                var form4 = new Member4(member_id, gym_id);
                //form2.Closed += (s, args) => this.Close();
                //response.redirect();
                form4.Show();
            }
            else
            {
                MessageBox.Show("Username or password invalid.Please retry");
            }
            dr.Close();
            cmd.Dispose();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            var form1 = new MainPage();
            form1.Show();
        }
    }
}
