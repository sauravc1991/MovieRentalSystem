using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSApp.Controllers
{
    public class ReserveController : Controller
    {
      

        public ActionResult Index()
        {
            MRSDataAccess.Entity.MovieRentalSystemEntities db = new MRSDataAccess.Entity.MovieRentalSystemEntities();
            MRSDataAccess.Repositories.MovieRepository movieRepo = new MRSDataAccess.Repositories.MovieRepository();
            var movies = movieRepo.GetAllMovies();
            return View(movies);
            
        }

        
        public ActionResult ReserveMovie()
        {
            MRSDataAccess.Repositories.MovieRepository MovieRepo = new MRSDataAccess.Repositories.MovieRepository();
            var movies = MovieRepo.GetAllMovies();
            int stock;
            int uid = int.Parse(Session["UID"].ToString());
            int mid = int.Parse(Request.QueryString["mid"]);
            stock = MovieRepo.CheckStock(mid);
            int reserveID;
            
            //check count
            int count=MovieRepo.CountMovie(uid);
            if (count < 3)
            {
           
                MRSDataAccess.Entity.MovieRentalSystemEntities db = new MRSDataAccess.Entity.MovieRentalSystemEntities();
                var request = new System.Data.Objects.ObjectParameter("requestID", typeof(int));
                db.ReserveMovie(uid, mid, "RESERVED", request);
                reserveID= (int)request.Value;
                @ViewBag.requestID = reserveID;

                if (stock > 0)
                {
                    ViewBag.status = "Your Movie has been booked successfully and your request ID is ";
                }
                else
                {
                    ViewBag.status = "The movie is not currently in stock but your request has been taken and it will be available shortly. Your Request ID is ";
                }
            }
            else
            {
                ViewBag.status="You have exceeded the maximum number of bookings per user";
            }
            return View(movies);
        }
    }
}
