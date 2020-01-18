using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Services
{
    public class SqlSectionRepository: IRepository<Sections>
    {
        private BookStoreDbContext _context;

        public SqlSectionRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public Sections Get(int id)
        {
            if (_context.Sections.Count(x => x.Id == id) > 0)
            {
                return _context.Sections.FirstOrDefault(x => x.Id == id);
            }

            return null;
        }

        public IEnumerable<Sections> GetAll()
        {
            return _context.Sections;
        }

        public bool Create(Sections item)
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

        public bool Delete(Sections item)
        {
            try
            {
                var section = Get(item.Id);
                if (section != null)
                {
                    _context.Remove(section);
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

        public bool Update(Sections item)
        {
            throw new System.NotImplementedException();
        }
    }
}