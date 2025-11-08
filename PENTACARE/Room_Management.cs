using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class Room_Management : Form
    {
        public Room_Management()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;


            dgvRoom.CellDoubleClick += dgvRoom_CellDoubleClick;
        }

        private void Room_Management_Load(object sender, EventArgs e)
        {
            dgvRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoom.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvRoom.AllowUserToAddRows = false;
            dgvRoom.RowHeadersVisible = false;

            dgvRoom.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRoom.EnableHeadersVisualStyles = false;
            dgvRoom.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dgvRoom.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRoom.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);


            cb_status.Items.Add("All");
            cb_status.Items.Add("Available");
            cb_status.Items.Add("Occupied");

            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection sqlconn = new MySqlConnection(dbconnect))
            {
                string query = "SELECT RoomID as 'Room ID', " +
                               "Room_No as 'Room Number', " +
                               "Room_Type as 'Room Type', " +
                               "Room_Rate as 'Room Rate', " +
                               "Bed as 'Bed', " +
                               "Status as 'Status' " +
                               "FROM room";

                MySqlCommand cmd = new MySqlCommand(query, sqlconn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    sqlconn.Open();
                    adapter.Fill(dt);

                    dgvRoom.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading records: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btn_addRoom_Click(object sender, EventArgs e)
        {
            AddRoom addRoom = new AddRoom();
            addRoom.Show();
            this.Hide();
        }

        private void btn_manageRoom_Click(object sender, EventArgs e)
        {
            Room_Type rt = new Room_Type();
            rt.Show();
            this.Hide();
        }

        private void btn_assignPatient_Click(object sender, EventArgs e)
        {
            if (dgvRoom.CurrentRow == null)
            {
                MessageBox.Show("Please select a room first.", "No Room Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvRoom.CurrentRow;

            int roomID = Convert.ToInt32(row.Cells["Room ID"].Value);
            string roomType = row.Cells["Room Type"].Value?.ToString() ?? "";
            string roomRate = row.Cells["Room Rate"].Value?.ToString() ?? "";
            string status = row.Cells["Status"].Value?.ToString() ?? "";

            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection sqlconn = new MySqlConnection(dbconnect))
            {
                sqlconn.Open();

                string bedQuery = "SELECT COUNT(*) FROM bed WHERE RoomID = @RoomID AND Status = 'Available'";
                using (MySqlCommand cmd = new MySqlCommand(bedQuery, sqlconn))
                {
                    cmd.Parameters.AddWithValue("@RoomID", roomID);
                    int availableBeds = Convert.ToInt32(cmd.ExecuteScalar());

                    if (availableBeds > 0)
                    {
                        AssignRoom assignForm = new AssignRoom(roomID, roomType, roomRate);
                        assignForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No available beds in this room.", "Room Full", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dgvRoom_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgvRoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRoom.Rows[e.RowIndex];

                int roomID = Convert.ToInt32(row.Cells["Room ID"].Value);
                string roomType = row.Cells["Room Type"].Value?.ToString() ?? "";

                View_RoomRec viewForm = new View_RoomRec(roomID, this);
                this.Hide();
                viewForm.Show();
            }
        }

        private void btn_assignPatient_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_searchRoom_TextChanged(object sender, EventArgs e)
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            MySqlConnection conn = new MySqlConnection(dbconnect);

            
            string query = "SELECT RoomID AS 'Room ID', Room_No AS 'Room Number', Room_Type AS 'Room Type', Room_Rate AS 'Room Rate', Status AS 'Status' " +
                           "FROM room WHERE RoomID LIKE '%" + txt_searchRoom.Text + "%' " +
                           "OR Room_No LIKE '%" + txt_searchRoom.Text + "%' " +
                           "OR Room_Type LIKE '%" + txt_searchRoom.Text + "%'";

            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvRoom.DataSource = dt;
        }

        private void cb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        void FilterData()
        {
            string conString = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                string sql = "SELECT RoomID AS 'Room ID', " +
                             "Room_No AS 'Room Number', " +
                             "Room_Type AS 'Room Type', " +
                             "Room_Rate AS 'Room Rate', " +
                             "Bed AS 'Bed', " +
                             "Status AS 'Status' " +
                             "FROM room WHERE 1";

                if (!string.IsNullOrEmpty(txt_searchRoom.Text))
                {
                    sql += " AND (Room_No LIKE '%" + txt_searchRoom.Text + "%' OR Room_Type LIKE '%" + txt_searchRoom.Text + "%')";
                }

                if (cb_status.Text != "All" && !string.IsNullOrEmpty(cb_status.Text))
                {
                    sql += " AND Status = '" + cb_status.Text + "'";
                }

                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRoom.DataSource = dt;
            }
        }

        private void btn_backMain_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }
    }
}


