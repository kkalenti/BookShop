using System.Collections.Generic;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private List<Book> _book;

        public HomeController()
        {
            _book = new List<Book>
            {
                new Book()
                {
                    Title = "C# 8.0 and .NET Core 3.0 - Modern Cross-Platform Development",
                    Description = "Learn the fundamentals, practical applications, and latest" +
                                  " features of C# 8.0 and .NET Core 3.0 from expert teacher Mark J. Price.",
                    Author = "Mark J. Price",
                    PublishDate = "Oct, 2019",
                    Price = 35.99,
                    Image = "image1"
                },
                new Book()
                {
                    Title = "Pro ASP.NET Core MVC 2, 7th ed. Edition",
                    Description = "Develop cloud-ready web applications using Microsoft's latest framework," +
                                  "ASP.NET Core MVC 2",
                    Author = "Adam Freeman",
                    PublishDate = "October 25, 2017",
                    Price = 20.79,
                    Image = "image2"
                }
            };
        }

        /// <summary>
        /// The home page
        /// </summary>
        /// <returns>Index view</returns>
        public IActionResult Index()
        {
            return View(_book);
        }

        /// <summary>
        /// The about page
        /// </summary>
        /// <returns>About view</returns>
        public IActionResult About()
        {
            return View();
        }

        /// <summary>
        /// The contact us page
        /// </summary>
        /// <returns>Contact view</returns>
        public IActionResult Contact()
        {
            return View();
        }
    }
}