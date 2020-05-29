using System;
using System.Collections.Generic;
using Core.Models;
using WebApi.DTO;

namespace WebApi.Interfaces
{
    public interface IMoviesService
    {
        List<MovieDto> GetMovies(Genre? genre);
        MovieDto GetMovieById(Guid id);
    }
}
