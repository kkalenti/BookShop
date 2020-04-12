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
            //TODO: 
            try
            {
                var book = Get(item.Id);
                if (book != null)
                {
                    book.Author = item.Author;
                    book.BookSection = item.BookSection;
                    book.Description = item.Description;
                    book.Image = item.Image;
                    book.Price = item.Price;
                    book.PublishDate = item.PublishDate;
                    book.Title = item.Title;
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
    }
}