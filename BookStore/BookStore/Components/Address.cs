using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Components
{
    public class Address : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var address = new Models.Address();
            //{
            //    Countries = new List<SelectListItem>()
            //    {
            //        new SelectListItem(text: "1 Country", value: "1 Country", selected: true),
            //        new SelectListItem(text: "2 Country", value: "2 Country"),
            //        new SelectListItem(text: "3 Country", value: "3 Country"),
            //        new SelectListItem(text: "4 Country", value: "4 Country"),
            //        new SelectListItem(text: "5 Country", value: "5 Country"),
            //        new SelectListItem(text: "6 Country", value: "6 Country"),
            //        new SelectListItem(text: "7 Country", value: "7 Country"),
            //    }
            //};
            return View(address);
        }
    }
}
