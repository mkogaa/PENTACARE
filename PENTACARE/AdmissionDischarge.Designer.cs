namespace PentaCare
{
    partial class AdmissionDischarge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdmissionDischarge));
            panel1 = new Panel();
            fileSystemWatcher1 = new FileSystemWatcher();
            dataGridView1 = new DataGridView();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            cmbRtype = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(1535, 873);
            panel1.Name = "panel1";
            panel1.Size = new Size(247, 75);
            panel1.TabIndex = 0;
            panel1.Click += panel1_Click;
            panel1.Paint += panel1_Paint;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(142, 476);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1639, 173);
            dataGridView1.TabIndex = 1;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // cmbRtype
            // 
            cmbRtype.FormattingEnabled = true;
            cmbRtype.Items.AddRange(new object[] { "All", "Ward ", "Semi-Private", "Private" });
            cmbRtype.Location = new Point(1095, 255);
            cmbRtype.Name = "cmbRtype";
            cmbRtype.Size = new Size(310, 28);
            cmbRtype.TabIndex = 2;
            cmbRtype.SelectedIndexChanged += cmbRtype_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(1504, 253);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(238, 27);
            dateTimePicker1.TabIndex = 3;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Location = new Point(154, 883);
            panel2.Name = "panel2";
            panel2.Size = new Size(319, 78);
            panel2.TabIndex = 6;
            panel2.Click += panel2_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Location = new Point(1504, 353);
            panel3.Name = "panel3";
            panel3.Size = new Size(196, 78);
            panel3.TabIndex = 7;
            panel3.Click += panel3_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.Location = new Point(1272, 873);
            panel4.Name = "panel4";
            panel4.Size = new Size(247, 75);
            panel4.TabIndex = 1;
            panel4.Click += panel4_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(171, 234);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search by PatientID, Patient Name...";
            textBox1.Size = new Size(510, 36);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // AdmissionDischarge
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(textBox1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(dateTimePicker1);
            Controls.Add(cmbRtype);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "AdmissionDischarge";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdmissionDischarge";
            Load += AdmissionDischarge_Load;
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private FileSystemWatcher fileSystemWatcher1;
        private DataGridView dataGridView1;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private ComboBox cmbRtype;
        private DateTimePicker dateTimePicker1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel4;
        private TextBox textBox1;
    }
}