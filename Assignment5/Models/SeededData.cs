using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class SeededData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BooksDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<BooksDbContext>();
            //if any migrations need to happen, then migrate

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Books.Any())
            //seeded data!
            {
                context.Books.AddRange(
                    new Books
                    {
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification= "Fiction",
                        Category = "Classic",
                        Price = 9.95F,
                        PagesNum= 1448
                    },
                    new Books
                    {
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris",
                        AuthorMiddle = "Kearns",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58F,
                        PagesNum = 944
                    },
                    new Books
                    {
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54F,
                        PagesNum = 832
                    },
                    new Books
                    {
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald",
                        AuthorMiddle = "C.",
                        AuthorLast = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61F,
                        PagesNum = 864
                    },
                    new Books
                    {
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33F,
                        PagesNum = 528
                    },
                    new Books
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorLast = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical",
                        Price = 15.95F,
                        PagesNum = 288
                    },
                    new Books
                    {
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99F,
                        PagesNum = 304
                    },
                    new Books
                    {
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael",
                        AuthorLast = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66F,
                        PagesNum = 240
                    },
                    new Books
                    {
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorLast = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16F,
                        PagesNum = 400
                    },
                    new Books
                    {
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03F,
                        PagesNum = 642
                    },
                        new Books
                        {
                            Title = "The Mysterious Benedict Society",
                            AuthorFirst = "Trenton",
                            AuthorMiddle= "Lee",
                            AuthorLast = "Stewart",
                            Publisher = "Little, Brown and Company",
                            ISBN = "978-6003956456",
                            Classification = "Fiction",
                            Category = "Mystery",
                            Price = 9.83F,
                            PagesNum = 512
                        },
                        new Books
                        {
                            Title = "Jane Eyre",
                            AuthorFirst = "Charlotte",
                            AuthorLast = "Bronte",
                            Publisher = "Smith, Elder & Co.",
                            ISBN = "978-0141441146",
                            Classification = "Fiction",
                            Category = "Classic",
                            Price = 4.99F,
                            PagesNum = 480
                        },
                        new Books
                        {
                            Title = "Where the Red Fern Growsw",
                            AuthorFirst = "Wilson",
                            AuthorLast = "Rawls",
                            Publisher = "Doubleday",
                            ISBN = "978-0440412670",
                            Classification = "Fiction",
                            Category = "Classic",
                            Price = 6.19F,
                            PagesNum = 304
                        }

                    );
                //save data
                context.SaveChanges();
            }
        }
    }
}
