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
    public partial class View_RoomRec : Form
    {
        private int roomID;

        private Room_Management parentForm;
        public View_RoomRec(int roomID, Room_Management parentForm)
        {
            InitializeComponent();

            this.roomID = roomID;

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            this.parentForm = parentForm;
        }

        private void View_RoomRec_Load(object sender, EventArgs e)
        {
            LoadRoomRecord();
        }

        private void LoadRoomRecord()
        {
            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection conn = new MySqlConnection(dbconnect))
            {
                string query = @"SELECT r.Room_No AS 'RoomNumber', 
                                r.Room_Type AS 'RoomType',
                                r.Status AS 'RoomStatus',
                                p.Name AS 'PatientName', 
                                p.Age, 
                                p.Gender, 
                                a.Admission_Date AS 'AdmissionDate'
                         FROM room r
                         LEFT JOIN room_assign a ON r.RoomID = a.RoomID
                         LEFT JOIN patient p ON a.PatientID = p.PatientID
                         WHERE r.RoomID = @RoomID";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomID", roomID);

                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblRoomNo.Text = reader["RoomNumber"].ToString();
                            lblType.Text = reader["RoomType"].ToString();
                            lblStatus.Text = reader["RoomStatus"].ToString();
                            lblPatient.Text = reader["PatientName"].ToString();
                            lblAge.Text = reader["Age"].ToString();
                            lblGender.Text = reader["Gender"].ToString();
                            lblAD.Text = reader["AdmissionDate"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No patient assigned to this room.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading room record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_backk_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
        }

        private void btn_backk_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
