namespace USERS_WINDOW
{
    partial class UserDashboard
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDashboard));
            assignedP = new Label();
            monthCalendar1 = new MonthCalendar();
            userName = new Label();
            dgvDashboard = new DataGridView();
            btnViewProfile = new Button();
            btnPatient = new Button();
            btnMedRecords = new Button();
            btnLab = new Button();
            btnLogout = new Button();
            btnRefresh = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtPLT = new Label();
            txtTLT = new Label();
            txtTP = new Label();
            txtTMR = new Label();
            btnRecords = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).BeginInit();
            SuspendLayout();
            // 
            // assignedP
            // 
            assignedP.AutoSize = true;
            assignedP.BackColor = Color.Transparent;
            assignedP.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            assignedP.ForeColor = SystemColors.ButtonFace;
            assignedP.Location = new Point(1081, 91);
            assignedP.Name = "assignedP";
            assignedP.Size = new Size(0, 20);
            assignedP.TabIndex = 3;
            // 
            // monthCalendar1
            // 
            monthCalendar1.BackColor = Color.MidnightBlue;
            monthCalendar1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            monthCalendar1.Location = new Point(1538, 235);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 6;
            // 
            // userName
            // 
            userName.AutoSize = true;
            userName.BackColor = Color.Transparent;
            userName.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userName.ForeColor = SystemColors.ButtonFace;
            userName.Location = new Point(1613, 146);
            userName.Name = "userName";
            userName.Size = new Size(192, 27);
            userName.TabIndex = 0;
            userName.Text = "Nurse, Gumban!";
            // 
            // dgvDashboard
            // 
            dgvDashboard.BackgroundColor = Color.FromArgb(69, 105, 173);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDashboard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDashboard.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDashboard.GridColor = Color.DarkBlue;
            dgvDashboard.Location = new Point(800, 535);
            dgvDashboard.Name = "dgvDashboard";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvDashboard.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvDashboard.RowHeadersWidth = 51;
            dgvDashboard.Size = new Size(1012, 321);
            dgvDashboard.TabIndex = 0;
            dgvDashboard.CellContentClick += dgvCurrentP_CellContentClick;
            // 
            // btnViewProfile
            // 
            btnViewProfile.BackColor = Color.FromArgb(140, 193, 233);
            btnViewProfile.FlatStyle = FlatStyle.Flat;
            btnViewProfile.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewProfile.ForeColor = Color.MidnightBlue;
            btnViewProfile.Location = new Point(286, 292);
            btnViewProfile.Name = "btnViewProfile";
            btnViewProfile.Size = new Size(378, 72);
            btnViewProfile.TabIndex = 7;
            btnViewProfile.Text = "View Profile";
            btnViewProfile.UseVisualStyleBackColor = false;
            btnViewProfile.Click += btnViewProfile_Click;
            // 
            // btnPatient
            // 
            btnPatient.BackColor = Color.FromArgb(140, 193, 233);
            btnPatient.FlatStyle = FlatStyle.Flat;
            btnPatient.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPatient.ForeColor = Color.MidnightBlue;
            btnPatient.Location = new Point(285, 378);
            btnPatient.Name = "btnPatient";
            btnPatient.Size = new Size(379, 78);
            btnPatient.TabIndex = 8;
            btnPatient.Text = "Patient Management";
            btnPatient.UseVisualStyleBackColor = false;
            btnPatient.Click += btnPatient_Click;
            // 
            // btnMedRecords
            // 
            btnMedRecords.BackColor = Color.FromArgb(140, 193, 233);
            btnMedRecords.FlatStyle = FlatStyle.Flat;
            btnMedRecords.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMedRecords.ForeColor = Color.MidnightBlue;
            btnMedRecords.Location = new Point(285, 560);
            btnMedRecords.Name = "btnMedRecords";
            btnMedRecords.Size = new Size(379, 81);
            btnMedRecords.TabIndex = 9;
            btnMedRecords.Text = "Active Patient Records";
            btnMedRecords.UseVisualStyleBackColor = false;
            btnMedRecords.Click += btnMedRecords_Click;
            // 
            // btnLab
            // 
            btnLab.BackColor = Color.FromArgb(140, 193, 233);
            btnLab.FlatStyle = FlatStyle.Flat;
            btnLab.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLab.ForeColor = Color.MidnightBlue;
            btnLab.Location = new Point(285, 461);
            btnLab.Name = "btnLab";
            btnLab.Size = new Size(379, 83);
            btnLab.TabIndex = 10;
            btnLab.Text = "Laboratory Management";
            btnLab.UseVisualStyleBackColor = false;
            btnLab.Click += btnLab_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(140, 193, 233);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.MidnightBlue;
            btnLogout.Location = new Point(287, 752);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(377, 82);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = SystemColors.ButtonFace;
            btnRefresh.Location = new Point(1629, 954);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(158, 49);
            btnRefresh.TabIndex = 12;
            btnRefresh.Text = "                          ";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btn_Refresh_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(1553, 185);
            label1.Name = "label1";
            label1.Size = new Size(241, 22);
            label1.TabIndex = 13;
            label1.Text = "_____________________";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(1580, 207);
            label2.Name = "label2";
            label2.Size = new Size(190, 22);
            label2.TabIndex = 14;
            label2.Text = "Pentacare Calendar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(1613, 127);
            label3.Name = "label3";
            label3.Size = new Size(88, 19);
            label3.TabIndex = 15;
            label3.Text = "Welcome";
            // 
            // txtPLT
            // 
            txtPLT.AutoSize = true;
            txtPLT.BackColor = Color.Transparent;
            txtPLT.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPLT.ForeColor = Color.FromArgb(0, 22, 122);
            txtPLT.Location = new Point(768, 98);
            txtPLT.Name = "txtPLT";
            txtPLT.Size = new Size(86, 47);
            txtPLT.TabIndex = 16;
            txtPLT.Text = "000";
            // 
            // txtTLT
            // 
            txtTLT.AutoSize = true;
            txtTLT.BackColor = Color.Transparent;
            txtTLT.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTLT.ForeColor = Color.FromArgb(0, 22, 122);
            txtTLT.Location = new Point(1148, 96);
            txtTLT.Name = "txtTLT";
            txtTLT.Size = new Size(86, 47);
            txtTLT.TabIndex = 17;
            txtTLT.Text = "000";
            // 
            // txtTP
            // 
            txtTP.AutoSize = true;
            txtTP.BackColor = Color.Transparent;
            txtTP.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTP.ForeColor = Color.FromArgb(0, 22, 122);
            txtTP.Location = new Point(766, 257);
            txtTP.Name = "txtTP";
            txtTP.Size = new Size(86, 47);
            txtTP.TabIndex = 18;
            txtTP.Text = "000";
            // 
            // txtTMR
            // 
            txtTMR.AutoSize = true;
            txtTMR.BackColor = Color.Transparent;
            txtTMR.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTMR.ForeColor = Color.FromArgb(0, 22, 122);
            txtTMR.Location = new Point(1148, 256);
            txtTMR.Name = "txtTMR";
            txtTMR.Size = new Size(86, 47);
            txtTMR.TabIndex = 19;
            txtTMR.Text = "000";
            // 
            // btnRecords
            // 
            btnRecords.BackColor = Color.FromArgb(140, 193, 233);
            btnRecords.FlatStyle = FlatStyle.Flat;
            btnRecords.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRecords.ForeColor = Color.MidnightBlue;
            btnRecords.Location = new Point(287, 658);
            btnRecords.Name = "btnRecords";
            btnRecords.Size = new Size(377, 83);
            btnRecords.TabIndex = 20;
            btnRecords.Text = "Medical Records";
            btnRecords.UseVisualStyleBackColor = false;
            btnRecords.Click += btnRecords_Click;
            // 
            // UserDashboard
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btnRecords);
            Controls.Add(txtTMR);
            Controls.Add(txtTP);
            Controls.Add(txtTLT);
            Controls.Add(txtPLT);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRefresh);
            Controls.Add(btnLogout);
            Controls.Add(btnLab);
            Controls.Add(btnMedRecords);
            Controls.Add(btnPatient);
            Controls.Add(btnViewProfile);
            Controls.Add(dgvDashboard);
            Controls.Add(monthCalendar1);
            Controls.Add(userName);
            Controls.Add(assignedP);
            Name = "UserDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "s";
            WindowState = FormWindowState.Maximized;
            Load += UserDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label assignedP;
        private MonthCalendar monthCalendar1;
        private Label userName;
        private DataGridView dgvDashboard;
        private Button btnViewProfile;
        private Button btnPatient;
        private Button btnMedRecords;
        private Button btnLab;
        private Button btnLogout;
        private Button btnRefresh;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label txtPLT;
        private Label txtTLT;
        private Label label4;
        private Label txtTP;
        private Label txtTMR;
        private Button btnRecords;
    }
}
