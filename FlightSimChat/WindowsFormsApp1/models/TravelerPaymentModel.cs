using System;

namespace WindowsFormsApp1.models
{
    internal class TravelerPaymentModel
    {
        private string cardName;
        private string cardNumber;
        private string cvv;
        private DateTime expiryDate;
        private Traveler traveler;

        public static TravelerPaymentModel paymentDetails = null;



        public TravelerPaymentModel(string cardName, string cardNumber, string cvv, DateTime expiryDate, Traveler traveler)
        {

            this.cardName = cardName;
            this.cardNumber = cardNumber;
            this.cvv = cvv;
            this.expiryDate = expiryDate;
            this.traveler = traveler;
        }

        public TravelerPaymentModel() { }

        public string CardName { get { return cardName; } set { this.cardName = value; } }
        public string CardNumber { get { return cardNumber; } set { this.cardNumber = value; } }
        public string CVV { get { return cvv; } set { this.cvv = value; } }
        public DateTime ExpiryDate { get { return expiryDate; } set { expiryDate = value; } }
        public Traveler Traveler { get { return traveler; } set { this.traveler = value; } }

        public TravelerPaymentModel PaymentDetails { get { return paymentDetails; } set { paymentDetails = value; } }
    }
}
