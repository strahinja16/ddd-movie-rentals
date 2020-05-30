using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using Core.Interfaces.Infrastructure;
using Core.Models;
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

        public MovieDto AddPromoCode(PromoCodeDto promoCodeDto)
        {
            var movie = moviesRepository.FindById(promoCodeDto.MovieId);
            if (movie == null)
            {
                throw new HttpException("Movie not found.", HttpStatusCode.NotFound);
            }

            var promoCode = PromoCode.Create(movie, promoCodeDto.PromoEnd, promoCodeDto.Percentage);
            moviesRepository.AddPromoCode(promoCode);

            return mapper.Map<MovieDto>(movie);
        }

        public MovieDto GetMovieById(Guid id)
        {
            var movie = moviesRepository.FindById(id);

            if (movie == null)
            {
                throw new HttpException("Movie not found.", HttpStatusCode.NotFound);
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
