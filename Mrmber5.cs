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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace GYM_MANAGEMENT
{
    public partial class Mrmber5 : Form
    {
        private int member_id;
        private int gym_id;
        private int workout_id;
        public Mrmber5(int m_id, int g_id)
        {
            InitializeComponent();
            member_id = m_id;
            gym_id = g_id;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            var main_f = new Member4(member_id,gym_id);
            main_f.Show();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string pushups_sets = comboBox3.Text;
            string pushups_reps = comboBox10.Text;

            string pullups_sets = comboBox4.Text;
            string pullups_reps = comboBox9.Text;

            string chinups_sets = comboBox5.Text;
            string cinups_reps = comboBox8.Text;

            string stretch_sets = comboBox6.Text;
            string stretch_reps = comboBox2.Text;

            string rest = comboBox7.Text;

            string name = textBox1.Text;
            string goal = textBox2.Text;
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            conn.Open();
           
            //string query = "insert into WorkoutPlan values ('" + name + "','" + goal + "','" + 1 + "','" + member_id + "','" + gym_id + "')";
            string query = "INSERT INTO WorkoutPlan (WorkoutPlan_Name, WorkoutPlan_goal, trainer_id,member_id,GymID) VALUES (@WorkoutPlan_Name, @WorkoutPlan_goal,@trainer_id,@member_id,@GymID)";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@WorkoutPlan_Name", name);
            cmd.Parameters.AddWithValue("@WorkoutPlan_goal", goal);
            cmd.Parameters.AddWithValue("@trainer_id", DBNull.Value);
            cmd.Parameters.AddWithValue("@member_id", member_id);
            cmd.Parameters.AddWithValue("@GymID", gym_id);

            cmd.ExecuteNonQuery();
             cmd.Dispose();

            //==========exercise===================
            // conn.Open();
            string query2 = "select * from WorkoutPlan where WorkoutPlan_id=(select max(WorkoutPlan_id) from WorkoutPlan)";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            
            

            if (dr2.Read())
            {
                MessageBox.Show("workout id create successfully");
                workout_id = dr2.GetInt32(0);

            }
            else
            {
                MessageBox.Show("workput creation failed.wrong data entry");
            }
            dr2.Close();
            cmd.Dispose();
            


            string query3 = "insert into Exercise values ('" + "Pushups" + "','" + pushups_sets + "','" + pushups_reps + "','" + rest + "','" + workout_id + "')";
            SqlCommand cmd3 = new SqlCommand(query3, conn);
            cmd3.ExecuteNonQuery();
            cmd3.Dispose();

            string query4 = "insert into Exercise values ('" + "Pullups" + "','" + pullups_sets + "','" + pullups_reps + "','" + rest + "','" + workout_id + "')";
            SqlCommand cmd4 = new SqlCommand(query4, conn);
            cmd4.ExecuteNonQuery();
            cmd4.Dispose();

            string query5 = "insert into Exercise values ('" + "Chinups" + "','" + chinups_sets + "','" + cinups_reps + "','" + rest + "','" + workout_id + "')";
            SqlCommand cmd5 = new SqlCommand(query5, conn);
            cmd5.ExecuteNonQuery();
            cmd5.Dispose();

            string query6 = "insert into Exercise values ('" + "Stretches" + "','" + stretch_sets + "','" + stretch_reps + "','" + rest + "','" + workout_id + "')";
            SqlCommand cmd6 = new SqlCommand(query6, conn);
            cmd6.ExecuteNonQuery();
            cmd6.Dispose();


            conn.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
