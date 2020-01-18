namespace BookStore.Models
{
    /// <summary>
    /// Element for carousel in the view
    /// </summary>
    public class Carousel
    {
        /// <summary>
        /// Carousel element Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Image for carousel element
        /// </summary>
        public string ImageUrl { get; set; } 

        /// <summary>
        /// Carousel element title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Carousel element description
        /// </summary>
        public string Description { get; set; }
    }
}