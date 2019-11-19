using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using LambdaCopaFilmesWebAPI.Services;
using LambdaCopaFilmesWebAPI.Domain.Services;
using LambdaCopaFilmesWebAPI.Domain.Models;
using Newtonsoft.Json;

namespace LambdaCopaFilmesWebAPI.Tests
{
    public class MovieServiceTests
    {
        private readonly IMovieService MovieService;
        private readonly List<Movie> Movies;

        public MovieServiceTests()
        {
            this.MovieService = new MovieService();
            var moviesJson = "[{ \"id\":\"tt3606756\",\"titulo\":\"Os Incríveis 2\",\"ano\":2018,\"nota\":8.5},{ \"id\":\"tt4881806\",\"titulo\":\"Jurassic World: Reino Ameaçado\",\"ano\":2018,\"nota\":6.7},{ \"id\":\"tt5164214\",\"titulo\":\"Oito Mulheres e um Segredo\",\"ano\":2018,\"nota\":6.3},{ \"id\":\"tt7784604\",\"titulo\":\"Hereditário\",\"ano\":2018,\"nota\":7.8},{ \"id\":\"tt4154756\",\"titulo\":\"Vingadores: Guerra Infinita\",\"ano\":2018,\"nota\":8.8},{ \"id\":\"tt5463162\",\"titulo\":\"Deadpool 2\",\"ano\":2018,\"nota\":8.1},{ \"id\":\"tt3778644\",\"titulo\":\"Han Solo: Uma História Star Wars\",\"ano\":2018,\"nota\":7.2},{ \"id\":\"tt3501632\",\"titulo\":\"Thor: Ragnarok\",\"ano\":2017,\"nota\":7.9},{ \"id\":\"tt2854926\",\"titulo\":\"Te Peguei!\",\"ano\":2018,\"nota\":7.1},{ \"id\":\"tt0317705\",\"titulo\":\"Os Incríveis\",\"ano\":2004,\"nota\":8.0},{ \"id\":\"tt3799232\",\"titulo\":\"A Barraca do Beijo\",\"ano\":2018,\"nota\":6.4},{ \"id\":\"tt1365519\",\"titulo\":\"Tomb Raider: A Origem\",\"ano\":2018,\"nota\":6.5},{ \"id\":\"tt1825683\",\"titulo\":\"Pantera Negra\",\"ano\":2018,\"nota\":7.5},{ \"id\":\"tt5834262\",\"titulo\":\"Hotel Artemis\",\"ano\":2018,\"nota\":6.3},{ \"id\":\"tt7690670\",\"titulo\":\"Superfly\",\"ano\":2018,\"nota\":5.1},{ \"id\":\"tt6499752\",\"titulo\":\"Upgrade\",\"ano\":2018,\"nota\":7.8}]";
            this.Movies = JsonConvert.DeserializeObject<List<Movie>>(moviesJson);
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
            List<Movie> incompleteMovies = this.Movies.Take(4).ToList();
            var result = this.MovieService.RunChampionship(incompleteMovies);
            Assert.Null(result);
        }

        [Fact]
        public void RunChampionship_First8Items_ReturnVingadoresAndOsIncriveis2()
        {
            List<Movie> first8Movies = this.Movies.Take(8).ToList();
            List<Movie> champions = new List<Movie>()
            {
                first8Movies[4],
                first8Movies[0]
            };
            var result = this.MovieService.RunChampionship(first8Movies);
            Assert.Equal(result, champions);
        }

        [Fact]
        public void RunChampionship_Last8Items_ReturnOsIncriveisAndPanteraNegra()
        {
            List<Movie> last8Movies = this.Movies.Skip(8).Take(8).ToList();
            List<Movie> champions = new List<Movie>()
            {
                last8Movies[1],
                last8Movies[7]
            };
            var result = this.MovieService.RunChampionship(last8Movies);
            Assert.Equal(result, champions);
        }
    }
}
