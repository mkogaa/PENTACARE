using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USERS_WINDOW
{
    public partial class PatientMedicalRecord : Form
    {
        private int patientID;

        public PatientMedicalRecord(int id)
        {
            InitializeComponent();
            patientID = id;
            LoadPatientDetails();
            LoadPatientRecords();
            SetTextBoxesReadOnly(true);
            LoadLatestRecord();

            dgvPRecord.CellClick += dgvPRecord_CellClick;
        }

        private void LoadPatientDetails()
        {
            string query = "SELECT * FROM patient_medrec WHERE PatientID = @id";

            using (MySqlConnection conn = new MySqlConnection(MedicalRecords.DBConnection.connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", patientID);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtPID.Text = reader["patientID"].ToString();
                    txtPName.Text = reader["Patient_Name"].ToString();
                    txtAge.Text = reader["Age"].ToString();
                    txtGender.Text = reader["Gender"].ToString();
                    txtContact.Text = reader["Contact_No."].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                }
            }
        }

        private void LoadSpecificRecord(int recordID)
        {
            string query = "SELECT * FROM medical_records WHERE RecordID = @rid";

            using (MySqlConnection conn = new MySqlConnection(MedicalRecords.DBConnection.connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@rid", recordID);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtRecordDate.Text = Convert.ToDateTime(reader["RecordDate"]).ToString("yyyy-MM-dd");
                    txtBP.Text = reader["BP"].ToString();
                    txtHR.Text = reader["HR"].ToString();
                    txtTemp.Text = reader["Temp"].ToString();
                    txtAllergies.Text = reader["Allergies"].ToString();
                    txtDiagnosis.Text = reader["Diagnosis"].ToString();
                    txtDN.Text = reader["DiagnosisNotes"].ToString();
                    txtTreatment.Text = reader["Treatment"].ToString();
                    txtMedication.Text = reader["Medication"].ToString();
                    txtExamFindings.Text = reader["ExamFindings"].ToString();
                }
            }
        }

        private void LoadLatestRecord()
        {
            string query = @"SELECT * FROM medical_records 
                     WHERE PatientID = @id 
                     ORDER BY RecordDate DESC 
                     LIMIT 1";

            using (MySqlConnection conn = new MySqlConnection(MedicalRecords.DBConnection.connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", patientID);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtRecordDate.Text = Convert.ToDateTime(reader["RecordDate"]).ToString("yyyy-MM-dd");
                        txtBP.Text = reader["BP"].ToString();
                        txtHR.Text = reader["HR"].ToString();
                        txtTemp.Text = reader["Temp"].ToString();
                        txtAllergies.Text = reader["Allergies"].ToString();
                        txtDiagnosis.Text = reader["Diagnosis"].ToString();
                        txtDN.Text = reader["DiagnosisNotes"].ToString();
                        txtTreatment.Text = reader["Treatment"].ToString();
                        txtMedication.Text = reader["Medication"].ToString();
                        txtExamFindings.Text = reader["ExamFindings"].ToString();
                        txtRecordNo.Text = "1";
                    }
                }
            }
        }


        private void LoadPatientRecords()
        {
            string query = "SELECT RecordID, Diagnosis FROM medical_records WHERE PatientID = @id ORDER BY RecordDate DESC";

            using (MySqlConnection conn = new MySqlConnection(MedicalRecords.DBConnection.connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", patientID);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvPRecord.DataSource = dt;
                dgvPRecord.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPRecord.Columns["RecordID"].HeaderText = "Record ID";
                dgvPRecord.Columns["Diagnosis"].HeaderText = "Diagnosis";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MedicalRecords medicalrecords = new MedicalRecords();
            medicalrecords.Show();
            this.Hide();
        }

        private void PatientMedicalRecord_Load(object sender, EventArgs e)
        {
        }

        private void SetTextBoxesReadOnly(bool readOnly)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.ReadOnly = readOnly;
                }
            }
        }

        private void dgvPRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int recordID = Convert.ToInt32(dgvPRecord.Rows[e.RowIndex].Cells["RecordID"].Value);
                LoadSpecificRecord(recordID);
                txtRecordNo.Text = (e.RowIndex + 1).ToString();
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
