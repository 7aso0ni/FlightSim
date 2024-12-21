using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class UserList : Form
    {
        private readonly string sqlConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gaming\\Desktop\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30";
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
                        user.InstanceUserID = Convert.ToInt32(reader["id"]);
                        user.Username = reader["username"].ToString();
                        user.Email = reader["email"].ToString();
                        user.Password = reader["password"].ToString();
                        user.Role = reader["role"].ToString();

                        users.Add(user);
                    }
                }
                conn.Close();

                dataGridView1.DataSource = users;
                dataGridView1.Columns.Remove("UserId");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the User ID from the selected row
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["InstanceUserID"].Value);

                // Create the DELETE command to remove the user by UserId
                string deleteQuery = "DELETE FROM [dbo].[User] WHERE [id] = @id";

                // Execute the DELETE command
                using (SqlConnection conn = new SqlConnection(sqlConnection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        // Add the parameter to prevent SQL injection
                        cmd.Parameters.AddWithValue("@id", id);

                        // Execute the command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User deleted successfully.");
                            // Reload the user list to reflect the deletion
                            loadUserList();
                        }
                        else
                        {
                            MessageBox.Show("User not found or could not be deleted.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected user ID from the DataGridView
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["InstanceUserID"].Value);

                // Get the updated data from the selected row or input fields (e.g., TextBox controls)
                string updatedUsername = dataGridView1.CurrentRow.Cells["Username"].Value.ToString();
                string updatedEmail = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                string updatedPassword = dataGridView1.CurrentRow.Cells["Password"].Value.ToString();
                string updatedRole = dataGridView1.CurrentRow.Cells["Role"].Value.ToString();

                if (!handleRoleChange(id, updatedRole))
                {
                    return;
                }

                // Create the UPDATE SQL command to update the user data in the database
                string updateQuery = "UPDATE [dbo].[User] SET [username] = @username, [email] = @email, [password] = @password, [role] = @role WHERE [id] = @id";

                // Execute the UPDATE command
                using (SqlConnection conn = new SqlConnection(sqlConnection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@username", updatedUsername);
                        cmd.Parameters.AddWithValue("@email", updatedEmail);
                        cmd.Parameters.AddWithValue("@password", updatedPassword);
                        cmd.Parameters.AddWithValue("@role", updatedRole);

                        // Execute the command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User updated successfully.");
                            // Reload the user list to reflect the changes
                            loadUserList();
                        }
                        else
                        {
                            MessageBox.Show("User could not be updated.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool handleRoleChange(int userId, string newRole)
        {
            string insertQuery = "";

            switch (newRole.ToLower())
            {
                case "admin":
                    insertQuery = "INSERT INTO [dbo].[Administrator] ([user_id]) VALUES (@userId)";
                    break;
                case "employee":
                    insertQuery = "INSERT INTO [dbo].[Employer] ([user_id]) VALUES (@userId)";
                    break;
                case "traveler":
                    insertQuery = "INSERT INTO [dbo].[Traveler] ([user_id]) VALUES (@userId)";
                    break;
                default:
                    MessageBox.Show("Invalid role selected.");
                    return false;
            }

            // Execute the insertion based on the role
            using (SqlConnection conn = new SqlConnection(sqlConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchQuery = textBox1.Text.Trim();  // Get the search text from the TextBox

            if (!string.IsNullOrEmpty(searchQuery))
            {
                List<User> filteredUsers = new List<User>();

                // Construct the SQL query to search by username (case-insensitive)
                string searchQuerySQL = "%" + searchQuery + "%";  // Use wildcards for partial matching

                string query = "SELECT * FROM [dbo].[User] WHERE [username] LIKE @searchQuery";

                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnection))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@searchQuery", searchQuerySQL);

                            // Execute the query and read the results
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    User user = new User();
                                    user.InstanceUserID = Convert.ToInt32(reader["id"]);
                                    user.Username = reader["username"].ToString();
                                    user.Email = reader["email"].ToString();
                                    user.Password = reader["password"].ToString();
                                    user.Role = reader["role"].ToString();

                                    filteredUsers.Add(user);
                                }
                            }
                        }
                    }

                    // Update DataGridView with filtered users
                    dataGridView1.DataSource = filteredUsers;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                // If the search query is empty, reload the full user list
                loadUserList();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadUserList();
        }
    }
}
