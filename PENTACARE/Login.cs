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

            if (string.IsNullOrEmpty(usernameOrEmail) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show($"Welcome {userType}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (userType == "Admin")
                    {
                        PatientManagement pm = new PatientManagement();
                        pm.Show();
                    }
                    else if (userType == "Doctor")
                    {
                        int doctorID = Convert.ToInt32(dr["DoctorID"]);
                        string doctorName = dr["Doctor_Name"].ToString();
                        UserDashboard userdashboard = new UserDashboard(doctorID);
                        userdashboard.Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid credentials. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_signup_CLick(object sender, EventArgs e)
        {
            CreateAccount ca = new CreateAccount();
            ca.Show();
            this.Hide();
        }

        private void btn_signup_Click_1(object sender, EventArgs e)
        {
            CreateAccount ca = new CreateAccount();
            ca.Show();
            this.Hide();
        }
    }
}
