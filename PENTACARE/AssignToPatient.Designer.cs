namespace PentaCare
{
    partial class AssignToPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignToPatient));
            assignBtn = new Panel();
            searchBox = new TextBox();
            searchBtn = new Panel();
            pID = new TextBox();
            pName = new TextBox();
            doctor = new ComboBox();
            backBtn = new Panel();
            SuspendLayout();
            // 
            // assignBtn
            // 
            assignBtn.BackColor = Color.Transparent;
            assignBtn.Location = new Point(242, 779);
            assignBtn.Name = "assignBtn";
            assignBtn.Size = new Size(365, 75);
            assignBtn.TabIndex = 0;
            assignBtn.Click += assignBtn_Click;
            // 
            // searchBox
            // 
            searchBox.BorderStyle = BorderStyle.None;
            searchBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchBox.Location = new Point(710, 235);
            searchBox.Name = "searchBox";
            searchBox.PlaceholderText = "Search by Patient Name, Patient ID...";
            searchBox.Size = new Size(618, 40);
            searchBox.TabIndex = 1;
            searchBox.TextChanged += searchBox_TextChanged;
            // 
            // searchBtn
            // 
            searchBtn.BackColor = Color.Transparent;
            searchBtn.Location = new Point(1465, 234);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(82, 60);
            searchBtn.TabIndex = 2;
            searchBtn.Click += searchBtn_Click;
            searchBtn.Paint += searchBtn_Paint;
            // 
            // pID
            // 
            pID.BorderStyle = BorderStyle.None;
            pID.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pID.Location = new Point(960, 334);
            pID.Name = "pID";
            pID.Size = new Size(392, 44);
            pID.TabIndex = 3;
            // 
            // pName
            // 
            pName.BorderStyle = BorderStyle.None;
            pName.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pName.Location = new Point(1029, 436);
            pName.Name = "pName";
            pName.Size = new Size(392, 44);
            pName.TabIndex = 4;
            // 
            // doctor
            // 
            doctor.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            doctor.FormattingEnabled = true;
            doctor.Items.AddRange(new object[] { "Dr. Amelia Santos", "Dr. Benjamin Cruz", "Dr. Carla Mendoza", "Dr. Daniel Ramos", "Dr. Erica Lim", "Dr. Francis Tan", "Dr. Grace Navarro", "Dr. Henry Dela Cruz", "Dr. Isabel Torres", "Dr. Joseph Reyes" });
            doctor.Location = new Point(1029, 540);
            doctor.Name = "doctor";
            doctor.Size = new Size(333, 45);
            doctor.TabIndex = 5;
            // 
            // backBtn
            // 
            backBtn.BackColor = Color.Transparent;
            backBtn.Location = new Point(1449, 781);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(226, 73);
            backBtn.TabIndex = 6;
            backBtn.Click += backBtn_Click;
            // 
            // AssignToPatient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(backBtn);
            Controls.Add(doctor);
            Controls.Add(pName);
            Controls.Add(pID);
            Controls.Add(searchBtn);
            Controls.Add(searchBox);
            Controls.Add(assignBtn);
            Name = "AssignToPatient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AssignToPatient";
            Load += AssignToPatient_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel assignBtn;
        private TextBox searchBox;
        private Panel searchBtn;
        private TextBox pID;
        private TextBox pName;
        private ComboBox doctor;
        private Panel backBtn;
    }
}