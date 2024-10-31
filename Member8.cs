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
    public partial class Member8 : Form
    {
        private int member_id;
        private int gym_id;
        public Member8(int m_id, int g_id)
        {
            InitializeComponent();
            member_id = m_id;
            gym_id = g_id;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var main_f = new Member4(member_id, gym_id);
            main_f.Show();
        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void label22_Click_1(object sender, EventArgs e)
        {

        }

        private void label36_Click_1(object sender, EventArgs e)
        {

        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label29_Click_1(object sender, EventArgs e)
        {

        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            conn.Open();
            string query = "select DietPlan_Name,DietPlan.DietPlan_id,Meal_type,Meal_Name,Meal_cal,Meal_fats,Meal_protein from DietPlan inner join MEAL on DietPlan.DietPlan_id=MEAL.DietPlan_id where member_id ='" + member_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);


            SqlDataAdapter dr = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            dr.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            dr.Dispose();
            ds.Dispose();


            string query2 = "select DietPlan_Name,DietPlan.DietPlan_id,DietPlan.trainer_id,Meal_type,Meal_Name,Meal_cal,Meal_fats,Meal_protein from DietPlan inner join MEAL on DietPlan.DietPlan_id=MEAL.DietPlan_id where trainer_id !='" + DBNull.Value + "'";
            SqlCommand cmd2 = new SqlCommand(query2, conn);


            SqlDataAdapter dr2 = new SqlDataAdapter(cmd2);

            DataSet ds2 = new DataSet();
            dr2.Fill(ds2);

            dataGridView2.DataSource = ds2.Tables[0];

            dr2.Dispose();
            ds2.Dispose();


            string query3 = "select DietPlan_Name,DietPlan.DietPlan_id,DietPlan.trainer_id,Meal_type,Meal_Name,Meal_cal,Meal_fats,Meal_protein from DietPlan inner join MEAL on DietPlan.DietPlan_id=MEAL.DietPlan_id where member_id !='" + member_id + "' AND  trainer_id = '" + DBNull.Value + "'";
            SqlCommand cmd3 = new SqlCommand(query3, conn);


            SqlDataAdapter dr3 = new SqlDataAdapter(cmd3);

            DataSet ds3 = new DataSet();
            dr3.Fill(ds3);

            dataGridView3.DataSource = ds3.Tables[0];

            dr3.Dispose();
            ds3.Dispose();


            string query4 = "select DietPlan2.DietPlan_id,DietPlan2.trainer_id,Meal_type,Meal_Name,Meal_cal,Meal_fats,Meal_protein from DietPlan2 inner join MEAL on DietPlan2.DietPlan_id=MEAL.DietPlan_id where member_id ='" + member_id + "'";
            SqlCommand cmd4 = new SqlCommand(query4, conn);


            SqlDataAdapter dr4 = new SqlDataAdapter(cmd4);

            DataSet ds4 = new DataSet();
            dr4.Fill(ds4);

            dataGridView4.DataSource = ds4.Tables[0];

            dr4.Dispose();
            ds4.Dispose();

            conn.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                 string trainer_id = selectedRow.Cells["trainer_id"].Value.ToString();
                string diet_id = selectedRow.Cells["DietPlan_id"].Value.ToString();


                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
                conn.Open();
                string query = " insert into DietPlan2 values('" + trainer_id + "','" + member_id + "','" + diet_id + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("plan added selected successfully.");

            }
            else
            {
                MessageBox.Show("Please select a diet plan first first.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];
                string trainer_id = selectedRow.Cells["trainer_id"].Value.ToString();
                string diet_id = selectedRow.Cells["DietPlan_id"].Value.ToString();


                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
                conn.Open();
                string query = " insert into DietPlan2 values('" + trainer_id + "','" + member_id + "','" + diet_id + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("plan added selected successfully.");

            }
            else
            {
                MessageBox.Show("Please select a diet plan first first.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string diet_id = selectedRow.Cells["DietPlan_id"].Value.ToString();



                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
                conn.Open();


                string query2 = "DELETE FROM DietPlan2 WHERE DietPlan_Id = @diet_id";
                SqlCommand cmd2 = new SqlCommand(query2, conn);

                cmd2.Parameters.AddWithValue("@diet_id", diet_id);

                cmd2.ExecuteNonQuery();
                cmd2.Dispose();


                string query1 = "DELETE FROM MEAL WHERE DietPlan_Id = @diet_id";
                SqlCommand cmd1 = new SqlCommand(query1, conn);

                cmd1.Parameters.AddWithValue("@diet_id", diet_id);

                cmd1.ExecuteNonQuery();
                cmd1.Dispose();

                string query = "DELETE FROM DietPlan WHERE DietPlan_Id = @diet_id AND member_id = @member_id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@diet_id", diet_id);
                cmd.Parameters.AddWithValue("@member_id", member_id);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("plan deleted selected successfully.");

            }
            else if (dataGridView4.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView4.SelectedRows[0];
                string diet_id = selectedRow.Cells["DietPlan_id"].Value.ToString();



                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
                conn.Open();


                string query2 = "DELETE FROM DietPlan2 WHERE DietPlan_Id = @diet_id";
                SqlCommand cmd2 = new SqlCommand(query2, conn);

                cmd2.Parameters.AddWithValue("@diet_id", diet_id);

                cmd2.ExecuteNonQuery();
                cmd2.Dispose();
                MessageBox.Show("plan deleted selected successfully.");
            }
            else
            {
                MessageBox.Show("Please select a diet plan first.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type = comboBox3.Text;

            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            conn.Open();
            string query = "select DietPlan_Name,DietPlan.DietPlan_id,Meal_type,Meal_Name,Meal_cal,Meal_fats,Meal_protein from DietPlan inner join MEAL on DietPlan.DietPlan_id=MEAL.DietPlan_id where member_id ='" + member_id + "' AND DietPlan_goal = '" + type + "'";
            SqlCommand cmd = new SqlCommand(query, conn);


            SqlDataAdapter dr = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            dr.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            dr.Dispose();
            ds.Dispose();


            string query2 = "select DietPlan_Name,DietPlan.DietPlan_id,DietPlan.trainer_id,Meal_type,Meal_Name,Meal_cal,Meal_fats,Meal_protein from DietPlan inner join MEAL on DietPlan.DietPlan_id=MEAL.DietPlan_id where trainer_id !='" + DBNull.Value + "' AND DietPlan_goal = '" + type + "'";
            SqlCommand cmd2 = new SqlCommand(query2, conn);


            SqlDataAdapter dr2 = new SqlDataAdapter(cmd2);

            DataSet ds2 = new DataSet();
            dr2.Fill(ds2);

            dataGridView2.DataSource = ds2.Tables[0];

            dr2.Dispose();
            ds2.Dispose();


            string query3 = "select DietPlan_Name,DietPlan.DietPlan_id,DietPlan.trainer_id,Meal_type,Meal_Name,Meal_cal,Meal_fats,Meal_protein from DietPlan inner join MEAL on DietPlan.DietPlan_id=MEAL.DietPlan_id where member_id !='" + member_id + "' AND DietPlan_goal = '" + type + "' AND  trainer_id = '" + DBNull.Value + "'";
            SqlCommand cmd3 = new SqlCommand(query3, conn);


            SqlDataAdapter dr3 = new SqlDataAdapter(cmd3);

            DataSet ds3 = new DataSet();
            dr3.Fill(ds3);

            dataGridView3.DataSource = ds3.Tables[0];

            dr3.Dispose();
            ds3.Dispose();


            string query4 = "select DietPlan2.DietPlan_id,DietPlan2.trainer_id,Meal_type,Meal_Name,Meal_cal,Meal_fats,Meal_protein from DietPlan2 inner join MEAL on DietPlan2.DietPlan_id=MEAL.DietPlan_id where member_id ='" + member_id + "'";
            SqlCommand cmd4 = new SqlCommand(query4, conn);


            SqlDataAdapter dr4 = new SqlDataAdapter(cmd4);

            DataSet ds4 = new DataSet();
            dr4.Fill(ds4);

            dataGridView4.DataSource = ds4.Tables[0];

            dr4.Dispose();
            ds4.Dispose();

            conn.Close();

        }
    }
}
