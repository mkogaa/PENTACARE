using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace USERS_WINDOW
{
    public partial class CreateAccount : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=pentacare;username=root;password=;");

        public CreateAccount()
        {
            InitializeComponent();
        }

        private void btn_createaccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_ca_name.Text == "" || txt_ca_specialty.Text == "" || txt_ca_contact.Text == "" ||
                    txt_ca_email.Text == "" || txt_ca_username.Text == "" || txt_ca_password.Text == "")
                {
                    MessageBox.Show("⚠️ Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "INSERT INTO doctor (Doctor_Name, Specialty, Contact_No, Email, Username, Password) " +
                               "VALUES (@Doctor_Name, @Specialty, @Contact_No, @Email, @Username, @Password)";
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Doctor_Name", txt_ca_name.Text);
                cmd.Parameters.AddWithValue("@Specialty", txt_ca_specialty.Text);
                cmd.Parameters.AddWithValue("@Contact_No", txt_ca_contact.Text);
                cmd.Parameters.AddWithValue("@Email", txt_ca_email.Text);
                cmd.Parameters.AddWithValue("@Username", txt_ca_username.Text);
                cmd.Parameters.AddWithValue("@Password", txt_ca_password.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("✅ Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Login login = new Login();
                login.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                con.Close();
            }
        }

        private void btn_ca_cancel_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {

        }

        private void txt_ca_email_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
