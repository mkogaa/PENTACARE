namespace USERS_WINDOW
{
    partial class LaboratoryRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaboratoryRecord));
            btn_record_back = new FlowLayoutPanel();
            dgv_laboratoryrecord = new DataGridView();
            txt_record_search = new TextBox();
            lbl_record_patientname = new Label();
            btn_record_printreport = new Panel();
            lbl_record_room = new Label();
            lbl_record_doctorname = new Label();
            lbl_record_specialty = new Label();
            cb_record = new ComboBox();
            btn_record_assigntest = new Panel();
            btn_record_complete = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgv_laboratoryrecord).BeginInit();
            SuspendLayout();
            // 
            // btn_record_back
            // 
            btn_record_back.BackColor = Color.Transparent;
            btn_record_back.Location = new Point(1551, 915);
            btn_record_back.Margin = new Padding(2, 2, 2, 2);
            btn_record_back.Name = "btn_record_back";
            btn_record_back.Size = new Size(219, 75);
            btn_record_back.TabIndex = 2;
            btn_record_back.Click += btn_record_back_Click;
            // 
            // dgv_laboratoryrecord
            // 
            dgv_laboratoryrecord.AllowUserToAddRows = false;
            dgv_laboratoryrecord.AllowUserToDeleteRows = false;
            dgv_laboratoryrecord.BackgroundColor = Color.White;
            dgv_laboratoryrecord.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_laboratoryrecord.Location = new Point(179, 519);
            dgv_laboratoryrecord.Margin = new Padding(2, 2, 2, 2);
            dgv_laboratoryrecord.Name = "dgv_laboratoryrecord";
            dgv_laboratoryrecord.ReadOnly = true;
            dgv_laboratoryrecord.RowHeadersWidth = 62;
            dgv_laboratoryrecord.Size = new Size(1554, 329);
            dgv_laboratoryrecord.TabIndex = 3;
            // 
            // txt_record_search
            // 
            txt_record_search.BorderStyle = BorderStyle.None;
            txt_record_search.Location = new Point(216, 425);
            txt_record_search.Margin = new Padding(2, 2, 2, 2);
            txt_record_search.Multiline = true;
            txt_record_search.Name = "txt_record_search";
            txt_record_search.Size = new Size(1014, 52);
            txt_record_search.TabIndex = 4;
            txt_record_search.KeyDown += txt_record_search_KeyDown;
            // 
            // lbl_record_patientname
            // 
            lbl_record_patientname.AutoSize = true;
            lbl_record_patientname.BackColor = Color.White;
            lbl_record_patientname.Font = new Font("Century Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_record_patientname.ForeColor = Color.MidnightBlue;
            lbl_record_patientname.Location = new Point(638, 234);
            lbl_record_patientname.Margin = new Padding(2, 0, 2, 0);
            lbl_record_patientname.Name = "lbl_record_patientname";
            lbl_record_patientname.Size = new Size(118, 40);
            lbl_record_patientname.TabIndex = 5;
            lbl_record_patientname.Text = "label1";
            // 
            // btn_record_printreport
            // 
            btn_record_printreport.BackColor = Color.Transparent;
            btn_record_printreport.Location = new Point(144, 916);
            btn_record_printreport.Margin = new Padding(2, 2, 2, 2);
            btn_record_printreport.Name = "btn_record_printreport";
            btn_record_printreport.Size = new Size(577, 74);
            btn_record_printreport.TabIndex = 7;
            btn_record_printreport.Click += btn_record_printreport_Click;
            // 
            // lbl_record_room
            // 
            lbl_record_room.AutoSize = true;
            lbl_record_room.BackColor = Color.White;
            lbl_record_room.Font = new Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_record_room.Location = new Point(429, 281);
            lbl_record_room.Margin = new Padding(2, 0, 2, 0);
            lbl_record_room.Name = "lbl_record_room";
            lbl_record_room.Size = new Size(84, 28);
            lbl_record_room.TabIndex = 8;
            lbl_record_room.Text = "label1";
            // 
            // lbl_record_doctorname
            // 
            lbl_record_doctorname.AutoSize = true;
            lbl_record_doctorname.BackColor = Color.White;
            lbl_record_doctorname.Font = new Font("Century Gothic", 20F, FontStyle.Bold);
            lbl_record_doctorname.ForeColor = Color.MidnightBlue;
            lbl_record_doctorname.Location = new Point(1423, 234);
            lbl_record_doctorname.Margin = new Padding(2, 0, 2, 0);
            lbl_record_doctorname.Name = "lbl_record_doctorname";
            lbl_record_doctorname.Size = new Size(118, 40);
            lbl_record_doctorname.TabIndex = 9;
            lbl_record_doctorname.Text = "label1";
            // 
            // lbl_record_specialty
            // 
            lbl_record_specialty.AutoSize = true;
            lbl_record_specialty.BackColor = Color.White;
            lbl_record_specialty.Font = new Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_record_specialty.ForeColor = Color.Black;
            lbl_record_specialty.Location = new Point(1110, 277);
            lbl_record_specialty.Margin = new Padding(2, 0, 2, 0);
            lbl_record_specialty.Name = "lbl_record_specialty";
            lbl_record_specialty.Size = new Size(94, 32);
            lbl_record_specialty.TabIndex = 10;
            lbl_record_specialty.Text = "label1";
            // 
            // cb_record
            // 
            cb_record.BackColor = Color.White;
            cb_record.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_record.Font = new Font("Century Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_record.FormattingEnabled = true;
            cb_record.Location = new Point(1368, 443);
            cb_record.Margin = new Padding(2, 2, 2, 2);
            cb_record.Name = "cb_record";
            cb_record.Size = new Size(312, 41);
            cb_record.TabIndex = 11;
            cb_record.SelectedIndexChanged += cb_record_SelectedIndexChanged_1;
            // 
            // btn_record_assigntest
            // 
            btn_record_assigntest.BackColor = Color.Transparent;
            btn_record_assigntest.Location = new Point(782, 916);
            btn_record_assigntest.Margin = new Padding(2, 2, 2, 2);
            btn_record_assigntest.Name = "btn_record_assigntest";
            btn_record_assigntest.Size = new Size(237, 74);
            btn_record_assigntest.TabIndex = 12;
            btn_record_assigntest.Click += btn_record_assigntest_Click_1;
            // 
            // btn_record_complete
            // 
            btn_record_complete.BackColor = Color.Transparent;
            btn_record_complete.Location = new Point(1086, 915);
            btn_record_complete.Margin = new Padding(2, 2, 2, 2);
            btn_record_complete.Name = "btn_record_complete";
            btn_record_complete.Size = new Size(229, 75);
            btn_record_complete.TabIndex = 13;
            // 
            // LaboratoryRecord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_record_complete);
            Controls.Add(btn_record_assigntest);
            Controls.Add(cb_record);
            Controls.Add(lbl_record_specialty);
            Controls.Add(lbl_record_doctorname);
            Controls.Add(lbl_record_room);
            Controls.Add(btn_record_printreport);
            Controls.Add(lbl_record_patientname);
            Controls.Add(txt_record_search);
            Controls.Add(dgv_laboratoryrecord);
            Controls.Add(btn_record_back);
            Margin = new Padding(2, 2, 2, 2);
            Name = "LaboratoryRecord";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgv_laboratoryrecord).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel btn_record_back;
        private DataGridView dgv_laboratoryrecord;
        private TextBox txt_record_search;
        private Label lbl_record_patientname;
        private Panel btn_record_printreport;
        private Label lbl_record_room;
        private Label lbl_record_doctorname;
        private Label lbl_record_specialty;
        private ComboBox cb_record;
        private Panel btn_record_assigntest;
        private Panel btn_record_complete;
    }
}