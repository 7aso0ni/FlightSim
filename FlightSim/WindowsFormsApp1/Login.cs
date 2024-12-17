using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = UsernameTextBox.Text;
            MessageBox.Show(text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            // validate the user credentials and return the role of the logged in user
            Traveler user = ValidateLogin(username.Trim(), password.Trim());

            if (user != null)
            {
                MessageBox.Show("Welcome " + user.Username);
            } else
            {
                MessageBox.Show("An Error Occured");
                return;
            }

            // navigate into the respective home page based on the user role
            switch (user.Role)
            {
                case "admin":
                    this.Hide();
                    AdminHome admin = new AdminHome();
                    admin.ShowDialog();
                    this.Show();
                    break;
                case "employer":
                    this.Hide();
                    EmployerHome emp = new EmployerHome();
                    emp.ShowDialog();
                    this.Show();
                    break;
                case "traveler":
                    this.Hide();
                    TravelerHome trv = new TravelerHome();
                    trv.ShowDialog();
                    this.Show();
                    break;
            }
        }

        private Traveler ValidateLogin(string username, string password)
        {
            Traveler traveler = null;
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Hussa\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"
                SELECT t.id, u.username, u.password, u.email, u.role, 
                       t.name, t.passport_number, t.age
                FROM [dbo].[User] u
                LEFT JOIN [dbo].[Traveler] t ON u.id = t.user_id
                WHERE u.username = @username AND u.password = @password";

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            // start reading the data
            try
            {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // check if data was returned
                if (reader.Read())
                {
                        traveler = new Traveler(
                         Convert.ToInt32(reader["id"]),
                         reader["username"].ToString(),
                         reader["password"].ToString(),
                         reader["email"].ToString(),
                         reader["role"].ToString(),
                         reader["name"].ToString(),
                         Convert.ToInt32(reader["passport_number"]),
                         Convert.ToInt32(reader["age"])
                     );

                        Console.WriteLine(traveler.Id);

                        Traveler.TravelerInstance = traveler;
                    } else
                {
                    MessageBox.Show("User does not exist");
                    return null;
                }
            }

            // close the connection
            conn.Close();
            return traveler;
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        private void linkToRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // hide the current form when link is clicked
            this.Hide();

            Register form2 = new Register();
            form2.ShowDialog();

            // show the current form when the second form is closed
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
