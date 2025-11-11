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
    public partial class Add_Charge : Form
    {
        private string patientID;
        private DataTable billingTable;

        public Add_Charge(string patientID, DataTable billingTable)
        {
            InitializeComponent();

            this.patientID = patientID;
            this.billingTable = billingTable;
        }

        private void Add_Charge_Load(object sender, EventArgs e)
        {
            if (cbCType.Items.Count > 0)
            {
                cbCType.SelectedIndex = 0; // select first type by default
            }
        }

        private void btn_Add_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (cbService.SelectedItem == null)
            {
                MessageBox.Show("Please select a service.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtQD.Text, out decimal quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity or number of days.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string type = cbCType.SelectedItem.ToString();
            string serviceName = cbService.SelectedItem.ToString();
            int index = serviceName.LastIndexOf("₱");
            decimal amount = 0;

            if (index >= 0)
            {
                // Get the unit amount
                amount = decimal.Parse(serviceName.Substring(index + 1));
                // Clean up the name
                serviceName = serviceName.Substring(0, index).Trim();
            }

            decimal totalAmount = amount * quantity;

            // Add to billing table with quantity in description
            billingTable.Rows.Add(type, $"{serviceName} ({quantity} {(quantity > 1 ? "days" : "day")})", totalAmount);

            MessageBox.Show("Charge added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void cbCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = cbCType.SelectedItem.ToString();
            LoadServices(selectedType);

            if (cbService.Items.Count > 0)
            {
                cbService.SelectedIndex = 0; // triggers cbService_SelectedIndexChanged
            }
            else
            {
                txtAmount.Text = "0.00";
            }
        }

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAmount();
        }

        private void LoadServices(string type)
        {
            cbService.Items.Clear();

            try
            {
                if (type == "Other Services")
                {
                    // Only show these specific services
                    List<string> allowedServices = new List<string>
            {
                "Laundry Service",
                "Television Rental",
                "Personal Care Kit",
                "Extra Bed",
                "Parking Fee"
            };

                    string connString = "server=127.0.0.1; database=pentacare; uid=root;";
                    using (MySqlConnection conn = new MySqlConnection(connString))
                    {
                        conn.Open();
                        string sql = "SELECT Service_Name, Service_Fee FROM other_services WHERE Status = 'Available'";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string name = reader[0].ToString();
                            decimal fee = Convert.ToDecimal(reader[1]);

                            if (allowedServices.Contains(name))
                            {
                                cbService.Items.Add($"{name} - ₱{fee}");
                            }
                        }

                        reader.Close();
                    }
                }
                else
                {
                    // Existing code for Medicine or Laboratory
                    string connString = "server=127.0.0.1; database=pentacare; uid=root;";
                    using (MySqlConnection conn = new MySqlConnection(connString))
                    {
                        conn.Open();
                        string sql = "";

                        if (type == "Medicine")
                            sql = "SELECT Medicine_Name, Price FROM medicines WHERE Stock > 0";
                        else if (type == "Laboratory")
                            sql = "SELECT Lab_Name, Lab_Fee FROM lab_services WHERE Status = 'Available'";

                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string name = reader[0].ToString();
                            decimal fee = Convert.ToDecimal(reader[1]);

                            if (type == "Medicine")
                                cbService.Items.Add($"{name} (Medicine) - ₱{fee}");
                            else if (type == "Laboratory")
                                cbService.Items.Add($"{name} (Lab) - ₱{fee}");
                        }

                        reader.Close();
                    }
                }

                if (cbService.Items.Count > 0)
                    cbService.SelectedIndex = 0;
                else
                    txtAmount.Text = "0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading services: " + ex.Message);
            }
        }


        private void ShowAmount()
        {
            if (cbService.SelectedItem == null)
            {
                txtAmount.Text = "0.00";
                return;
            }

            try
            {
                string selected = cbService.SelectedItem.ToString();
                int index = selected.LastIndexOf("₱");
                if (index >= 0)
                {
                    decimal price = decimal.Parse(selected.Substring(index + 1));
                    if (decimal.TryParse(txtQD.Text, out decimal quantity))
                        price *= quantity;

                    txtAmount.Text = price.ToString("0.00");
                }
            }
            catch
            {
                txtAmount.Text = "0.00";
            }
        }

    }
}
