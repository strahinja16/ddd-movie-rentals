using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [HttpGet]
        public IEnumerable<Movie> Get([FromQuery()] Genre? genre)
        {
            return moviesService.GetMovies(genre);
        }

        [HttpGet("{id}")]
        public Movie Get(Guid id)
        {
            return moviesService.GetMovieById(id);
        }
    }
}
