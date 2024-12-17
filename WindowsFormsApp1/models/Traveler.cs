using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.models
{
    internal class Traveler : User
    {
        private int id;
        private string name;
        private int passportNumber;
        private int age;
        private List<int> passengers = new List<int>();

        // static instance to have access throughout the enitre application
        private static Traveler travelerInstance;

        public Traveler(int id, string username, string password, string email, string role, string name, int passportNumber, int age) : base(username, password, email, role)
        {
            this.id = id;
            this.name = name;
            this.passportNumber = passportNumber;
            this.age = age;
        }
 

        public string Name { get => name; set => name = value; }
        public int PassportNumber { get => passportNumber; set => passportNumber = value; }
        public int Age { get => age; set => age = value; }
        public int Id { get => id; set => id = value; }

        public List<int> Passengers { get => passengers; set => passengers = value; }

        public static Traveler TravelerInstance { get => travelerInstance; set => travelerInstance = value; }
    }
}
