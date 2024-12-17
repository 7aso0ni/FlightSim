using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace WindowsFormsApp1.models
{
    internal class TravelerPayment
    {
        private string cardName;
        private string cardNumber;
        private int cvv;
        private DateTime expiryDate;
        private Traveler traveler;

        public static TravelerPayment paymentDetails;

        public TravelerPayment(string cardName, string cardNumber, int cvv, DateTime expiryDate, Traveler traveler)
        {
            this.cardName = cardName;
            this.cardNumber = cardNumber;
            this.cvv = cvv;
            this.expiryDate = expiryDate;
            this.traveler = traveler;
        }

        public string CardName { get { return cardName; } set { this.cardName = value; } }
        public string CardNumber { get { return cardNumber; } set { this.cardNumber = value; } }
        public int CVV { get { return cvv; } set { this.cvv = value; } }
        public DateTime ExpiryDate { get { return expiryDate; } set { expiryDate = value; } }
        public Traveler Traveler { get { return traveler; } set { this.traveler = value; } }
    }
}
