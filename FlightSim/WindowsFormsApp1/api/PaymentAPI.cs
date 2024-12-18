using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.api
{
    internal class PaymentAPI
    {
        public PaymentAPI() { }

        public bool ProcessPayment(string cardNumber, string expiryDate, string cvv, double amount)
        {
            // Simple validation for the inputs
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length != 16)
            {
                MessageBox.Show("Invalid card number.");
                return false;
            }

            if (string.IsNullOrEmpty(cvv) || cvv.Length != 3)
            {
                 MessageBox.Show("Invalid CVV.");
                return false;
            }

            if (!DateTime.TryParse(expiryDate, out DateTime parsedExpiryDate) || parsedExpiryDate < DateTime.Now)
            {
                MessageBox.Show("Card has expired or invalid date format.");
                return false;
            }

            if (amount <= 0)
            {
                MessageBox.Show("Invalid payment amount.");
                return false;
            }

            return true;
        }

    }
}
