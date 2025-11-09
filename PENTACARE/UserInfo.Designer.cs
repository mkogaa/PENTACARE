namespace USERS_WINDOW
{
    partial class UserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfo));
            userEmail = new TextBox();
            userSpecialty = new TextBox();
            userContact = new TextBox();
            userUN = new TextBox();
            userID = new TextBox();
            userName = new TextBox();
            btnBack = new Button();
            btnEdit = new Button();
            SuspendLayout();
            // 
            // userEmail
            // 
            userEmail.BackColor = Color.White;
            userEmail.BorderStyle = BorderStyle.None;
            userEmail.Font = new Font("Century Gothic", 10.2F);
            userEmail.Location = new Point(952, 622);
            userEmail.Name = "userEmail";
            userEmail.Size = new Size(615, 21);
            userEmail.TabIndex = 26;
            // 
            // userSpecialty
            // 
            userSpecialty.BackColor = Color.White;
            userSpecialty.BorderStyle = BorderStyle.None;
            userSpecialty.Font = new Font("Century Gothic", 10.2F);
            userSpecialty.Location = new Point(884, 509);
            userSpecialty.Name = "userSpecialty";
            userSpecialty.Size = new Size(683, 21);
            userSpecialty.TabIndex = 25;
            // 
            // userContact
            // 
            userContact.BackColor = Color.White;
            userContact.BorderStyle = BorderStyle.None;
            userContact.Font = new Font("Century Gothic", 10.2F);
            userContact.Location = new Point(995, 567);
            userContact.Name = "userContact";
            userContact.Size = new Size(572, 21);
            userContact.TabIndex = 24;
            // 
            // userUN
            // 
            userUN.BackColor = Color.White;
            userUN.BorderStyle = BorderStyle.None;
            userUN.Font = new Font("Century Gothic", 10.2F);
            userUN.Location = new Point(900, 455);
            userUN.Name = "userUN";
            userUN.Size = new Size(667, 21);
            userUN.TabIndex = 23;
            // 
            // userID
            // 
            userID.BackColor = Color.White;
            userID.BorderStyle = BorderStyle.None;
            userID.Font = new Font("Century Gothic", 10.2F);
            userID.Location = new Point(795, 406);
            userID.Name = "userID";
            userID.Size = new Size(772, 21);
            userID.TabIndex = 22;
            // 
            // userName
            // 
            userName.BackColor = Color.White;
            userName.BorderStyle = BorderStyle.None;
            userName.Font = new Font("Century Gothic", 10.2F);
            userName.Location = new Point(838, 352);
            userName.Name = "userName";
            userName.Size = new Size(715, 21);
            userName.TabIndex = 21;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(0, 22, 122);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = SystemColors.ButtonFace;
            btnBack.Location = new Point(1390, 707);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(177, 53);
            btnBack.TabIndex = 20;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(69, 105, 173);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = SystemColors.ButtonFace;
            btnEdit.Location = new Point(1169, 711);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(180, 57);
            btnEdit.TabIndex = 19;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click_1;
            // 
            // UserInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(userEmail);
            Controls.Add(userSpecialty);
            Controls.Add(userContact);
            Controls.Add(userUN);
            Controls.Add(userID);
            Controls.Add(userName);
            Controls.Add(btnBack);
            Controls.Add(btnEdit);
            DoubleBuffered = true;
            Name = "UserInfo";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += UserInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox userEmail;
        private TextBox userSpecialty;
        private TextBox userContact;
        private TextBox userUN;
        private TextBox userID;
        private TextBox userName;
        private Button btnBack;
        private Button btnEdit;
    }
}