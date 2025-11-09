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
    public partial class AddService : Form
    {
        public AddService()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

        }

        private void btn_backSS_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            services.Show();
            this.Hide();
        }

        private void btn_backSS_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_saveService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_serviceName.Text))
            {
                MessageBox.Show("Please enter the service name.");
                return;
            }

            if (txt_serviceName.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Service name cannot contain numbers.");
                return;
            }

            if (string.IsNullOrEmpty(txt_Fee.Text))
            {
                MessageBox.Show("Please enter the service fee.");
                return;
            }

            if (txt_Fee.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Service fee cannot contain letters.");
                return;
            }

            if (cb_SType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the service type.");
                return;
            }

            if (cbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the status.");
                return;
            }

            string serviceName = txt_serviceName.Text;
            string serviceType = cb_SType.SelectedItem.ToString();
            double serviceFee = double.Parse(txt_Fee.Text);
            string serviceStatus = cbStatus.SelectedItem.ToString();

            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            MySqlConnection sqlconn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcommand = new MySqlCommand();

            try
            {
                sqlconn.Open();

                string checkQuery = "SELECT COUNT(*) FROM other_services WHERE LOWER(Service_Name) = LOWER(@serviceName)";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, sqlconn))
                {
                    checkCmd.Parameters.AddWithValue("@serviceName", serviceName);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("This service already exists!.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                sqlcommand.CommandText = $"INSERT INTO other_services (Service_Name, Service_Fee, Service_Type, Status) " +
                                 $"VALUES ('{serviceName}', '{serviceFee}', '{serviceType}', '{serviceStatus}')";
                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconn;

                sqlcommand.ExecuteNonQuery();

                MessageBox.Show("Service added successfully!");
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

        private void btn_saveService_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_serviceName.Clear();
            txt_Fee.Clear();
            cb_SType.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
        }
    }
}
