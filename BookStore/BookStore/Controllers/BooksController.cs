using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly ILogger<BooksController> _logger;
        private readonly IWebHostEnvironment _environment;

        public BooksController(IRepository<Book> bookRepository, ILogger<BooksController> logger, IWebHostEnvironment environment)
        {
            _bookRepository = bookRepository;
            _logger = logger;
            _environment = environment;
        }

        // GET: Books
        public ActionResult Index()
        {
            return View(_bookRepository.GetAll());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            var book = _bookRepository.Get(model => model.Id == id.Value).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookRepository.Create(book);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            var book = _bookRepository.Get(model => model.Id == id.Value).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book book)
        {
            
            try
            {
                if (id != book.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    _bookRepository.Update(book);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            var book = _bookRepository.Get(model => model.Id == id.Value).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var book = _bookRepository.Get(model => model.Id == id).FirstOrDefault();
                _bookRepository.Delete(book);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}