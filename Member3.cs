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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GYM_MANAGEMENT
{
    public partial class Member3 : Form
    {
        private string FName;
        private string LName;
        private string Email;
        private string Adrs;
        private string gender;
        private string goal;
        private string dob;
        private string height;
        private string weight;
        private string gymid;
        private string mem;
        private string dur;
        public Member3(string FN, string LN,string mail,string Adr,string gen,string gl,string db,string hght,string weght,string gym_id,string m,string d)
        {
            InitializeComponent();
            FName = FN;
            LName = LN;
            Email = mail;
            Adrs = Adr;
            gender = gen;
            goal = gl;
            dob = db;
            height = hght;
            weight = weght;
            gymid = gym_id;
            mem = m;
            dur = d;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
           // var form2 = new Form2();
            //form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            conn.Open();

                string Username = textBox3.Text;
                string Password = textBox4.Text;
                string Password2 = textBox7.Text;

                if (Password != Password2)
                {
                MessageBox.Show("Password not same");
                }
                else if (Password == Password2)
                {
                MessageBox.Show("Password same");

                DateTime date1 = DateTime.Parse(dob);
                DateTime today = DateTime.Today;
                string query = "INSERT INTO Member1 (member_FName, member_LName, member_Email, member_password, member_Username, member_DoB, member_RegDate, member_Height, member_Weight, member_Gender, member_Goal, GymId) " +
                   "VALUES (@FName, @LName, @Email, @Password, @Username, @DOB, @RegDate, @Height, @Weight, @Gender, @Goal, @GymId);" +
                   "SELECT SCOPE_IDENTITY();";

                

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FName", FName);
                cmd.Parameters.AddWithValue("@LName", LName);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@DOB", date1);
                cmd.Parameters.AddWithValue("@RegDate", today);
                cmd.Parameters.AddWithValue("@Height", height);
                cmd.Parameters.AddWithValue("@Weight", weight);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Goal", goal);
                cmd.Parameters.AddWithValue("@GymId", gymid);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                int id2 = Convert.ToInt32(gymid);
                string query2 = "INSERT INTO MemberReport (MemberId, GymId, MemberShipDuration, MemberShipType, Goals) " +
                                "VALUES (@id, @id2, @mem, @dur, @Goal)";

                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@id", id); 
                cmd2.Parameters.AddWithValue("@id2", id2);
                cmd2.Parameters.AddWithValue("@mem", mem);
                cmd2.Parameters.AddWithValue("@dur", dur);
                cmd2.Parameters.AddWithValue("@Goal", goal);
           //     cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();
               // conn.Close();

               

                int amount = 0;
                if(mem=="Standard")
                {
                    amount = 5000;
                }
                else if(mem=="Gold")
                {
                    amount = 10000;
                }
                else
                {
                    amount = 20000;
                }
                string query4 = "Update Expanses Set membership=membership+@amount where gymid=@id";
                using (SqlCommand cmd4 = new SqlCommand(query4, conn))
                {
                    cmd4.Parameters.AddWithValue("@amount", amount);
                    cmd4.Parameters.AddWithValue("@id", id2);

                    cmd4.ExecuteNonQuery();
                }
                conn.Close();
                this.Hide();
                var form1 = new Member1();
                form1.Show();

            }





            /*this.Hide();
            var form1 = new Form1();
            form1.Show();*/
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
