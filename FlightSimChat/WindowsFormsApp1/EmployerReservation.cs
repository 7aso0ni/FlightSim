using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp1
{
    public partial class EmployerReservation : Form
    {

        private int flightID;
        private double basePrice = 0;
        private List<Traveler> travelerList = new List<Traveler>();

        public EmployerReservation(int selectedFlightID)
        {
            InitializeComponent();
            flightID = selectedFlightID;
            LoadSeatTypeCombo();
            LoadFlightInformation();
        }
        

        private void EmployerReservation_Load(object sender, EventArgs e)
        {
            LoadFlightInformation();

        }
        private void LoadSeatTypeCombo()
        {
            seatTypeCombo.Items.Clear(); // Clear any existing items
            seatTypeCombo.Items.Add("Economy");
            seatTypeCombo.Items.Add("Business");
            seatTypeCombo.Items.Add("First Class");
            seatTypeCombo.SelectedIndex = 0; // Set the default selection
        }
        private void LoadFlightInformation()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(MyString.ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT f.id AS FlightID, depCity.name AS Departure, arrCity.name AS Destination, 
                                            f.departure_time AS DepartureTime, f.arrival_time AS ArrivalTime, f.base_price AS BasePrice
                                     FROM [dbo].[Flight] f
                                     INNER JOIN [dbo].[City] depCity ON f.departure_location = depCity.id
                                     INNER JOIN [dbo].[City] arrCity ON f.arrival_location = arrCity.id
                                     WHERE f.id = @flightID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@flightID", flightID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                DataTable flightInfo = new DataTable();
                                flightInfo.Load(reader);
                                basePrice = Convert.ToDouble(flightInfo.Rows[0]["BasePrice"]);
                                flightInfoGrid.DataSource = flightInfo;
                            }
                            else
                            {
                                MessageBox.Show("No flight details found for the selected flight.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading flight information: " + ex.Message);
            }
        }

        private int GetTravelerID(string passportNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(MyString.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT id FROM [dbo].[Traveler] WHERE passport_number = @passportNumber";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@passportNumber", passportNumber);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching traveler ID: " + ex.Message);
            }
            return -1;
        }

        private void addTravelerButton_Click(object sender, EventArgs e)
        {
            
        }

        private void UpdateTravelerGrid()
        {
            travelerDetailGrid.DataSource = null;
            travelerDetailGrid.DataSource = travelerList;
        }

        private void ClearInputFields()
        {
            passportTextBox.Text = "";
            seatTypeCombo.SelectedIndex = 0;
            insuranceaddOn.Checked = false;
            priorityaddOn.Checked = false;
            baggageaddOn.Checked = false;
            mealsaddOn.Checked = false;
            selectionaddOn.Checked = false;
        }

        private void confirmBookingButton_Click(object sender, EventArgs e)
        {
            
        }

        private void generateReceiptButton_Click(object sender, EventArgs e)
        {
            
        }

        private double CalculateTotalCost()
        {
            double totalCost = 0;

            foreach (var traveler in travelerList)
            {
                double seatPrice = basePrice;
                if (traveler.SeatType == "Business") seatPrice *= 2;
                else if (traveler.SeatType == "First Class") seatPrice *= 3;

                totalCost += seatPrice + traveler.AddOnsCost;
            }

            return totalCost;
        }

        
        

        

        

        private void seatTypeCombo_SelectedIndexChanged(object sender, EventArgs e) {
            string selectedSeatType = seatTypeCombo.SelectedItem.ToString();

            // Show or hide the "Seat Selection" checkbox based on the seat type
            if (selectedSeatType == "Economy")
            {
                selectionaddOn.Visible = true; // Show the checkbox for seat selection
            }
            else
            {
                selectionaddOn.Visible = false; // Hide the checkbox for seat selection
                selectionaddOn.Checked = false; // Uncheck it if hidden
            }
        }

        
        private class Traveler
        {
            public int TravelerID { get; set; }
            public string PassportNumber { get; set; }
            public string SeatType { get; set; }
            public string Insurance { get; set; } 
            public string PriorityBoarding { get; set; } 
            public string ExtraBaggage { get; set; } 
            public string Meals { get; set; } 
            public string SeatSelection { get; set; } 
            public double AddOnsCost { get; set; } 
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSeatType = seatTypeCombo.SelectedItem.ToString();

            // Show the Traveler Insurance add-on checkbox only for "Economy"
            if (selectedSeatType == "Economy")
            {
                selectionaddOn.Visible = true;
            }
            else
            {
                selectionaddOn.Visible = false;
                selectionaddOn.Checked = false; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passportTextBox.Text) ||
        seatTypeCombo.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int travelerID = GetTravelerID(passportTextBox.Text);
            if (travelerID == -1)
            {
                MessageBox.Show("Passport number not found in the database.");
                return;
            }

            // Calculate add-on costs
            double insuranceCost = insuranceaddOn.Checked ? 20 : 0;
            double priorityCost = priorityaddOn.Checked ? 15 : 0;
            double baggageCost = baggageaddOn.Checked ? 50 : 0;
            double mealsCost = mealsaddOn.Checked ? 25 : 0;
            double seatSelectionCost = selectionaddOn.Checked ? 10 : 0;

            double totalAddOnsCost = insuranceCost + priorityCost + baggageCost + mealsCost + seatSelectionCost;

            Traveler traveler = new Traveler
            {
                TravelerID = travelerID,
                PassportNumber = passportTextBox.Text,
                SeatType = seatTypeCombo.SelectedItem.ToString(),
                Insurance = insuranceaddOn.Checked ? "Yes" : "No",
                PriorityBoarding = priorityaddOn.Checked ? "Yes" : "No",
                ExtraBaggage = baggageaddOn.Checked ? "Yes" : "No",
                Meals = mealsaddOn.Checked ? "Yes" : "No",
                SeatSelection = selectionaddOn.Checked ? "Yes" : "No",
                AddOnsCost = totalAddOnsCost
            };

            travelerList.Add(traveler);
            UpdateTravelerGrid();
            ClearInputFields();
        }

        private void confirmBookingButton_Click_1(object sender, EventArgs e)
        {
            if (travelerList.Count == 0)
            {
                MessageBox.Show("Please add at least one traveler.");
                return;
            }

            double totalCost = CalculateTotalCost();

            try
            {
                using (SqlConnection conn = new SqlConnection(MyString.ConnectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction(); // Begin transaction

                    try
                    {
                        foreach (var traveler in travelerList)
                        {
                            int bookingId;

                            // Insert into the Booking table and retrieve the Booking ID
                            using (SqlCommand cmd = new SqlCommand(@"
INSERT INTO [dbo].[Booking] (flight_id, user_id, booking_date, price, booking_status)
VALUES (@flightId, @userId, @bookingDate, @price, @bookingStatus);
SELECT SCOPE_IDENTITY();", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@flightId", flightID);
                                cmd.Parameters.AddWithValue("@userId", traveler.TravelerID);
                                cmd.Parameters.AddWithValue("@bookingDate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@price", totalCost);
                                cmd.Parameters.AddWithValue("@bookingStatus", 1); // Assuming 1 is the ID for "Confirmed"

                                bookingId = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // Insert add-ons for this traveler
                            InsertAddOns(conn, transaction, bookingId, traveler);
                        }

                        transaction.Commit(); // Commit transaction
                        MessageBox.Show("Booking confirmed successfully!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Rollback on error
                        MessageBox.Show("Error confirming booking: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
        }

        private void InsertAddOns(SqlConnection conn, SqlTransaction transaction, int bookingId, Traveler traveler)
        {
            using (SqlCommand addonCmd = new SqlCommand(@"
INSERT INTO [dbo].[Booking_Addon] (booking_id, addon_id)
VALUES (@bookingId, @addonId);", conn, transaction))
            {
                addonCmd.Parameters.Add("@bookingId", System.Data.SqlDbType.Int);
                addonCmd.Parameters.Add("@addonId", System.Data.SqlDbType.Int);

                // Map traveler add-ons to IDs in the Addons table
                if (traveler.Insurance == "Yes")
                {
                    addonCmd.Parameters["@bookingId"].Value = bookingId;
                    addonCmd.Parameters["@addonId"].Value = 1; // Insurance ID
                    addonCmd.ExecuteNonQuery();
                }
                if (traveler.PriorityBoarding == "Yes")
                {
                    addonCmd.Parameters["@bookingId"].Value = bookingId;
                    addonCmd.Parameters["@addonId"].Value = 2; // Priority Boarding ID
                    addonCmd.ExecuteNonQuery();
                }
                if (traveler.ExtraBaggage == "Yes")
                {
                    addonCmd.Parameters["@bookingId"].Value = bookingId;
                    addonCmd.Parameters["@addonId"].Value = 3; // Extra Baggage ID
                    addonCmd.ExecuteNonQuery();
                }
                if (traveler.Meals == "Yes")
                {
                    addonCmd.Parameters["@bookingId"].Value = bookingId;
                    addonCmd.Parameters["@addonId"].Value = 4; // Meals ID
                    addonCmd.ExecuteNonQuery();
                }
                if (traveler.SeatSelection == "Yes")
                {
                    addonCmd.Parameters["@bookingId"].Value = bookingId;
                    addonCmd.Parameters["@addonId"].Value = 5; // Seat Selection ID
                    addonCmd.ExecuteNonQuery();
                }
            }
        }


        private void generateReceiptButton_Click_1(object sender, EventArgs e)
        {
            double totalCost = CalculateTotalCost();
            MessageBox.Show($"Total Cost: ${totalCost:F2}", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void priorityaddOn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void baggageaddOn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mealsaddOn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void selectionaddOn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
