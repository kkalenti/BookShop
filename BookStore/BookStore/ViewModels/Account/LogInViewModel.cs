using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Account
{
    public class LogInViewModel
    {

        [DisplayName("User Name")]
        [Required, MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember me")]
        public bool RememberMe { get; set; }
    }
}