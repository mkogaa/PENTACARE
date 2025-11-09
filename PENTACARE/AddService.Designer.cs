namespace PENTACARE
{
    partial class AddService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddService));
            btn_backSS = new Panel();
            txt_serviceName = new TextBox();
            txt_Fee = new TextBox();
            cb_SType = new ComboBox();
            btn_saveService = new Panel();
            cbStatus = new ComboBox();
            btn_clear = new Panel();
            SuspendLayout();
            // 
            // btn_backSS
            // 
            btn_backSS.BackColor = Color.Transparent;
            btn_backSS.Location = new Point(1609, 782);
            btn_backSS.Name = "btn_backSS";
            btn_backSS.Size = new Size(180, 51);
            btn_backSS.TabIndex = 0;
            btn_backSS.Click += btn_backSS_Click;
            // 
            // txt_serviceName
            // 
            txt_serviceName.BackColor = Color.LightSteelBlue;
            txt_serviceName.Location = new Point(628, 390);
            txt_serviceName.Name = "txt_serviceName";
            txt_serviceName.Size = new Size(526, 27);
            txt_serviceName.TabIndex = 1;
            // 
            // txt_Fee
            // 
            txt_Fee.BackColor = Color.LightSteelBlue;
            txt_Fee.Location = new Point(628, 462);
            txt_Fee.Name = "txt_Fee";
            txt_Fee.Size = new Size(526, 27);
            txt_Fee.TabIndex = 2;
            // 
            // cb_SType
            // 
            cb_SType.FormattingEnabled = true;
            cb_SType.Items.AddRange(new object[] { "Room / Add-on", "Food & Beverage", "Facility", "Maintenance", "Entertainment", "Supplies", "Room Service", "Support Service" });
            cb_SType.Location = new Point(631, 521);
            cb_SType.Name = "cb_SType";
            cb_SType.Size = new Size(281, 28);
            cb_SType.TabIndex = 3;
            // 
            // btn_saveService
            // 
            btn_saveService.BackColor = Color.Transparent;
            btn_saveService.Location = new Point(154, 779);
            btn_saveService.Name = "btn_saveService";
            btn_saveService.Size = new Size(139, 42);
            btn_saveService.TabIndex = 4;
            btn_saveService.Click += btn_saveService_Click;
            btn_saveService.Paint += btn_saveService_Paint;
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Available", "Unavailable", "Under Maintenance" });
            cbStatus.Location = new Point(631, 581);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(281, 28);
            cbStatus.TabIndex = 5;
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.Transparent;
            btn_clear.Location = new Point(394, 782);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(139, 42);
            btn_clear.TabIndex = 5;
            btn_clear.Click += btn_clear_Click;
            // 
            // AddService
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_clear);
            Controls.Add(cbStatus);
            Controls.Add(btn_saveService);
            Controls.Add(cb_SType);
            Controls.Add(txt_Fee);
            Controls.Add(txt_serviceName);
            Controls.Add(btn_backSS);
            Name = "AddService";
            Text = "AddService";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel btn_backSS;
        private TextBox txt_serviceName;
        private TextBox txt_Fee;
        private ComboBox cb_SType;
        private Panel btn_saveService;
        private ComboBox cbStatus;
        private Panel btn_clear;
    }
}