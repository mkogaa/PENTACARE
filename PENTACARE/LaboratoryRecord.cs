using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace USERS_WINDOW
{
    public partial class LaboratoryRecord : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=pentacare;username=root;password=;");
        MySqlDataAdapter da;
        MySqlCommand cmd;
        DataTable dt;
        int currentPatientID;

        public LaboratoryRecord(int patientID)
        {
            InitializeComponent();
            currentPatientID = patientID;


            btn_record_assigntest.Click += btn_record_assigntest_Click_1;
            btn_record_printreport.Click += btn_record_printreport_Click;
            btn_record_back.Click += btn_record_back_Click;
            btn_record_complete.Click += btn_record_complete_Click;


            StyleDataGridView();
            SetupFilterComboBox();
            SetupSearchBox();


            LoadPatientInfo();
            LoadLabRecords();
        }

        private void StyleDataGridView()
        {
            dgv_laboratoryrecord.BorderStyle = BorderStyle.None;
            dgv_laboratoryrecord.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255);
            dgv_laboratoryrecord.DefaultCellStyle.BackColor = Color.White;
            dgv_laboratoryrecord.DefaultCellStyle.ForeColor = Color.Black;
            dgv_laboratoryrecord.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            dgv_laboratoryrecord.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgv_laboratoryrecord.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_laboratoryrecord.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dgv_laboratoryrecord.EnableHeadersVisualStyles = false;

            dgv_laboratoryrecord.GridColor = Color.FromArgb(180, 200, 230);
            dgv_laboratoryrecord.RowHeadersVisible = false;
            dgv_laboratoryrecord.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_laboratoryrecord.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
            dgv_laboratoryrecord.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv_laboratoryrecord.AllowUserToAddRows = false;
            dgv_laboratoryrecord.ReadOnly = true;
            dgv_laboratoryrecord.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_laboratoryrecord.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void LoadPatientInfo()
        {
            try
            {
                con.Open();
                string query = @"SELECT 
                                    CONCAT(p.First_Name, ' ', p.Last_Name) AS Name, 
                                    IFNULL(r.Room_No, 'N/A') AS Room_No, 
                                    IFNULL(d.Doctor_Name, 'N/A') AS Doctor_Name, 
                                    IFNULL(d.Specialty, 'N/A') AS Specialty
                                 FROM patient p
                                 LEFT JOIN doctor d ON p.DoctorID = d.DoctorID
                                 LEFT JOIN room r ON p.RoomID = r.RoomID
                                 WHERE p.PatientID = @id";

                da = new MySqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@id", currentPatientID);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    lbl_record_patientname.Text = dt.Rows[0]["Name"].ToString();
                    lbl_record_room.Text = dt.Rows[0]["Room_No"].ToString();
                    lbl_record_doctorname.Text = dt.Rows[0]["Doctor_Name"].ToString();
                    lbl_record_specialty.Text = dt.Rows[0]["Specialty"].ToString();
                }
                else
                {
                    lbl_record_patientname.Text = "N/A";
                    lbl_record_room.Text = "N/A";
                    lbl_record_doctorname.Text = "N/A";
                    lbl_record_specialty.Text = "N/A";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient info: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void LoadLabRecords(string search = "", string filterStatus = "All")
        {
            try
            {
                con.Open();
                string query = @"SELECT 
                                    pl.RecordID,
                                    l.Lab_Name AS TestName,
                                    l.Lab_Description AS Description,
                                    l.Lab_Fee AS Fee,
                                    l.Lab_Category AS Category,
                                    l.Estimated_Time AS EstimatedTime,
                                    pl.Date_Ordered,
                                    IFNULL(pl.Result, 'Pending') AS ResultDescription,
                                    IFNULL(pl.Status, 'Pending') AS Status
                                FROM patient_labrec pl
                                JOIN lab_services l ON pl.LabID = l.LabID
                                WHERE pl.PatientID = @id
                                AND (l.Lab_Name LIKE @search OR l.Lab_Category LIKE @search)";

                if (filterStatus != "All")
                    query += " AND pl.Status = @status";

                da = new MySqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@id", currentPatientID);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
                if (filterStatus != "All")
                    da.SelectCommand.Parameters.AddWithValue("@status", filterStatus);

                dt = new DataTable();
                da.Fill(dt);
                dgv_laboratoryrecord.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading lab records: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        private void SetupFilterComboBox()
        {
            cb_record.Items.Clear();
            cb_record.Items.Add("All");
            cb_record.Items.Add("Pending");
            cb_record.Items.Add("Completed");
            cb_record.SelectedIndex = 0;
            cb_record.SelectedIndexChanged += cb_record_SelectedIndexChanged;
        }

        private void cb_record_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = cb_record.Text;
            string searchText = txt_record_search.Text == "Search by Test Name or Category" ? "" : txt_record_search.Text;
            LoadLabRecords(searchText, selectedFilter);
        }

        private void SetupSearchBox()
        {
            txt_record_search.ForeColor = Color.Gray;
            txt_record_search.Font = new Font("Century Gothic", 20);
            txt_record_search.Text = "Search by Test Name or Category";

            txt_record_search.GotFocus += RemovePlaceholder;
            txt_record_search.LostFocus += AddPlaceholder;
            txt_record_search.TextChanged += txt_record_search_TextChanged;
            txt_record_search.KeyDown += txt_record_search_KeyDown;
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (txt_record_search.Text == "Search by Test Name or Category")
            {
                txt_record_search.Text = "";
                txt_record_search.ForeColor = Color.Black;
            }
        }

        private void AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_record_search.Text))
            {
                txt_record_search.Text = "Search by Test Name or Category";
                txt_record_search.ForeColor = Color.Gray;
            }
        }

        private void txt_record_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_record_search.Text != "Search by Test Name or Category")
                LoadLabRecords(txt_record_search.Text, cb_record.Text);
        }

        private void txt_record_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadLabRecords(txt_record_search.Text, cb_record.Text);
            }
        }

        private void btn_record_printreport_Click(object sender, EventArgs e)
        {
            try
            {
                AdmissionAndDischargeRecords reportForm = new AdmissionAndDischargeRecords(currentPatientID);
                reportForm.FormClosed += (s, args) => this.Show();
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening report: " + ex.Message);
            }
        }

        private void btn_record_assigntest_Click_1(object sender, EventArgs e)
        {
            AssignLaboratoryTest assignForm = new AssignLaboratoryTest(currentPatientID);
            assignForm.FormClosed += (s, args) =>
            {
                LoadLabRecords("", cb_record.Text);
                LoadPatientInfo();
                this.Show();
            };
            assignForm.Show();
        }

        private void btn_record_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_record_complete_Click(object sender, EventArgs e)
        {
            if (dgv_laboratoryrecord.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a laboratory record to mark as completed.");
                return;
            }

            int recordID = Convert.ToInt32(dgv_laboratoryrecord.SelectedRows[0].Cells["RecordID"].Value);

            try
            {
                con.Open();
                string query = "UPDATE patient_labrec SET Status = 'Completed' WHERE RecordID = @recordID;";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@recordID", recordID);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("✅ Record marked as completed successfully!");

                string searchText = txt_record_search.Text == "Search by Test Name or Category" ? "" : txt_record_search.Text;
                string filterStatus = cb_record.Text;
                LoadLabRecords(searchText, filterStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record status: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void cb_record_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
