using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        //add item to cart, pass the book and how many
        public virtual void AddItem (Books booook, int qty)
        {
            //compare book id, grab the first one from that group
            CartLine line = Lines
                .Where(b => b.Book.BookID == booook.BookID)
                .FirstOrDefault();
            //if you don't find anything in that list, add a new line
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = booook,
                    Quantity = qty
                });
            }
            //otherwise update line to include that
            else
            {
                line.Quantity += qty;
            }
        }
        //to remove an item
        public virtual void RemoveLine(Books booook) =>
            Lines.RemoveAll(x => x.Book.BookID == booook.BookID);
        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => e.Book.Price * e.Quantity);
        //price of book, cast it to a decimal
        public virtual void Clear() => Lines.Clear();


       
  
        public class CartLine
        {
            public int CartlineID { get; set; }
            public Books Book { get; set; }
            public int Quantity { get; set; }
        }
    }

}
