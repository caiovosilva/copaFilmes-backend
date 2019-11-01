using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LambdaCopaFilmesWebAPI.Domain.Services;
using LambdaCopaFilmesWebAPI.Domain.Models;

namespace LambdaCopaFilmesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        //[HttpGet]
        //public async Task<IEnumerable<Movie>> GetAllAsync()
        //{
        //    var result = await this.movieService.ListAsync();
        //    return result;
        //}

        [HttpGet]
        public async Task<IEnumerable<Movie>> GetChampionshipAsync([FromBody] Movies movies)
        {
            Console.Write(movies);
            var result = await this.movieService.ListAsync();
            return result;
        }
    }
}