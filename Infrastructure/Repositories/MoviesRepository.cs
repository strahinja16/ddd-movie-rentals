using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly RentalDbContext context;

        public MoviesRepository(RentalDbContext context)
        {
            this.context = context;
        }
     
        public void Add(Movie entity)
        {
            context.Movies.Add(entity);
        }

        public Movie FindById(Guid id)
        {
            return context.Movies.Find(id);
        }

        public List<Movie> GetMoviesByGenre(Genre? genre)
        {
            if (!genre.HasValue)
            {
                return context.Movies
                    .OrderByDescending(m => m.CreatedAt)
                    .Take(5)
                    .ToList();
            }

            return context.Movies.Where(m => m.Genre == genre.Value).ToList();
        }
    }
}
