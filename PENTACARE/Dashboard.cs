using MySql.Data.MySqlClient;
using PentaCare;
using System.Data;
using USERS_WINDOW;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PENTACARE
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        }

        private void btn_labService_Click(object sender, EventArgs e)
        {
            Laboratory lab = new Laboratory();
            lab.Show();
            this.Hide();
        }

        private void btn_services_Click(object sender, EventArgs e)
        {
            Services service = new Services();
            service.Show();
            this.Hide();
        }

        private void btn_billingMain_Click(object sender, EventArgs e)
        {
            BillingMain bm = new BillingMain();
            bm.Show();
            this.Hide();

            MessageBox.Show("Panel Clicked!");

        }

        private void btn_labService_DoubleClick(object sender, EventArgs e)
        {
            Laboratory lab = new Laboratory();
            lab.Show();
            this.Hide();
        }

        private void btn_billingMain_Click_1(object sender, EventArgs e)
        {
            BillingMain bm = new BillingMain();
            bm.Show();
            this.Hide();

            MessageBox.Show("Panel Clicked!");
        }

        private void btn_room_Click(object sender, EventArgs e)
        {
            Room_Management rm = new Room_Management();
            rm.Show();
            this.Hide();
        }

        private void btn_patientManage_Click(object sender, EventArgs e)
        {
            Patient_Management pm = new Patient_Management();
            pm.Show();
            this.Hide();
        }

        private void btn_doctorsRec_Click(object sender, EventArgs e)
        {
            DoctorandRecords dr = new DoctorandRecords();
            dr.Show();
            this.Hide();
        }

        private void btn_patient_Click(object sender, EventArgs e)
        {
            AddPatient ap = new AddPatient();
            ap.Show();
            this.Hide();
        }

        private void btn_doctor_Click(object sender, EventArgs e)
        {
            AddDoctors ad = new AddDoctors();
            ad.Show();
            this.Hide();
        }

        private void btn_rooms_Click(object sender, EventArgs e)
        {
            AddRoom ar = new AddRoom();
            ar.Show();
            this.Hide();
        }

        private void btn_rooms_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            ShowTotalPatients();

            ShowOccupiedRooms();

            ShowAvailableRooms();

            ShowTotalDoctors();

            LoadRecentPatients();

        }


        private void ShowTotalPatients()
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";

            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                string query = "SELECT COUNT(*) FROM patient";

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    int totalPatients = Convert.ToInt32(cmd.ExecuteScalar());

                    lbl_totalPatients.Text = totalPatients.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading patient count: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowOccupiedRooms()
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";

            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                string query = "SELECT COUNT(*) FROM room WHERE Status = 'Occupied'";

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    int totalOccupied = Convert.ToInt32(cmd.ExecuteScalar());

                    lbl_occupied.Text = totalOccupied.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading occupied rooms: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowAvailableRooms()
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";

            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                string query = "SELECT COUNT(*) FROM room WHERE Status = 'Available'";

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    int totalAvailable = Convert.ToInt32(cmd.ExecuteScalar());

                    lbl_available.Text = totalAvailable.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading available rooms: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowTotalDoctors()
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";

            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                string query = "SELECT COUNT(*) FROM doctor";

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    int totalDoctor = Convert.ToInt32(cmd.ExecuteScalar());

                    lbl_doctors.Text = totalDoctor.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading patient count: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadRecentPatients()
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";

            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {

                string query = @"SELECT 
                                    p.Name AS 'Patient Name', 
                                    p.Admission_Date AS 'Admission Date', 
                                    r.Room_No AS 'Room Number',
                                    p.Status 
                                 FROM patient p
                                 LEFT JOIN room r ON p.RoomID = r.RoomID
                                 ORDER BY p.Admission_Date DESC
                                 LIMIT 5";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    da.Fill(dt);
                    dgvRecentAct.DataSource = dt;

                    dgvRecentAct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvRecentAct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvRecentAct.AllowUserToAddRows = false;

                    dgvRecentAct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                    dgvRecentAct.EnableHeadersVisualStyles = false;
                    dgvRecentAct.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
                    dgvRecentAct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvRecentAct.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading recent patients: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void viewInfo_Click(object sender, EventArgs e)
        {
            AdminInfo admin = new AdminInfo();
            admin.Show();
            this.Hide();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Are you sure you want to logout?",
            "Confirm Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
             );

            if (result == DialogResult.Yes)
            {
                // Show the login form
                Login loginForm = new Login();
                loginForm.Show();

                // Close or hide the current dashboard
                this.Hide(); // or this.Hide();
            }
        }

        private void btn_Records_Click(object sender, EventArgs e)
        {
            Reports_Monitoring rm = new Reports_Monitoring();
            rm.Show();
            this.Hide();
        }
    }
}
