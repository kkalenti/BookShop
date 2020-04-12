using System;
using System.Collections.Generic;
using System.Linq;
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

        public Carousel Get(int id)
        {
            if (_context.Carousels.Count(x => x.Id == id) > 0)
            {
                return _context.Carousels.Include(c => c.Section).FirstOrDefault(x => x.Id == id);
            }

            return null;
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
                var carousel = Get(item.Id);
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