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
    public partial class Billing : Form
    {
        private string patientID;
        private string patientName;
        private string admissionDate;
        private string dischargeDate;
        private string roomNo;
        private string roomID;
        private string roomType;
        private decimal roomFee;
        public Billing(string patientID, string patientName, string admissionDate, string dischargeDate, string roomNo, string roomID, string roomType, decimal roomFee)
        {

            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            this.patientID = patientID;
            this.patientName = patientName;
            this.admissionDate = admissionDate;
            this.dischargeDate = dischargeDate;
            this.roomNo = roomNo;
            this.roomID = roomID;
            this.roomType = roomType;
            this.roomFee = roomFee;


        }

        private void Billing_Load(object sender, EventArgs e)
        {
            lblPID.Text = patientID;
            lblName.Text = patientName;
            lblAD.Text = admissionDate;
            lblDD.Text = dischargeDate;
            lblRN.Text = roomNo;
            lblRID.Text = roomID;
            lblRType.Text = roomType;
            lblRFee.Text = "₱" + roomFee.ToString("N2");
        }
    }
}
