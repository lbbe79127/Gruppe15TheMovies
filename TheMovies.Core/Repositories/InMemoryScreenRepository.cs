using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Models;

namespace TheMovies.Core.Repositories
{
    class InMemoryScreenRepository : IScreenRepository
    {
        List<Screen> screenList = new List<Screen>();

        public void Add(Screen screen)
        {
            screenList.Add(screen);
        }

        public IEnumerable<Screen> GetAll()
        {
            return screenList;
        }

        public Screen GetByID(int id)
        {
            foreach (Screen screen in GetAll())
            {
                if (screen.ScreenID == id)
                {
                    return screen;
                }
            }
            return null;
        }
    }
}
