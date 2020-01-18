using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Services
{
    public class SqlOrderRepository : IRepository<Order>
    {
        private BookStoreDbContext _context;

        public SqlOrderRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public Order Get(int id)
        {
            if (_context.Orders.Count(x => x.Id == id) > 0)
            {
                return _context.Orders.FirstOrDefault(x => x.Id == id);
            }

            return null;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }

        public bool Create(Order item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Order item)
        {
            try
            {
                var order = Get(item.Id);
                if (order != null)
                {
                    _context.Remove(order);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Order item)
        {
            throw new System.NotImplementedException();
        }
    }
}