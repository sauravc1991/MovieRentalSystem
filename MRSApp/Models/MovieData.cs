using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSApp.Models
{
    public class MovieData : MRSDataAccess.Entity.MovieRentalSystemEntities
    {
        public int MovieID { get; set; }
        public int LanguageId { get; set; }
        public int GenreID { get; set; }
        public string MovieName { get; set; }
        public int Rating { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

     }
}