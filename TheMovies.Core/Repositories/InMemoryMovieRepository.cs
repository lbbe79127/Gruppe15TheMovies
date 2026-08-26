using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Models;

namespace TheMovies.Core.Repositories
{
    class InMemoryMovieRepository : IMovieRepository
    {
        List<Movie> movieList = new List<Movie>();

        public void Add(Movie movie)
        {
            movieList.Add(movie);
        }

        public IEnumerable<Movie> GetAll()
        {
            return movieList;
        }

        public Movie GetByID(int movieID)
        {
            foreach (Movie movie in GetAll())
            {
                if (movie.MovieID == movieID)
                {
                    return movie;
                }
            }

            return null;
        }
    }
}
