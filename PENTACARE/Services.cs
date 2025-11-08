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
using System.Xml.Linq;

namespace PENTACARE
{
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;



        }

        private void btn_addService_Click(object sender, EventArgs e)
        {
            AddService addService = new AddService();
            addService.Show();
            this.Hide();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void Services_Load(object sender, EventArgs e)
        {
            dgvService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvService.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvService.AllowUserToAddRows = false;
            dgvService.RowHeadersVisible = false;


            dgvService.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvService.EnableHeadersVisualStyles = false;
            dgvService.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dgvService.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvService.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection sqlconn = new MySqlConnection(dbconnect))
            {
                string query = "SELECT ServiceID as 'Service ID', " +
                                "Service_Name as 'Service Name', " +
                                "Service_Fee as 'Service Fee', " +
                                "Service_Type as 'Service Type' " +
                                "FROM other_services";

                MySqlCommand cmd = new MySqlCommand(query, sqlconn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    sqlconn.Open();
                    adapter.Fill(dt);

                    dgvService.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading records: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string serviceName = txtSearch.Text.Trim();

            string dbconnection = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection con = new MySqlConnection(dbconnection))
            {
                try
                {
                    con.Open();

                    string query = "SELECT ServiceID AS 'Service ID', " + "Service_Name AS 'Service Name', " + "Service_Fee AS 'Service Fee', " + "Service_Type AS 'Service Type' " + "FROM other_services";

                    if (!string.IsNullOrEmpty(serviceName))
                    {
                        query += " WHERE Service_Name LIKE @name";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    if (!string.IsNullOrEmpty(serviceName))
                    {
                        cmd.Parameters.AddWithValue("@name", "%" + serviceName + "%");
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvService.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btn_updateS_Click(object sender, EventArgs e)
        {
            if (dgvService.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to update this service?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
                return;

            try
            {
                string serviceID = dgvService.CurrentRow.Cells["Service ID"].Value.ToString();
                string serviceName = dgvService.CurrentRow.Cells["Service Name"].Value.ToString();
                string serviceFee = dgvService.CurrentRow.Cells["Service Fee"].Value.ToString();
                string serviceType = dgvService.CurrentRow.Cells["Service Type"].Value.ToString();

                string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
                using (MySqlConnection con = new MySqlConnection(dbconnect))
                {
                    con.Open();

                    string query = "UPDATE other_services SET Service_Name = @name, Service_Fee = @fee, Service_Type = @type WHERE ServiceID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", serviceID);
                        cmd.Parameters.AddWithValue("@name", serviceName);
                        cmd.Parameters.AddWithValue("@fee", serviceFee);
                        cmd.Parameters.AddWithValue("@type", serviceType);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Service updated successfully!", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No changes were made.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }

                Services_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_deleteS_Click(object sender, EventArgs e)
        {
            if (dgvService.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this type of service?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
                return;

            try
            {
                string serviceID = dgvService.CurrentRow.Cells["Service ID"].Value.ToString();

                string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
                using (MySqlConnection con = new MySqlConnection(dbconnect))
                {
                    con.Open();

                    string query = "DELETE FROM other_services WHERE ServiceID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", serviceID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Service deleted successfully!", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No record was deleted. Please try again.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    Services_Load(sender, e);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}