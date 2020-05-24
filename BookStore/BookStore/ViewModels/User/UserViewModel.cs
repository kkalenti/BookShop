using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BookStore.ViewModels.Roles;

namespace BookStore.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [DisplayName("User Name")]
        [Required, MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public List<RolesViewModel> UserInRole { get; set; }

        [DisplayName("Is user Locked out")]
        public bool IsLockedOut { get; set; }
    }
}