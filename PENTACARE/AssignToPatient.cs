using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PentaCare
{
    public partial class AssignToPatient : Form
    {
        public AssignToPatient()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        private void assignBtn_Click(object sender, EventArgs e)
        {

            string ID = pID.Text;
            string Name = pName.Text;
            string doc = doctor.Text;


            string dbconnect = "server= 127.0.0.1; database=pentacare; uid=root; ";
            MySqlConnection conn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcmd = new MySqlCommand();



            conn.Open();

            sqlcmd.CommandText = $"UPDATE patient SET DoctorID = (SELECT DoctorID FROM doctor WHERE Doctor_Name = " +
                $"'{doc}') WHERE PatientID = '{ID}'";



            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = conn;


            sqlcmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Doctor assigned to Patient Successfully!");
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string dbconnect = "server= 127.0.0.1; database=pentacare; uid=root; ";
            MySqlConnection conn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcmd = new MySqlCommand();


            // For Viewing 

            MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            DataSet sqlDS = new DataSet();

            MySqlDataReader reader;
            // Step 2: Establish SQL Connection
            conn.Open();

            sqlcmd.CommandText = $"SELECT PatientID, Name FROM patient WHERE PatientID LIKE '%{searchBox.Text}%' OR Name LIKE '%{searchBox.Text}%' ";

            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = conn;

            reader = sqlcmd.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                pID.Text = reader["PatientID"].ToString();
                pName.Text = reader["Name"].ToString();



            }
            else
            {
                MessageBox.Show("No Patient Found! ");
            }
        }

        private void searchBtn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            DoctorandRecords doctorandRecords = new DoctorandRecords();
            doctorandRecords.Show();
            this.Hide();

        }

        private void AssignToPatient_Load(object sender, EventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                pID.Clear();
                pName.Clear();
                return;
            }

            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                string query = "SELECT PatientID, Name FROM patient " +
                               "WHERE PatientID LIKE @search OR Name LIKE @search " +
                               "LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchBox.Text + "%");

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pID.Text = reader["PatientID"].ToString();
                            pName.Text = reader["Name"].ToString();
                        }
                        else
                        {
                            pID.Clear();
                            pName.Clear();
                        }
                    }
                }
            }
        }
    }
}
