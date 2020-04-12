using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Models
{
    public class Registration
    {
        /// <summary>
        /// Id of registration
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// First name for user
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name for User
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Email for user
        /// </summary>
        [EmailAddress]
        [Required]
        [Remote("EmailValidation", "Home")]
        public string Email { get; set; }

        /// <summary>
        /// User address
        /// </summary>
        public Address MailAddress { get; set; }
    }
}