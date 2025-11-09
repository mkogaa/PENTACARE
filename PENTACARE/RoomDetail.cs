using PentaCare;
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
    public partial class RoomDetail : Form
    {
        public RoomDetail(string roomNo, string roomID, string roomType, string roomRate, string bedNo)
        {
            InitializeComponent();
            roomNum.Text = roomNo;
            RoomID.Text = roomID;
            RoomType.Text = roomType;
            RoomRate.Text = roomRate;
            BedNo.Text = bedNo;
        }

        private void RoomDetail_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Patient_Management patient_Management = new Patient_Management();
            patient_Management.Show(); 
            this.Hide();
        }
    }
}
