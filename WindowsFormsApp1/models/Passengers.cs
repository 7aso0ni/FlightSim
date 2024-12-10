using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.models
{
    internal class Passengers
    {
        private string name;
        private string passportNumber;
        private int travelerId;

        public Passengers(string name, string passportNumber, int travelerId)
        {
            this.name = name;
            this.passportNumber = passportNumber;
            this.travelerId = travelerId;
        }

        public string Name { get => name; set => name = value; }
        public string PassportNumber { get => passportNumber; set => passportNumber = value; }
        public int TravelerId { get => travelerId; set => travelerId = value; }

    }
}
