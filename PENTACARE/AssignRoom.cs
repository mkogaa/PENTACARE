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
    public partial class AssignRoom : Form
    {
        private int selectedRoomID;
        private string roomType;
        private string roomRate;


        public AssignRoom(int roomID, string roomType, string roomRate)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;


            selectedRoomID = roomID;
            this.roomType = roomType;
            this.roomRate = roomRate;

            txt_roomType.Text = roomType;
            txt_roomRate.Text = roomRate;
        }


        private void txt_patientName_TextChanged(object sender, EventArgs e)
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection sqlconn = new MySqlConnection(dbconnect))
            {
                try
                {
                    sqlconn.Open();
                    string query = "SELECT PatientID FROM patient WHERE Name = @Name LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, sqlconn))
                    {
                        cmd.Parameters.AddWithValue("@Name", txt_patientName.Text);
                        object result = cmd.ExecuteScalar();
                        txt_patientID.Text = result != null ? result.ToString() : "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching Patient ID: " + ex.Message);
                }
            }
        }

        private void btn_assign_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txt_patientID.Text))
            {
                MessageBox.Show("Please enter or select a valid patient.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_roomType.Text) || string.IsNullOrWhiteSpace(txt_roomRate.Text))
            {
                MessageBox.Show("Room details are missing.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cb_bed.SelectedValue == null)
            {
                MessageBox.Show("Please select an available bed.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bedID = Convert.ToInt32(cb_bed.SelectedValue);
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";

            using (MySqlConnection sqlconn = new MySqlConnection(dbconnect))
            {
                try
                {
                    sqlconn.Open();

                    string roomStatusQuery = "SELECT Status FROM room WHERE RoomID = @RoomID";
                    using (MySqlCommand statusCmd = new MySqlCommand(roomStatusQuery, sqlconn))
                    {
                        statusCmd.Parameters.AddWithValue("@RoomID", selectedRoomID);
                        object result = statusCmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Room not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string currentStatus = result.ToString().Trim().ToLower();

                        if (currentStatus != "available")
                        {
                            MessageBox.Show("Cannot assign a patient to a room that is not available.", "Assignment Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string checkQuery = "SELECT COUNT(*) FROM room_assign WHERE PatientID = @PatientID AND Status = 'Occupied'";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, sqlconn))
                    {
                        checkCmd.Parameters.AddWithValue("@PatientID", txt_patientID.Text);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("This patient is already assigned to a room.", "Assignment Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string insertQuery = @"INSERT INTO room_assign (PatientID, RoomID, BedID, Room_Type, Room_Fee, Admission_Date, Expected_Discharge, Remarks, Status)
                                   VALUES (@PatientID, @RoomID, @BedID, @RoomType, @RoomFee, @AdmissionDate, @ExpectedDischarge, @Remarks, @Status)";
                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, sqlconn))
                    {
                        insertCmd.Parameters.AddWithValue("@PatientID", txt_patientID.Text);
                        insertCmd.Parameters.AddWithValue("@RoomID", selectedRoomID);
                        insertCmd.Parameters.AddWithValue("@BedID", bedID);
                        insertCmd.Parameters.AddWithValue("@RoomType", txt_roomType.Text);
                        insertCmd.Parameters.AddWithValue("@RoomFee", txt_roomRate.Text);
                        insertCmd.Parameters.AddWithValue("@AdmissionDate", dtp_AD.Value);
                        insertCmd.Parameters.AddWithValue("@ExpectedDischarge", dtp_ED.Value);
                        insertCmd.Parameters.AddWithValue("@Remarks", txt_Remarks.Text);
                        insertCmd.Parameters.AddWithValue("@Status", "Occupied");
                        insertCmd.ExecuteNonQuery();
                    }

                    string updatePatient = "UPDATE patient SET RoomID = @RoomID, Status = 'Admitted' WHERE PatientID = @PatientID";
                    using (MySqlCommand updatePatientCmd = new MySqlCommand(updatePatient, sqlconn))
                    {
                        updatePatientCmd.Parameters.AddWithValue("@RoomID", selectedRoomID);
                        updatePatientCmd.Parameters.AddWithValue("@PatientID", txt_patientID.Text);
                        updatePatientCmd.ExecuteNonQuery();
                    }

                    string updateBed = "UPDATE bed SET Status = 'Occupied' WHERE BedID = @BedID";
                    using (MySqlCommand updateBedCmd = new MySqlCommand(updateBed, sqlconn))
                    {
                        updateBedCmd.Parameters.AddWithValue("@BedID", bedID);
                        updateBedCmd.ExecuteNonQuery();
                    }

                    string checkBedsQuery = "SELECT COUNT(*) FROM bed WHERE RoomID = @RoomID AND Status = 'Available'";
                    int availableBeds;
                    using (MySqlCommand checkBedsCmd = new MySqlCommand(checkBedsQuery, sqlconn))
                    {
                        checkBedsCmd.Parameters.AddWithValue("@RoomID", selectedRoomID);
                        availableBeds = Convert.ToInt32(checkBedsCmd.ExecuteScalar());
                    }

                    string roomStatus = availableBeds == 0 ? "Occupied" : "Available";
                    string updateRoom = "UPDATE room SET Status = @Status WHERE RoomID = @RoomID";
                    using (MySqlCommand updateRoomCmd = new MySqlCommand(updateRoom, sqlconn))
                    {
                        updateRoomCmd.Parameters.AddWithValue("@Status", roomStatus);
                        updateRoomCmd.Parameters.AddWithValue("@RoomID", selectedRoomID);
                        updateRoomCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Patient successfully assigned! {availableBeds} bed(s) remaining in this room.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Room_Management rm = new Room_Management();
                    rm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error assigning patient: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btn_assign_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_patientID.Clear();
            txt_patientName.Clear();
            txt_Remarks.Clear();
            txt_roomRate.Clear();
            txt_roomType.Clear();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Room_Management rm = new Room_Management();
            rm.Show();
            this.Hide();
        }

        private void AssignRoom_Load(object sender, EventArgs e)
        {
            LoadAvailableBeds();
        }

        private void LoadAvailableBeds()
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection sqlconn = new MySqlConnection(dbconnect))
            {
                try
                {
                    sqlconn.Open();

                    string roomQuery = "SELECT Status FROM room WHERE RoomID = @RoomID";
                    using (MySqlCommand roomCmd = new MySqlCommand(roomQuery, sqlconn))
                    {
                        roomCmd.Parameters.AddWithValue("@RoomID", selectedRoomID);
                        object result = roomCmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Room not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string status = result.ToString().Trim().ToLower();
                        if (status == "inactive")
                        {
                            MessageBox.Show("Cannot assign patients to an inactive room.", "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cb_bed.DataSource = null; 
                            return;
                        }
                    }

                    string query = "SELECT BedID, Bed_No FROM bed WHERE RoomID = @RoomID AND Status = 'Available'";
                    using (MySqlCommand cmd = new MySqlCommand(query, sqlconn))
                    {
                        cmd.Parameters.AddWithValue("@RoomID", selectedRoomID);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cb_bed.DataSource = dt;
                        cb_bed.DisplayMember = "Bed_No";
                        cb_bed.ValueMember = "BedID";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading available beds: " + ex.Message);
                }
            }
        }

    }
}
