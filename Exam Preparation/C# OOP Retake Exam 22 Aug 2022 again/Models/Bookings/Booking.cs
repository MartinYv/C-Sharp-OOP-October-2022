﻿using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int resudenceDuration;
        private int adultsCount;
        private int childrenCount;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }
        public IRoom Room { get; }

        public int ResidenceDuration
        {
            get
            {
                return resudenceDuration;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }

                resudenceDuration = value;
            }
        }
        public int AdultsCount
        {
            get
            {
                return adultsCount;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }

                adultsCount = value;
            }
        }
        public int ChildrenCount
        {
            get
            {
                return childrenCount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }

                childrenCount = value;         
            }
        }
        public int BookingNumber { get; }

        public string BookingSummary()
        {
            double TotalPaid = Math.Round(ResidenceDuration * Room.PricePerNight);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}");
            sb.AppendLine($"Adults: { AdultsCount} Children: { ChildrenCount}");
            sb.AppendLine($"Total amount paid: {TotalPaid:F2} $");

            return sb.ToString().TrimEnd();

        }
    }
}
