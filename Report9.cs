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

    public partial class Report9 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = DESKTOP-0LNVCRQ\\SQLEXPRESS; Initial Catalog = DBProject; Integrated Security = True; Encrypt = False");

        public Report9()
        {
            InitializeComponent();
        }

        private void Report9_Load(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(Member1.MemberID) FROM Member1 INNER JOIN WorkoutPlan_Member ON Member1.MemberID = WorkoutPlan_Member.MemberID INNER JOIN WorkoutPlan ON WorkoutPlan_Member.PlanID=WorkoutPlan.PlanID INNER JOIN WorkoutPlan_Exercise ON WorkoutPlan.PlanID = WorkoutPlan_Exercise.PlanID INNER JOIN Exercise ON WorkoutPlan_Exercise.ExerciseID = Exercise.ExerciseID INNER JOIN Exercise_Machine ON Exercise.ExerciseID=Exercise_Machine.ExerciseID INNER JOIN Machine ON Exercise_Machine.MachineID = Machine.MachineID GROUP BY Machine.MachineID, Member.GymID";
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
