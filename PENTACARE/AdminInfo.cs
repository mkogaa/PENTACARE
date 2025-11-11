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
using System.Xml.Linq;

namespace PENTACARE
{
    public partial class AdminInfo : Form
    {
        public AdminInfo()
        {
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void AdminInfo_Load(object sender, EventArgs e)
        {
            string adminID = "1"; // replace with the logged-in admin ID
            string connectionString = "server=localhost;database=pentacare;uid=root;pwd=;";
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();

            string query = "SELECT Username, email, Contact FROM admin WHERE AdminID = @id";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", adminID);

            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                name.Text = dr["Username"].ToString();
                email.Text = dr["email"].ToString();
                contact.Text = dr["Contact"].ToString(); // make sure this column exists
            }
            else
            {
                MessageBox.Show("Admin not found.");
            }

            dr.Close();
            con.Close();

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
