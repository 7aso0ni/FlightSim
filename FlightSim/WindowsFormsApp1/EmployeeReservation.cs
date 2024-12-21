using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class EmployeeReservation : Form
    {

        private int flightID;
        private double basePrice = 0;
        double totalPrice = 0;
        private List<Traveler> travelerList = new List<Traveler>();
        private string sqlConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gaming\\Desktop\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30";
        List<int> selectedAddons = new List<int>();

        public EmployeeReservation(int selectedFlightID, double flightPrice)
        {
            InitializeComponent();
            flightID = selectedFlightID;
            basePrice = flightPrice;
            LoadSeatTypeCombo();
            LoadFlightInformation();
        }


        private void EmployerReservation_Load(object sender, EventArgs e)
        {
            LoadFlightInformation();
            loadAddons();

        }
        private void LoadSeatTypeCombo()
        {

        }
        private void LoadFlightInformation()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnection))
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

        private void loadAddons()
        {
            try
            {
                // Clear existing checkboxes (if any)
                AddonList.Controls.Clear();

                SqlConnection conn = new SqlConnection(sqlConnection);
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

            // get the total price and save it for later use
            totalPrice = basePrice + totalAddonsPrice;
        }

        private int GetTravelerID(string passportNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnection))
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
            travelerDetailGrid.DataSource = travelerList;
        }


        private void confirmBookingButton_Click(object sender, EventArgs e)
        {

        }

        private void generateReceiptButton_Click(object sender, EventArgs e)
        {

        }

        //private double CalculateTotalCost()
        //{
        //    double totalCost = 0;

        //    foreach (var traveler in travelerList)
        //    {
        //        totalCost += traveler.AddOnsCost;
        //    }

        //    // get the total cost of the flight including all addons if any
        //    return totalCost + basePrice;
        //}


        private void seatTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Traveler traveler = null;

            if (string.IsNullOrWhiteSpace(passportTextBox.Text))
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

            try
            {
                // Connect to the database to get traveler details
                using (SqlConnection conn = new SqlConnection(sqlConnection))
                {
                    conn.Open();

                    // Query to fetch traveler information by ID
                    // Query to fetch traveler and user details by travelerID
                    string query = @"
                SELECT 
                    t.id AS TravelerId,
                    t.name AS TravelerName,
                    t.passport_number AS PassportNumber,
                    t.age AS Age,
                    u.username AS Username,
                    u.password AS Password,
                    u.email AS Email,
                    u.role AS Role
                FROM 
                    [dbo].[Traveler] t
                INNER JOIN 
                    [dbo].[User] u ON t.user_id = u.id
                WHERE 
                    t.id = @travelerID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@travelerID", travelerID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Create a new Traveler object and populate it with the retrieved data
                                traveler = new Traveler(
                            Convert.ToInt32(reader["TravelerId"]),  // travelerId
                            reader["Username"].ToString(),         // username
                            reader["Password"].ToString(),         // password
                            reader["Email"].ToString(),            // email
                            reader["Role"].ToString(),             // role
                            reader["TravelerName"].ToString(),     // name
                            Convert.ToInt32(reader["PassportNumber"]), // passportNumber
                            Convert.ToInt32(reader["Age"])         // age
                        );

                                Traveler.TravelerInstance = traveler;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching traveler information: " + ex.Message);
            }

            travelerList.Add(Traveler.TravelerInstance);
            UpdateTravelerGrid();
        }

        private void confirmBookingButton_Click_1(object sender, EventArgs e)
        {
            if (travelerList.Count == 0)
            {
                MessageBox.Show("Please add at least one traveler.");
                return;
            }



            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnection))
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
                                cmd.Parameters.AddWithValue("@userId", Traveler.TravelerInstance.TravelerId);
                                cmd.Parameters.AddWithValue("@bookingDate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@price", totalPrice);
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
            }
        }


        private void generateReceiptButton_Click_1(object sender, EventArgs e)
        {

            MessageBox.Show($"Total Cost: ${totalPrice:F2}", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
