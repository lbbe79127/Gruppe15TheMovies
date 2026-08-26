using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Models;
using System.Linq;

namespace TheMovies.Core.Repositories
{
    class InMemoryCinemaRepository : ICinemaRepository
    {
        List<Cinema> cinemaList = new List<Cinema>();


        public void Add(Cinema cinema)
        {
            cinemaList.Add(cinema);
        }

        public IEnumerable<Cinema> GetAll()
        {
            return cinemaList;
        }

        public Cinema GetByID(int id)
        {
            foreach (Cinema cinema in GetAll())
            {
                if (cinema.CinemaID == id)
                {
                    return cinema;
                }
            }

            return null;
        }
    }
}
