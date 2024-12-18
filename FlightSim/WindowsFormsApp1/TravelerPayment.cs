using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.api;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class TravelerPayment : Form
    {

        double flightPrice;
        int flightID;

        List<int> selectedAddons = new List<int>();

        public TravelerPayment(double flightPrice, int flightId)
        {
            InitializeComponent();
            this.flightPrice = flightPrice;
            this.flightID = flightId;
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

                        // Storing the addonId and price for easy access later
                        checkBox.Tag =
                            Convert.ToDouble(reader["price"]);
                        selectedAddons.Add(Convert.ToInt32(reader["id"]));


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

            bool isSuccess = api.ProcessPayment(cardNumber, expiryDate, cvv, flightPrice);

            if (isSuccess)
            {
                try
                {
                    int bookingId;

                    // Connect to the database
                    using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gaming\\Desktop\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        conn.Open();

                        // Insert into the Booking table and retrieve the Booking ID
                        using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO [dbo].[Booking] (flight_id, user_id, booking_date, price, booking_status)
                    VALUES (@flightId, @userId, @bookingDate, @price, @bookingStatus); 
                    SELECT SCOPE_IDENTITY();", conn))
                        {
                            cmd.Parameters.AddWithValue("@flightId", flightID);
                            cmd.Parameters.AddWithValue("@userId", Traveler.TravelerInstance.UserId);
                            cmd.Parameters.AddWithValue("@bookingDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@price", flightPrice);
                            cmd.Parameters.AddWithValue("@bookingStatus", 1);

                            bookingId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Insert into the Booking_Addon table for each selected addon
                        using (SqlCommand addonCmd = new SqlCommand(@"
                    INSERT INTO [dbo].[Booking_Addon] (booking_id, addon_id)
                    VALUES (@bookingId, @addonId)", conn))
                        {
                            // Add parameters once and update their values for each addon
                            addonCmd.Parameters.Add("@bookingId", System.Data.SqlDbType.Int);
                            addonCmd.Parameters.Add("@addonId", System.Data.SqlDbType.Int);

                            foreach (int addonId in selectedAddons)
                            {
                                addonCmd.Parameters["@bookingId"].Value = bookingId;
                                addonCmd.Parameters["@addonId"].Value = addonId;
                                addonCmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Flight booked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Payment failed. Please check your card details and try again.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
