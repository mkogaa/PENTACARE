namespace PENTACARE
{
    partial class AddLabService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLabService));
            btn_backS = new Panel();
            txt_LabName = new TextBox();
            txt_Description = new TextBox();
            txt_Fee = new TextBox();
            cbCategory = new ComboBox();
            txt_ETime = new TextBox();
            btn_saveLab = new Panel();
            cbStatus = new ComboBox();
            btn_clear = new Panel();
            SuspendLayout();
            // 
            // btn_backS
            // 
            btn_backS.BackColor = Color.Transparent;
            btn_backS.Location = new Point(1606, 779);
            btn_backS.Name = "btn_backS";
            btn_backS.Size = new Size(187, 57);
            btn_backS.TabIndex = 0;
            btn_backS.Click += btn_backS_Click;
            // 
            // txt_LabName
            // 
            txt_LabName.BackColor = Color.LightSteelBlue;
            txt_LabName.Location = new Point(692, 338);
            txt_LabName.Name = "txt_LabName";
            txt_LabName.Size = new Size(852, 27);
            txt_LabName.TabIndex = 2;
            // 
            // txt_Description
            // 
            txt_Description.BackColor = Color.LightSteelBlue;
            txt_Description.Location = new Point(692, 396);
            txt_Description.Name = "txt_Description";
            txt_Description.Size = new Size(852, 27);
            txt_Description.TabIndex = 3;
            // 
            // txt_Fee
            // 
            txt_Fee.BackColor = Color.LightSteelBlue;
            txt_Fee.Location = new Point(692, 452);
            txt_Fee.Name = "txt_Fee";
            txt_Fee.Size = new Size(852, 27);
            txt_Fee.TabIndex = 4;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Items.AddRange(new object[] { "Laboratory Test", "Imaging", "Cardiology" });
            cbCategory.Location = new Point(692, 511);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(448, 28);
            cbCategory.TabIndex = 5;
            // 
            // txt_ETime
            // 
            txt_ETime.BackColor = Color.LightSteelBlue;
            txt_ETime.Location = new Point(692, 568);
            txt_ETime.Name = "txt_ETime";
            txt_ETime.Size = new Size(852, 27);
            txt_ETime.TabIndex = 6;
            // 
            // btn_saveLab
            // 
            btn_saveLab.BackColor = Color.Transparent;
            btn_saveLab.Location = new Point(154, 779);
            btn_saveLab.Name = "btn_saveLab";
            btn_saveLab.Size = new Size(155, 57);
            btn_saveLab.TabIndex = 1;
            btn_saveLab.Click += btn_saveLab_Click;
            btn_saveLab.Paint += btn_saveLab_Paint;
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Available", "Unavailable", "Under Maintenance" });
            cbStatus.Location = new Point(692, 629);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(448, 28);
            cbStatus.TabIndex = 7;
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.Transparent;
            btn_clear.Location = new Point(393, 779);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(155, 57);
            btn_clear.TabIndex = 2;
            btn_clear.Click += btn_clear_Click;
            // 
            // AddLabService
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_clear);
            Controls.Add(cbStatus);
            Controls.Add(btn_saveLab);
            Controls.Add(txt_ETime);
            Controls.Add(cbCategory);
            Controls.Add(txt_Fee);
            Controls.Add(txt_Description);
            Controls.Add(txt_LabName);
            Controls.Add(btn_backS);
            Name = "AddLabService";
            Text = "AddService";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel btn_backS;
        private TextBox txt_LabName;
        private TextBox txt_Description;
        private TextBox txt_Fee;
        private ComboBox cbCategory;
        private TextBox txt_ETime;
        private Panel btn_saveLab;
        private ComboBox cbStatus;
        private Panel btn_clear;
    }
}