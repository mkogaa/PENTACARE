namespace PENTACARE
{
    partial class Reports_Monitoring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports_Monitoring));
            rb_PH = new RadioButton();
            rb_PR = new RadioButton();
            rb_BS = new RadioButton();
            dateFrom = new DateTimePicker();
            dateTo = new DateTimePicker();
            dgv_Record = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_Record).BeginInit();
            SuspendLayout();
            // 
            // rb_PH
            // 
            rb_PH.AutoSize = true;
            rb_PH.BackColor = Color.Transparent;
            rb_PH.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rb_PH.ForeColor = Color.White;
            rb_PH.Location = new Point(715, 211);
            rb_PH.Name = "rb_PH";
            rb_PH.Size = new Size(197, 35);
            rb_PH.TabIndex = 0;
            rb_PH.TabStop = true;
            rb_PH.Text = "Patient History";
            rb_PH.UseVisualStyleBackColor = false;
            rb_PH.CheckedChanged += rb_PH_CheckedChanged;
            // 
            // rb_PR
            // 
            rb_PR.AutoSize = true;
            rb_PR.BackColor = Color.Transparent;
            rb_PR.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rb_PR.ForeColor = Color.White;
            rb_PR.Location = new Point(962, 211);
            rb_PR.Name = "rb_PR";
            rb_PR.Size = new Size(215, 35);
            rb_PR.TabIndex = 1;
            rb_PR.TabStop = true;
            rb_PR.Text = "Physician Report";
            rb_PR.UseVisualStyleBackColor = false;
            rb_PR.CheckedChanged += rb_PR_CheckedChanged;
            // 
            // rb_BS
            // 
            rb_BS.AutoSize = true;
            rb_BS.BackColor = Color.Transparent;
            rb_BS.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rb_BS.ForeColor = Color.White;
            rb_BS.Location = new Point(1233, 211);
            rb_BS.Name = "rb_BS";
            rb_BS.Size = new Size(215, 35);
            rb_BS.TabIndex = 2;
            rb_BS.TabStop = true;
            rb_BS.Text = "Billing Summary";
            rb_BS.UseVisualStyleBackColor = false;
            rb_BS.CheckedChanged += rb_BS_CheckedChanged;
            // 
            // dateFrom
            // 
            dateFrom.Location = new Point(396, 293);
            dateFrom.Name = "dateFrom";
            dateFrom.Size = new Size(250, 27);
            dateFrom.TabIndex = 3;
            // 
            // dateTo
            // 
            dateTo.Location = new Point(682, 293);
            dateTo.Name = "dateTo";
            dateTo.Size = new Size(250, 27);
            dateTo.TabIndex = 4;
            // 
            // dgv_Record
            // 
            dgv_Record.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Record.Location = new Point(175, 472);
            dgv_Record.Name = "dgv_Record";
            dgv_Record.RowHeadersWidth = 51;
            dgv_Record.Size = new Size(1596, 328);
            dgv_Record.TabIndex = 5;
            dgv_Record.CellContentClick += dgv_Record_CellContentClick;
            // 
            // Reports_Monitoring
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(dgv_Record);
            Controls.Add(dateTo);
            Controls.Add(dateFrom);
            Controls.Add(rb_BS);
            Controls.Add(rb_PR);
            Controls.Add(rb_PH);
            Name = "Reports_Monitoring";
            Text = "Reports_Monitoring";
            Load += Reports_Monitoring_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Record).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rb_PH;
        private RadioButton rb_PR;
        private RadioButton rb_BS;
        private DateTimePicker dateFrom;
        private DateTimePicker dateTo;
        private DataGridView dgv_Record;
    }
}