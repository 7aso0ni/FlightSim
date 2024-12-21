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

namespace WindowsFormsApp1
{
    public partial class TravelerBooking : Form
    {
        private readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Administrator\\Source\\Repos\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30";
        public TravelerBooking()
        {
            InitializeComponent();
            this.Load += new EventHandler(TravelerBooking_Load);
        }
        private void LoadData()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [dbo].[Booking]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TravelerBooking_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //Search
        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                // If the search box is empty, display the entire Booking table
                DisplayAllBookings();
            }
            else
            {
                int bookingId;
                if (int.TryParse(textBox1.Text, out bookingId))
                {
                    SearchBooking(bookingId);
                }
                else
                {
                    MessageBox.Show("Please enter a valid booking ID.");
                }
            }
        }

        private void SearchBooking(int bookingId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Booking WHERE id = @bookingId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@bookingId", bookingId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void DisplayAllBookings()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Booking";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        //Delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int bookingId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                DeleteBooking(bookingId);
            }
            else
            {
                MessageBox.Show("Please select a booking to delete.");
            }
        }

        private void DeleteBooking(int bookingId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Booking WHERE id = @bookingId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@bookingId", bookingId);

                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Booking deleted successfully.");
                LoadData();
            }
        }

        //Modify
        private void button2_Click(object sender, EventArgs e)
        {
            
            DataTable table = (DataTable)dataGridView1.DataSource;

            // Check if there are any modified rows
            if (table.GetChanges() == null)
            {
                MessageBox.Show("No changes made to update.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Exit the method if no changes are detected
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                bool isModified = false; // Flag to check if any row was modified

                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        string updateQuery = "UPDATE Booking SET flight_id = @flightId, user_id = @userId, " +
                                             "booking_date = @bookingDate, price = @price, booking_status = @bookingStatus " +
                                             "WHERE id = @id";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@flightId", row["flight_id"]);
                            command.Parameters.AddWithValue("@userId", row["user_id"]);
                            command.Parameters.AddWithValue("@bookingDate", row["booking_date"]);
                            command.Parameters.AddWithValue("@price", row["price"]);
                            command.Parameters.AddWithValue("@bookingStatus", row["booking_status"]);
                            command.Parameters.AddWithValue("@id", row["id"]);

                            command.ExecuteNonQuery();
                            isModified = true; // Set the flag to true if a row was modified
                        }
                    }
                }

                // Show confirmation message if any rows were modified
                if (isModified)
                {
                    MessageBox.Show("Booking details updated successfully.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Refresh the DataGridView after the update
            LoadData();
        }
    }
}
