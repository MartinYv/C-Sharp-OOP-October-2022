using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        private const int DOUBLE_ROOM_BED_CAPACITY = 2;

        public DoubleBed() : base(DOUBLE_ROOM_BED_CAPACITY)
        {

        }

    }
}
