using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Roles
{
    public class RolesViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool Selected { get; set; }
    }
}