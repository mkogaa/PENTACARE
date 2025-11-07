

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
    public partial class BillingMain : Form
    {
        public BillingMain()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_labfee_Click(object sender, EventArgs e)
        {
            Laboratory laboratory = new Laboratory();
            laboratory.Show();
            this.Hide();
        }

        private void btn_servicefee_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            services.Show();
            this.Hide();
        }

        private void btn_backB_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
