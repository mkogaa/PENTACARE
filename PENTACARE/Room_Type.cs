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
    public partial class Room_Type : Form
    {
        public Room_Type()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        private void Room_Type_Load(object sender, EventArgs e)
        {
            dgvRoomType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoomType.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvRoomType.AllowUserToAddRows = false;
            dgvRoomType.RowHeadersVisible = false;

            dgvRoomType.EnableHeadersVisualStyles = false;
            dgvRoomType.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dgvRoomType.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRoomType.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection sqlconn = new MySqlConnection(dbconnect))
            {
                string query = "SELECT Room_TypeID as 'Room Type ID', " +
                                "Room_Type as 'Room Type', " +
                                "Room_Description as 'Room Description', " +
                                "Room_Capacity as 'Room Capacity', " +
                                "RoomType_Rate as 'Room Type Rate' " +
                                "FROM room_type";

                MySqlCommand cmd = new MySqlCommand(query, sqlconn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    sqlconn.Open();
                    adapter.Fill(dt);

                    dgvRoomType.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading records: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_updateRate_Click(object sender, EventArgs e)
        {
            Room_Fee rf = new Room_Fee();
            rf.Show();
            this.Hide();
        }
    }
}
