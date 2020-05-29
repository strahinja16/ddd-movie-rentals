using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Movie AddPromoCode(PromoCode promoCode)
        {
            var movie = context.Movies.Find(promoCode.MovieId);

            movie.AddPromoCode(promoCode);

            context.Add(promoCode);
            context.SaveChanges();

            return movie;
        }

        public Movie FindById(Guid id)
        {
            return context.Movies
                .Include(m => m.PromoCodes)
                .Where(m => m.Id == id)
                .FirstOrDefault();
        }

        public List<Movie> GetMoviesByGenre(Genre? genre)
        {
            if (!genre.HasValue)
            {
                return context.Movies
                    .OrderByDescending(m => m.CreatedAt)
                    .ToList();
            }

            return context.Movies.Where(m => m.Genre == genre.Value).ToList();
        }
    }
}
