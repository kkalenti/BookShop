using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Services;
using BookStore.ViewModels.Home;
using Microsoft.AspNetCore.Identity;
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

        private readonly UserManager<User> _userManager;

        private readonly IRepository<Comment> _commentRepository;

        /// <summary>
        /// Constructor for <see cref="HomeController"/> class
        /// </summary>
        public HomeController(IRepository<Book> book, IRepository<Carousel> carousel, IRepository<Order> order,
            IRepository<Section> section, UserManager<User> userManager, IRepository<Comment> commentRepository)
        {
            _bookRepo = book;
            _carouselRepo = carousel;
            _ordersRepo = order;
            _sectionsRepo = section;
            _userManager = userManager;
            _commentRepository = commentRepository;
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
        [HttpGet]
        public ViewResult Details(int id)
        {
            var book = _bookRepo.Get(bookModel => bookModel.Id == id).FirstOrDefault();
            var comments = _commentRepository.Get(filter: commentModel => commentModel.Book.Id == book.Id, "User").ToList();
            var model = new DetailsViewModel()
            {
                Book = book,
                Comments = comments
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ViewResult> Details(int id, DetailsViewModel details)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var comment = details.NewComment;
            var book = _bookRepo.Get(bookModel => bookModel.Id == id).FirstOrDefault();

            comment.User = user;
            comment.Book = book;

            _commentRepository.Create(comment);

            var comments = _commentRepository
                .Get(filter: commentModel => commentModel.Book.Id == book.Id, "User").ToList();
            var model = new DetailsViewModel()
            {
                Book = book,
                Comments = comments
            };
            return View(model);
        }

        public IActionResult SectionDetails(int id)
        {
            var section = _sectionsRepo.Get(model => model.Id == id).FirstOrDefault();
            return View(section);
        }

        [HttpGet]
        public async Task<IActionResult> Order(int? id)
        {
            if (id != null && id >= 0)
            {
                var model = new OrderViewModel()
                {
                    BookToOrder = _bookRepo.Get(model => model.Id == id.Value).FirstOrDefault(),
                    OrderDetails = new Order()
                    {
                        BookId = (int)id,

                    },
                };

                if (User.Identity.IsAuthenticated)
                {
                    var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                    model.OrderDetails.Email = user.Email;
                    model.OrderDetails.Phone = user.PhoneNumber;
                    model.OrderDetails.ClientName = user.FirstName + " " + user.LastName;
                }
                
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
                    BookToOrder = _bookRepo.Get(model => model.Id == id).FirstOrDefault()
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