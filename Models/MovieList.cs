using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public static class MovieLists
    {
        private static List<AddMovieModel> movies = new List<AddMovieModel>();

        public static IEnumerable<AddMovieModel> Movies => movies;

        public static void AddMovie(AddMovieModel movie)
        {
            movies.Add(movie);
        }
    }
}
