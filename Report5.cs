using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DB_Project
{
    public partial class Report5 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");

        public Report5()
        {
            InitializeComponent();
        }

        private void Report5_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT DietPlan.Name, DietPlan.Goals FROM DietPlan INNER JOIN DietPlan_Meals ON DietPlan.DietPlanID = DietPlan_Meals.DietPlanID INNER JOIN Meal ON DietPlan_Meals.MealID=Meal.MealID WHERE Meal.Carbs < 300";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
