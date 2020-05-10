using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a book")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Client name is required")]
        [DataType(DataType.Text)]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [DataType(DataType.Text)]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is required")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [DataType(DataType.Text)]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [DataType(DataType.Text)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        public User User { get; set; }

    }
}