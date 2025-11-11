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
            lblName.Location = new Point(693, 228);
            lblName.Name = "lblName";
            lblName.Size = new Size(50, 20);
            lblName.TabIndex = 0;
            lblName.Text = "label1";
            // 
            // lblPID
            // 
            lblPID.AutoSize = true;
            lblPID.Location = new Point(504, 303);
            lblPID.Name = "lblPID";
            lblPID.Size = new Size(50, 20);
            lblPID.TabIndex = 1;
            lblPID.Text = "label1";
            // 
            // lblAD
            // 
            lblAD.AutoSize = true;
            lblAD.Location = new Point(526, 356);
            lblAD.Name = "lblAD";
            lblAD.Size = new Size(50, 20);
            lblAD.TabIndex = 2;
            lblAD.Text = "label1";
            // 
            // lblDD
            // 
            lblDD.AutoSize = true;
            lblDD.Location = new Point(526, 425);
            lblDD.Name = "lblDD";
            lblDD.Size = new Size(50, 20);
            lblDD.TabIndex = 3;
            lblDD.Text = "label1";
            // 
            // lblRN
            // 
            lblRN.AutoSize = true;
            lblRN.Location = new Point(1539, 244);
            lblRN.Name = "lblRN";
            lblRN.Size = new Size(50, 20);
            lblRN.TabIndex = 4;
            lblRN.Text = "label1";
            // 
            // lblRID
            // 
            lblRID.AutoSize = true;
            lblRID.Location = new Point(1379, 303);
            lblRID.Name = "lblRID";
            lblRID.Size = new Size(50, 20);
            lblRID.TabIndex = 5;
            lblRID.Text = "label1";
            // 
            // lblRType
            // 
            lblRType.AutoSize = true;
            lblRType.Location = new Point(1415, 368);
            lblRType.Name = "lblRType";
            lblRType.Size = new Size(50, 20);
            lblRType.TabIndex = 6;
            lblRType.Text = "label1";
            // 
            // lblRFee
            // 
            lblRFee.AutoSize = true;
            lblRFee.Location = new Point(1415, 425);
            lblRFee.Name = "lblRFee";
            lblRFee.Size = new Size(50, 20);
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
            lblTotal.Location = new Point(1498, 804);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(50, 20);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "label1";
            // 
            // btn_back
            // 
            btn_back.Location = new Point(1489, 872);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(250, 125);
            btn_back.TabIndex = 10;
            btn_back.Click += btn_back_Click;
            // 
            // btn_addCharge
            // 
            btn_addCharge.Location = new Point(192, 813);
            btn_addCharge.Name = "btn_addCharge";
            btn_addCharge.Size = new Size(250, 125);
            btn_addCharge.TabIndex = 11;
            btn_addCharge.Click += btn_addCharge_Click;
            // 
            // btn_saveBill
            // 
            btn_saveBill.Location = new Point(526, 781);
            btn_saveBill.Name = "btn_saveBill";
            btn_saveBill.Size = new Size(250, 125);
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