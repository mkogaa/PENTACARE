namespace USERS_WINDOW
{
    partial class CreateAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccount));
            txt_ca_name = new TextBox();
            txt_ca_specialty = new TextBox();
            txt_ca_contact = new TextBox();
            txt_ca_email = new TextBox();
            txt_ca_username = new TextBox();
            txt_ca_password = new TextBox();
            btn_createaccount = new Panel();
            btn_ca_cancel = new Panel();
            SuspendLayout();
            // 
            // txt_ca_name
            // 
            txt_ca_name.BorderStyle = BorderStyle.None;
            txt_ca_name.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_ca_name.Location = new Point(730, 274);
            txt_ca_name.Margin = new Padding(2);
            txt_ca_name.Name = "txt_ca_name";
            txt_ca_name.Size = new Size(790, 37);
            txt_ca_name.TabIndex = 0;
            // 
            // txt_ca_specialty
            // 
            txt_ca_specialty.BorderStyle = BorderStyle.None;
            txt_ca_specialty.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_ca_specialty.Location = new Point(730, 365);
            txt_ca_specialty.Margin = new Padding(2);
            txt_ca_specialty.Name = "txt_ca_specialty";
            txt_ca_specialty.Size = new Size(790, 37);
            txt_ca_specialty.TabIndex = 1;
            // 
            // txt_ca_contact
            // 
            txt_ca_contact.BorderStyle = BorderStyle.None;
            txt_ca_contact.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_ca_contact.Location = new Point(730, 444);
            txt_ca_contact.Margin = new Padding(2);
            txt_ca_contact.Name = "txt_ca_contact";
            txt_ca_contact.Size = new Size(790, 37);
            txt_ca_contact.TabIndex = 2;
            txt_ca_contact.Text = " ";
            // 
            // txt_ca_email
            // 
            txt_ca_email.BorderStyle = BorderStyle.None;
            txt_ca_email.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_ca_email.Location = new Point(730, 523);
            txt_ca_email.Margin = new Padding(2);
            txt_ca_email.Name = "txt_ca_email";
            txt_ca_email.Size = new Size(790, 37);
            txt_ca_email.TabIndex = 4;
            txt_ca_email.TextChanged += txt_ca_email_TextChanged;
            // 
            // txt_ca_username
            // 
            txt_ca_username.BorderStyle = BorderStyle.None;
            txt_ca_username.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_ca_username.Location = new Point(730, 602);
            txt_ca_username.Margin = new Padding(2);
            txt_ca_username.Name = "txt_ca_username";
            txt_ca_username.Size = new Size(790, 37);
            txt_ca_username.TabIndex = 5;
            // 
            // txt_ca_password
            // 
            txt_ca_password.BorderStyle = BorderStyle.None;
            txt_ca_password.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_ca_password.Location = new Point(730, 684);
            txt_ca_password.Margin = new Padding(2);
            txt_ca_password.Name = "txt_ca_password";
            txt_ca_password.Size = new Size(790, 37);
            txt_ca_password.TabIndex = 6;
            // 
            // btn_createaccount
            // 
            btn_createaccount.BackColor = Color.Transparent;
            btn_createaccount.Location = new Point(555, 815);
            btn_createaccount.Margin = new Padding(2);
            btn_createaccount.Name = "btn_createaccount";
            btn_createaccount.Size = new Size(374, 69);
            btn_createaccount.TabIndex = 7;
            btn_createaccount.Click += btn_createaccount_Click;
            // 
            // btn_ca_cancel
            // 
            btn_ca_cancel.BackColor = Color.Transparent;
            btn_ca_cancel.Location = new Point(1002, 810);
            btn_ca_cancel.Margin = new Padding(2);
            btn_ca_cancel.Name = "btn_ca_cancel";
            btn_ca_cancel.Size = new Size(368, 74);
            btn_ca_cancel.TabIndex = 8;
            btn_ca_cancel.Click += btn_ca_cancel_Click;
            // 
            // CreateAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_ca_cancel);
            Controls.Add(btn_createaccount);
            Controls.Add(txt_ca_password);
            Controls.Add(txt_ca_username);
            Controls.Add(txt_ca_email);
            Controls.Add(txt_ca_contact);
            Controls.Add(txt_ca_specialty);
            Controls.Add(txt_ca_name);
            Margin = new Padding(2);
            Name = "CreateAccount";
            WindowState = FormWindowState.Maximized;
            Load += CreateAccount_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_ca_name;
        private TextBox txt_ca_specialty;
        private TextBox txt_ca_contact;
        private TextBox textBox4;
        private TextBox txt_ca_email;
        private TextBox txt_ca_username;
        private TextBox txt_ca_password;
        private Panel btn_createaccount;
        private Panel btn_ca_cancel;
    }
}