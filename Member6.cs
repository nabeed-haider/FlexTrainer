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
    public partial class Member6 : Form
    {
        private int member_id;
        private int gym_id;
        public Member6(int m_id, int g_id)
        {
            InitializeComponent();
            member_id = m_id;
            gym_id = g_id;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            var main_f = new Member4(member_id, gym_id);
            main_f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
