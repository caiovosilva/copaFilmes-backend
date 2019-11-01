using System.Collections.Generic;
using System.Threading.Tasks;
using LambdaCopaFilmesWebAPI.Domain.Models;

namespace LambdaCopaFilmesWebAPI.Domain.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> ListAsync();

        Task<IEnumerable<Movie>> RunChampionshipAsync(string[] moviesIds);
    }
}