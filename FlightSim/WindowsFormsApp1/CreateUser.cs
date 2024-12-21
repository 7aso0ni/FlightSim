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
    public partial class CreateUser : Form
    {
        private string sqlConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gaming\\Desktop\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30";
        string userRole = "";
        public CreateUser(string userRole)
        {
            this.userRole = userRole;
            InitializeComponent();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            // dynamically render the page based on the user role
            createUserLabel.Text = $"Create {userRole}";
            createUserBtn.Text = $"Create {userRole}";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void createUserBtn_Click(object sender, EventArgs e)
        {

            string username = usernameText.Text;
            string password = passwordText.Text;
            string email = emailText.Text;
            string phoneNumber = contactInfo.Text;

            try
            {
                SqlConnection con = new SqlConnection(sqlConnection);
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("phoneNumber", phoneNumber);

                if (userRole == "Admin")
                {
                    cmd.CommandText = "INSERT INTO [dbo].[User] (username, password, email, role) VALUES (@username, @password, @email, 'admin'); SELECT SCOPE_IDENTITY();";
                    
                    // get user id
                    int userId = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd.Parameters.AddWithValue("userId", userId);

                    cmd.CommandText = "INSERT INTO [dbo].[Administrator] (user_id, contact_info) VALUES (@userId, @phoneNumber)";

                } else
                {
                    cmd.CommandText = "INSERT INTO [dbo].[User] (username, password, email, role) VALUES (@username, @password, @email, 'employee'); SELECT SCOPE_IDENTITY();";
                    // get user id
                    int userId = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.CommandText = "INSERT INTO [dbo].[Employer] (user_id, contact_info) VALUES (@userId, @phoneNumber)";
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show($"{userRole} created successfully");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
