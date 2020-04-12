namespace BookStore.Models
{
    public class BookSection
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; }
    }
}