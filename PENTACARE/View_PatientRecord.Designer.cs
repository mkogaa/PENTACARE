namespace PENTACARE
{
    partial class View_PatientRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_PatientRecord));
            dgv_LabRec = new DataGridView();
            dgv_MedRec = new DataGridView();
            lblPID = new Label();
            lblRID = new Label();
            lblName = new Label();
            lblGender = new Label();
            lblFee = new Label();
            lblAddress = new Label();
            lblAge = new Label();
            lblRN = new Label();
            lblType = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgv_LabRec).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_MedRec).BeginInit();
            SuspendLayout();
            // 
            // dgv_LabRec
            // 
            dgv_LabRec.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_LabRec.Location = new Point(175, 407);
            dgv_LabRec.Name = "dgv_LabRec";
            dgv_LabRec.RowHeadersWidth = 51;
            dgv_LabRec.Size = new Size(1600, 127);
            dgv_LabRec.TabIndex = 0;
            dgv_LabRec.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dgv_MedRec
            // 
            dgv_MedRec.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_MedRec.Location = new Point(175, 634);
            dgv_MedRec.Name = "dgv_MedRec";
            dgv_MedRec.RowHeadersWidth = 51;
            dgv_MedRec.Size = new Size(1600, 127);
            dgv_MedRec.TabIndex = 1;
            // 
            // lblPID
            // 
            lblPID.AutoSize = true;
            lblPID.BackColor = Color.Transparent;
            lblPID.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPID.ForeColor = Color.DarkBlue;
            lblPID.Location = new Point(379, 188);
            lblPID.Name = "lblPID";
            lblPID.Size = new Size(96, 38);
            lblPID.TabIndex = 2;
            lblPID.Text = "label1";
            // 
            // lblRID
            // 
            lblRID.AutoSize = true;
            lblRID.BackColor = Color.Transparent;
            lblRID.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRID.ForeColor = Color.DarkBlue;
            lblRID.Location = new Point(1388, 188);
            lblRID.Name = "lblRID";
            lblRID.Size = new Size(96, 38);
            lblRID.TabIndex = 3;
            lblRID.Text = "label1";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.DarkBlue;
            lblName.Location = new Point(255, 258);
            lblName.Name = "lblName";
            lblName.Size = new Size(70, 28);
            lblName.TabIndex = 4;
            lblName.Text = "label1";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.BackColor = Color.Transparent;
            lblGender.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGender.ForeColor = Color.DarkBlue;
            lblGender.Location = new Point(273, 311);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(70, 28);
            lblGender.TabIndex = 5;
            lblGender.Text = "label2";
            // 
            // lblFee
            // 
            lblFee.AutoSize = true;
            lblFee.BackColor = Color.Transparent;
            lblFee.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFee.ForeColor = Color.DarkBlue;
            lblFee.Location = new Point(1626, 311);
            lblFee.Name = "lblFee";
            lblFee.Size = new Size(70, 28);
            lblFee.TabIndex = 6;
            lblFee.Text = "label3";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.BackColor = Color.Transparent;
            lblAddress.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddress.ForeColor = Color.DarkBlue;
            lblAddress.Location = new Point(744, 258);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(70, 28);
            lblAddress.TabIndex = 6;
            lblAddress.Text = "label3";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.BackColor = Color.Transparent;
            lblAge.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAge.ForeColor = Color.DarkBlue;
            lblAge.Location = new Point(665, 311);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(70, 28);
            lblAge.TabIndex = 7;
            lblAge.Text = "label5";
            // 
            // lblRN
            // 
            lblRN.AutoSize = true;
            lblRN.BackColor = Color.Transparent;
            lblRN.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRN.ForeColor = Color.DarkBlue;
            lblRN.Location = new Point(1348, 258);
            lblRN.Name = "lblRN";
            lblRN.Size = new Size(70, 28);
            lblRN.TabIndex = 6;
            lblRN.Text = "label3";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.BackColor = Color.Transparent;
            lblType.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblType.ForeColor = Color.DarkBlue;
            lblType.Location = new Point(1379, 311);
            lblType.Name = "lblType";
            lblType.Size = new Size(70, 28);
            lblType.TabIndex = 8;
            lblType.Text = "label7";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(161, 839);
            panel1.Name = "panel1";
            panel1.Size = new Size(166, 57);
            panel1.TabIndex = 9;
            panel1.Click += panel1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Location = new Point(396, 839);
            panel2.Name = "panel2";
            panel2.Size = new Size(166, 57);
            panel2.TabIndex = 10;
            panel2.Click += panel2_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Location = new Point(1626, 849);
            panel3.Name = "panel3";
            panel3.Size = new Size(166, 57);
            panel3.TabIndex = 11;
            panel3.Click += panel3_Click;
            // 
            // View_PatientRecord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblType);
            Controls.Add(lblAge);
            Controls.Add(lblAddress);
            Controls.Add(lblRN);
            Controls.Add(lblFee);
            Controls.Add(lblGender);
            Controls.Add(lblName);
            Controls.Add(lblRID);
            Controls.Add(lblPID);
            Controls.Add(dgv_MedRec);
            Controls.Add(dgv_LabRec);
            Name = "View_PatientRecord";
            Text = "View_PatientRecord";
            Load += View_PatientRecord_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_LabRec).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_MedRec).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_LabRec;
        private DataGridView dgv_MedRec;
        private Label lblPID;
        private Label lblRID;
        private Label lblName;
        private Label lblGender;
        private Label lblFee;
        private Label lblAddress;
        private Label lblAge;
        private Label lblRN;
        private Label lblType;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}