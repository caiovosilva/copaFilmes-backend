using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using LambdaCopaFilmesWebAPI.Services;
using LambdaCopaFilmesWebAPI.Domain.Services;

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
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var result = this.MovieService.RunChampionship();

            Assert.False(result, "1 should not be prime");
        }
    }
}
