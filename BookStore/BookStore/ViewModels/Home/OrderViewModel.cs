using BookStore.Models;

namespace BookStore.ViewModels.Home
{
    public class OrderViewModel
    {
        /// <summary>
        /// Ordered book
        /// </summary>
        public Book BookToOrder { get; set; }

        /// <summary>
        /// Order details
        /// </summary>
        public Order OrderDetails { get; set; }

    }
}