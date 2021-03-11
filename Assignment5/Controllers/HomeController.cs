using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment5.Models.ViewModels;

namespace Assignment5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BooksRepository _repository;
        //pass the repository and then give it to the view
        //declare variable of amount of books on each page (5)
        public int PageSize = 5;
        public HomeController(ILogger<HomeController> logger, BooksRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            return View(new ProjectListViewModel
            {
                Books = _repository.Books
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.BookID)
                .Skip((pageNum - 1) * PageSize)
                .Take(PageSize),
                //new page infor object
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    //if null, normal amount of items. otherwise, count the category
                    TotalNumItems = category == null ? _repository.Books.Count() :
                        _repository.Books.Where(x => x.Category == category).Count()

                },
                    Category = category
            });

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
