using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.models
{
    internal class Traveler : User
    {
        private string name;
        private string passportNumber;
        private string contanctInfo;
        private List<int> passengers = new List<int>();

        public Traveler(string username, string password, string email, string role, string name, string passportNumber, string contanctInfo) : base(username, password, email, role)
        {
            this.name = name;
            this.passportNumber = passportNumber;
            this.contanctInfo = contanctInfo;
        }

        public string Name { get => name; set => name = value; }
        public string PassportNumber { get => passportNumber; set => passportNumber = value; }
        public string ContanctInfo { get => contanctInfo; set => contanctInfo = value; }

        public List<int> Passengers { get => passengers; set => passengers = value; }
    }
}
