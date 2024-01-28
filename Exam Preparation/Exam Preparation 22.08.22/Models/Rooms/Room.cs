using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private double pricePerNight;
        private int roomSetPriceCounter = -1;

        public int BedCapacity { get; private set; }


        public Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
            PricePerNight = 0;
        }


        public double PricePerNight
        {
            get
            {
                return pricePerNight;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }

                if (roomSetPriceCounter == 1)
                {
                    throw new ArgumentException(ExceptionMessages.PriceAlreadySet);
                }

                pricePerNight = value;
                roomSetPriceCounter++;
            }
        }
        public void SetPrice(double price)
        {
            PricePerNight += price;
        }
    }
}
