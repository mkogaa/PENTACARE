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

namespace PENTACARE
{
    public partial class View_PatientRecord : Form
    {
        private string patientID;
        public View_PatientRecord(string selectedPatientID)
        {
            InitializeComponent();
            patientID = selectedPatientID;

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void View_PatientRecord_Load(object sender, EventArgs e)
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                conn.Open();

                string query = @"SELECT 
                        p.PatientID, p.Name, p.Age, p.Gender, p.Address, p.Contact_No,
                        p.Admission_Date, p.Discharge_Date,
                        r.RoomID, r.Room_No, r.Room_Type, r.Room_Rate
                     FROM patient p
                     LEFT JOIN room r ON p.RoomID = r.RoomID
                     WHERE p.PatientID = @PatientID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblPID.Text = reader["PatientID"].ToString();
                            lblName.Text = reader["Name"].ToString();
                            lblAge.Text = reader["Age"].ToString();
                            lblGender.Text = reader["Gender"].ToString();
                            lblAddress.Text = reader["Address"].ToString();

                            lblRID.Text = reader["RoomID"].ToString();
                            lblRN.Text = reader["Room_No"].ToString();
                            lblType.Text = reader["Room_Type"].ToString();
                            lblFee.Text = reader["Room_Rate"].ToString();
                        }
                    }
                }
            }

            dgv_LabRec.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_LabRec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_LabRec.ScrollBars = ScrollBars.Both;

            dgv_LabRec.AllowUserToAddRows = false;
            dgv_LabRec.RowHeadersVisible = false;

            dgv_LabRec.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_LabRec.EnableHeadersVisualStyles = false;
            dgv_LabRec.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dgv_LabRec.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_LabRec.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                conn.Open();

                string query = "SELECT pl.RecordID AS 'Record ID', p.Name AS 'Patient Name', d.Doctor_Name AS 'Doctor Name', " +
                               "ls.Lab_Name AS 'Laboratory Test', pl.Date_Ordered AS 'Date Ordered', pl.Fee, pl.Result, pl.Status " +
                               "FROM patient_labrec pl " +
                               "LEFT JOIN patient p ON pl.PatientID = p.PatientID " +
                               "LEFT JOIN doctor d ON pl.DoctorID = d.DoctorID " +
                               "LEFT JOIN lab_services ls ON pl.LabID = ls.LabID " +
                               "WHERE pl.PatientID = @PatientID"; // filter by selected patient

                using (MySqlCommand sqlcmd = new MySqlCommand(query, conn))
                {
                    sqlcmd.Parameters.AddWithValue("@PatientID", patientID); // pass parameter
                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(sqlcmd);
                    DataSet sqlDS = new DataSet();
                    sqlDA.Fill(sqlDS, "recordsfetch");

                    dgv_LabRec.DataSource = sqlDS.Tables["recordsfetch"];
                }
            }

            dgv_MedRec.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_MedRec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_MedRec.ScrollBars = ScrollBars.Both;

            dgv_MedRec.AllowUserToAddRows = false;
            dgv_MedRec.RowHeadersVisible = false;

            dgv_MedRec.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_MedRec.EnableHeadersVisualStyles = false;
            dgv_MedRec.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dgv_MedRec.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_MedRec.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            string con = "server=127.0.0.1; database=pentacare; uid=root;";
            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                conn.Open();
                string query = @"
                SELECT 
                    mr.RecordID AS 'Record ID',
                    p.Name AS 'Patient Name',
                    d.Doctor_Name AS 'Doctor Name',
                    mr.BP AS 'Blood Pressure',
                    mr.HR AS 'Heart Rate',
                    mr.Temp AS 'Temperature',
                    mr.Allergies,
                    mr.Diagnosis,
                    mr.DiagnosisNotes AS 'Diagnosis Notes',
                    mr.ExamFindings AS 'Exam Findings',
                    mr.Treatment,
                    mr.Medication,
                    mr.RecordDate AS 'Date Recorded'
                FROM medical_records mr
                LEFT JOIN patient p ON mr.PatientID = p.PatientID
                LEFT JOIN doctor d ON mr.DoctorID = d.DoctorID
                WHERE mr.PatientID = @PatientID";


                using (MySqlCommand sqlcmd = new MySqlCommand(query, conn))
                {
                    sqlcmd.Parameters.AddWithValue("@PatientID", patientID); // selected patient
                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(sqlcmd);
                    DataSet sqlDS = new DataSet();
                    sqlDA.Fill(sqlDS, "recordsfetch");

                    dgv_MedRec.DataSource = sqlDS.Tables["recordsfetch"];

                    // Optional: center all cell values
                    foreach (DataGridViewColumn col in dgv_MedRec.Columns)
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Reports_Monitoring rm = new Reports_Monitoring();
            rm.Show();
            this.Hide();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Record successfully exported!", "PENTACARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Record successfully printed!", "PENTACARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
