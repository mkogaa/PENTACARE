namespace PentaCare
{
    partial class AddPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPatient));
            pName = new TextBox();
            pAge = new TextBox();
            pCon = new TextBox();
            diagnosis = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            pGender = new ComboBox();
            btnSave = new Panel();
            pAddress = new TextBox();
            panel1 = new Panel();
            pStatus = new ComboBox();
            SuspendLayout();
            // 
            // pName
            // 
            pName.BorderStyle = BorderStyle.None;
            pName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pName.Location = new Point(469, 326);
            pName.Name = "pName";
            pName.Size = new Size(1133, 27);
            pName.TabIndex = 0;
            // 
            // pAge
            // 
            pAge.BorderStyle = BorderStyle.None;
            pAge.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pAge.Location = new Point(460, 393);
            pAge.Name = "pAge";
            pAge.Size = new Size(206, 27);
            pAge.TabIndex = 1;
            // 
            // pCon
            // 
            pCon.BorderStyle = BorderStyle.None;
            pCon.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pCon.Location = new Point(1222, 462);
            pCon.Name = "pCon";
            pCon.Size = new Size(380, 27);
            pCon.TabIndex = 2;
            // 
            // diagnosis
            // 
            diagnosis.BorderStyle = BorderStyle.None;
            diagnosis.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            diagnosis.Location = new Point(519, 600);
            diagnosis.Name = "diagnosis";
            diagnosis.Size = new Size(1083, 27);
            diagnosis.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Location = new Point(630, 534);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(414, 34);
            dateTimePicker1.TabIndex = 6;
            // 
            // pGender
            // 
            pGender.BackColor = Color.White;
            pGender.DropDownStyle = ComboBoxStyle.DropDownList;
            pGender.FlatStyle = FlatStyle.Flat;
            pGender.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pGender.ForeColor = Color.Black;
            pGender.FormattingEnabled = true;
            pGender.Items.AddRange(new object[] { "Male", "Female", "Others" });
            pGender.Location = new Point(887, 390);
            pGender.Name = "pGender";
            pGender.Size = new Size(317, 33);
            pGender.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.Location = new Point(125, 830);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(272, 78);
            btnSave.TabIndex = 8;
            btnSave.Click += btnSave_Click;
            // 
            // pAddress
            // 
            pAddress.BorderStyle = BorderStyle.None;
            pAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pAddress.Location = new Point(491, 462);
            pAddress.Name = "pAddress";
            pAddress.Size = new Size(436, 27);
            pAddress.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(1520, 830);
            panel1.Name = "panel1";
            panel1.Size = new Size(261, 78);
            panel1.TabIndex = 10;
            panel1.Click += panel1_Click;
            // 
            // pStatus
            // 
            pStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            pStatus.FlatStyle = FlatStyle.Flat;
            pStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pStatus.FormattingEnabled = true;
            pStatus.Items.AddRange(new object[] { "Admitted", "Under Observation" });
            pStatus.Location = new Point(1338, 528);
            pStatus.Name = "pStatus";
            pStatus.Size = new Size(281, 33);
            pStatus.TabIndex = 11;
            // 
            // AddPatient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(pStatus);
            Controls.Add(panel1);
            Controls.Add(pAddress);
            Controls.Add(btnSave);
            Controls.Add(pGender);
            Controls.Add(dateTimePicker1);
            Controls.Add(diagnosis);
            Controls.Add(pCon);
            Controls.Add(pAge);
            Controls.Add(pName);
            Name = "AddPatient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddPatient";
            Load += AddPatient_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox pName;
        private TextBox pAge;
        private TextBox pCon;
        private TextBox diagnosis;
        private DateTimePicker dateTimePicker1;
        private ComboBox pGender;
        private Panel btnSave;
        private TextBox pAddress;
        private Panel panel1;
        private ComboBox pStatus;
    }
}