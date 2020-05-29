using System;
using System.Collections.Generic;
using Core.Models;

namespace Infrastructure.Interfaces
{
    public interface IMoviesRepository : IRepository<Movie>
    {
        List<Movie> GetMoviesByGenre(Genre? genre);
        Movie AddPromoCode(PromoCode promoCode);
    }
}
