using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaCopaFilmesWebAPI.Domain.Models
{
    public class Movie : IComparable<Movie>
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public Double Nota { get; set; }

        private static int Compare(Movie e1, Movie e2)
        {
            if (e1 == null && e2 == null)
                return 0;
            else if (e1 == null)
                return -1;
            else if (e2 == null)
                return 1;

            if (e1.Nota == e2.Nota)
            {
                if (String.Compare(e1.Titulo, e2.Titulo) < 1)
                    return -1;
                else
                    return 1;
            }
            else if (e1.Nota < e2.Nota)
                return -1;
            else
                return 1;
        }

        public int CompareTo(Movie other)
        {
            return Compare(this, other);
        }

        public static bool operator <(Movie e1, Movie e2)
        {
            return Compare(e1, e2) < 0;
        }

        public static bool operator >(Movie e1, Movie e2)
        {
            return Compare(e1, e2) > 0;
        }
    }
}
