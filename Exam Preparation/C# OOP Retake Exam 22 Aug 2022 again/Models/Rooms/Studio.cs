using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        private const int STUDIO_BEDCAPACITY = 4;

        public Studio() : base(STUDIO_BEDCAPACITY)
        {
        }
    }
}
