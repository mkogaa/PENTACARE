namespace PENTACARE
{
    partial class AssignRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignRoom));
            dtp_AD = new DateTimePicker();
            dtp_ED = new DateTimePicker();
            txt_patientName = new TextBox();
            txt_patientID = new TextBox();
            txt_roomType = new TextBox();
            txt_roomRate = new TextBox();
            txt_Remarks = new TextBox();
            btn_assign = new Panel();
            btn_clear = new Panel();
            btn_back = new Panel();
            SuspendLayout();
            // 
            // dtp_AD
            // 
            dtp_AD.Location = new Point(665, 619);
            dtp_AD.Name = "dtp_AD";
            dtp_AD.Size = new Size(381, 27);
            dtp_AD.TabIndex = 0;
            // 
            // dtp_ED
            // 
            dtp_ED.Location = new Point(665, 683);
            dtp_ED.Name = "dtp_ED";
            dtp_ED.Size = new Size(381, 27);
            dtp_ED.TabIndex = 1;
            // 
            // txt_patientName
            // 
            txt_patientName.Location = new Point(501, 267);
            txt_patientName.Name = "txt_patientName";
            txt_patientName.Size = new Size(335, 27);
            txt_patientName.TabIndex = 2;
            txt_patientName.TextChanged += txt_patientName_TextChanged;
            // 
            // txt_patientID
            // 
            txt_patientID.Location = new Point(501, 329);
            txt_patientID.Name = "txt_patientID";
            txt_patientID.Size = new Size(335, 27);
            txt_patientID.TabIndex = 3;
            // 
            // txt_roomType
            // 
            txt_roomType.Location = new Point(501, 443);
            txt_roomType.Name = "txt_roomType";
            txt_roomType.Size = new Size(335, 27);
            txt_roomType.TabIndex = 4;
            // 
            // txt_roomRate
            // 
            txt_roomRate.Location = new Point(501, 505);
            txt_roomRate.Name = "txt_roomRate";
            txt_roomRate.Size = new Size(335, 27);
            txt_roomRate.TabIndex = 5;
            // 
            // txt_Remarks
            // 
            txt_Remarks.Location = new Point(420, 782);
            txt_Remarks.Name = "txt_Remarks";
            txt_Remarks.Size = new Size(977, 27);
            txt_Remarks.TabIndex = 6;
            // 
            // btn_assign
            // 
            btn_assign.BackColor = Color.Transparent;
            btn_assign.Location = new Point(132, 894);
            btn_assign.Name = "btn_assign";
            btn_assign.Size = new Size(241, 58);
            btn_assign.TabIndex = 7;
            btn_assign.Click += btn_assign_Click;
            btn_assign.Paint += btn_assign_Paint;
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.Transparent;
            btn_clear.Location = new Point(414, 894);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(241, 58);
            btn_clear.TabIndex = 8;
            btn_clear.Click += btn_clear_Click;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.Transparent;
            btn_back.Location = new Point(1539, 894);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(241, 58);
            btn_back.TabIndex = 8;
            btn_back.Click += btn_back_Click;
            // 
            // AssignRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_back);
            Controls.Add(btn_clear);
            Controls.Add(btn_assign);
            Controls.Add(txt_Remarks);
            Controls.Add(txt_roomRate);
            Controls.Add(txt_roomType);
            Controls.Add(txt_patientID);
            Controls.Add(txt_patientName);
            Controls.Add(dtp_ED);
            Controls.Add(dtp_AD);
            Name = "AssignRoom";
            Text = "AssignRoom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtp_AD;
        private DateTimePicker dtp_ED;
        private TextBox txt_patientName;
        private TextBox txt_patientID;
        private TextBox txt_roomType;
        private TextBox txt_roomRate;
        private TextBox txt_Remarks;
        private Panel btn_assign;
        private Panel btn_clear;
        private Panel panel2;
        private Panel btn_back;
    }
}