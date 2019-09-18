using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyMovies.Pages
{
    public class IndexModel : PageModel
    {
        public string MovieList { get; private set; }

        public void OnGet()
        {
            
        }        
    }
}
