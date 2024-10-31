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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace DB_Project
{
    public partial class Form23 : Form
    {
        public static string str;
        public Form23(string value)
        {
            InitializeComponent();
            str = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int GymID = Convert.ToInt32(textBox1.Text);
            int trainerID;
            string query = "SELECT TrainerID FROM Trainer WHERE username='" + str + "'";

            SqlConnection connection = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            Object obj = command.ExecuteScalar();
            trainerID = Convert.ToInt32(obj);
            command.Dispose();
            query = "SELECT * FROM Gym_Trainer WHERE GymID='" + GymID + "' AND TrainerID='" + trainerID + "'";

            command = new SqlCommand(query, connection);
            obj = command.ExecuteScalar();
            command.Dispose();
            if (obj == null || obj == DBNull.Value)
            {
                int rating = 8;
                query = "INSERT INTO  Gym_Trainer VALUES ('" + GymID + "','" + trainerID + "','" + rating + "')";

                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();

            }
            Form11 f11 = new Form11(str,GymID);
            this.Hide();

            f11.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
