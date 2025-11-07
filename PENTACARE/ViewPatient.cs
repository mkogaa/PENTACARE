using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PentaCare
{
    public partial class ViewPatient : Form
    {
        private string patientName;
        private string doctorName;

        public ViewPatient(string name, string dName)
        {
            InitializeComponent();
            patientName = name;
            doctorName = dName;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            DoctorandRecords doctorandRecords = new DoctorandRecords();
            doctorandRecords.Show();
            this.Hide();
        }

        private void ViewPatient_Load(object sender, EventArgs e)
        {
            pName.Text = patientName;
            pDoc.Text = doctorName;
        }
    }
}
