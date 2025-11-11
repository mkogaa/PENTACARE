using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static USERS_WINDOW.MedicalRecords;


namespace USERS_WINDOW
{
    public partial class MedicalRecords : Form
    {
        private int doctorID;
        private UserDashboard dashboardForm;

        public static class DBConnection

        {
            public static string connString = "server=localhost;user id=root;password=;database=pentacare;";
        }

        public MedicalRecords(UserDashboard dashboard, int id)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            InitializeDGV();
            doctorID = id;
            dashboardForm = dashboard;

            LoadRecords();
        }

        private void RoundDataGridViewCorners(DataGridView dgv, int radius)
        {
            Rectangle rect = new Rectangle(0, 0, dgv.Width, dgv.Height);
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); 
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90); 
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); 
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90); 
            path.CloseAllFigures();

            dgv.Region = new Region(path);
        }


        private void LoadRecords()
        {
            string query = @"SELECT p.PatientID, p.Name, p.Age, p.Gender, p.Contact_No, p.Address
                     FROM patient p
                     INNER JOIN doctor_patient dp ON p.PatientID = dp.PatientID
                     WHERE dp.DoctorID = @DoctorID
                     ORDER BY p.Name;";

            using (MySqlConnection conn = new MySqlConnection(DBConnection.connString))
            {
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DoctorID", doctorID);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    dgvRecords.Rows.Clear();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dgvRecords.Rows.Add(
                                reader["PatientID"],
                                reader["Name"],
                                reader["Age"],
                                reader["Gender"],
                                reader["Contact_No"],
                                reader["Address"],
                                "View Details",
                                "Add Record"
                            );
                        }
                    }
                    else
                    {
                        MessageBox.Show("No patient records found.");
                    }

                    reader.Close();
                    conn.Close();
                }
            }

            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void InitializeDGV()
        {
            dgvRecords.Columns.Clear();
            dgvRecords.AutoGenerateColumns = false;
            dgvRecords.AllowUserToAddRows = false;
            dgvRecords.DefaultCellStyle.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            dgvRecords.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);

            dgvRecords.Columns.Add("PatientID", "Patient ID");
            dgvRecords.Columns.Add("Name", "Name");
            dgvRecords.Columns.Add("Age", "Age");
            dgvRecords.Columns.Add("Gender", "Gender");
            dgvRecords.Columns.Add("Contact_No", "Contact");
            dgvRecords.Columns.Add("Address", "Address");

            DataGridViewButtonColumn viewDetailsColumn = new DataGridViewButtonColumn
            {
                Name = "Action",
                Text = "View Details",
                UseColumnTextForButtonValue = true,
                HeaderText = "Action"
            };
            dgvRecords.Columns.Add(viewDetailsColumn);

            DataGridViewButtonColumn addRecordColumn = new DataGridViewButtonColumn
            {
                Name = "AddRecord",
                Text = "Add Record",
                UseColumnTextForButtonValue = true,
                HeaderText = "Add Record"
            };
            dgvRecords.Columns.Add(addRecordColumn);

            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            foreach (DataGridViewColumn col in dgvRecords.Columns)
                col.MinimumWidth = 80;

            dgvRecords.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecords.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvRecords.EnableHeadersVisualStyles = false;
            dgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvRecords.Columns["PatientID"].FillWeight = 70;
            dgvRecords.Columns["Age"].FillWeight = 60;
            dgvRecords.Columns["Name"].FillWeight = 150;
            dgvRecords.Columns["Address"].FillWeight = 120;
            dgvRecords.Columns["Action"].FillWeight = 100;
            dgvRecords.Columns["AddRecord"].FillWeight = 100;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dashboardForm.Show();  
            this.Hide();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            string filter = txtFilter.SelectedItem != null ? txtFilter.SelectedItem.ToString() : "Name";

            using (MySqlConnection conn = new MySqlConnection(DBConnection.connString))
            {
                conn.Open();

                string query = @"SELECT p.PatientID, p.Name, p.Age, p.Gender, p.Contact_No, p.Address
                         FROM patient p
                         INNER JOIN doctor_patient dp ON p.PatientID = dp.PatientID
                         WHERE dp.DoctorID = @DoctorID";

                if (search != "")
                {
                    if (filter == "Name")
                        query += " AND p.Name LIKE @search";
                    else if (filter == "ID")
                        query += " AND p.PatientID LIKE @search";
                    else if (filter == "Age")
                        query += " AND p.Age LIKE @search";
                    else if (filter == "Address")
                        query += " AND p.Address LIKE @search";
                }

                query += " ORDER BY p.Name;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DoctorID", doctorID);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                MySqlDataReader reader = cmd.ExecuteReader();

                dgvRecords.Rows.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dgvRecords.Rows.Add(
                            reader["PatientID"],
                            reader["Name"],
                            reader["Age"],
                            reader["Gender"],
                            reader["Contact_No"],
                            reader["Address"],
                            "View Details",
                            "Add Record"
                        );
                    }
                }
                else
                {
                    MessageBox.Show("No records found.");
                }

                reader.Close();
                conn.Close();
            }
        }

        private void dgvRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int patientId = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells["PatientID"].Value);

            if (dgvRecords.Columns[e.ColumnIndex].Name == "Action")
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.connString))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM medical_records WHERE PatientID = @id";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@id", patientId);

                    int recordCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (recordCount > 0)
                    {
                        PatientMedicalRecord detailsForm = new PatientMedicalRecord(this, patientId);
                        detailsForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Patient has no medical records yet. Please add a record first.",
                                        "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (dgvRecords.Columns[e.ColumnIndex].Name == "AddRecord")
            {
                string name = dgvRecords.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                string age = dgvRecords.Rows[e.RowIndex].Cells["Age"].Value.ToString();
                string gender = dgvRecords.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                string contact = dgvRecords.Rows[e.RowIndex].Cells["Contact_No"].Value.ToString();
                string address = dgvRecords.Rows[e.RowIndex].Cells["Address"].Value.ToString();

                NewRecords newRecordForm = new NewRecords(this, doctorID, patientId, name, age, gender, contact, address);
                DialogResult result = newRecordForm.ShowDialog();


                if (result == DialogResult.OK)
                {
                    LoadRecords();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRecords();
            MessageBox.Show("Records refreshed successfully.", "Refreshed",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MedicalRecords_Load(object sender, EventArgs e)
        {
            RoundDataGridViewCorners(dgvRecords, 50);
        }
    }
}
