using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovies.Core.Models
{
    public class Screen
    {
        public int ScreenID { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public int CinemaID { get; set; }

        public Screen(int screenID, int number, int capacity, int cinemaID)
        {
            ScreenID = screenID;
            Number = number;
            Capacity = capacity;
            CinemaID = cinemaID;
        }

        public string ToFileString()
        {
            return $"{ScreenID};{Number};{Capacity};{CinemaID}";
        }


        public static Screen FromFileString(string line)
        {
            string[] values = line.Split(';');

            return new Screen
            {
                ScreenID = int.Parse(values[0]),
                Number = int.Parse(values[1]),
                Capacity = int.Parse(values[2]),
                CinemaID = int.Parse(values[3])
            };

        }

    }
}
