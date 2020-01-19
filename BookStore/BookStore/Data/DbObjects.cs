using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using BookStore.Models;

namespace BookStore.Data
{
    public class DbObjects
    {
        /// <summary>
        /// Initializes data in the DataBase
        /// </summary>
        /// <param name="context">DB context</param>
        public static void Initial(BookStoreDbContext context)
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(Books.Select(c => c.Value));
            }

            if (!context.Sections.Any())
            {
                context.Sections.AddRange(Section.Select(c => c.Value));
            }

            if (!context.Carousels.Any())
            {
                context.Carousels.AddRange(Carousel.Select(c => c.Value));
            }

            context.SaveChanges();
        }

        /// <summary>
        /// Stores a list of books
        /// 
        /// </summary>
        private static Dictionary<string, Book> _books;

        /// <summary>
        /// Gets a list of books
        /// </summary>
        public static Dictionary<string, Book> Books
        {
            get
            {
                if (_books == null)
                {
                    var list = new Book[]
                    {
                        new Book() {
                            Title = "C# 8.0 and .NET Core 3.0 - Modern Cross-Platform Development",
                            Description = "Learn the fundamentals, practical applications, and latest features of C# 8.0 and .NET Core 3.0 from expert teacher Mark J. Price.",
                            Author = "Mark J. Price",
                            PublishDate = "October 2019",
                            Image = "00.jpg",
                            Price = 35.99,
                        },
                        new Book() {
                            Title = "Pro ASP.NET Core MVC 2, 7th ed. Edition",
                            Description = "Develop cloud-ready web applications using Microsoft's latest framework, ASP.NET Core MVC 2",
                            Author = "Adam Freeman",
                            PublishDate = "October 2017",
                            Image = "01.jpg",
                            Price = 20.79,
                        },
                        new Book() {
                            Title = "Pro C# 7: With .NET and .NET Core, 8th ed. Edition",
                            Description = "This essential classic title provides a comprehensive foundation in the C# programming language and the frameworks it lives in.",
                            Author = "Andrew Troelsen, Philip Japikse",
                            PublishDate = "November 2017",
                            Image = "02.jpg",
                            Price = 38,
                        },
                        new Book() {
                            Title = "CLR via C# (4th Edition)",
                            Description = "Dig deep and master the intricacies of the common language runtime, C#, and .NET development. Led by programming expert Jeffrey Richter, a longtime consultant to the Microsoft .NET team - you’ll gain pragmatic insights for building robust, reliable, and responsive apps and components.",
                            Author = "Jeffrey Richter",
                            PublishDate = "November 2012",
                            Image = "03.jpg",
                            Price = 55.11,
                        },
                        new Book() {
                            Title = "C# in Depth, 4th Edition",
                            Description = "C# in Depth, Fourth Edition is your key to unlocking the powerful new features added to the language in C# 5, 6, and 7. Following the expert guidance of C# legend Jon Skeet, you'll master asynchronous functions, expression-bodied members, interpolated strings, tuples, and much more.",
                            Author = "Jon Skeet",
                            PublishDate = "March 2019",
                            Image = "04.jpg",
                            Price = 34.77,
                        },
                        new Book() {
                            Title = "Learn C# in One Day and Learn It Well: C# for Beginners with Hands-on Project (Learn Coding Fast with Hands-On Project) (Volume 3)",
                            Description = "Have you always wanted to learn computer programming but are afraid it'll be too difficult for you? Or perhaps you know other programming languages but are interested in learning the C# language fast? This book is for you.You no longer have to waste your time and money learning C# from boring books that are 600 pages long, expensive online courses or complicated C# tutorials that just leave you more confused.",
                            Author = "Jamie Chan",
                            PublishDate = "October 2015",
                            Image = "05.jpg",
                            Price = 11.3,
                        },
                        new Book() {
                            Title = "ASP.NET Core in Action",
                            Description = "ASP.NET Core in Action is for C# developers without any web development experience who want to get started and productive fast using ASP.NET Core 2.0 to build web applications.",
                            Author = "Andrew Lock",
                            PublishDate = "July 2018",
                            Image = "06.jpg",
                            Price = 43.39,
                        },
                        new Book() {
                            Title = "Clean Code: A Handbook of Agile Software Craftsmanship",
                            Description = "This book is a must for any developer, software engineer, project manager, team lead, or systems analyst with an interest in producing better code.",
                            Author = "Robert Martin",
                            PublishDate = "July 2018",
                            Image = "07.jpg",
                            Price = 31.88,
                        },
                        new Book() {
                            Title = "Introduction to Algorithms, 3rd Edition",
                            Description = "The latest edition of the essential text and professional reference, with substantial new material on such topics as vEB trees, multithreaded algorithms, dynamic programming, and edge-based flow.",
                            Author = "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, Clifford Stein",
                            PublishDate = "July 2009",
                            Image = "08.jpg",
                            Price = 49.95,
                        },
                    };

                    _books = new Dictionary<string, Book>();

                    foreach (var element in list)
                    {
                        _books.Add(element.Title, element);
                    }

                }
                return _books;
            }
        }

        /// <summary>
        /// Stores a list of sections
        /// </summary>
        private static Dictionary<string, Section> _section;

        /// <summary>
        /// Gets  a list of sections
        /// </summary>
        public static Dictionary<string, Section> Section
        {
            get
            {
                if (_section == null)
                {
                    var list = new Section[]
                    {
                        new Section() {
                            Title = "Discount books",
                            Description = "Discount books, get them all."
                        },
                        new Section() {
                            Title = "New books",
                            Description = "All brand new books."
                        },
                        new Section() {
                            Title = "Subscriptions",
                            Description = "Discount on monthly subscriptions."
                        }
                    };

                    _section = new Dictionary<string, Section>();

                    foreach (var element in list)
                    {
                        _section.Add(element.Title, element);
                    }

                }
                return _section;
            }
        }

        /// <summary>
        /// Stores a list of carousel items
        /// </summary>
        private static Dictionary<string, Carousel> _carousel;

        /// <summary>
        /// Gets a list of carousel items
        /// </summary>
        public static Dictionary<string, Carousel> Carousel
        {
            get
            {
                if (_carousel == null)
                {
                    var list = new Carousel[]
                    {
                        new Carousel() {
                            ImageUrl = "Carousel1.jpg",
                            Section = Section["Discount books"]
                        },
                        new Carousel() {
                            ImageUrl = "Carousel2.jpg",
                            Section = Section["New books"]
                        },
                        new Carousel() {
                            ImageUrl = "Carousel3.jpg",
                            Section = Section["Subscriptions"]
                        }
                    };

                    _carousel = new Dictionary<string, Carousel>();

                    foreach (var element in list)
                    {
                        _carousel.Add(element.Section.Title, element);
                    }

                }
                return _carousel;
            }
        }
    }
}