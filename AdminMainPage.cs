using ePOSOne.btnProduct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminMainPage : Form
    {
        private PictureBox loader; // Declare a PictureBox for the loader
        private Timer resizeTimer; // Declare a Timer to handle delay

        public AdminMainPage()
        {
            InitializeComponent();
            // Attach SizeChanged event handler
            this.SizeChanged += Form1_SizeChanged;

            // Initialize loader PictureBox
            loader = new PictureBox();
            loader.Image = Properties.Resources.R; // Set the image for the loader
            loader.SizeMode = PictureBoxSizeMode.CenterImage;
            loader.Size = new Size(50, 50); // Set the size of the loader
            loader.Visible = true; // Initially hide the loader
            this.Controls.Add(loader); // Add the loader to the form

            // Initialize Timer for delay
            resizeTimer = new Timer();
            resizeTimer.Interval = 2000; // 2 seconds delay
            resizeTimer.Tick += ResizeTimer_Tick;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            loader.Visible = true; // Show the loader when resizing starts
            resizeTimer.Stop(); // Stop the timer if running
            resizeTimer.Start(); // Start the timer for delay
            ResponsiveResize();
        }

        private void ResponsiveResize()
        {
            // Calculate button sizes based on the form's width and height
            int buttonWidth = (int)(this.ClientSize.Width * 0.2); // Adjust as needed
            int buttonHeight = (int)(this.ClientSize.Height * 0.1); // Adjust as needed

            // Set the calculated sizes to the buttons
            button_WOC1.Size = new Size(buttonWidth, buttonHeight);
            button_WOC2.Size = new Size(buttonWidth, buttonHeight);
            button_WOC3.Size = new Size(buttonWidth, buttonHeight);

            button_WOC1.Font=new Font(button_WOC1.Font.FontFamily,0.17f*buttonHeight);
            button_WOC2.Font = new Font(button_WOC2.Font.FontFamily, 0.17f * buttonHeight);
            button_WOC3.Font = new Font(button_WOC3.Font.FontFamily, 0.2f * buttonHeight);

            int x = (int)(this.ClientSize.Width * 0.4); // Adjust as needed
            int y1 = (int)(this.ClientSize.Height * 0.2); // Adjust as needed
            int y2 = (int)(this.ClientSize.Height * 0.4); // Adjust as needed
            int y3 = (int)(this.ClientSize.Height * 0.6); // Adjust as needed

            // Set the locations for the buttons
            button_WOC1.Location = new Point(x, y1);
            button_WOC2.Location = new Point(x, y2);
            button_WOC3.Location = new Point(x, y3);
        }

        private void ResizeTimer_Tick(object sender, EventArgs e)
        {
            loader.Visible = false; // Hide the loader after delay
            resizeTimer.Stop(); // Stop the timer
            ResponsiveResize(); // Call ResponsiveResize after the delay
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form3 = new AdminRegistrationRequests();
            form3.Show();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new AdminGymReport();
            form2.Show();
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form7 = new OwnerMainPage();
            form7.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form11 = new AdminSignup();
            form11.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            var form1 = new MainPage();
            form1.Show();
        }
    }
}
