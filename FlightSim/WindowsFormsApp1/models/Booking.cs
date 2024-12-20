using System.Collections.Generic;

namespace WindowsFormsApp1.models
{
    internal class Booking
    {
        private int flightId;
        private List<Addon> addons;
        private double price;
        private bool isServiceEnabled;

        public Booking(int flight_id, List<Addon> addons, double price)
        {
            this.flightId = flight_id;
            this.addons = addons;
            this.price = price;
        }

        public int FlightId { get { return flightId; } set { this.flightId = value; } }

        public List<Addon> Addons { get { return addons; } set { this.addons = value; } }
        public double Price
        {
            get { return price; }
            set { this.price = value; }

        }

        public bool IsServiceEnabled
        {
            get { return isServiceEnabled; }
            set { this.isServiceEnabled = value; }
        }
    }
}
