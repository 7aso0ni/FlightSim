using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.models
{
    internal class AddonInfo
    {
        private double price;
        private int id;

        public AddonInfo(double price, int id)
        {
            this.price = price;
            this.id = id;
        }

        public double Price { get { return price; } set { this.price = value; } }
        public int Id { get { return id; } set { this.id = value; } }

    }
}
