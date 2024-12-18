using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            LoadInsuranceCombo();
            LoadFlightInformation();
        }

        private void EmployerReservation_Load(object sender, EventArgs e)
        {
            LoadFlightInformation();
        }

        private void LoadFlightInformation()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sayed\\OneDrive\\Desktop\\S\\FlightSim-master (4)\\FlightSim-master\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf\";Integrated Security=True;Connect Timeout=30"))
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
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sayed\\OneDrive\\Desktop\\S\\FlightSim-master (4)\\FlightSim-master\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf\";Integrated Security=True;Connect Timeout=30"))
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
            if (string.IsNullOrWhiteSpace(passportTextBox.Text) ||
                seatTypeCombo.SelectedItem == null ||
                string.IsNullOrWhiteSpace(luggageTextBox.Text) ||
                insuranceCombo.SelectedItem == null)
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

            if (!int.TryParse(luggageTextBox.Text, out int extraLuggage))
            {
                MessageBox.Show("Extra luggage must be a valid number.");
                return;
            }

            Traveler traveler = new Traveler
            {
                TravelerID = travelerID,
                PassportNumber = passportTextBox.Text,
                SeatType = seatTypeCombo.SelectedItem.ToString(),
                ExtraLuggage = extraLuggage,
                Insurance = insuranceCombo.SelectedItem.ToString()
            };

            travelerList.Add(traveler);
            UpdateTravelerGrid();
            ClearInputFields();
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
            luggageTextBox.Text = "";
            insuranceCombo.SelectedIndex = 0;
        }

        private void confirmBookingButton_Click(object sender, EventArgs e)
        {
            if (travelerList.Count == 0)
            {
                MessageBox.Show("Please add at least one traveler.");
                return;
            }

            double totalCost = CalculateTotalCost();

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sayed\\OneDrive\\Desktop\\S\\FlightSim-master (4)\\FlightSim-master\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf\";Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();
                    foreach (var traveler in travelerList)
                    {
                        string query = @"
    DECLARE @statusID INT;
    SELECT @statusID = id FROM [dbo].[BookingStatus] WHERE status_name = 'Confirmed';

    IF @statusID IS NOT NULL
    BEGIN
        INSERT INTO [dbo].[Booking] (flight_id, user_id, booking_date, price, booking_status)
        VALUES (@flightID, (SELECT user_id FROM [dbo].[Traveler] WHERE id = @travelerID), @bookingDate, @price, @statusID);
    END
    ELSE
    BEGIN
        RAISERROR('Booking status ''Confirmed'' does not exist.', 16, 1);
    END";


                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@flightID", flightID);
                            cmd.Parameters.AddWithValue("@travelerID", traveler.TravelerID);
                            cmd.Parameters.AddWithValue("@bookingDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@price", totalCost);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Booking confirmed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error confirming booking: " + ex.Message);
            }
        }

        private void generateReceiptButton_Click(object sender, EventArgs e)
        {
            double totalCost = CalculateTotalCost();
            MessageBox.Show($"Total Cost: ${totalCost:F2}", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private double CalculateTotalCost()
        {
            double luggageCostPerKg = 10;
            double insuranceCost = 50;
            double totalCost = 0;

            foreach (var traveler in travelerList)
            {
                double seatPrice = basePrice;
                if (traveler.SeatType == "Business") seatPrice *= 2;
                else if (traveler.SeatType == "First Class") seatPrice *= 3;

                totalCost += seatPrice + (traveler.ExtraLuggage * luggageCostPerKg);
                if (traveler.Insurance == "Yes") totalCost += insuranceCost;
            }

            return totalCost;
        }

        private void flightInfoGrid_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void insuranceCombo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void LoadInsuranceCombo()
        {
            insuranceCombo.Items.Clear();
            insuranceCombo.Items.Add("Yes");
            insuranceCombo.Items.Add("No");
            insuranceCombo.SelectedIndex = 0; // Default selection
        }

        private void luggageTextBox_TextChanged(object sender, EventArgs e) { }

        private void passportTextBox_TextChanged(object sender, EventArgs e) { }

        private void seatTypeCombo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void LoadSeatTypeCombo()
        {
            seatTypeCombo.Items.Clear();
            seatTypeCombo.Items.Add("Economy");
            seatTypeCombo.Items.Add("Business");
            seatTypeCombo.Items.Add("First Class");
            seatTypeCombo.SelectedIndex = 0; // Default selection
        }

        private void travelerDetailGrid_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private class Traveler
        {
            public int TravelerID { get; set; }
            public string PassportNumber { get; set; }
            public string SeatType { get; set; }
            public int ExtraLuggage { get; set; }
            public string Insurance { get; set; }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
