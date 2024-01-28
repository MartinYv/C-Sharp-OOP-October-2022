using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
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
                return residenceDuration;
            }

            private set
            {
                if (value <= 0)
                {

                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }

                residenceDuration = value;
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

            //
            //            "Booking number: {BookingNumber}
            //             Room type: { RoomType}
            //             Adults: { AdultsCount}
            //             Children: { ChildrenCount}
            //            $"
            //             Total amount paid: { TotalPaid():F2}
            //HINT: TotalPaid() => MathRound(ResidenceDuration * PricePerNight, 2),  print TotalPaid() on the Console with two decimal places after decimal point.
            //

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}"); // problem- the room is null
            sb.AppendLine($"Adults: {AdultsCount}");
            sb.AppendLine($"Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {Math.Round(ResidenceDuration * Room.PricePerNight * Room.BedCapacity):F2}$");

            return sb.ToString().TrimEnd();
        }
    }
}
