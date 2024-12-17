using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class TravelerHome : Form
    {
        public TravelerHome()
        {
            InitializeComponent();
        }

        private void TravelerHome_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string depCountry = departureCountry.Text;

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchFlight_Click(object sender, EventArgs e)
        {
            string depCountry = departureCountry.Text;
            string destCountry = destinationCountry.Text;

            // search for flights based on the departure and destination countries
            List<Flight> flights = SearchFlights(depCountry.ToLower().Trim(), destCountry.ToLower().Trim());

            foreach (Flight flight in flights)
            {
                dataGridView1.Rows.Add(
                    flight.Id,
                    flight.DepartureLocation,
                    flight.ArrivalLocation,
                    flight.DepartureTime,
                    flight.ArrivalTime,
                    flight.CategoryId,
                    flight.FlightStatus
                );
            }
        }

        private List<Flight> SearchFlights(string depCountry, string destCountry)
        {
            List<Flight> flights = new List<Flight>();

            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Hussa\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
            SELECT f.*
            FROM [dbo].[Flight] f
            INNER JOIN [dbo].[City] depCity ON f.departure_location = depCity.id
            INNER JOIN [dbo].[Country] depCountry ON depCity.parent_id = depCountry.id
            INNER JOIN [dbo].[City] arrCity ON f.arrival_location = arrCity.id
            INNER JOIN [dbo].[Country] arrCountry ON arrCity.parent_id = arrCountry.id
            WHERE depCountry.name = @depCountry AND arrCountry.name = @destCountry";

            cmd.Parameters.AddWithValue("@depCountry", depCountry);
            cmd.Parameters.AddWithValue("@destCountry", destCountry);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Flight flight = new Flight();
                flight.Id = reader.GetInt32(0);
                flight.DepartureLocation = reader.GetInt32(1);
                flight.ArrivalLocation = reader.GetInt32(2);
                flight.DepartureTime = reader.GetDateTime(3);
                flight.ArrivalTime = reader.GetDateTime(4);
                flight.CategoryId = reader.GetInt32(5);
                flight.FlightStatus = reader.GetInt32(6);
                flights.Add(flight);
            }

            conn.Close();

            if (flights.Count == 0)
            {
                MessageBox.Show("No flights found");
            }
            return flights;
        }
    }
}
