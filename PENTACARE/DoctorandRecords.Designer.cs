namespace PentaCare
{
    partial class DoctorandRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorandRecords));
            docRecords = new DataGridView();
            dataGridView1 = new DataGridView();
            assignBtn = new Panel();
            addDocBtn = new Panel();
            editBtn = new Panel();
            removeBtn = new Panel();
            cmbSpecialty = new ComboBox();
            searchTxt = new TextBox();
            btnSearch = new Panel();
            btn_back = new Panel();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)docRecords).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // docRecords
            // 
            docRecords.BorderStyle = BorderStyle.Fixed3D;
            docRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            docRecords.Location = new Point(184, 466);
            docRecords.Name = "docRecords";
            docRecords.RowHeadersWidth = 49;
            docRecords.Size = new Size(689, 306);
            docRecords.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1059, 466);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(719, 306);
            dataGridView1.TabIndex = 1;
            // 
            // assignBtn
            // 
            assignBtn.BackColor = Color.Transparent;
            assignBtn.Location = new Point(990, 893);
            assignBtn.Name = "assignBtn";
            assignBtn.Size = new Size(298, 56);
            assignBtn.TabIndex = 2;
            assignBtn.Click += assignBtn_Click;
            // 
            // addDocBtn
            // 
            addDocBtn.AccessibleDescription = "";
            addDocBtn.BackColor = Color.Transparent;
            addDocBtn.Location = new Point(133, 893);
            addDocBtn.Name = "addDocBtn";
            addDocBtn.Size = new Size(355, 55);
            addDocBtn.TabIndex = 3;
            addDocBtn.Click += addDocBtn_Click_1;
            // 
            // editBtn
            // 
            editBtn.BackColor = Color.Transparent;
            editBtn.Location = new Point(520, 892);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(163, 57);
            editBtn.TabIndex = 4;
            editBtn.Click += editBtn_Click;
            // 
            // removeBtn
            // 
            removeBtn.BackColor = Color.Transparent;
            removeBtn.Location = new Point(710, 892);
            removeBtn.Name = "removeBtn";
            removeBtn.Size = new Size(213, 59);
            removeBtn.TabIndex = 5;
            removeBtn.Click += removeBtn_Click;
            removeBtn.Paint += removeBtn_Paint;
            // 
            // cmbSpecialty
            // 
            cmbSpecialty.BackColor = Color.White;
            cmbSpecialty.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpecialty.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSpecialty.FormattingEnabled = true;
            cmbSpecialty.Items.AddRange(new object[] { "All", "Cardiology", "Neurology", "Pediatrics", "Orthopedics", "Dermatology", "General Surgery", "Obstetrics and Gynecology", "Psychiatry", "Internal Medicine", "Ophthalmology" });
            cmbSpecialty.Location = new Point(1450, 237);
            cmbSpecialty.Name = "cmbSpecialty";
            cmbSpecialty.Size = new Size(318, 39);
            cmbSpecialty.TabIndex = 6;
            cmbSpecialty.SelectedIndexChanged += cmbSpecialty_SelectedIndexChanged;
            // 
            // searchTxt
            // 
            searchTxt.BorderStyle = BorderStyle.None;
            searchTxt.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchTxt.Location = new Point(179, 226);
            searchTxt.Name = "searchTxt";
            searchTxt.PlaceholderText = "Search by Name, Doctor ID...";
            searchTxt.Size = new Size(1090, 36);
            searchTxt.TabIndex = 7;
            searchTxt.TextChanged += textBox1_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Transparent;
            btnSearch.Location = new Point(1279, 223);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(93, 67);
            btnSearch.TabIndex = 8;
            btnSearch.Click += btnSearch_Click;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.Transparent;
            btn_back.Location = new Point(1546, 895);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(232, 56);
            btn_back.TabIndex = 3;
            btn_back.Click += btn_back_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.White;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "All" });
            comboBox1.Location = new Point(1375, 790);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(318, 39);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // DoctorandRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(comboBox1);
            Controls.Add(btn_back);
            Controls.Add(btnSearch);
            Controls.Add(searchTxt);
            Controls.Add(cmbSpecialty);
            Controls.Add(removeBtn);
            Controls.Add(editBtn);
            Controls.Add(addDocBtn);
            Controls.Add(assignBtn);
            Controls.Add(dataGridView1);
            Controls.Add(docRecords);
            Name = "DoctorandRecords";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DoctorandRecords";
            Load += DoctorandRecords_Load;
            ((System.ComponentModel.ISupportInitialize)docRecords).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView docRecords;
        private DataGridView dataGridView1;
        private Panel assignBtn;
        private Panel addDocBtn;
        private Panel editBtn;
        private Panel removeBtn;
        private ComboBox cmbSpecialty;
        private TextBox searchTxt;
        private Panel btnSearch;
        private Panel btn_back;
        private ComboBox comboBox1;
    }
}