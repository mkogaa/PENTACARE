namespace PENTACARE
{
    partial class RoomDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomDetail));
            roomNum = new Label();
            RoomID = new Label();
            RoomType = new Label();
            RoomRate = new Label();
            BedNo = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // roomNum
            // 
            roomNum.AutoSize = true;
            roomNum.BackColor = Color.Transparent;
            roomNum.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roomNum.ForeColor = Color.DarkBlue;
            roomNum.Location = new Point(912, 297);
            roomNum.Name = "roomNum";
            roomNum.Size = new Size(117, 46);
            roomNum.TabIndex = 0;
            roomNum.Text = "label1";
            // 
            // RoomID
            // 
            RoomID.AutoSize = true;
            RoomID.BackColor = Color.Transparent;
            RoomID.Font = new Font("Segoe UI", 16.2F);
            RoomID.Location = new Point(912, 382);
            RoomID.Name = "RoomID";
            RoomID.Size = new Size(91, 38);
            RoomID.TabIndex = 1;
            RoomID.Text = "label2";
            // 
            // RoomType
            // 
            RoomType.AutoSize = true;
            RoomType.BackColor = Color.Transparent;
            RoomType.Font = new Font("Segoe UI", 16.2F);
            RoomType.Location = new Point(912, 446);
            RoomType.Name = "RoomType";
            RoomType.Size = new Size(91, 38);
            RoomType.TabIndex = 3;
            RoomType.Text = "label4";
            // 
            // RoomRate
            // 
            RoomRate.AutoSize = true;
            RoomRate.BackColor = Color.Transparent;
            RoomRate.Font = new Font("Segoe UI", 16.2F);
            RoomRate.Location = new Point(912, 526);
            RoomRate.Name = "RoomRate";
            RoomRate.Size = new Size(91, 38);
            RoomRate.TabIndex = 3;
            RoomRate.Text = "label4";
            // 
            // BedNo
            // 
            BedNo.AutoSize = true;
            BedNo.BackColor = Color.Transparent;
            BedNo.Font = new Font("Segoe UI", 16.2F);
            BedNo.Location = new Point(912, 606);
            BedNo.Name = "BedNo";
            BedNo.Size = new Size(91, 38);
            BedNo.TabIndex = 4;
            BedNo.Text = "label6";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(1414, 841);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(269, 92);
            panel1.TabIndex = 5;
            panel1.Click += panel1_Click;
            // 
            // RoomDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel1);
            Controls.Add(BedNo);
            Controls.Add(RoomRate);
            Controls.Add(RoomType);
            Controls.Add(RoomID);
            Controls.Add(roomNum);
            Name = "RoomDetail";
            Text = "RoomDetail";
            WindowState = FormWindowState.Maximized;
            Load += RoomDetail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label roomNum;
        private Label RoomID;
        private Label RoomType;
        private Label RoomRate;
        private Label BedNo;
        private Panel panel1;
    }
}