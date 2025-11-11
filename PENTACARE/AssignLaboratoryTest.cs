using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace USERS_WINDOW
{
    public partial class AssignLaboratoryTest : Form
    {
        private int currentPatientID;
        private readonly MySqlConnection con = new MySqlConnection("server=localhost;database=pentacare;username=root;password=;");
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private DataTable dt;
        private int doctorID;


        public AssignLaboratoryTest(int patientID, int loggedDocorID)
        {
            InitializeComponent();
            currentPatientID = patientID;
            doctorID = loggedDocorID;

            LoadLabTests();
            SetupFormStyle();
            LoadPatientInfo();
        }

        private void SetupFormStyle()
        {
            this.BackColor = Color.White;
            cb_labtest.DropDownStyle = ComboBoxStyle.DropDownList;
            txt_assign_fee.Font = new Font("Century Gothic", 12);
            txt_assign_remarks.Font = new Font("Century Gothic", 12);
        }

        private void LoadPatientInfo()
        {
            try
            {
                con.Open();
                string query = @"
                    SELECT 
                        p.Name AS FullName,
                        IFNULL(r.Room_No, 'N/A') AS Room_No,
                        IFNULL(d.Doctor_Name, 'N/A') AS Doctor_Name,
                        IFNULL(d.Specialty, 'N/A') AS Specialty
                    FROM patient p
                    LEFT JOIN doctor d ON p.DoctorID = d.DoctorID
                    LEFT JOIN room r ON CAST(p.RoomID AS UNSIGNED) = r.RoomID
                    WHERE p.PatientID = @id;";

                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", currentPatientID);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lbl_assign_patientname.Text = reader["FullName"].ToString();
                    lbl_assign_room.Text = reader["Room_No"].ToString();
                    lbl_assign_doctorname.Text = reader["Doctor_Name"].ToString();
                    lbl_assign_specialty.Text = reader["Specialty"].ToString();
                }
                else
                {
                    lbl_assign_patientname.Text = "Unknown Patient";
                    lbl_assign_room.Text = "N/A";
                    lbl_assign_doctorname.Text = "N/A";
                    lbl_assign_specialty.Text = "N/A";
                }

                reader.Close();
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

        private void LoadLabTests()
        {
            try
            {
                con.Open();
                string query = "SELECT LabID, Lab_Name, Lab_Fee FROM lab_services ORDER BY Lab_Name ASC;";
                da = new MySqlDataAdapter(query, con);
                dt = new DataTable();
                da.Fill(dt);

                DataRow newRow = dt.NewRow();
                newRow["LabID"] = 0;
                newRow["Lab_Name"] = "Select Test";
                newRow["Lab_Fee"] = 0;
                dt.Rows.InsertAt(newRow, 0);

                cb_labtest.DataSource = dt;
                cb_labtest.DisplayMember = "Lab_Name";
                cb_labtest.ValueMember = "LabID";

                cb_labtest.SelectedIndexChanged += (s, e) =>
                {
                    if (cb_labtest.SelectedIndex > 0)
                    {
                        DataRowView drv = cb_labtest.SelectedItem as DataRowView;
                        if (drv != null)
                            txt_assign_fee.Text = drv["Lab_Fee"].ToString();
                    }
                    else
                    {
                        txt_assign_fee.Clear();
                    }
                };

                cb_labtest.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading lab tests: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btn_assign_save_Click(object sender, EventArgs e)
        {
            if (cb_labtest.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a laboratory test.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_assign_fee.Text))
            {
                MessageBox.Show("Please enter the fee.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_assign_remarks.Text))
            {
                MessageBox.Show("Please enter remarks or test description.");
                return;
            }

            try
            {
                con.Open();
                string query = @"INSERT INTO patient_labrec 
                                 (PatientID, LabID, DoctorID, Date_Ordered, Fee, Result, Status)
                                 VALUES (@patientID, @labID, @doctorID, @dateOrdered, @fee, @result, 'Pending');";

                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@patientID", currentPatientID);
                cmd.Parameters.AddWithValue("@labID", cb_labtest.SelectedValue);
                cmd.Parameters.AddWithValue("@doctorID", doctorID); 
                cmd.Parameters.AddWithValue("@dateOrdered", dtp_assign.Value.Date);
                cmd.Parameters.AddWithValue("@fee", Convert.ToDecimal(txt_assign_fee.Text));
                cmd.Parameters.AddWithValue("@result", txt_assign_remarks.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Laboratory test assigned successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving lab test: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btn_assign_clear_Click(object sender, EventArgs e)
        {
            cb_labtest.SelectedIndex = 0;
            txt_assign_fee.Clear();
            txt_assign_remarks.Clear();
            dtp_assign.Value = DateTime.Now;
        }

        private void btn_assign_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AssignLaboratoryTest_Load(object sender, EventArgs e)
        {
        }
    }
}
