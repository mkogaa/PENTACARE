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
    public partial class AddRoom : Form
    {
        private int roomID;

        public AddRoom()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        }

        public AddRoom(int roomID)
        {
            InitializeComponent();
            this.roomID = roomID;
            LoadRoomData(roomID);
        }

        private void LoadRoomData(int roomID)
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                conn.Open();
                string query = "SELECT * FROM room WHERE RoomID=@RoomID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomID", roomID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txt_RoomNo.Text = reader["Room_No"].ToString();
                            cb_RoomType.Text = reader["Room_Type"].ToString();
                            txt_Rate.Text = reader["Room_Rate"].ToString();
                            txt_beds.Text = reader["Bed"].ToString();
                            cb_Status.Text = reader["Status"].ToString();

                            btn_addRoom.Text = "Update Room";
                        }
                    }
                }
            }
        }

        private void AddRoom_Load(object sender, EventArgs e)
        {

        }

        private void btn_addRoom_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_RoomNo.Text))
            {
                MessageBox.Show("Please enter the room number.");
                return;
            }

            if (cb_RoomType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the room type.");
                return;
            }

            if (string.IsNullOrEmpty(txt_Rate.Text))
            {
                MessageBox.Show("Please enter the room fee.");
                return;
            }

            if (txt_Rate.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Room fee cannot contain letters.");
                return;
            }

            if (cb_Status.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the room status.");
                return;
            }

            if (string.IsNullOrEmpty(txt_beds.Text))
            {
                MessageBox.Show("Please enter the number of beds.");
                return;
            }

            if (!int.TryParse(txt_beds.Text.Trim(), out int bedCount) || bedCount <= 0)
            {
                MessageBox.Show("Invalid bed count. Please enter a valid number.");
                return;
            }

            string roomNumber = txt_RoomNo.Text.Trim();
            string roomType = cb_RoomType.SelectedItem.ToString();
            double roomRate = double.Parse(txt_Rate.Text.Trim());
            string roomStatus = cb_Status.SelectedItem.ToString();

            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            MySqlConnection sqlconn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcommand = new MySqlCommand();

            try
            {
                sqlconn.Open();

                if (roomID > 0)
                {

                    string updateRoom = "UPDATE room SET Room_No=@RoomNo, Room_Type=@RoomType, Room_Rate=@RoomRate, " +
                                        "Bed=@BedCount, Status=@Status WHERE RoomID=@RoomID";
                    using (MySqlCommand cmd = new MySqlCommand(updateRoom, sqlconn))
                    {
                        cmd.Parameters.AddWithValue("@RoomNo", roomNumber);
                        cmd.Parameters.AddWithValue("@RoomType", roomType);
                        cmd.Parameters.AddWithValue("@RoomRate", roomRate);
                        cmd.Parameters.AddWithValue("@BedCount", bedCount);
                        cmd.Parameters.AddWithValue("@Status", roomStatus);
                        cmd.Parameters.AddWithValue("@RoomID", roomID);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Room updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    string insertRoom = "INSERT INTO room (Room_No, Room_Type, Room_Rate, Bed, Status) " +
                                        "VALUES (@RoomNo, @RoomType, @RoomRate, @BedCount, @Status)";
                    using (MySqlCommand cmd = new MySqlCommand(insertRoom, sqlconn))
                    {
                        cmd.Parameters.AddWithValue("@RoomNo", roomNumber);
                        cmd.Parameters.AddWithValue("@RoomType", roomType);
                        cmd.Parameters.AddWithValue("@RoomRate", roomRate);
                        cmd.Parameters.AddWithValue("@BedCount", bedCount);
                        cmd.Parameters.AddWithValue("@Status", roomStatus);
                        cmd.ExecuteNonQuery();

                        long newRoomID = cmd.LastInsertedId;

                        for (int i = 1; i <= bedCount; i++)
                        {
                            string insertBed = "INSERT INTO bed (RoomID, Bed_No, Status) VALUES (@RoomID, @BedNo, 'Available')";
                            using (MySqlCommand bedCmd = new MySqlCommand(insertBed, sqlconn))
                            {
                                bedCmd.Parameters.AddWithValue("@RoomID", newRoomID);
                                bedCmd.Parameters.AddWithValue("@BedNo", "Bed " + i);
                                bedCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Room and beds added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_RoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_RoomType.SelectedIndex != -1)
            {
                string selectedType = cb_RoomType.SelectedItem.ToString();
                LoadRoomRate(selectedType);
            }
        }

        void LoadRoomRate(string roomType)
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection con = new MySqlConnection(dbconnect))
            {
                try
                {
                    con.Open();
                    string query = "SELECT RoomType_Rate, Room_Capacity FROM room_type WHERE Room_Type = @type";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@type", roomType);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txt_Rate.Text = reader["RoomType_Rate"].ToString();
                        txt_beds.Text = reader["Room_Capacity"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading room rate: " + ex.Message);
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Room_Management roomManagement = new Room_Management();
            roomManagement.Show();
            this.Hide();
        }
    }
}
