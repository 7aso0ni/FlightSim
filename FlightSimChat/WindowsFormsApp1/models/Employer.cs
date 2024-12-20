using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.models
{
    internal class Employer : User
    {
        private string contactInfo;

        public Employer(string username, string password, string email, string role, string contactInfo) : base(username, password, email, role)
        {
            this.contactInfo = contactInfo;
        }

        public string ContactInfo { get => contactInfo; set => contactInfo = value; }
    }
}
