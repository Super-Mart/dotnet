using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyMovies.Models
{
    public class MyMoviesContext : DbContext
    {
        public MyMoviesContext (DbContextOptions<MyMoviesContext> options)
            : base(options)
        {
        }

        public DbSet<MyMovies.Models.Movie> Movie { get; set; }
    }
}
