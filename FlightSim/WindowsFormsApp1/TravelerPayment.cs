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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class TravelerPayment : Form
    {

        double flightPrice;
        public TravelerPayment(double flightPrice)
        {
            InitializeComponent();
            this.flightPrice = flightPrice;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TravelerPayment_Load(object sender, EventArgs e)
        {
            // get the user info that is saved
            Traveler travelerInfo = Traveler.TravelerInstance;

            nameField.Text = travelerInfo.Name;
            passpotField.Text = travelerInfo.PassportNumber.ToString();

            textBox7.Text = flightPrice.ToString() + "$";

            loadAddons();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void loadAddons()
        {

            try
            {


                // Clear existing checkboxes (if any)
                AddonList.Controls.Clear();

                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Hussa\\Downloads\\FlightSim\\FlightSim\\FlightSim\\WindowsFormsApp1\\FlightDB.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM [dbo].[Addons]";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CheckBox checkBox = new CheckBox();
                        checkBox.Text = $"{reader["name"].ToString()} - ${reader["price"]}";
                        checkBox.Tag = reader["id"];
                        checkBox.AutoSize = true;
                        AddonList.Controls.Add(checkBox);

                        
                    }


                }
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
