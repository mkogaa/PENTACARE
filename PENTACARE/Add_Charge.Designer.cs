namespace PENTACARE
{
    partial class Add_Charge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Charge));
            cbCType = new ComboBox();
            cbService = new ComboBox();
            txtAmount = new TextBox();
            btn_Add = new Panel();
            txtQD = new TextBox();
            SuspendLayout();
            // 
            // cbCType
            // 
            cbCType.FormattingEnabled = true;
            cbCType.Items.AddRange(new object[] { "Laboratory", "Medicine", "Other Services" });
            cbCType.Location = new Point(517, 388);
            cbCType.Name = "cbCType";
            cbCType.Size = new Size(151, 28);
            cbCType.TabIndex = 0;
            cbCType.SelectedIndexChanged += cbCType_SelectedIndexChanged;
            // 
            // cbService
            // 
            cbService.FormattingEnabled = true;
            cbService.Location = new Point(401, 461);
            cbService.Name = "cbService";
            cbService.Size = new Size(151, 28);
            cbService.TabIndex = 1;
            cbService.SelectedIndexChanged += cbService_SelectedIndexChanged;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(427, 534);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(125, 27);
            txtAmount.TabIndex = 3;
            // 
            // btn_Add
            // 
            btn_Add.Location = new Point(202, 748);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(250, 125);
            btn_Add.TabIndex = 4;
            btn_Add.Click += btn_Add_Click;
            btn_Add.Paint += btn_Add_Paint;
            // 
            // txtQD
            // 
            txtQD.Location = new Point(603, 618);
            txtQD.Name = "txtQD";
            txtQD.Size = new Size(125, 27);
            txtQD.TabIndex = 5;
            // 
            // Add_Charge
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(txtQD);
            Controls.Add(btn_Add);
            Controls.Add(txtAmount);
            Controls.Add(cbService);
            Controls.Add(cbCType);
            Name = "Add_Charge";
            Text = "Add_Charge";
            Load += Add_Charge_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbCType;
        private ComboBox cbService;
        private TextBox txtAmount;
        private Panel btn_Add;
        private TextBox txtQD;
    }
}