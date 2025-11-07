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

            string serviceName = txt_serviceName.Text;
            string serviceType = cb_SType.SelectedItem.ToString();
            double serviceFee = double.Parse(txt_Fee.Text);

            string dbconnect = "server=127.0.0.1; database=pentacare; username=root; password=;";
            MySqlConnection sqlconn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcommand = new MySqlCommand();

            try
            {
                sqlconn.Open();

                sqlcommand.CommandText = $"INSERT INTO other_services (Service_Name, Service_Fee, Service_Type) " +
                                 $"VALUES ('{serviceName}', '{serviceFee}', '{serviceType}')";
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
    }
}
