namespace PENTACARE
{
    partial class AdminInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminInfo));
            panel2 = new Panel();
            name = new Label();
            email = new Label();
            contact = new Label();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Location = new Point(1493, 863);
            panel2.Name = "panel2";
            panel2.Size = new Size(289, 101);
            panel2.TabIndex = 1;
            panel2.Click += panel2_Click;
            // 
            // name
            // 
            name.AutoSize = true;
            name.BackColor = Color.Transparent;
            name.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            name.Location = new Point(1067, 310);
            name.Name = "name";
            name.Size = new Size(120, 50);
            name.TabIndex = 2;
            name.Text = "label1";
            // 
            // email
            // 
            email.AutoSize = true;
            email.BackColor = Color.Transparent;
            email.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            email.Location = new Point(1067, 464);
            email.Name = "email";
            email.Size = new Size(120, 50);
            email.TabIndex = 3;
            email.Text = "label2";
            // 
            // contact
            // 
            contact.AutoSize = true;
            contact.BackColor = Color.Transparent;
            contact.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contact.Location = new Point(1067, 614);
            contact.Name = "contact";
            contact.Size = new Size(120, 50);
            contact.TabIndex = 4;
            contact.Text = "label3";
            // 
            // AdminInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(contact);
            Controls.Add(email);
            Controls.Add(name);
            Controls.Add(panel2);
            Name = "AdminInfo";
            Text = "AdminInfo";
            WindowState = FormWindowState.Maximized;
            Load += AdminInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel2;
        private Label name;
        private Label email;
        private Label contact;
    }
}