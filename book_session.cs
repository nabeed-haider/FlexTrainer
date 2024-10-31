using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GYM_MANAGEMENT
{
    public partial class book_session : Form
    {
        private int member_id;
        private int gym_id;
        private string name;
        private int id;
        public book_session(int m_id, int g_id,string t_n,int t_id)
        {
            InitializeComponent();
            member_id = m_id;
            gym_id = g_id;
            name=t_n;
            id = t_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var main_frm = new Member4(member_id, gym_id);
            main_frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string t_name;
            string t_id;

            if (id != 0 && name != " ")
            {
                t_name = name;
                 t_id = id.ToString();
                //textBox1.Text = t_name;
                //textBox2.Text = t_id;
            }
            else
            {
                 t_name = textBox1.Text;
                 t_id=textBox2.Text;
            }


            string start_d=textBox3.Text;
            string end_d=textBox4.Text;


            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            conn.Open();

            string query = "Select * from Trainer where TrainerID = '" + t_id + "' and Name = '" + t_name + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                

                MessageBox.Show("trainer found Successfully");
                dr.Close();
                cmd.Dispose();

                string query2 = "insert into Sessions values ('" + t_id + "','" + member_id + "','" + start_d + "','" + end_d + "','" + "Pending" + "')";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();
                

                //dr.Close();
                //cmd.Dispose();
                conn.Close();

                this.Hide();
                var form4 = new Member4(member_id, gym_id);
                form4.Show();
            }
            else
            {
                MessageBox.Show("Trainer with this name or id no avaialble");
            }
            dr.Close();
            cmd.Dispose();
            conn.Close();
        }

        private void book_session_Load(object sender, EventArgs e)
        {
            if (id != 0 && name != " ")
            {
                textBox1.Text = name;
                textBox2.Text = id.ToString();
            }
        }
    }
}
