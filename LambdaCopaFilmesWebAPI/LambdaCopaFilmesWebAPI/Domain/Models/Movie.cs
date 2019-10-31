using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaCopaFilmesWebAPI.Domain.Models
{
    public class Movie
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public Double Nota { get; set; }

        public static implicit operator List<object>(Movie v)
        {
            throw new NotImplementedException();
        }
    }
}
