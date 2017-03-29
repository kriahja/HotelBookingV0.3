using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelBooking.Models;


namespace HotelBooking.DAL.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        public Customer Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            using (HotelBookingContext db = new HotelBookingContext())
            {
                return db.Customers.ToList();
            }
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}