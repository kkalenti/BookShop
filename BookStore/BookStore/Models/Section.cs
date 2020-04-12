using System.Collections.Generic;

namespace BookStore.Models
{
    /// <summary>
    /// Class for different sections in the store (example: new books, subscriptions, etc)
    /// </summary>
    public class Section
    {
        /// <summary>
        /// Section id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Section title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Section description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Сarousel that section refers to
        /// </summary>
        public Carousel Carousel { get; set; }

        /// <summary>
        /// Binding entity for <see cref="Book"/> and <see cref="Section"/> classes
        /// </summary>
        public List<BookSection> BookSection { get; set; }

        /// <summary>
        /// Constructor for the <see cref="Section"/> class
        /// </summary>
        public Section()
        {
            BookSection = new List<BookSection>();
        }

    }
}