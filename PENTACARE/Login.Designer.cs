using System;
using System.Drawing;
using System.Windows.Forms;

namespace USERS_WINDOW
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            txt_login_email = new TextBox();
            txt_login_password = new TextBox();
            btn_login = new FlowLayoutPanel();
            btn_login_cancel = new FlowLayoutPanel();
            cb_login = new ComboBox();
            SuspendLayout();
            // 
            // txt_login_email
            // 
            txt_login_email.BorderStyle = BorderStyle.None;
            txt_login_email.Font = new Font("Century Gothic", 21F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_login_email.Location = new Point(779, 540);
            txt_login_email.Margin = new Padding(2);
            txt_login_email.Multiline = true;
            txt_login_email.Name = "txt_login_email";
            txt_login_email.Size = new Size(653, 38);
            txt_login_email.TabIndex = 1;
            // 
            // txt_login_password
            // 
            txt_login_password.BorderStyle = BorderStyle.None;
            txt_login_password.Font = new Font("Century Gothic", 21F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_login_password.Location = new Point(779, 633);
            txt_login_password.Margin = new Padding(2);
            txt_login_password.Name = "txt_login_password";
            txt_login_password.Size = new Size(653, 43);
            txt_login_password.TabIndex = 2;
            txt_login_password.UseSystemPasswordChar = true;
            // 
            // btn_login
            // 
            btn_login.BackColor = Color.Transparent;
            btn_login.Location = new Point(686, 782);
            btn_login.Margin = new Padding(2);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(224, 65);
            btn_login.TabIndex = 3;
            btn_login.Click += btn_login_Click;
            // 
            // btn_login_cancel
            // 
            btn_login_cancel.BackColor = Color.Transparent;
            btn_login_cancel.Location = new Point(983, 782);
            btn_login_cancel.Margin = new Padding(2);
            btn_login_cancel.Name = "btn_login_cancel";
            btn_login_cancel.Size = new Size(231, 65);
            btn_login_cancel.TabIndex = 4;
            btn_login_cancel.Click += btn_login_cancel_Click;
            // 
            // cb_login
            // 
            cb_login.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_login.Font = new Font("Century Gothic", 21F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_login.FormattingEnabled = true;
            cb_login.Items.AddRange(new object[] { "Admin", "Doctor" });
            cb_login.Location = new Point(777, 443);
            cb_login.Margin = new Padding(2);
            cb_login.Name = "cb_login";
            cb_login.Size = new Size(655, 50);
            cb_login.TabIndex = 6;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(cb_login);
            Controls.Add(btn_login_cancel);
            Controls.Add(btn_login);
            Controls.Add(txt_login_password);
            Controls.Add(txt_login_email);
            KeyPreview = true;
            Margin = new Padding(2);
            MaximumSize = new Size(1920, 1080);
            MinimumSize = new Size(1918, 1018);
            Name = "Login";
            WindowState = FormWindowState.Maximized;
            Load += Login_Load;
            KeyDown += Login_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_login_email;
        private TextBox txt_login_password;
        private FlowLayoutPanel btn_login;
        private FlowLayoutPanel btn_login_cancel;
        private ComboBox cb_login;
    }
}
