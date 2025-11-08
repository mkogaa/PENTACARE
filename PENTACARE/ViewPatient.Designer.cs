namespace PentaCare
{
    partial class ViewPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewPatient));
            backBtn = new Panel();
            pName = new Label();
            pDoc = new Label();
            pDiag = new Label();
            pMed = new Label();
            pNotes = new Label();
            SuspendLayout();
            // 
            // backBtn
            // 
            backBtn.BackColor = Color.Transparent;
            backBtn.Location = new Point(1454, 830);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(233, 80);
            backBtn.TabIndex = 0;
            backBtn.Click += backBtn_Click;
            // 
            // pName
            // 
            pName.AutoSize = true;
            pName.BackColor = Color.Transparent;
            pName.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pName.Location = new Point(996, 273);
            pName.Name = "pName";
            pName.Size = new Size(119, 54);
            pName.TabIndex = 1;
            pName.Text = "Value";
            // 
            // pDoc
            // 
            pDoc.AutoSize = true;
            pDoc.BackColor = Color.Transparent;
            pDoc.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pDoc.Location = new Point(871, 362);
            pDoc.Name = "pDoc";
            pDoc.Size = new Size(119, 54);
            pDoc.TabIndex = 2;
            pDoc.Text = "Value";
            // 
            // pDiag
            // 
            pDiag.AutoSize = true;
            pDiag.BackColor = Color.Transparent;
            pDiag.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pDiag.Location = new Point(924, 447);
            pDiag.Name = "pDiag";
            pDiag.Size = new Size(119, 54);
            pDiag.TabIndex = 3;
            pDiag.Text = "Value";
            // 
            // pMed
            // 
            pMed.AutoSize = true;
            pMed.BackColor = Color.Transparent;
            pMed.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pMed.Location = new Point(1160, 535);
            pMed.Name = "pMed";
            pMed.Size = new Size(119, 54);
            pMed.TabIndex = 4;
            pMed.Text = "Value";
            // 
            // pNotes
            // 
            pNotes.AutoSize = true;
            pNotes.BackColor = Color.Transparent;
            pNotes.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pNotes.Location = new Point(1078, 618);
            pNotes.Name = "pNotes";
            pNotes.Size = new Size(119, 54);
            pNotes.TabIndex = 5;
            pNotes.Text = "Value";
            // 
            // ViewPatient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(pNotes);
            Controls.Add(pMed);
            Controls.Add(pDiag);
            Controls.Add(pDoc);
            Controls.Add(pName);
            Controls.Add(backBtn);
            Name = "ViewPatient";
            Text = "ViewPatient";
            Load += ViewPatient_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel backBtn;
        private Label pName;
        private Label pDoc;
        private Label pDiag;
        private Label pMed;
        private Label pNotes;
    }
}