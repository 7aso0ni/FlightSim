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
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            LoadPreviousChats();
        }
        private void LoadPreviousChats()
        {
            try
            {
                User user = new User();

                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gaming\\Desktop\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();
                    string query = @"
    SELECT DISTINCT u.id AS UserId, u.username
    FROM [dbo].[Message] m
    INNER JOIN [dbo].[User] u
    ON u.id = CASE
        WHEN m.sender_id = @currentUserId THEN m.receiver_id
        WHEN m.receiver_id = @currentUserId THEN m.sender_id
        ELSE NULL END
    WHERE @currentUserId IN (m.sender_id, m.receiver_id)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@currentUserId", user.UserId); // Replace with the logged-in user's ID
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable chatData = new DataTable();
                            chatData.Columns.Add("UserId", typeof(int));
                            chatData.Columns.Add("Username", typeof(string));
                            adapter.Fill(chatData);
                            chatHistoryGrid.DataSource = chatData;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error loading chat history: {ex.Message}");
            }
        }
        private void OpenChatWithUser(int userId)
        {
            try
            {
                User user = new User();
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gaming\\Desktop\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();
                    string query = @"
                SELECT sender_id, content, date_sent
                FROM [dbo].[Message]
                WHERE (sender_id = @currentUserId AND receiver_id = @userId)
                   OR (sender_id = @userId AND receiver_id = @currentUserId)
                ORDER BY date_sent ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@currentUserId", user.UserId); // Replace with the logged-in user's ID
                        cmd.Parameters.AddWithValue("@userId", userId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            chatListBox.Items.Clear();
                            while (reader.Read())
                            {
                                string sender = (int)reader["sender_id"] == user.UserId ? "You" : "User";
                                string message = $"[{reader["date_sent"]}] {sender}: {reader["content"]}";
                                chatListBox.Items.Add(message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error loading chat: {ex.Message}");
            }
        }
        private void SendMessage(int receiverId, string messageContent)
        {
            User user = new User();

            if (string.IsNullOrWhiteSpace(messageContent))
            {
                System.Windows.Forms.MessageBox.Show("Message content cannot be empty.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gaming\\Desktop\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();
                    string query = @"
                INSERT INTO [dbo].[Message] (sender_id, receiver_id, content, date_sent, status)
                VALUES (@senderId, @receiverId, @content, @dateSent, 'Sent')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@senderId", user.UserId); // Replace with the logged-in user's ID
                        cmd.Parameters.AddWithValue("@receiverId", receiverId);
                        cmd.Parameters.AddWithValue("@content", messageContent);
                        cmd.Parameters.AddWithValue("@dateSent", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }

                System.Windows.Forms.MessageBox.Show("Message sent!");
                OpenChatWithUser(receiverId); // Refresh chat after sending
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error sending message: {ex.Message}");
            }
        }
        private void StartNewChat(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gaming\\Desktop\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();
                    string query = "SELECT id FROM [dbo].[User] WHERE username = @username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            int userId = Convert.ToInt32(result);
                            OpenChatWithUser(userId);
                            DataRow newRow = ((DataTable)chatHistoryGrid.DataSource).NewRow();
                            newRow["UserId"] = userId;
                            newRow["Username"] = username;
                            ((DataTable)chatHistoryGrid.DataSource).Rows.Add(newRow);
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("User not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error starting chat: {ex.Message}");
            }
        }




        private void chatHistoryGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void userNameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void startNewButton_Click(object sender, EventArgs e)
        {
            string username = userNameText.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                System.Windows.Forms.MessageBox.Show("Please enter a username.");
                return;
            }
            StartNewChat(username);
        }

        private void openSelectedButton_Click(object sender, EventArgs e)
        {
            if (chatHistoryGrid.SelectedRows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Please select a chat from the list.");
                return;
            }
            int userId = Convert.ToInt32(chatHistoryGrid.SelectedRows[0].Cells[0].Value);
            OpenChatWithUser(userId);

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chatListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chatListBox.SelectedItem != null)
            {
                string selectedMessage = chatListBox.SelectedItem.ToString();
                System.Windows.Forms.MessageBox.Show($"Selected Message: {selectedMessage}");
            }
        }

        private void MessageBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string messageContent = MessageBox.Text.Trim();
            if (string.IsNullOrEmpty(messageContent)) 
            {
                System.Windows.Forms.MessageBox.Show("Message cannot be empty.");
                return;
            }

            if (chatHistoryGrid.SelectedRows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Please select or start a chat.");
                return;
            }
            int receiverId = Convert.ToInt32(chatHistoryGrid.SelectedRows[0].Cells[0].Value);
            SendMessage(receiverId, messageContent);
            System.Windows.Forms.MessageBox.Show("Message sent successfully!");
            MessageBox.Clear();

        }
    }
}
