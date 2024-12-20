using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class EmployeeHome : Form
    {
        private int selectedFlightID = -1;
        double flightPrice = 0;
        public EmployeeHome()
        {
            InitializeComponent();
        }


        private void LoadAllFlights() //Method to load flight details
        {
            string query = @"SELECT 
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
        INNER JOIN [dbo].[FlightStatus] fs ON f.flight_status = fs.id";

            printToGrid(query);
        }

        private void SearchFlights() //The search method
        {
            string depLocation = textBox1.Text.Trim();
            string destLocation = textBox2.Text.Trim();
            string query = @"
                SELECT f.id AS FlightID, depCity.name AS Departure, arrCity.name AS Destination, 
                       f.departure_time AS DepartureTime, f.arrival_time AS ArrivalTime, 
                       cat.name AS Category, fs.status_name AS Status
                FROM [dbo].[Flight] f
                INNER JOIN [dbo].[City] depCity ON f.departure_location = depCity.id
                INNER JOIN [dbo].[City] arrCity ON f.arrival_location = arrCity.id
                INNER JOIN [dbo].[Category] cat ON f.category_id = cat.id
                INNER JOIN [dbo].[FlightStatus] fs ON f.flight_status = fs.id
                WHERE (@dep = '' OR depCity.name = @dep)
                  AND (@dest = '' OR arrCity.name = @dest)";

            printToGrid(query, depLocation, destLocation);
        }

        private void printToGrid(string query, string dep = "", string dest = "") //method to show data inside the gridview
        {
            using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gaming\\Desktop\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dep", dep);
                    cmd.Parameters.AddWithValue("@dest", dest);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable flights = new DataTable();
                        adapter.Fill(flights);
                        dataGridView1.DataSource = flights;
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedFlightID = Convert.ToInt32(row.Cells["FlightID"].Value);
            }
        }

        private void EmployerHome_Load(object sender, EventArgs e)
        {
            LoadAllFlights();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            LoadAllFlights();
        }
        //private void button3_Click_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (selectedFlightID > 0)
        //    {
        //        EmployeeReservation reservationForm = new EmployeeReservation(selectedFlightID);
        //        reservationForm.ShowDialog();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select a flight to book");
        //    }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                selectedFlightID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["FlightID"].Value);
                double flightPrice = Convert.ToDouble(dataGridView1.CurrentRow.Cells["BasePrice"].Value);
                EmployeeReservation reservationForm = new EmployeeReservation(selectedFlightID, flightPrice);
                reservationForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a flight to book.");
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }



        //private void button3_Click_1(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells["FlightID"].Value != null)
        //        {
        //            selectedFlightID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["FlightID"].Value);
        //            EmployeeReservation reservationForm = new EmployeeReservation(selectedFlightID);
        //            reservationForm.ShowDialog();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please select a valid flight to book.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An error occurred: " + ex.Message);
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            SearchFlights();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            LoadAllFlights();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Chat chat = new Chat();
            chat.ShowDialog();
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
