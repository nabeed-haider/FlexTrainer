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

namespace DB_Project
{
    
    public partial class Form19 : Form
    {
        
        public static string str = "";
        public static int temp = 0;
        public static int trainerID = 0;
        private DataGridView dataGridView1;
        public static int GymID;
        public Form19(string value, int val)
        {
            InitializeComponent();
            str = value;
            GymID = val;
            getTrainerID();
            dataGridView1 = new DataGridView();
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Dock = DockStyle.Fill; // Adjust docking as needed
            Controls.Add(dataGridView1); // Add DataGridView to form's controls
            DisplayPendingAppointments();


        }
        private void getTrainerID() {
            string query = "SELECT TrainerID FROM Trainer WHERE username= '" + str + "'";



            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-S46R54P\\SQLEXPRESS;Initial Catalog=DataBaseProject;Integrated Security=True");
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
        private void button5_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12(str,GymID);
            this.Hide();
            f12.ShowDialog();
        }

        private void Form19_Load(object sender, EventArgs e)
        {

        }
        private void DisplayPendingAppointments()
        {
            string query = "SELECT TrainerID,SessionID,Member.Name FROM Sessions INNER JOIN Member ON Member.MemberID = Sessions.MemberID WHERE Status = 'Pending' AND TrainerID = '" + trainerID + "' AND GymID = '" + GymID + "'";

            
            
             SqlConnection connection = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
            
            // Bind data to DataGridView
            
                dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = true;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.RowHeadersVisible =true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // Add button column for approval
            if (temp == 0)
            {
                DataGridViewButtonColumn approveButtonColumn = new DataGridViewButtonColumn();
                approveButtonColumn.Name = "Approve";
                approveButtonColumn.Text = "Approve";
                approveButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(approveButtonColumn);

                // Handle button click event
                dataGridView1.CellContentClick += dataGridView1_CellContentClick;

                DataGridViewButtonColumn disapproveButtonColumn = new DataGridViewButtonColumn();
                disapproveButtonColumn.Name = "Disapprove";
                disapproveButtonColumn.Text = "Disapprove";
                disapproveButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(disapproveButtonColumn);

                // Handle button click event
                dataGridView1.CellContentClick += dataGridView1_CellContentClick1;
                temp++;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Approve"].Index)
            {
                int appointmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["SessionID"].Value);
                // Perform approval action for appointmentID
                ApproveAppointment(appointmentID);
            }
        }
        private void dataGridView1_CellContentClick1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Disapprove"].Index)
            {
                int appointmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["SessionID"].Value);
                // Perform approval action for appointmentID
                DisapproveAppointment(appointmentID);
            }
        }
        private void ApproveAppointment(int appointmentID)
        {
            // Write code to update the appointment status to "Approved" in your database
            using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False"))
            {
                string updateQuery = "UPDATE Sessions SET Status = 'Approved' WHERE SessionID = @AppointmentID";

                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@AppointmentID", appointmentID);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Session approved successfully.");
                    DisplayPendingAppointments();
                }
                else
                {
                    MessageBox.Show("Failed to approve session.");
                }
            }
        }


        private void DisapproveAppointment(int appointmentID)
        {
            // Write code to update the appointment status to "Approved" in your database
            using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False"))
            {
                string updateQuery = "UPDATE Sessions SET Status = 'Disapproved' WHERE SessionID = @AppointmentID";

                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@AppointmentID", appointmentID);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Session disapproved successfully.");
                    DisplayPendingAppointments();
                }
                else
                {
                    MessageBox.Show("Failed to disapprove session.");
                }
            }
        }
    }

    }

