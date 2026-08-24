using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Models;

namespace TheMovies.Core.Repositories
{
    public interface IScreenRepository
    {
        IEnumerable<Screen> GetAll();

        Screen GetByID(int id);

        void Add(Screen screen);
    }
}
