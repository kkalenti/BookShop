using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Models
{
    public class Address
    {
        [Required]
        [DisplayName("Address line 1")]
        public string Address1 { get; set; }

        [DisplayName("Address line 2")]
        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Zip { get; set; }

        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        public List<SelectListItem> Countries { get; set; }
    }
}
