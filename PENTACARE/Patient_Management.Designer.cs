namespace PentaCare
{
    partial class Patient_Management
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patient_Management));
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            panel1 = new Panel();
            addPatient = new Panel();
            dischargeBtn = new Panel();
            editBtn = new Panel();
            deleteBtn = new Panel();
            cmbGender = new ComboBox();
            cmbStatus = new ComboBox();
            btn_backPM = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(230, 474);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1463, 351);
            dataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(167, 224);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search by Patient Name, ID...";
            textBox1.Size = new Size(692, 36);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(1253, 355);
            panel1.Name = "panel1";
            panel1.Size = new Size(472, 60);
            panel1.TabIndex = 2;
            panel1.Click += panel1_Click;
            // 
            // addPatient
            // 
            addPatient.BackColor = Color.Transparent;
            addPatient.Location = new Point(137, 886);
            addPatient.Name = "addPatient";
            addPatient.Size = new Size(349, 76);
            addPatient.TabIndex = 3;
            addPatient.Click += addPatient_Click;
            // 
            // dischargeBtn
            // 
            dischargeBtn.BackColor = Color.Transparent;
            dischargeBtn.Location = new Point(765, 886);
            dischargeBtn.Name = "dischargeBtn";
            dischargeBtn.Size = new Size(235, 76);
            dischargeBtn.TabIndex = 4;
            dischargeBtn.Click += dischargeBtn_Click;
            // 
            // editBtn
            // 
            editBtn.BackColor = Color.Transparent;
            editBtn.Location = new Point(528, 887);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(185, 78);
            editBtn.TabIndex = 5;
            editBtn.Click += editBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.BackColor = Color.Transparent;
            deleteBtn.Location = new Point(1044, 887);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(247, 76);
            deleteBtn.TabIndex = 6;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "All", "Male", "Female" });
            cmbGender.Location = new Point(1044, 238);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(311, 36);
            cmbGender.TabIndex = 7;
            cmbGender.SelectedIndexChanged += cmbGender_SelectedIndexChanged;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "All", "Admitted", "Under Observation" });
            cmbStatus.Location = new Point(1449, 238);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(326, 36);
            cmbStatus.TabIndex = 8;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // btn_backPM
            // 
            btn_backPM.BackColor = Color.Transparent;
            btn_backPM.Location = new Point(1538, 889);
            btn_backPM.Name = "btn_backPM";
            btn_backPM.Size = new Size(247, 76);
            btn_backPM.TabIndex = 7;
            btn_backPM.Click += btn_backPM_Click;
            // 
            // Patient_Management
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_backPM);
            Controls.Add(cmbStatus);
            Controls.Add(cmbGender);
            Controls.Add(deleteBtn);
            Controls.Add(editBtn);
            Controls.Add(dischargeBtn);
            Controls.Add(addPatient);
            Controls.Add(panel1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Name = "Patient_Management";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Panel panel1;
        private Panel addPatient;
        private Panel dischargeBtn;
        private Panel editBtn;
        private Panel deleteBtn;
        private ComboBox cmbGender;
        private ComboBox cmbStatus;
        private Panel btn_backPM;
    }
}
