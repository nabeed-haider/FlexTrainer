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
    public partial class OwnerMainPage : Form
    {
        int ownerid {  get; set; }
        public OwnerMainPage(int ownerid=0)
        {
            this.ownerid = ownerid;
            InitializeComponent();
            this.SizeChanged += Form7_SizeChanged;
        }
        private void Form7_SizeChanged(object sender, EventArgs e)
        {
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
            button_WOC4.Size = new Size(buttonWidth, buttonHeight);

            button_WOC1.Font = new Font(button_WOC1.Font.FontFamily, 0.2f * buttonHeight);
            button_WOC2.Font = new Font(button_WOC2.Font.FontFamily, 0.15f * buttonHeight);
            button_WOC3.Font = new Font(button_WOC3.Font.FontFamily, 0.15f * buttonHeight);
            button_WOC4.Font = new Font(button_WOC3.Font.FontFamily, 0.2f * buttonHeight);

            // Calculate the x and y coordinates for the buttons' location
            int x = (int)(this.ClientSize.Width * 0.4); // Adjust as needed
            int y1 = (int)(this.ClientSize.Height * 0.2); // Adjust as needed
            int y2 = (int)(this.ClientSize.Height * 0.4); // Adjust as needed
            int y3 = (int)(this.ClientSize.Height * 0.6); // Adjust as needed
            int y4 = (int)(this.ClientSize.Height * 0.8);

            // Set the locations for the buttons
            button_WOC1.Location = new Point(x, y1);
            button_WOC2.Location = new Point(x, y2);
            button_WOC3.Location = new Point(x, y3);
            button_WOC4.Location = new Point(x, y4);
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form8 = new OwnerGyms(ownerid);
            form8.Show();
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form9 = new OwnerTrainerReports();
            form9.Show();
        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form10 = new OwnerMemberReports();
            form10.Show();
        }

        private void button_WOC4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OwnerMainPage_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new MainPage();
            form1.Show();
        }

        private void button_WOC5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Reports();
            form1.Show();
        }
    }
    

}
