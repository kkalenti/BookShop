using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        /// <summary>
        /// List of books
        /// </summary>
        public IEnumerable<Book> Books { get; set; }

        /// <summary>
        /// List of carousel elements
        /// </summary>
        public IEnumerable<Carousel> Carousels { get; set; }
    }
}