using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using LambdaCopaFilmesWebAPI.Services;
using LambdaCopaFilmesWebAPI.Domain.Services;
using LambdaCopaFilmesWebAPI.Domain.Models;

namespace LambdaCopaFilmesWebAPI.Tests
{
    public class MovieServiceTests
    {
        private readonly IMovieService MovieService;

        public MovieServiceTests()
        {
            this.MovieService = new MovieService();
        }


        [Fact]
        public void RunChampionship_InputIsNull_ReturnNull()
        {
            var result = this.MovieService.RunChampionship(null);
            Assert.Null(result);
        }

        [Fact]
        public void RunChampionship_InputDoNotHave8Items_ReturnNull()
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie(){ Id="tt3606756", Titulo="Os Incríveis 2", Ano=2018, Nota=8.5 },
                new Movie(){ Id="tt36065", Titulo="Os Incríveis 3", Ano=2019, Nota=8.6 },
                new Movie(){ Id="tt38756", Titulo="Os Incríveis 4", Ano=2020, Nota=8.7 }

            };
            var result = this.MovieService.RunChampionship(movies);
            Assert.Null(result);
        }
    }
}
