namespace BookStore.Models
{
    /// <summary>
    /// Class for different sections in the store (example: new books, subscriptions, etc)
    /// </summary>
    public class Sections
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

    }
}