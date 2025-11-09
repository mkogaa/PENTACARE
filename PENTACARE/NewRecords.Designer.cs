namespace USERS_WINDOW
{
    partial class NewRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewRecords));
            txtPName = new TextBox();
            txtBP = new TextBox();
            txtHR = new TextBox();
            txtTemp = new TextBox();
            txtAge = new TextBox();
            txtContact = new TextBox();
            txtAddress = new TextBox();
            txtDN = new TextBox();
            txtDiagnosis = new TextBox();
            txtTreatment = new TextBox();
            txtExamFindings = new TextBox();
            txtAllergies = new TextBox();
            txtRecordDate = new TextBox();
            btnClose = new Button();
            btnSave = new Button();
            txtGender = new ComboBox();
            txtMedication = new ComboBox();
            SuspendLayout();
            // 
            // txtPName
            // 
            txtPName.BorderStyle = BorderStyle.None;
            txtPName.Font = new Font("Century Gothic", 9F);
            txtPName.Location = new Point(378, 287);
            txtPName.Name = "txtPName";
            txtPName.Size = new Size(522, 19);
            txtPName.TabIndex = 0;
            txtPName.TextChanged += txtPName_TextChanged;
            // 
            // txtBP
            // 
            txtBP.BorderStyle = BorderStyle.None;
            txtBP.Font = new Font("Century Gothic", 9F);
            txtBP.Location = new Point(364, 465);
            txtBP.Name = "txtBP";
            txtBP.Size = new Size(422, 19);
            txtBP.TabIndex = 1;
            // 
            // txtHR
            // 
            txtHR.BorderStyle = BorderStyle.None;
            txtHR.Font = new Font("Century Gothic", 9F);
            txtHR.Location = new Point(301, 522);
            txtHR.Name = "txtHR";
            txtHR.Size = new Size(485, 19);
            txtHR.TabIndex = 2;
            // 
            // txtTemp
            // 
            txtTemp.BorderStyle = BorderStyle.None;
            txtTemp.Font = new Font("Century Gothic", 9F);
            txtTemp.Location = new Point(332, 580);
            txtTemp.Name = "txtTemp";
            txtTemp.Size = new Size(454, 19);
            txtTemp.TabIndex = 3;
            // 
            // txtAge
            // 
            txtAge.BorderStyle = BorderStyle.None;
            txtAge.Font = new Font("Century Gothic", 9F);
            txtAge.Location = new Point(223, 341);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(85, 19);
            txtAge.TabIndex = 5;
            // 
            // txtContact
            // 
            txtContact.BorderStyle = BorderStyle.None;
            txtContact.Font = new Font("Century Gothic", 9F);
            txtContact.Location = new Point(1206, 281);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(519, 19);
            txtContact.TabIndex = 6;
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.None;
            txtAddress.Font = new Font("Century Gothic", 9F);
            txtAddress.Location = new Point(1201, 327);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(519, 19);
            txtAddress.TabIndex = 7;
            // 
            // txtDN
            // 
            txtDN.BorderStyle = BorderStyle.None;
            txtDN.Font = new Font("Century Gothic", 9F);
            txtDN.Location = new Point(1144, 468);
            txtDN.Name = "txtDN";
            txtDN.Size = new Size(634, 19);
            txtDN.TabIndex = 8;
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.BorderStyle = BorderStyle.None;
            txtDiagnosis.Font = new Font("Century Gothic", 9F);
            txtDiagnosis.Location = new Point(1041, 535);
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.Size = new Size(726, 19);
            txtDiagnosis.TabIndex = 9;
            // 
            // txtTreatment
            // 
            txtTreatment.BorderStyle = BorderStyle.None;
            txtTreatment.Font = new Font("Century Gothic", 9F);
            txtTreatment.Location = new Point(1129, 587);
            txtTreatment.Name = "txtTreatment";
            txtTreatment.Size = new Size(638, 19);
            txtTreatment.TabIndex = 10;
            // 
            // txtExamFindings
            // 
            txtExamFindings.BorderStyle = BorderStyle.None;
            txtExamFindings.Font = new Font("Century Gothic", 9F);
            txtExamFindings.Location = new Point(1114, 692);
            txtExamFindings.Name = "txtExamFindings";
            txtExamFindings.Size = new Size(664, 19);
            txtExamFindings.TabIndex = 12;
            // 
            // txtAllergies
            // 
            txtAllergies.BorderStyle = BorderStyle.None;
            txtAllergies.Font = new Font("Century Gothic", 9F);
            txtAllergies.Location = new Point(281, 641);
            txtAllergies.Name = "txtAllergies";
            txtAllergies.Size = new Size(505, 19);
            txtAllergies.TabIndex = 13;
            // 
            // txtRecordDate
            // 
            txtRecordDate.BorderStyle = BorderStyle.None;
            txtRecordDate.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtRecordDate.Location = new Point(238, 876);
            txtRecordDate.Name = "txtRecordDate";
            txtRecordDate.Size = new Size(277, 21);
            txtRecordDate.TabIndex = 14;
            txtRecordDate.Text = "1";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = SystemColors.ButtonFace;
            btnClose.Location = new Point(1588, 867);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(264, 48);
            btnClose.TabIndex = 15;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = SystemColors.ButtonFace;
            btnSave.Location = new Point(1293, 867);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(250, 48);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtGender
            // 
            txtGender.DropDownStyle = ComboBoxStyle.DropDownList;
            txtGender.Font = new Font("Century Gothic", 9F);
            txtGender.FormattingEnabled = true;
            txtGender.Items.AddRange(new object[] { "Male", "Female" });
            txtGender.Location = new Point(508, 337);
            txtGender.Name = "txtGender";
            txtGender.Size = new Size(123, 28);
            txtGender.TabIndex = 17;
            txtGender.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // txtMedication
            // 
            txtMedication.DropDownStyle = ComboBoxStyle.DropDownList;
            txtMedication.FlatStyle = FlatStyle.Flat;
            txtMedication.FormattingEnabled = true;
            txtMedication.Location = new Point(1241, 635);
            txtMedication.Name = "txtMedication";
            txtMedication.Size = new Size(533, 28);
            txtMedication.TabIndex = 18;
            // 
            // NewRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(txtMedication);
            Controls.Add(txtGender);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(txtRecordDate);
            Controls.Add(txtAllergies);
            Controls.Add(txtExamFindings);
            Controls.Add(txtTreatment);
            Controls.Add(txtDiagnosis);
            Controls.Add(txtDN);
            Controls.Add(txtAddress);
            Controls.Add(txtContact);
            Controls.Add(txtAge);
            Controls.Add(txtTemp);
            Controls.Add(txtHR);
            Controls.Add(txtBP);
            Controls.Add(txtPName);
            Name = "NewRecords";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += NewRecords_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPName;
        private TextBox txtBP;
        private TextBox txtHR;
        private TextBox txtTemp;
        private TextBox txtAge;
        private TextBox txtContact;
        private TextBox txtAddress;
        private TextBox txtDN;
        private TextBox txtDiagnosis;
        private TextBox txtTreatment;
        private TextBox textBox1;
        private TextBox txtAllergies;
        private TextBox txtRecordDate;
        private Button btnClose;
        private Button btnSave;
        private ComboBox txtGender;
        private ComboBox txtMedication;
        private TextBox txtExamFindings;
    }
}