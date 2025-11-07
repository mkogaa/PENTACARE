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
            btn_roomfee = new Panel();
            btn_labfee = new Panel();
            btn_servicefee = new Panel();
            btn_backB = new Panel();
            SuspendLayout();
            // 
            // btn_roomfee
            // 
            btn_roomfee.BackColor = Color.Transparent;
            btn_roomfee.Location = new Point(487, 868);
            btn_roomfee.Name = "btn_roomfee";
            btn_roomfee.Size = new Size(187, 45);
            btn_roomfee.TabIndex = 0;
            // 
            // btn_labfee
            // 
            btn_labfee.BackColor = Color.Transparent;
            btn_labfee.Location = new Point(751, 868);
            btn_labfee.Name = "btn_labfee";
            btn_labfee.Size = new Size(180, 45);
            btn_labfee.TabIndex = 1;
            btn_labfee.Click += btn_labfee_Click;
            // 
            // btn_servicefee
            // 
            btn_servicefee.BackColor = Color.Transparent;
            btn_servicefee.Location = new Point(1002, 868);
            btn_servicefee.Name = "btn_servicefee";
            btn_servicefee.Size = new Size(216, 45);
            btn_servicefee.TabIndex = 1;
            btn_servicefee.Click += btn_servicefee_Click;
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
            // BillingMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_backB);
            Controls.Add(btn_servicefee);
            Controls.Add(btn_labfee);
            Controls.Add(btn_roomfee);
            Name = "BillingMain";
            Text = "BillingMain";
            ResumeLayout(false);
        }

        #endregion

        private Panel btn_roomfee;
        private Panel btn_labfee;
        private Panel btn_servicefee;
        private Panel btn_backB;
    }
}