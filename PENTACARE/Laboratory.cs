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
    public partial class Laboratory : Form
    {
        public Laboratory()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

        }

        private void Laboratory_Load(object sender, EventArgs e)
        {
            dgvLaboratory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLaboratory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvLaboratory.AllowUserToAddRows = false;
            dgvLaboratory.RowHeadersVisible = false;

            dgvLaboratory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvLaboratory.EnableHeadersVisualStyles = false;
            dgvLaboratory.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dgvLaboratory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLaboratory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection sqlconn = new MySqlConnection(dbconnect))
            {
                string query = "SELECT LabID as 'Laboratory ID', " +
                                "Lab_Name as 'Laboratory Name', " +
                                "Lab_Description as 'Laboratory Description', " +
                                "Lab_Fee as 'Laboratory Fee', " +
                                "Lab_Category as 'Category', " +
                                "Estimated_Time as 'Laboratory Time' " +
                                "FROM lab_services";

                MySqlCommand cmd = new MySqlCommand(query, sqlconn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    sqlconn.Open();
                    adapter.Fill(dt);

                    dgvLaboratory.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading records: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_addLab_Click(object sender, EventArgs e)
        {
            AddLabService addLabService = new AddLabService();
            addLabService.Show();
            this.Hide();
        }

        private void btn_backL_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btn_backL_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string labName = txtSearch.Text.Trim();

            string dbconnection = "server=127.0.0.1; database=pentacare; username=root; password=;";
            using (MySqlConnection con = new MySqlConnection(dbconnection))
            {
                try
                {
                    con.Open();

                    string query = "SELECT LabID AS 'Laboratory ID', " + "Lab_Name AS 'Laboratory Name', " + "Lab_Description AS 'Laboratory Description', " + "Lab_Fee AS 'Laboratory Fee', " + "Lab_Category AS 'Category', " + "Estimated_Time AS 'Laboratory Time' " + "FROM lab_services";

                    if (!string.IsNullOrEmpty(labName))
                    {
                        query += " WHERE Lab_Name LIKE @name";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    if (!string.IsNullOrEmpty(labName))
                    {
                        cmd.Parameters.AddWithValue("@name", "%" + labName + "%");
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvLaboratory.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btn_updateL_Click(object sender, EventArgs e)
        {
            if (dgvLaboratory.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to update this service?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
                return;

            try
            {
                string labID = dgvLaboratory.CurrentRow.Cells["Laboratory ID"].Value.ToString();
                string labName = dgvLaboratory.CurrentRow.Cells["Laboratory Name"].Value.ToString();
                string labDescription = dgvLaboratory.CurrentRow.Cells["Laboratory Description"].Value.ToString();
                string labFee = dgvLaboratory.CurrentRow.Cells["Laboratory Fee"].Value.ToString();
                string labCategory = dgvLaboratory.CurrentRow.Cells["Category"].Value.ToString();
                string labTime = dgvLaboratory.CurrentRow.Cells["Laboratory Time"].Value.ToString();

                string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
                using (MySqlConnection con = new MySqlConnection(dbconnect))
                {
                    con.Open();

                    string query = "UPDATE lab_services SET Lab_Name = @name, Lab_Description = @description, Lab_Fee = @fee, Lab_Category = @category, Estimated_Time = @time WHERE LabID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", labID);
                        cmd.Parameters.AddWithValue("@name", labName);
                        cmd.Parameters.AddWithValue("@description", labDescription);
                        cmd.Parameters.AddWithValue("@fee", labFee);
                        cmd.Parameters.AddWithValue("@category", labCategory);
                        cmd.Parameters.AddWithValue("@time", labTime);

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

                    Laboratory_Load(sender, e);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_updateL_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_deleteL_Click(object sender, EventArgs e)
        {

            if (dgvLaboratory.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this laboratory service?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
                return;

            try
            {
                string labID = dgvLaboratory.CurrentRow.Cells["Laboratory ID"].Value.ToString();

                string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
                using (MySqlConnection con = new MySqlConnection(dbconnect))
                {
                    con.Open();

                    string query = "DELETE FROM lab_services WHERE LabID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", labID);

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

                    Laboratory_Load(sender, e);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}