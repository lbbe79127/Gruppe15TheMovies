using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Models;

namespace TheMovies.Core.Repositories
{
    public class InMemoryScreenRepository : IScreenRepository
    {
        // Test Screens
        List<Screen> screenList = new List<Screen>()
        {
            new Screen(0,1,80,0),
            new Screen(1,2,80,0),
            new Screen(2,3,60,0),
            new Screen(3,4,80,0),
            new Screen(4,1,80,1),
            new Screen(5,2,40,1),
            new Screen(6,1,80,2),
            new Screen(7,1,30,3),
            new Screen(8,1,70,4),
            new Screen(9,2,80,4),
        };

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
