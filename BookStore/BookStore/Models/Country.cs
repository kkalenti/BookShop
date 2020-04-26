using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<SelectListItem> GetCountrySelectList(IEnumerable<Country> countries)
        {
            return countries.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }
    }
}