using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static USERS_WINDOW.MedicalRecords;

namespace USERS_WINDOW
{
    public partial class NewRecords : Form
    {
        private int doctorID;
        private int patientID;
        private int existingPatientId = 0;
        private MedicalRecords medrec;

        public NewRecords(MedicalRecords medrecs)
        {
            InitializeComponent();
            medrec = medrecs;

            txtPName.Enabled = true;
            txtAge.Enabled = true;
            txtGender.Enabled = true;
            txtContact.Enabled = true;
            txtAddress.Enabled = true;
        }

        public NewRecords(MedicalRecords medrecs,int doctorID, int patientId, string name, string age, string gender, string contact, string address)
        {
            InitializeComponent();
            medrec = medrecs;

            this.doctorID = doctorID;
            this.patientID = patientId;

            txtPName.Text = name;
            txtAge.Text = age;
            txtGender.Text = gender;
            txtContact.Text = contact;
            txtAddress.Text = address;

            txtPName.Enabled = false;
            txtAge.Enabled = false;
            txtGender.Enabled = false;
            txtContact.Enabled = false;
            txtAddress.Enabled = false;

            txtRecordDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            medrec.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPName.Text == "" || txtAge.Text == "" || txtGender.Text == "" ||
            txtContact.Text == "" || txtAddress.Text == "" || txtBP.Text == "" ||
            txtHR.Text == "" || txtTemp.Text == "" || txtDiagnosis.Text == "" ||
            txtTreatment.Text == "" || txtMedication.Text == "" || txtAllergies.Text == "")

            {
                MessageBox.Show("Please fill in all fields before saving.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtPName.Text.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("Name should contain letters only.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtAge.Text.All(char.IsDigit))
            {
                MessageBox.Show("Age should contain numbers only.", "Invalid Age", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtContact.Text.All(char.IsDigit))
            {
                MessageBox.Show("Contact number should contain numbers only.", "Invalid Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtContact.Text.Length != 11)
            {
                MessageBox.Show("Contact number must be 11 digits long.", "Invalid Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(DBConnection.connString))
            {
                conn.Open();

                string insertRecord = @"INSERT INTO medical_records 
                    (DoctorID, PatientID, BP, HR, Temp, Allergies, Diagnosis, DiagnosisNotes, ExamFindings, Treatment, Medication, RecordDate)
                    VALUES (@doctorID, @pid, @bp, @hr, @temp, @allergies, @diagnosis, @dn, @exam, @treatment, @medication, NOW())";

                MySqlCommand cmd = new MySqlCommand(insertRecord, conn);
                cmd.Parameters.AddWithValue("@doctorID", doctorID);
                cmd.Parameters.AddWithValue("@pid", patientID);
                cmd.Parameters.AddWithValue("@bp", txtBP.Text);
                cmd.Parameters.AddWithValue("@hr", txtHR.Text);
                cmd.Parameters.AddWithValue("@temp", txtTemp.Text);
                cmd.Parameters.AddWithValue("@allergies", txtAllergies.Text);
                cmd.Parameters.AddWithValue("@diagnosis", txtDiagnosis.Text);
                cmd.Parameters.AddWithValue("@dn", txtDN.Text);
                cmd.Parameters.AddWithValue("@exam", txtExamFindings.Text);
                cmd.Parameters.AddWithValue("@treatment", txtTreatment.Text);
                cmd.Parameters.AddWithValue("@medication", txtMedication.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtBP.Text = "";
            txtHR.Text = "";
            txtTemp.Text = "";
            txtAllergies.Text = "";
            txtDiagnosis.Text = "";
            txtDN.Text = "";
            txtExamFindings.Text = "";
            txtTreatment.Text = "";
            txtMedication.Text = "";

            txtBP.Focus();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }


        private void txtPName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewRecords_Load(object sender, EventArgs e)
        {
            txtRecordDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            MySqlConnection con = new MySqlConnection("server=localhost;database=pentacare;username=root;password=;");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT Medicine_Name FROM medicines", con);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtMedication.Items.Add(dr["Medicine_Name"].ToString());
            }

            con.Close();
        }

    }
}