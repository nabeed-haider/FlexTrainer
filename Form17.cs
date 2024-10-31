﻿using System;
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

namespace DB_Project
{
    public partial class Form17 : Form
    {
        public static int temp = 0;
        private DataGridView dataGridView1;
        public static string str = "";
        public static int GymID;
        public static int trainer_ID = 0;
        public Form17(string value,int val)
        {
            InitializeComponent();
            str = value;
            GymID= val;
            getTrainerID();
            dataGridView1 = new DataGridView();
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Dock = DockStyle.Fill; // Adjust docking as needed
            Controls.Add(dataGridView1); // Add DataGridView to form's controls
            DisplayCompletedAppointments();
        }

        private void Form17_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11(str,GymID);
            this.Hide();
            f11.ShowDialog();

        }
        private void getTrainerID()
        {
            string query = "SELECT TrainerID FROM Trainer WHERE username = '" + str + "'";




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
                trainer_ID = Convert.ToInt32(result);
                // Use the trainerID value as needed
            }
        }
        private void DisplayCompletedAppointments()
        {
            string query = "SELECT TrainerID,SessionID,Member.Name,Sessions.Feedback FROM Sessions INNER JOIN Member ON Member.MemberID = Sessions.MemberID WHERE Status = 'Disapproved' AND TrainerID ='" + trainer_ID + "' AND GymID = '" + GymID + "'";
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
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // Add button column for approval
            if (temp == 0)
            {
                DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
                removeButtonColumn.Name = "Acknowledge";
                removeButtonColumn.Text = "Acknowledge";
                removeButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(removeButtonColumn);

                // Handle button click event
                dataGridView1.CellContentClick += dataGridView1_CellContentClick;

                temp++;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Remove"].Index)
            {
                int appointmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["SessionID"].Value);
                // Perform approval action for appointmentID
                RemoveAppointment(appointmentID);
            }
        }
        private void RemoveAppointment(int appointmentID)
        {
            // Write code to update the appointment status to "Approved" in your database
            using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False"))
            {
                string updateQuery = "DELETE Sessions WHERE SessionID = @AppointmentID";

                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@AppointmentID", appointmentID);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Session removed successfully.");
                    DisplayCompletedAppointments();
                }
                else
                {
                    MessageBox.Show("Failed to remove session.");
                }
            }
        }
    }
}
