using System.Collections.Generic;
using System.Linq;
using BookStore.Models;
using BookStore.Services;
using BookStore.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// The list of books
        /// </summary>
        private List<Book> _book;

        /// <summary>
        /// Interface for Book repository
        /// </summary>
        private readonly IRepository<Book> _bookRepo;

        /// <summary>
        /// Interface for Carousel repository
        /// </summary>
        private readonly IRepository<Carousel> _carouselRepo;

        /// <summary>
        /// Interface for Order repository
        /// </summary>
        private readonly IRepository<Order> _ordersRepo;

        /// <summary>
        /// Constructor for <see cref="HomeController"/> class
        /// </summary>
        public HomeController(IRepository<Book> book, IRepository<Carousel> carousel, IRepository<Order> order)
        {
            _bookRepo = book;
            _carouselRepo = carousel;
            _ordersRepo = order;
        }

        ///// <summary>
        ///// Get method to add book
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public IActionResult Addbook()
        //{
        //    return View();
        //}

        ///// <summary>
        ///// Post method to add book
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //public IActionResult Addbook(Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var item = new Book()
        //        {
        //            Id = _bookRepo.GetAll().Max(x => x.Id) + 1,
        //            Title = book.Title,
        //            Description = book.Description,
        //            Author = book.Author,
        //            PublishDate = book.PublishDate,
        //            Price = book.Price
        //        };
        //        _bookRepo.Create(item);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View();
        //    }
            
        //}

        /// <summary>
        /// The home page
        /// </summary>
        /// <returns>Index view</returns>
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel()
            {
                Books = _bookRepo.GetAll(),
                Carousels = _carouselRepo.GetAll()
            };
            return View(model);
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

        /// <summary>
        /// Book details page
        /// </summary>
        /// <returns>Contact view</returns>
        public IActionResult Details(int id)
        {
            var book = _bookRepo.Get(id);
            return View(book);
        }

        [HttpGet]
        public IActionResult Order(int? id)
        {
            if (id != null && id >= 0)
            {
                var model = new OrderViewModel()
                {
                    BookToOrder = _bookRepo.Get((int)id),
                    OrderDetails = new Order()
                    {
                        BookId = (int)id
                    }
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Order(int id, Order orderDetails)
        {
            if (ModelState.IsValid)
            {
                if (_bookRepo.GetAll().Count(x => x.Id == id) >= 1)
                {
                    orderDetails.BookId = id;
                    _ordersRepo.Create(orderDetails);
                    
                    return RedirectToAction("ThankYou");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View(new OrderViewModel()
                {
                    OrderDetails = orderDetails,
                    BookToOrder = _bookRepo.Get(id)
                });
            }
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        public IActionResult OrderList()
        {
            return View(_ordersRepo.GetAll());
        }
    }
}