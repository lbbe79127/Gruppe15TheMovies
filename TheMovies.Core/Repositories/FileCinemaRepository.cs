using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TheMovies.Core.Models;
using TheMovies.Core.Repositories;

namespace TheMovies.Core.Repositories
{
    public class FileCinemaRepository : ICinemaRepository
    {
        private readonly string _filepath = "cinemas.txt";

        public FileCinemaRepository()
        {
            if (!File.Exists(_filepath))
            {
                File.Create(_filepath).Close();
            }
        }



        public IEnumerable<Cinema> GetAll()
        {
            try
            {
                string[] lines = File.ReadAllLines(_filepath);
                List<Cinema> cinemas = new();
                foreach (string line in lines)
                {
                    if(!string.IsNullOrWhiteSpace(line))
                    {
                        cinemas.Add(Cinema.FromFileString(line));
                    }
                }

                return cinemas;
            }

            catch (IOException ex)
            {
                Debug.WriteLine($"Read error: {ex.Message}");
                return new List<Cinema>();
            }
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


        public void Add(Cinema cinema)
        {
            List<Cinema> allCinemas = GetAll().ToList();

            int maxID = 0;

            foreach(Cinema existingCinema in allCinemas)
            {
                if (existingCinema.CinemaID > maxID)
                {
                    maxID = existingCinema.CinemaID;
                }
            }

            cinema.CinemaID = maxID + 1;

            try
            {
                StreamWriter writer = File.AppendText(_filepath);
                writer.WriteLine(cinema.ToFileString());
                writer.Close();
            }

            catch (IOException ex)
            {
                Debug.WriteLine($"Write error: {ex.Message}");
            }

        }
    }
}
