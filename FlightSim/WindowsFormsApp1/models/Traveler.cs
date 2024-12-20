﻿namespace WindowsFormsApp1.models
{
    internal class Traveler : User
    {
        private int travelerId;
        private string name;
        private int passportNumber;
        private int age;

        // by default booking and payment are enabled
        private static bool isBookingEnabled = true;
        private static bool isPaymentEnabled = true;

        // static instance to have access throughout the enitre application
        private static Traveler travelerInstance;

        public Traveler(int travelerId, string username, string password, string email, string role, string name, int passportNumber, int age) : base(username, password, email, role)
        {
            this.travelerId = travelerId;
            this.name = name;
            this.passportNumber = passportNumber;
            this.age = age;
        }


        public string Name { get => name; set => name = value; }
        public int PassportNumber { get => passportNumber; set => passportNumber = value; }
        public int Age { get => age; set => age = value; }
        public int TravelerId { get => travelerId; set => travelerId = value; }

        public static bool IsBookingEnabled { get => isBookingEnabled; set => isBookingEnabled = value; }
        public static bool IsPaymentEnabled { get => isPaymentEnabled; set => isPaymentEnabled = value; }

        public static Traveler TravelerInstance { get => travelerInstance; set => travelerInstance = value; }
    }
}
