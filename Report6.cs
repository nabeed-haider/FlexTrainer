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
    public partial class Report6 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");

        public Report6()
        {
            InitializeComponent();
        }

        private void Report6_Load(object sender, EventArgs e)
        {

            conn.Open();
            string query = "SELECT WorkoutPlan.Name,WorkoutPlan.Description  FROM WorkoutPlan INNER JOIN WorkoutPlan_Exercise ON WorkoutPlan_Exercise.PlanID = WorkoutPlan.PlanID INNER JOIN Exercise ON WorkoutPlan_Exericse.ExerciseID=Exercise.ExerciseID INNER JOIN Exercise_Machine ON Exercise.ExerciseID=Exercise_Machine.ExericseID INNER JOIN Machine ON Exercise_Machine.MachineID = Machine.MachineID WHERE Machine.MachineID != 3";
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
