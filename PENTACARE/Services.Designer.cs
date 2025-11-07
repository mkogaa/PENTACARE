namespace PENTACARE
{
    partial class Services
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Services));
            btn_addService = new Panel();
            btn_back = new Panel();
            dgvService = new DataGridView();
            label1 = new Label();
            txtSearch = new TextBox();
            btn_updateS = new Panel();
            btn_deleteS = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvService).BeginInit();
            SuspendLayout();
            // 
            // btn_addService
            // 
            btn_addService.BackColor = Color.Transparent;
            btn_addService.Location = new Point(162, 863);
            btn_addService.Name = "btn_addService";
            btn_addService.Size = new Size(250, 49);
            btn_addService.TabIndex = 0;
            btn_addService.Click += btn_addService_Click;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.Transparent;
            btn_back.Location = new Point(1583, 863);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(177, 49);
            btn_back.TabIndex = 1;
            btn_back.Click += btn_back_Click;
            // 
            // dgvService
            // 
            dgvService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvService.Location = new Point(166, 371);
            dgvService.Name = "dgvService";
            dgvService.RowHeadersWidth = 51;
            dgvService.Size = new Size(1598, 407);
            dgvService.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(143, 176);
            label1.Name = "label1";
            label1.Size = new Size(217, 25);
            label1.TabIndex = 3;
            label1.Text = "Search by Service Name";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Location = new Point(153, 236);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(1091, 20);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btn_updateS
            // 
            btn_updateS.BackColor = Color.Transparent;
            btn_updateS.Location = new Point(503, 863);
            btn_updateS.Name = "btn_updateS";
            btn_updateS.Size = new Size(208, 49);
            btn_updateS.TabIndex = 1;
            btn_updateS.Click += btn_updateS_Click;
            // 
            // btn_deleteS
            // 
            btn_deleteS.BackColor = Color.Transparent;
            btn_deleteS.Location = new Point(811, 863);
            btn_deleteS.Name = "btn_deleteS";
            btn_deleteS.Size = new Size(208, 49);
            btn_deleteS.TabIndex = 2;
            btn_deleteS.Click += btn_deleteS_Click;
            // 
            // Services
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_deleteS);
            Controls.Add(btn_updateS);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(dgvService);
            Controls.Add(btn_back);
            Controls.Add(btn_addService);
            Name = "Services";
            Text = "Services";
            Load += Services_Load;
            ((System.ComponentModel.ISupportInitialize)dgvService).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel btn_addService;
        private Panel btn_back;
        private DataGridView dgvService;
        private Label label1;
        private TextBox txtSearch;
        private Panel btn_updateS;
        private Panel btn_deleteS;
    }
}