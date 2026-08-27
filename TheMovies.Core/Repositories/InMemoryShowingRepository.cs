using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Models;

namespace TheMovies.Core.Repositories
{
    public class InMemoryShowingRepository : IShowingRepository
    {
        List<Showing> showingList = new List<Showing>();

        public void Add(Showing showing)
        {
            showingList.Add(showing);
        }

        public IEnumerable<Showing> GetAll()
        {
            return showingList;
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
    }
}
