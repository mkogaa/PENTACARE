namespace PENTACARE
{
    partial class Billing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Billing));
            lblName = new Label();
            lblPID = new Label();
            lblAD = new Label();
            lblDD = new Label();
            lblRN = new Label();
            lblRID = new Label();
            lblRType = new Label();
            lblRFee = new Label();
            dgvBill = new DataGridView();
            lblTotal = new Label();
            btn_back = new Panel();
            btn_addCharge = new Panel();
            btn_saveBill = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvBill).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.Location = new Point(657, 218);
            lblName.Name = "lblName";
            lblName.Size = new Size(97, 41);
            lblName.TabIndex = 0;
            lblName.Text = "label1";
            // 
            // lblPID
            // 
            lblPID.AutoSize = true;
            lblPID.BackColor = Color.Transparent;
            lblPID.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPID.Location = new Point(405, 271);
            lblPID.Name = "lblPID";
            lblPID.Size = new Size(97, 41);
            lblPID.TabIndex = 1;
            lblPID.Text = "label1";
            // 
            // lblAD
            // 
            lblAD.AutoSize = true;
            lblAD.BackColor = Color.Transparent;
            lblAD.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAD.Location = new Point(526, 335);
            lblAD.Name = "lblAD";
            lblAD.Size = new Size(97, 41);
            lblAD.TabIndex = 2;
            lblAD.Text = "label1";
            lblAD.Click += lblAD_Click;
            // 
            // lblDD
            // 
            lblDD.AutoSize = true;
            lblDD.BackColor = Color.Transparent;
            lblDD.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDD.Location = new Point(526, 404);
            lblDD.Name = "lblDD";
            lblDD.Size = new Size(97, 41);
            lblDD.TabIndex = 3;
            lblDD.Text = "label1";
            // 
            // lblRN
            // 
            lblRN.AutoSize = true;
            lblRN.BackColor = Color.Transparent;
            lblRN.Font = new Font("Segoe UI", 18F);
            lblRN.Location = new Point(1551, 204);
            lblRN.Name = "lblRN";
            lblRN.Size = new Size(97, 41);
            lblRN.TabIndex = 4;
            lblRN.Text = "label1";
            // 
            // lblRID
            // 
            lblRID.AutoSize = true;
            lblRID.BackColor = Color.Transparent;
            lblRID.Font = new Font("Segoe UI", 18F);
            lblRID.Location = new Point(1379, 282);
            lblRID.Name = "lblRID";
            lblRID.Size = new Size(97, 41);
            lblRID.TabIndex = 5;
            lblRID.Text = "label1";
            // 
            // lblRType
            // 
            lblRType.AutoSize = true;
            lblRType.BackColor = Color.Transparent;
            lblRType.Font = new Font("Segoe UI", 18F);
            lblRType.Location = new Point(1415, 338);
            lblRType.Name = "lblRType";
            lblRType.Size = new Size(97, 41);
            lblRType.TabIndex = 6;
            lblRType.Text = "label1";
            // 
            // lblRFee
            // 
            lblRFee.AutoSize = true;
            lblRFee.BackColor = Color.Transparent;
            lblRFee.Font = new Font("Segoe UI", 18F);
            lblRFee.Location = new Point(1415, 400);
            lblRFee.Name = "lblRFee";
            lblRFee.Size = new Size(97, 41);
            lblRFee.TabIndex = 7;
            lblRFee.Text = "label1";
            // 
            // dgvBill
            // 
            dgvBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBill.Location = new Point(231, 530);
            dgvBill.Name = "dgvBill";
            dgvBill.RowHeadersWidth = 51;
            dgvBill.Size = new Size(1458, 188);
            dgvBill.TabIndex = 8;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.Transparent;
            lblTotal.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(1481, 756);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(120, 50);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "label1";
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.Transparent;
            btn_back.Location = new Point(1508, 843);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(250, 125);
            btn_back.TabIndex = 10;
            btn_back.Click += btn_back_Click;
            // 
            // btn_addCharge
            // 
            btn_addCharge.BackColor = Color.Transparent;
            btn_addCharge.Location = new Point(147, 794);
            btn_addCharge.Name = "btn_addCharge";
            btn_addCharge.Size = new Size(334, 125);
            btn_addCharge.TabIndex = 11;
            btn_addCharge.Click += btn_addCharge_Click;
            // 
            // btn_saveBill
            // 
            btn_saveBill.BackColor = Color.Transparent;
            btn_saveBill.Location = new Point(511, 781);
            btn_saveBill.Name = "btn_saveBill";
            btn_saveBill.Size = new Size(286, 125);
            btn_saveBill.TabIndex = 12;
            btn_saveBill.Click += btn_saveBill_Click;
            // 
            // Billing
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_saveBill);
            Controls.Add(btn_addCharge);
            Controls.Add(btn_back);
            Controls.Add(lblTotal);
            Controls.Add(dgvBill);
            Controls.Add(lblRFee);
            Controls.Add(lblRType);
            Controls.Add(lblRID);
            Controls.Add(lblRN);
            Controls.Add(lblDD);
            Controls.Add(lblAD);
            Controls.Add(lblPID);
            Controls.Add(lblName);
            Name = "Billing";
            Text = "Billing";
            Load += Billing_Load;
            Click += Billing_Click;
            ((System.ComponentModel.ISupportInitialize)dgvBill).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblPID;
        private Label lblAD;
        private Label lblDD;
        private Label lblRN;
        private Label lblRID;
        private Label lblRType;
        private Label lblRFee;
        private DataGridView dgvBill;
        private Label lblTotal;
        private Panel btn_back;
        private Panel btn_addCharge;
        private Panel btn_saveBill;
    }
}