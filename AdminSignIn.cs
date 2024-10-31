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
    public partial class AdminSignIn : Form
    {
        public AdminSignIn()
        {
            InitializeComponent();
            this.SizeChanged += Form11_SizeChanged;
        }
        private void Form11_SizeChanged(object sender, EventArgs e)
        {
            ResponsiveResize();
        }
        private void ResponsiveResize()
        {
            // Calculate button sizes based on the form's width and height
            int width = (int)(this.ClientSize.Width * 0.2); // Adjust as needed
            int height = (int)(this.ClientSize.Height * 0.1); // Adjust as needed

            // Set the calculated sizes to the buttons
            panel1.Size = new Size(width * 2, height * 6);
            label1.Font = new Font(label1.Font.FontFamily, 0.3f * height);
            label2.Font = new Font(label2.Font.FontFamily, 0.2f * height);
            label3.Font = new Font(label3.Font.FontFamily, 0.2f * height);
            label4.Font = new Font(label3.Font.FontFamily, 0.15f * height);

            textBox1.Size = new Size(width, height * 2);
            textBox2.Size = new Size(width, height * 2);
            button1.Size = new Size(width - 190, height - 50);
            button2.Size = new Size(width - 255, height - 50);
            // Calculate the x and y coordinates for the buttons' location
            int x = (int)(this.ClientSize.Width * 0.16); // Adjust as needed
            int y1 = (int)(this.ClientSize.Height * 0.08); // Adjust as needed
            int y2 = (int)(this.ClientSize.Height * 0.2); // Adjust as needed
            int y3 = (int)(this.ClientSize.Height * 0.3); // Adjust as needed

            // Set the locations for the buttons
            //comboBox1.Location = new Point(x, y);
            panel1.Location = new Point(x * 2, y1 * 2);

            label1.Location = new Point(x - 100, y1);
            label2.Location = new Point(x - 200, y1 * 3);
            label3.Location = new Point(x - 200, y1 * 4+50);
            label4.Location = new Point(x - 50, y1 * 7);

            button1.Location = new Point(x, y1 * 6);
            button2.Location = new Point(x + 115, y1 * 7 - 3);
            textBox1.Location = new Point(x, y1 * 3);
            textBox2.Location = new Point(x, y1 * 4+50);


        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            conn.Open();
            string Email = textBox1.Text;
            string pass = textBox2.Text;
            string query = "Select * from Admin where Email = '" + Email + "' and password = '" + pass + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Login Successfully");
                this.Hide();
                var form1 = new AdminMainPage();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Invalid information");
            }
            dr.Close();
            cmd.Dispose();
            conn.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form11 = new AdminSignup();
            form11.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AdminSignIn_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new MainPage();
            form1.Show(); 
        }
    }
}
