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

        public int SectionId { get; set; }

        public Section Section { get; set; }
    }
}