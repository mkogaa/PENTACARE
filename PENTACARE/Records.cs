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
using USERS_WINDOW;

namespace PENTACARE
{
    public partial class Records : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=pentacare;username=root;password=;");
        MySqlDataAdapter da;
        DataTable dt;

        private UserDashboard dashboardForm;
        private int doctorID;

        public Records(UserDashboard dashboard, int loggedDoctorID)
        {
            InitializeComponent();
            doctorID = loggedDoctorID;
            dashboardForm = dashboard;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            dashboardForm.Show();
            this.Close();
        }

        private void Records_Load(object sender, EventArgs e)
        {
            filterGender.SelectedIndex = 0;
            try
            {
                con.Open();

                string query = @"
    SELECT DISTINCT
        p.PatientID AS 'Patient ID',
        p.Name,
        p.Age,
        p.Address,
        p.Contact_No AS 'Contact',
        DATE_FORMAT(NULLIF(p.Admission_Date, '0000-00-00'), '%Y-%m-%d') AS 'Admission Date',
        DATE_FORMAT(NULLIF(p.Discharge_Date, '0000-00-00'), '%Y-%m-%d') AS 'Discharge Date',
        r.Room_No AS 'Room No',
        mr.BP,
        mr.HR,
        mr.Temp,
        mr.Allergies,
        mr.Diagnosis,
        mr.DiagnosisNotes AS 'Diagnosis',
        mr.ExamFindings AS 'Findings',
        mr.Treatment,
        mr.Medication
    FROM doctor_patient dp
    JOIN patient p ON dp.PatientID = p.PatientID
    LEFT JOIN room r ON p.RoomID = r.RoomID
    LEFT JOIN medical_records mr ON p.PatientID = mr.PatientID
    WHERE dp.DoctorID = @DoctorID
      AND p.Status = 'Discharged'";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DoctorID", doctorID);

                da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading discharged patient data:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            dataGridView1.Size = new Size(1713, 485);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;



            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // use fixed widths

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void filterGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGender = filterGender.SelectedItem?.ToString() ?? "All";
           
            try
            {
                con.Open();

                string query = @"
        SELECT DISTINCT
            p.PatientID AS 'Patient ID',
            p.Name,
            p.Age,
            p.Address,
            p.Contact_No AS 'Contact',
            DATE_FORMAT(NULLIF(p.Admission_Date, '0000-00-00'), '%Y-%m-%d') AS 'Admission Date',
            DATE_FORMAT(NULLIF(p.Discharge_Date, '0000-00-00'), '%Y-%m-%d') AS 'Discharge Date',
            r.Room_No AS 'Room No',
            mr.BP,
            mr.HR,
            mr.Temp,
            mr.Allergies,
            mr.Diagnosis,
            mr.DiagnosisNotes AS 'Diagnosis',
            mr.ExamFindings AS 'Findings',
            mr.Treatment,
            mr.Medication
        FROM doctor_patient dp
        JOIN patient p ON dp.PatientID = p.PatientID
        LEFT JOIN room r ON p.RoomID = r.RoomID
        LEFT JOIN medical_records mr ON p.PatientID = mr.PatientID
        WHERE dp.DoctorID = @DoctorID
          AND p.Status = 'Discharged'";

                // Add gender filter if not "All"
                if (!string.IsNullOrEmpty(selectedGender) && selectedGender != "All")
                {
                    query += " AND p.Gender = @gender";
                }

                query += " ORDER BY mr.RecordDate DESC;";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DoctorID", doctorID);

                if (!string.IsNullOrEmpty(selectedGender) && selectedGender != "All")
                    cmd.Parameters.AddWithValue("@gender", selectedGender);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering by gender:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            string selectedGender = filterGender.SelectedItem?.ToString() ?? "All";

            try
            {
                con.Open();

                string query = @"
        SELECT DISTINCT
            p.PatientID AS 'Patient ID',
            p.Name,
            p.Age,
            p.Address,
            p.Contact_No AS 'Contact',
            DATE_FORMAT(NULLIF(p.Admission_Date, '0000-00-00'), '%Y-%m-%d') AS 'Admission Date',
            DATE_FORMAT(NULLIF(p.Discharge_Date, '0000-00-00'), '%Y-%m-%d') AS 'Discharge Date',
            r.Room_No AS 'Room No',
            mr.BP,
            mr.HR,
            mr.Temp,
            mr.Allergies,
            mr.Diagnosis,
            mr.DiagnosisNotes AS 'Diagnosis',
            mr.ExamFindings AS 'Findings',
            mr.Treatment,
            mr.Medication
        FROM doctor_patient dp
        JOIN patient p ON dp.PatientID = p.PatientID
        LEFT JOIN room r ON p.RoomID = r.RoomID
        LEFT JOIN medical_records mr ON p.PatientID = mr.PatientID
        WHERE dp.DoctorID = @DoctorID
          AND p.Status = 'Discharged'";

                // Gender filter
                if (!string.IsNullOrEmpty(selectedGender) && selectedGender != "All")
                    query += " AND p.Gender = @gender";

                // Search filter
                if (!string.IsNullOrEmpty(searchText))
                    query += " AND (p.PatientID LIKE @search OR p.Name LIKE @search)";

                query += " ORDER BY mr.RecordDate DESC;";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DoctorID", doctorID);

                if (!string.IsNullOrEmpty(selectedGender) && selectedGender != "All")
                    cmd.Parameters.AddWithValue("@gender", selectedGender);

                if (!string.IsNullOrEmpty(searchText))
                    cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering data:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
