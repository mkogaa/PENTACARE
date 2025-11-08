namespace USERS_WINDOW
{
    partial class AdmissionAndDischargeRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdmissionAndDischargeRecords));
            cb_filter_roomtype = new ComboBox();
            cb_filter_status = new ComboBox();
            dgv_personal = new DataGridView();
            btn_admission_exportreport = new Panel();
            btn_admission_back = new Panel();
            dgv_admission = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_personal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_admission).BeginInit();
            SuspendLayout();
            // 
            // cb_filter_roomtype
            // 
            cb_filter_roomtype.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_filter_roomtype.Font = new Font("Century Gothic", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_filter_roomtype.FormattingEnabled = true;
            cb_filter_roomtype.Location = new Point(597, 287);
            cb_filter_roomtype.Margin = new Padding(2, 2, 2, 2);
            cb_filter_roomtype.Name = "cb_filter_roomtype";
            cb_filter_roomtype.Size = new Size(268, 48);
            cb_filter_roomtype.TabIndex = 0;
            cb_filter_roomtype.SelectedIndexChanged += cb_filter_roomtype_SelectedIndexChanged;
            // 
            // cb_filter_status
            // 
            cb_filter_status.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_filter_status.Font = new Font("Century Gothic", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_filter_status.FormattingEnabled = true;
            cb_filter_status.Location = new Point(1408, 287);
            cb_filter_status.Margin = new Padding(2, 2, 2, 2);
            cb_filter_status.Name = "cb_filter_status";
            cb_filter_status.Size = new Size(268, 48);
            cb_filter_status.TabIndex = 1;
            // 
            // dgv_personal
            // 
            dgv_personal.AllowUserToAddRows = false;
            dgv_personal.AllowUserToDeleteRows = false;
            dgv_personal.BackgroundColor = Color.White;
            dgv_personal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_personal.Location = new Point(127, 501);
            dgv_personal.Margin = new Padding(2, 2, 2, 2);
            dgv_personal.Name = "dgv_personal";
            dgv_personal.ReadOnly = true;
            dgv_personal.RowHeadersWidth = 62;
            dgv_personal.Size = new Size(1646, 83);
            dgv_personal.TabIndex = 3;
            dgv_personal.CellContentClick += dgv_personal_CellContentClick;
            // 
            // btn_admission_exportreport
            // 
            btn_admission_exportreport.BackColor = Color.Transparent;
            btn_admission_exportreport.Location = new Point(127, 910);
            btn_admission_exportreport.Margin = new Padding(2, 2, 2, 2);
            btn_admission_exportreport.Name = "btn_admission_exportreport";
            btn_admission_exportreport.Size = new Size(331, 80);
            btn_admission_exportreport.TabIndex = 4;
            btn_admission_exportreport.Click += btn_admission_exportreport_Click;
            // 
            // btn_admission_back
            // 
            btn_admission_back.BackColor = Color.Transparent;
            btn_admission_back.Location = new Point(1577, 918);
            btn_admission_back.Margin = new Padding(2, 2, 2, 2);
            btn_admission_back.Name = "btn_admission_back";
            btn_admission_back.Size = new Size(196, 72);
            btn_admission_back.TabIndex = 5;
            btn_admission_back.Click += btn_admission_back_Click;
            // 
            // dgv_admission
            // 
            dgv_admission.AllowUserToAddRows = false;
            dgv_admission.AllowUserToDeleteRows = false;
            dgv_admission.BackgroundColor = Color.White;
            dgv_admission.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_admission.Location = new Point(127, 742);
            dgv_admission.Margin = new Padding(2, 2, 2, 2);
            dgv_admission.Name = "dgv_admission";
            dgv_admission.ReadOnly = true;
            dgv_admission.RowHeadersWidth = 62;
            dgv_admission.Size = new Size(1646, 83);
            dgv_admission.TabIndex = 6;
            // 
            // AdmissionAndDischargeRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(dgv_admission);
            Controls.Add(btn_admission_back);
            Controls.Add(btn_admission_exportreport);
            Controls.Add(dgv_personal);
            Controls.Add(cb_filter_status);
            Controls.Add(cb_filter_roomtype);
            Margin = new Padding(2, 2, 2, 2);
            Name = "AdmissionAndDischargeRecords";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgv_personal).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_admission).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cb_filter_roomtype;
        private ComboBox cb_filter_status;
        private DataGridView dgv_personal;
        private Panel btn_admission_exportreport;
        private Panel btn_admission_back;
        private DataGridView dgv_admission;
    }
}