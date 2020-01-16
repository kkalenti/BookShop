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
                    Image = "00.jpg"
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
                    Image = "01.jpg"
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
                    Image = "02.jpg"
                },
                new Book()
                {
                    Id = 4,
                    Title = "CLR via C# (4th Edition)",
                    Description = "Dig deep and master the intricacies of the common language runtime, C#, and" +
                                  " .NET development. Led by programming expert Jeffrey Richter, a longtime" +
                                  " consultant to the Microsoft .NET team - you’ll gain pragmatic insights for" +
                                  " building robust, reliable, and responsive apps and components.",
                    Author = "Jeffrey Richter",
                    PublishDate = "November 2012",
                    Price = 55.11,
                    Image = "03.jpg"
                },
                new Book()
                {
                    Id = 5,
                    Title = "C# in Depth, 4th Edition",
                    Description = "C# in Depth, Fourth Edition is your key to unlocking the powerful new features" +
                                  " added to the language in C# 5, 6, and 7. Following the expert guidance of C# " +
                                  "legend Jon Skeet, you'll master asynchronous functions, expression-bodied members," +
                                  " interpolated strings, tuples, and much more.",
                    Author = "Jon Skeet",
                    PublishDate = "March 2019",
                    Price = 34.77,
                    Image = "04.jpg"
                },
                new Book()
                {
                    Id = 6,
                    Title = "Learn C# in One Day and Learn It Well: C# for Beginners with Hands-on Project " +
                            "(Learn Coding Fast with Hands-On Project) (Volume 3)",
                    Description = "Have you always wanted to learn computer programming but are afraid it'll be" +
                                  " too difficult for you? Or perhaps you know other programming languages but " +
                                  "are interested in learning the C# language fast? This book is for you.You no" +
                                  " longer have to waste your time and money learning C# from boring books that " +
                                  "are 600 pages long, expensive online courses or complicated C# tutorials that " +
                                  "just leave you more confused.",
                    Author = "Jamie Chan",
                    PublishDate = "October 2015",
                    Price = 11.3,
                    Image = "05.jpg"
                },
                new Book()
                {
                    Id = 7,
                    Title = "ASP.NET Core in Action ",
                    Description = "ASP.NET Core in Action is for C# developers without any web development experience" +
                                  " who want to get started and productive fast using ASP.NET Core 2.0 to build web" +
                                  " applications.",
                    Author = "Andrew Lock",
                    PublishDate = "July 2018",
                    Price = 43.39,
                    Image = "06.jpg"
                },
                new Book()
                {
                    Id = 8,
                    Title = "Clean Code: A Handbook of Agile Software Craftsmanship",
                    Description = "This book is a must for any developer, software engineer, project manager," +
                                  " team lead, or systems analyst with an interest in producing better code.",
                    Author = "Robert Martin",
                    PublishDate = "July 2018",
                    Price = 31.88,
                    Image = "07.jpg"
                },
                new Book()
                {
                    Id = 9,
                    Title = "Introduction to Algorithms, 3rd Edition",
                    Description = "The latest edition of the essential text and professional reference, with " +
                                  "substantial new material on such topics as vEB trees, multithreaded algorithms," +
                                  " dynamic programming, and edge-based flow.",
                    Author = "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, Clifford Stein",
                    PublishDate = "July 2009",
                    Price = 49.95,
                    Image = "08.jpg"
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