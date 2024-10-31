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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApp1
{
    public partial class OwnerGymInfo : Form
    {
        string name { get; set; }
        string email { get; set; }
        string password { get; set; }
        string ph_no { get; set; }
        int id { get; set; }
        public OwnerGymInfo(int id=1,string name="", string email = "", string password = "", string phoneNumber = "")
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
            ph_no= phoneNumber;
            InitializeComponent();
            this.SizeChanged += Form11_SizeChanged;
        }
        private void Form11_SizeChanged(object sender, EventArgs e)
        {
            ResponsiveResize();
        }
        private void ResponsiveResize()
        {
            int width = (int)(this.ClientSize.Width * 0.2); // Adjust as needed
            int height = (int)(this.ClientSize.Height * 0.1); // Adjust as needed

            panel1.Size = new Size(width * 2, height * 6);
            label1.Font = new Font(label1.Font.FontFamily, 0.3f * height);
            label2.Font = new Font(label2.Font.FontFamily, 0.2f * height);
            label3.Font = new Font(label3.Font.FontFamily, 0.2f * height);
            label4.Font = new Font(label4.Font.FontFamily, 0.2f * height);
            label6.Font = new Font(label4.Font.FontFamily, 0.2f * height);

            textBox1.Size = new Size(width, height * 2);
            textBox2.Size = new Size(width, height * 2);
            textBox3.Size = new Size(width, height * 2);
            textBox4.Size = new Size(width, height * 2);
            button1.Size = new Size(width - 190, height - 50);
            button2.Size = new Size(width - 190, height - 50);

            int x = (int)(this.ClientSize.Width * 0.16); // Adjust as needed
            int y1 = (int)(this.ClientSize.Height * 0.08); // Adjust as needed
            int y2 = (int)(this.ClientSize.Height * 0.2); // Adjust as needed
            int y3 = (int)(this.ClientSize.Height * 0.3); // Adjust as needed

            // Set the locations for the buttons
            //comboBox1.Location = new Point(x, y);
            panel1.Location = new Point(x * 2, y1 * 2);

            label1.Location = new Point(x - 50, y1);
            label2.Location = new Point(x - 200, y1 * 3);
            label3.Location = new Point(x - 200, y1 * 4);
            label4.Location = new Point(x - 200, y1 * 5);
            label6.Location = new Point(x - 200, y1 * 6);
            //label7.Location = new Point(x - 50, y1 * 7);

            button1.Location = new Point(x-100, y1 * 7);
            button2.Location = new Point(x+100 , y1 * 7);
            textBox1.Location = new Point(x, y1 * 3);
            textBox2.Location = new Point(x, y1 * 4);
            textBox3.Location = new Point(x, y1 * 5);
            textBox4.Location = new Point(x, y1 * 6);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            conn.Open();
            string GymName = textBox1.Text;
            string Location = textBox2.Text;
            string BuisnessDetails = textBox3.Text;
            string Facilities = textBox4.Text;
            string query1 = "Select max(RequestID) as max_id from Registration_Requests";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            object result = cmd1.ExecuteScalar();
            int ReqId = result != DBNull.Value ? Convert.ToInt32(result) : 1;
            string query2 = "Insert into GymOwner values ('" + name + "','" + email + "','" + password + "')";
            string query3 = "Insert into Registration_Requests values ('" + GymName + "','" + Location + "','"+ name +"' ,'" + BuisnessDetails +"','" + Facilities + "',' PENDING','"+ id +"')";

            SqlCommand cmd2 = new SqlCommand(query2, conn);
            SqlCommand cmd3 = new SqlCommand(query3, conn);
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            cmd2.Dispose();
            cmd3.Dispose();
            cmd1.Dispose();
            conn.Close();
            MessageBox.Show("Please wait for Admin's approval. :)");
            //this.Hide();
            //var form12 = new OwnerMainPage();
            //form12.Show();
        }

        private void OwnerGymInfo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form12 = new OwnerSignUp();
            form12.Show();
        }
    }
}
