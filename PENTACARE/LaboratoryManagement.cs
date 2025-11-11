using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace USERS_WINDOW
{
    public partial class LaboratoryManagement : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=pentacare;username=root;password=;");
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt;
        private int doctorID;

        public LaboratoryManagement(int loggedDoctorID)
        {
            InitializeComponent();

            doctorID = loggedDoctorID;

            StyleDataGridView();
            SetupSearchBox();
            SetupFilterComboBox();

            dgv_laboratory.CellContentClick += dgv_laboratory_CellContentClick;

            LoadLaboratoryData("", "Admitted", "All");
        }

        private void StyleDataGridView()
        {
            dgv_laboratory.BorderStyle = BorderStyle.None;
            dgv_laboratory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255);
            dgv_laboratory.DefaultCellStyle.BackColor = Color.White;
            dgv_laboratory.DefaultCellStyle.ForeColor = Color.Black;
            dgv_laboratory.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            dgv_laboratory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgv_laboratory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_laboratory.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dgv_laboratory.EnableHeadersVisualStyles = false;

            dgv_laboratory.GridColor = Color.FromArgb(180, 200, 230);
            dgv_laboratory.RowHeadersVisible = false;
            dgv_laboratory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_laboratory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
            dgv_laboratory.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv_laboratory.AllowUserToAddRows = false;
            dgv_laboratory.ReadOnly = true;
            dgv_laboratory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_laboratory.AllowUserToResizeColumns = true;
            dgv_laboratory.AllowUserToResizeRows = true;
            dgv_laboratory.AllowUserToOrderColumns = true;
            dgv_laboratory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_laboratory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_laboratory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        }

        private void LoadLaboratoryData(string search = "", string statusFilter = "Admitted", string genderFilter = "All")
        {
            try
            {
                con.Open();

                string query = @"
                                SELECT DISTINCT
                                    p.PatientID AS PatientID,
                                    p.Name AS FullName,
                                    p.Age,
                                    p.Gender,
                                    p.Address,
                                    p.Contact_No AS ContactNo,
                                    DATE_FORMAT(NULLIF(p.Admission_Date, '0000-00-00'), '%Y-%m-%d') AS AdmissionDate,
                                    IFNULL(r.Room_No, 'N/A') AS RoomNo,
                                    p.Status
                                FROM doctor_patient dp
                                JOIN patient p ON dp.PatientID = p.PatientID
                                LEFT JOIN room r ON p.RoomID = r.RoomID
                                WHERE dp.DoctorID = @DoctorID
                                  AND (p.PatientID LIKE @search OR p.Name LIKE @search)
                                ";

                if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
                    query += " AND p.Status = @status";

                if (!string.IsNullOrEmpty(genderFilter) && genderFilter != "All")
                    query += " AND p.Gender = @gender";

                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@DoctorID", doctorID);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");

                if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
                    da.SelectCommand.Parameters.AddWithValue("@status", statusFilter);

                if (!string.IsNullOrEmpty(genderFilter) && genderFilter != "All")
                    da.SelectCommand.Parameters.AddWithValue("@gender", genderFilter);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv_laboratory.Columns.Clear();
                dgv_laboratory.DataSource = dt;

                // Add "View Result" button column
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn
                {
                    HeaderText = "Action",
                    Name = "ViewResult",
                    Text = "View Result",
                    UseColumnTextForButtonValue = true,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.FromArgb(0, 102, 204),
                        ForeColor = Color.White,
                        Font = new Font("Century Gothic", 12, FontStyle.Bold)
                    }
                };
                dgv_laboratory.Columns.Add(btn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void SetupFilterComboBox()
        {
            cb_laboratory.Items.Clear();
            cb_laboratory.Items.Add("All");
            cb_laboratory.Items.Add("Male");
            cb_laboratory.Items.Add("Female");
            cb_laboratory.SelectedIndex = 0;

            cb_laboratory.SelectedIndexChanged += (s, e) =>
            {
                string selectedGender = cb_laboratory.SelectedItem?.ToString() ?? "All";
                string searchText = txt_laboratory_search.Text != "Search by Patient ID or Name"
                    ? txt_laboratory_search.Text
                    : "";
                LoadLaboratoryData(searchText, "Admitted", selectedGender);
            };
        }

        private void SetupSearchBox()
        {
            txt_laboratory_search.ForeColor = Color.Gray;
            txt_laboratory_search.Text = "Search by Patient ID or Name";

            txt_laboratory_search.GotFocus += (s, e) =>
            {
                if (txt_laboratory_search.Text == "Search by Patient ID or Name")
                {
                    txt_laboratory_search.Text = "";
                    txt_laboratory_search.ForeColor = Color.Black;
                }
            };

            txt_laboratory_search.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt_laboratory_search.Text))
                {
                    txt_laboratory_search.Text = "Search by Patient ID or Name";
                    txt_laboratory_search.ForeColor = Color.Gray;
                }
            };

            txt_laboratory_search.TextChanged += (s, e) =>
            {
                if (txt_laboratory_search.Text != "Search by Patient ID or Name")
                {
                    string gender = cb_laboratory.SelectedItem?.ToString() ?? "All";
                    LoadLaboratoryData(txt_laboratory_search.Text, "Admitted", gender);
                }
            };
        }

        private void dgv_laboratory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_laboratory.Columns[e.ColumnIndex].Name == "ViewResult")
            {
                try
                {
                    int patientID = Convert.ToInt32(dgv_laboratory.Rows[e.RowIndex].Cells["PatientID"].Value);
                    LaboratoryRecord recordForm = new LaboratoryRecord(patientID, doctorID);
                    recordForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening record: " + ex.Message);
                }
            }
        }

        private void btn_laboratory_discharge_Click(object sender, EventArgs e)
        {
            if (dgv_laboratory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a patient to discharge.");
                return;
            }

            string currentStatus = dgv_laboratory.SelectedRows[0].Cells["Status"].Value.ToString();
            if (currentStatus == "Discharged")
            {
                MessageBox.Show("This patient is already discharged.");
                return;
            }

            int patientID = Convert.ToInt32(dgv_laboratory.SelectedRows[0].Cells["PatientID"].Value);

            try
            {
                con.Open();

                // Check Billing_Status first
                string billingQuery = "SELECT Billing_Status FROM patient WHERE PatientID = @id";
                cmd = new MySqlCommand(billingQuery, con);
                cmd.Parameters.AddWithValue("@id", patientID);
                object billingStatusObj = cmd.ExecuteScalar();

                if (billingStatusObj != null && billingStatusObj.ToString() == "Unpaid")
                {
                    MessageBox.Show("Cannot discharge patient because the billing is unpaid.",
                                    "Discharge Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirm discharge
                DialogResult result = MessageBox.Show("Are you sure you want to discharge this patient?",
                                                      "Confirm Discharge", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;

                // Proceed with discharge
                string query = "UPDATE patient SET Status = 'Discharged', Discharge_Date = @date WHERE PatientID = @id";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", patientID);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.ExecuteNonQuery();

                // Free bed
                string bedQuery = "SELECT BedID FROM patient WHERE PatientID = @id";
                cmd = new MySqlCommand(bedQuery, con);
                cmd.Parameters.AddWithValue("@id", patientID);
                object bedIDObj = cmd.ExecuteScalar();

                if (bedIDObj != null)
                {
                    int bedID = Convert.ToInt32(bedIDObj);
                    string freeBedQuery = "UPDATE bed SET Status = 'Available' WHERE BedID = @bedID";
                    cmd = new MySqlCommand(freeBedQuery, con);
                    cmd.Parameters.AddWithValue("@bedID", bedID);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Patient successfully discharged.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error discharging patient: " + ex.Message);
            }
            finally
            {
                con.Close();
                string gender = cb_laboratory.SelectedItem?.ToString() ?? "All";
                LoadLaboratoryData("", "Admitted", gender);
            }
        }

        private void btn_laboratory_back_Click(object sender, EventArgs e)
        {
            UserDashboard dashboard = new UserDashboard(doctorID);
            dashboard.Show();
            this.Hide();
        }

        private void btn_record_assigntest_Click(object sender, EventArgs e)
        {
            if (dgv_laboratory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient first.");
                return;
            }

            int currentPatientID = Convert.ToInt32(dgv_laboratory.SelectedRows[0].Cells["PatientID"].Value);

            AssignLaboratoryTest assignForm = new AssignLaboratoryTest(currentPatientID, doctorID);
            assignForm.FormClosed += (s, args) =>
            {
                string gender = cb_laboratory.SelectedItem?.ToString() ?? "All";
                LoadLaboratoryData("", "Admitted", gender);
                LoadPatientInfo();
                this.Show();
            };
            assignForm.Show();
        }

        private void LoadPatientInfo() { }

        private void LaboratoryManagement_Load(object sender, EventArgs e)
        {
            LoadLaboratoryData("", "Admitted", "All");
        }

        private void txt_laboratory_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_laboratory_search.Text != "Search by Patient ID or Name")
            {
                string gender = cb_laboratory.SelectedItem?.ToString() ?? "All";
                LoadLaboratoryData(txt_laboratory_search.Text, "Admitted", gender);
            }
        }

        private void btn_laboratory_discharge_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
