using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Models;

namespace BookStore.Services
{
    public class MockBooksRepository : IRepository<Book>
    {
        private readonly List<Book> _books;

        public MockBooksRepository()
        {
            _books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "C# 8.0 and .NET Core 3.0 - Modern Cross-Platform Development",
                    Description = "Learn the fundamentals, practical applications, and latest" +
                                  " features of C# 8.0 and .NET Core 3.0 from expert teacher Mark J. Price.",
                    Author = "Mark J. Price",
                    PublishDate = "October 2019",
                    Price = 35.99,
                    Image = "image1"
                },
                new Book()
                {
                    Id = 2,
                    Title = "Pro ASP.NET Core MVC 2, 7th ed. Edition",
                    Description = "Develop cloud-ready web applications using Microsoft's latest framework," +
                                  "ASP.NET Core MVC 2",
                    Author = "Adam Freeman",
                    PublishDate = "October 2017",
                    Price = 20.79,
                    Image = "image2"
                },
                new Book()
                {
                    Id = 3,
                    Title = "Pro C# 7: With .NET and .NET Core, 8th ed. Edition",
                    Description = "This essential classic title provides a comprehensive foundation in the C# " +
                                  "programming language and the frameworks it lives in.",
                    Author = "Andrew Troelsen, Philip Japikse",
                    PublishDate = "November 2017",
                    Price = 38,
                    Image = "image3"
                }
            };

        }

        public Book Get(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _books.ToList();
        }

        public bool Add(Book item)
        {
            try
            {
                var book = item;
                book.Id = _books.Max(x => x.Id) + 1;
                _books.Add(book);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Delete(Book item)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(Book item)
        {
            throw new System.NotImplementedException();
        }
    }
}