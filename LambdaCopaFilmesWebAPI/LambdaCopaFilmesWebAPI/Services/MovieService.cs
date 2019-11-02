﻿using System;
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
        public IEnumerable<Movie> RunChampionshipAsync(Movie[] movies)
        {
            int j = movies.Length - 1;
            Movie[] moviesArray = new Movie[movies.Length / 2];
            for (int i = 0; i < movies.Length / 2; i++)
            {
                moviesArray[i] = Movie.Greater(movies[i], movies[j]);
                j--;
            }

            moviesArray = new Movie[2]
            {
                Movie.Greater(moviesArray[0], moviesArray[1]),
                Movie.Greater(moviesArray[2], moviesArray[3])
            };

            if(Movie.Greater(moviesArray[0], moviesArray[1]).Id.Equals(moviesArray[1].Id))
            {
                Movie movie = moviesArray[0];
                moviesArray[0] = moviesArray[1];
                moviesArray[1] = movie;
            }
            return moviesArray;
        }
    }
}
