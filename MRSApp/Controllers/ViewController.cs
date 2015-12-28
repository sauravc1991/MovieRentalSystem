using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSApp.Controllers
{
    
    
    
    public class ViewController : Controller
    {
        MRSDataAccess.Repositories.UserRepositories userRepo = null;
             
        public ActionResult Index()
        {
            userRepo = new MRSDataAccess.Repositories.UserRepositories();
            var usrs = userRepo.GetAllUsers();
            return View(usrs);
        }

        public ActionResult ViewUserByID()
        {
            userRepo = new MRSDataAccess.Repositories.UserRepositories();
            int uid = int.Parse(Session["UID"].ToString());
            var user=userRepo.ViewUserProfile(uid);
            return View(user);

        }

        public ActionResult ViewAllMovie(int id=0)
        {
            MRSDataAccess.Entity.MovieRentalSystemEntities db=new MRSDataAccess.Entity.MovieRentalSystemEntities();
            MRSDataAccess.Repositories.MovieRepository movieRepo = new MRSDataAccess.Repositories.MovieRepository();
            var movies = movieRepo.GetAllMovies();  
            return View(movies);
        }

        public ActionResult ViewAllLanguage(int id = 0)
        {
            MRSDataAccess.Entity.MovieRentalSystemEntities db = new MRSDataAccess.Entity.MovieRentalSystemEntities();
            MRSDataAccess.Repositories.MovieRepository movieRepo = new MRSDataAccess.Repositories.MovieRepository();
            var languages = movieRepo.GetAllLanguages();
            return View(languages);
        }

       
    }
}
