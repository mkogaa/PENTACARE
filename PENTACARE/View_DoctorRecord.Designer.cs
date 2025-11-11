namespace PENTACARE
{
    partial class View_DoctorRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_DoctorRecord));
            dgv_DR = new DataGridView();
            lblDI = new Label();
            lblEmail = new Label();
            lblName = new Label();
            lblSpecialty = new Label();
            lblCN = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_DR).BeginInit();
            SuspendLayout();
            // 
            // dgv_DR
            // 
            dgv_DR.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_DR.Location = new Point(175, 461);
            dgv_DR.Name = "dgv_DR";
            dgv_DR.RowHeadersWidth = 51;
            dgv_DR.Size = new Size(1543, 298);
            dgv_DR.TabIndex = 0;
            // 
            // lblDI
            // 
            lblDI.AutoSize = true;
            lblDI.BackColor = Color.Transparent;
            lblDI.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDI.ForeColor = Color.DarkBlue;
            lblDI.Location = new Point(515, 205);
            lblDI.Name = "lblDI";
            lblDI.Size = new Size(117, 46);
            lblDI.TabIndex = 1;
            lblDI.Text = "label1";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.DarkBlue;
            lblEmail.Location = new Point(1355, 205);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(117, 46);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "label1";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.DarkBlue;
            lblName.Location = new Point(401, 280);
            lblName.Name = "lblName";
            lblName.Size = new Size(96, 38);
            lblName.TabIndex = 3;
            lblName.Text = "label1";
            // 
            // lblSpecialty
            // 
            lblSpecialty.AutoSize = true;
            lblSpecialty.BackColor = Color.Transparent;
            lblSpecialty.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSpecialty.ForeColor = Color.DarkBlue;
            lblSpecialty.Location = new Point(464, 344);
            lblSpecialty.Name = "lblSpecialty";
            lblSpecialty.Size = new Size(96, 38);
            lblSpecialty.TabIndex = 4;
            lblSpecialty.Text = "label1";
            // 
            // lblCN
            // 
            lblCN.AutoSize = true;
            lblCN.BackColor = Color.Transparent;
            lblCN.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCN.ForeColor = Color.DarkBlue;
            lblCN.Location = new Point(1428, 280);
            lblCN.Name = "lblCN";
            lblCN.Size = new Size(96, 38);
            lblCN.TabIndex = 5;
            lblCN.Text = "label1";
            // 
            // View_DoctorRecord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(lblCN);
            Controls.Add(lblSpecialty);
            Controls.Add(lblName);
            Controls.Add(lblEmail);
            Controls.Add(lblDI);
            Controls.Add(dgv_DR);
            Name = "View_DoctorRecord";
            Text = "View_DoctorRecord";
            Load += View_DoctorRecord_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_DR).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_DR;
        private Label lblDI;
        private Label lblEmail;
        private Label lblName;
        private Label lblSpecialty;
        private Label lblCN;
    }
}