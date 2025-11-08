namespace USERS_WINDOW
{
    partial class LogOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogOut));
            btnlogout = new Button();
            btncancel = new Button();
            SuspendLayout();
            // 
            // btnlogout
            // 
            btnlogout.BackColor = Color.FromArgb(12, 22, 112);
            btnlogout.BackgroundImageLayout = ImageLayout.Center;
            btnlogout.FlatAppearance.BorderSize = 0;
            btnlogout.FlatStyle = FlatStyle.Flat;
            btnlogout.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnlogout.ForeColor = SystemColors.ButtonHighlight;
            btnlogout.Location = new Point(626, 775);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(285, 91);
            btnlogout.TabIndex = 0;
            btnlogout.Text = "LOGOUT";
            btnlogout.UseVisualStyleBackColor = false;
            btnlogout.Click += btnlogout_Click;
            // 
            // btncancel
            // 
            btncancel.BackColor = Color.FromArgb(69, 105, 173);
            btncancel.BackgroundImageLayout = ImageLayout.Center;
            btncancel.FlatAppearance.BorderSize = 0;
            btncancel.FlatStyle = FlatStyle.Flat;
            btncancel.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btncancel.ForeColor = SystemColors.ButtonHighlight;
            btncancel.Location = new Point(994, 775);
            btncancel.Name = "btncancel";
            btncancel.Size = new Size(283, 91);
            btncancel.TabIndex = 1;
            btncancel.Text = "CANCEL";
            btncancel.UseVisualStyleBackColor = false;
            btncancel.Click += btncancel_Click;
            // 
            // LogOut
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btncancel);
            Controls.Add(btnlogout);
            Name = "LogOut";
            Text = "Form3";
            Load += LogOut_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnlogout;
        private Button btncancel;
    }
}