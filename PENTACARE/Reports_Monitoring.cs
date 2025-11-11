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
        }

        private void LoadPatientRecords()
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


                MySqlCommand cmd = new MySqlCommand(query, sqlconn);
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

        private void LoadDoctorRecords()
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection sqlconn = new MySqlConnection(dbconnect))
            {
                string query = "SELECT DoctorID as 'Doctor ID', " +
                               "Doctor_Name as 'Doctor Name', " +
                               "Specialty as 'Doctor Specialty', " +
                               "Contact_No as 'Contact Number' " +
                               "FROM doctor";


                MySqlCommand cmd = new MySqlCommand(query, sqlconn);
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

        private void LoadBillingSummary()
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

                MySqlCommand cmd = new MySqlCommand(query, sqlconn);
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
    }
}
