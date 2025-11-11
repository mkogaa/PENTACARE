namespace PENTACARE
{
    partial class LabMed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabMed));
            backBtn = new Panel();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            labSearcg = new TextBox();
            medSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // backBtn
            // 
            backBtn.BackColor = Color.Transparent;
            backBtn.Location = new Point(1548, 903);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(264, 69);
            backBtn.TabIndex = 0;
            backBtn.Click += backBtn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(194, 324);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1572, 202);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(164, 663);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1628, 202);
            dataGridView2.TabIndex = 2;
            // 
            // labSearcg
            // 
            labSearcg.BorderStyle = BorderStyle.None;
            labSearcg.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labSearcg.Location = new Point(877, 220);
            labSearcg.Name = "labSearcg";
            labSearcg.PlaceholderText = "Search by Lab Text, Result...";
            labSearcg.Size = new Size(840, 36);
            labSearcg.TabIndex = 3;
            labSearcg.TextChanged += labSearcg_TextChanged;
            // 
            // medSearch
            // 
            medSearch.BorderStyle = BorderStyle.None;
            medSearch.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            medSearch.Location = new Point(877, 578);
            medSearch.Name = "medSearch";
            medSearch.PlaceholderText = "Search by RecordID, Medication, Allergies, Diagnosis...";
            medSearch.Size = new Size(840, 36);
            medSearch.TabIndex = 4;
            medSearch.TextChanged += medSearch_TextChanged;
            // 
            // LabMed
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(medSearch);
            Controls.Add(labSearcg);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(backBtn);
            Name = "LabMed";
            Text = "LabMed";
            WindowState = FormWindowState.Maximized;
            Load += LabMed_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel backBtn;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private TextBox labSearcg;
        private TextBox medSearch;
    }
}