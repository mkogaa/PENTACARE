using System;
using System.Drawing;
using System.Windows.Forms;

namespace USERS_WINDOW
{
    partial class PatientManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientManagement));
            txt_patient_search = new TextBox();
            dgv_patient = new DataGridView();
            cb_patient_filter = new ComboBox();
            btn_patient_back = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgv_patient).BeginInit();
            SuspendLayout();
            // 
            // txt_patient_search
            // 
            txt_patient_search.BorderStyle = BorderStyle.None;
            txt_patient_search.Font = new Font("Century Gothic", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_patient_search.Location = new Point(128, 243);
            txt_patient_search.Margin = new Padding(2);
            txt_patient_search.Multiline = true;
            txt_patient_search.Name = "txt_patient_search";
            txt_patient_search.PlaceholderText = "Search by patient name or ID...";
            txt_patient_search.Size = new Size(1217, 45);
            txt_patient_search.TabIndex = 0;
            // 
            // dgv_patient
            // 
            dgv_patient.BackgroundColor = Color.White;
            dgv_patient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_patient.Location = new Point(118, 367);
            dgv_patient.Margin = new Padding(2);
            dgv_patient.Name = "dgv_patient";
            dgv_patient.RowHeadersWidth = 62;
            dgv_patient.Size = new Size(1666, 492);
            dgv_patient.TabIndex = 1;
            dgv_patient.CellContentClick += dgv_patient_CellContentClick;
            // 
            // cb_patient_filter
            // 
            cb_patient_filter.BackColor = Color.White;
            cb_patient_filter.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_patient_filter.Font = new Font("Century Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_patient_filter.FormattingEnabled = true;
            cb_patient_filter.Items.AddRange(new object[] { "Discharged", "Admitted" });
            cb_patient_filter.Location = new Point(1485, 260);
            cb_patient_filter.Margin = new Padding(2);
            cb_patient_filter.Name = "cb_patient_filter";
            cb_patient_filter.Size = new Size(299, 41);
            cb_patient_filter.TabIndex = 6;
            // 
            // btn_patient_back
            // 
            btn_patient_back.BackColor = Color.Transparent;
            btn_patient_back.Location = new Point(1592, 931);
            btn_patient_back.Margin = new Padding(2);
            btn_patient_back.Name = "btn_patient_back";
            btn_patient_back.Size = new Size(203, 67);
            btn_patient_back.TabIndex = 7;
            btn_patient_back.Click += btn_patient_back_Click;
            // 
            // PatientManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btn_patient_back);
            Controls.Add(cb_patient_filter);
            Controls.Add(dgv_patient);
            Controls.Add(txt_patient_search);
            Margin = new Padding(2);
            Name = "PatientManagement";
            WindowState = FormWindowState.Maximized;
            Load += PatientManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_patient).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_patient_search;
        private System.Windows.Forms.DataGridView dgv_patient;
        private System.Windows.Forms.ComboBox cb_patient_filter;
        private System.Windows.Forms.Panel btn_patient_back;
    }
}
