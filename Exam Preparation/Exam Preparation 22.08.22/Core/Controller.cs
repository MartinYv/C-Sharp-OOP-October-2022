using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;
        public Controller()
        {
            hotels = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            if (hotels.Select(hotelName) == null)
            {
                IHotel hotel = new Hotel(hotelName, category);
                hotels.AddNew(hotel);
                throw new Exception(string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName));

            }
            else
            {
                throw new Exception(string.Format(OutputMessages.HotelAlreadyRegistered, hotelName));
            }
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            List<IHotel> hotelsOrderedAlphabeticaly = hotels.All().OrderBy(x => x.FullName).ToList();
            var roomsWithSettedPricePerNight = hotels.All().Select(x => x.Rooms.All().Where(x => x.PricePerNight > 0)).ToList();
            var roomsOrderedByCapacity = hotels.All().Select(x => x.Rooms.All().Where(x => x.PricePerNight > 0).OrderBy(x => x.BedCapacity)).ToList();

            var hotel = hotels.All().FirstOrDefault(x => x.Category == category);
            if (hotel == null)
            {
                throw new Exception(string.Format(OutputMessages.CategoryInvalid, category));
            }


            foreach (IRoom currRoom in roomsOrderedByCapacity)
            {
                
                if (currRoom.BedCapacity >= adults + children)
                {
                                
                    
                    var booking = new Booking(currRoom as IRoom, duration, adults,children, hotel.Bookings.All().Count +1);
                    hotel.Bookings.AddNew(booking);
                   
                    throw new Exception(string.Format(OutputMessages.BookingSuccessful, category, hotel.FullName));
                }
                
            }

                throw new Exception(string.Format(OutputMessages.RoomNotAppropriate));

        }

        public string HotelReport(string hotelName)
        {
            var hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                throw new Exception(String.Format(OutputMessages.HotelNameInvalid, hotelName));
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Hotel name: {hotelName}");
                sb.AppendLine($"--{hotel.Category} star hotel");
                sb.AppendLine($"--Turnover: {hotel.Turnover: F2} $");

                string result = hotel.Bookings.All().Count <= 0 ? "none" : $"{string.Join(" ", hotel.Bookings.All().Select(x => x.BookingSummary()))}";

                sb.AppendLine(result);

                return sb.ToString().TrimEnd();
            }

        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            var hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                throw new Exception(string.Format(OutputMessages.HotelNameInvalid, hotelName));
            }

            if (roomTypeName != "Apartment" && roomTypeName != "DoubleBed" && roomTypeName != "Studio")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));
            }

            bool isRoomTypeCreated = hotel.Rooms.All().Any(x => x.GetType().Name == roomTypeName);
           
            if (isRoomTypeCreated == false)
            {
            throw new Exception(string.Format(OutputMessages.RoomTypeNotCreated));

            }


            var room= hotel.Rooms.All().First(x=>x.GetType().Name == roomTypeName) as IRoom;
            room.SetPrice(price);
            throw new Exception(string.Format(OutputMessages.PriceSetSuccessfully,roomTypeName, hotelName));
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            var hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                throw new Exception(string.Format(OutputMessages.HotelNameInvalid, hotelName));
            }

            foreach (var currRoom in hotel.Rooms.All())
            {
                if (currRoom.GetType().Name == roomTypeName)
                {
                    throw new Exception(string.Format(OutputMessages.RoomTypeAlreadyCreated));
                }
            }

            if (roomTypeName != "Apartment" && roomTypeName != "DoubleBed" && roomTypeName != "Studio")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));
            }

            IRoom room = null;

            if (roomTypeName == "Apartment")
            {
                room = new Apartment();
            }
            else if (roomTypeName == "Studio")
            {
                room = new Studio();
            }
            else if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }

            hotel.Rooms.AddNew(room);

            throw new Exception(string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName));
        }
    }
}
