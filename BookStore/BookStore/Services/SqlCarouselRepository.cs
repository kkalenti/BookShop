using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class SqlCarouselRepository:IRepository<Carousel>
    {
        private BookStoreDbContext _context;

        public SqlCarouselRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Carousel> Get(Expression<Func<Carousel, bool>> filter, string includeProperties = "")
        {
            return _context.Carousels.Include(c => c.Section).Where(filter);
        }

        public IEnumerable<Carousel> GetAll()
        {
            return _context.Carousels.Include(c => c.Section).ToList();
        }

        public bool Create(Carousel item)
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

        public bool Delete(Carousel item)
        {
            try
            {
                var carousel = Get(model => model.Id == item.Id).FirstOrDefault();
                if (carousel != null)
                {
                    _context.Remove(carousel);
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

        public bool Update(Carousel item)
        {
            throw new System.NotImplementedException();
        }
    }
}