using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class TravelerHome : Form
    {

        int flightId;
        public TravelerHome()
        {
            InitializeComponent();
        }

        private void TravelerHome_Load(object sender, EventArgs e)
        {
            User user = new User();

            // get traveler info from the user id
            SqlConnection conn = new SqlConnection(MyString.ConnectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"
    SELECT t.id, u.username, u.password, u.email, u.role, 
           t.name, t.passport_number, t.age
    FROM [dbo].[User] u
    LEFT JOIN [dbo].[Traveler] t ON u.id = t.user_id
    WHERE u.id = @UserId";

            cmd.Parameters.AddWithValue("UserId", user.UserId);



            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Traveler tra = new Traveler(
                       travelerId: Convert.ToInt32(reader["id"]),
                       username: reader["username"].ToString(),
                       password: reader["password"].ToString(),
                       email: reader["email"].ToString(),
                       role: reader["role"].ToString(),
                       name: reader["name"].ToString(),
                       passportNumber: Convert.ToInt32(reader["passport_number"]),
                       age: Convert.ToInt32(reader["age"])
                        );

                    Traveler.TravelerInstance = tra;
                }
            }

            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void searchFlight_Click(object sender, EventArgs e)
        {
            string depLocation = depLocationTextBox.Text;
            string destLocation = desLocationTextBox.Text;

            List<Flight> flights = SearchFlights(depLocation.ToLower().Trim(), destLocation.ToLower().Trim());

            if (flights == null)
            {
                MessageBox.Show("Something went wrong, Please try again later");
                return;
            }


            // Display the search results in the gridview
            flightDisplay.DataSource = flights;

        }

        private List<Flight> SearchFlights(string depCountry, string destCountry)
        {

            try
            {
                List<Flight> flights = new List<Flight>();

                SqlConnection conn = new SqlConnection(MyString.ConnectionString);

                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = @"
        SELECT 
        f.id AS FlightID,
        depCity.name AS DepartureLocation,
        arrCity.name AS ArrivalLocation,
        arrCity.airport_name AS ArrivalAirport,
        f.departure_time AS DepartureTime,
        f.arrival_time AS ArrivalTime,
        f.base_price AS BasePrice,
        cat.name AS Category,
        fs.status_name AS FlightStatus   
        FROM [dbo].[Flight] f
        INNER JOIN [dbo].[City] depCity ON f.departure_location = depCity.id
        INNER JOIN [dbo].[Country] depCountry ON depCity.parent_id = depCountry.id
        INNER JOIN [dbo].[City] arrCity ON f.arrival_location = arrCity.id
        INNER JOIN [dbo].[Country] arrCountry ON arrCity.parent_id = arrCountry.id
        INNER JOIN [dbo].[Category] cat ON f.category_id = cat.id
        INNER JOIN [dbo].[FlightStatus] fs ON f.flight_status = fs.id
        WHERE depCountry.name = @depCountry AND arrCountry.name = @destCountry";

                Console.WriteLine(cmd.CommandText);

                // Add parameters
                cmd.Parameters.AddWithValue("@depCountry", depCountry);
                cmd.Parameters.AddWithValue("@destCountry", destCountry);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flight flight = new Flight();
                        flightId = reader.GetInt32(reader.GetOrdinal("FlightID"));

                        flight.Id = flightId;
                        flight.DepartureLocationName = reader.GetString(reader.GetOrdinal("DepartureLocation"));
                        flight.ArrivalLocationName = reader.GetString(reader.GetOrdinal("ArrivalLocation"));
                        flight.DepartureTime = reader.GetDateTime(reader.GetOrdinal("DepartureTime"));
                        flight.ArrivalTime = reader.GetDateTime(reader.GetOrdinal("ArrivalTime"));
                        flight.CategoryName = reader.GetString(reader.GetOrdinal("Category"));
                        flight.FlightStatusName = reader.GetString(reader.GetOrdinal("FlightStatus"));
                        flight.AirportName = reader.GetString(reader.GetOrdinal("ArrivalAirport"));
                        flight.BasePrice = (double)reader.GetDecimal(reader.GetOrdinal("BasePrice"));
                        MessageBox.Show(flight.ToString());
                        flights.Add(flight);
                    }
                }

                if (flights.Count == 0)
                {
                    MessageBox.Show("No flights found");
                }


                conn.Close();

                return flights;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            depLocationTextBox.Text = "";
            desLocationTextBox.Text = "";

            flightDisplay.DataSource = null;
        }

        private void profileButton_Click(object sender, EventArgs e)
        {

            TravelerProfile profile = new TravelerProfile();
            profile.ShowDialog();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bookFlightButton_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (flightDisplay.CurrentRow != null)
            {
                try
                {
                    // Example: Assume "Price" is a column in your DataGridView
                    double flightPrice = Convert.ToDouble(flightDisplay.CurrentRow.Cells["BasePrice"].Value);

                    // Pass the price to TravelerPayment form
                    TravelerPayment tp = new TravelerPayment(flightPrice, flightId);
                    tp.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a flight to book.");
            }
        }

        private void flightDisplay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Chat chat = new Chat();
            chat.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
