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
            btn_signup = new FlowLayoutPanel();
            cb_login = new ComboBox();
            SuspendLayout();
            // 
            // txt_login_email
            // 
            txt_login_email.BorderStyle = BorderStyle.None;
            txt_login_email.Font = new Font("Century Gothic", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_login_email.Location = new Point(773, 528);
            txt_login_email.Margin = new Padding(2);
            txt_login_email.Multiline = true;
            txt_login_email.Name = "txt_login_email";
            txt_login_email.Size = new Size(644, 38);
            txt_login_email.TabIndex = 1;
            // 
            // txt_login_password
            // 
            txt_login_password.BorderStyle = BorderStyle.None;
            txt_login_password.Font = new Font("Century Gothic", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_login_password.Location = new Point(774, 624);
            txt_login_password.Margin = new Padding(2);
            txt_login_password.Name = "txt_login_password";
            txt_login_password.Size = new Size(644, 41);
            txt_login_password.TabIndex = 2;
            txt_login_password.UseSystemPasswordChar = true;
            // 
            // btn_login
            // 
            btn_login.BackColor = Color.Transparent;
            btn_login.Location = new Point(688, 823);
            btn_login.Margin = new Padding(2);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(224, 65);
            btn_login.TabIndex = 3;
            btn_login.Click += btn_login_Click;
            // 
            // btn_login_cancel
            // 
            btn_login_cancel.BackColor = Color.Transparent;
            btn_login_cancel.Location = new Point(985, 823);
            btn_login_cancel.Margin = new Padding(2);
            btn_login_cancel.Name = "btn_login_cancel";
            btn_login_cancel.Size = new Size(231, 65);
            btn_login_cancel.TabIndex = 4;
            // 
            // btn_signup
            // 
            btn_signup.BackColor = Color.Black;
            btn_signup.Location = new Point(688, 753);
            btn_signup.Margin = new Padding(2);
            btn_signup.Name = "btn_signup";
            btn_signup.Size = new Size(528, 31);
            btn_signup.TabIndex = 5;
            btn_signup.Click += btn_signup_Click_1;
            // 
            // cb_login
            // 
            cb_login.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_login.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_login.FormattingEnabled = true;
            cb_login.Items.AddRange(new object[] { "Admin", "Doctor" });
            cb_login.Location = new Point(776, 431);
            cb_login.Margin = new Padding(2);
            cb_login.Name = "cb_login";
            cb_login.Size = new Size(644, 45);
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
            Controls.Add(btn_signup);
            Controls.Add(btn_login_cancel);
            Controls.Add(btn_login);
            Controls.Add(txt_login_password);
            Controls.Add(txt_login_email);
            Margin = new Padding(2);
            Name = "Login";
            WindowState = FormWindowState.Maximized;
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_login_email;
        private TextBox txt_login_password;
        private FlowLayoutPanel btn_login;
        private FlowLayoutPanel btn_login_cancel;
        private FlowLayoutPanel btn_signup;
        private ComboBox cb_login;
    }
}
