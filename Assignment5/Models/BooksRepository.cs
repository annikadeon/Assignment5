using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    //inherit from interface as a template
    public interface BooksRepository
    {
        IQueryable<Books> Books { get; }
    }
}
