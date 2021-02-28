using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class Books
        //the following are all the differet fields for the model
        //ISBN needs to follow a certain format
        //all properties are required
    {
        //comment
        [Key]
        public int BookID { get; set; }
        [Required(ErrorMessage ="Please enter all fields")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter all fields")]
        public string AuthorFirst { get; set; }
        [Required(ErrorMessage = "Please enter all fields")]
        public string AuthorMiddle { get; set; } = "";
        [Required(ErrorMessage = "Please enter all fields")]
        public string AuthorLast { get; set; }
        [Required(ErrorMessage = "Please enter all fields")] 
        public string Publisher { get; set; }
        [Required(ErrorMessage = "Please enter all fields")] 
        [RegularExpression(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Please enter all fields")] 
        public string Classification { get; set; }
        [Required(ErrorMessage = "Please enter all fields")] 
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter all fields")] 
        public float Price { get; set; }
        [Required(ErrorMessage = "Please enter all fields")]
        public int PagesNum { get; set; }



    }
}
