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
        private int patientID;
        private int existingPatientId = 0;

        public NewRecords()
        {
            InitializeComponent();

            txtPName.Enabled = true;
            txtAge.Enabled = true;
            txtGender.Enabled = true;
            txtContact.Enabled = true;
            txtAddress.Enabled = true;
        }

        public NewRecords(int patientId, string name, string age, string gender, string contact, string address)
        {
            InitializeComponent();

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
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            MedicalRecords medicalrecords = new MedicalRecords();
            medicalrecords.Show();
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

                long patientId = 0;

                string checkQuery = "SELECT PatientID FROM patient_medrec WHERE Patient_Name = @name AND Age = @age AND Gender = @gender AND `Contact_No.` = @contact LIMIT 1";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@name", txtPName.Text);
                checkCmd.Parameters.AddWithValue("@age", txtAge.Text);
                checkCmd.Parameters.AddWithValue("@gender", txtGender.Text);
                checkCmd.Parameters.AddWithValue("@contact", txtContact.Text);

                object result = checkCmd.ExecuteScalar();

                if (result != null)
                {
                    patientId = Convert.ToInt64(result);
                }
                else
                {
                    string insertPatient = "INSERT INTO patient_medrec (Patient_Name, Age, Gender, `Contact_No.`, `Address`) " +
                                            "VALUES (@name, @age, @gender, @contact, @address)";
                    MySqlCommand cmdPatient = new MySqlCommand(insertPatient, conn);
                    cmdPatient.Parameters.AddWithValue("@name", txtPName.Text);
                    cmdPatient.Parameters.AddWithValue("@age", txtAge.Text);
                    cmdPatient.Parameters.AddWithValue("@gender", txtGender.Text);
                    cmdPatient.Parameters.AddWithValue("@contact", txtContact.Text);
                    cmdPatient.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmdPatient.ExecuteNonQuery();

                    patientId = cmdPatient.LastInsertedId;

                }
                string insertRecord = "INSERT INTO medical_records (PatientID, BP, HR, Temp, Allergies, Diagnosis, Treatment, Medication, RecordDate) " +
                                       "VALUES (@pid, @bp, @hr, @temp, @allergies, @diagnosis, @treatment, @medication, NOW())";
                MySqlCommand cmdRecord = new MySqlCommand(insertRecord, conn);
                cmdRecord.Parameters.AddWithValue("@pid", patientId);
                cmdRecord.Parameters.AddWithValue("@bp", txtBP.Text);
                cmdRecord.Parameters.AddWithValue("@hr", txtHR.Text);
                cmdRecord.Parameters.AddWithValue("@temp", txtTemp.Text);
                cmdRecord.Parameters.AddWithValue("@allergies", txtAllergies.Text);
                cmdRecord.Parameters.AddWithValue("@diagnosis", txtDiagnosis.Text);
                cmdRecord.Parameters.AddWithValue("@treatment", txtTreatment.Text);
                cmdRecord.Parameters.AddWithValue("@medication", txtMedication.Text);
                cmdRecord.ExecuteNonQuery();

                MessageBox.Show($"Record saved successfully!\nPatient ID: {patientId}",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtPName.Text = "";
            txtAge.Text = "";
            txtGender.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtBP.Text = "";
            txtHR.Text = "";
            txtTemp.Text = "";
            txtAllergies.Text = "";
            txtDiagnosis.Text = "";
            txtTreatment.Text = "";
            txtMedication.Text = "";

            txtPName.Focus();

            this.DialogResult = DialogResult.OK;
            this.Close();
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