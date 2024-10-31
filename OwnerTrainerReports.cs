using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class OwnerTrainerReports : Form
    {
        public OwnerTrainerReports()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(128, Color.Gray);
            this.SizeChanged += Form9_SizeChanged;
        }
        private void Form9_SizeChanged(object sender, EventArgs e)
        {
            ResponsiveResize();
        }
        private void ResponsiveResize()
        {
            // Calculate button sizes based on the form's width and height
            int width = (int)(this.ClientSize.Width * 0.25); // Adjust as needed
            int height = (int)(this.ClientSize.Height * 0.1); // Adjust as needed

            // Set the calculated sizes to the buttons
            panel1.Size = new Size(width * 2, height * 2);
            


            // Calculate the x and y coordinates for the buttons' location
            int x = (int)(this.ClientSize.Width * 0.13); // Adjust as needed
                                                         // int y = (int)(this.ClientSize.Height * 0.1);
            int y1 = (int)(this.ClientSize.Height * 0.1); // Adjust as needed
            int y2 = (int)(this.ClientSize.Height * 0.2); // Adjust as needed
            int y3 = (int)(this.ClientSize.Height * 0.3); // Adjust as needed

            // Set the locations for the buttons
            //comboBox1.Location = new Point(x, y);
            panel1.Location = new Point(x * 2, y1 * 2);

          


        }
        private void DefineButtonColumns()
        {
            // Accept button column
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "Delete";
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteButton);
        }
         public void DisplayInfo()
        {
            try
            {
                string query = "SELECT t.Name, t.phoneno, tr.Expierience, tr.Speciality " +
                               "FROM Trainer AS t " +
                               "INNER JOIN TrainerReport AS tr ON t.TrainerId = tr.TrainerId";

                // Create a new SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False"))
                {
                    // Create a new SqlDataAdapter with the SQL query and connection
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
                DefineButtonColumns();
                if (dataGridView1.Columns.Contains("IDColumnName"))
                    dataGridView1.Columns["IDColumnName"].Visible = false;
            }
            catch (Exception ex) { MessageBox.Show("An error occurred: " + ex.Message); }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form7 = new OwnerMainPage();
            form7.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["deleteButton"].Index && e.RowIndex >= 0)
            {
                // Prompt the user for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to remove Trainer from Gym?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    int trainerid = Convert.ToInt32(selectedRow.Cells["TrainerID"].Value.ToString());
                    string query = "Delete from Trainer where TrainerId=@trainerid";
                    using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0LNVCRQ\\SQLEXPRESS;Initial Catalog=DBProject;Integrated Security=True;Encrypt=False"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }   

                }
            }
        }

        private void OwnerTrainerReports_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }
    }
}
