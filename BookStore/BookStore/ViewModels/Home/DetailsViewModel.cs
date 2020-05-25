using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.ViewModels.Home
{
    public class DetailsViewModel
    {
        public Book Book { get; set; }

        public List<Comment> Comments { get; set; }

        public Comment NewComment { get; set; }
    }
}