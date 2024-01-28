using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorBooking_WorkingWell()
        {
            Room room = new Room(2, 50);
            Booking booking = new Booking(1, room, 1);

            Assert.AreEqual(1, booking.BookingNumber);
            Assert.AreEqual(2, room.BedCapacity);
            Assert.AreEqual(50, room.PricePerNight);
            Assert.AreEqual(1, booking.ResidenceDuration);
        }



        [Test]
        public void BookingNUmber_Property_WorkingAsNeeded()
        {
            Room room = new Room(2, 50);
            Booking booking = new Booking(1, room, 1);

            Assert.AreEqual(1, booking.BookingNumber);

        }
        [Test]
        public void ResidenceDuration_Property_WorkingAsNeeded()
        {
            Room room = new Room(2, 50);
            Booking booking = new Booking(1, room, 1);

            Assert.AreEqual(1, booking.ResidenceDuration);

        }

        [Test]
        public void Room_Property_WorkingAsNeeded()
        {
            Room room = new Room(2, 50);
            Booking booking = new Booking(1, room, 1);

            Assert.AreEqual(2, booking.Room.BedCapacity);
            Assert.AreEqual(50, booking.Room.PricePerNight);

        }


        [Test]
        public void Hotel_Constructor_WorkingAsNeeded()
        {
            //Room room = new Room(2, 50);
            //Booking booking = new Booking(1, room, 1);
            Hotel hotel = new Hotel("Casablanca", 5);

            Assert.AreEqual("Casablanca", hotel.FullName);
            Assert.AreEqual(5, hotel.Category);

        }

        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void Hotel_Name_Throws_WhenItsNULLorWHITESPACE(string HotelName)
        {


            Assert.Throws<ArgumentNullException>(() => new Hotel(HotelName, 5));

        }


        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(6)]
        public void Hotel_Category_Throws_WhenIts_LessThen1_And_Above5_Stars(int stars)
        {

            Assert.Throws<ArgumentException>(() => new Hotel("Casablanca", stars));

        }

        [Test]
        public void Hotel_TurnOver_WorkingAsNeeded()
        {
            //Room room = new Room(2, 50);
            //Booking booking = new Booking(1, room, 1);
            Hotel hotel = new Hotel("Casablanca", 5);

            Assert.AreEqual(0, hotel.Turnover);

        }

        [Test]
        public void Hotel_Rooms_WorkingAsNeeded()
        {
            Hotel hotel = new Hotel("Casablanca", 5);
            List<Room> rooms = new List<Room>();
            Room room = new Room(2, 50);

            rooms.Add(room);
            hotel.AddRoom(room);

            CollectionAssert.AreEqual(rooms, hotel.Rooms);
            Assert.AreEqual(1, hotel.Rooms.Count);

        }

        [Test]
        public void Hotel_Bookings_WorkingAsNeeded()
        {
            Hotel hotel = new Hotel("Casablanca", 5);

            Room room = new Room(2, 50);
            Booking booking = new Booking(1, room, 1);

            //hotel.AddRoom(room);
            //hotel.BookRoom(1, 1, 1, 50);

            List<Booking> bookings = new List<Booking>();
            //bookings.Add(booking);



            CollectionAssert.AreEqual(bookings, hotel.Bookings);

        }

        [Test]
        public void Hotel_Bookings()
        {
            Hotel hotel = new Hotel("Casablanca", 5);

            Room room = new Room(4, 50);

            hotel.AddRoom(room);

            hotel.BookRoom(1,1,1,50);

            Assert.AreEqual(1, hotel.Bookings.Count);

        }

        [Test]
        public void Hotel_BookRoom_Throws_When_Adults_Less_Then_One()
        {
            Hotel hotel = new Hotel("Casablanca", 5);

            Room room = new Room(2, 50);
            Booking booking = new Booking(1, room, 1);

            hotel.AddRoom(room);


            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 1, 1, 50));

        }

        [Test]
        public void Hotel_BookRoom_Throws_When_Children_Less_Then_Zero()
        {
            Hotel hotel = new Hotel("Casablanca", 5);

            Room room = new Room(2, 50);
            Booking booking = new Booking(1, room, 1);

            hotel.AddRoom(room);


            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, -1, 1, 50));

        }

        [Test]
        public void Hotel_BookRoom_Throws_When_Duration_Less_Then_Zero()
        {
            Hotel hotel = new Hotel("Casablanca", 5);

            Room room = new Room(2, 50);
            Booking booking = new Booking(1, room, 1);

            hotel.AddRoom(room);


            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, 1, -1, 50));

        }

        [Test]
        public void Hotel_BookRoom_Works_As_Needed()
        {
            Hotel hotel = new Hotel("Casablanca", 5);

            Room room = new Room(2, 50);
            Booking booking = new Booking(1, room, 1);

            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 1, 50);


            Assert.AreEqual(1, hotel.Bookings.Count);
        }

        [Test]
        public void Room_Constructor_Works_As_Needed()
        {


            Room room = new Room(2, 50);

            Assert.AreEqual(2, room.BedCapacity);
            Assert.AreEqual(50, room.PricePerNight);
        }

        [TestCase(0)]
        [TestCase(-8)]
        public void Room_Bed_Capacity_Throws_When_Its_Zero_Or_Less(int bedCapacity)
        {

            Assert.Throws<ArgumentException>(() => new Room(bedCapacity, 50));
        }
        
        [TestCase(0)]
        [TestCase(-8)]
        public void PricePerNight_Throws_When_Its_Zero_Or_Less(int pricePerNight)
        {

            Assert.Throws<ArgumentException>(() => new Room(1, pricePerNight));
        }


        [Test]
        public void Hotel_BookRoom()
        {
            Hotel hotel = new Hotel("Casablanca", 5);

            Room room = new Room(2, 50);
            Booking booking = new Booking(1, room, 1);

            hotel.AddRoom(room);
            hotel.BookRoom(11, 11, 11, 50);


            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void BookRoom_NoBookingIfTheBudgetIsLOw()
        {
            var hotel = new Hotel("Casablanca", 5);
            var room = new Room(5, 333);
            
            hotel.AddRoom(room);


            hotel.BookRoom(2, 1, 2, 200);
            double expectedTurnover = 0;

            Assert.AreEqual(expectedTurnover, hotel.Turnover);
            Assert.That(hotel.Bookings.Count.Equals(0));
            Assert.That(hotel.Rooms.Count.Equals(1));
        }
    }
}
