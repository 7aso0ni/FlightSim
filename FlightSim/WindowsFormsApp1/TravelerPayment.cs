using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.api;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class TravelerPayment : Form
    {

        double flightPrice;
        public TravelerPayment(double flightPrice)
        {
            InitializeComponent();
            this.flightPrice = flightPrice;
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

            textBox7.Text = flightPrice.ToString() + "$";

            loadAddons();
            LoadCardDetails();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void loadAddons()
        {
            try
            {
                // Clear existing checkboxes (if any)
                AddonList.Controls.Clear();

                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gaming\\Desktop\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM [dbo].[Addons]";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CheckBox checkBox = new CheckBox();
                        checkBox.Text = $"{reader["name"].ToString()} - ${reader["price"]}";

                        // storing the price for easy access later
                        checkBox.Tag = reader["price"];
                        checkBox.AutoSize = true;

                        // Subscribe to the CheckedChanged event
                        checkBox.CheckedChanged += AddonCheckBox_CheckedChanged;

                        AddonList.Controls.Add(checkBox);


                    }
                }
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void LoadCardDetails()
        {
            try
            {
                // get the traveler data
                Traveler travelerInfo = Traveler.TravelerInstance;

                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gaming\\Desktop\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT * FROM [dbo].[Traveler_Payment] WHERE traveler_id = @travelerId";
                cmd.Parameters.AddWithValue("@travelerId", travelerInfo.TravelerId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // if data is found
                    if (reader.Read())
                    {
                        string cardNumber = reader["card_number"].ToString();
                        string expiryDate = Convert.ToDateTime(reader["expiration_date"]).ToShortDateString();
                        string cvv = reader["cvv"].ToString();

                        cardNumberTextBox.Text = cardNumber;
                        expiryDateTextBox.Text = expiryDate;
                        cvvTextBox.Text = cvv;
                    }
                }
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void AddonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            double totalAddonsPrice = 0;

            // Loop through all the checkboxes to calculate the total add-on price
            foreach (Control control in AddonList.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    // Retrieve the price from the Tag property and add to the total
                    totalAddonsPrice += Convert.ToDouble(checkBox.Tag);
                }
            }

            // Update the total price textbox
            double totalPrice = flightPrice + totalAddonsPrice;
            textBox7.Text = $"{totalPrice}$";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaymentAPI api = new PaymentAPI();
            string cardNumber = cardNumberTextBox.Text;
            string expiryDate = expiryDateTextBox.Text;
            string cvv = cvvTextBox.Text;
            bool isSucccess = api.ProcessPayment(cardNumber, expiryDate, cvv, flightPrice);

            if (isSucccess)
            {
                MessageBox.Show("Payment successful");

                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gaming\\Desktop\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30");

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = @"
            INSERT INTO [dbo].[Booking] (flight_id, user_id, booking_date, price, booking_status)
            VALUES (@flightId, @userId, @bookingDate, @price, @bookingStatus)";

                conn.Close();
            }

        }
    }
}
