using MySql.Data.MySqlClient;
using PENTACARE;
using System.Data;
using System.Data.SqlTypes;

namespace PentaCare
{
    public partial class Patient_Management : Form
    {
        private DataSet sqlDS;

        public Patient_Management()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Size = new Size(1463, 351);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ScrollBars = ScrollBars.Both; // optional: adds scroll if needed

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dataGridView1.AllowUserToAddRows = false;
            //dataGridView1.RowHeadersVisible = false;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            string dbconnect = "server= 127.0.0.1; database=pentacare; uid=root; ";
            MySqlConnection conn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcmd = new MySqlCommand();

            MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            sqlDS = new DataSet();

            conn.Open();

            sqlcmd.CommandText = "SELECT p.PatientID, p.Name, p.Gender, r.Room_No, d.Doctor_Name, d.Specialty, p.Status, DATE_FORMAT(p.Admission_Date, '%Y-%m-%d') AS Admission_Date " +
                "FROM patient AS p LEFT JOIN room AS r ON p.RoomID = r.RoomID " +
                "LEFT JOIN doctor AS d ON p.DoctorID = d.DoctorID " +
                "WHERE p.Status = 'Admitted' OR p.Status = 'Under Observation'";


            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = conn;

            sqlDA.SelectCommand = sqlcmd;

            sqlDA.Fill(sqlDS, "recordsfetch");
            dataGridView1.DataSource = sqlDS;
            dataGridView1.DataMember = "recordsfetch";
            dataGridView1.Columns["Gender"].Visible = false;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Action";
            btn.HeaderText = "Action";
            btn.Text = "View Lab Result";
            btn.UseColumnTextForButtonValue = true;  // ✅ Same text for all buttons
            dataGridView1.Columns.Add(btn);
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Action" && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string patientID = row.Cells["PatientID"].Value.ToString();

                LabMed labMed = new LabMed(patientID, this);
                labMed.Show();
                this.Hide();
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            AdmissionDischarge admisdi = new AdmissionDischarge();
            admisdi.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim(); // value typed by user

