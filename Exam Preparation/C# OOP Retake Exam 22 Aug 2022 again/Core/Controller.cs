using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
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

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private IRepository<IHotel> hotels;
        private IRepository<IRoom> rooms;
        public Controller()
        {
            hotels = new HotelRepository();
            rooms = new RoomRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (hotels.All().All(x => x.Category != category))
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

           
            var hotelsAlphabetical = hotels.All().Where(x => x.Category == category).OrderBy(x=>x.FullName);

            for (int i = 0; i < hotelsAlphabetical.Count(); i++)
            {
                var sortedRoomsByPriceOrderByCapacity = hotelsAlphabetical.ElementAt(i).Rooms.All().Where(x => x.PricePerNight > 0).OrderBy(x => x.BedCapacity);

                for (int j = 0; j < sortedRoomsByPriceOrderByCapacity.Count(); j++)
                {
                    if (sortedRoomsByPriceOrderByCapacity.ElementAt(j).BedCapacity >= adults + children)
                    {
                        IBooking booking = new Booking(sortedRoomsByPriceOrderByCapacity.ElementAt(j), duration, adults, children, hotelsAlphabetical.ElementAt(i).Bookings.All().Count() + 1);

                        hotelsAlphabetical.ElementAt(i).Bookings.AddNew(booking);

                        return string.Format(OutputMessages.BookingSuccessful, hotelsAlphabetical.ElementAt(i).Bookings.All().Count(), hotelsAlphabetical.ElementAt(i).FullName);
                    }
                }
            }

           
            return OutputMessages.RoomNotAppropriate;


        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover :F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

           // string result = hotel.Bookings.All().Count == 0 ? "none" : string.Join(Environment.NewLine, hotel.Bookings.All().Select(x => x.BookingSummary()));
            //sb.AppendLine(result);
            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine();
                }
            }


            return sb.ToString().TrimEnd();

        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.Select(hotelName);
            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != "DoubleBed" && roomTypeName != "Studio" && roomTypeName != "Apartment")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            if (room == null) 
            {
                return OutputMessages.RoomTypeNotCreated;
            }

          

            if (room.PricePerNight != 0)
            {
                throw new ArgumentException(ExceptionMessages.PriceAlreadySet);

            }

            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);

        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.Select(hotelName);
            IRoom room = rooms.Select(roomTypeName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (room != null)
            {
                return (OutputMessages.RoomTypeAlreadyCreated);
            }

            if (roomTypeName != "DoubleBed" && roomTypeName != "Studio" && roomTypeName != "Apartment")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }



            if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == "Studio")
            {
                room = new Studio();
            }
            else
            {
                room = new Apartment();
            }

            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
