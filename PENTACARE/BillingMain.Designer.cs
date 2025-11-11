namespace PENTACARE
{
    partial class BillingMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillingMain));
            btn_backB = new Panel();
            dgvBilling = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBilling).BeginInit();
            SuspendLayout();
            // 
            // btn_backB
            // 
            btn_backB.BackColor = Color.Transparent;
            btn_backB.Location = new Point(1593, 868);
            btn_backB.Name = "btn_backB";
            btn_backB.Size = new Size(182, 45);
            btn_backB.TabIndex = 2;
            btn_backB.Click += btn_backB_Click;
            // 
            // dgvBilling
            // 
            dgvBilling.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBilling.Location = new Point(183, 420);
            dgvBilling.Name = "dgvBilling";
            dgvBilling.RowHeadersWidth = 51;
            dgvBilling.Size = new Size(1561, 355);
            dgvBilling.TabIndex = 3;
            dgvBilling.CellContentDoubleClick += dgvBilling_CellContentDoubleClick;
            // 
            // BillingMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(dgvBilling);
            Controls.Add(btn_backB);
            Name = "BillingMain";
            Text = "BillingMain";
            Load += BillingMain_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBilling).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel btn_backB;
        private DataGridView dgvBilling;
    }
}