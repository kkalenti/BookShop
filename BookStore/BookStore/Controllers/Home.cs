using System.Collections.Generic;
using System.Linq;
using BookStore.Models;
using BookStore.Services;
using BookStore.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
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
        /// Interface for Sections repository
        /// </summary>
        private readonly IRepository<Section> _sectionsRepo;

        /// <summary>
        /// Constructor for <see cref="HomeController"/> class
        /// </summary>
        public HomeController(IRepository<Book> book, IRepository<Carousel> carousel, IRepository<Order> order,
            IRepository<Section> section)
        {
            _bookRepo = book;
            _carouselRepo = carousel;
            _ordersRepo = order;
            _sectionsRepo = section;
        }

        /*/// <summary>
        /// Get method to add book
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Addbook()
        {
            return View();
        }

        /// <summary>
        /// Post method to add book
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Addbook(Book book)
        {
            if (ModelState.IsValid)
            {
                var item = new Book()
                {
                    Id = _bookRepo.GetAll().Max(x => x.Id) + 1,
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    PublishDate = book.PublishDate,
                    Price = book.Price
                };
                _bookRepo.Create(item);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }*/

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

        public IActionResult SectionDetails(int id)
        {
            var section = _sectionsRepo.Get(id);
            return View(section);
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

        [HttpGet]
        public IActionResult Register()
        {
            var model = new Registration();
            return View("Register" ,model);
        }

        [HttpPost]
        public IActionResult Register(Registration registration)
        {
            return View("Register",registration);
        }

        public IActionResult EmailValidation(string email)
        {
            List<string> emails = new List<string>()
            {
                "test1@test.com"
            };

            if (emails.Exists(x => x.Equals(email)))
            {
                return Json("Email already exists");
            }
            return Json(true);
        }
    }
}