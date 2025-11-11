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
            ((System.ComponentModel.ISupportInitialize)dgv_LabRec).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_MedRec).BeginInit();
            SuspendLayout();
            // 
            // dgv_LabRec
            // 
            dgv_LabRec.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_LabRec.Location = new Point(146, 414);
            dgv_LabRec.Name = "dgv_LabRec";
            dgv_LabRec.RowHeadersWidth = 51;
            dgv_LabRec.Size = new Size(1600, 149);
            dgv_LabRec.TabIndex = 0;
            dgv_LabRec.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dgv_MedRec
            // 
            dgv_MedRec.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_MedRec.Location = new Point(146, 651);
            dgv_MedRec.Name = "dgv_MedRec";
            dgv_MedRec.RowHeadersWidth = 51;
            dgv_MedRec.Size = new Size(1600, 149);
            dgv_MedRec.TabIndex = 1;
            // 
            // lblPID
            // 
            lblPID.AutoSize = true;
            lblPID.BackColor = Color.Transparent;
            lblPID.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPID.ForeColor = Color.DarkBlue;
            lblPID.Location = new Point(379, 195);
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
            lblRID.Location = new Point(1388, 195);
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
            lblName.Location = new Point(251, 270);
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
            lblGender.Location = new Point(279, 326);
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
            lblFee.Location = new Point(1626, 326);
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
            lblAddress.Location = new Point(762, 270);
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
            lblAge.Location = new Point(680, 326);
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
            lblRN.Location = new Point(1357, 270);
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
            lblType.Location = new Point(1388, 326);
            lblType.Name = "lblType";
            lblType.Size = new Size(70, 28);
            lblType.TabIndex = 8;
            lblType.Text = "label7";
            // 
            // View_PatientRecord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
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
    }
}