using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovies.Core.Models
{
    public class Cinema
    {
        //Properties
        public int CinemaID { get; set; }
        public string Name { get; set; }


        //Tom konstruktør
        public Cinema()
        {

        }

        public Cinema(int cinemaID, string name)
        {
            CinemaID = cinemaID;
            Name = name;
        }

        public Cinema(string name)
        {
            Name = name;
        }

        public string ToFileString()
        {
            return $"{CinemaID};{Name}";
        }

        public static Cinema FromFileString(string line)
        {
            string[] values = line.Split(';');
            return new Cinema
            {
                CinemaID = int.Parse(values[0]),
                Name = values[1]
            };
        }



    }
}
