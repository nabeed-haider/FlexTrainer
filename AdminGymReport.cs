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

namespace WindowsFormsApp1
{
    public partial class AdminGymReport : Form
    {
        private string gym = "";
        public AdminGymReport()
        {
            InitializeComponent();
            this.SizeChanged += Form2_SizeChanged;
        }
        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            ResponsiveResize();
        }
        private void ResponsiveResize()
        {
            // Calculate button sizes based on the form's width and height
            int buttonWidth = (int)(this.ClientSize.Width * 0.2); // Adjust as needed
            int buttonHeight = (int)(this.ClientSize.Height * 0.1); // Adjust as needed

            // Set the calculated sizes to the buttons
            comboBox1.Size = new Size(buttonWidth, buttonHeight);
            
            comboBox1.Font = new Font(comboBox1.Font.FontFamily, 0.15f * buttonHeight);

            // Calculate the x and y coordinates for the buttons' location
            int x = (int)(this.ClientSize.Width * 0.4); // Adjust as needed
            int y = (int)(this.ClientSize.Height * 0.1);
            int y1 = (int)(this.ClientSize.Height * 0.3); // Adjust as needed
            int y2 = (int)(this.ClientSize.Height * 0.5); // Adjust as needed
            int y3 = (int)(this.ClientSize.Height * 0.7); // Adjust as needed

            // Set the locations for the buttons
            comboBox1.Location = new Point(x, y);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==-1)
            {
                MessageBox.Show("Please select a gym");
                return;
            }
             gym=comboBox1.Text;

            string q = "Select gymid from gym where name=@gym ";
            int id;
            using (SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@gym", gym);
                    id = (int)cmd.ExecuteScalar();
                }
            }


            int newMembersCount, expiredMemberCount;
            decimal a1=0,a2=0;
            string query = "Select count(*) As newMembers from member1 WHERE member_RegDate >= DATEADD(month, -3, GETDATE()) AND gymid=@id";
            string query2 = "Select count(*) As expiredMembers from member1 WHERE member_RegDate <= DATEADD(month, -3, GETDATE()) AND gymid=@id";
            using (SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    newMembersCount = (int)cmd.ExecuteScalar();
                }
                using (SqlCommand cmd2 = new SqlCommand(query2, conn))
                {
                    cmd2.Parameters.AddWithValue("@id", id);
                    expiredMemberCount = (int)cmd2.ExecuteScalar();
                }
                string query3 = "Select membership,wages from Expanses where gymid=@id";
                using (SqlCommand cmd3 = new SqlCommand(query3, conn))
                {
                    cmd3.Parameters.AddWithValue("@id", id);
                   // conn.Open();
                    using (SqlDataReader reader = cmd3.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            a1 = Convert.ToDecimal(reader["membership"]);
                            a2 = Convert.ToDecimal(reader["wages"]);
                        }
                    }
                }
            }

            int total = newMembersCount + expiredMemberCount;
            if (total > 0)
            {
                int final = (newMembersCount - expiredMemberCount) / total * 100;
                textBox2.Text= final.ToString();
            }
            decimal total2 = a1 - a2;
            textBox1.Text = total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new AdminMainPage();
            form1.Show();
        }

  

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form6 = new AdminCustomerFeedback();
            form6.Show();
        }

        private void AdminGymReport_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            string query = "Select Name from Gym";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader= cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));
                }
            }
            conn.Dispose();
        }

        private void button_WOC4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to remove Gym from company?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False"))
                {
                    conn.Open ();
                    string query = "Delete from Gym where Name =@gym";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@gym", gym);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Gym has been removed");
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           


        }
    }
}
