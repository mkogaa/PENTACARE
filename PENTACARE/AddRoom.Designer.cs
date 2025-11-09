namespace PENTACARE
{
    partial class AddRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRoom));
            btn_addRoom = new Panel();
            txt_RoomNo = new TextBox();
            txt_Rate = new TextBox();
            cb_RoomType = new ComboBox();
            cb_Status = new ComboBox();
            txt_beds = new TextBox();
            btn_back = new Panel();
            SuspendLayout();
            // 
            // btn_addRoom
            // 
            btn_addRoom.BackColor = Color.Transparent;
            btn_addRoom.Location = new Point(259, 826);
            btn_addRoom.Name = "btn_addRoom";
            btn_addRoom.Size = new Size(321, 72);
            btn_addRoom.TabIndex = 0;
            btn_addRoom.Click += btn_addRoom_Click;
            // 
            // txt_RoomNo
            // 
            txt_RoomNo.BackColor = Color.LightSteelBlue;
            txt_RoomNo.Location = new Point(970, 301);
            txt_RoomNo.Name = "txt_RoomNo";
            txt_RoomNo.Size = new Size(557, 27);
            txt_RoomNo.TabIndex = 3;
            // 
            // txt_Rate
            // 
            txt_Rate.BackColor = Color.LightSteelBlue;
            txt_Rate.Location = new Point(970, 469);
            txt_Rate.Name = "txt_Rate";
            txt_Rate.Size = new Size(557, 27);
            txt_Rate.TabIndex = 4;
            // 
            // cb_RoomType
            // 
            cb_RoomType.FormattingEnabled = true;
            cb_RoomType.Items.AddRange(new object[] { "Private", "Semi-Private", "Ward" });
            cb_RoomType.Location = new Point(970, 386);
            cb_RoomType.Name = "cb_RoomType";
            cb_RoomType.Size = new Size(557, 28);
            cb_RoomType.TabIndex = 6;
            cb_RoomType.SelectedIndexChanged += cb_RoomType_SelectedIndexChanged;
            // 
            // cb_Status
            // 
            cb_Status.FormattingEnabled = true;
            cb_Status.Items.AddRange(new object[] { "Available", "Under Maintenance" });
            cb_Status.Location = new Point(970, 549);
            cb_Status.Name = "cb_Status";
            cb_Status.Size = new Size(557, 28);
            cb_Status.TabIndex = 7;
            // 
            // txt_beds
            // 
            txt_beds.BackColor = Color.LightSteelBlue;
            txt_beds.Location = new Point(970, 632);
            txt_beds.Name = "txt_beds";
            txt_beds.Size = new Size(557, 27);
            txt_beds.TabIndex = 8;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.Transparent;
            btn_back.Location = new Point(1422, 826);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(256, 72);
            btn_back.TabIndex = 1;
            btn_back.Click += btn_back_Click;
            // 
            // AddRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_back);
            Controls.Add(txt_beds);
            Controls.Add(cb_Status);
            Controls.Add(cb_RoomType);
            Controls.Add(txt_Rate);
            Controls.Add(txt_RoomNo);
            Controls.Add(btn_addRoom);
            Name = "AddRoom";
            Text = "AddRoom";
            Load += AddRoom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel btn_addRoom;
        private TextBox txt_RoomNo;
        private TextBox txt_Rate;
        private ComboBox cb_RoomType;
        private ComboBox cb_Status;
        private TextBox txt_beds;
        private Panel btn_back;
    }
}