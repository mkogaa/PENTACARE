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
    public partial class Billing : Form
    {
        private string patientID;
        private string patientName;
        private string admissionDate;
        private string dischargeDate;
        private string roomNo;
        private string roomID;
        private string roomType;
        private decimal roomFee;

        private DataTable billingTable;
        public DataTable BillingDataTable => billingTable;

        public Billing(string patientID, string patientName, string admissionDate, string dischargeDate, string roomNo, string roomID, string roomType, decimal roomFee)
        {

            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            this.patientID = patientID;
            this.patientName = patientName;
            this.admissionDate = admissionDate;
            this.dischargeDate = dischargeDate;
            this.roomNo = roomNo;
            this.roomID = roomID;
            this.roomType = roomType;
            this.roomFee = roomFee;


        }

        private void Billing_Load(object sender, EventArgs e)
        {
            lblPID.Text = patientID;
            lblName.Text = patientName;
            lblAD.Text = admissionDate;
            lblDD.Text = dischargeDate;
            lblRN.Text = roomNo;
            lblRID.Text = roomID;
            lblRType.Text = roomType;
            lblRFee.Text = "₱" + roomFee.ToString("N2");

            LoadBillingData();
        }

        private void LoadBillingData()
        {
            try
            {
                string connectionString = "server=127.0.0.1; database=pentacare; uid=root;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Create data table for billing items
                    billingTable = new DataTable();

                    billingTable.Columns.Add("Item");
                    billingTable.Columns.Add("Description");
                    billingTable.Columns.Add("Amount", typeof(decimal));

                    decimal totalAmount = 0;

                    // Calculate number of days stayed
                    int daysStayed = CalculateDaysStayed();


                    // 1. Add room charges (daily rate × number of days)
                    decimal totalRoomFee = roomFee * daysStayed;
                    billingTable.Rows.Add("Room", $"{roomType} Room ({daysStayed} days  ₱{roomFee:N2}/day)", totalRoomFee);
                    totalAmount += totalRoomFee;
                    lblRFee.Text = "₱" + totalRoomFee.ToString("N2");

                    // 2. Add medicine charges
                    string medicineQuery = @"SELECT mr.Medication, m.Price 
                                           FROM medical_records mr 
                                           JOIN medicines m ON mr.Medication = m.Medicine_Name 
                                           WHERE mr.PatientID = @patientID";

                    using (MySqlCommand cmd = new MySqlCommand(medicineQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@patientID", patientID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string medicineName = reader["Medication"].ToString();
                                decimal medicinePrice = Convert.ToDecimal(reader["Price"]);
                                billingTable.Rows.Add("Medicine", medicineName, medicinePrice);
                                totalAmount += medicinePrice;
                            }
                        }
                    }

                    // 3. Add lab services (only completed ones)
                    string labSQuery = @"SELECT ls.Lab_Name, pl.Fee, pl.Status, pl.Date_Ordered
                                      FROM patient_labrec pl 
                                      JOIN lab_services ls ON pl.LabID = ls.LabID 
                                      WHERE pl.PatientID = @patientID and pl.Status = 'Completed'";

                    using (MySqlCommand cmd = new MySqlCommand(labSQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@patientID", patientID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string labName = reader["Lab_Name"].ToString();
                                decimal labFee = Convert.ToDecimal(reader["Fee"]);
                                string status = reader["Status"].ToString();
                                DateTime dateOrdered = Convert.ToDateTime(reader["Date_Ordered"]);

                                billingTable.Rows.Add("Lab Test", $"{labName} ({status})", labFee);
                                totalAmount += labFee;
                            }
                        }
                    }

                    // 4. Add other services (daily services × number of days)
                    string serviceQuery = @"SELECT os.Service_Name, os.Service_Fee 
                                          FROM other_services os 
                                          WHERE os.Status = 'Available' 
                                          AND os.Service_Name IN ('Meal Service', 'Wifi Access', 'Room Cleaning', 'Air Conditioning', 'Nurse Assistance')";

                    using (MySqlCommand cmd = new MySqlCommand(serviceQuery, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string serviceName = reader["Service_Name"].ToString();
                                decimal dailyServiceFee = Convert.ToDecimal(reader["Service_Fee"]);
                                decimal totalServiceFee = dailyServiceFee * daysStayed;

                                billingTable.Rows.Add("Service", $"{serviceName} ({daysStayed} days)", totalServiceFee);
                                totalAmount += totalServiceFee;
                            }
                        }
                    }

                    // Setup DataGridView appearance
                    dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvBill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvBill.ReadOnly = true;
                    dgvBill.AllowUserToAddRows = false;
                    dgvBill.RowHeadersVisible = false;
                    dgvBill.EnableHeadersVisualStyles = false;
                    dgvBill.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
                    dgvBill.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvBill.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                    // Display in DataGridView
                    dgvBill.DataSource = billingTable;

                    // Format the amount column
                    dgvBill.Columns["Amount"].DefaultCellStyle.Format = "₱#,##0.00";

                    // Show total amount
                    lblTotal.Text = "₱" + totalAmount.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading billing data: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CalculateDaysStayed()
        {
            try
            {
                DateTime admitDate = DateTime.Parse(admissionDate);
                DateTime dischargeDateValue;

                // If discharge date is not set (0000-00-00), use current date
                if (string.IsNullOrEmpty(dischargeDate) || dischargeDate == "0000-00-00")
                {
                    dischargeDateValue = DateTime.Now;
                }
                else
                {
                    dischargeDateValue = DateTime.Parse(dischargeDate);
                }

                // Calculate total days (add 1 to include both admission and discharge days)
                TimeSpan stayDuration = dischargeDateValue - admitDate;
                int daysStayed = (int)Math.Ceiling(stayDuration.TotalDays + 1);

                // Ensure at least 1 day is charged
                return Math.Max(1, daysStayed);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating days stayed: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 1; // Default to 1 day if there's an error
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            BillingMain billingMain = new BillingMain();
            billingMain.Show();
            this.Hide();
        }

        private void btn_addCharge_Click(object sender, EventArgs e)
        {
            Add_Charge addChargeForm = new Add_Charge(patientID, billingTable);
            addChargeForm.ShowDialog();


            // After returning from Add_Charge, recalculate total
            decimal total = 0;
            foreach (DataRow row in billingTable.Rows)
            {
                total += Convert.ToDecimal(row["Amount"]);
            }
            lblTotal.Text = "₱" + total.ToString("N2");
        }

        private void Billing_Click(object sender, EventArgs e)
        {

        }

        private void btn_saveBill_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=127.0.0.1; database=pentacare; uid=root;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Combine all billing details into one text summary
                    StringBuilder detailsBuilder = new StringBuilder();
                    decimal totalAmount = 0;

                    foreach (DataRow row in billingTable.Rows)
                    {
                        string item = row["Item"].ToString();
                        string desc = row["Description"].ToString();
                        decimal amount = Convert.ToDecimal(row["Amount"]);

                        detailsBuilder.AppendLine($"{item}: {desc} - ₱{amount:N2}");
                        totalAmount += amount;
                    }

                    string billingDetails = detailsBuilder.ToString();

                    // Insert new single record
                    string insertQuery = @"INSERT INTO billing (PatientID, BillingDetails, TotalAmount)
                                   VALUES (@PatientID, @Details, @Total)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@PatientID", patientID);
                        cmd.Parameters.AddWithValue("@Details", billingDetails);
                        cmd.Parameters.AddWithValue("@Total", totalAmount);

                        cmd.ExecuteNonQuery();
                    }

                    string updateStatusQuery = @"UPDATE patient 
                                         SET Billing_Status = 'Paid' 
                                         WHERE PatientID = @PatientID";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateStatusQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@PatientID", patientID);
                        updateCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Billing summary saved successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving billing summary: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
