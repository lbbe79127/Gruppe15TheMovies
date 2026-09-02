using System;
using System.Collections.Generic;
using System.Text;


namespace TheMovies.Core.Models
{
    public class Movie
    {
        private static int _nextId = 1;

        public int MovieID { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string Instructor { get; set; }
        public DateTime PremiereDate { get; set; }


        // bruges af repo ved opstart
        public static void UpdateID(int nextId)
        {
            _nextId = nextId;
        }

        public Movie()
        {

        }

        //Constructor. Bruges når film læses fra fil
        public Movie(int movieID, string title, int duration, string genre, string instructor, DateTime premiereDate)
        {
            MovieID = movieID;
            Title = title;
            Duration = duration;
            Genre = genre;
            Instructor = instructor;
            PremiereDate = premiereDate;
        }


        //Constructor. Bruges når ny film oprettes
        public Movie(string title, int duration, string genre, string instructor, DateTime premiereDate)
        {
            MovieID = _nextId++;
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
