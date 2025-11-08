namespace USERS_WINDOW
{
    partial class PatientMedicalRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientMedicalRecord));
            txtBP = new TextBox();
            txtHR = new TextBox();
            txtTemp = new TextBox();
            txtAllergies = new TextBox();
            txtDN = new TextBox();
            txtDiagnosis = new TextBox();
            txtTreatment = new TextBox();
            txtMedication = new TextBox();
            txtExamFindings = new TextBox();
            txtRecordDate = new TextBox();
            txtPName = new TextBox();
            txtPID = new TextBox();
            btnClose = new Button();
            txtAge = new TextBox();
            txtContact = new TextBox();
            txtAddress = new TextBox();
            txtGender = new TextBox();
            dgvPRecord = new DataGridView();
            txtRecordNo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPRecord).BeginInit();
            SuspendLayout();
            // 
            // txtBP
            // 
            txtBP.BackColor = Color.White;
            txtBP.BorderStyle = BorderStyle.None;
            txtBP.Font = new Font("Century Gothic", 9F);
            txtBP.Location = new Point(1020, 396);
            txtBP.Name = "txtBP";
            txtBP.Size = new Size(122, 19);
            txtBP.TabIndex = 0;
            // 
            // txtHR
            // 
            txtHR.BackColor = Color.White;
            txtHR.BorderStyle = BorderStyle.None;
            txtHR.Font = new Font("Century Gothic", 9F);
            txtHR.Location = new Point(1293, 396);
            txtHR.Name = "txtHR";
            txtHR.Size = new Size(122, 19);
            txtHR.TabIndex = 1;
            // 
            // txtTemp
            // 
            txtTemp.BackColor = Color.White;
            txtTemp.BorderStyle = BorderStyle.None;
            txtTemp.Font = new Font("Century Gothic", 9F);
            txtTemp.Location = new Point(1590, 396);
            txtTemp.Name = "txtTemp";
            txtTemp.Size = new Size(122, 19);
            txtTemp.TabIndex = 2;
            // 
            // txtAllergies
            // 
            txtAllergies.BackColor = Color.White;
            txtAllergies.BorderStyle = BorderStyle.None;
            txtAllergies.Font = new Font("Century Gothic", 9F);
            txtAllergies.Location = new Point(1064, 476);
            txtAllergies.Name = "txtAllergies";
            txtAllergies.Size = new Size(696, 19);
            txtAllergies.TabIndex = 3;
            // 
            // txtDN
            // 
            txtDN.BackColor = Color.White;
            txtDN.BorderStyle = BorderStyle.None;
            txtDN.Font = new Font("Century Gothic", 9F);
            txtDN.Location = new Point(1164, 589);
            txtDN.Name = "txtDN";
            txtDN.Size = new Size(596, 19);
            txtDN.TabIndex = 4;
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.BackColor = Color.White;
            txtDiagnosis.BorderStyle = BorderStyle.None;
            txtDiagnosis.Font = new Font("Century Gothic", 9F);
            txtDiagnosis.Location = new Point(1060, 535);
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.Size = new Size(700, 19);
            txtDiagnosis.TabIndex = 5;
            // 
            // txtTreatment
            // 
            txtTreatment.BackColor = Color.White;
            txtTreatment.BorderStyle = BorderStyle.None;
            txtTreatment.Font = new Font("Century Gothic", 9F);
            txtTreatment.Location = new Point(1153, 646);
            txtTreatment.Name = "txtTreatment";
            txtTreatment.Size = new Size(607, 19);
            txtTreatment.TabIndex = 6;
            // 
            // txtMedication
            // 
            txtMedication.BackColor = Color.White;
            txtMedication.BorderStyle = BorderStyle.None;
            txtMedication.Font = new Font("Century Gothic", 9F);
            txtMedication.Location = new Point(1258, 704);
            txtMedication.Name = "txtMedication";
            txtMedication.Size = new Size(502, 19);
            txtMedication.TabIndex = 7;
            // 
            // txtExamFindings
            // 
            txtExamFindings.BackColor = Color.White;
            txtExamFindings.BorderStyle = BorderStyle.None;
            txtExamFindings.Font = new Font("Century Gothic", 9F);
            txtExamFindings.Location = new Point(1135, 759);
            txtExamFindings.Name = "txtExamFindings";
            txtExamFindings.Size = new Size(625, 19);
            txtExamFindings.TabIndex = 8;
            // 
            // txtRecordDate
            // 
            txtRecordDate.BackColor = Color.White;
            txtRecordDate.BorderStyle = BorderStyle.None;
            txtRecordDate.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtRecordDate.ForeColor = Color.Black;
            txtRecordDate.Location = new Point(303, 600);
            txtRecordDate.Name = "txtRecordDate";
            txtRecordDate.Size = new Size(281, 29);
            txtRecordDate.TabIndex = 9;
            // 
            // txtPName
            // 
            txtPName.BackColor = Color.White;
            txtPName.BorderStyle = BorderStyle.None;
            txtPName.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPName.ForeColor = Color.FromArgb(0, 22, 122);
            txtPName.Location = new Point(427, 269);
            txtPName.Name = "txtPName";
            txtPName.Size = new Size(360, 37);
            txtPName.TabIndex = 10;
            txtPName.Text = "Patient Name ";
            // 
            // txtPID
            // 
            txtPID.BackColor = Color.White;
            txtPID.BorderStyle = BorderStyle.None;
            txtPID.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPID.ForeColor = Color.Black;
            txtPID.Location = new Point(331, 312);
            txtPID.Name = "txtPID";
            txtPID.Size = new Size(122, 29);
            txtPID.TabIndex = 11;
            txtPID.Text = "1";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = SystemColors.ButtonFace;
            btnClose.Location = new Point(1657, 894);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(174, 61);
            btnClose.TabIndex = 17;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // txtAge
            // 
            txtAge.BackColor = Color.White;
            txtAge.BorderStyle = BorderStyle.None;
            txtAge.Font = new Font("Century Gothic", 13.8F);
            txtAge.ForeColor = Color.Black;
            txtAge.Location = new Point(182, 408);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(122, 29);
            txtAge.TabIndex = 18;
            txtAge.Text = "100";
            txtAge.TextChanged += txtAge_TextChanged;
            // 
            // txtContact
            // 
            txtContact.BackColor = Color.White;
            txtContact.BorderStyle = BorderStyle.None;
            txtContact.Font = new Font("Century Gothic", 13.8F);
            txtContact.ForeColor = Color.Black;
            txtContact.Location = new Point(307, 490);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(241, 29);
            txtContact.TabIndex = 19;
            txtContact.Text = "09368693028";
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.White;
            txtAddress.BorderStyle = BorderStyle.None;
            txtAddress.Font = new Font("Century Gothic", 13.8F);
            txtAddress.ForeColor = Color.Black;
            txtAddress.Location = new Point(226, 537);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(417, 29);
            txtAddress.TabIndex = 20;
            txtAddress.Text = "CAMANAVA ";
            txtAddress.TextChanged += txtAddress_TextChanged;
            // 
            // txtGender
            // 
            txtGender.BackColor = Color.White;
            txtGender.BorderStyle = BorderStyle.None;
            txtGender.Font = new Font("Century Gothic", 13.8F);
            txtGender.ForeColor = Color.Black;
            txtGender.Location = new Point(227, 451);
            txtGender.Name = "txtGender";
            txtGender.Size = new Size(122, 29);
            txtGender.TabIndex = 21;
            txtGender.Text = "Lesbian";
            // 
            // dgvPRecord
            // 
            dgvPRecord.BackgroundColor = SystemColors.ActiveCaption;
            dgvPRecord.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPRecord.GridColor = SystemColors.HotTrack;
            dgvPRecord.Location = new Point(65, 658);
            dgvPRecord.Name = "dgvPRecord";
            dgvPRecord.RowHeadersWidth = 51;
            dgvPRecord.Size = new Size(691, 202);
            dgvPRecord.TabIndex = 22;
            dgvPRecord.CellClick += dgvPRecord_CellClick;
            // 
            // txtRecordNo
            // 
            txtRecordNo.AutoSize = true;
            txtRecordNo.BackColor = Color.Transparent;
            txtRecordNo.Font = new Font("Century Gothic", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtRecordNo.ForeColor = Color.White;
            txtRecordNo.Location = new Point(1384, 246);
            txtRecordNo.Name = "txtRecordNo";
            txtRecordNo.Size = new Size(81, 59);
            txtRecordNo.TabIndex = 23;
            txtRecordNo.Text = "01";
            // 
            // PatientMedicalRecord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(txtRecordNo);
            Controls.Add(dgvPRecord);
            Controls.Add(txtGender);
            Controls.Add(txtAddress);
            Controls.Add(txtContact);
            Controls.Add(txtAge);
            Controls.Add(btnClose);
            Controls.Add(txtPID);
            Controls.Add(txtPName);
            Controls.Add(txtRecordDate);
            Controls.Add(txtExamFindings);
            Controls.Add(txtMedication);
            Controls.Add(txtTreatment);
            Controls.Add(txtDiagnosis);
            Controls.Add(txtDN);
            Controls.Add(txtAllergies);
            Controls.Add(txtTemp);
            Controls.Add(txtHR);
            Controls.Add(txtBP);
            Name = "PatientMedicalRecord";
            Text = "Form1";
            Load += PatientMedicalRecord_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPRecord).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBP;
        private TextBox txtHR;
        private TextBox txtTemp;
        private TextBox txtAllergies;
        private TextBox txtDN;
        private TextBox txtDiagnosis;
        private TextBox txtTreatment;
        private TextBox txtMedication;
        private TextBox txtExamFindings;
        private TextBox txtRecordDate;
        private TextBox txtPName;
        private TextBox txtPID;
        private Button btnClose;
        private TextBox txtAge;
        private TextBox txtContact;
        private TextBox txtAddress;
        private TextBox txtGender;
        private DataGridView dgvPRecord;
        private TextBox textBox1;
        private Label txtRecordNo;
    }
}