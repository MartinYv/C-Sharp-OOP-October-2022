using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private IRepository<IBooking> bookings;
        private IRepository<IRoom> rooms;
        private double turnover;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;

            bookings = new BookingRepository();
            rooms = new RoomRepository();
            Bookings = bookings;
            Rooms = rooms;
        }

        public string FullName 
        {
            get
            {
                return fullName;
            }
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }

                fullName = value;
            }
        }

        public int Category
        {
            get
            {
                return category;
            }
            private set
            {
                if (value < 1 && value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }

                category = value;
            }
        }

        public double Turnover
        {
            get
            {
                return turnover;
            }
           private set
            {
                double totalSum = 0;

                foreach (var item in bookings.All())
                {
                    totalSum += item.ResidenceDuration * item.Room.PricePerNight;
                }

                value = totalSum;
                turnover = value;
            }
        }
        public IRepository<IRoom> Rooms //=> rooms.All() as IRepository<IRoom>;
        {
            get
            {
                return rooms;
            }
            set
            {

                value = rooms.All() as IRepository<IRoom>;

            }
        }
        public IRepository<IBooking> Bookings //=> bookings.All() as IRepository<IBooking>;
        {
            get
            {
                return bookings;
            }
            set
            {

                value = bookings.All() as IRepository<IBooking>;
            }
        }
    }
}
