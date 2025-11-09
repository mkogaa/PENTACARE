namespace PENTACARE
{
    partial class Room_Fee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Room_Fee));
            cb_roomType = new ComboBox();
            txt_CurrentFee = new TextBox();
            txt_NewFee = new TextBox();
            btn_saveFee = new Panel();
            btn_clear = new Panel();
            btn_back = new Panel();
            SuspendLayout();
            // 
            // cb_roomType
            // 
            cb_roomType.FormattingEnabled = true;
            cb_roomType.Location = new Point(572, 381);
            cb_roomType.Name = "cb_roomType";
            cb_roomType.Size = new Size(568, 28);
            cb_roomType.TabIndex = 0;
            cb_roomType.SelectedIndexChanged += cb_roomType_SelectedIndexChanged;
            // 
            // txt_CurrentFee
            // 
            txt_CurrentFee.Location = new Point(572, 501);
            txt_CurrentFee.Name = "txt_CurrentFee";
            txt_CurrentFee.Size = new Size(568, 27);
            txt_CurrentFee.TabIndex = 1;
            // 
            // txt_NewFee
            // 
            txt_NewFee.Location = new Point(572, 629);
            txt_NewFee.Name = "txt_NewFee";
            txt_NewFee.Size = new Size(568, 27);
            txt_NewFee.TabIndex = 2;
            // 
            // btn_saveFee
            // 
            btn_saveFee.BackColor = Color.Transparent;
            btn_saveFee.Location = new Point(169, 803);
            btn_saveFee.Name = "btn_saveFee";
            btn_saveFee.Size = new Size(287, 54);
            btn_saveFee.TabIndex = 3;
            btn_saveFee.Click += btn_saveFee_Click;
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.Transparent;
            btn_clear.Location = new Point(530, 803);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(216, 54);
            btn_clear.TabIndex = 4;
            btn_clear.Paint += btn_clear_Paint;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.Transparent;
            btn_back.Location = new Point(1579, 803);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(216, 54);
            btn_back.TabIndex = 5;
            btn_back.Click += btn_back_Click;
            // 
            // Room_Fee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_back);
            Controls.Add(btn_clear);
            Controls.Add(btn_saveFee);
            Controls.Add(txt_NewFee);
            Controls.Add(txt_CurrentFee);
            Controls.Add(cb_roomType);
            Name = "Room_Fee";
            Text = "Room_Fee";
            Load += Room_Fee_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cb_roomType;
        private TextBox txt_CurrentFee;
        private TextBox txt_NewFee;
        private Panel btn_saveFee;
        private Panel btn_clear;
        private Panel btn_back;
    }
}