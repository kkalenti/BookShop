using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.User
{
    public class ChangePasswordViewModel
    {
        [DisplayName("Old password")]
        [Required, DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [DisplayName("New password")]
        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName("Confirm new password")]
        [Required, DataType(DataType.Password), Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }

    }
}