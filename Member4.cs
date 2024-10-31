using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM_MANAGEMENT
{
    public partial class Member4 : Form
    {
        private int member_id;
        private int gym_id;
        public Member4(int m_id,int g_id)
        {
            InitializeComponent();
            menuStrip1.Dock = DockStyle.Left;
            member_id = m_id;
            gym_id = g_id;  
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //menuStrip1.Dock = DockStyle.Left;
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var prf = new profile(member_id, gym_id);
            prf.Show();
        }

        private void workoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void workoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var select_workout = new Member6(member_id, gym_id);
            select_workout.Show();
        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void uUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var workout_report = new workout_Report(member_id, gym_id);
            workout_report.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var create_workout = new Mrmber5(member_id,gym_id);
            create_workout.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var select_workout = new Member6(member_id, gym_id);
            select_workout.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
          
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
          
            

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            var create_diet = new Member7(member_id, gym_id);
            create_diet.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            var select_diet = new Member8(member_id, gym_id);
            select_diet.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var select_diet = new Member8(member_id, gym_id);
            select_diet.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var workout_report = new workout_Report(member_id, gym_id);
            workout_report.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            var diet_report = new Diet_report(member_id, gym_id);
            diet_report.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var diet_report = new Diet_report(member_id, gym_id);
            diet_report.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fedbck = new Feedback(member_id, gym_id);
            fedbck.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fedbck = new Feedback(member_id, gym_id);
            fedbck.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            this.Hide();
            var session = new book_session(member_id, gym_id," ",0);
            session.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var session = new book_session(member_id, gym_id," ", 0);
            session.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var trainer = new trainers(member_id, gym_id);
            trainer.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
