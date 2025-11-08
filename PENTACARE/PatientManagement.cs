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

        public PatientManagement()
        {
            InitializeComponent();
            InitializeFilter();
            StyleDataGridView();
            SetupPlaceholder();
            LoadPatients();

            txt_patient_search.TextChanged += txt_patient_search_TextChanged;
            cb_patient_filter.SelectedIndexChanged += cb_patient_filter_SelectedIndexChanged;
            btn_patient_back.Click += btn_patient_back_Click;
        }

        private void LoadPatients(string search = "", string statusFilter = "")
        {
            try
            {
                con.Open();

                string query = @"SELECT 
                                    PatientID AS 'Patient ID',
                                    Name AS 'Full Name',
                                    Age,
                                    Gender,
                                    Address,
                                    Contact_No AS 'Contact No',
                                    Admission_Date AS 'Admission Date',
                                    Discharge_Date AS 'Discharge Date',
                                    Status
                                 FROM patient
                                 WHERE 1=1";


                if (!string.IsNullOrWhiteSpace(search))
                {
                    query += " AND (PatientID LIKE @search OR Name LIKE @search)";
                }


                if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
                {
                    query += " AND Status = @statusFilter";
                }

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                cmd.Parameters.AddWithValue("@statusFilter", statusFilter);

                da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dgv_patient.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient data:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void txt_patient_search_TextChanged(object sender, EventArgs e)
        {
            string searchText = txt_patient_search.ForeColor == Color.Gray ? "" : txt_patient_search.Text.Trim();
            string selectedStatus = cb_patient_filter.SelectedItem?.ToString() ?? "";
            LoadPatients(searchText, selectedStatus);
        }

        private void cb_patient_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string searchText = txt_patient_search.ForeColor == Color.Gray ? "" : txt_patient_search.Text.Trim();
            string selectedStatus = cb_patient_filter.SelectedItem?.ToString() ?? "";
            LoadPatients(searchText, selectedStatus);
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
                }
            };
        }

        private void InitializeFilter()
        {
            cb_patient_filter.Items.Clear();
            cb_patient_filter.Items.Add("All");
            cb_patient_filter.Items.Add("Admitted");
            cb_patient_filter.Items.Add("Discharged");
            cb_patient_filter.SelectedIndex = 0;
        }

        private void btn_patient_back_Click(object sender, EventArgs e)
        {
            UserDashboard userdashboard = new UserDashboard(0);
            userdashboard.Show();
            this.Close();
        }

        private void PatientManagement_Load(object sender, EventArgs e)
        {

        }

        private void dgv_patient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
