using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LambdaCopaFilmesWebAPI.Domain.Models;
using LambdaCopaFilmesWebAPI.Domain.Services;

namespace LambdaCopaFilmesWebAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient client = new HttpClient();

        public MovieService()
        {
            client.BaseAddress = new Uri("http://copafilmes.azurewebsites.net/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            List<Movie> movies = new List<Movie>();

            HttpResponseMessage response = await client.GetAsync("filmes");
            if (response.IsSuccessStatusCode)
            {
                movies = await response.Content.ReadAsAsync<List<Movie>>();
            }
            return movies;
        }

        public IEnumerable<Movie> RunChampionship(IList<Movie> movies)
        {
            if (movies == null || movies.Count != 8)
                return null;

            movies = movies.OrderBy(x => x.Titulo).ToList();
            int j = movies.Count - 1;
            Movie[] moviesArray = new Movie[4];
            for (int i = 0; i < 4; i++)
            {
                moviesArray[i] = Movie.Greater(movies[i], movies[j]);
                j--;
            }

            moviesArray = new Movie[2]
            {
                Movie.Greater(moviesArray[0], moviesArray[1]),
                Movie.Greater(moviesArray[2], moviesArray[3])
            };

            if (Movie.Greater(moviesArray[0], moviesArray[1]).Id.Equals(moviesArray[1].Id))
            {
                Movie movie = moviesArray[0];
                moviesArray[0] = moviesArray[1];
                moviesArray[1] = movie;
            }
            return moviesArray;
        }
    }
}
