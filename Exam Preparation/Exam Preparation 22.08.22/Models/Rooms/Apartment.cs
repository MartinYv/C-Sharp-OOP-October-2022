using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int APARTMENT_BED_CAPACITY = 6;
        public Apartment() : base(APARTMENT_BED_CAPACITY)
        {
        }
    }
}
