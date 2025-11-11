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

namespace PENTACARE
{
    public partial class Reports_Monitoring : Form
    {
        public Reports_Monitoring()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        }

        private void dgv_rPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void Reports_Monitoring_Load(object sender, EventArgs e)
        {
            dgv_Record.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Record.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_Record.AllowUserToAddRows = false;
            dgv_Record.RowHeadersVisible = false;


            dgv_Record.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv_Record.EnableHeadersVisualStyles = false;
            dgv_Record.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dgv_Record.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_Record.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            rb_PH.Checked = true;

            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void LoadPatientRecords(string search = "")
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection sqlconn = new MySqlConnection(dbconnect))
            {
                string query = "SELECT PatientID as 'Patient ID', " +
                               "Name as 'Patient Name', " +
                               "Age as 'Age', " +
                               "Gender as 'Gender', " +
                               "Address as 'Address', " +
                               "Contact_No as 'Contact Number', " +
                               "DATE_FORMAT(Admission_Date, '%M %d, %Y') as 'Admission Date', " +
                               "DATE_FORMAT(Discharge_Date, '%M %d, %Y') as 'Discharge Date' " +
                               "FROM patient WHERE Status = 'Discharged'";

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query += " AND Name LIKE @search";
                }


                MySqlCommand cmd = new MySqlCommand(query, sqlconn);

                if (!string.IsNullOrWhiteSpace(search))
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    sqlconn.Open();
                    adapter.Fill(dt);

                    dgv_Record.DataSource = dt;

                    AddButtonColumns();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading records: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadDoctorRecords(string search = "")
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection sqlconn = new MySqlConnection(dbconnect))
            {
                string query = "SELECT DoctorID as 'Doctor ID', " +
                               "Doctor_Name as 'Doctor Name', " +
                               "Specialty as 'Doctor Specialty', " +
                               "Contact_No as 'Contact Number' " +
                               "FROM doctor WHERE 1";

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query += " AND Doctor_Name LIKE @search";
                }

                MySqlCommand cmd = new MySqlCommand(query, sqlconn);

                if (!string.IsNullOrWhiteSpace(search))
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    sqlconn.Open();
                    adapter.Fill(dt);

                    dgv_Record.DataSource = dt;

                    AddButtonColumns();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading records: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadBillingSummary(string search = "")
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection sqlconn = new MySqlConnection(dbconnect))
            {
                string query = @"SELECT p.PatientID AS 'Patient ID',
                                        p.Name AS 'Patient Name',
                                        DATE_FORMAT(p.Discharge_Date, '%M %d, %Y') AS 'Discharge Date',
                                        b.TotalAmount AS 'Total Amount'
                                 FROM patient p
                                 INNER JOIN billing b ON p.PatientID = b.PatientID
                                 WHERE p.Billing_Status = 'Paid'";

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query += " AND p.Name LIKE @search";
                }

                MySqlCommand cmd = new MySqlCommand(query, sqlconn);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                }


                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    sqlconn.Open();
                    adapter.Fill(dt);
                    dgv_Record.DataSource = dt;

                    AddButtonColumns();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading billing summary: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddButtonColumns()
        {
            if (dgv_Record.Columns.Contains("btnView"))
                dgv_Record.Columns.Remove("btnView");

            DataGridViewButtonColumn viewBtn = new DataGridViewButtonColumn
            {
                HeaderText = "View Record",
                Text = "View",
                UseColumnTextForButtonValue = true,
                Name = "btnView",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };

            dgv_Record.Columns.Add(viewBtn);
        }

        private void rb_PH_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_PH.Checked)
                LoadPatientRecords();
        }

        private void rb_PR_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_PR.Checked)
                LoadDoctorRecords();
        }

        private void rb_BS_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_BS.Checked)
                LoadBillingSummary();
        }

        private void dgv_Record_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_Record.Columns[e.ColumnIndex].Name == "btnView")
            {
                string selectedID = dgv_Record.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (rb_PH.Checked)
                {
                    View_PatientRecord viewPatient = new View_PatientRecord(selectedID);
                    viewPatient.ShowDialog();
                }
                else if (rb_PR.Checked)
                {
                    View_DoctorRecord viewDoctor = new View_DoctorRecord(selectedID);
                    viewDoctor.ShowDialog();
                }
                else if (rb_BS.Checked)
                {
                    ViewBill viewbill = new ViewBill(selectedID);
                    viewbill.ShowDialog();
                }
            }
        }

        private void txtSearch_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (rb_PH.Checked)
            {
                LoadPatientRecords(searchText);
            }
            else if (rb_PR.Checked)
            {
                LoadDoctorRecords(searchText);
            }
            else if (rb_BS.Checked)
            {
                LoadBillingSummary(searchText);
            }
        }

        private void btn_AD_Click(object sender, EventArgs e)
        {
            AdmissionDischarge ad = new AdmissionDischarge();
            ad.Show();
            this.Hide();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

