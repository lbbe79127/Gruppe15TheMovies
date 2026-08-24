using System;
using System.Collections.Generic;
using System.Text;


namespace TheMovies.Core.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string Instructor { get; set; }
        public DateTime PremiereDate { get; set; }

        public Movie()
        {

        }

        //Constructor
        public Movie(int movieID, string title, int duration, string genre, string instructor, DateTime premiereDate)
        {
            MovieID = movieID;
            Title = title;
            Duration = duration;
            Genre = genre;
            Instructor = instructor;
            PremiereDate = premiereDate;
        }

        //Konvertere Movie-objekt til en streng, som kan gemmes i tekstfil
        public string ToFileString()
        {
            return $"{MovieID};{Title};{Duration};{Genre};{Instructor};{PremiereDate}";
        }

        //Opretter et Movie-objekt ud fra en linje i en tekstfil
        public static Movie FromFileString(string line)
        {
            string[] values = line.Split(';');
            return new Movie
            {
                MovieID = int.Parse(values[0]),
                Title = values[1],
                Duration = int.Parse(values[2]),
                Genre = values[3],
                Instructor = values[4],
                PremiereDate = DateTime.Parse(values[5])
            };
        }


    }
}
