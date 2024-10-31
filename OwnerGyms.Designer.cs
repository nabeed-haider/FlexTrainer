namespace WindowsFormsApp1
{
    partial class OwnerGyms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OwnerGyms));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gymBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dBProjectDataSet1 = new WindowsFormsApp1.DBProjectDataSet1();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dBProjectDataSet = new WindowsFormsApp1.DBProjectDataSet();
            this.gymTableAdapter = new WindowsFormsApp1.DBProjectDataSetTableAdapters.GymTableAdapter();
            this.gym_TrainerTableAdapter = new WindowsFormsApp1.DBProjectDataSetTableAdapters.Gym_TrainerTableAdapter();
            this.gymBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.dBProjectDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gymBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gymBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gymTableAdapter1 = new WindowsFormsApp1.DBProjectDataSet1TableAdapters.GymTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBProjectDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBProjectDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBProjectDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(81, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 182);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView1.DataSource = this.gymBindingSource2;
            this.dataGridView1.Location = new System.Drawing.Point(17, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(720, 149);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Location";
            this.dataGridViewTextBoxColumn2.HeaderText = "Location";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // gymBindingSource2
            // 
            this.gymBindingSource2.DataMember = "Gym";
            this.gymBindingSource2.DataSource = this.dBProjectDataSet1;
            // 
            // dBProjectDataSet1
            // 
            this.dBProjectDataSet1.DataSetName = "DBProjectDataSet1";
            this.dBProjectDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.go_back_2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 65);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(322, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(285, 69);
            this.button1.TabIndex = 6;
            this.button1.Text = "Trainer Requests";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dBProjectDataSet
            // 
            this.dBProjectDataSet.DataSetName = "DBProjectDataSet";
            this.dBProjectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gymTableAdapter
            // 
            this.gymTableAdapter.ClearBeforeFill = true;
            // 
            // gym_TrainerTableAdapter
            // 
            this.gym_TrainerTableAdapter.ClearBeforeFill = true;
            // 
            // gymBindingSource3
            // 
            this.gymBindingSource3.DataMember = "Gym";
            this.gymBindingSource3.DataSource = this.dBProjectDataSet;
            // 
            // dBProjectDataSetBindingSource
            // 
            this.dBProjectDataSetBindingSource.DataSource = this.dBProjectDataSet;
            this.dBProjectDataSetBindingSource.Position = 0;
            // 
            // gymBindingSource
            // 
            this.gymBindingSource.DataMember = "Gym";
            this.gymBindingSource.DataSource = this.dBProjectDataSetBindingSource;
            // 
            // gymBindingSource1
            // 
            this.gymBindingSource1.DataMember = "Gym";
            this.gymBindingSource1.DataSource = this.dBProjectDataSet;
            // 
            // gymTableAdapter1
            // 
            this.gymTableAdapter1.ClearBeforeFill = true;
            // 
            // OwnerGyms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(913, 480);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "OwnerGyms";
            this.Text = "Gyms";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OwnerGyms_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBProjectDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBProjectDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBProjectDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private DBProjectDataSet dBProjectDataSet;
        private DBProjectDataSetTableAdapters.GymTableAdapter gymTableAdapter;
        private DBProjectDataSetTableAdapters.Gym_TrainerTableAdapter gym_TrainerTableAdapter;
       // private DBProjectDataSet1TableAdapters.GymTableAdapter gymTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource gymBindingSource3;
        private System.Windows.Forms.BindingSource gymBindingSource1;
        private System.Windows.Forms.BindingSource dBProjectDataSetBindingSource;
        private System.Windows.Forms.BindingSource gymBindingSource;
        private DBProjectDataSet1 dBProjectDataSet1;
        private System.Windows.Forms.BindingSource gymBindingSource2;
        private DBProjectDataSet1TableAdapters.GymTableAdapter gymTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}