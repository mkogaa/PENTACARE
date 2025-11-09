namespace USERS_WINDOW
{
    partial class MedicalRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedicalRecords));
            txtSearch = new TextBox();
            txtFilter = new ComboBox();
            dgvRecords = new DataGridView();
            btnRefresh = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRecords).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(78, 250);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(1101, 34);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // txtFilter
            // 
            txtFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            txtFilter.FlatStyle = FlatStyle.Flat;
            txtFilter.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilter.FormattingEnabled = true;
            txtFilter.Items.AddRange(new object[] { "Patient ID", "Name", "Diagnosis", "Room Number", "" });
            txtFilter.Location = new Point(1470, 249);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(311, 35);
            txtFilter.TabIndex = 8;
            // 
            // dgvRecords
            // 
            dgvRecords.BackgroundColor = SystemColors.ActiveCaption;
            dgvRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecords.GridColor = SystemColors.HotTrack;
            dgvRecords.Location = new Point(78, 359);
            dgvRecords.Name = "dgvRecords";
            dgvRecords.RowHeadersWidth = 51;
            dgvRecords.Size = new Size(1729, 512);
            dgvRecords.TabIndex = 5;
            dgvRecords.CellClick += dgvRecords_CellClick;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = SystemColors.ButtonFace;
            btnRefresh.Location = new Point(1427, 924);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(170, 58);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = SystemColors.ButtonFace;
            btnClose.Location = new Point(1648, 921);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(175, 61);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // MedicalRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(txtFilter);
            Controls.Add(btnClose);
            Controls.Add(btnRefresh);
            Controls.Add(txtSearch);
            Controls.Add(dgvRecords);
            Name = "MedicalRecords";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "c";
            Load += MedicalRecords_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRecords).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private ComboBox txtFilter;
        private DataGridView dgvRecords;
        private Button btnRefresh;
        private Button btnClose;
    }
}