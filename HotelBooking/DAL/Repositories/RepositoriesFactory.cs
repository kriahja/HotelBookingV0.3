using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.DAL.Repositories
{
    public class RepositoriesFactory
    {
        private static IRepository<Booking> bookingRepository = new BookingRepository();
        private static IRepository<Room> roomRepository = new RoomRepository();
        private static IRepository<Customer> customerRepository = new CustomerRepository();
        public static IRepository<Booking> BookingRepository
        {
            get { return bookingRepository; }
            set { bookingRepository = value; }
        }

        public static IRepository<Room> RoomRepository
        {
            get { return roomRepository; }
            set { roomRepository = value; }
        }

        public static IRepository<Customer> CustomerRepository
        {
            get { return customerRepository; }
            set { customerRepository = value; }
        }

    }
}