using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment5.Models;

namespace WaterProject.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private BooksRepository repository;
        public NavigationMenuViewComponent(BooksRepository r)
        {
            repository = r;
        }

        public IViewComponentResult Invoke()
        {
            //build viewbag component for the nav menu- so you can see what's being highlited
            ViewBag.SelectedCat = RouteData?.Values["category"];
            //all received in default.cshtml
            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
                );
        }
    }
}
