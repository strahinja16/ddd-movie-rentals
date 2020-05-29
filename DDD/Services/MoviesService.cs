using System;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Interfaces;
using WebApi.Exceptions;
using WebApi.Interfaces;

namespace WebApi.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            this.moviesRepository = moviesRepository;
        }

        public Movie GetMovieById(Guid id)
        {
            var movie = moviesRepository.FindById(id);

            if (movie == null)
            {
                throw new HttpException("Movie not found.", HttpStatus.NotFound);
            }

            return movie;
        }

        public List<Movie> GetMovies(Genre? genre)
        {
            return moviesRepository.GetMoviesByGenre(genre);
        }
    }
}
