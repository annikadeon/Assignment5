using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class EFBooksRepository : BooksRepository
    {
        //create type context
        private BooksDbContext _context;
        //constructor, pass context file
        public EFBooksRepository (BooksDbContext context)
        {
            _context = context;
        }
        //books are set to the _context.Books 
        public IQueryable<Books> Books => _context.Books;

    }
}
