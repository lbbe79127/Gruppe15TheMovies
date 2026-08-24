using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Models;

namespace TheMovies.Core.Repositories
{
    public class FileScreenRepository : IScreenRepository
    {
        private readonly string _filePath = "screens.txt";

        public FileScreenRepository()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }

        public IEnumerable<Screen> GetAll()
        {
            try
            {
                string[] lines = File.ReadAllLines(_filePath);

                List<Screen> screens = new List<Screen>();

                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        screens.Add(Screen.FromFileString(line));
                    }
                }
                return screens;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Read error: {ex.Message}");
                return new List<Screen>();
            }
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

        public void Add(Screen screen)
        {
            List<Screen> allScreens = GetAll().ToList();

            int maxID = 0;

            foreach (Screen s in allScreens)
            {
                if (s.ScreenID > maxID)
                {
                    maxID = s.ScreenID;
                }
            }

            screen.ScreenID = maxID + 1;


            try
            {
                StreamWriter writer = File.AppendText(_filePath);
                
                writer.WriteLine(screen.ToFileString());

                writer.Close();
                
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Write error: {ex.Message}");
            }
        }


    }
}
