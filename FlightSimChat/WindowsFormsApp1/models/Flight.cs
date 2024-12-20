using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace WindowsFormsApp1.models
{
    internal class Flight
    {
            // Private fields
            private int id;
            private string departureLocationName;
            private string arrivalLocationName;
            private DateTime departureTime;
            private DateTime arrivalTime;
            private string categoryName;
            private string flightStatusName;
            private string airportName;
            private double basePrice;

        public Flight() { }

            // Public Properties
            public int Id
            {
                get { return id; }
                set { id = value; }
            }

            public string DepartureLocationName
            {
                get { return departureLocationName; }
                set { departureLocationName = value; }
            }

            public string ArrivalLocationName
            {
                get { return arrivalLocationName; }
                set { arrivalLocationName = value; }
            }

            public DateTime DepartureTime
            {
                get { return departureTime; }
                set { departureTime = value; }
            }

            public DateTime ArrivalTime
            {
                get { return arrivalTime; }
                set { arrivalTime = value; }
            }

            public string CategoryName
            {
                get { return categoryName; }
                set { categoryName = value; }
            }

            public string FlightStatusName
            {
                get { return flightStatusName; }
                set { flightStatusName = value; }
            }

        public string AirportName
        {
            get { return airportName; }
            set { airportName = value; }
        }

        public double BasePrice
        {
            get { return basePrice; }
            set { basePrice = value; }
        }
    }
}
