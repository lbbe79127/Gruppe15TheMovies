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
    }
}
