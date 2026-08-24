using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TheMovies.Core.Models;

namespace TheMovies.Core.Repositories
{
    public class FileShowingRepository : IShowingRepository
    {

        private readonly string _filepath = "showing.txt";

        public FileShowingRepository()
        {
            if (!File.Exists(_filepath))
            {
                File.Create(_filepath).Close();
            }
        }


        public IEnumerable<Showing> GetAll()
        {
            try
            {
                string[] lines = File.ReadAllLines(_filepath);

                List<Showing> showings = new();

                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        showings.Add(Showing.FromFileString(line));
                    }
                }

                return showings;
            }

            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
                return new List<Showing>();
            }

        }


        public Showing GetByID(int id)
        {
            foreach (Showing showing in GetAll())
            {
                if (showing.ShowingID == id)
                {
                    return showing;
                }
            }

            return null;
        }


        public void Add(Showing showing)
        {
            List<Showing> allShowings = GetAll().ToList();

            int maxID = 0;

            foreach (Showing s in allShowings)
            {
                if (s.ShowingID > maxID)
                {
                    maxID = s.ShowingID;
                }
            }

            showing.ShowingID = maxID + 1;


            try
            {
                StreamWriter writer = File.AppendText(_filepath);

                writer.WriteLine(showing.ToFileString());

                writer.Close();
            }

            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }



    }
}
