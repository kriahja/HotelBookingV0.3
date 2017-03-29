using System;
using NUnit.Framework;
using HotelBooking.BLL;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HotelBooking.UnitTests
{
    public class BookingManagerTests
    {
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
            return new BookingManager();
        }
    }
}
