using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.models
{
        internal class Flight
        {
            private int id;
            private int departureLocation;
            private int arrivalLocation;
            private DateTime departureTime;
            private DateTime arrivalTime;
            private int categoryId;
            private int flightStatus;

            public int Id
            {
                get { return id; }
                set { id = value; }
            }

            public int DepartureLocation
            {
                get { return departureLocation; }
                set { departureLocation = value; }
            }

            public int ArrivalLocation
            {
                get { return arrivalLocation; }
                set { arrivalLocation = value; }
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

            public int CategoryId
            {
                get { return categoryId; }
                set { categoryId = value; }
            }

            public int FlightStatus
            {
                get { return flightStatus; }
                set { flightStatus = value; }
            }

            // Constructor
            public Flight() { }

            public Flight(int id, int departureLocation, int arrivalLocation, DateTime departureTime, DateTime arrivalTime, int categoryId, int flightStatus)
            {
                this.id = id;
                this.departureLocation = departureLocation;
                this.arrivalLocation = arrivalLocation;
                this.departureTime = departureTime;
                this.arrivalTime = arrivalTime;
                this.categoryId = categoryId;
                this.flightStatus = flightStatus;
            }

           
        }

}
