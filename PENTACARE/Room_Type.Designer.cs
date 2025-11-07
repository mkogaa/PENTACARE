namespace PENTACARE
{
    partial class Room_Type
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Room_Type));
            dgvRoomType = new DataGridView();
            btn_updateRate = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvRoomType).BeginInit();
            SuspendLayout();
            // 
            // dgvRoomType
            // 
            dgvRoomType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoomType.Location = new Point(175, 369);
            dgvRoomType.Name = "dgvRoomType";
            dgvRoomType.RowHeadersWidth = 51;
            dgvRoomType.Size = new Size(1535, 455);
            dgvRoomType.TabIndex = 4;
            // 
            // btn_updateRate
            // 
            btn_updateRate.BackColor = Color.Transparent;
            btn_updateRate.Location = new Point(162, 894);
            btn_updateRate.Name = "btn_updateRate";
            btn_updateRate.Size = new Size(250, 87);
            btn_updateRate.TabIndex = 5;
            btn_updateRate.Click += btn_updateRate_Click;
            // 
            // Room_Type
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_updateRate);
            Controls.Add(dgvRoomType);
            Name = "Room_Type";
            Text = "Room_Type";
            Load += Room_Type_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRoomType).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvRoomType;
        private Panel btn_updateRate;
    }
}