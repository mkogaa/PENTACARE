namespace PENTACARE
{
    partial class Records
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Records));
            dataGridView1 = new DataGridView();
            backBtn = new Panel();
            filterGender = new ComboBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(95, 348);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1713, 485);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // backBtn
            // 
            backBtn.BackColor = Color.Transparent;
            backBtn.Location = new Point(1627, 912);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(206, 77);
            backBtn.TabIndex = 1;
            backBtn.Click += backBtn_Click;
            // 
            // filterGender
            // 
            filterGender.DropDownStyle = ComboBoxStyle.DropDownList;
            filterGender.FormattingEnabled = true;
            filterGender.Items.AddRange(new object[] { "All", "Male", "Female", "Other" });
            filterGender.Location = new Point(1362, 266);
            filterGender.Name = "filterGender";
            filterGender.Size = new Size(296, 28);
            filterGender.TabIndex = 2;
            filterGender.SelectedIndexChanged += filterGender_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(127, 248);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search by PatientID, Name...";
            textBox1.Size = new Size(670, 40);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Records
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(textBox1);
            Controls.Add(filterGender);
            Controls.Add(backBtn);
            Controls.Add(dataGridView1);
            Name = "Records";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Records";
            WindowState = FormWindowState.Maximized;
            Load += Records_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel backBtn;
        private ComboBox filterGender;
        private TextBox textBox1;
    }
}