            dataGridView1.Size = new Size(1463, 351);
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

            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                try
                {
                    conn.Open();

                    // Filter only admitted patients and also search by ID or Name
                    string query = "SELECT p.PatientID, p.Name, p.Gender, r.Room_No, d.Doctor_Name, p.Status, p.Admission_Date " +
                                   "FROM patient AS p " +
                                   "LEFT JOIN room AS r ON p.RoomID = r.RoomID " +
                                   "LEFT JOIN doctor AS d ON p.DoctorID = d.DoctorID " +
                                   "WHERE p.Status = 'Admitted' AND (p.PatientID LIKE @search OR p.Name LIKE @search)";

                    using (MySqlCommand sqlcmd = new MySqlCommand(query, conn))
                    {
                        sqlcmd.Parameters.AddWithValue("@search", "%" + searchValue + "%");

                        MySqlDataAdapter sqlDA = new MySqlDataAdapter(sqlcmd);
                        DataSet sqlDS = new DataSet();
                        sqlDA.Fill(sqlDS, "recordsfetch");

                        dataGridView1.DataSource = sqlDS.Tables["recordsfetch"];

                        if (!dataGridView1.Columns.Contains("Action"))
                        {
                            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                            btn.Name = "Action";
                            btn.HeaderText = "Action";
                            btn.Text = "View Lab Result";
                            btn.UseColumnTextForButtonValue = true;
                            dataGridView1.Columns.Add(btn);
                            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
                        }

                        // Ensure the Action button is the last column
                        dataGridView1.Columns["Action"].DisplayIndex = dataGridView1.Columns.Count - 1;

                        if (dataGridView1.Columns.Contains("Gender"))
                            dataGridView1.Columns["Gender"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void addPatient_Click(object sender, EventArgs e)
        {
            AddPatient addPatient = new AddPatient();
            addPatient.Show();
            this.Hide();
        }

        private void dischargeBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string patientID = selectedRow.Cells["PatientID"].Value.ToString();
                string name = selectedRow.Cells["Name"].Value.ToString();

                string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
                using (MySqlConnection conn = new MySqlConnection(dbconnect))
                {
                    conn.Open();

                    // Check Billing_Status before discharging
                    string billingCheckQuery = "SELECT Billing_Status FROM patient WHERE PatientID = @PatientID";
                    MySqlCommand billingCmd = new MySqlCommand(billingCheckQuery, conn);
                    billingCmd.Parameters.AddWithValue("@PatientID", patientID);

                    object statusObj = billingCmd.ExecuteScalar();
                    if (statusObj != null && statusObj.ToString() == "Unpaid")
                    {
                        MessageBox.Show($"{name} cannot be discharged because the billing is unpaid.",
                                        "Discharge Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Stop discharge
                    }

                    // Confirm discharge
                    DialogResult result = MessageBox.Show($"Discharge patient: {name}?", "Confirm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        // Update patient status and discharge date
                        string query = "UPDATE patient SET Status = 'Discharged', Discharge_Date = CURDATE() WHERE PatientID = @PatientID";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@PatientID", patientID);
                        cmd.ExecuteNonQuery();

                        // Free up the bed
                        string getBedQuery = "SELECT BedID FROM patient WHERE PatientID = @PatientID";
                        MySqlCommand getBedCmd = new MySqlCommand(getBedQuery, conn);
                        getBedCmd.Parameters.AddWithValue("@PatientID", patientID);
                        object bedIDObj = getBedCmd.ExecuteScalar();

                        if (bedIDObj != null)
                        {
                            int bedID = Convert.ToInt32(bedIDObj);
                            string updateBedQuery = "UPDATE bed SET Status = 'Available' WHERE BedID = @BedID";
                            MySqlCommand updateBedCmd = new MySqlCommand(updateBedQuery, conn);
                            updateBedCmd.Parameters.AddWithValue("@BedID", bedID);
                            updateBedCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show($"{name} has been discharged successfully.");
                        RefreshDataGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a patient to discharge.");
            }
        }
        private void RefreshDataGrid()
        {
            this.Hide();
            Patient_Management form = new Patient_Management();
            form.Show();

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No row selected to edit. Select Name to edit records ");
                return;
            }


            dataGridView1.EndEdit();  // ← forces DGV to save current cell edit


            int pID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PatientID"].Value);
            string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
            string status = dataGridView1.SelectedRows[0].Cells["Status"].Value.ToString();

            // prevent editing DoctorID
            // Check non-editable columns individually

            int colIndex = dataGridView1.CurrentCell.ColumnIndex;

            if (colIndex == 0)
            {
                MessageBox.Show("Patient ID cannot be edited.");
                return;
            }

            if (colIndex == 3)
            {
                DialogResult result = MessageBox.Show(
                   "Room Assignment cannot be changed in this form.\nGo to Room Management to change assigned room?\n\nClick Yes to proceed.",
                   "Doctor and Records",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
             );

                dataGridView1.CurrentCell.Value = ""; // Clear attempted edit

                if (result == DialogResult.Yes)
                {
                    // papunta sa room management
                }
                return;
            }

            if (colIndex == 4)
            {
                DialogResult result = MessageBox.Show(
                   "Doctor Name cannot be edited.\nGo to Doctor and Records to change assigned doctor?\n\nClick Yes to proceed.",
                   "Doctor and Records",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
             );

                dataGridView1.CurrentCell.Value = ""; // Clear attempted edit

                if (result == DialogResult.Yes)
                {
                    DoctorandRecords drForm = new DoctorandRecords();
                    drForm.Show();
                    this.Hide();
                }
                return;
            }




            dataGridView1.EndEdit();
            try
            {
                string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
                MySqlConnection conn = new MySqlConnection(dbconnect);
                MySqlCommand sqlcmd = new MySqlCommand();
                MySqlDataAdapter sqlDA = new MySqlDataAdapter();
                DataSet sqlDS = new DataSet();

                conn.Open();

                sqlcmd.CommandText = $"UPDATE patient " +
                                     $"SET Name = '{name}', " +
                                     $"Status = '{status}' " +
                                     $"WHERE PatientID = {pID}";

                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Connection = conn;
                sqlcmd.ExecuteNonQuery();

                MessageBox.Show("Patient record updated successfully.");

                // reload data
                sqlcmd.CommandText = "SELECT p.PatientID, p.Name, p.Gender, r.Room_No, d.Doctor_Name, p.Status, p.Admission_Date " +
                     "FROM patient AS p " +
                     "LEFT JOIN room AS r ON p.RoomID = r.RoomID " +
                     "LEFT JOIN doctor AS d ON p.DoctorID = d.DoctorID";

                sqlDA.SelectCommand = sqlcmd;
                sqlDS.Clear();
                sqlDA.Fill(sqlDS, "recordsfetch");
                dataGridView1.DataSource = sqlDS;
                dataGridView1.DataMember = "recordsfetch";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No row selected to delete.");
                return;
            }

            int patientID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PatientID"].Value);

            DialogResult result = MessageBox.Show("Are you sure you want to delete this patient record?",
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

                sqlcmd.CommandText = $"DELETE FROM patient WHERE PatientID = {patientID}";
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Connection = conn;
                sqlcmd.ExecuteNonQuery();

                MessageBox.Show("Patient record deleted successfully.");

                sqlcmd.CommandText = "SELECT p.PatientID, p.Name, r.Room_No, d.Doctor_Name, p.Status, p.Admission_Date " +
                                  "FROM patient AS p " +
                                  "LEFT JOIN room AS r ON p.RoomID = r.RoomID " +
                                  "LEFT JOIN doctor AS d ON p.DoctorID = d.DoctorID";
                sqlDA.SelectCommand = sqlcmd;
                sqlDS.Clear();
                sqlDA.Fill(sqlDS, "recordsfetch");
                dataGridView1.DataSource = sqlDS;
                dataGridView1.DataMember = "recordsfetch";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message);
            }
        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT p.PatientID, p.Name, p.Gender, r.Room_No, d.Doctor_Name, d.Specialty, p.Status, " +
                                   "DATE_FORMAT(p.Admission_Date, '%Y-%m-%d') AS Admission_Date " +
                                   "FROM patient AS p " +
                                   "LEFT JOIN room AS r ON p.RoomID = r.RoomID " +
                                   "LEFT JOIN doctor AS d ON p.DoctorID = d.DoctorID " +
                                   "WHERE (p.Status = 'Admitted' OR p.Status = 'Under Observation')";

                    string selectedGender = cmbGender.SelectedItem?.ToString() ?? "All";
                    if (selectedGender != "All")
                    {
                        query += " AND p.Gender = @Gender";
                    }

                    using (MySqlCommand sqlcmd = new MySqlCommand(query, conn))
                    {
                        if (selectedGender != "All")
                            sqlcmd.Parameters.AddWithValue("@Gender", selectedGender);

                        MySqlDataAdapter sqlDA = new MySqlDataAdapter(sqlcmd);
                        DataSet sqlDS = new DataSet();
                        sqlDA.Fill(sqlDS, "recordsfetch");

                        dataGridView1.DataSource = sqlDS.Tables["recordsfetch"];

                        if (dataGridView1.Columns.Contains("Gender"))
                            dataGridView1.Columns["Gender"].Visible = false;

                        if (!dataGridView1.Columns.Contains("Action"))
                        {
                            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                            btn.Name = "Action";
                            btn.HeaderText = "Action";
                            btn.Text = "View Lab Result";
                            btn.UseColumnTextForButtonValue = true;
                            dataGridView1.Columns.Add(btn);
                        }

                        dataGridView1.Columns["Action"].DisplayIndex = dataGridView1.Columns.Count - 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }



        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; uid=root;";
            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT p.PatientID, p.Name, p.Gender, r.Room_No, d.Doctor_Name, d.Specialty, p.Status, DATE_FORMAT(p.Admission_Date, '%Y-%m-%d') AS Admission_Date " +
                                   "FROM patient AS p LEFT JOIN room AS r ON p.RoomID = r.RoomID " +
                                   "LEFT JOIN doctor AS d ON p.DoctorID = d.DoctorID " +
                                   "WHERE (p.Status = 'Admitted' OR p.Status = 'Under Observation')";

                    // ✅ Optional filter by status (only if combo box isn't set to "All")
                    string selectedStatus = cmbStatus.SelectedItem?.ToString() ?? "All";
                    if (selectedStatus != "All")
                    {
                        query += " AND p.Status = @Status";
                    }

                    using (MySqlCommand sqlcmd = new MySqlCommand(query, conn))
                    {
                        if (selectedStatus != "All")
                            sqlcmd.Parameters.AddWithValue("@Status", selectedStatus);

                        MySqlDataAdapter sqlDA = new MySqlDataAdapter(sqlcmd);
                        DataSet sqlDS = new DataSet();
                        sqlDA.Fill(sqlDS, "recordsfetch");

                        dataGridView1.DataSource = sqlDS.Tables["recordsfetch"];

                        if (dataGridView1.Columns.Contains("Gender"))
                            dataGridView1.Columns["Gender"].Visible = false;

                        // ✅ Add button column only if not yet added
                        if (!dataGridView1.Columns.Contains("Action"))
                        {
                            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                            btn.Name = "Action";
                            btn.HeaderText = "Action";
                            btn.Text = "View Lab Result";
                            btn.UseColumnTextForButtonValue = true;
                            dataGridView1.Columns.Add(btn);
                        }

                        // ✅ Make sure Action button is last column
                        dataGridView1.Columns["Action"].DisplayIndex = dataGridView1.Columns.Count - 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void btn_backPM_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void dischargeBtn_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

