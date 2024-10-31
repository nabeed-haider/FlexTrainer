using GYM_MANAGEMENT;
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

namespace WindowsFormsApp1
{
    public partial class OwnerTrainerRequests : Form
    {
        int ownerid { get; set; }
        public OwnerTrainerRequests(int ownerid)
        {
            this.ownerid = ownerid;
            InitializeComponent();
        }
        private void DefineButtonColumns()
        {
            // Accept button column
            DataGridViewButtonColumn acceptButtonColumn = new DataGridViewButtonColumn();
            acceptButtonColumn.Name = "AcceptButtonColumn";
            acceptButtonColumn.HeaderText = "Accept";
            acceptButtonColumn.Text = "Accept";
            acceptButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(acceptButtonColumn);

            // Reject button column
            DataGridViewButtonColumn rejectButtonColumn = new DataGridViewButtonColumn();
            rejectButtonColumn.Name = "RejectButtonColumn";
            rejectButtonColumn.HeaderText = "Reject";
            rejectButtonColumn.Text = "Reject";
            rejectButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(rejectButtonColumn);

            DataGridViewTextBoxColumn wageColumn = new DataGridViewTextBoxColumn();
            wageColumn.HeaderText = "Wage";
            wageColumn.Name = "Wage"; 
           // wageColumn.
            dataGridView1.Columns.Add(wageColumn);

        }
        public void DisplayRequests()
        {
            // this.registration_RequestsTableAdapter.Fill(this.dBProjectDataSet.Registration_Requests);
            using (SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False"))
            {
                string query = "Select Name,TrainerID,Expierience,Specialty,Status  from Trainer_Requests";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter dr = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            dr.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }

                    }
                }
            }
            DefineButtonColumns();
            if (dataGridView1.Columns.Contains("IDColumnName"))
                dataGridView1.Columns["IDColumnName"].Visible = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["AcceptButtonColumn"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string status = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                if (status == " PENDING" && selectedRow.Cells["Wage"].Value != null)
                {
                    string Name = selectedRow.Cells["Name"].Value.ToString();
                    int trainerid = Convert.ToInt32(selectedRow.Cells["TrainerID"].Value.ToString());
                    string email = "", ph_no = "", pass = "", username = "", speciality = "", experience = "";
                    int id = 0;
                    int wage = Convert.ToInt32(selectedRow.Cells["Wage"].Value);
                    string query = "SELECT email, phoneno, password, username,specialty,experiance,ownerId FROM Trainer_Requests WHERE trainerid=@trainerid";

                    using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0LNVCRQ\\SQLEXPRESS;Initial Catalog=DBProject;Integrated Security=True;Encrypt=False"))
                    {
                        conn.Open();

                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@trainerid", trainerid);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read()) 
                                {
                                    email = reader["email"].ToString();
                                    ph_no = reader["phoneno"].ToString();
                                    pass = reader["password"].ToString();
                                    username = reader["username"].ToString();
                                    speciality = reader["specialty"].ToString();
                                    experience = reader["experience"].ToString();
                                    id= Convert.ToInt32( (reader["ownerid"].ToString()));
                                }
                                else
                                {
                                    MessageBox.Show("Invalid");
                                }
                            }
                        }
                        int gymId=0;
                        query = "Select gymId from Gym where OwnerId=@id";
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@OwnerId", id);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    gymId= Convert.ToInt32((reader["gymId"].ToString()));
                                }
                            }
                        }
                        query = "INSERT INTO TrainerReport VALUES('" + gymId + "','" + trainerid + "','" + speciality + "' ,'" + experience + "')";
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.ExecuteNonQuery();
                           // command.Dispose();
                        }
                        query = "Update Expanses Set wages=wages+@amount where gymid=@id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@amount", wage);
                            cmd.Parameters.AddWithValue("@id", gymId);

                            cmd.ExecuteNonQuery();
                        }
                        int rating = 10;
                        query = "INSERT INTO Gym_Trainer VALUES('" + gymId + "','" + trainerid + "','" + rating + "')";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                    }
                    using (SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False"))
                    {
                        conn.Open();
                        string insertQuery = "INSERT INTO Trainer (Name, Email,Password,PhoneNo,username) VALUES ( @name, @email, @pass,@ph_no,@username)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@name", Name);
                            insertCmd.Parameters.AddWithValue("@email", email);
                            insertCmd.Parameters.AddWithValue("@password", pass);
                            insertCmd.Parameters.AddWithValue("@PhoneNo", ph_no);
                            insertCmd.Parameters.AddWithValue("@username", username);

                            insertCmd.ExecuteNonQuery();
                            string deleteQuery = "DELETE FROM Trainer_Requests WHERE TrainerId = @trainerid";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                            {
                                deleteCmd.Parameters.AddWithValue("@TrainerId", trainerid);
                                deleteCmd.ExecuteNonQuery();
                            }

                            dataGridView1.Rows[e.RowIndex].Cells["Status"].Value = "Accepted";
                            MessageBox.Show("Another Trainer Added! :D");

                        }
                        conn.Close();
                    }
                }

            }
            else if (e.ColumnIndex == dataGridView1.Columns["RejectButtonColumn"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string status = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                if (status == "PENDING")
                {
                    int trainerID = Convert.ToInt32(selectedRow.Cells["TrainerID"].Value.ToString());
                   string deleteQuery = "DELETE FROM Trainer_Requests WHERE TrainerId = @trainerid";
                    using (SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False"))
                    {
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@TrainerId", trainerID);
                            deleteCmd.ExecuteNonQuery();
                        };
                        string deleteQuery2 = "DELETE FROM Trainer_Requests WHERE TrainerID = @trainerid";
                        using (SqlCommand deleteCmd2 = new SqlCommand(deleteQuery2, conn))
                        {
                            deleteCmd2.Parameters.AddWithValue("@trainerid", trainerID);
                            deleteCmd2.ExecuteNonQuery();
                        }


                        dataGridView1.Rows[e.RowIndex].Cells["Status"].Value = "Rejected";
                        MessageBox.Show("Request Rejected");

                        conn.Close();
                    }
                }
            }

        }

        private void OwnerTrainerRequests_Load(object sender, EventArgs e)
        {
            DisplayRequests();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new OwnerGyms(ownerid);
            form1.Show();
        }
    }
}
