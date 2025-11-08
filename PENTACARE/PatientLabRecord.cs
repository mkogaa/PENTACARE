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

namespace PentaCare
{
    public partial class PatientLabRecord : Form
    {
        private string patientID;
        private string patientName;
        private string doctorName;
        private string roomNo;


        public PatientLabRecord(string id, string name, string dname, string room)
        {
            InitializeComponent();
            patientID = id;
            patientName = name;
            doctorName = dname;
            roomNo = room;

            this.WindowState = FormWindowState.Maximized;



            //dataGridView1.Size = new Size(1463, 351);
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.ScrollBars = ScrollBars.Both; // optional: adds scroll if needed




            //string dbconnect = "server= 127.0.0.1; database=ccp; uid=root; ";
            //MySqlConnection conn = new MySqlConnection(dbconnect);
            //MySqlCommand sqlcmd = new MySqlCommand();

            //MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            //DataSet sqlDS = new DataSet();


            //// Step 2: Establish SQL Connection
            //conn.Open();


            //// Step 3: Request Query

            //sqlcmd.CommandText = $"SELECT * FROM patient";


            //sqlcmd.CommandType = CommandType.Text;
            //sqlcmd.Connection = conn;

            //// Step 4: Execute SQL Command

            //sqlDA.SelectCommand = sqlcmd;

            //sqlDA.Fill(sqlDS, "recordsfetch");
            //dataGridView1.DataSource = sqlDS;
            //dataGridView1.DataMember = "recordsfetch";


        }

        private void PatientLabRecord_Load(object sender, EventArgs e)
        {
            pName.Text = patientName;
            doc.Text = doctorName;
            room.Text = roomNo;
            //nagkakabaliktad hindi k alam bakit 
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Management form = new Patient_Management();
            form.Show();
        }

        



        

        private void viewbtn_Click(object sender, EventArgs e)
        {
            View view = new View(patientID, patientName, doctorName, roomNo);
            view.Show();
            this.Hide();
        }
    }
}
