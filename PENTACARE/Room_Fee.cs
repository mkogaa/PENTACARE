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
    public partial class Room_Fee : Form
    {
        public Room_Fee()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        private void Room_Fee_Load(object sender, EventArgs e)
        {
            LoadRoomType();
        }

        private void LoadRoomType()
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            MySqlConnection sqlconn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcommand = new MySqlCommand();

            try
            {
                sqlconn.Open();

                sqlcommand.CommandText = "SELECT Room_Type FROM room_type";
                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconn;

                MySqlDataReader reader = sqlcommand.ExecuteReader();

                while (reader.Read())
                {
                    cb_roomType.Items.Add(reader["Room_Type"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room types: " + ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }
        }

        private void btn_saveFee_Click(object sender, EventArgs e)
        {
            if (cb_roomType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a room type.");
                return;
            }

            if (string.IsNullOrEmpty(txt_NewFee.Text))
            {
                MessageBox.Show("Please enter the new room fee.");
                return;
            }

            if (txt_NewFee.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Room fee cannot contain letters.");
                return;
            }

            string selectedRoomType = cb_roomType.SelectedItem.ToString();
            double newFee = double.Parse(txt_NewFee.Text.Trim());

            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            MySqlConnection sqlconn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcommand = new MySqlCommand();

            try
            {
                sqlconn.Open();

                sqlcommand.CommandText = "UPDATE room_type SET RoomType_Rate = @newFee WHERE Room_Type = @type";
                
                sqlcommand.Parameters.AddWithValue("@newFee", newFee);
                sqlcommand.Parameters.AddWithValue("@type", selectedRoomType);
                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconn;

                sqlcommand.ExecuteNonQuery();

                MessageBox.Show("Room fee updated successfully!");
                txt_CurrentFee.Text = newFee.ToString();
                txt_NewFee.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating room fee: " + ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }
        }

        private void cb_roomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_roomType.SelectedIndex != -1)
            {
                string selectedRoomType = cb_roomType.SelectedItem.ToString();

                string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
                MySqlConnection sqlconn = new MySqlConnection(dbconnect);
                MySqlCommand sqlcommand = new MySqlCommand();

                try
                {
                    sqlconn.Open();

                    sqlcommand.CommandText = "SELECT RoomType_Rate FROM room_type WHERE Room_Type = @type";
                    sqlcommand.Parameters.AddWithValue("@type", selectedRoomType);
                    sqlcommand.CommandType = CommandType.Text;
                    sqlcommand.Connection = sqlconn;

                    object result = sqlcommand.ExecuteScalar();

                    if (result != null)
                    {
                        txt_CurrentFee.Text = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching current fee: " + ex.Message);
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }
    }
}
