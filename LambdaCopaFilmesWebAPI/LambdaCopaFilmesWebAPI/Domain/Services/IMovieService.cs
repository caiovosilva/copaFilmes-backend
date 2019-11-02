﻿using System.Collections.Generic;
using System.Threading.Tasks;
using LambdaCopaFilmesWebAPI.Domain.Models;

namespace LambdaCopaFilmesWebAPI.Domain.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> RunChampionship(List<Movie> movies);
    }
}