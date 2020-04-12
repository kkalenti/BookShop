using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IRepository<Book> _bookRepository;
        private ILogger<BookController> _logger;

        public BookController(IRepository<Book> bookRepository, ILogger<BookController> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        // GET: api/Book
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_bookRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError("Get all error:" + ex.Message);
                return NotFound();
            }
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_bookRepository.Get(id));
            }
            catch (Exception ex)
            {
                _logger.LogError("Get by id error:" + ex.Message);
                return NotFound();
            }
        }

        // POST: api/Book
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid model state.");
                    return BadRequest();
                }
                else
                {
                    _bookRepository.Create(book);
                    return Created($"api/book/{book.Id}", book);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception adding new book:" + ex.Message);
                return BadRequest();
            }
        }

        // PUT: api/Book/5
        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid model state.");
                    return BadRequest();
                }
                else
                {
                    _bookRepository.Update(book);
                    return Ok(book);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception updating book:" + ex.Message);
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var deletedBook = _bookRepository.Get(id);
                if (deletedBook != null)
                {
                    _bookRepository.Delete(deletedBook);
                    return Ok("Book deleted");
                }

                return BadRequest("Could not delete book");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception deleting book:" + ex.Message);
                return BadRequest();
            }
        }
    }
}
