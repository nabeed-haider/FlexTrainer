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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GYM_MANAGEMENT
{
    public partial class Member7 : Form
    {
        private int member_id;
        private int gym_id;
        private int dietpln_id;
        public Member7(int m_id, int g_id)
        {
            InitializeComponent();
            member_id = m_id;
            gym_id = g_id;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            var main_f = new Member4(member_id, gym_id);
            main_f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string breakfast = comboBox3.Text;
        
            string snack1 = comboBox4.Text;


            string lunch = comboBox5.Text;

            string snack2 = comboBox6.Text;


            string dinner = comboBox7.Text;

            string name= textBox1.Text;
            string goal = textBox2.Text;
            
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            conn.Open();

            //string query = "insert into DietPlan values ('" + name + "','" + goal + "','" + 1 + "','" + member_id + "','" + gym_id + "')";

            string query = "INSERT INTO DietPlan (DietPlan_Name, DietPlan_goal, trainer_id,member_id,GymID) VALUES (@DietPlan_Name, @DietPlan_goal,@trainer_id,@member_id,@GymID)";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@DietPlan_Name", name);
            cmd.Parameters.AddWithValue("@DietPlan_goal", goal);
            cmd.Parameters.AddWithValue("@trainer_id", DBNull.Value);
            cmd.Parameters.AddWithValue("@member_id", member_id);
            cmd.Parameters.AddWithValue("@GymID", gym_id);

           
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            //======================
            // conn.Open();
            string query2 = "select * from DietPlan where DietPlan_id=(select max(DietPlan_id) from DietPlan)";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();



            if (dr2.Read())
            {
                MessageBox.Show("dietplan id create successfully");
                dietpln_id = dr2.GetInt32(0);

            }
            else
            {
                MessageBox.Show("dietplan creation failed.wrong data entry");
            }
            dr2.Close();
            cmd.Dispose();

            Random rnd = new Random();
            double randomDouble = rnd.NextDouble();

            string query3 = "insert into Meal values ('" + breakfast + "','" + "breakfast" + "','" + randomDouble + "','" + randomDouble + "','" + randomDouble + "','" + dietpln_id + "')";
            SqlCommand cmd3 = new SqlCommand(query3, conn);
            cmd3.ExecuteNonQuery();
            cmd3.Dispose();

            string query4 = "insert into Meal values ('" + snack1 + "','" + "snack1" + "','" + randomDouble + "','" + randomDouble + "','" + randomDouble + "','" + dietpln_id + "')";
            SqlCommand cmd4 = new SqlCommand(query4, conn);
            cmd4.ExecuteNonQuery();
            cmd4.Dispose();

            string query5 = "insert into Meal values ('" + lunch + "','" + "lunch" + "','" + randomDouble + "','" + randomDouble + "','" + randomDouble + "','" + dietpln_id + "')";
            SqlCommand cmd5 = new SqlCommand(query5, conn);
            cmd5.ExecuteNonQuery();
            cmd5.Dispose();

            string query6 = "insert into Meal values ('" + snack2 + "','" + "snack2" + "','" + randomDouble + "','" + randomDouble + "','" + randomDouble + "','" + dietpln_id + "')";
            SqlCommand cmd6 = new SqlCommand(query6, conn);
            cmd6.ExecuteNonQuery();
            cmd6.Dispose();

            string query7 = "insert into Meal values ('" + dinner + "','" + "dinner" + "','" + randomDouble + "','" + randomDouble + "','" + randomDouble + "','" + dietpln_id + "')";
            SqlCommand cmd7 = new SqlCommand(query7, conn);
            cmd7.ExecuteNonQuery();
            cmd7.Dispose();

            conn.Close();

            this.Hide();
            var main_f = new Member4(member_id, gym_id);
            main_f.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
