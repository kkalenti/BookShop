using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class SqlSectionRepository: IRepository<Section>
    {
        private BookStoreDbContext _context;

        public SqlSectionRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public Section Get(int id)
        {
            if (_context.Sections.Count(x => x.Id == id) > 0)
            {
                return _context.Sections.Include(s=>s.BookSection).ThenInclude(bs=> bs.Book).
                    FirstOrDefault(x => x.Id == id);
            }

            return null;
        }

        public IEnumerable<Section> GetAll()
        {
            return _context.Sections.Include(s => s.BookSection).ThenInclude(bs => bs.Book).ToList();
        }

        public bool Create(Section item)
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

        public bool Delete(Section item)
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

        public bool Update(Section item)
        {
            throw new System.NotImplementedException();
        }
    }
}