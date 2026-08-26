using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TheMovies.Core.Models;

namespace TheMovies.Core.Repositories
{
    public class InMemoryCinemaRepository : ICinemaRepository
    {
        // Test Cinemas
        List<Cinema> cinemaList = new List<Cinema>()
        {            
            new Cinema() { CinemaID = 0, Name = "Hjerm" },
            new Cinema() { CinemaID = 1, Name = "Videbæk" },
            new Cinema() { CinemaID = 2, Name = "Thorsminde" },
            new Cinema() { CinemaID = 3, Name = "Ræhr" },
            new Cinema() { CinemaID = 4, Name = "Østerbro" },
            new Cinema() { CinemaID = 5, Name = "Kolding" }
        };

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
