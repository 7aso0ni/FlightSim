using System;
using System.Windows.Forms;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class TravelerServices : Form
    {
        public TravelerServices()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isBookingEnabled = Traveler.IsBookingEnabled;

            if (isBookingEnabled)
            {
                Traveler.IsBookingEnabled = false;
                MessageBox.Show("Booking Service Disabled");
                bookingService.Text = "Enable Booking";
            }
            else
            {
                Traveler.IsBookingEnabled = true;
                MessageBox.Show("Booking Service Enabled");
                bookingService.Text = "Disable Booking";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isPaymentEnabled = Traveler.IsPaymentEnabled;

            if (isPaymentEnabled)
            {
                Traveler.IsPaymentEnabled = false;
                MessageBox.Show("Payment Service Disabled");
                paymentService.Text = "Enable Payment";
            }
            else
            {
                Traveler.IsPaymentEnabled = true;
                MessageBox.Show("Payment Service Enabled");
                paymentService.Text = "Disable Payment";
            }
        }

        private void TravelerServices_Load(object sender, EventArgs e)
        {
            bool isPaymentEnabled = Traveler.IsPaymentEnabled;
            bool isBookingEnabled = Traveler.IsBookingEnabled;

            if (isBookingEnabled)
            {
                bookingService.Text = "Disable Booking";
            }
            else
            {
                bookingService.Text = "Enable Booking";
            }

            if (isPaymentEnabled)
            {
                paymentService.Text = "Disable Payment";
            }
            else
            {
                paymentService.Text = "Enable Payment";
            }
        }
    }
}
