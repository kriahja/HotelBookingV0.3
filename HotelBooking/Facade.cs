using HotelBooking.DAL.Repositories;
using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking
{
    public class Facade
    {
        private IRepository<Booking> bookingRepo;
        private IRepository<Customer> customerRepo;
        private IRepository<Room> roomRepo;

        public IRepository<Booking> GetBookingRepository()
        {
            if (bookingRepo == null)
            {
                bookingRepo = new BookingRepository();

            }
            return bookingRepo;
        }

        public IRepository<Customer> GetCustomerRepository()
        {
            if (customerRepo == null)
            {
                customerRepo = new CustomerRepository();

            }
            return customerRepo;
        }

        public IRepository<Room> GetRoomRepository()
        {
            if (roomRepo == null)
            {
                roomRepo = new RoomRepository();

            }
            return roomRepo;
        }
    }
}