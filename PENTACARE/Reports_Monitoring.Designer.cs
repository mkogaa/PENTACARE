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
            dgv_Record = new DataGridView();
            txtSearch = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            btn_AD = new Panel();
            btn_back = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgv_Record).BeginInit();
            SuspendLayout();
            // 
            // rb_PH
            // 
            rb_PH.AutoSize = true;
            rb_PH.BackColor = Color.Transparent;
            rb_PH.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rb_PH.ForeColor = Color.White;
            rb_PH.Location = new Point(712, 226);
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
            rb_PR.Location = new Point(959, 226);
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
            rb_BS.Location = new Point(1230, 226);
            rb_BS.Name = "rb_BS";
            rb_BS.Size = new Size(215, 35);
            rb_BS.TabIndex = 2;
            rb_BS.TabStop = true;
            rb_BS.Text = "Billing Summary";
            rb_BS.UseVisualStyleBackColor = false;
            rb_BS.CheckedChanged += rb_BS_CheckedChanged;
            // 
            // dgv_Record
            // 
            dgv_Record.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Record.Location = new Point(185, 454);
            dgv_Record.Name = "dgv_Record";
            dgv_Record.RowHeadersWidth = 51;
            dgv_Record.Size = new Size(1596, 328);
            dgv_Record.TabIndex = 5;
            dgv_Record.CellContentClick += dgv_Record_CellContentClick;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Location = new Point(535, 362);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(806, 20);
            txtSearch.TabIndex = 6;
            txtSearch.TextAlignChanged += txtSearch_TextAlignChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(145, 853);
            panel1.Name = "panel1";
            panel1.Size = new Size(160, 54);
            panel1.TabIndex = 7;
            panel1.Click += panel1_Click;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Location = new Point(390, 853);
            panel2.Name = "panel2";
            panel2.Size = new Size(160, 54);
            panel2.TabIndex = 8;
            panel2.Click += panel2_Click;
            // 
            // btn_AD
            // 
            btn_AD.BackColor = Color.Transparent;
            btn_AD.Location = new Point(637, 853);
            btn_AD.Name = "btn_AD";
            btn_AD.Size = new Size(583, 54);
            btn_AD.TabIndex = 9;
            btn_AD.Click += btn_AD_Click;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.Transparent;
            btn_back.Location = new Point(1611, 853);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(160, 54);
            btn_back.TabIndex = 9;
            btn_back.Click += btn_back_Click;
            // 
            // Reports_Monitoring
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_back);
            Controls.Add(btn_AD);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(txtSearch);
            Controls.Add(dgv_Record);
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
        private DataGridView dgv_Record;
        private TextBox txtSearch;
        private Panel panel1;
        private Panel panel2;
        private Panel btn_AD;
        private Panel btn_back;
    }
}