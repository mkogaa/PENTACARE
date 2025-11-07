using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PentaCare
{
    public partial class AddDoctors : Form
    {
        public AddDoctors()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string name = docName.Text;
            string specialty = docSpecialty.Text;
            string contact = docContact.Text;
            string email = docEmail.Text;



            string dbconnect = "server= 127.0.0.1; database=pentacare; uid=root; ";
            MySqlConnection conn = new MySqlConnection(dbconnect);
            MySqlCommand sqlcmd = new MySqlCommand();



            conn.Open();


            sqlcmd.CommandText = $"INSERT INTO doctor (Doctor_Name, Specialty, Contact_No, Email) " +
                       $"VALUES ('{name}', '{specialty}', '{contact}', '{email}') ";


            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = conn;


            sqlcmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("New Doctor Record has been added!");

            DoctorandRecords doctorandRecords = new DoctorandRecords();
            doctorandRecords.Show();
            this.Hide();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            DoctorandRecords doctorandRecords = new DoctorandRecords();
            doctorandRecords.Show();
            this.Hide();
        }
    }
}
