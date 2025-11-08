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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PentaCare
{
    public partial class AddPatient : Form
    {
        public AddPatient()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

        }

        private void AddPatient_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = pName.Text;
            string Age = pAge.Text;
            string Gender = pGender.Text;
            string Address = pAddress.Text;
            string contact = pCon.Text;
            string AdDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string Status = pStatus.Text;


            // Validations //

            bool isValidName = true;

            foreach (char c in pName.Text)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    isValidName = false;
                    break;
                }
            }

            if (!isValidName)
            {
                MessageBox.Show("Name must contain letters only!",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (!int.TryParse(pAge.Text, out int age))
            {
                MessageBox.Show("Age must be numbers only!.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(pCon.Text, out long phoneNumber) || pCon.Text.Length != 11)
            {
                MessageBox.Show("Phone number must be exactly 11 digits and contain numbers only.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



           




            string dbconnect = "server= 127.0.0.1; database=pentacare; uid=root; ";
            MySqlConnection conn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcmd = new MySqlCommand();



            conn.Open();


            sqlcmd.CommandText = $"INSERT INTO patient (Name, Age, Gender, Address, Contact_No, Admission_Date, Status) " +
                       $"VALUES ('{name}', '{Age}', '{Gender}', '{Address}', '{contact}', '{AdDate}','{Status}') ";


            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = conn;


            sqlcmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Record is save into database");
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Patient_Management form1 = new Patient_Management();
            form1.Show();
            this.Hide();
        }
    }
}
