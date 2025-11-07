namespace PentaCare
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            backbtn = new Panel();
            label1 = new Label();
            SuspendLayout();
            // 
            // backbtn
            // 
            backbtn.BackColor = Color.Transparent;
            backbtn.Location = new Point(1439, 889);
            backbtn.Name = "backbtn";
            backbtn.Size = new Size(251, 82);
            backbtn.TabIndex = 0;
            backbtn.Click += backbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(993, 270);
            label1.Name = "label1";
            label1.Size = new Size(130, 60);
            label1.TabIndex = 1;
            label1.Text = "Value";
            label1.Click += label1_Click;
            // 
            // View
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1902, 1055);
            Controls.Add(label1);
            Controls.Add(backbtn);
            Name = "View";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View";
            Load += View_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel backbtn;
        private Label label1;
    }
}