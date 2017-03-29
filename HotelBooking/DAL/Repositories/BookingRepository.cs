using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelBooking.DAL.Repositories
{
    public class BookingRepository : IRepository<Booking>
    {
        public Booking Add(Booking entity)
        {
            using (HotelBookingContext db = new HotelBookingContext())
            {
                Booking newBooking = db.Bookings.Add(entity);
                db.SaveChanges();
                return newBooking;
            }
        }

        public void Edit(Booking entity)
        {
            using (HotelBookingContext db = new HotelBookingContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Booking Get(int id)
        {
            using (HotelBookingContext db = new HotelBookingContext())
            {
                return db.Bookings.Include(b => b.Customer).Include(b => b.Room).FirstOrDefault(b => b.Id == id);
            }
        }

        public IEnumerable<Booking> GetAll()
        {
            using (HotelBookingContext db = new HotelBookingContext())
            {
                return db.Bookings.Include(b => b.Customer).Include(b => b.Room).ToList();
            }
        }

        public void Remove(int id)
        {
            using (HotelBookingContext db = new HotelBookingContext())
            {
                var booking = db.Bookings.FirstOrDefault(b => b.Id == id);
                db.Bookings.Remove(booking);
                db.SaveChanges();
            }
        }

    }
}