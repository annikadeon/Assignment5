using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment5.Infrastructure;
using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment5.Pages
{
    //adding data into the model
    public class ShoppingModel : PageModel
    {
        private BooksRepository _repository;
        //constructor
        public ShoppingModel (BooksRepository repo, Cart cartService)
        {
            _repository = repo;
            Cart = cartService;
        }
        //prperties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } 
        //methods
        public void OnGet(string returnUrl)
        {
            //if null, set = to /
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost (long bookID, string returnUrl)
        {
            //book doesnt use _
            Books book = _repository.Books
                .FirstOrDefault(b => b.BookID == bookID);
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(book, 1);
            //HttpContext.Session.SetJson("cart", Cart);
            //redirect to new page
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        //to remove item from cart
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            //Books book = _repository.Books
            //    .FirstOrDefault(b => b.BookID == bookId);
            Cart.RemoveLine(Cart.Lines.First(cl =>
            cl.Book.BookID == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
