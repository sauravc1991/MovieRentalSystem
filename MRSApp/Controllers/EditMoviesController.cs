using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRSDataAccess.Entity;

namespace MRSApp.Controllers
{
    public class EditMoviesController : Controller
    {
        private MovieRentalSystemEntities db = new MovieRentalSystemEntities();

        //
        // GET: /EditMovies/

        public ActionResult Index()
        {
            var movieinformations = db.MovieInformations.Include("Genre").Include("Language");
            return View(movieinformations.ToList());
        }

        //
        // GET: /EditMovies/Details/5

        public ActionResult Details(int id = 0)
        {
            MovieInformation movieinformation = db.MovieInformations.Single(m => m.MovieID == id);
            if (movieinformation == null)
            {
                return HttpNotFound();
            }
            return View(movieinformation);
        }

        //
        // GET: /EditMovies/Create

        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName");
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "LanguageName");
            return View();
        }

        //
        // POST: /EditMovies/Create

        [HttpPost]
        public ActionResult Create(MovieInformation movieinformation)
        {
            if (ModelState.IsValid)
            {
                db.MovieInformations.AddObject(movieinformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", movieinformation.GenreID);
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "LanguageName", movieinformation.LanguageID);
            return View(movieinformation);
        }

        //
        // GET: /EditMovies/Edit/5

        public ActionResult Edit(int mid = 0)
        {
            MovieInformation movieinformation = db.MovieInformations.Single(m => m.MovieID == mid);
            if (movieinformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", movieinformation.GenreID);
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "LanguageName", movieinformation.LanguageID);
            return View(movieinformation);
        }

        //
        // POST: /EditMovies/Edit/5

        [HttpPost]
        public ActionResult Edit(MovieInformation movieinformation)
        {
            if (ModelState.IsValid)
            {
                db.MovieInformations.Attach(movieinformation);
                db.ObjectStateManager.ChangeObjectState(movieinformation, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", movieinformation.GenreID);
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "LanguageName", movieinformation.LanguageID);
            return View(movieinformation);
        }

        //
        // GET: /EditMovies/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MovieInformation movieinformation = db.MovieInformations.Single(m => m.MovieID == id);
            if (movieinformation == null)
            {
                return HttpNotFound();
            }
            return View(movieinformation);
        }

        //
        // POST: /EditMovies/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieInformation movieinformation = db.MovieInformations.Single(m => m.MovieID == id);
            db.MovieInformations.DeleteObject(movieinformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}