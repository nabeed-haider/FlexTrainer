using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class OwnerMemberReports : Form
    {
        public OwnerMemberReports()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(128, Color.Gray);
            this.SizeChanged += Form10_SizeChanged;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form7 = new OwnerMainPage();
            form7.Show();
        }
        private void Form10_SizeChanged(object sender, EventArgs e)
        {
            ResponsiveResize();
        }
        private void ResponsiveResize()
        {
            // Calculate button sizes based on the form's width and height
            int width = (int)(this.ClientSize.Width * 0.25); // Adjust as needed
            int height = (int)(this.ClientSize.Height * 0.1); // Adjust as needed

            // Set the calculated sizes to the buttons
           // panel1.Size = new Size(width * 2, height * 2);

            // Calculate the x and y coordinates for the buttons' location
            int x = (int)(this.ClientSize.Width * 0.13); // Adjust as needed
                                                         // int y = (int)(this.ClientSize.Height * 0.1);
            int y1 = (int)(this.ClientSize.Height * 0.1); // Adjust as needed
            int y2 = (int)(this.ClientSize.Height * 0.2); // Adjust as needed
            int y3 = (int)(this.ClientSize.Height * 0.3); // Adjust as needed

            // Set the locations for the buttons
            //comboBox1.Location = new Point(x, y);
          //  panel1.Location = new Point(x * 2, y1 * 2);
            

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
                string query = "SELECT m.member_Id, m.member_fname, m.member_lname, m.member_RegDate, mr.MemberShipDuration, mr.MemberShipType, mr.Goals " +
               "FROM Member1 AS m " +
               "INNER JOIN MemberReport AS mr ON m.member_Id = mr.MemberId " +
               "WHERE m.member_RegDate >= DATEADD(month, -3, GETDATE())";

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

        private void Form10_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["deleteButton"].Index && e.RowIndex >= 0)
            {
                // Prompt the user for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to remove Member from Gym?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    int id = Convert.ToInt32(selectedRow.Cells["member_id"].Value.ToString());
                    string query = "Delete from Member1 where member_id=@id";
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

        private void member1BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dBProjectDataSet3BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dBProjectDataSet2BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
