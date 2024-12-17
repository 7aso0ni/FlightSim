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
    public partial class TravelerProfile : Form
    {
        public TravelerProfile()
        {
            InitializeComponent();
        }

        private void TravelerProfile_Load(object sender, EventArgs e)
        {
            Traveler traveler = Traveler.TravelerInstance;

            nameField.Text = traveler.Name;
            passportField.Text = traveler.PassportNumber.ToString();
            emailField.Text = traveler.Email;

            fetchCardDetails(traveler.Id);
        }

        private void fetchCardDetails(int travelerID)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Hussa\\Downloads\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT * FROM [dbo].[Traveler_Payment] WHERE traveler_id = @traveler_id";
                cmd.Parameters.AddWithValue("@traveler_id", travelerID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cardNumberField.Text = reader["card_number"].ToString();
                        cardNameField.Text = reader["card_name"].ToString();

                        DateTime expirationDate = Convert.ToDateTime(reader["expiration_date"]);
                        expiryDateField.Text = expirationDate.ToString("dd/MM/yyyy"); // Formats date without time
                        cvvField.Text = reader["cvv"].ToString();
                    }
                }

                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void cvvField_TextChanged(object sender, EventArgs e)
        {
        }

        private void updatePayment_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the user has already entered the payment details
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Hussa\\Downloads\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT * FROM [dbo].[Traveler_Payment] WHERE traveler_id = @traveler_id";
                cmd.Parameters.AddWithValue("@traveler_id", Traveler.TravelerInstance.Id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check if the user has already entered the payment details
                    if (reader.Read())
                    {
                        // Close the reader before executing a new command
                        reader.Close();
                        cmd.Parameters.Clear();

                        // Update the payment details
                        cmd.CommandText = "UPDATE [dbo].[Traveler_Payment] SET card_number = @card_number, card_name = @card_name, expiration_date = @expiry_date, cvv = @cvv WHERE traveler_id = @traveler_id";
                        cmd.Parameters.AddWithValue("@card_number", cardNumberField.Text);
                        cmd.Parameters.AddWithValue("@card_name", cardNameField.Text);
                        cmd.Parameters.AddWithValue("@expiry_date", expiryDateField.Text);
                        cmd.Parameters.AddWithValue("@cvv", cvvField.Text);
                        cmd.Parameters.AddWithValue("@traveler_id", Traveler.TravelerInstance.Id);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // Close the reader before executing a new command
                        reader.Close();
                        cmd.Parameters.Clear();

                        // Insert the payment details
                        cmd.CommandText = "INSERT INTO [dbo].[Traveler_Payment] (card_number, card_name, expiration_date, cvv, traveler_id) VALUES (@card_number, @card_name, @expiry_date, @cvv, @traveler_id)";
                        cmd.Parameters.AddWithValue("@card_number", cardNumberField.Text);
                        cmd.Parameters.AddWithValue("@card_name", cardNameField.Text);
                        cmd.Parameters.AddWithValue("@expiry_date", expiryDateField.Text);
                        cmd.Parameters.AddWithValue("@cvv", cvvField.Text);
                        cmd.Parameters.AddWithValue("@traveler_id", Traveler.TravelerInstance.Id);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Payment details updated successfully.");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
