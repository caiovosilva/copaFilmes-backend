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

        public async Task<IEnumerable<Movie>> ListAsync()
        {
            List<Movie> movies = new List<Movie>();

            HttpResponseMessage response = await client.GetAsync("filmes");
            if (response.IsSuccessStatusCode)
            {
                movies = await response.Content.ReadAsAsync<List<Movie>>();
            }
            return movies;
        }
    }
}
