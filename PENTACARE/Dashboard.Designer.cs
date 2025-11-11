namespace PENTACARE
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            btn_labService = new Panel();
            btn_services = new Panel();
            btn_billingMain = new Panel();
            btn_room = new Panel();
            btn_patientManage = new Panel();
            btn_doctorsRec = new Panel();
            btn_patient = new Panel();
            btn_doctor = new Panel();
            btn_rooms = new Panel();
            lbl_totalPatients = new Label();
            lbl_occupied = new Label();
            lbl_available = new Label();
            lbl_doctors = new Label();
            dgvRecentAct = new DataGridView();
            viewInfo = new Panel();
            panel1 = new Panel();
            btn_Records = new Panel();
            monthCalendar1 = new MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)dgvRecentAct).BeginInit();
            SuspendLayout();
            // 
            // btn_labService
            // 
            btn_labService.BackColor = Color.Transparent;
            btn_labService.Location = new Point(176, 787);
            btn_labService.Name = "btn_labService";
            btn_labService.Size = new Size(208, 34);
            btn_labService.TabIndex = 0;
            btn_labService.Click += btn_labService_Click;
            btn_labService.DoubleClick += btn_labService_DoubleClick;
            // 
            // btn_services
            // 
            btn_services.BackColor = Color.Transparent;
            btn_services.Location = new Point(1464, 421);
            btn_services.Name = "btn_services";
            btn_services.Size = new Size(106, 74);
            btn_services.TabIndex = 1;
            btn_services.Click += btn_services_Click;
            // 
            // btn_billingMain
            // 
            btn_billingMain.BackColor = Color.Transparent;
            btn_billingMain.BackgroundImageLayout = ImageLayout.Stretch;
            btn_billingMain.Location = new Point(176, 621);
            btn_billingMain.Name = "btn_billingMain";
            btn_billingMain.Size = new Size(215, 37);
            btn_billingMain.TabIndex = 1;
            btn_billingMain.Click += btn_billingMain_Click_1;
            // 
            // btn_room
            // 
            btn_room.BackColor = Color.Transparent;
            btn_room.BackgroundImageLayout = ImageLayout.Stretch;
            btn_room.Location = new Point(176, 459);
            btn_room.Name = "btn_room";
            btn_room.Size = new Size(215, 37);
            btn_room.TabIndex = 2;
            btn_room.Click += btn_room_Click;
            // 
            // btn_patientManage
            // 
            btn_patientManage.BackColor = Color.Transparent;
            btn_patientManage.BackgroundImageLayout = ImageLayout.Stretch;
            btn_patientManage.Location = new Point(176, 378);
            btn_patientManage.Name = "btn_patientManage";
            btn_patientManage.Size = new Size(215, 37);
            btn_patientManage.TabIndex = 3;
            btn_patientManage.Click += btn_patientManage_Click;
            // 
            // btn_doctorsRec
            // 
            btn_doctorsRec.BackColor = Color.Transparent;
            btn_doctorsRec.Location = new Point(176, 539);
            btn_doctorsRec.Name = "btn_doctorsRec";
            btn_doctorsRec.Size = new Size(215, 37);
            btn_doctorsRec.TabIndex = 4;
            btn_doctorsRec.Click += btn_doctorsRec_Click;
            // 
            // btn_patient
            // 
            btn_patient.BackColor = Color.Transparent;
            btn_patient.Location = new Point(1459, 295);
            btn_patient.Name = "btn_patient";
            btn_patient.Size = new Size(106, 74);
            btn_patient.TabIndex = 2;
            btn_patient.Click += btn_patient_Click;
            // 
            // btn_doctor
            // 
            btn_doctor.BackColor = Color.Transparent;
            btn_doctor.Location = new Point(1705, 294);
            btn_doctor.Name = "btn_doctor";
            btn_doctor.Size = new Size(106, 74);
            btn_doctor.TabIndex = 3;
            btn_doctor.Click += btn_doctor_Click;
            // 
            // btn_rooms
            // 
            btn_rooms.BackColor = Color.Transparent;
            btn_rooms.Location = new Point(1707, 419);
            btn_rooms.Name = "btn_rooms";
            btn_rooms.Size = new Size(106, 74);
            btn_rooms.TabIndex = 5;
            btn_rooms.Click += btn_rooms_Click;
            btn_rooms.Paint += btn_rooms_Paint;
            // 
            // lbl_totalPatients
            // 
            lbl_totalPatients.AutoSize = true;
            lbl_totalPatients.BackColor = Color.Transparent;
            lbl_totalPatients.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_totalPatients.ForeColor = Color.White;
            lbl_totalPatients.Location = new Point(627, 257);
            lbl_totalPatients.Name = "lbl_totalPatients";
            lbl_totalPatients.Size = new Size(89, 28);
            lbl_totalPatients.TabIndex = 6;
            lbl_totalPatients.Text = "patients";
            // 
            // lbl_occupied
            // 
            lbl_occupied.AutoSize = true;
            lbl_occupied.BackColor = Color.Transparent;
            lbl_occupied.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_occupied.ForeColor = Color.White;
            lbl_occupied.Location = new Point(1078, 257);
            lbl_occupied.Name = "lbl_occupied";
            lbl_occupied.Size = new Size(97, 28);
            lbl_occupied.TabIndex = 7;
            lbl_occupied.Text = "occupied";
            // 
            // lbl_available
            // 
            lbl_available.AutoSize = true;
            lbl_available.BackColor = Color.Transparent;
            lbl_available.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_available.ForeColor = Color.White;
            lbl_available.Location = new Point(627, 408);
            lbl_available.Name = "lbl_available";
            lbl_available.Size = new Size(97, 28);
            lbl_available.TabIndex = 9;
            lbl_available.Text = "available";
            // 
            // lbl_doctors
            // 
            lbl_doctors.AutoSize = true;
            lbl_doctors.BackColor = Color.Transparent;
            lbl_doctors.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_doctors.ForeColor = Color.White;
            lbl_doctors.Location = new Point(1078, 408);
            lbl_doctors.Name = "lbl_doctors";
            lbl_doctors.Size = new Size(83, 28);
            lbl_doctors.TabIndex = 10;
            lbl_doctors.Text = "doctors";
            // 
            // dgvRecentAct
            // 
            dgvRecentAct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecentAct.Location = new Point(504, 681);
            dgvRecentAct.Name = "dgvRecentAct";
            dgvRecentAct.RowHeadersWidth = 51;
            dgvRecentAct.Size = new Size(800, 205);
            dgvRecentAct.TabIndex = 11;
            // 
            // viewInfo
            // 
            viewInfo.BackColor = Color.Transparent;
            viewInfo.Location = new Point(1361, 72);
            viewInfo.Name = "viewInfo";
            viewInfo.Size = new Size(471, 135);
            viewInfo.TabIndex = 12;
            viewInfo.Click += viewInfo_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(176, 852);
            panel1.Name = "panel1";
            panel1.Size = new Size(206, 48);
            panel1.TabIndex = 13;
            panel1.Click += panel1_Click;
            // 
            // btn_Records
            // 
            btn_Records.BackColor = Color.Transparent;
            btn_Records.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Records.Location = new Point(176, 698);
            btn_Records.Name = "btn_Records";
            btn_Records.Size = new Size(215, 37);
            btn_Records.TabIndex = 2;
            btn_Records.Click += btn_Records_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.BackColor = Color.DarkBlue;
            monthCalendar1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            monthCalendar1.ForeColor = Color.White;
            monthCalendar1.Location = new Point(1474, 658);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 20;
            // 
            // Dashboard
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(monthCalendar1);
            Controls.Add(btn_Records);
            Controls.Add(panel1);
            Controls.Add(viewInfo);
            Controls.Add(dgvRecentAct);
            Controls.Add(lbl_doctors);
            Controls.Add(lbl_available);
            Controls.Add(lbl_occupied);
            Controls.Add(lbl_totalPatients);
            Controls.Add(btn_rooms);
            Controls.Add(btn_doctor);
            Controls.Add(btn_patient);
            Controls.Add(btn_doctorsRec);
            Controls.Add(btn_patientManage);
            Controls.Add(btn_room);
            Controls.Add(btn_billingMain);
            Controls.Add(btn_services);
            Controls.Add(btn_labService);
            Name = "Dashboard";
            Text = "Form1";
            Load += Dashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRecentAct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel btn_labService;
        private Panel btn_services;
        private Panel btn_billingMain;
        private Panel btn_room;
        private Panel btn_patientManage;
        private Panel btn_doctorsRec;
        private Panel btn_patient;
        private Panel btn_doctor;
        private Panel btn_rooms;
        private Label lbl_totalPatients;
        private Label lbl_occupied;
        private Label lbl_available;
        private Label lbl_doctors;
        private DataGridView dgvRecentAct;
        private Panel viewInfo;
        private Panel panel1;
        private Panel btn_Records;
        private MonthCalendar monthCalendar1;
    }
}
