using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.models
{
    internal class Traveler : User
    {
        private int travelerId;
        private string name;
        private int passportNumber;
        private int age;

        // static instance to have access throughout the enitre application
        private static Traveler travelerInstance;

        public Traveler(int travelerId, string username, string password, string email, string role, string name, int passportNumber, int age) : base(0, username, password, email, role)
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


        public static Traveler TravelerInstance { get => travelerInstance; set => travelerInstance = value; }
    }
}
