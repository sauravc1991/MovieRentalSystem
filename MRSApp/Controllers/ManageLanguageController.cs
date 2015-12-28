using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MRSApp.Models;
using MRSDataAccess.Entity;

namespace MRSApp.Controllers
{
    public class ManageLanguageController : Controller
    {
        MRSDataAccess.Entity.MovieRentalSystemEntities DataContext = null;
        public ActionResult Index()
        {
            DataContext = new MRSDataAccess.Entity.MovieRentalSystemEntities();
            MRSDataAccess.Entity.Language movieinformation = new MRSDataAccess.Entity.Language();
            //ViewBag.LanguageID = new SelectList(DataContext.Languages, "LanguageID", "LanguageName", movieinformation.LanguageID);
            return View();
        }

        [HttpPost]
        public ActionResult AddLanguage(MRSDataAccess.Entity.Language obj)
        {
            DataContext = new MRSDataAccess.Entity.MovieRentalSystemEntities();

            int stat = DataContext.InsertLanguage(obj.LanguageName);
            if (stat == 1)
            {
                ViewBag.Status = "Language added successfully";
            }
            else
            {
                ViewBag.Status = "Language not added";
            }
            return View();
        }

        public ActionResult Delete()
        {
            int stat = 0;
            MRSDataAccess.Repositories.MovieRepository movieRepo = new MRSDataAccess.Repositories.MovieRepository();
            int lid = int.Parse(Request.QueryString["lid"]);
            try
            {
                stat = movieRepo.DeleteLanguage(lid);
            }
            catch (Exception ex)
            {
                ViewBag.Excp = ex;
                ViewBag.Status = "The Language is referenced to some Movies, Hence it cannot be deleted";
            }
            if (stat == 1)
            {
                ViewBag.Status = "Language Deleted successfully";
            }

            MRSDataAccess.Repositories.MovieRepository movieRepo1 = new MRSDataAccess.Repositories.MovieRepository();
            var languages = movieRepo.GetAllLanguages();
            return View(languages);
        }
        [HttpGet]
        public ActionResult Edit(int lid = 0)
        {
            DataContext = new MRSDataAccess.Entity.MovieRentalSystemEntities();
            MRSDataAccess.Entity.Language language = DataContext.Languages.Single(l => l.LanguageID == lid);
            //ViewBag.GenreID = new SelectList(DataContext.Genres, "GenreID", "GenreName", language.GenreID);
            ViewBag.LanguageID = new SelectList(DataContext.Languages, "LanguageID", "LanguageID", language.LanguageID);
            return View(language);
           
        }


        [HttpPost]
        public ActionResult Edit(MRSDataAccess.Entity.Language language)
        {
            DataContext = new MRSDataAccess.Entity.MovieRentalSystemEntities();
            if (ModelState.IsValid)
            {
                DataContext.Languages.Attach(language);
                DataContext.ObjectStateManager.ChangeObjectState(language, EntityState.Modified);
                DataContext.SaveChanges();
                ViewBag.Status = "Movie Details Updated Successfully";
                return RedirectToAction("Index");
            }
            //ViewBag.GenreID = new SelectList(DataContext.Genres, "GenreID", "GenreName", language.GenreID);
            ViewBag.LanguageID = new SelectList(DataContext.Languages, "LanguageID", "LanguageID", language.LanguageID);
            return View(language);

        }
    }
}
