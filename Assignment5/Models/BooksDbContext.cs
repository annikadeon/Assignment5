using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//"hooks" you up to the database
namespace Assignment5.Models
{
    //inherit from system
    public class BooksDbContext : DbContext
    {
        //constructor that's called when the object is built the first time, inherits from base
        public BooksDbContext (DbContextOptions<BooksDbContext> options) : base(options)
        {

        }
        //create project of Books type (from models)
        public DbSet<Books> Books { get; set; }
    }
}
