using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Account
{
    public class RegistrationViewModel
    {
        [DisplayName("User Name")]
        [Required, MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("ConfirmPassword")]
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }


    }
}