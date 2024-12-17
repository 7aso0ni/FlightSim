using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class TravelerPayment : Form
    {
        public TravelerPayment()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TravelerPayment_Load(object sender, EventArgs e)
        {
            // get the user info that is saved
            Traveler travelerInfo = Traveler.TravelerInstance;

            nameField.Text = travelerInfo.Name;
            passpotField.Text = travelerInfo.PassportNumber.ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
