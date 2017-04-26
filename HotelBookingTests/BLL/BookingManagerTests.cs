using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBooking.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace HotelBooking.BLL.Tests
{
    [TestClass()]
    public class BookingManagerTests
    {

        [TestMethod()]
        public void FindAvailableRoom_StartDateNotInTheFuture_ThrowsArgumentException()
        {
            BookingManager manager = CreateBookingManager();
            DateTime date = DateTime.Today;

            try
            {
                manager.FindAvailableRoom(date, date);
            }
            catch (ArgumentException)
            {

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void FindAvailableRoom_RoomAvailable_RoomIdNotMinusOne()
        {
            BookingManager manager = CreateBookingManager();
            DateTime date = DateTime.Today.AddDays(1);
            int roomId = manager.FindAvailableRoom(date, date);
            Assert.AreNotEqual(-1, roomId);
        }

        [TestMethod()]
        public void GetFullyOccupiedDates()
        {
            BookingManager manager = CreateBookingManager();
            List<DateTime> knownDates= new List<DateTime>();
            for (int i = 0; i <= 14; ++i)
            {
                knownDates.Add(new DateTime(2017, 4, 20 + i));
            }
            
            List<DateTime> dates = manager.GetFullyOccupiedDates(DateTime.Today, DateTime.Today.AddYears(1));
            
            Assert.IsTrue(listcomparer(knownDates, dates));
        }

        public bool comparer(DateTime a, DateTime b)
        {
           
            if (DateTime.Equals(a,b))
            {
                return true;
            }
            return false;
        }

        public bool listcomparer(List<DateTime> a, List<DateTime> b)
        {
            bool equals = true;
            if (a.Count() != b.Count())
            {
                return false;
            }
            else
            {
                for (int i = 0; i < a.Count(); ++i)
                {
                    if (!comparer(a[i], b[i]))
                    {
                        equals = false;
                    }
                }
            }
            return equals;
        }

        private BookingManager CreateBookingManager()
        {
            return new BookingManager();
        }
    }
}