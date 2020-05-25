using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class SqlOrderRepository : IRepository<Order>
    {
        private BookStoreDbContext _context;

        public SqlOrderRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> Get(Expression<Func<Order, bool>> filter, string includeProperties = "")
        {
            return _context.Orders.Include(x => x.User)
                .Include(x => x.Book).Where(filter);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.Include(x => x.User).Include(x => x.Book);
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
                var order = Get(model => model.Id == item.Id).FirstOrDefault();
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