using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LambdaCopaFilmesWebAPI.Domain.Services;
using LambdaCopaFilmesWebAPI.Domain.Models;
using Microsoft.AspNetCore.Cors;

namespace LambdaCopaFilmesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipController : ControllerBase
    {
        private readonly IMovieService movieService;

        public ChampionshipController(IMovieService movieService)
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