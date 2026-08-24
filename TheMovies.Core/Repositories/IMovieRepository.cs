using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Models;

namespace TheMovies.Core.Repositories
{
    public interface IMovieRepository
    {
        //Henter alle film
        IEnumerable<Movie> GetAll();

        //Henter en film ud fra ID
        Movie GetByID(int MovieID);

        //Tilføj ny film
        void Add(Movie movie);
    }
}
