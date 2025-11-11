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

namespace PENTACARE
{
    public partial class View_DoctorRecord : Form
    {
        private string doctorID;
        public View_DoctorRecord(string selectedDoctorID)
        {
            InitializeComponent();

            doctorID = selectedDoctorID;
        }

        private void View_DoctorRecord_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = AutoScaleMode.Dpi;

            LoadDoctorInfo();

            dgv_DR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_DR.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_DR.AllowUserToAddRows = false;
            dgv_DR.RowHeadersVisible = false;

            dgv_DR.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_DR.EnableHeadersVisualStyles = false;
            dgv_DR.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dgv_DR.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_DR.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            LoadPatientsForDoctor();
        }

        private void LoadDoctorInfo()
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                string query = @"SELECT 
                                    DoctorID, Doctor_Name, Specialty, Contact_No, Email
                                 FROM doctor
                                 WHERE DoctorID = @DoctorID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DoctorID", doctorID);
                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblDI.Text = reader["DoctorID"].ToString();
                                lblName.Text = reader["Doctor_Name"].ToString();
                                lblSpecialty.Text = reader["Specialty"].ToString();
                                lblCN.Text = reader["Contact_No"].ToString();
                                lblEmail.Text = reader["Email"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading doctor info: " + ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadPatientsForDoctor()
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection sqlconn = new MySqlConnection(dbconnect))
            {

                string query = @"SELECT 
                                    p.PatientID AS 'Patient ID',
                                    p.Name AS 'Patient Name',
                                    p.Age AS 'Age',
                                    p.Gender AS 'Gender',
                                    DATE_FORMAT(p.Admission_Date, '%M %d, %Y') AS 'Admission Date',
                                    DATE_FORMAT(p.Discharge_Date, '%M %d, %Y') AS 'Discharge Date'
                                FROM patient p
                                WHERE p.DoctorID = @DoctorID";

                MySqlCommand cmd = new MySqlCommand(query, sqlconn);
                cmd.Parameters.AddWithValue("@DoctorID", doctorID);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    sqlconn.Open();
                    adapter.Fill(dt);

                    dgv_DR.DataSource = dt;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("No patients found for this doctor.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading patient list: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
