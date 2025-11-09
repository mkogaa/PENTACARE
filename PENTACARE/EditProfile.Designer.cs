namespace USERS_WINDOW
{
    partial class EditProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProfile));
            btnCancel = new Button();
            btnSave = new Button();
            userName = new TextBox();
            userID = new TextBox();
            userUN = new TextBox();
            userContact = new TextBox();
            userSpecialty = new TextBox();
            userEmail = new TextBox();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(0, 22, 122);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ButtonFace;
            btnCancel.Location = new Point(1375, 741);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(177, 53);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(69, 105, 173);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = SystemColors.ButtonFace;
            btnSave.Location = new Point(1157, 741);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 57);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // userName
            // 
            userName.BackColor = Color.White;
            userName.BorderStyle = BorderStyle.None;
            userName.Font = new Font("Century Gothic", 10.2F);
            userName.Location = new Point(837, 367);
            userName.Name = "userName";
            userName.Size = new Size(715, 21);
            userName.TabIndex = 13;
            // 
            // userID
            // 
            userID.BackColor = Color.White;
            userID.BorderStyle = BorderStyle.None;
            userID.Font = new Font("Century Gothic", 10.2F);
            userID.Location = new Point(780, 423);
            userID.Name = "userID";
            userID.Size = new Size(772, 21);
            userID.TabIndex = 14;
            // 
            // userUN
            // 
            userUN.BackColor = Color.White;
            userUN.BorderStyle = BorderStyle.None;
            userUN.Font = new Font("Century Gothic", 10.2F);
            userUN.Location = new Point(885, 477);
            userUN.Name = "userUN";
            userUN.Size = new Size(667, 21);
            userUN.TabIndex = 15;
            // 
            // userContact
            // 
            userContact.BackColor = Color.White;
            userContact.BorderStyle = BorderStyle.None;
            userContact.Font = new Font("Century Gothic", 10.2F);
            userContact.Location = new Point(980, 593);
            userContact.Name = "userContact";
            userContact.Size = new Size(572, 21);
            userContact.TabIndex = 16;
            // 
            // userSpecialty
            // 
            userSpecialty.BackColor = Color.White;
            userSpecialty.BorderStyle = BorderStyle.None;
            userSpecialty.Font = new Font("Century Gothic", 10.2F);
            userSpecialty.Location = new Point(869, 536);
            userSpecialty.Name = "userSpecialty";
            userSpecialty.Size = new Size(683, 21);
            userSpecialty.TabIndex = 17;
            // 
            // userEmail
            // 
            userEmail.BackColor = Color.White;
            userEmail.BorderStyle = BorderStyle.None;
            userEmail.Font = new Font("Century Gothic", 10.2F);
            userEmail.Location = new Point(937, 648);
            userEmail.Name = "userEmail";
            userEmail.Size = new Size(615, 21);
            userEmail.TabIndex = 18;
            // 
            // EditProfile
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
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            DoubleBuffered = true;
            Name = "EditProfile";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += EditProfile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCancel;
        private Button btnSave;
        private TextBox userName;
        private TextBox userID;
        private TextBox userUN;
        private TextBox userContact;
        private TextBox userSpecialty;
        private TextBox userEmail;
    }
}