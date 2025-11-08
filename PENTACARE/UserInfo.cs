using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USERS_WINDOW
{
    public partial class UserInfo : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=pentacare;username=root;password=;");
        private int doctorID;

        public UserInfo(int id)
        {
            InitializeComponent();
            doctorID = id;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserDashboard dashboard = new UserDashboard(doctorID);
            dashboard.Show();
            this.Hide();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            EditProfile editprofile = new EditProfile(doctorID);
            editprofile.Show();
            this.Hide();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "SELECT DoctorID, Doctor_Name, Username, Email, Contact_No, Specialty FROM doctor WHERE DoctorID=@id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", doctorID);

                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    userName.Text = dr["Doctor_Name"].ToString();
                    userID.Text = dr["DoctorID"].ToString();
                    userUN.Text = dr["Username"].ToString();
                    userEmail.Text = dr["Email"].ToString();
                    userContact.Text = dr["Contact_No"].ToString();
                    userSpecialty.Text = dr["Specialty"].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    
}
