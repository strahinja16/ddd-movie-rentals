using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Models;
using Infrastructure.Interfaces;
using WebApi.DTO;
using WebApi.Exceptions;
using WebApi.Interfaces;

namespace WebApi.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository moviesRepository;
        private readonly IMapper mapper;

        public MoviesService(IMoviesRepository moviesRepository, IMapper mapper)
        {
            this.moviesRepository = moviesRepository;
            this.mapper = mapper;
        }

        public MovieDto GetMovieById(Guid id)
        {
            var movie = moviesRepository.FindById(id);

            if (movie == null)
            {
                throw new HttpException("Movie not found.", HttpStatus.NotFound);
            }

            return mapper.Map<MovieDto>(movie);
        }

        public List<MovieDto> GetMovies(Genre? genre)
        {
            return moviesRepository
                .GetMoviesByGenre(genre)
                .Select(m => mapper.Map<MovieDto>(m))
                .ToList();
        }
    }
}
