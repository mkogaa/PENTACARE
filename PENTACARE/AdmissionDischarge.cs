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
    public partial class AdmissionDischarge : Form
    {
        public AdmissionDischarge()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Patient_Management form1 = new Patient_Management();
            form1.Show();
            this.Hide();
        }
    }
}
