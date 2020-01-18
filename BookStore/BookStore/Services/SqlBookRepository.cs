using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Services
{
    public class SqlBookRepository:IRepository<Book>
    {
        private BookStoreDbContext _context;

        public SqlBookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public Book Get(int id)
        {
            if(_context.Books.Count(x=>x.Id == id) > 0) {
                return _context.Books.FirstOrDefault(x => x.Id == id);
            }

            return null;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        public bool Create(Book item)
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

        public bool Delete(Book item)
        {
            try
            {
                var book = Get(item.Id);
                if (book != null)
                {
                    _context.Remove(book);
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

        public bool Update(Book item)
        {
            throw new System.NotImplementedException();
        }
    }
}