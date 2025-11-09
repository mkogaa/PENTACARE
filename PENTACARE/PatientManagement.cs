using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace USERS_WINDOW
{
    public partial class PatientManagement : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=pentacare;username=root;password=;");
        MySqlDataAdapter da;
        DataTable dt;
        private int doctorID;
        private UserDashboard dashboardForm;

        public PatientManagement(UserDashboard dashboard, int loggedDoctorID)
        {
            InitializeComponent();

            doctorID = loggedDoctorID;
            dashboardForm = dashboard;
            InitializeFilter();
            StyleDataGridView();
            SetupPlaceholder();
            LoadPatients();

            txt_patient_search.TextChanged += txt_patient_search_TextChanged;
            cb_patient_filter.SelectedIndexChanged += cb_patient_filter_SelectedIndexChanged;
            btn_patient_back.Click += btn_patient_back_Click;

            this.WindowState= FormWindowState.Maximized;
        }

       
        private void LoadPatients(string search = "", string genderFilter = "")
        {
            try
            {
                con.Open();

                string query = @"
              SELECT DISTINCT
                  p.PatientID AS 'Patient ID',
                  p.Name AS 'Full Name',
                  p.Age,
                  p.Gender,
                  p.Address,
                  p.Contact_No AS 'Contact No',
                  DATE_FORMAT(NULLIF(p.Admission_Date, '0000-00-00'), '%Y-%m-%d') AS 'Admission Date',
                  r.Room_No AS 'Room No'
              FROM doctor_patient dp
              JOIN patient p ON dp.PatientID = p.PatientID
              LEFT JOIN room r ON p.RoomID = r.RoomID
              WHERE dp.DoctorID = @DoctorID
                AND p.Status = 'Admitted'";


               

                if (!string.IsNullOrWhiteSpace(search) && txt_patient_search.ForeColor != Color.Gray)
                {
                    query += " AND (p.PatientID LIKE @search OR p.Name LIKE @search)";
                }

                if (!string.IsNullOrEmpty(genderFilter) && genderFilter != "All")
                {
                    query += " AND p.Gender = @genderFilter";
                }

                query += " ORDER BY p.PatientID;";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                cmd.Parameters.AddWithValue("@genderFilter", genderFilter);
                cmd.Parameters.AddWithValue("@DoctorID", doctorID);

                da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                dgv_patient.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient data:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        
        private void txt_patient_search_TextChanged(object sender, EventArgs e)
        {
            string searchText = txt_patient_search.ForeColor == Color.Gray ? "" : txt_patient_search.Text.Trim();
            string selectedGender = cb_patient_filter.SelectedItem?.ToString() ?? "";
            LoadPatients(searchText, selectedGender);
        }

        
        private void cb_patient_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string searchText = txt_patient_search.ForeColor == Color.Gray ? "" : txt_patient_search.Text.Trim();
            string selectedGender = cb_patient_filter.SelectedItem?.ToString() ?? "";
            LoadPatients(searchText, selectedGender);
        }

        
        private void StyleDataGridView()
        {
            dgv_patient.BorderStyle = BorderStyle.None;
            dgv_patient.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255);
            dgv_patient.DefaultCellStyle.BackColor = Color.White;
            dgv_patient.DefaultCellStyle.ForeColor = Color.Black;
            dgv_patient.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            dgv_patient.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgv_patient.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_patient.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dgv_patient.EnableHeadersVisualStyles = false;

            dgv_patient.GridColor = Color.FromArgb(180, 200, 230);
            dgv_patient.RowHeadersVisible = false;
            dgv_patient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_patient.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
            dgv_patient.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv_patient.AllowUserToAddRows = false;
            dgv_patient.ReadOnly = true;
            dgv_patient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_patient.AllowUserToResizeColumns = true;
            dgv_patient.AllowUserToResizeRows = true;
            dgv_patient.AllowUserToOrderColumns = true;
            dgv_patient.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_patient.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_patient.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        }

        
        private void SetupPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txt_patient_search.Text))
            {
                txt_patient_search.Text = "Search by Name or Patient ID...";
                txt_patient_search.ForeColor = Color.Gray;
            }

            txt_patient_search.GotFocus += (s, e) =>
            {
                if (txt_patient_search.ForeColor == Color.Gray)
                {
                    txt_patient_search.Text = "";
                    txt_patient_search.ForeColor = Color.Black;
                }
            };

            txt_patient_search.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt_patient_search.Text))
                {
                    txt_patient_search.Text = "Search by Name or Patient ID...";
                    txt_patient_search.ForeColor = Color.Gray;

                    string selectedGender = cb_patient_filter.SelectedItem?.ToString() ?? "";
                    LoadPatients("", selectedGender);
                }
            };
        }

        
        private void InitializeFilter()
        {
            cb_patient_filter.Items.Clear();
            cb_patient_filter.Items.Add("All");
            cb_patient_filter.Items.Add("Male");
            cb_patient_filter.Items.Add("Female");
            cb_patient_filter.SelectedIndex = 0;
        }

        
        private void btn_patient_back_Click(object sender, EventArgs e)
        {
            dashboardForm.Show();  // ✅ show the existing dashboard
            this.Close();
        }

        private void PatientManagement_Load(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void dgv_patient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
