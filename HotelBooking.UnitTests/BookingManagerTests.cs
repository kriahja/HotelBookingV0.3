using System;
using NUnit.Framework;
using HotelBooking.BLL;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HotelBooking.DAL.Repositories;
using HotelBooking.Models;
using NSubstitute;
using static HotelBooking.UnitTests.FakeSystemTime;

namespace HotelBooking.UnitTests
{
    public class BookingManagerTests
    {

        [SetUp]
        public void Setup()
        {
            SystemTime.Set(new DateTime(2002, 1, 1));
        }

        [TearDown]
        public void TearDown()
        {
            SystemTime.Reset();
        }

        [Test]
        public void FindAvailableRoom_StartDateNotInTheFuture_ThrowsArgumentException()
        {
            BookingManager manager = CreateBookingManager();
            DateTime date = DateTime.Today;
            Assert.Catch<ArgumentException>(() => manager.FindAvailableRoom(date, date));
        }

        [Test]
        public void FindAvailableRoom_RoomAvailable_RoomIdNotMinusOne()
        {
            BookingManager manager = CreateBookingManager();
            DateTime date = DateTime.Today.AddDays(1);
            int roomId = manager.FindAvailableRoom(date, date);
            Assert.AreNotEqual(-1, roomId);
        }

        private BookingManager CreateBookingManager()
        {
         
            DateTime start = SystemTime.Today.AddDays(10);
            DateTime end = SystemTime.Today.AddDays(20);


            List<Room> rooms = new List<Room>();
            List<Booking> bookings = new List<Booking>
            {
                new Booking { Id=1, StartDate=start, EndDate=end, IsActive=true, CustomerId=1, RoomId=1 },
                new Booking { Id=2, StartDate=start, EndDate=end, IsActive=true, CustomerId=2, RoomId=2 },
            };


            IRepository<Room> fakeRoomRepos = Substitute.For<IRepository<Room>>();
            IRepository<Booking> fakeBookingRepos = Substitute.For<IRepository<Booking>>();

            //We must create a RepositoryFactory to make this work. -- I think 8-)
                //RepositoriesFactory.RoomRepository = fakeRoomRepos;
                //RepositoriesFactory.BookingRepository = fakeBookingRepos;

            fakeRoomRepos.GetAll().Returns(rooms);
            fakeBookingRepos.GetAll().Returns(bookings);



            return new BookingManager();

        }
    }
}
