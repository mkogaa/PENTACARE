using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace USERS_WINDOW
{
    public partial class EditProfile : Form
    {
        private int doctorID;
        MySqlConnection con = new MySqlConnection("server=localhost;database=pentacare;username=root;password=;");

        public EditProfile(int id)
        {
            InitializeComponent();
            doctorID = id;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to cancel? Any changes will not be saved.", "Cancel Editing",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                UserInfo userinfo = new UserInfo(doctorID);
                userinfo.Show();
                this.Hide();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (userName.Text == "" || userUN.Text == "" || userEmail.Text == "" || userContact.Text == "" || userSpecialty.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            for (int i = 0; i < userName.Text.Length; i++)
            {
                if (!char.IsLetter(userName.Text[i]) && userName.Text[i] != ' ')
                {
                    MessageBox.Show("Name can contain letters only.");
                    return;
                }
            }

            for (int i = 0; i < userContact.Text.Length; i++)
            {
                if (!char.IsDigit(userContact.Text[i]))
                {
                    MessageBox.Show("Contact can contain numbers only.");
                    return;
                }
            }

            con.Open();
            MySqlCommand cmd = new MySqlCommand(
                "UPDATE doctor SET Doctor_Name=@name, Username=@username, Email=@email, Contact_No=@contact, Specialty=@specialty WHERE DoctorID=@id", con);
            cmd.Parameters.AddWithValue("@id", doctorID);
            cmd.Parameters.AddWithValue("@name", userName.Text);
            cmd.Parameters.AddWithValue("@username", userUN.Text);
            cmd.Parameters.AddWithValue("@email", userEmail.Text);
            cmd.Parameters.AddWithValue("@contact", userContact.Text);
            cmd.Parameters.AddWithValue("@specialty", userSpecialty.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Profile updated!");

            UserInfo ui = new UserInfo(doctorID);
            ui.Show();
            this.Hide();

        }

        private void EditProfile_Load(object sender, EventArgs e)
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
                    userID.ReadOnly = true;
                    userUN.Text = dr["Username"].ToString();
                    userEmail.Text = dr["Email"].ToString();
                    userContact.Text = dr["Contact_No"].ToString();
                    userSpecialty.Text = dr["Specialty"].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    
}
