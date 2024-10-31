using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class AdminCustomerFeedback : Form
    {
        public AdminCustomerFeedback()
        {
            InitializeComponent();
            this.SizeChanged += Form6_SizeChanged;
        }
        private void Form6_SizeChanged(object sender, EventArgs e)
        {
            ResponsiveResize();
        }
        private void ResponsiveResize()
        {
            // Calculate button sizes based on the form's width and height
            int width = (int)(this.ClientSize.Width * 0.2); // Adjust as needed
            int height = (int)(this.ClientSize.Height * 0.1); // Adjust as needed

            // Set the calculated sizes to the buttons
            label1.Font = new Font(label1.Font.FontFamily, height-20);


            textBox1.Size = new Size(width*3, height * 2);
            textBox2.Size = new Size(width*3, height * 2);
            textBox3.Size = new Size(width * 3, height * 2);
            textBox4.Size = new Size(width * 3, height * 2);
            textBox5.Size = new Size(width * 3, height * 2);

            // Calculate the x and y coordinates for the buttons' location
            int x = (int)(this.ClientSize.Width * 0.16); // Adjust as needed
                                                         // int y = (int)(this.ClientSize.Height * 0.1);
            int y1 = (int)(this.ClientSize.Height * 0.1); // Adjust as needed
            int y2 = (int)(this.ClientSize.Height * 0.2); // Adjust as needed
            int y3 = (int)(this.ClientSize.Height * 0.3); // Adjust as needed

            // Set the locations for the buttons
            //comboBox1.Location = new Point(x, y);
            label1.Location = new Point(x*2, y1);


            textBox1.Location = new Point(x, y1*4);
            textBox2.Location = new Point(x, y1*5);
            textBox3.Location = new Point(x, y1 * 6);
            textBox4.Location = new Point(x, y1 * 7);
            textBox5.Location = new Point(x, y1 * 8);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new AdminGymReport();
            form2.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
