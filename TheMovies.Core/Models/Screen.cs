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
    }
}
