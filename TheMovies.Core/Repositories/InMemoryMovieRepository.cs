using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Models;

namespace TheMovies.Core.Repositories
{
    public class InMemoryMovieRepository : IMovieRepository
    {
        // Test movies
        List<Movie> movieList = new List<Movie>()
        {
            new Movie() { MovieID = 0, Title = "De uskyldige", Duration = 117, Director = "Eskil Vogt", Genre = "Thriller", PremiereDate = DateTime.Now },
            new Movie() { MovieID = 1, Title = "Druk", Duration = 117, Director = "Thomas Vinterberg", Genre = "Comedy", PremiereDate = DateTime.Now }

        };

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
