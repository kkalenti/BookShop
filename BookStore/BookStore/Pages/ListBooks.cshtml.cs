using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages
{
    public class ListBooksModel : PageModel
    {
        private readonly BookStoreDbContext _context;

        public ListBooksModel(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<Book> Books { get; set; }

        public void OnGet()
        {
            Books = _context.Books.ToList();
        }
    }
}