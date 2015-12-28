using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRSApp.Models;
using MRSDataAccess.Entity;
using System.Data;

namespace MRSApp.Controllers
{
    public class ManageMoviesController : Controller
    {
        MRSDataAccess.Entity.MovieRentalSystemEntities DataContext = null;
        public ActionResult Index()
        {
            DataContext = new MRSDataAccess.Entity.MovieRentalSystemEntities();
            MRSDataAccess.Entity.MovieInformation movieinformation = new MRSDataAccess.Entity.MovieInformation();
            ViewBag.GenreID = new SelectList(DataContext.Genres, "GenreID", "GenreName", movieinformation.GenreID);
            ViewBag.LanguageID = new SelectList(DataContext.Languages, "LanguageID", "LanguageName", movieinformation.LanguageID);
            return View();
        }

        [HttpPost]
        public ActionResult AddMovie(MovieData obj)
        {
            DataContext = new MRSDataAccess.Entity.MovieRentalSystemEntities();

            int stat=DataContext.InsertMovie(obj.MovieID, obj.LanguageId, obj.GenreID, obj.MovieName, obj.Rating, obj.Price, obj.Stock, obj.Description, obj.Status);
            if (stat == 1)
            {
                ViewBag.Status = "Movie added successfully";
            }
            else
            {
                ViewBag.Status = "Movie not added";
            }
            return View();
        }

        public ActionResult Delete()
        {
            MRSDataAccess.Repositories.MovieRepository movieRepo = new MRSDataAccess.Repositories.MovieRepository();
            int mid=int.Parse(Request.QueryString["mid"]);
            int stat = movieRepo.DeleteMovie(mid);
            if (stat == 1)
            {
                ViewBag.Status = "Movie Deleted successfully";
            }
            else
            {
                ViewBag.Status = "Movie not Deleted";
            }
            MRSDataAccess.Repositories.MovieRepository movieRepo1 = new MRSDataAccess.Repositories.MovieRepository();
            var movies = movieRepo.GetAllMovies();  
            return View(movies);
        }
       
        public ActionResult Edit(int mid = 0)
        {
            DataContext = new MRSDataAccess.Entity.MovieRentalSystemEntities();
            MRSDataAccess.Entity.MovieInformation movieinformation = DataContext.MovieInformations.Single(m => m.MovieID == mid);
            ViewBag.GenreID = new SelectList(DataContext.Genres, "GenreID", "GenreName", movieinformation.GenreID);
            ViewBag.LanguageID = new SelectList(DataContext.Languages, "LanguageID", "LanguageName", movieinformation.LanguageID);
            return View(movieinformation);
        }


        [HttpPost]
        public ActionResult Edit(MovieInformation movieinformation)
        {
            DataContext = new MRSDataAccess.Entity.MovieRentalSystemEntities();
            if (ModelState.IsValid)
            {
                DataContext.MovieInformations.Attach(movieinformation);
                DataContext.ObjectStateManager.ChangeObjectState(movieinformation, EntityState.Modified);
                DataContext.SaveChanges();
                ViewBag.Status = "Movie Details Updated Successfully";
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(DataContext.Genres, "GenreID", "GenreName", movieinformation.GenreID);
            ViewBag.LanguageID = new SelectList(DataContext.Languages, "LanguageID", "LanguageName", movieinformation.LanguageID);
            return View(movieinformation);
        }

        
      

        
    }
}
