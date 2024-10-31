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

namespace DB_Project
{
 
    public partial class Form16 : Form
    {
        public static int trainerID;
        public static string str="";
        public static int gymID;
        public Form16(string value,int val)
        {
            InitializeComponent();
            str = value;
            gymID = val;
            getTrainerID();
        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11(str, gymID);
            this.Hide();
            f11.ShowDialog();

        }
        private void getTrainerID()
        {
            string query = "SELECT TrainerID FROM Trainer WHERE username= '" + str + "'";



            SqlConnection connection = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            SqlCommand command = new SqlCommand(query, connection);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            // Execute the query and retrieve the result as an object
            object result = command.ExecuteScalar();

            // Check if the result is not null and convert it to an integer
            if (result != null && result != DBNull.Value)
            {
                trainerID = Convert.ToInt32(result);
                // Use the trainerID value as needed
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int memberID = Convert.ToInt32(textBox1.Text);
            string query = "SELECT * FROM Sessions WHERE status=Approved AND MemberID = '" + memberID + "' TrainerID = '" + trainerID + "'";



            SqlConnection connection = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False1");
            SqlCommand command = new SqlCommand(query, connection);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            // Execute the query and retrieve the result as an object
            object result = command.ExecuteScalar();
            command.Dispose();
            // Check if the result is not null and convert it to an integer
            if (result != null && result != DBNull.Value)
            {
                string updated_status = textBox2.Text;
                query = "UPDATE DietReport WHERE MemberID = '" + memberID + "' AND TrainerID = '" + trainerID + "' SET Status = '" + updated_status + "'";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();


            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
