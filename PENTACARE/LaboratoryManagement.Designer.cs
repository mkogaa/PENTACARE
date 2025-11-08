namespace USERS_WINDOW
{
    partial class LaboratoryManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaboratoryManagement));
            dgv_laboratory = new DataGridView();
            btn_laboratory_back = new FlowLayoutPanel();
            txt_laboratory_search = new TextBox();
            btn_laboratory_discharge = new Panel();
            cb_laboratory = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgv_laboratory).BeginInit();
            SuspendLayout();
            // 
            // dgv_laboratory
            // 
            dgv_laboratory.AllowUserToAddRows = false;
            dgv_laboratory.AllowUserToDeleteRows = false;
            dgv_laboratory.BackgroundColor = Color.White;
            dgv_laboratory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_laboratory.Location = new Point(124, 375);
            dgv_laboratory.Margin = new Padding(2);
            dgv_laboratory.Name = "dgv_laboratory";
            dgv_laboratory.ReadOnly = true;
            dgv_laboratory.RowHeadersWidth = 62;
            dgv_laboratory.Size = new Size(1650, 430);
            dgv_laboratory.TabIndex = 0;
            // 
            // btn_laboratory_back
            // 
            btn_laboratory_back.BackColor = Color.Transparent;
            btn_laboratory_back.Location = new Point(1598, 928);
            btn_laboratory_back.Margin = new Padding(2);
            btn_laboratory_back.Name = "btn_laboratory_back";
            btn_laboratory_back.Size = new Size(189, 72);
            btn_laboratory_back.TabIndex = 1;
            btn_laboratory_back.Click += btn_laboratory_back_Click;
            // 
            // txt_laboratory_search
            // 
            txt_laboratory_search.BorderStyle = BorderStyle.None;
            txt_laboratory_search.Font = new Font("Century Gothic", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_laboratory_search.Location = new Point(124, 245);
            txt_laboratory_search.Margin = new Padding(2);
            txt_laboratory_search.Multiline = true;
            txt_laboratory_search.Name = "txt_laboratory_search";
            txt_laboratory_search.Size = new Size(1222, 40);
            txt_laboratory_search.TabIndex = 2;
            txt_laboratory_search.TextChanged += txt_laboratory_search_TextChanged;
            // 
            // btn_laboratory_discharge
            // 
            btn_laboratory_discharge.BackColor = Color.Transparent;
            btn_laboratory_discharge.Location = new Point(124, 928);
            btn_laboratory_discharge.Margin = new Padding(2);
            btn_laboratory_discharge.Name = "btn_laboratory_discharge";
            btn_laboratory_discharge.Size = new Size(240, 72);
            btn_laboratory_discharge.TabIndex = 4;
            btn_laboratory_discharge.Click += btn_laboratory_discharge_Click;
            // 
            // cb_laboratory
            // 
            cb_laboratory.BackColor = Color.White;
            cb_laboratory.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_laboratory.Font = new Font("Century Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_laboratory.FormattingEnabled = true;
            cb_laboratory.Items.AddRange(new object[] { "Discharged", "Admitted" });
            cb_laboratory.Location = new Point(1491, 256);
            cb_laboratory.Margin = new Padding(2);
            cb_laboratory.Name = "cb_laboratory";
            cb_laboratory.Size = new Size(296, 41);
            cb_laboratory.TabIndex = 5;
            // 
            // LaboratoryManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(cb_laboratory);
            Controls.Add(btn_laboratory_discharge);
            Controls.Add(txt_laboratory_search);
            Controls.Add(btn_laboratory_back);
            Controls.Add(dgv_laboratory);
            Margin = new Padding(2);
            Name = "LaboratoryManagement";
            WindowState = FormWindowState.Maximized;
            Load += LaboratoryManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_laboratory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_laboratory;
        private FlowLayoutPanel btn_laboratory_back;
        private TextBox txt_laboratory_search;
        private Panel btn_laboratory_discharge;
        private ComboBox cb_laboratory;
    }
}
