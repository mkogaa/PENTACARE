using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USERS_WINDOW;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PentaCare
{
    public partial class AdmissionDischarge : Form

    {
        private DataSet sqlDS;

        public AdmissionDischarge()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Patient_Management form1 = new Patient_Management();
            form1.Show();
            this.Hide();
        }

        private void AdmissionDischarge_Load(object sender, EventArgs e)
        {
            dataGridView1.Size = new Size(1639, 173);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ScrollBars = ScrollBars.Both;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);


            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root; Allow Zero Datetime=True; Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcmd = new MySqlCommand();

            MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            sqlDS = new DataSet();

            conn.Open();


            sqlcmd.CommandText = @"
            SELECT p.Name, 
                   p.Gender, 
                   r.Room_No AS `Room Number`, 
                   d.Doctor_Name AS `Doctor Name`, 
                   d.Specialty, 
                   p.Status, 
                   NULLIF(p.Admission_Date,'0000-00-00') AS Admit, 
                   NULLIF(p.Discharge_Date,'0000-00-00') AS Discharge, 
                   mr.RecordID, 
                   mr.BP, 
                   mr.HR, 
                   mr.Temp, 
                   mr.Allergies, 
                   mr.Diagnosis, 
                   mr.DiagnosisNotes AS `Diagnosis Notes`, 
                   mr.ExamFindings AS `Exam Findings`, 
                   mr.Treatment, 
                   mr.Medication, 
                   NULLIF(mr.RecordDate,'0000-00-00') AS `Record Date`
            FROM patient AS p
            LEFT JOIN room AS r ON p.RoomID = r.RoomID
            LEFT JOIN doctor AS d ON p.DoctorID = d.DoctorID
            LEFT JOIN medical_records AS mr ON p.PatientID = mr.PatientID
            ORDER BY mr.RecordDate DESC;";

            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = conn;

            sqlDA.SelectCommand = sqlcmd;
            sqlDA.Fill(sqlDS, "recordsfetch");

            dataGridView1.DataSource = sqlDS;
            dataGridView1.DataMember = "recordsfetch";

            dataGridView1.Columns["Gender"].Visible = false;
            dataGridView1.Columns["Status"].Visible = false;

            conn.Close();

        }

        private void cmbRtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                try
                {
                    conn.Open();

                    // Determine room prefix based on selected room type
                    string roomTypePrefix = "";
                    switch (cmbRtype.SelectedItem?.ToString())
                    {
                        case "Private":
                            roomTypePrefix = "P%";
                            break;
                        case "Semi-Private":
                            roomTypePrefix = "SP%";
                            break;
                        case "Ward":
                            roomTypePrefix = "W%";
                            break;
                        default:
                            roomTypePrefix = "%"; // all rooms
                            break;
                    }

                    string query = @"
            SELECT p.Name, 
                   p.Gender, 
                   r.Room_No AS `Room Number`, 
                   d.Doctor_Name AS `Doctor Name`, 
                   d.Specialty, 
                   p.Status, 
                   NULLIF(p.Admission_Date,'0000-00-00') AS Admit, 
                   NULLIF(p.Discharge_Date,'0000-00-00') AS Discharge, 
                   mr.RecordID, 
                   mr.BP, 
                   mr.HR, 
                   mr.Temp, 
                   mr.Allergies, 
                   mr.Diagnosis, 
                   mr.DiagnosisNotes AS `Diagnosis Notes`, 
                   mr.ExamFindings AS `Exam Findings`, 
                   mr.Treatment, 
                   mr.Medication, 
                   NULLIF(mr.RecordDate,'0000-00-00') AS `Record Date`
            FROM patient AS p
            LEFT JOIN room AS r ON p.RoomID = r.RoomID
            LEFT JOIN doctor AS d ON p.DoctorID = d.DoctorID
            LEFT JOIN medical_records AS mr ON p.PatientID = mr.PatientID
            WHERE r.Room_No LIKE @RoomPrefix
            ORDER BY mr.RecordDate DESC;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RoomPrefix", roomTypePrefix);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind to DataGridView
                    dataGridView1.DataSource = dt;

                    // Hide unnecessary columns
                    if (dataGridView1.Columns["Gender"] != null)
                        dataGridView1.Columns["Gender"].Visible = false;
                    if (dataGridView1.Columns["Status"] != null)
                        dataGridView1.Columns["Status"].Visible = false;

                    // Show results count
                    MessageBox.Show($"Found {dt.Rows.Count} patients in {cmbRtype.SelectedItem} rooms.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                try
                {
                    conn.Open();

                    // Get the selected date
                    DateTime selectedDate = dateTimePicker1.Value.Date;

                    string query = @"
                   SELECT p.Name, p.Gender, 
                           r.Room_No AS `Room Number`, 
                           d.Doctor_Name AS `Doctor Name`, 
                           d.Specialty, 
                           p.Status, 
                           NULLIF(p.Admission_Date,'0000-00-00') AS Admit, 
                           NULLIF(p.Discharge_Date,'0000-00-00') AS Discharge, 
                           mr.RecordID, mr.BP, mr.HR, mr.Temp, mr.Allergies, mr.Diagnosis, 
                           mr.DiagnosisNotes AS `Diagnosis Notes`, 
                           mr.ExamFindings AS `Exam Findings`, 
                           mr.Treatment, mr.Medication, 
                           NULLIF(mr.RecordDate,'0000-00-00') AS `Record Date`
                    FROM patient AS p
                    LEFT JOIN room AS r ON p.RoomID = r.RoomID
                    LEFT JOIN doctor AS d ON p.DoctorID = d.DoctorID
                    LEFT JOIN medical_records AS mr ON p.PatientID = mr.PatientID
                    WHERE p.Status = 'Discharged'
                    ORDER BY mr.RecordDate DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DischargeDate", selectedDate.ToString("yyyy-MM-dd"));

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // Optional: Hide unnecessary columns
                    if (dataGridView1.Columns["Gender"] != null) dataGridView1.Columns["Gender"].Visible = false;
                    if (dataGridView1.Columns["Status"] != null) dataGridView1.Columns["Status"].Visible = true;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No discharged patients found on this date.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report exported", "PENTACARE", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btn_print_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report has been printed", "PENTACARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report has been printed", "PENTACARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report exported", "PENTACARE", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;

            // Clear the DataGridView
            dataGridView1.DataSource = null;

            dataGridView1.Size = new Size(1639, 173);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ScrollBars = ScrollBars.Both;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);


            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root; Allow Zero Datetime=True; Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcmd = new MySqlCommand();

            MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            sqlDS = new DataSet();

            conn.Open();
            sqlcmd.CommandText = @"
            SELECT p.Name, 
                   p.Gender, 
                   r.Room_No AS `Room Number`, 
                   d.Doctor_Name AS `Doctor Name`, 
                   d.Specialty, 
                   p.Status, 
                   NULLIF(p.Admission_Date,'0000-00-00') AS Admit, 
                   NULLIF(p.Discharge_Date,'0000-00-00') AS Discharge, 
                   mr.RecordID, 
                   mr.BP, 
                   mr.HR, 
                   mr.Temp, 
                   mr.Allergies, 
                   mr.Diagnosis, 
                   mr.DiagnosisNotes AS `Diagnosis Notes`, 
                   mr.ExamFindings AS `Exam Findings`, 
                   mr.Treatment, 
                   mr.Medication, 
                   NULLIF(mr.RecordDate,'0000-00-00') AS `Record Date`
            FROM patient AS p
            LEFT JOIN room AS r ON p.RoomID = r.RoomID
            LEFT JOIN doctor AS d ON p.DoctorID = d.DoctorID
            LEFT JOIN medical_records AS mr ON p.PatientID = mr.PatientID
            ORDER BY mr.RecordDate DESC;";

            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = conn;

            sqlDA.SelectCommand = sqlcmd;
            sqlDA.Fill(sqlDS, "recordsfetch");

            dataGridView1.DataSource = sqlDS;
            dataGridView1.DataMember = "recordsfetch";

            dataGridView1.Columns["Gender"].Visible = false;
            dataGridView1.Columns["Status"].Visible = false;

            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root; Allow Zero Datetime=True; Convert Zero Datetime=True;";
            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                try
                {
                    conn.Open();

                    string searchText = textBox1.Text.Trim();

                    string query = @"
                                    SELECT p.Name, 
                                           p.Gender, 
                                           r.Room_No AS `Room Number`, 
                                           d.Doctor_Name AS `Doctor Name`, 
                                           d.Specialty, 
                                           p.Status, 
                                           NULLIF(p.Admission_Date,'0000-00-00') AS Admit, 
                                           NULLIF(p.Discharge_Date,'0000-00-00') AS Discharge, 
                                           mr.RecordID, 
                                           mr.BP, 
                                           mr.HR, 
                                           mr.Temp, 
                                           mr.Allergies, 
                                           mr.Diagnosis, 
                                           mr.DiagnosisNotes AS `Diagnosis Notes`, 
                                           mr.ExamFindings AS `Exam Findings`, 
                                           mr.Treatment, 
                                           mr.Medication, 
                                           NULLIF(mr.RecordDate,'0000-00-00') AS `Record Date`
                                    FROM patient AS p
                                    LEFT JOIN room AS r ON p.RoomID = r.RoomID
                                    LEFT JOIN doctor AS d ON p.DoctorID = d.DoctorID
                                    LEFT JOIN medical_records AS mr ON p.PatientID = mr.PatientID
                                    WHERE (p.PatientID LIKE @Search OR p.Name LIKE @Search)
                                    ORDER BY mr.RecordDate DESC;";


                    using (MySqlCommand sqlcmd = new MySqlCommand(query, conn))
                    {
                        sqlcmd.Parameters.AddWithValue("@Search", "%" + searchText + "%");

                        MySqlDataAdapter sqlDA = new MySqlDataAdapter(sqlcmd);
                        DataSet sqlDS = new DataSet();
                        sqlDA.Fill(sqlDS, "recordsfetch");

                        dataGridView1.DataSource = sqlDS.Tables["recordsfetch"];

                        // Optional: hide columns
                        if (dataGridView1.Columns.Contains("Gender"))
                            dataGridView1.Columns["Gender"].Visible = false;
                        if (dataGridView1.Columns.Contains("Status"))
                            dataGridView1.Columns["Status"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

