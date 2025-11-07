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

            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";

            using (MySqlConnection sqlconn = new MySqlConnection(dbconnect))
            {
                try
                {
                    sqlconn.Open();

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

                    string query = @"INSERT INTO room_assign 
                            (PatientID, RoomID, Room_Type, Room_Fee, Admission_Date, Expected_Discharge, Remarks, Status)
                             VALUES (@PatientID, @RoomID, @RoomType, @RoomFee, @AdmissionDate, @ExpectedDischarge, @Remarks, @Status)";

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlconn))
                    {
                        cmd.Parameters.AddWithValue("@PatientID", txt_patientID.Text);
                        cmd.Parameters.AddWithValue("@RoomID", selectedRoomID);
                        cmd.Parameters.AddWithValue("@RoomType", txt_roomType.Text);
                        cmd.Parameters.AddWithValue("@RoomFee", txt_roomRate.Text);
                        cmd.Parameters.AddWithValue("@AdmissionDate", dtp_AD.Value);
                        cmd.Parameters.AddWithValue("@ExpectedDischarge", dtp_ED.Value);
                        cmd.Parameters.AddWithValue("@Remarks", txt_Remarks.Text);
                        cmd.Parameters.AddWithValue("@Status", "Occupied");

                        cmd.ExecuteNonQuery();
                    }

                    string updateRoom = "UPDATE room SET PatientID = @PatientID, Status = 'Occupied' WHERE RoomID = @RoomID";
                    using (MySqlCommand updateRoomCmd = new MySqlCommand(updateRoom, sqlconn))
                    {
                        updateRoomCmd.Parameters.AddWithValue("@PatientID", txt_patientID.Text);
                        updateRoomCmd.Parameters.AddWithValue("@RoomID", selectedRoomID);
                        updateRoomCmd.ExecuteNonQuery();
                    }

                    string updatePatient = "UPDATE patient SET RoomID = @RoomID, Status = 'Admitted' WHERE PatientID = @PatientID";
                    using (MySqlCommand updatePatientCmd = new MySqlCommand(updatePatient, sqlconn))
                    {
                        updatePatientCmd.Parameters.AddWithValue("@RoomID", selectedRoomID);
                        updatePatientCmd.Parameters.AddWithValue("@PatientID", txt_patientID.Text);
                        updatePatientCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Patient successfully assigned! Room status updated to Occupied.",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
    }
}
