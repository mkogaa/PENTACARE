

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
    public partial class BillingMain : Form
    {
        public BillingMain()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

        }


        private void btn_backB_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void BillingMain_Load(object sender, EventArgs e)
        {
            LoadBillingData();
        }

        private void LoadBillingData()
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";

            string query = @"SELECT 
                            PatientID AS 'Patient ID',
                            Name AS 'Full Name',
                            Age,
                            Gender,
                            Address,
                            Contact_No AS 'Contact No',
                            DATE_FORMAT(NULLIF(Admission_Date, '0000-00-00'), '%Y-%m-%d') AS 'Admission Date',
                            DATE_FORMAT(NULLIF(Discharge_Date, '0000-00-00'), '%Y-%m-%d') AS 'Discharge Date',
                            RoomID AS 'Room ID',
                            Status,
                            Billing_Status AS 'Billing Status'
                        FROM patient
                        WHERE Status = 'Admitted' AND Billing_Status = 'Unpaid';
                    ";

            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvBilling.DataSource = dt;

                    dgvBilling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvBilling.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvBilling.ReadOnly = true;
                    dgvBilling.AllowUserToAddRows = false;
                    dgvBilling.RowHeadersVisible = false;
                    dgvBilling.EnableHeadersVisualStyles = false;
                    dgvBilling.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
                    dgvBilling.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvBilling.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void dgvBilling_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)            {

                DataGridViewRow row = dgvBilling.Rows[e.RowIndex];

                string patientID = row.Cells["Patient ID"].Value.ToString();
                string patientName = row.Cells["Full Name"].Value.ToString();
                string admissionDate = row.Cells["Admission Date"].Value.ToString();
                string dischargeDate = row.Cells["Discharge Date"].Value.ToString();
                string roomID = row.Cells["Room ID"].Value.ToString();

                string roomNo = "";
                string roomType = "";
                decimal roomFee = 0;

                using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1; database=pentacare; uid=root;"))
                {
                    conn.Open();
                    string query = "SELECT Room_No, Room_Type, Room_Rate FROM room WHERE RoomID = @RoomID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomID", roomID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                roomNo = reader["Room_No"].ToString();
                                roomType = reader["Room_Type"].ToString();
                                roomFee = Convert.ToDecimal(reader["Room_Rate"]);
                            }
                        }
                    }
                }

                Billing billingForm = new Billing(patientID,patientName, admissionDate, dischargeDate, roomNo, roomID, roomType, roomFee);
                billingForm.Show();

                this.Hide();
            }
        }
    }
}
