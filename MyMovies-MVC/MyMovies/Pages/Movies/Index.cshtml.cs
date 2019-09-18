using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMovies.Models;

namespace MyMovies.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MyMovies.Models.MyMoviesContext _context;

        public IndexModel(MyMovies.Models.MyMoviesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList RD { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MRD { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby String.Format(m.ReleaseDate.ToString("MM/dd/yyyy"))
                                            select String.Format(m.ReleaseDate.ToString("MM/dd/yyyy"));
                                            
            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!String.IsNullOrEmpty(MRD))
            {
                movies = movies.Where(x => String.Format(x.ReleaseDate.ToString("MM/dd/yyyy")) == MRD);
            }
            RD = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
