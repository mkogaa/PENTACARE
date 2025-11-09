using MySql.Data.MySqlClient;
using PENTACARE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PentaCare
{


    public partial class DoctorandRecords : Form
    {
        private DataSet sqlDS;

        public DoctorandRecords()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

        }


        private void DoctorandRecords_Load(object sender, EventArgs e)
        {

            // DOCTOR// 

            // DOCTOR //
            docRecords.Size = new Size(689, 297);
            docRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            docRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            docRecords.ScrollBars = ScrollBars.Both;

            docRecords.AllowUserToAddRows = false;
            docRecords.RowHeadersVisible = false;

            docRecords.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            docRecords.EnableHeadersVisualStyles = false;
            docRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            docRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            docRecords.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
            MySqlConnection conn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcmd = new MySqlCommand();

            MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            sqlDS = new DataSet();


            conn.Open();

            sqlcmd.CommandText = $"SELECT DoctorID, Doctor_Name, Specialty, Contact_No FROM doctor";



            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = conn;

            sqlDA.SelectCommand = sqlcmd;
            sqlDA.Fill(sqlDS, "recordsfetch");

            docRecords.DataSource = sqlDS;
            docRecords.DataMember = "recordsfetch";

            conn.Close();


            // PATIENT //
            dataGridView1.Size = new Size(689, 297);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ScrollBars = ScrollBars.Both;

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            string con = "server=127.0.0.1; database=pentacare; uid=root;";
            MySqlConnection connect = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();

            MySqlDataAdapter patient = new MySqlDataAdapter();
            DataSet set = new DataSet();

            connect.Open();

            cmd.CommandText = $"SELECT  p.Name, r.Room_No, d.Doctor_Name, p.Status " +
                $"FROM patient as p LEFT JOIN room AS r ON p.RoomID = r.RoomID " +
                $"LEFT JOIN doctor AS d ON p.DoctorID = d.DoctorID";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connect;

            patient.SelectCommand = cmd;
            patient.Fill(set, "patientfetch");

            dataGridView1.DataSource = set;
            dataGridView1.DataMember = "patientfetch";

            connect.Close();

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Action";
            btn.HeaderText = "Action";
            btn.Text = "View";
            btn.UseColumnTextForButtonValue = true;  // ✅ Same text for all buttons
            dataGridView1.Columns.Add(btn);
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Action" && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string patientName = row.Cells["Name"].Value.ToString();
                string doctorName = row.Cells["Doctor_Name"].Value.ToString();


                ViewPatient patient = new ViewPatient(patientName, doctorName);
                patient.Show();
                this.Hide();
            }
        }
        private void assignBtn_Click(object sender, EventArgs e)
        {
            AssignToPatient assignToPatient = new AssignToPatient();
            assignToPatient.Show();
            this.Hide();
        }

        private void addDocBtn_Click_1(object sender, EventArgs e)
        {
            AddDoctors addDoc = new AddDoctors();
            addDoc.Show();
            this.Hide();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (docRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("No row selected to delete.");
                return;
            }

            int doctorID = Convert.ToInt32(docRecords.SelectedRows[0].Cells["DoctorID"].Value);

            DialogResult result = MessageBox.Show("Are you sure you want to delete this doctor record?",
                                                  "Confirm Deletion",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                return;

            try
            {
                string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
                MySqlConnection conn = new MySqlConnection(dbconnect);
                MySqlCommand sqlcmd = new MySqlCommand();
                MySqlDataAdapter sqlDA = new MySqlDataAdapter();
                DataSet sqlDS = new DataSet();

                conn.Open();

                sqlcmd.CommandText = $"DELETE FROM doctor WHERE DoctorID = {doctorID}";
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Connection = conn;
                sqlcmd.ExecuteNonQuery();

                MessageBox.Show("Doctor record deleted successfully.");

                sqlcmd.CommandText = "SELECT DoctorID, Doctor_Name, Specialty, Contact_No FROM doctor";
                sqlDA.SelectCommand = sqlcmd;
                sqlDS.Clear();
                sqlDA.Fill(sqlDS, "recordsfetch");
                docRecords.DataSource = sqlDS;
                docRecords.DataMember = "recordsfetch";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message);
            }

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (docRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("No row selected to save.");
                return;
            }


            docRecords.EndEdit();  // ← forces DGV to save current cell edit


            int doctorID = Convert.ToInt32(docRecords.SelectedRows[0].Cells["DoctorID"].Value);
            string doctorName = docRecords.SelectedRows[0].Cells["Doctor_Name"].Value.ToString();
            string specialty = docRecords.SelectedRows[0].Cells["Specialty"].Value.ToString();
            string contactNo = docRecords.SelectedRows[0].Cells["Contact_No"].Value.ToString();

            // prevent editing DoctorID
            if (docRecords.CurrentCell.OwningColumn.Name == "DoctorID")
            {
                MessageBox.Show("Doctor ID cannot be edited.");
                return;
            }

            try
            {
                string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
                MySqlConnection conn = new MySqlConnection(dbconnect);
                MySqlCommand sqlcmd = new MySqlCommand();
                MySqlDataAdapter sqlDA = new MySqlDataAdapter();
                DataSet sqlDS = new DataSet();

                conn.Open();

                sqlcmd.CommandText = $"UPDATE doctor " +
                                     $"SET Doctor_Name = '{doctorName}', " +
                                     $"Specialty = '{specialty}', " +
                                     $"Contact_No = '{contactNo}' " +
                                     $"WHERE DoctorID = {doctorID}";

                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Connection = conn;
                sqlcmd.ExecuteNonQuery();

                MessageBox.Show("Doctor record updated successfully.");

                // reload data
                sqlcmd.CommandText = "SELECT DoctorID, Doctor_Name, Specialty, Contact_No FROM doctor";
                sqlDA.SelectCommand = sqlcmd;
                sqlDS.Clear();
                sqlDA.Fill(sqlDS, "recordsfetch");
                docRecords.DataSource = sqlDS;
                docRecords.DataMember = "recordsfetch";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message);
            }

        }

        private void cmbSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {

            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
            MySqlConnection conn = new MySqlConnection(dbconnect);

            try
            {
                conn.Open();

                string query = "SELECT DoctorID, Doctor_Name, Specialty, Contact_No FROM doctor";

                // Filter by gender
                string selectedSpecialty = cmbSpecialty.SelectedItem.ToString();
                if (selectedSpecialty != "All")
                {
                    query += " WHERE Specialty = '" + selectedSpecialty + "'";
                }

                MySqlDataAdapter sqlDA = new MySqlDataAdapter(query, conn);
                sqlDS = new DataSet();
                sqlDA.Fill(sqlDS, "recordsfetch");

                docRecords.DataSource = sqlDS;
                docRecords.DataMember = "recordsfetch";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                conn.Close();
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            docRecords.Size = new Size(689, 297);
            docRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            docRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            docRecords.ScrollBars = ScrollBars.Both;

            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
            MySqlConnection conn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcmd = new MySqlCommand();
            MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            DataSet sqlDS = new DataSet();

            string searchValue = searchTxt.Text.Trim();

            conn.Open();

            // 👇 Filter by Doctor_Name or Specialty (case-insensitive)
            sqlcmd.CommandText =
                $"SELECT DoctorID, Doctor_Name, Specialty, Contact_No " +
                $"FROM doctor " +
                $"WHERE Doctor_Name LIKE '%{searchValue}%' OR Specialty LIKE '%{searchValue}%' OR DoctorID LIKE '%{searchValue}%'";

            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = conn;

            sqlDA.SelectCommand = sqlcmd;
            sqlDA.Fill(sqlDS, "recordsfetch");

            docRecords.DataSource = sqlDS;
            docRecords.DataMember = "recordsfetch";

            if (docRecords.Rows.Count == 0 || (docRecords.Rows.Count == 1 && docRecords.Rows[0].IsNewRow))
            {
                MessageBox.Show("No records found.");
            }

            conn.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            docRecords.Size = new Size(689, 297);
            docRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            docRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            docRecords.ScrollBars = ScrollBars.Both;

            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
            MySqlConnection conn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcmd = new MySqlCommand();
            MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            DataSet sqlDS = new DataSet();

            string searchValue = searchTxt.Text.Trim();

            conn.Open();

            // 👇 Filter by Doctor_Name or Specialty (case-insensitive)
            sqlcmd.CommandText =
                $"SELECT DoctorID, Doctor_Name, Specialty, Contact_No " +
                $"FROM doctor " +
                $"WHERE Doctor_Name LIKE '%{searchValue}%' OR Specialty LIKE '%{searchValue}%' OR DoctorID LIKE '%{searchValue}%'";

            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = conn;

            sqlDA.SelectCommand = sqlcmd;
            sqlDA.Fill(sqlDS, "recordsfetch");

            docRecords.DataSource = sqlDS;
            docRecords.DataMember = "recordsfetch";

            if (docRecords.Rows.Count == 0 || (docRecords.Rows.Count == 1 && docRecords.Rows[0].IsNewRow))
            {
                MessageBox.Show("No records found.");
            }

            conn.Close();
        }

        private void removeBtn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
