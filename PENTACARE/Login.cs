using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace USERS_WINDOW
{
    public partial class Login : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=pentacare;username=root;password=;");

        public Login()
        {
            InitializeComponent();
            cb_login.SelectedIndex = 0;
            txt_login_password.UseSystemPasswordChar = true;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = txt_login_email.Text.Trim();
            string password = txt_login_password.Text.Trim();
            string userType = cb_login.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(usernameOrEmail) && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your email and password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(usernameOrEmail))
            {
                MessageBox.Show("Please enter your email.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(userType))
            {
                MessageBox.Show("Please select your user type (Admin or Doctor).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                con.Open();
                string query = "";

                if (userType == "Admin")
                {
                    query = "SELECT * FROM admin WHERE Username=@user AND Password=@pass";
                }
                else if (userType == "Doctor")
                {
                    query = "SELECT * FROM doctor WHERE Email=@user AND Password=@pass";
                }

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", usernameOrEmail);
                cmd.Parameters.AddWithValue("@pass", password);

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    int doctorID = 0;
                    string doctorName = "";

                    if (userType == "Doctor")
                    {
                        doctorID = Convert.ToInt32(dr["DoctorID"]);
                        doctorName = dr["Doctor_Name"].ToString();
                        MessageBox.Show($"Welcome, {doctorName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Welcome, {userType}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dr.Close();

                    if (userType == "Admin")
                    {

                    }
                    else if (userType == "Doctor")
                    {
                        UserDashboard userdashboard = new UserDashboard(doctorID);
                        userdashboard.Show();
                    }

                    this.Hide();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Invalid credentials. Please check your username/email and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show("MySQL connection failed:\n" + sqlEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void btn_login_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                cb_login.SelectedIndex = 1;
                txt_login_email.Text = "daniel.ramos@pentacare.com";
                txt_login_password.Text = "ortho456";
            }
                
        }
    }
}
