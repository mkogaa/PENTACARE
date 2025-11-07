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
        public AddRoom()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
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

            if (cb_RoomType.SelectedIndex == -1) {
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

                sqlcommand.CommandText = $"INSERT INTO room (Room_No, Room_Type, Room_Rate, Status) " +
                                 $"VALUES ('{roomNumber}', '{roomType}', '{roomRate}', '{roomStatus}')";
                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconn;

                sqlcommand.ExecuteNonQuery();

                MessageBox.Show("Room added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }
        }
    }
}
