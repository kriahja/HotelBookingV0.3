using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelBooking.Models;


namespace HotelBooking.DAL.Repositories
{
    public class RoomRepository : IRepository<Room>
    {
        public Room Add(Room entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Room entity)
        {
            throw new NotImplementedException();
        }

        public Room Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetAll()
        {
            using (HotelBookingContext db = new HotelBookingContext())
            {
                return db.Rooms.ToList();
            }
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}