using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rdlc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2BQ5JAD\\SQLEXPRESS;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();
            string query = "select member_id,member_username,member_password,member_Regdate,GymID from member1";
            SqlCommand cmd = new SqlCommand(query, conn);


            SqlDataAdapter dr = new SqlDataAdapter(cmd);

            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dr.Fill(dt);
           
           // dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.DataSource= dt;
           // dataGridView1.localreport.Reportpath = "Report1.rdlc";
            dr.Dispose();
            dt.Dispose();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2BQ5JAD\\SQLEXPRESS;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();
            string query = "select * from member1 where member_regdate>=DATEADD(month, -3, GETDATE())";
            SqlCommand cmd = new SqlCommand(query, conn);


            SqlDataAdapter dr = new SqlDataAdapter(cmd);

            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dr.Fill(dt);

            // dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.DataSource = dt;
            // dataGridView1.localreport.Reportpath = "Report1.rdlc";
            dr.Dispose();
            dt.Dispose();
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2BQ5JAD\\SQLEXPRESS;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();
            string query = "select Name,Trainer.Trainerid,memberid,start_d,end_d from Trainer inner join sessions on Trainer.Trainerid=sessions.Trainerid where status='pending'";
            SqlCommand cmd = new SqlCommand(query, conn);


            SqlDataAdapter dr = new SqlDataAdapter(cmd);

            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dr.Fill(dt);

            // dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.DataSource = dt;
            // dataGridView1.localreport.Reportpath = "Report1.rdlc";
            dr.Dispose();
            dt.Dispose();
            conn.Close();
        }
    }
}
