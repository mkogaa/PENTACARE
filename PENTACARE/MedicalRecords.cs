using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static USERS_WINDOW.MedicalRecords;


namespace USERS_WINDOW
{
    public partial class MedicalRecords : Form
    {
        public static class DBConnection
        {
            public static string connString = "server=localhost;user id=root;password=;database=pentacare;";
        }

        public MedicalRecords()
        {
            InitializeComponent();
            InitializeDGV();
            LoadRecords();
        }

        private void RoundDataGridViewCorners(DataGridView dgv, int radius)
        {
            Rectangle rect = new Rectangle(0, 0, dgv.Width, dgv.Height);
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); 
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90); 
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); 
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90); 
            path.CloseAllFigures();

            dgv.Region = new Region(path);
        }


        private void LoadRecords()
        {
            string query = @"SELECT m.RecordID, p.PatientID, p.Patient_Name, p.Age, p.Gender, 
                             p.`Contact_No.`, p.`Address`, m.BP, m.HR, m.Temp, m.Allergies, m.Diagnosis, m.Treatment
                             FROM patient_medrec p 
                             LEFT JOIN medical_records m 
                             ON p.PatientID = m.PatientID 
                             AND m.RecordDate = (SELECT MAX(m2.RecordDate) FROM medical_records m2 WHERE m2.PatientID = p.PatientID)
                             ORDER BY p.Patient_Name;";

            using (MySqlConnection conn = new MySqlConnection(DBConnection.connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dgvRecords.Rows.Clear();
                    while (reader.Read())
                    {
                        dgvRecords.Rows.Add(
                            reader["RecordID"],
                            reader["PatientID"],
                            reader["Patient_Name"],
                            reader["Age"],
                            reader["Gender"],
                            reader["Contact_No."],
                            reader["Address"],
                            reader["BP"],
                            reader["HR"],
                            reader["Temp"],
                            reader["Allergies"],
                            reader["Diagnosis"],
                            reader["Treatment"],
                            "View Details"
                        );
                    }
                }
            }
        }

        private void InitializeDGV()
        {
            dgvRecords.Columns.Clear();
            dgvRecords.AutoGenerateColumns = false;
            dgvRecords.AllowUserToAddRows = false;
            dgvRecords.DefaultCellStyle.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            dgvRecords.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);


            dgvRecords.Columns.Add("RecordID", "Record ID");
            dgvRecords.Columns.Add("PatientID", "Patient ID");
            dgvRecords.Columns.Add("Patient_Name", "Name");
            dgvRecords.Columns.Add("Age", "Age");
            dgvRecords.Columns.Add("Gender", "Gender");
            dgvRecords.Columns.Add("Contact_No.", "Contact");
            dgvRecords.Columns.Add("Address", "Address");
            dgvRecords.Columns.Add("BP", "BP");
            dgvRecords.Columns.Add("HR", "HR");
            dgvRecords.Columns.Add("Temp", "Temp");
            dgvRecords.Columns.Add("Allergies", "Allergies");
            dgvRecords.Columns.Add("Diagnosis", "Diagnosis");
            dgvRecords.Columns.Add("Treatment", "Treatment");

            DataGridViewButtonColumn viewDetailsColumn = new DataGridViewButtonColumn
            {
                Name = "Action",
                Text = "View Details",
                UseColumnTextForButtonValue = true,
                HeaderText = "Action"
            };

            dgvRecords.Columns.Add(viewDetailsColumn);

            DataGridViewButtonColumn addRecordColumn = new DataGridViewButtonColumn
            {
                Name = "AddRecord",
                Text = "Add Record",
                UseColumnTextForButtonValue = true,
                HeaderText = "Add Record"
            };
            dgvRecords.Columns.Add(addRecordColumn);

            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            foreach (DataGridViewColumn col in dgvRecords.Columns)
                col.MinimumWidth = 80;

            dgvRecords.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecords.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvRecords.EnableHeadersVisualStyles = false;
            dgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvRecords.Columns["PatientID"].FillWeight = 70;
            dgvRecords.Columns["Age"].FillWeight = 60;
            dgvRecords.Columns["Patient_Name"].FillWeight = 150;
            dgvRecords.Columns["Diagnosis"].FillWeight = 140;
            dgvRecords.Columns["Address"].FillWeight = 120;
            dgvRecords.Columns["Action"].FillWeight = 100;
            dgvRecords.Columns["AddRecord"].FillWeight = 100;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            UserDashboard dashboard = new UserDashboard(0);
            dashboard.Show();
            this.Hide();
        }

        private void txtFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            string search = txtSearch.Text.Trim();
            string filter = txtFilter.SelectedItem?.ToString() ?? "Name";

            if (string.IsNullOrEmpty(search))
            {
                LoadRecords();
                return;
            }

            string query = "";

            if (filter == "Name")
                query = @"SELECT p.PatientID, p.Patient_Name, p.Age, p.Gender, p.`Contact_No.`, p.`Address`, 
                          m.Allergies, m.Diagnosis, m.Treatment
                          FROM patient_medrec p 
                          LEFT JOIN medical_records m ON p.PatientID = m.PatientID 
                          AND m.RecordDate = (SELECT MAX(m2.RecordDate) FROM medical_records m2 WHERE m2.PatientID = p.PatientID)
                          WHERE p.Patient_Name LIKE @search;";
            else if (filter == "ID")
                query = @"SELECT p.PatientID, p.Patient_Name, p.Age, p.Gender, p.`Contact_No.`, p.`Address`, 
                          m.Allergies, m.Diagnosis, m.Treatment
                          FROM patient_medrec p 
                          LEFT JOIN medical_records m ON p.PatientID = m.PatientID
                          AND m.RecordDate = (SELECT MAX(m2.RecordDate) FROM medical_records m2 WHERE m2.PatientID = p.PatientID)
                          WHERE p.PatientID LIKE @search;";
            else if (filter == "Age")
                query = @"SELECT p.PatientID, p.Patient_Name, p.Age, p.Gender, p.`Contact_No.`, p.`Address`, 
                          m.Allergies, m.Diagnosis, m.Treatment
                          FROM patient_medrec p 
                          LEFT JOIN medical_records m ON p.PatientID = m.PatientID
                          AND m.RecordDate = (SELECT MAX(m2.RecordDate) FROM medical_records m2 WHERE m2.PatientID = p.PatientID)
                          WHERE p.Age LIKE @search;";
            else if (filter == "Address")
                query = @"SELECT p.PatientID, p.Patient_Name, p.Age, p.Gender, p.`Contact_No.`, p.`Address`, 
                          m.Allergies, m.Diagnosis, m.Treatment
                          FROM patient_medrec p 
                          LEFT JOIN medical_records m ON p.PatientID = m.PatientID
                          AND m.RecordDate = (SELECT MAX(m2.RecordDate) FROM medical_records m2 WHERE m2.PatientID = p.PatientID)
                          WHERE p.`Address` LIKE @search;";
            else if (filter == "Diagnosis")
                query = @"SELECT p.PatientID, p.Patient_Name, p.Age, p.Gender, p.`Contact_No.`, p.`Address`, 
                          m.Allergies, m.Diagnosis, m.Treatment
                          FROM patient_medrec p 
                          LEFT JOIN medical_records m ON p.PatientID = m.PatientID
                          AND m.RecordDate = (SELECT MAX(m2.RecordDate) FROM medical_records m2 WHERE m2.PatientID = p.PatientID)
                          WHERE m.Diagnosis LIKE @search;";


            using (MySqlConnection conn = new MySqlConnection(DBConnection.connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dgvRecords.Rows.Clear();
                    while (reader.Read())
                    {
                        dgvRecords.Rows.Add(
                            DBNull.Value,
                            reader["PatientID"],
                            reader["Patient_Name"],
                            reader["Age"],
                            reader["Gender"],
                            reader["Contact_No."],
                            reader["Address"],
                            DBNull.Value,
                            DBNull.Value,
                            DBNull.Value,
                            reader["Allergies"],
                            reader["Diagnosis"],
                            reader["Treatment"],
                            "View Details"
                        );
                    }
                }
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewRecords newrecords = new NewRecords();
            DialogResult result = newrecords.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadRecords();
            }
        }

        private void dgvRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvRecords.Columns[e.ColumnIndex].Name == "Action")
            {
                int patientId = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells["PatientID"].Value);
                PatientMedicalRecord detailsForm = new PatientMedicalRecord(patientId);
                detailsForm.ShowDialog();
            }

            else if (dgvRecords.Columns[e.ColumnIndex].Name == "AddRecord")
            {
                int patientId = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells["PatientID"].Value);

                string name = dgvRecords.Rows[e.RowIndex].Cells["Patient_Name"].Value.ToString();
                string age = dgvRecords.Rows[e.RowIndex].Cells["Age"].Value.ToString();
                string gender = dgvRecords.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                string contact = dgvRecords.Rows[e.RowIndex].Cells["Contact_No."].Value.ToString();
                string address = dgvRecords.Rows[e.RowIndex].Cells["Address"].Value.ToString();

                NewRecords newRecordForm = new NewRecords(patientId, name, age, gender, contact, address);
                DialogResult result = newRecordForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadRecords();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRecords();
            MessageBox.Show("Records refreshed successfully.", "Refreshed",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MedicalRecords_Load(object sender, EventArgs e)
        {
            RoundDataGridViewCorners(dgvRecords, 50);
        }
    }
}
