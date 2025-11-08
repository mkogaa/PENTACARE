namespace USERS_WINDOW
{
    partial class AssignLaboratoryTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignLaboratoryTest));
            lbl_assign_patientname = new Label();
            lbl_assign_room = new Label();
            lbl_assign_doctorname = new Label();
            lbl_assign_specialty = new Label();
            cb_labtest = new ComboBox();
            dtp_assign = new DateTimePicker();
            txt_assign_fee = new TextBox();
            txt_assign_remarks = new TextBox();
            btn_assign_save = new Panel();
            btn_assign_clear = new Panel();
            btn_assign_back = new Panel();
            SuspendLayout();
            // 
            // lbl_assign_patientname
            // 
            lbl_assign_patientname.AutoSize = true;
            lbl_assign_patientname.BackColor = Color.White;
            lbl_assign_patientname.Font = new Font("Century Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_assign_patientname.ForeColor = Color.MidnightBlue;
            lbl_assign_patientname.Location = new Point(633, 234);
            lbl_assign_patientname.Margin = new Padding(2, 0, 2, 0);
            lbl_assign_patientname.Name = "lbl_assign_patientname";
            lbl_assign_patientname.Size = new Size(118, 40);
            lbl_assign_patientname.TabIndex = 6;
            lbl_assign_patientname.Text = "label1";
            // 
            // lbl_assign_room
            // 
            lbl_assign_room.AutoSize = true;
            lbl_assign_room.BackColor = Color.White;
            lbl_assign_room.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_assign_room.Location = new Point(426, 281);
            lbl_assign_room.Margin = new Padding(2, 0, 2, 0);
            lbl_assign_room.Name = "lbl_assign_room";
            lbl_assign_room.Size = new Size(70, 23);
            lbl_assign_room.TabIndex = 9;
            lbl_assign_room.Text = "label1";
            // 
            // lbl_assign_doctorname
            // 
            lbl_assign_doctorname.AutoSize = true;
            lbl_assign_doctorname.BackColor = Color.White;
            lbl_assign_doctorname.Font = new Font("Century Gothic", 20F, FontStyle.Bold);
            lbl_assign_doctorname.ForeColor = Color.MidnightBlue;
            lbl_assign_doctorname.Location = new Point(1416, 234);
            lbl_assign_doctorname.Margin = new Padding(2, 0, 2, 0);
            lbl_assign_doctorname.Name = "lbl_assign_doctorname";
            lbl_assign_doctorname.Size = new Size(118, 40);
            lbl_assign_doctorname.TabIndex = 10;
            lbl_assign_doctorname.Text = "label1";
            // 
            // lbl_assign_specialty
            // 
            lbl_assign_specialty.AutoSize = true;
            lbl_assign_specialty.BackColor = Color.White;
            lbl_assign_specialty.Font = new Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_assign_specialty.ForeColor = Color.Black;
            lbl_assign_specialty.Location = new Point(1118, 280);
            lbl_assign_specialty.Margin = new Padding(2, 0, 2, 0);
            lbl_assign_specialty.Name = "lbl_assign_specialty";
            lbl_assign_specialty.Size = new Size(94, 32);
            lbl_assign_specialty.TabIndex = 11;
            lbl_assign_specialty.Text = "label1";
            // 
            // cb_labtest
            // 
            cb_labtest.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_labtest.Font = new Font("Century Gothic", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_labtest.FormattingEnabled = true;
            cb_labtest.Location = new Point(701, 439);
            cb_labtest.Margin = new Padding(2, 2, 2, 2);
            cb_labtest.Name = "cb_labtest";
            cb_labtest.Size = new Size(1003, 48);
            cb_labtest.TabIndex = 12;
            // 
            // dtp_assign
            // 
            dtp_assign.CalendarFont = new Font("Century Gothic", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_assign.Location = new Point(701, 556);
            dtp_assign.Margin = new Padding(2, 2, 2, 2);
            dtp_assign.Name = "dtp_assign";
            dtp_assign.Size = new Size(1003, 27);
            dtp_assign.TabIndex = 13;
            // 
            // txt_assign_fee
            // 
            txt_assign_fee.BackColor = Color.White;
            txt_assign_fee.BorderStyle = BorderStyle.FixedSingle;
            txt_assign_fee.Font = new Font("Century Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_assign_fee.Location = new Point(701, 649);
            txt_assign_fee.Margin = new Padding(2, 2, 2, 2);
            txt_assign_fee.Name = "txt_assign_fee";
            txt_assign_fee.ReadOnly = true;
            txt_assign_fee.Size = new Size(1003, 57);
            txt_assign_fee.TabIndex = 14;
            // 
            // txt_assign_remarks
            // 
            txt_assign_remarks.BorderStyle = BorderStyle.FixedSingle;
            txt_assign_remarks.Font = new Font("Century Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_assign_remarks.Location = new Point(701, 751);
            txt_assign_remarks.Margin = new Padding(2, 2, 2, 2);
            txt_assign_remarks.Name = "txt_assign_remarks";
            txt_assign_remarks.Size = new Size(1003, 57);
            txt_assign_remarks.TabIndex = 15;
            // 
            // btn_assign_save
            // 
            btn_assign_save.BackColor = Color.Transparent;
            btn_assign_save.Location = new Point(139, 913);
            btn_assign_save.Margin = new Padding(2, 2, 2, 2);
            btn_assign_save.Name = "btn_assign_save";
            btn_assign_save.Size = new Size(249, 75);
            btn_assign_save.TabIndex = 16;
            btn_assign_save.Click += btn_assign_save_Click;
            // 
            // btn_assign_clear
            // 
            btn_assign_clear.BackColor = Color.Transparent;
            btn_assign_clear.Location = new Point(452, 913);
            btn_assign_clear.Margin = new Padding(2, 2, 2, 2);
            btn_assign_clear.Name = "btn_assign_clear";
            btn_assign_clear.Size = new Size(234, 75);
            btn_assign_clear.TabIndex = 17;
            btn_assign_clear.Click += btn_assign_clear_Click;
            // 
            // btn_assign_back
            // 
            btn_assign_back.BackColor = Color.Transparent;
            btn_assign_back.Location = new Point(1551, 913);
            btn_assign_back.Margin = new Padding(2, 2, 2, 2);
            btn_assign_back.Name = "btn_assign_back";
            btn_assign_back.Size = new Size(216, 75);
            btn_assign_back.TabIndex = 18;
            btn_assign_back.Click += btn_assign_back_Click;
            // 
            // AssignLaboratoryTest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_assign_back);
            Controls.Add(btn_assign_clear);
            Controls.Add(btn_assign_save);
            Controls.Add(txt_assign_remarks);
            Controls.Add(txt_assign_fee);
            Controls.Add(dtp_assign);
            Controls.Add(cb_labtest);
            Controls.Add(lbl_assign_specialty);
            Controls.Add(lbl_assign_doctorname);
            Controls.Add(lbl_assign_room);
            Controls.Add(lbl_assign_patientname);
            Margin = new Padding(2, 2, 2, 2);
            Name = "AssignLaboratoryTest";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_assign_patientname;
        private Label lbl_assign_room;
        private Label lbl_assign_doctorname;
        private Label lbl_assign_specialty;
        private ComboBox cb_labtest;
        private DateTimePicker dtp_assign;
        private TextBox txt_assign_fee;
        private TextBox txt_assign_remarks;
        private Panel btn_assign_save;
        private Panel btn_assign_clear;
        private Panel btn_assign_back;
    }
}
