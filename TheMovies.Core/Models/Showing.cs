using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovies.Core.Models
{
    public class Showing
    {


        public int ShowingID { get; set; }
        public int MovieID { get; set; }
        public int ScreenNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
       


        public Showing()
        {

        }

        public Showing(int showingID, int movieID, int screenNumber, DateTime startTime, DateTime endTime)
        {
            ShowingID = showingID;
            MovieID = movieID;
            ScreenNumber = screenNumber;
            StartTime = startTime;
            EndTime = endTime;
        }

        public Showing(int movieID, int screenNumber, DateTime startTime, DateTime endTime)
        {
            MovieID = movieID;
            ScreenNumber = screenNumber;
            StartTime = startTime;
            EndTime = endTime;
        }

        public string ToFileString()
        {
            return $"{ShowingID};{MovieID};{ScreenNumber};{StartTime};{EndTime}";
        }


        public static Showing FromFileString(string line)
        {
            string[] values = line.Split(';');

            return new Showing
            {
                ShowingID = int.Parse(values[0]),
                MovieID = int.Parse(values[1]),
                ScreenNumber = int.Parse(values[2]),
                StartTime = DateTime.Parse(values[3]),
                EndTime = DateTime.Parse(values[4])
            };
        }


    }


}
