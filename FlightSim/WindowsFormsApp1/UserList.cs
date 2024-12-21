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
    public partial class UserList : Form
    {
        private readonly string sqlConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Hussa\\Downloads\\FlightSim\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30";
        public UserList()
        {
            InitializeComponent();
        }

        private void UserList_Load(object sender, EventArgs e)
        {
            loadUserList();
        }

        private void loadUserList()
        {
            List<User> users = new List<User>();
            try
            {
                SqlConnection conn = new SqlConnection(sqlConnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT * FROM [dbo].[User]";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.UserId = Convert.ToInt32(reader["id"]);
                        user.Username = reader["username"].ToString();
                        user.Email = reader["email"].ToString();
                        user.Password = reader["password"].ToString();
                        user.Role = reader["role"].ToString();

                        users.Add(user);
                    }
                }
                conn.Close();

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
