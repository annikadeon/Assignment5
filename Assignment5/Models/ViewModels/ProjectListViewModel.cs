using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models.ViewModels
{
    //any view with data uses this view model
    public class ProjectListViewModel
    {
        public IEnumerable<Books> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}

