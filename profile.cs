using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;


namespace GYM_MANAGEMENT
{
    public partial class profile : Form
    {
        private int member_id;
        private int gym_id;
        public profile(int m_id, int g_id)
        {
            InitializeComponent();
            this.Paint += panel1_Paint;
            member_id = m_id;
            gym_id = g_id;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        /*int centerX = 100; // X-coordinate of the center of the circle
            int centerY = 100; // Y-coordinate of the center of the circle
            int radius = 50;

            Graphics graphics = e.Graphics;

            // Set the drawing color and thickness
            Pen pen = new Pen(Color.Black, 5);

            // Draw the circle
            graphics.DrawEllipse(pen, centerX - radius, centerY - radius, 2 * radius, 2 * radius);


            Image image = Image.FromFile("C:\\Users\\admin\\Desktop\\abc.jpg");
            int imageWidth = Math.Min(radius * 2, image.Width); // Adjust the image width to fit inside the circle
            int imageHeight = Math.Min(radius * 2, image.Height); // Adjust the image height to fit inside the circle
            int imageX = centerX - imageWidth / 2; // X-coordinate of the upper-left corner of the image
            int imageY = centerY - imageHeight / 2;

            graphics.DrawImage(image, imageX, imageY, imageWidth, imageHeight);*/
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new MainPage();
            form.Show();
        }

        private void profile_Load(object sender, EventArgs e)
        {

        }
    }
}
