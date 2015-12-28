using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSApp.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SearchMovieByName()
        {
            string searchterm = Request.Form["MSearch"];
            MRSDataAccess.Entity.MovieRentalSystemEntities db = new MRSDataAccess.Entity.MovieRentalSystemEntities();
            List<MRSDataAccess.Entity.MovieInformation> movies = db.MovieInformations.Where(m => m.MovieName.StartsWith(searchterm)).ToList();
           return View(movies);
        }
      

    }
}
