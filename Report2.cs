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

namespace DB_Project
{
   
    public partial class Report2 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");
        public Report2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Report2_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT member_Name,member_DOB,member_email FROM Member1 INNER JOIN DietPlan_Member ON Member1.Member_ID=DietPlan_Member.MemberID WHERE Member.GymID=1 AND DietPlan_Member.DietPlanID = 3";

            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            conn.Close();

        }
    }
}
