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
using WindowsFormsApp1;

namespace DB_Project
{
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            this.Hide();
            f7.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f1 = new MainPage();
            this.Hide();
            f1.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = name_text.Text;
            string email = email_text.Text;
            string username = username_text.Text;
            string password = password_text.Text;
            string phoneNo = phoneno_text.Text;
            int gymID = Convert.ToInt32(gymid_text.Text);
           // string query = "INSERT INTO Trainer VALUES ('" + name + "','" + email + "','" + password + "','" + phoneNo + "','" + username + "')";
            SqlConnection connection = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            connection.Open();
           // SqlCommand command = new SqlCommand(query, connection);
           
          //  command.ExecuteNonQuery();
           // command.Dispose();
           string  query = "SELECT Name FROM Gym WHERE GymID = @GymID";

            // Create a SqlCommand object with the query and connection
            SqlCommand command = new SqlCommand(query, connection);
            
                // Add a parameter for the GymID value
                command.Parameters.AddWithValue("@GymID", gymID);

                // Open the connection if it's not already open
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                // Execute the SELECT query and retrieve the Gym name
                object result = command.ExecuteScalar();
            string gymName = "";
                // Check if the result is not null and store the name in a variable
                if (result != null && result != DBNull.Value)
                {
                     gymName= result.ToString();
                    // Use the gymName variable as needed
                    Console.WriteLine("Gym Name: " + gymName);
                command.Dispose();
                query = "SELECT OwnerID FROM Gym WHERE GymID = @GymID";

                // Create a SqlCommand object with the query and connection
                command = new SqlCommand(query, connection);
                
                    // Add a parameter for the GymID value
                    command.Parameters.AddWithValue("@GymID", gymID);

                    // Open the connection if it's not already open
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    // Execute the SELECT query and retrieve the Gym name
                    object result1 = command.ExecuteScalar();
                int ownerID = 0;
                    // Check if the result is not null and store the name in a variable
                    if (result1 != null && result1 != DBNull.Value)
                    {
                    ownerID = Convert.ToInt32(result1);
                    // Use the gymName variable as needed
                    command.Dispose();

                    query = "SELECT MAX(TrainerID) FROM Trainer";

                    command = new SqlCommand(query, connection);
                    //command.ExecuteNonQuery();
                    object result2 = command.ExecuteScalar();
                    int TrainerID = result != DBNull.Value ? Convert.ToInt32(result2) : 1;

                    command.Dispose();
                    
                    string status = " pending";
                    string Expierience=textBox1.Text;
                    string speciality=textBox2.Text;
                    query = "INSERT INTO Trainer_Requests (Name, email, Password, PhoneNo, username, Expierience, Specialty, Status, TrainerID, ownerId) " +
               "VALUES ('" + name + "', '" + email + "', '" + password + "', '" + phoneNo + "', '" + username + "', '" + Expierience + "', '" + speciality + "', '" + status + "', '" + TrainerID + "', '" + ownerID + "')";
                    command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                      
                    MessageBox.Show("Wait for approval. :)");
                    Form7 f7 = new Form7();
                    this.Hide();

                    f7.ShowDialog();
                    }
                    else

                {

                }
                }
            
                else
                {
                    // Handle case where GymID is not found or result is null
                    Console.WriteLine("Gym not found.");
                }
            
        }

        private void Form22_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void phoneno_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
