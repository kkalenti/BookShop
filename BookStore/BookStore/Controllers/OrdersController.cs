using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Order> _orderRepository;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(UserManager<User> userManager, IRepository<Order> orderRepository, ILogger<OrdersController> logger)
        {
            _userManager = userManager;
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            if (User.IsInRole("Admin"))
            {
                return View(_orderRepository.GetAll());
            }
            else
            {
                if (!_orderRepository.GetAll().Any())
                {
                    return View();
                }
                return View(_orderRepository.GetAll().Where(x =>x.User != null &&  x.User.Id == user.Id));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }
            var order = _orderRepository.Get(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            var order = _orderRepository.Get(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Books/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var order = _orderRepository.Get(id);
                _orderRepository.Delete(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}