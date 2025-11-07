namespace PentaCare
{
    partial class AddDoctors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDoctors));
            docName = new TextBox();
            docSpecialty = new TextBox();
            docContact = new TextBox();
            docEmail = new TextBox();
            saveBtn = new Panel();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // docName
            // 
            docName.BorderStyle = BorderStyle.None;
            docName.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            docName.Location = new Point(884, 297);
            docName.Name = "docName";
            docName.Size = new Size(627, 36);
            docName.TabIndex = 0;
            // 
            // docSpecialty
            // 
            docSpecialty.BorderStyle = BorderStyle.None;
            docSpecialty.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            docSpecialty.Location = new Point(959, 389);
            docSpecialty.Name = "docSpecialty";
            docSpecialty.Size = new Size(555, 36);
            docSpecialty.TabIndex = 1;
            // 
            // docContact
            // 
            docContact.BorderStyle = BorderStyle.None;
            docContact.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            docContact.Location = new Point(990, 487);
            docContact.Name = "docContact";
            docContact.Size = new Size(521, 36);
            docContact.TabIndex = 2;
            // 
            // docEmail
            // 
            docEmail.BorderStyle = BorderStyle.None;
            docEmail.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            docEmail.Location = new Point(868, 576);
            docEmail.Name = "docEmail";
            docEmail.Size = new Size(649, 36);
            docEmail.TabIndex = 3;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.Transparent;
            saveBtn.Location = new Point(233, 776);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(235, 75);
            saveBtn.TabIndex = 4;
            saveBtn.Click += saveBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(1448, 776);
            panel1.Name = "panel1";
            panel1.Size = new Size(229, 75);
            panel1.TabIndex = 5;
            panel1.Click += panel1_Click;
            // 
            // AddDoctors
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel1);
            Controls.Add(saveBtn);
            Controls.Add(docEmail);
            Controls.Add(docContact);
            Controls.Add(docSpecialty);
            Controls.Add(docName);
            Name = "AddDoctors";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddDoctors";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox docName;
        private TextBox docSpecialty;
        private TextBox docContact;
        private TextBox docEmail;
        private Panel saveBtn;
        private Panel panel1;
    }
}