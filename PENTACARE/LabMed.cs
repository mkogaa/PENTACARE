using MySql.Data.MySqlClient;
using PentaCare;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PENTACARE
{
    public partial class LabMed : Form
    {
        private DataSet sqlDS;
        private string patientID;
        private Form parentForm;



        public LabMed(string selectedPatientID, Form parent)
        {
            InitializeComponent();
            patientID = selectedPatientID;
            this.parentForm = parent;
        }

        private void LabMed_Load(object sender, EventArgs e)
        {
            // LAB RECORDS
            dataGridView1.Size = new Size(1572, 202);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ScrollBars = ScrollBars.Both;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
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

                    dataGridView1.DataSource = sqlDS.Tables["recordsfetch"];
                }
            }


            // MED RECORDS

            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ScrollBars = ScrollBars.Both;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.RowHeadersVisible = false;

            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

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

                    dataGridView2.DataSource = sqlDS.Tables["recordsfetch"];

                    // Optional: center all cell values
                    foreach (DataGridViewColumn col in dataGridView2.Columns)
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.Show();
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labSearcg_TextChanged(object sender, EventArgs e)
        {
            string searchValue = labSearcg.Text.Trim();

            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                try
                {
                    conn.Open();

                    string query = @"
                SELECT pl.RecordID AS 'Record ID', 
                       p.Name AS 'Patient Name', 
                       d.Doctor_Name AS 'Doctor Name', 
                       ls.Lab_Name AS 'Laboratory Test', 
                       pl.Date_Ordered AS 'Date Ordered', 
                       pl.Fee, 
                       pl.Result, 
                       pl.Status
                FROM patient_labrec pl
                LEFT JOIN patient p ON pl.PatientID = p.PatientID
                LEFT JOIN doctor d ON pl.DoctorID = d.DoctorID
                LEFT JOIN lab_services ls ON pl.LabID = ls.LabID
                WHERE pl.PatientID = @PatientID 
                  AND (ls.Lab_Name LIKE @search OR pl.Result LIKE @search)
                ORDER BY pl.Date_Ordered DESC";

                    using (MySqlCommand sqlcmd = new MySqlCommand(query, conn))
                    {
                        sqlcmd.Parameters.AddWithValue("@PatientID", patientID);
                        sqlcmd.Parameters.AddWithValue("@search", "%" + searchValue + "%");

                        MySqlDataAdapter sqlDA = new MySqlDataAdapter(sqlcmd);
                        DataSet sqlDS = new DataSet();
                        sqlDA.Fill(sqlDS, "labrecords");

                        dataGridView1.DataSource = sqlDS.Tables["labrecords"];

                        // Optional: keep all text centered
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void medSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = medSearch.Text.Trim();

            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                try
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
                WHERE mr.PatientID = @PatientID
                  AND (
                        mr.Medication LIKE @search OR 
                        mr.Allergies LIKE @search OR 
                        mr.Diagnosis LIKE @search OR 
                        mr.RecordID LIKE @search
                      )";

                    using (MySqlCommand sqlcmd = new MySqlCommand(query, conn))
                    {
                        sqlcmd.Parameters.AddWithValue("@PatientID", patientID);
                        sqlcmd.Parameters.AddWithValue("@search", "%" + searchValue + "%");

                        MySqlDataAdapter sqlDA = new MySqlDataAdapter(sqlcmd);
                        DataSet sqlDS = new DataSet();
                        sqlDA.Fill(sqlDS, "medrecords");

                        dataGridView2.DataSource = sqlDS.Tables["medrecords"];

                        // Optional: center all cells
                        foreach (DataGridViewColumn col in dataGridView2.Columns)
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        // Optional: keep Action button (if any) as last column
                        if (dataGridView2.Columns.Contains("Action"))
                            dataGridView2.Columns["Action"].DisplayIndex = dataGridView2.Columns.Count - 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
