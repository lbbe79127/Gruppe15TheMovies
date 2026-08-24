using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Models;

namespace TheMovies.Core.Repositories
{
    public interface IShowingRepository
    {
        IEnumerable<Showing> GetAll();

        Showing GetByID(int id);

        void Add(Showing showing);
    }
}
