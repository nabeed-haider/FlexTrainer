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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GYM_MANAGEMENT
{
    public partial class trainers : Form
    {
        private int member_id;
        private int gym_id;
        public trainers(int m_id, int g_id)
        {
            InitializeComponent();
            member_id = m_id;
            gym_id = g_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var main_frm = new Member4(member_id, gym_id);
            main_frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string name = selectedRow.Cells["name"].Value.ToString();
                string id = selectedRow.Cells["TrainerID"].Value.ToString();

                int intValue = int.Parse(id);

                this.Hide();
                var session = new book_session(member_id, gym_id,name, intValue);
                session.Show();

            }
            else
            {
                MessageBox.Show("Please select a trainer first.");
            }
        }

        private void trainers_Load(object sender, EventArgs e)
        {
            
            
        }

        private void trainers_Load_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
            conn.Open();
            string query = "Select trainerid,name,email,phoneno from trainer";
            SqlCommand cmd = new SqlCommand(query, conn);


            SqlDataAdapter dr = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            dr.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
