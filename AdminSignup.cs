using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class AdminSignup : Form
    {
        public AdminSignup()
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
            label4.Font = new Font(label4.Font.FontFamily, 0.2f * height);
            label7.Font = new Font(label4.Font.FontFamily, 0.15f * height);

            textBox1.Size = new Size(width, height * 2);
            textBox2.Size = new Size(width, height * 2);
            textBox3.Size = new Size(width, height * 2);
            button1.Size=new Size(width-190, height-50);
            button2.Size = new Size(width - 260, height - 50);
            // Calculate the x and y coordinates for the buttons' location
            int x = (int)(this.ClientSize.Width * 0.16); // Adjust as needed
            int y1 = (int)(this.ClientSize.Height * 0.08); // Adjust as needed
            int y2 = (int)(this.ClientSize.Height * 0.2); // Adjust as needed
            int y3 = (int)(this.ClientSize.Height * 0.3); // Adjust as needed

            // Set the locations for the buttons
            //comboBox1.Location = new Point(x, y);
            panel1.Location = new Point(x * 2, y1 * 2);

            label1.Location = new Point(x-100, y1);
            label2.Location = new Point(x - 200, y1 * 3);
            label3.Location = new Point(x - 200, y1 * 4);
            label4.Location = new Point(x - 200, y1 * 5);
            label7.Location = new Point(x-50, y1 * 7);

            button1.Location=new Point(x, y1*6);
            button2.Location = new Point(x + 115, y1 * 7-3);
            textBox1.Location = new Point(x, y1*3);
            textBox2.Location = new Point(x, y1 * 4);
            textBox3.Location = new Point(x, y1 * 5);


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form12 = new AdminSignIn();
            form12.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            conn.Open();
            string Name = textBox1.Text;
            string Email = textBox2.Text;
            string pass = textBox3.Text;
            string query2 = "Insert into Admin values ('"+ Name + "','" + Email + "','" + pass + "')";

            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();
            conn.Close();
            MessageBox.Show("You are registered!");
            this.Hide();
            var form1 = new AdminMainPage();
            form1.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminSignup_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form13 = new OwnerSignUp();
            form13.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1=new AdminSignIn();
            form1.Show(); 
        }
    }
}
