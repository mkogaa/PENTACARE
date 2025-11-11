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
            this.Hide();
        }

        private void Records_Load(object sender, EventArgs e)
        {
            filterGender.SelectedIndex = 0;

            string selectedGender = filterGender.SelectedItem != null ? filterGender.SelectedItem.ToString() : "All";
            string searchText = textBox1.Text.Trim();

            if (con.State == ConnectionState.Closed)
                con.Open();

            string query = @"SELECT DISTINCT p.PatientID AS 'Patient ID', p.Name, p.Age, p.Address, p.Contact_No AS 'Contact',
                        DATE_FORMAT(NULLIF(p.Admission_Date,'0000-00-00'), '%Y-%m-%d') AS 'Admission Date',
                        DATE_FORMAT(NULLIF(p.Discharge_Date,'0000-00-00'), '%Y-%m-%d') AS 'Discharge Date',
                        r.Room_No AS 'Room No'
                        FROM doctor_patient dp
                        JOIN patient p ON dp.PatientID = p.PatientID
                        LEFT JOIN room r ON p.RoomID = r.RoomID
                        WHERE dp.DoctorID = @DoctorID AND p.Status = 'Discharged'";

            if (selectedGender != "All" && selectedGender != "")
                query += " AND p.Gender = @gender";

            if (searchText != "")
                query += " AND (p.Name LIKE @search OR p.PatientID LIKE @search)";

            query += " ORDER BY p.Name;";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@DoctorID", doctorID);

            if (selectedGender != "All" && selectedGender != "")
                cmd.Parameters.AddWithValue("@gender", selectedGender);

            if (searchText != "")
                cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dgvMedRec.DataSource = dt;
            }
            else
            {
                dgvMedRec.DataSource = null;
                MessageBox.Show("No matching records found.");
            }

            con.Close();

            dgvMedRec.Size = new Size(1713, 485);
            dgvMedRec.BorderStyle = BorderStyle.None;
            dgvMedRec.RowHeadersVisible = false;
            dgvMedRec.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedRec.MultiSelect = false;
            dgvMedRec.AllowUserToAddRows = false;
            dgvMedRec.ReadOnly = true;

            dgvMedRec.DefaultCellStyle.BackColor = Color.White;
            dgvMedRec.DefaultCellStyle.ForeColor = Color.Black;
            dgvMedRec.DefaultCellStyle.Font = new Font("Century Gothic", 10); 
            dgvMedRec.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215); 
            dgvMedRec.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvMedRec.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245); 

            dgvMedRec.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 70, 160);
            dgvMedRec.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMedRec.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            dgvMedRec.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMedRec.EnableHeadersVisualStyles = false;
            dgvMedRec.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgvMedRec.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMedRec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvMedRec.Columns["Patient ID"].FillWeight = 50;
            dgvMedRec.Columns["Name"].FillWeight = 150;
            dgvMedRec.Columns["Age"].FillWeight = 40;
            dgvMedRec.Columns["Contact"].FillWeight = 90;
            dgvMedRec.Columns["Address"].FillWeight = 100;
            dgvMedRec.Columns["Room No"].FillWeight = 70;
            dgvMedRec.Columns["Admission Date"].FillWeight = 80;
            dgvMedRec.Columns["Discharge Date"].FillWeight = 80;

            dgvMedRec.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            DataGridViewButtonColumn viewBtn = new DataGridViewButtonColumn();
            viewBtn.Name = "ViewDetails";
            viewBtn.HeaderText = "Action";
            viewBtn.Text = "View Details";
            viewBtn.UseColumnTextForButtonValue = true;
            dgvMedRec.Columns.Add(viewBtn);
        }


        private void filterGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGender = filterGender.SelectedItem != null ? filterGender.SelectedItem.ToString() : "All";

            if (con.State == ConnectionState.Closed)
                con.Open();

            string query = @"SELECT DISTINCT p.PatientID AS 'Patient ID', p.Name, p.Age, p.Gender, 
                            p.Contact_No AS 'Contact', p.Address,
                            DATE_FORMAT(NULLIF(p.Admission_Date,'0000-00-00'), '%Y-%m-%d') AS 'Admission Date',
                            DATE_FORMAT(NULLIF(p.Discharge_Date,'0000-00-00'), '%Y-%m-%d') AS 'Discharge Date',
                            r.Room_No AS 'Room No' FROM doctor_patient dp
                            JOIN patient p ON dp.PatientID = p.PatientID
                            LEFT JOIN room r ON p.RoomID = r.RoomID
                            WHERE dp.DoctorID = @DoctorID AND p.Status = 'Discharged'";

            if (selectedGender != "All" && selectedGender != "")
                query += " AND p.Gender = @gender";

            query += " ORDER BY p.Name;";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@DoctorID", doctorID);

            if (selectedGender != "All" && selectedGender != "")
                cmd.Parameters.AddWithValue("@gender", selectedGender);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dgvMedRec.DataSource = dt;
            }
            else
            {
                dgvMedRec.DataSource = null;
                MessageBox.Show("No records found.");
            }

            con.Close();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            string selectedGender = filterGender.SelectedItem != null ? filterGender.SelectedItem.ToString() : "All";

            if (con.State == ConnectionState.Closed)
                con.Open();

            string query = @"SELECT DISTINCT p.PatientID AS 'Patient ID', p.Name, p.Age, p.Address, 
                            p.Contact_No AS 'Contact', 
                            DATE_FORMAT(NULLIF(p.Admission_Date,'0000-00-00'),'%Y-%m-%d') AS 'Admission Date', 
                            DATE_FORMAT(NULLIF(p.Discharge_Date,'0000-00-00'),'%Y-%m-%d') AS 'Discharge Date', 
                            r.Room_No AS 'Room No', 
                            mr.BP, mr.HR, mr.Temp, mr.Allergies, mr.Diagnosis, 
                            mr.DiagnosisNotes AS 'Diagnosis Notes', 
                            mr.ExamFindings AS 'Findings', 
                            mr.Treatment, mr.Medication 
                            FROM doctor_patient dp 
                            JOIN patient p ON dp.PatientID = p.PatientID 
                            LEFT JOIN room r ON p.RoomID = r.RoomID 
                            LEFT JOIN medical_records mr ON p.PatientID = mr.PatientID 
                            WHERE dp.DoctorID = @DoctorID AND p.Status = 'Discharged'";

            if (selectedGender != "All" && selectedGender != "")
                query += " AND p.Gender = @gender";

            if (searchText != "")
                query += " AND (p.PatientID LIKE @search OR p.Name LIKE @search)";

            query += " ORDER BY mr.RecordDate DESC;";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@DoctorID", doctorID);

            if (selectedGender != "All" && selectedGender != "")
                cmd.Parameters.AddWithValue("@gender", selectedGender);

            if (searchText != "")
                cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dgvMedRec.DataSource = dt;
            }
            else
            {
                dgvMedRec.DataSource = null;
                MessageBox.Show("No matching records found.");
            }

            con.Close();
        }

        private void dgvMedRec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvMedRec.Columns[e.ColumnIndex].Name == "ViewDetails")
            {
                int patientID = Convert.ToInt32(dgvMedRec.Rows[e.RowIndex].Cells["Patient ID"].Value);
                PatientMedicalRecord detailsForm = new PatientMedicalRecord(this, patientID);
                detailsForm.ShowDialog();
            }
        }
    }
}
