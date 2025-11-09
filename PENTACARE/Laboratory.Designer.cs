namespace PENTACARE
{
    partial class Laboratory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Laboratory));
            btn_addLab = new Panel();
            btn_backL = new Panel();
            dgvLaboratory = new DataGridView();
            txtSearch = new TextBox();
            label1 = new Label();
            btn_updateL = new Panel();
            btn_deleteL = new Panel();
            label2 = new Label();
            cbCategory = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvLaboratory).BeginInit();
            SuspendLayout();
            // 
            // btn_addLab
            // 
            btn_addLab.BackColor = Color.Transparent;
            btn_addLab.Location = new Point(150, 866);
            btn_addLab.Name = "btn_addLab";
            btn_addLab.Size = new Size(306, 46);
            btn_addLab.TabIndex = 0;
            btn_addLab.Click += btn_addLab_Click;
            // 
            // btn_backL
            // 
            btn_backL.BackColor = Color.Transparent;
            btn_backL.Location = new Point(1616, 866);
            btn_backL.Name = "btn_backL";
            btn_backL.Size = new Size(166, 46);
            btn_backL.TabIndex = 1;
            btn_backL.Click += btn_backL_Click;
            btn_backL.Paint += btn_backL_Paint;
            // 
            // dgvLaboratory
            // 
            dgvLaboratory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLaboratory.Location = new Point(180, 389);
            dgvLaboratory.Name = "dgvLaboratory";
            dgvLaboratory.RowHeadersWidth = 51;
            dgvLaboratory.Size = new Size(1598, 407);
            dgvLaboratory.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Location = new Point(161, 245);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(1091, 20);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(128, 185);
            label1.Name = "label1";
            label1.Size = new Size(249, 25);
            label1.TabIndex = 5;
            label1.Text = "Search by Laboratory Name";
            label1.Click += label1_Click;
            // 
            // btn_updateL
            // 
            btn_updateL.BackColor = Color.Transparent;
            btn_updateL.Location = new Point(566, 866);
            btn_updateL.Name = "btn_updateL";
            btn_updateL.Size = new Size(166, 46);
            btn_updateL.TabIndex = 2;
            btn_updateL.Click += btn_updateL_Click;
            btn_updateL.Paint += btn_updateL_Paint;
            // 
            // btn_deleteL
            // 
            btn_deleteL.BackColor = Color.Transparent;
            btn_deleteL.Location = new Point(867, 866);
            btn_deleteL.Name = "btn_deleteL";
            btn_deleteL.Size = new Size(166, 46);
            btn_deleteL.TabIndex = 3;
            btn_deleteL.Click += btn_deleteL_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.SteelBlue;
            label2.Location = new Point(1512, 185);
            label2.Name = "label2";
            label2.Size = new Size(164, 25);
            label2.TabIndex = 7;
            label2.Text = "Filter by Category";
            // 
            // cbCategory
            // 
            cbCategory.FlatStyle = FlatStyle.Flat;
            cbCategory.FormattingEnabled = true;
            cbCategory.Items.AddRange(new object[] { "All", "Laboratory Test", "Imaging", "Cardiology" });
            cbCategory.Location = new Point(1534, 245);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(266, 28);
            cbCategory.TabIndex = 8;
            cbCategory.SelectedIndexChanged += cbCategory_SelectedIndexChanged;
            // 
            // Laboratory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(cbCategory);
            Controls.Add(label2);
            Controls.Add(btn_deleteL);
            Controls.Add(btn_updateL);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(dgvLaboratory);
            Controls.Add(btn_backL);
            Controls.Add(btn_addLab);
            Name = "Laboratory";
            Text = "Laboratory";
            Load += Laboratory_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLaboratory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel btn_addLab;
        private Panel btn_backL;
        private DataGridView dgvLaboratory;
        private TextBox txtSearch;
        private Label label1;
        private Panel btn_updateL;
        private Panel btn_deleteL;
        private Label label2;
        private ComboBox cbCategory;
    }
}