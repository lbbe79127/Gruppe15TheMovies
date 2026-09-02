using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TheMovies.Core.Models;



namespace TheMovies.Core.Repositories
{
    public class FileMovieRepository : IMovieRepository
    {

        private readonly string _filepath = "movies.txt";


        public FileMovieRepository()
        {
            if (!File.Exists(_filepath))
            {
                File.Create(_filepath).Close();
            }

            int maxID = 0;

            foreach (Movie movie in GetAll())
            {
                if (movie.MovieID > maxID)
                {
                    maxID = movie.MovieID;
                }
            }

            Movie.UpdateID(maxID + 1);
        }


        public IEnumerable<Movie> GetAll()
        {
            try
            {
                string[] lines = File.ReadAllLines(_filepath);

                List<Movie> movies = new List<Movie>();

                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        movies.Add(Movie.FromFileString(line));
                    }
                }

                return movies;
            }

            catch (IOException ex)
            {
                Debug.WriteLine($"Read error: {ex.Message}");
                return new List<Movie>();
            }
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


        public void Add(Movie movie)
        {
            try
            {
                StreamWriter writer = File.AppendText(_filepath);

                writer.WriteLine(movie.ToFileString());

                writer.Close();
            }

            catch (IOException ex)
            {
                Debug.WriteLine($"Write error: {ex.Message}");
            }
        }


    }
    
}
