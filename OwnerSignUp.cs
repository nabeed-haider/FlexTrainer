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
    public partial class OwnerSignUp : Form
    {
        public OwnerSignUp()
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
            label6.Font = new Font(label4.Font.FontFamily, 0.2f * height);
            label7.Font = new Font(label4.Font.FontFamily, 0.15f * height);

            textBox1.Size = new Size(width, height * 2);
            textBox2.Size = new Size(width, height * 2);
            textBox3.Size = new Size(width, height * 2);
            textBox4.Size = new Size(width, height * 2);
            button1.Size = new Size(width - 190, height - 50);
            button2.Size = new Size(width - 260, height - 50);
            // Calculate the x and y coordinates for the buttons' location
            int x = (int)(this.ClientSize.Width * 0.16); // Adjust as needed
            int y1 = (int)(this.ClientSize.Height * 0.08); // Adjust as needed
            int y2 = (int)(this.ClientSize.Height * 0.2); // Adjust as needed
            int y3 = (int)(this.ClientSize.Height * 0.3); // Adjust as needed

            // Set the locations for the buttons
            //comboBox1.Location = new Point(x, y);
            panel1.Location = new Point(x * 2, y1 * 2);

            label1.Location = new Point(x - 100, y1);
            label2.Location = new Point(x - 200, y1 * 2);
            label3.Location = new Point(x - 200, y1 * 3);
            label4.Location = new Point(x - 200, y1 * 4);
            label6.Location = new Point(x - 200, y1 * 5);
            label7.Location = new Point(x - 50, y1 * 7);

            button1.Location = new Point(x, y1 * 6);
            button2.Location = new Point(x + 115, y1 * 7 - 3);
            textBox1.Location = new Point(x, y1 * 2);
            textBox2.Location = new Point(x, y1 * 3);
            textBox3.Location = new Point(x, y1 * 4);
            textBox4.Location = new Point(x, y1 * 5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            conn.Open();
            string Name = textBox1.Text;
            string Email = textBox2.Text;
            string pass = textBox3.Text;
            string phoneno = textBox4.Text;
            string query1 = "Select max(OwnerId) as max_id from GymOwner";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            object result = cmd1.ExecuteScalar();
            int maxid = result != DBNull.Value ? Convert.ToInt32(result) : 1;

            this.Hide();
            var form15 = new OwnerGymInfo(maxid,Name,Email,pass,phoneno);
            form15.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form14 = new OwnerSignIn();
            form14.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OwnerSignUp_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new OwnerSignIn();
            form1.Show();   
        }
    }
}
