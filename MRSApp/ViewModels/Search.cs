using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSApp.ViewModels
{
    public class Search
    {
        public string MSearch { get; set; }
        public IEnumerable<MRSDataAccess.Entity.MovieInformation> movies { get; set; }
    }
}