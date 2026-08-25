using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Models;


namespace TheMovies.Core.Repositories
{
    public interface ICinemaRepository
    {
        IEnumerable<Cinema> GetAll();

        Cinema GetByID(int id);

        void Add(Cinema cinema);

    }
}
