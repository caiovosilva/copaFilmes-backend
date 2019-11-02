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

        public static Movie Greater(Movie e1, Movie e2)
        {
            if (e1 == null && e2 == null)
                return null;
            else if (e1 == null)
                return e2;
            else if (e2 == null)
                return e1;

            if (e1.Nota == e2.Nota)
            {
                if (String.Compare(e1.Titulo, e2.Titulo) < 1)
                    return e2;
                else
                    return e1;
            }
            else if (e1.Nota < e2.Nota)
                return e2;
            else
                return e1;
        }
    }
}
