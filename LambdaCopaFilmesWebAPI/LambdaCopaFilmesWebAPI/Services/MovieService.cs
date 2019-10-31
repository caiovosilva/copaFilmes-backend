using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LambdaCopaFilmesWebAPI.Domain.Models;

namespace LambdaCopaFilmesWebAPI.Domain.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient client = new HttpClient();

        public MovieService()
        {
            client.BaseAddress = new Uri("http://copafilmes.azurewebsites.net/api/filmes");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Movie>> ListAsync()
        {
            List<Movie> lista = new List<Movie>();
            lista.Add(new Movie());

            HttpResponseMessage response = await client.GetAsync();
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }
    }
}
