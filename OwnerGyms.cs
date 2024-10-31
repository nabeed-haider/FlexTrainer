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
    public partial class OwnerGyms : Form
    {
        int ownerid {  get; set; }
        public OwnerGyms(int ownerid)
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(128, Color.Gray);
            this.SizeChanged += Form8_SizeChanged;
            this.ownerid = ownerid;
        }
        private void Form8_SizeChanged(object sender, EventArgs e)
        {
            ResponsiveResize();
        }
        private void ResponsiveResize()
        {
            // Calculate button sizes based on the form's width and height
            int width = (int)(this.ClientSize.Width * 0.15); // Adjust as needed
            int height = (int)(this.ClientSize.Height * 0.1); // Adjust as needed

            // Set the calculated sizes to the buttons
        //    panel1.Size = new Size(width*2, height * 2);


            // Calculate the x and y coordinates for the 
            int x = (int)(this.ClientSize.Width * 0.18); 
            int y1 = (int)(this.ClientSize.Height * 0.1);
            int y2 = (int)(this.ClientSize.Height * 0.15);
            int y3 = (int)(this.ClientSize.Height * 0.2);

            // Set the locations for the buttons
            //comboBox1.Location = new Point(x, y);
    //        panel1.Location = new Point(x, y1 * 2);

        }
        public void DisplayInfo()
        {
           // this.registration_RequestsTableAdapter.Fill(this.dBProjectDataSet.Registration_Requests);
            using (SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False"))
            {
                string query = "Select Name,Location from Gym where OwnerID=@ownerid";
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
        }
            private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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

        }

        private void OwnerGyms_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBProjectDataSet1.Gym' table. You can move, or remove it, as needed.
            this.gymTableAdapter1.Fill(this.dBProjectDataSet1.Gym);
            // this.gym_TrainerTableAdapter.Fill(this.dBProjectDataSet.Gym_Trainer);
            // TODO: This line of code loads data into the 'dBProjectDataSet.Gym' table. You can move, or remove it, as needed.
            //this.gymTableAdapter.Fill(this.dBProjectDataSet.Gym);

        }

        private void fKGymTrainGymID0B91BA14BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1=new OwnerTrainerRequests(ownerid);
            form1.Show();
        }
    }
}
