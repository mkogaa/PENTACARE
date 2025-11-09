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
    public partial class AddLabService : Form
    {
        public AddLabService()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

        }

        private void btn_backS_Click(object sender, EventArgs e)
        {
            Laboratory laboratory = new Laboratory();
            laboratory.Show();
            this.Hide();
        }

        private void btn_saveLab_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_LabName.Text))
            {
                MessageBox.Show("Please enter the lab name.");
                return;
            }

            if (txt_LabName.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Service name cannot contain numbers.");
                return;
            }

            if (string.IsNullOrEmpty(txt_Description.Text))
            {
                MessageBox.Show("Please enter the description of the lab.");
                return;
            }

            if (string.IsNullOrEmpty(txt_Fee.Text))
            {
                MessageBox.Show("Please enter the lab fee.");
                return;
            }

            if (txt_Fee.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Lab fee cannot contain letters.");
                return;
            }

            if (cbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the service type.");
                return;
            }

            if (string.IsNullOrEmpty(txt_ETime.Text))
            {
                MessageBox.Show("Please enter the estimated time.");
                return;
            }

            if (cbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the status.");
                return;
            }

            string serviceName = txt_LabName.Text;
            string serviceDescription = txt_Description.Text;
            string serviceType = cbCategory.SelectedItem.ToString();
            double serviceFee = double.Parse(txt_Fee.Text);
            string serviceTime = txt_ETime.Text;
            string serviceStatus = cbStatus.SelectedItem.ToString();

            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            MySqlConnection sqlconn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcommand = new MySqlCommand();

            try
            {
                sqlconn.Open();

                string checkQuery = "SELECT COUNT(*) FROM lab_services WHERE LOWER(Lab_Name) = LOWER(@serviceName)";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, sqlconn))
                {
                    checkCmd.Parameters.AddWithValue("@serviceName", serviceName);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("This service already exists!", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                sqlcommand.CommandText = $"INSERT INTO lab_services (Lab_Name, Lab_Description, Lab_Fee, Lab_Category, Estimated_Time, Status) " +
                                 $"VALUES ('{serviceName}', '{serviceDescription}', '{serviceFee}', '{serviceType}', '{serviceTime}', '{serviceStatus}')";
                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconn;

                sqlcommand.ExecuteNonQuery();

                MessageBox.Show("Laboratory Service added successfully!");
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

        private void btn_saveLab_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_LabName.Clear();
            txt_Description.Clear();
            txt_Fee.Clear();
            txt_ETime.Clear();
            cbCategory.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
        }
    }
}
