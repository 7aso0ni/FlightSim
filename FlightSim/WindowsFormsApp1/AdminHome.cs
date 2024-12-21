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
    public partial class AdminHome : Form
    {
        private readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gaming\\Desktop\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30";
        public AdminHome()
        {
            InitializeComponent();
            this.Load += new EventHandler(AdminHome_Load);
        }

        private void LoadData()
        {
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [dbo].[Flight]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //ADD
        private void button1_Click_1(object sender, EventArgs e)
        {
            string departureCity = textBox2.Text.Trim();
            string arrivalCity = textBox3.Text.Trim();
            DateTime departureTime = dateTimePicker1.Value;
            DateTime arrivalTime = dateTimePicker2.Value;

            // Get selected category ID based on the selected item in the ComboBox
            int categoryId = GetCategoryId(comboBox2.SelectedItem.ToString());

            // Get selected flight status ID based on the selected item in the ComboBox
            int flightStatusId = GetFlightStatusId(comboBox1.SelectedItem.ToString());

            // Check if IDs are valid
            if (categoryId <= 0)
            {
                MessageBox.Show("Invalid category selected.");
                return;
            }

            if (flightStatusId <= 0)
            {
                MessageBox.Show("Invalid flight status selected.");
                return;
            }

            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            INSERT INTO [dbo].[Flight] (departure_location, arrival_location, departure_time, arrival_time, category_id, flight_status, base_price) 
            VALUES (@departureCity, @arrivalCity, @departureTime, @arrivalTime, @categoryId, @flightStatusId, @basePrice)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@departureCity", GetCityId(departureCity, connection));
                    command.Parameters.AddWithValue("@arrivalCity", GetCityId(arrivalCity, connection));
                    command.Parameters.AddWithValue("@departureTime", departureTime);
                    command.Parameters.AddWithValue("@arrivalTime", arrivalTime);
                    command.Parameters.AddWithValue("@categoryId", categoryId);
                    command.Parameters.AddWithValue("@flightStatusId", flightStatusId);
                    command.Parameters.AddWithValue("@basePrice", 0.00m);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} flight(s) added successfully!");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

                // store the action performed in the database
                query = "INSERT INTO [dbo].[SystemLog] (admin_id, timestamp, action) VALUES (@adminID, @timestamp, @action)";
                using (SqlCommand com = new SqlCommand(query, connection))
                {
                    User user = new User();
                    com.Parameters.AddWithValue("adminID", user.UserId);
                    com.Parameters.AddWithValue("timestamp", DateTime.Now);
                    com.Parameters.AddWithValue("action", "add flight");
                }
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Database backup performed");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //EDIT
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int flightId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value); // Adjust "id" based on your primary key column name
                string departureCity = dataGridView1.CurrentRow.Cells["departure_location"].Value.ToString(); // Adjust column name
                string arrivalCity = dataGridView1.CurrentRow.Cells["arrival_location"].Value.ToString(); // Adjust column name
                DateTime departureTime = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["departure_time"].Value); // Adjust column name
                DateTime arrivalTime = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["arrival_time"].Value); // Adjust column name
                int categoryId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["category_id"].Value); // Adjust column name
                int flightStatusId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["flight_status"].Value); // Adjust column name

                // Update the database with new values
               

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                UPDATE [dbo].[Flight] 
                SET departure_location = @departureCity,
                    arrival_location = @arrivalCity,
                    departure_time = @departureTime,
                    arrival_time = @arrivalTime,
                    category_id = @categoryId,
                    flight_status = @flightStatusId
                WHERE id = @flightId"; // Adjust "id" based on your primary key column name

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@departureCity", departureCity);
                        command.Parameters.AddWithValue("@arrivalCity", arrivalCity);
                        command.Parameters.AddWithValue("@departureTime", departureTime);
                        command.Parameters.AddWithValue("@arrivalTime", arrivalTime);
                        command.Parameters.AddWithValue("@categoryId", categoryId);
                        command.Parameters.AddWithValue("@flightStatusId", flightStatusId);
                        command.Parameters.AddWithValue("@flightId", flightId);
                        command.ExecuteNonQuery();
                    }

                    // store the action performed in the database
                    query = "INSERT INTO [dbo].[SystemLog] (admin_id, timestamp, action) VALUES (@adminID, @timestamp, @action)";
                    using (SqlCommand com = new SqlCommand(query, connection))
                    {
                        User user = new User();
                        com.Parameters.AddWithValue("adminID", user.UserId);
                        com.Parameters.AddWithValue("timestamp", DateTime.Now);
                        com.Parameters.AddWithValue("action", "updated flight");
                    }

                    connection.Close();
                }

                // Reload data to reflect the changes
                LoadData();
                MessageBox.Show("Flight updated successfully!");
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        //DELETE
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int flightId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value); // Adjust "id" based on your primary key column name

               
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM [dbo].[Flight] WHERE id = @flightId"; // Adjust "id" based on your primary key column name

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@flightId", flightId);
                        command.ExecuteNonQuery();
                    }

                    // store the action performed in the database
                    query = "INSERT INTO [dbo].[SystemLog] (admin_id, timestamp, action) VALUES (@adminID, @timestamp, @action)";
                    using (SqlCommand com = new SqlCommand(query, connection))
                    {
                        User user = new User();
                        com.Parameters.AddWithValue("adminID", user.UserId);
                        com.Parameters.AddWithValue("timestamp", DateTime.Now);
                        com.Parameters.AddWithValue("action", "delete flight");
                    }

                    connection.Close();
                }

                // Reload data to reflect the changes
                LoadData();
                MessageBox.Show("Flight deleted successfully!");
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        //METHODS
        private int GetCategoryId(string categoryName)
        {
            switch (categoryName)
            {
                case "Domestic": return 4; // Replace with ID
                case "International": return 5; // Replace with ID
                default: return 0; // Invalid category
            }
        }

        // Method to map flight status names to IDs
        private int GetFlightStatusId(string flightStatusName)
        {
            switch (flightStatusName)
            {
                case "Scheduled": return 1; // Replace with ID
                case "Delayed": return 2; // Replace with ID
                case "Cancelled": return 3; // Replace with ID
                case "Completed": return 4; //Replace with ID

                default: return 0; // Invalid status
            }
        }

        //Method to get City ID
        private int GetCityId(string cityName, SqlConnection connection)
        {
            string query = "SELECT id FROM [dbo].[City] WHERE name = @cityName";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@cityName", cityName);
                object result = command.ExecuteScalar();
                return result != null ? (int)result : 0; // Return 0 if not found
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Chat chat = new Chat();
            chat.ShowDialog();
        }

        private void AdminHome_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CreateUser createUser = new CreateUser("Admin");
            createUser.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CreateUser createUser = new CreateUser("Employee");
            createUser.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TravelerBooking travelerBooking = new TravelerBooking();
            travelerBooking.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TravelerServices travelerServices = new TravelerServices();
            travelerServices.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UserList userList = new UserList();
            userList.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
