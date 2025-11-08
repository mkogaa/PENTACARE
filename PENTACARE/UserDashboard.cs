using MySql.Data.MySqlClient;
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

            string recentQuery = "SELECT PatientID, Name, Age, Gender, Contact_No, DoctorID, Admission_Date FROM patient ORDER BY Admission_Date DESC LIMIT 10";
            MySqlCommand cmdRecent = new MySqlCommand(recentQuery, con);
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
            if (dgvDashboard.Columns.Contains("First_Name")) dgvDashboard.Columns["Name"].FillWeight = 120;
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
            PatientManagement patientmanagement = new PatientManagement();
            patientmanagement.Show();
            this.Hide();
        }

        private void btnMedRecords_Click(object sender, EventArgs e)
        {
            MedicalRecords medicalrecords = new MedicalRecords();
            medicalrecords.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogOut logout = new LogOut();
            logout.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void userName_Click(object sender, EventArgs e)
        {

        }

        private void dgvCurrentP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDashboard.DefaultCellStyle.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            dgvDashboard.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);

        }

        private void btnLab_Click(object sender, EventArgs e)
        {
            LaboratoryManagement labmanagement = new LaboratoryManagement();
            labmanagement.Show();
            this.Hide();
        }



        private void txtTLT_Click(object sender, EventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }
    }
}
