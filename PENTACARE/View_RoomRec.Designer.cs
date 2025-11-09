namespace PENTACARE
{
    partial class View_RoomRec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_RoomRec));
            lblRoomNo = new Label();
            lblType = new Label();
            lblPatient = new Label();
            lblAge = new Label();
            lblGender = new Label();
            lblAD = new Label();
            btn_backk = new Panel();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // lblRoomNo
            // 
            lblRoomNo.AutoSize = true;
            lblRoomNo.BackColor = Color.Transparent;
            lblRoomNo.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomNo.ForeColor = Color.DarkBlue;
            lblRoomNo.Location = new Point(917, 255);
            lblRoomNo.Name = "lblRoomNo";
            lblRoomNo.Size = new Size(96, 38);
            lblRoomNo.TabIndex = 0;
            lblRoomNo.Text = "label1";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.BackColor = Color.Transparent;
            lblType.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblType.ForeColor = Color.Black;
            lblType.Location = new Point(784, 316);
            lblType.Name = "lblType";
            lblType.Size = new Size(70, 28);
            lblType.TabIndex = 1;
            lblType.Text = "label2";
            // 
            // lblPatient
            // 
            lblPatient.AutoSize = true;
            lblPatient.BackColor = Color.Transparent;
            lblPatient.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPatient.ForeColor = Color.DarkBlue;
            lblPatient.Location = new Point(1006, 474);
            lblPatient.Name = "lblPatient";
            lblPatient.Size = new Size(96, 38);
            lblPatient.TabIndex = 2;
            lblPatient.Text = "label3";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.BackColor = Color.Transparent;
            lblAge.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAge.ForeColor = Color.Black;
            lblAge.Location = new Point(784, 536);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(70, 28);
            lblAge.TabIndex = 3;
            lblAge.Text = "label4";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.BackColor = Color.Transparent;
            lblGender.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGender.ForeColor = Color.Black;
            lblGender.Location = new Point(875, 590);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(70, 28);
            lblGender.TabIndex = 4;
            lblGender.Text = "label5";
            // 
            // lblAD
            // 
            lblAD.AutoSize = true;
            lblAD.BackColor = Color.Transparent;
            lblAD.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAD.ForeColor = Color.Firebrick;
            lblAD.Location = new Point(1006, 646);
            lblAD.Name = "lblAD";
            lblAD.Size = new Size(70, 28);
            lblAD.TabIndex = 5;
            lblAD.Text = "label6";
            // 
            // btn_backk
            // 
            btn_backk.BackColor = Color.Transparent;
            btn_backk.Location = new Point(1431, 796);
            btn_backk.Name = "btn_backk";
            btn_backk.Size = new Size(250, 72);
            btn_backk.TabIndex = 6;
            btn_backk.Click += btn_backk_Click;
            btn_backk.Paint += btn_backk_Paint;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.Black;
            lblStatus.Location = new Point(826, 368);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(70, 28);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "label2";
            // 
            // View_RoomRec
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(lblStatus);
            Controls.Add(btn_backk);
            Controls.Add(lblAD);
            Controls.Add(lblGender);
            Controls.Add(lblAge);
            Controls.Add(lblPatient);
            Controls.Add(lblType);
            Controls.Add(lblRoomNo);
            Name = "View_RoomRec";
            Text = "View_RoomRec";
            Load += View_RoomRec_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRoomNo;
        private Label lblType;
        private Label lblPatient;
        private Label lblAge;
        private Label lblGender;
        private Label lblAD;
        private Panel btn_backk;
        private Label lblStatus;
    }
}