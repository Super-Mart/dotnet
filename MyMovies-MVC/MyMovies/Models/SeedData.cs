using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MyMovies.Models
{
    public class SeedData
    {        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyMoviesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyMoviesContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "17 Miracles",
                        ReleaseDate = DateTime.Parse("2011-6-3"),
                        Genre = "Adventure History",
                        Price = 14.99M,
                        Rating = "PG"
                    },

                    new Movie
                    {
                        Title = "The Book of Mormon Movie, Volume 1: The Journey",
                        ReleaseDate = DateTime.Parse("2004-1-12"),
                        Genre = "Adventure",
                        Price = 9.99M,
                        Rating = "PG-13"
                    },

                    new Movie
                    {
                        Title = "Legacy",
                        ReleaseDate = DateTime.Parse("1993-7-3"),
                        Genre = "Drama History Western",
                        Price = 11.94M,
                        Rating = "NA"
                    },

                    new Movie
                    {
                        Title = "The Testaments: Of One Fold and One Shepherd",
                        ReleaseDate = DateTime.Parse("2000-3-24"),
                        Genre = "Drama",
                        Price = 4.50M,
                        Rating = "NA"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
