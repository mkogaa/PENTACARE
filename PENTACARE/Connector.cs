using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PENTACARE
{
    internal class Connector
    {
        public static void OpenForm(Form currentForm, Form nextForm)
        {
            nextForm.Show();
            currentForm.Hide();
        }
    }
}
