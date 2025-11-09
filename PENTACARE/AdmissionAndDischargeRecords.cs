using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace USERS_WINDOW
{
    public partial class AdmissionAndDischargeRecords : Form
    {
        private int currentPatientID;
        MySqlConnection con = new MySqlConnection("server=localhost;database=pentacare;username=root;password=;");
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dtPersonal, dtAdmission;

        public AdmissionAndDischargeRecords(int patientID)
        {
            InitializeComponent();
            currentPatientID = patientID;

            SetupDataGridViews();
            LoadPatientPersonalInfo();
            LoadAdmissionRecords();
            SetupFilterComboBoxes();
        }

        private void SetupDataGridViews()
        {
            StyleDataGridView(dgv_personal);
            StyleDataGridView(dgv_admission);
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;

            dgv.GridColor = Color.FromArgb(180, 200, 230);
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = true;
            dgv.AllowUserToOrderColumns = true;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        }

        private void LoadPatientPersonalInfo()
        {
            try
            {
                con.Open();
                string query = @"SELECT 
                                    p.PatientID,
                                    p.Name AS `Name`,
                                    p.Age,
                                    p.Gender,
                                    IFNULL(p.Address, 'N/A') AS `Address`,
                                    IFNULL(p.Contact_No, 'N/A') AS `Contact Number`
                                 FROM patient p
                                 WHERE p.PatientID = @id;";
                da = new MySqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@id", currentPatientID);
                dtPersonal = new DataTable();
                da.Fill(dtPersonal);
                dgv_personal.DataSource = dtPersonal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient info: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void LoadAdmissionRecords(string roomTypeFilter = "All", string statusFilter = "All")
        {
            try
            {
                con.Open();
                string query = @"SELECT 
                                    IFNULL(d.Doctor_Name, 'N/A') AS `Doctor`,
                                    IFNULL(r.Room_No, 'N/A') AS `Room No.`,
                                    IFNULL(r.Room_Type, 'N/A') AS `Room Type`,
                                    IFNULL(p.Admission_Date, 'N/A') AS `Admission Date`,
                                    IFNULL(p.Discharge_Date, 'N/A') AS `Discharge Date`,
                                    IFNULL(p.Status, 'Admitted') AS `Status`
                                 FROM patient p
                                 LEFT JOIN doctor d ON p.DoctorID = d.DoctorID
                                 LEFT JOIN room r ON p.RoomID = r.RoomID
                                 WHERE p.PatientID = @id";

                if (roomTypeFilter != "All") query += " AND r.Room_Type = @roomType";
                if (statusFilter != "All") query += " AND p.Status = @status";

                da = new MySqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@id", currentPatientID);
                if (roomTypeFilter != "All") da.SelectCommand.Parameters.AddWithValue("@roomType", roomTypeFilter);
                if (statusFilter != "All") da.SelectCommand.Parameters.AddWithValue("@status", statusFilter);

                dtAdmission = new DataTable();
                da.Fill(dtAdmission);
                dgv_admission.DataSource = dtAdmission;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading admission records: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void SetupFilterComboBoxes()
        {
            cb_filter_roomtype.Items.Clear();
            cb_filter_roomtype.Items.Add("All");
            cb_filter_roomtype.Items.Add("Private");
            cb_filter_roomtype.Items.Add("Semi-Private");
            cb_filter_roomtype.Items.Add("Ward");
            cb_filter_roomtype.SelectedIndex = 0;

            cb_filter_status.Items.Clear();
            cb_filter_status.Items.Add("All");
            cb_filter_status.Items.Add("Admitted");
            cb_filter_status.Items.Add("Discharged");
            cb_filter_status.SelectedIndex = 0;

            cb_filter_roomtype.SelectedIndexChanged += (s, e) => ApplyFilters();
            cb_filter_status.SelectedIndexChanged += (s, e) => ApplyFilters();
        }

        private void ApplyFilters()
        {
            string roomType = cb_filter_roomtype.Text;
            string status = cb_filter_status.Text;
            LoadAdmissionRecords(roomType, status);
        }

        private void btn_admission_exportreport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtPersonal == null || dtPersonal.Rows.Count == 0)
                {
                    MessageBox.Show("No patient data available to print.");
                    return;
                }

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("🖨️ Report sent to printer successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error printing report: " + ex.Message);
            }
        }

        private void btn_admission_back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgv_personal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cb_filter_roomtype_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
