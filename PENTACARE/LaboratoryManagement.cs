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

        public LaboratoryManagement()
        {
            InitializeComponent();


            StyleDataGridView();
            SetupSearchBox();
            SetupFilterComboBox();
            dgv_laboratory.CellContentClick += dgv_laboratory_CellContentClick;
            LoadLaboratoryData();
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


        private void LoadLaboratoryData(string search = "", string statusFilter = "All")
        {
            try
            {
                con.Open();

                string query = @"SELECT 
                                p.PatientID,
                                p.Name AS PatientName,
                                p.Gender,
                                p.Age,
                                IFNULL(r.Room_No, 'N/A') AS Room_No,
                                IFNULL(p.Status, 'Admitted') AS Status,
                                IFNULL(d.Doctor_Name, 'N/A') AS Doctor_Name,
                                p.RoomID AS AdmissionID,
                                p.Admission_Date
                            FROM patient p
                            LEFT JOIN room r ON p.RoomID = r.RoomID
                            LEFT JOIN doctor d ON p.DoctorID = d.DoctorID
                            WHERE (p.PatientID LIKE @search OR p.Name LIKE @search)";

                if (statusFilter != "All" && !string.IsNullOrEmpty(statusFilter))
                    query += " AND Status = @status";

                da = new MySqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");

                if (statusFilter != "All" && !string.IsNullOrEmpty(statusFilter))
                    da.SelectCommand.Parameters.AddWithValue("@status", statusFilter);

                dt = new DataTable();
                da.Fill(dt);

                dgv_laboratory.Columns.Clear();
                dgv_laboratory.DataSource = dt;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.HeaderText = "Action";
                btn.Name = "ViewResult";
                btn.Text = "View Result";
                btn.UseColumnTextForButtonValue = true;
                btn.DefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
                btn.DefaultCellStyle.ForeColor = Color.White;
                btn.DefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                dgv_laboratory.Columns.Add(btn);

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
                con.Close();
            }
        }


        private void SetupFilterComboBox()
        {
            cb_laboratory.Items.Clear();
            cb_laboratory.Items.Add("All");
            cb_laboratory.Items.Add("Admitted");
            cb_laboratory.Items.Add("Discharged");
            cb_laboratory.SelectedIndex = 0;


            cb_laboratory.SelectedIndexChanged += (s, e) =>
            {
                string selectedStatus = cb_laboratory.SelectedItem?.ToString() ?? "All";
                string searchText = txt_laboratory_search.Text != "Search by Patient ID or Name"
                    ? txt_laboratory_search.Text
                    : "";
                LoadLaboratoryData(searchText, selectedStatus);
            };
        }

        private void txt_laboratory_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_laboratory_search.Text != "Search by Patient ID or Name")
            {
                string status = cb_laboratory.SelectedItem?.ToString() ?? "All";
                LoadLaboratoryData(txt_laboratory_search.Text, status);
            }
        }

        private void SetupSearchBox()
        {
            txt_laboratory_search.ForeColor = Color.Gray;
            txt_laboratory_search.Font = new Font("Century Gothic", 20);
            txt_laboratory_search.Text = "Search by Patient ID or Name";

            txt_laboratory_search.GotFocus += RemovePlaceholder;
            txt_laboratory_search.LostFocus += AddPlaceholder;
            txt_laboratory_search.TextChanged += txt_laboratory_search_TextChanged;
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (txt_laboratory_search.Text == "Search by Patient ID or Name")
            {
                txt_laboratory_search.Text = "";
                txt_laboratory_search.ForeColor = Color.Black;
            }
        }

        private void AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_laboratory_search.Text))
            {
                txt_laboratory_search.Text = "Search by Patient ID or Name";
                txt_laboratory_search.ForeColor = Color.Gray;
            }
        }

        private void txt_laboratory_search_TextChanged_1(object sender, EventArgs e)
        {
            if (txt_laboratory_search.Text != "Search by Patient ID or Name")
            {
                string status = cb_laboratory.SelectedItem?.ToString() ?? "All";
                LoadLaboratoryData(txt_laboratory_search.Text, status);
            }
        }


        private void dgv_laboratory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_laboratory.Columns[e.ColumnIndex].Name == "ViewResult")
            {
                try
                {
                    int patientID = Convert.ToInt32(dgv_laboratory.Rows[e.RowIndex].Cells["PatientID"].Value);
                    LaboratoryRecord recordForm = new LaboratoryRecord(patientID);
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
                string query = "UPDATE patient SET Status = 'Discharged' WHERE PatientID = @id";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", patientID);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Patient successfully discharged.");
                LoadLaboratoryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error discharging patient: " + ex.Message);
            }
        }

        private void btn_laboratory_back_Click(object sender, EventArgs e)
        {
            UserDashboard dashboard = new UserDashboard(0);
            dashboard.Show();
            this.Close();
        }

        private void LaboratoryManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
