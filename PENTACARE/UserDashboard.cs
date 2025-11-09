using MySql.Data.MySqlClient;
using PENTACARE;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace USERS_WINDOW
{
    public partial class UserDashboard : Form
    {
        private int patientID;
        private string loggedUser;
        private int doctorID;


        MySqlConnection con = new MySqlConnection("server=localhost;database=pentacare;username=root;password=;");

        public UserDashboard(int id)
        {
            InitializeComponent();
            doctorID = id;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string query = "SELECT Doctor_Name FROM doctor WHERE DoctorID = @id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", doctorID);

                object result = cmd.ExecuteScalar();

                if (result != null)
                    userName.Text = result.ToString();
                else
                    userName.Text = "Doctor";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            LoadDashboardData();
        }
        private void LoadDashboardData()
        {
            try
            {
                con.Open();

                MySqlCommand cmdPatients = new MySqlCommand("SELECT COUNT(*) FROM patient", con);
                txtTP.Text = cmdPatients.ExecuteScalar().ToString();

                MySqlCommand cmdRecords = new MySqlCommand("SELECT COUNT(*) FROM medical_records", con);
                txtTMR.Text = cmdRecords.ExecuteScalar().ToString();

                MySqlCommand cmdTotalLab = new MySqlCommand("SELECT COUNT(*) FROM patient_labrec", con);
                txtTLT.Text = cmdTotalLab.ExecuteScalar().ToString();

                MySqlCommand cmdPendingLab = new MySqlCommand("SELECT COUNT(*) FROM patient_labrec WHERE Status = 'Pending'", con);
                txtPLT.Text = cmdPendingLab.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data:\n" + ex.Message);
            }
            finally
            {
                con.Close();
            }
            string recentQuery = @"
                SELECT 
                    p.PatientID, 
                    p.Name, 
                    p.Age, 
                    p.Gender, 
                    p.Contact_No, 
                    p.DoctorID, 
                    p.Admission_Date
                FROM patient p
                INNER JOIN doctor_patient dp ON p.PatientID = dp.PatientID
                WHERE dp.DoctorID = @DoctorID
                  AND p.Status = 'Admitted'
                ORDER BY p.Admission_Date DESC
                LIMIT 10";


            MySqlCommand cmdRecent = new MySqlCommand(recentQuery, con);
            cmdRecent.Parameters.AddWithValue("@DoctorID", doctorID);

            MySqlDataAdapter da = new MySqlDataAdapter(cmdRecent);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDashboard.DataSource = dt;

            dgvDashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDashboard.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            foreach (DataGridViewColumn col in dgvDashboard.Columns)
                col.MinimumWidth = 80;

            dgvDashboard.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDashboard.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvDashboard.EnableHeadersVisualStyles = false;
            dgvDashboard.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvDashboard.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDashboard.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);

            if (dgvDashboard.Columns.Contains("PatientID")) dgvDashboard.Columns["PatientID"].FillWeight = 70;
            if (dgvDashboard.Columns.Contains("Name")) dgvDashboard.Columns["Name"].FillWeight = 120;
            if (dgvDashboard.Columns.Contains("Age")) dgvDashboard.Columns["Age"].FillWeight = 50;
            if (dgvDashboard.Columns.Contains("Gender")) dgvDashboard.Columns["Gender"].FillWeight = 60;
            if (dgvDashboard.Columns.Contains("Contact_No")) dgvDashboard.Columns["Contact_No"].FillWeight = 100;
            if (dgvDashboard.Columns.Contains("DoctorID")) dgvDashboard.Columns["DoctorID"].FillWeight = 80;
            if (dgvDashboard.Columns.Contains("Admission_Date")) dgvDashboard.Columns["Admission_Date"].FillWeight = 100;
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo(doctorID);
            userinfo.Show();
            this.Hide();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            PatientManagement patientmanagement = new PatientManagement(this, doctorID);
            patientmanagement.Show();
            this.Hide();
        }

        private void btnMedRecords_Click(object sender, EventArgs e)
        {
            MedicalRecords medrec = new MedicalRecords(this, doctorID);
            medrec.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogOut logout = new LogOut();
            logout.Show();
            this.Hide();
        }

        private void dgvCurrentP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDashboard.DefaultCellStyle.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            dgvDashboard.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
        }

        private void btnLab_Click(object sender, EventArgs e)
        {
            LaboratoryManagement labmanagement = new LaboratoryManagement(doctorID);
            labmanagement.Show();
            this.Hide();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            Records records = new Records(this,doctorID);
            records.Show();
            this.Hide();
        }
    }
}