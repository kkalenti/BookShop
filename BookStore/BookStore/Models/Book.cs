namespace BookStore.Models
{
    public class Book
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string PublishDate { get; set; }
        
        public double Price { get; set; }
        
        public string Image { get; set; }
    }
}