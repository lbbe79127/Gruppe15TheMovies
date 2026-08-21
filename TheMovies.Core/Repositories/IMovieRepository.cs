using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Models;

namespace TheMovies.Core.Repositories
{
    public interface IMovieRepository
    {
        void SaveMovie(Movie movie);
        List<Movie> LoadMovies();
    }
}
