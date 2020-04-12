using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        /// <summary>
        /// Book Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Book Title
        /// </summary>
        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Book Title"), MinLength(2,ErrorMessage = "Minimum length is 2 chars")]
        public string Title { get; set; }

        /// <summary>
        /// Book description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Bok author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Book publish date
        /// </summary>
        public string PublishDate { get; set; }

        /// <summary>
        /// Book price
        /// </summary>
        [DataType(DataType.Currency, ErrorMessage = "Please enter correct price")] 
        public double Price { get; set; }

        /// <summary>
        /// Image for book
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Binding entity for <see cref="Book"/> and <see cref="Section"/> classes
        /// </summary>
        public List<BookSection> BookSection { get; set; }

        /// <summary>
        /// Constructor of the <see cref="Book"/> class
        /// </summary>
        public Book()
        {
            BookSection = new List<BookSection>();
        }
    }
}