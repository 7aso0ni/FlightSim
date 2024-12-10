using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            // Check if Form1 is already open
            Login form1 = Application.OpenForms.OfType<Login>().FirstOrDefault();
            if (form1 == null)
            {
                form1 = new Login();
                form1.Show();
            }
            else
            {
                form1.BringToFront(); // Bring the existing Form1 to the front
            }

            // after opening the form, close the current form
            this.Close();
        }
    }
}
