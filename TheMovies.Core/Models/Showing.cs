using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovies.Core.Models
{
    public class Showing
    {
        public int ShowingID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MovieID { get; set; }
        public int ScreenID { get; set; }
    }
}
