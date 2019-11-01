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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Movie>>> GetChampionshipAsync([FromBody] Movie[] movies)
        {
            Console.Write(movies);
            if (movies.Length != 8)
                return BadRequest();
            var result = await this.movieService.RunChampionshipAsync(movies);
            return movies;
        }
    }
}