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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GYM_MANAGEMENT
{
    public partial class Feedback : Form
    {
        private int member_id;
        private int gym_id;
        private int feedback_id;
        public Feedback(int m_id, int g_id)
        {
            InitializeComponent();
            member_id = m_id;
            gym_id = g_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var main_frm = new Member4(member_id, gym_id);
            main_frm.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string t_name= textBox1.Text;
            string t_id= textBox2.Text;
            string session_id= textBox3.Text;

            string q1 = "";
            if (radioButton1.Checked)
            {
                q1 = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                q1 = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                q1 = radioButton3.Text;
            }
            else if (radioButton4.Checked)
            {
                q1 = radioButton4.Text;
            }
            else if (radioButton5.Checked)
            {
                q1 = radioButton5.Text;
            }

            string q2 = "";
            if (radioButton6.Checked)
            {
                q2 = radioButton6.Text;
            }
            else if (radioButton7.Checked)
            {
                q2 = radioButton7.Text;
            }
            else if (radioButton8.Checked)
            {
                q2 = radioButton8.Text;
            }
            else if (radioButton9.Checked)
            {
                q2 = radioButton9.Text;
            }
            else if (radioButton10.Checked)
            {
                q2 = radioButton10.Text;
            }

            string q3 = "";
            if (radioButton11.Checked)
            {
                q3 = radioButton11.Text;
            }
            else if (radioButton12.Checked)
            {
                q3 = radioButton12.Text;
            }
            else if (radioButton13.Checked)
            {
                q3 = radioButton13.Text;
            }
            else if (radioButton14.Checked)
            {
                q3 = radioButton14.Text;
            }
            else if (radioButton15.Checked)
            {
                q3 = radioButton15.Text;
            }

            string q4 = "";
            if (radioButton16.Checked)
            {
                q4 = radioButton16.Text;
            }
            else if (radioButton17.Checked)
            {
                q4 = radioButton17.Text;
            }
            else if (radioButton18.Checked)
            {
                q4 = radioButton18.Text;
            }
            else if (radioButton19.Checked)
            {
                q4 = radioButton19.Text;
            }
            else if (radioButton20.Checked)
            {
                q4 = radioButton20.Text;
            }


            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2BQ5JAD\\SQLEXPRESS;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();

            string query = "Select * from Sessions where TrainerID = '" + t_id + "' and SessionId = '" + session_id + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                MessageBox.Show("trainer session found Successfully");
                dr.Close();
                cmd.Dispose();

                string query2 = "insert into Trainer_Feedback values ('" + t_id + "','" + member_id + "','" + session_id + "')";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();

                string recent = "Select * from Trainer_Feedback where trainer_ID = '" + t_id + "' and sesion_id = '" + session_id + "'";

                SqlCommand cmd3 = new SqlCommand(recent, conn);
                SqlDataReader dr2 = cmd3.ExecuteReader();
                if (dr2.Read())
                {
                   
                    feedback_id = dr2.GetInt32(0);
                    dr2.Close();
                    cmd3.Dispose();

                    string query3 = "insert into Feedback_questions values ('" + feedback_id + "','" + "The trainer effectively communicated exercise techniques and instructions. " + "','" + q1 + "')";
                    SqlCommand cmd4 = new SqlCommand(query3, conn);
                    cmd4.ExecuteNonQuery();
                    cmd4.Dispose();

                    string query4 = "insert into Feedback_questions values ('" + feedback_id + "','" + "The trainer provided personalized attention and support during my workouts. " + "','" + q2 + "')";
                    SqlCommand cmd5 = new SqlCommand(query4, conn);
                    cmd5.ExecuteNonQuery();
                    cmd5.Dispose();

                    string query5 = "insert into Feedback_questions values ('" + feedback_id + "','" + "The trainer knowledge of fitness and health was evident in their guidance. " + "','" + q3 + "')";
                    SqlCommand cmd6 = new SqlCommand(query5, conn);
                    cmd6.ExecuteNonQuery();
                    cmd6.Dispose();

                    string query6 = "insert into Feedback_questions values ('" + feedback_id + "','" + "The trainer created a motivating and encouraging environment for fitness progress. " + "','" + q4 + "')";
                    SqlCommand cmd7 = new SqlCommand(query6, conn);
                    cmd7.ExecuteNonQuery();
                    cmd7.Dispose();

                }
                else
                {
                    MessageBox.Show("trainer feedback creation failed");
                    //cmd2.ExecuteNonQuery();
                    //cmd2.Dispose();
                }
                


                //dr.Close();
                //cmd.Dispose();
                conn.Close();

                this.Hide();
                var form4 = new Member4(member_id, gym_id);
                form4.Show();
            }
            else
            {
                MessageBox.Show("Trainer session with this id not exist");
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            

        }
    }
}
