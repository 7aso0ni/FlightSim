using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            // Check if Form1 is already open
            Login form1 = Application.OpenForms.OfType<Login>().FirstOrDefault();
            if (form1 == null)
            {
                form1 = new Login();
                form1.Show();
            }
            else
            {
                form1.BringToFront(); // Bring the existing Form1 to the front
            }

            // after opening the form, close the current form
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = UsernameTextBox.Text;
            String password = PasswordTextBox.Text;
            String email = EmailTextBox.Text;
            String name = NameTextBox.Text;
            int passportNumber;
            int age;

            // convert the passport number, phone number and age to integer, if not successfull show an error message
            if (!int.TryParse(PassportNumberTextBox.Text, out passportNumber))
            {
                MessageBox.Show("Invalid passport number. Please enter a valid number.");
                return;
            }


            if (!int.TryParse(AgeTextBox.Text, out age))
            {
                MessageBox.Show("Invalid age. Please enter a valid number.");
                return;
            }

            if (age < 18)
            {
                MessageBox.Show("You must be 18 years or older to register.");
                return;
            }


            if (VerifyRegister(username, password, email, name, passportNumber, age))
            {


                // navigate to the traveler home page
                this.Hide();
                TravelerHome travelerHome = new TravelerHome();
                travelerHome.ShowDialog();
                this.Show();
            }

        }

        private bool VerifyRegister(String username, String password, String email, String name, int passportNumber, int age)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gaming\\Desktop\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                   
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // check if the user already exists
                cmd.CommandText = "SELECT * FROM [dbo].[User] WHERE email = @email";
                cmd.Parameters.AddWithValue("@email", email);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        MessageBox.Show("User already exists. Please login.");
                        return false;
                    }
                }

                // insert the user into the database
                cmd.CommandText = "INSERT INTO [dbo].[User] (username, email, password, role) VALUES (@username, @email, @password, 'traveler'); SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                // get the user id after inserting to the user table
                int userId = Convert.ToInt32(cmd.ExecuteScalar());

                // insert the traveler into the database
                cmd.CommandText = "INSERT INTO [dbo].[Traveler] (name, passport_number, age, user_id) VALUES (@name, @passportNumber, @age, @userId); SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@passportNumber", passportNumber);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@userId", userId);

                int travelerId = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();
                MessageBox.Show("User registered successfully");

                Traveler traveler = new Traveler(travelerId, username, password, email, "traveler", name, passportNumber, age);
                // if everything is good to go save the traveler instance
                Traveler.TravelerInstance = traveler;

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
