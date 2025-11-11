namespace PENTACARE
{
    partial class ViewBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewBill));
            dgvBill = new DataGridView();
            lblRFee = new Label();
            lblRType = new Label();
            lblRID = new Label();
            lblRN = new Label();
            lblDD = new Label();
            lblAD = new Label();
            lblPID = new Label();
            lblName = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBill).BeginInit();
            SuspendLayout();
            // 
            // dgvBill
            // 
            dgvBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBill.Location = new Point(223, 637);
            dgvBill.Name = "dgvBill";
            dgvBill.RowHeadersWidth = 51;
            dgvBill.Size = new Size(1449, 188);
            dgvBill.TabIndex = 0;
            // 
            // lblRFee
            // 
            lblRFee.AutoSize = true;
            lblRFee.Location = new Point(1477, 524);
            lblRFee.Name = "lblRFee";
            lblRFee.Size = new Size(50, 20);
            lblRFee.TabIndex = 15;
            lblRFee.Text = "label1";
            // 
            // lblRType
            // 
            lblRType.AutoSize = true;
            lblRType.Location = new Point(1477, 467);
            lblRType.Name = "lblRType";
            lblRType.Size = new Size(50, 20);
            lblRType.TabIndex = 14;
            lblRType.Text = "label1";
            // 
            // lblRID
            // 
            lblRID.AutoSize = true;
            lblRID.Location = new Point(1441, 402);
            lblRID.Name = "lblRID";
            lblRID.Size = new Size(50, 20);
            lblRID.TabIndex = 13;
            lblRID.Text = "label1";
            // 
            // lblRN
            // 
            lblRN.AutoSize = true;
            lblRN.Location = new Point(1601, 343);
            lblRN.Name = "lblRN";
            lblRN.Size = new Size(50, 20);
            lblRN.TabIndex = 12;
            lblRN.Text = "label1";
            // 
            // lblDD
            // 
            lblDD.AutoSize = true;
            lblDD.Location = new Point(588, 524);
            lblDD.Name = "lblDD";
            lblDD.Size = new Size(50, 20);
            lblDD.TabIndex = 11;
            lblDD.Text = "label1";
            // 
            // lblAD
            // 
            lblAD.AutoSize = true;
            lblAD.Location = new Point(588, 455);
            lblAD.Name = "lblAD";
            lblAD.Size = new Size(50, 20);
            lblAD.TabIndex = 10;
            lblAD.Text = "label1";
            // 
            // lblPID
            // 
            lblPID.AutoSize = true;
            lblPID.Location = new Point(566, 402);
            lblPID.Name = "lblPID";
            lblPID.Size = new Size(50, 20);
            lblPID.TabIndex = 9;
            lblPID.Text = "label1";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(755, 327);
            lblName.Name = "lblName";
            lblName.Size = new Size(50, 20);
            lblName.TabIndex = 8;
            lblName.Text = "label1";
            // 
            // ViewBill
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1902, 1033);
            Controls.Add(lblRFee);
            Controls.Add(lblRType);
            Controls.Add(lblRID);
            Controls.Add(lblRN);
            Controls.Add(lblDD);
            Controls.Add(lblAD);
            Controls.Add(lblPID);
            Controls.Add(lblName);
            Controls.Add(dgvBill);
            Name = "ViewBill";
            Text = "ViewBill";
            Load += ViewBill_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBill).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBill;
        private Label lblRFee;
        private Label lblRType;
        private Label lblRID;
        private Label lblRN;
        private Label lblDD;
        private Label lblAD;
        private Label lblPID;
        private Label lblName;
    }
}