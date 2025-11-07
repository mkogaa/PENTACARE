namespace PENTACARE
{
    partial class Room_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Room_Management));
            btn_addRoom = new Panel();
            btn_manageRoom = new Panel();
            btn_assignPatient = new Panel();
            btn_backMain = new Panel();
            dgvRoom = new DataGridView();
            label1 = new Label();
            txt_searchRoom = new TextBox();
            cb_status = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRoom).BeginInit();
            SuspendLayout();
            // 
            // btn_addRoom
            // 
            btn_addRoom.BackColor = Color.Transparent;
            btn_addRoom.Location = new Point(159, 896);
            btn_addRoom.Name = "btn_addRoom";
            btn_addRoom.Size = new Size(303, 49);
            btn_addRoom.TabIndex = 0;
            btn_addRoom.Click += btn_addRoom_Click;
            // 
            // btn_manageRoom
            // 
            btn_manageRoom.BackColor = Color.Transparent;
            btn_manageRoom.Location = new Point(550, 897);
            btn_manageRoom.Name = "btn_manageRoom";
            btn_manageRoom.Size = new Size(303, 49);
            btn_manageRoom.TabIndex = 1;
            btn_manageRoom.Click += btn_manageRoom_Click;
            // 
            // btn_assignPatient
            // 
            btn_assignPatient.BackColor = Color.Transparent;
            btn_assignPatient.Location = new Point(938, 896);
            btn_assignPatient.Name = "btn_assignPatient";
            btn_assignPatient.Size = new Size(188, 49);
            btn_assignPatient.TabIndex = 1;
            btn_assignPatient.Click += btn_assignPatient_Click;
            btn_assignPatient.Paint += btn_assignPatient_Paint;
            // 
            // btn_backMain
            // 
            btn_backMain.BackColor = Color.Transparent;
            btn_backMain.Location = new Point(1569, 896);
            btn_backMain.Name = "btn_backMain";
            btn_backMain.Size = new Size(188, 49);
            btn_backMain.TabIndex = 2;
            btn_backMain.Click += btn_backMain_Click;
            // 
            // dgvRoom
            // 
            dgvRoom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoom.Location = new Point(189, 364);
            dgvRoom.Name = "dgvRoom";
            dgvRoom.RowHeadersWidth = 51;
            dgvRoom.Size = new Size(1535, 455);
            dgvRoom.TabIndex = 3;
            dgvRoom.CellDoubleClick += dgvRoom_CellDoubleClick;
            dgvRoom.DoubleClick += dgvRoom_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkBlue;
            label1.Location = new Point(134, 179);
            label1.Name = "label1";
            label1.Size = new Size(306, 23);
            label1.TabIndex = 4;
            label1.Text = "Search by Room Id or Room Number";
            // 
            // txt_searchRoom
            // 
            txt_searchRoom.BorderStyle = BorderStyle.None;
            txt_searchRoom.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_searchRoom.Location = new Point(159, 233);
            txt_searchRoom.Name = "txt_searchRoom";
            txt_searchRoom.Size = new Size(1097, 23);
            txt_searchRoom.TabIndex = 5;
            txt_searchRoom.TextChanged += txt_searchRoom_TextChanged;
            // 
            // cb_status
            // 
            cb_status.DropDownHeight = 260;
            cb_status.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_status.FlatStyle = FlatStyle.Flat;
            cb_status.FormattingEnabled = true;
            cb_status.IntegralHeight = false;
            cb_status.Location = new Point(1459, 234);
            cb_status.Name = "cb_status";
            cb_status.Size = new Size(311, 28);
            cb_status.TabIndex = 6;
            cb_status.SelectedIndexChanged += cb_status_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkBlue;
            label2.Location = new Point(1426, 179);
            label2.Name = "label2";
            label2.Size = new Size(177, 23);
            label2.TabIndex = 7;
            label2.Text = "Filter by room status";
            // 
            // Room_Management
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(label2);
            Controls.Add(cb_status);
            Controls.Add(txt_searchRoom);
            Controls.Add(label1);
            Controls.Add(dgvRoom);
            Controls.Add(btn_backMain);
            Controls.Add(btn_assignPatient);
            Controls.Add(btn_manageRoom);
            Controls.Add(btn_addRoom);
            Name = "Room_Management";
            Text = "Room_Management";
            Load += Room_Management_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRoom).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel btn_addRoom;
        private Panel btn_manageRoom;
        private Panel btn_assignPatient;
        private Panel btn_backMain;
        private DataGridView dgvRoom;
        private Label label1;
        private TextBox txt_searchRoom;
        private ComboBox cb_status;
        private Label label2;
    }
}