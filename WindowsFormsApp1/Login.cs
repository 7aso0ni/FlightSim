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
            String userRole = ValidateLogin(username.Trim(), password.Trim());

            if (userRole != null)
            {
                MessageBox.Show("Welcome " + userRole);
            }

            // navigate into the respective home page based on the user role
            switch (userRole)
            {
                case "admin":
                    this.Hide();
                    AdminHome admin = new AdminHome();
                    admin.Show();
                    this.Show();
                    break;
                case "employer":
                    this.Hide();
                    EmployerHome emp = new EmployerHome();
                    emp.Show();
                    this.Show();
                    break;
                case "traveler":
                    this.Hide();
                    TravelerHome trv = new TravelerHome();
                    trv.Show();
                    this.Show();
                    break;
            }
        }

        private String ValidateLogin(string username, string password)
        {
            String userRole = "";

            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Hussa\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT * FROM [dbo].[User] WHERE username = @username AND password = @password";
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
                   userRole = reader["role"].ToString();
                } else
                {
                    MessageBox.Show("User does not exist");
                    return null;
                }
            }

            // close the connection
            conn.Close();
            return userRole;
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
    }
}
