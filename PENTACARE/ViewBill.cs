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
    public partial class ViewBill : Form
    {
        private string patientID;
        public ViewBill(string patientID)
        {
            InitializeComponent();
            this.patientID = patientID;
        }

        private void ViewBill_Load(object sender, EventArgs e)
        {
            LoadBillingData();
            LoadPatientAndRoomInfo();
        }

        private void LoadPatientAndRoomInfo()
        {
            string connectionString = "server=127.0.0.1; database=pentacare; uid=root;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        p.Name AS PatientName,
                        DATE_FORMAT(p.Admission_Date, '%M %d, %Y') AS AdmissionDate,
                        DATE_FORMAT(p.Discharge_Date, '%M %d, %Y') AS DischargeDate,
                        r.Room_No AS RoomNo,
                        r.RoomID AS RoomID,
                        r.Room_Type AS RoomType,
                        r.Room_Rate AS RoomFee
                    FROM patient p
                    INNER JOIN room r ON p.RoomID = r.RoomID
                    WHERE p.PatientID = @PatientID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientID);
                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblPID.Text = patientID;
                                lblName.Text = reader["PatientName"].ToString();
                                lblAD.Text = reader["AdmissionDate"].ToString();
                                lblDD.Text = reader["DischargeDate"].ToString();
                                lblRN.Text = reader["RoomNo"].ToString();
                                lblRID.Text = reader["RoomID"].ToString();
                                lblRType.Text = reader["RoomType"].ToString();
                                lblRFee.Text = "₱" + Convert.ToDecimal(reader["RoomFee"]).ToString("N2");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading patient details: " + ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadBillingData()
        {
            string connectionString = "server=127.0.0.1; database=pentacare; uid=root;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT BillingID AS 'Billing ID',
                                        PatientID AS 'Patient ID',
                                        BillingDetails AS 'Billing Details',
                                        TotalAmount AS 'Total Amount',
                                        DATE_FORMAT(DateAdded, '%M %d, %Y %r') AS 'Date Issued'
                                 FROM billing
                                 WHERE PatientID = @PatientID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientID);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    try
                    {
                        conn.Open();
                        adapter.Fill(dt);

                        dgvBill.DataSource = dt;
                        dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvBill.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                        dgvBill.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        dgvBill.RowHeadersVisible = false;

                        dgvBill.AllowUserToResizeRows = false;
                        dgvBill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvBill.MultiSelect = false;

                        dgvBill.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
                        dgvBill.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        dgvBill.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                        dgvBill.EnableHeadersVisualStyles = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading billing details: " + ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
