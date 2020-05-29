using System;
using System.Collections.Generic;
using Core.Models;

namespace WebApi.Interfaces
{
    public interface IMoviesService
    {
        List<Movie> GetMovies(Genre? genre);
        Movie GetMovieById(Guid id);
    }
}
