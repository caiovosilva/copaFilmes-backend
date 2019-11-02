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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Movie>> RunChampionship([FromBody] List<Movie> movies)
        {
            if (movies.Count != 8)
                return BadRequest();
            var result = this.movieService.RunChampionship(movies);
            return Ok(result);
        }
    }
}