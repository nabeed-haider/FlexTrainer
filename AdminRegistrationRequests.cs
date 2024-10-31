using ePOSOne.btnProduct;
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

namespace WindowsFormsApp1
{
    public partial class AdminRegistrationRequests : Form
    {
        public static int temp = 0;
        public AdminRegistrationRequests()
        {
            InitializeComponent();

            this.SizeChanged += Form3_SizeChanged;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;



        }
        private void Form3_SizeChanged(object sender, EventArgs e)
        {
            ResponsiveResize();
        }
        private void ResponsiveResize()
        {
            // Calculate button sizes based on the form's width and height
            int width = (int)(this.ClientSize.Width * 0.2); // Adjust as needed
            int height = (int)(this.ClientSize.Height * 0.1); // Adjust as needed

            // Set the calculated sizes to the buttons
            //dataGridView1.Size = new Size(width * 3, height*6);

           

            // Calculate the x and y coordinates for the buttons' location
            int x = (int)(this.ClientSize.Width * 0.13); // Adjust as needed
           // int y = (int)(this.ClientSize.Height * 0.1);
            int y1 = (int)(this.ClientSize.Height * 0.2); // Adjust as needed
            int y2 = (int)(this.ClientSize.Height * 0.2); // Adjust as needed
            int y3 = (int)(this.ClientSize.Height * 0.3); // Adjust as needed

            // Set the locations for the buttons
            //comboBox1.Location = new Point(x, y);
            //dataGridView1.Location=new Point(x*2, y1);
        }                                   
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new AdminMainPage();
            form1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.DisplayRequests();
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
        }
        public void DisplayRequests()
        {
            this.registration_RequestsTableAdapter.Fill(this.dBProjectDataSet.Registration_Requests);
            using (SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False"))
            {
                string query = "Select GymName,Location,OwnerId,OwnerDetail,BusinessDetails,Facilites,Status  from Registration_Requests";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType= CommandType.Text;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["AcceptButtonColumn"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string status = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                if (status == " PENDING")
                {
                    string gymName = selectedRow.Cells["GymName"].Value.ToString();
                    string Location = selectedRow.Cells["Location"].Value.ToString();
                    int ownerid = Convert.ToInt32(selectedRow.Cells["OwnerId"].Value.ToString());
                    using (SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False"))
                    {
                        conn.Open();
                        string insertQuery = "INSERT INTO Gym (Name, Location,OwnerID) VALUES ( @gymName, @Location, @ownerid)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@gymName", gymName);
                            insertCmd.Parameters.AddWithValue("@Location", Location);
                            insertCmd.Parameters.AddWithValue("@OwnerId", ownerid);

                            insertCmd.ExecuteNonQuery();
                            string deleteQuery = "DELETE FROM Registration_Requests WHERE OwnerId = @ownerid";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                            {
                                deleteCmd.Parameters.AddWithValue("@OwnerId", ownerid);
                                deleteCmd.ExecuteNonQuery();
                            }
                            string query = "Select GymId from Gym where OwnerID=@OwnerId";
                            int id=0;
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@OwnerId", ownerid);
                                object result = cmd.ExecuteScalar();

                                // Check if the result is not null and convert it to an integer
                                if (result != null && result != DBNull.Value)
                                {
                                    id = Convert.ToInt32(result);
                                }
                            }
                            string q = "Insert into Expanses Values(@id,0,0)";
                            using (SqlCommand cmd = new SqlCommand(q, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                             dataGridView1.Rows[e.RowIndex].Cells["Status"].Value = "Accepted";
                            MessageBox.Show("Another Gym Added! :D");

                        }
                        conn.Close();
                    }
                }
                
            }
            else if (e.ColumnIndex == dataGridView1.Columns["RejectButtonColumn"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string status = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                if (status == " PENDING")
                {
                    int ownerid = Convert.ToInt32(selectedRow.Cells["OwnerId"].Value.ToString());
                    using (SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False"))
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM GymOwner WHERE OwnerId = @ownerid";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@OwnerId", ownerid);
                            deleteCmd.ExecuteNonQuery();
                        }
                        string deleteQuery2 = "DELETE FROM Registration_Requests WHERE OwnerId = @ownerid";
                        using (SqlCommand deleteCmd2 = new SqlCommand(deleteQuery2, conn))
                        {
                            deleteCmd2.Parameters.AddWithValue("@OwnerId", ownerid);
                            deleteCmd2.ExecuteNonQuery();
                        }
                       

                        dataGridView1.Rows[e.RowIndex].Cells["Status"].Value = "Rejected";
                        MessageBox.Show("Request Rejected");

                        conn.Close();
                    }
                }
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.registration_RequestsTableAdapter.FillBy(this.dBProjectDataSet.Registration_Requests);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
